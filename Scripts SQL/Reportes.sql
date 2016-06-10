USE PosPf
GO

	/* counts the sales for every branch office in a month */
CREATE PROCEDURE report_VentasPorSucursalPorMes
	@initialDATE DATETIME
	AS
		DECLARE @monthDATE DATETIME
			SELECT @monthDATE=DATEADD (month, 1, @initialDATE)

	SELECT V.IdSucursal, V.NombreSucursal, V.Direccion, COUNT(V.IdVenta) AS CantidadDeVentas
	FROM View_Ventas AS V
	WHERE V.EstadoVenta='A' AND V.Timestamp BETWEEN @initialDATE AND @monthDATE
	GROUP BY V.IdSucursal, V.NombreSucursal, V.Direccion
GO

	/* calculate the total profit for every branch office in a month */
CREATE PROCEDURE report_GananciasGlobalesPorMes
	@initialDATE DATETIME
	AS
		DECLARE @monthDATE DATETIME
			SELECT @monthDATE=DATEADD (month, 1, @initialDATE)

	SELECT Ppv.IdSucursal, SUM(Cantidad*Precio) AS Ganancias
	FROM View_ProductoPorVenta AS Ppv
	WHERE Ppv.Timestamp BETWEEN @initialDATE AND @monthDATE
	GROUP BY Ppv.IdSucursal
GO

	/* Selects the top 5 sellers in a branch in a month */
CREATE PROCEDURE report_ProductosMásVendidosPorSucursalPorMes
	@initialDATE DATETIME, @IdSucursal INT
	AS
		DECLARE @monthDATE DATETIME
			SELECT @monthDATE=DATEADD (month, 1, @initialDATE)

	SELECT TOP 5 Ppv.Nombre, SUM(Ppv.Cantidad) AS Total, Ppv.NombreSucursal, Ppv.Direccion
	FROM View_ProductoPorVenta AS Ppv
	WHERE Ppv.Estado='A' AND Ppv.IdSucursal=@IdSucursal AND  Ppv.Timestamp BETWEEN @initialDATE AND @monthDATE
	GROUP BY Ppv.Nombre, Ppv.NombreSucursal, Ppv.Direccion
GO

	/* Selects the top 5 sellers in a month */
CREATE PROCEDURE report_ProductosMásVendidosGlobalPorMes
	@initialDATE DATETIME
	AS
		DECLARE @monthDATE DATETIME
			SELECT @monthDATE=DATEADD (month, 1, @initialDATE)

	SELECT TOP 5 Ppv.Nombre, SUM(Ppv.Cantidad) AS Total 
	FROM View_ProductoPorVenta AS Ppv
	WHERE Ppv.Estado='A' AND  Ppv.Timestamp BETWEEN @initialDATE AND @monthDATE
	GROUP BY Ppv.Nombre
GO

/* calculate the sales in a range of a branch office */
CREATE PROCEDURE report_GananciasInRange
@initialDATE DATETIME, @finalDATE DATETIME, @IdSucursal INT
AS
	SELECT SUM(Precio*Cantidad) AS Sale
	FROM View_ProductoPorVenta AS Ppv
	WHERE Ppv.IdSucursal=@IdSucursal AND Ppv.Timestamp BETWEEN @initialDATE AND @finalDATE
GO

/* calculate the sales in a day, week and month for a specific branch office*/
CREATE PROCEDURE report_Ganancias
@initialDATE DATETIME, @IdSucursal INT
AS
	DECLARE @dayDATE DATETIME, @weekDATE DATETIME, @monthDATE DATETIME
		SELECT @dayDATE=DATEADD (DAY, 1, @initialDATE)
		SELECT @weekDATE=DATEADD (DAY, 7, @initialDATE)
		SELECT @monthDATE=DATEADD (month, 1, @initialDATE)

	DECLARE @dayPROFIT money, @weekPROFIT money, @monthPROFIT money
		SELECT @dayPROFIT=SUM(Precio*Cantidad)
		FROM View_ProductoPorVenta AS Ppv
		WHERE Ppv.IdSucursal=@IdSucursal AND Ppv.Timestamp BETWEEN @initialDATE AND @dayDATE

		SELECT @weekPROFIT=SUM(Precio*Cantidad)
		FROM View_ProductoPorVenta AS Ppv
		WHERE Ppv.IdSucursal=@IdSucursal AND Ppv.Timestamp BETWEEN @initialDATE AND @weekDATE

		SELECT @monthPROFIT=SUM(Precio*Cantidad)
		FROM View_ProductoPorVenta AS Ppv
		WHERE Ppv.IdSucursal=@IdSucursal AND Ppv.Timestamp BETWEEN @initialDATE AND @monthDATE

	SELECT S.Nombre, S.Direccion, @dayPROFIT AS Día, @weekPROFIT AS Semana, @monthPROFIT AS Mes 
	FROM SUCURSAL AS S
	WHERE S.IdSucursal=@IdSucursal
GO

CREATE PROCEDURE report_TiempoEnCaja
	@IdCaja INT
	AS
		SELECT Vpc.IdCaja, AVG(Vpc.Duracion) AS DuraciónPromedio
		FROM View_VentaPorCaja AS Vpc
		WHERE @IdCaja=Vpc.IdCaja
		GROUP BY Vpc.IdCaja
	GO

/* test query for ms checking 
EXEC report_VentasPorSucursal @initialDATE = '20160601'
EXEC report_GananciasGlobalesPorMes @initialDATE='20160601'

EXEC sp_VentasInRange @initialDate='2016-06-07 20:10:16', @finalDate='2016-06-07 20:10:16.821'
EXEC report_Ventas @initialDATE='2016-06-01', @IdSucursal=6
*/
