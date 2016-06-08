USE PosPf
GO

CREATE PROCEDURE report_VentasPorSucursal
AS
	SELECT Vps.Nombre AS Sucursal, COUNT(Vps.IdVenta) AS CantidadDeVentas
	FROM View_VentasPorSucursal AS Vps
	WHERE Vps.Estado='A'
	GROUP BY Vps.Nombre
	GO

CREATE PROCEDURE report_5ProductosMasVendidos
AS
	SELECT TOP 5 Ppv.Nombre, SUM(Ppv.Cantidad) AS Total 
	FROM View_ProductoPorVenta AS Ppv
	WHERE Ppv.Estado='A'
	GROUP BY Ppv.Nombre
	GO

/* calculate the sales in a range */
CREATE PROCEDURE report_VentasInRange
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

	SELECT @dayPROFIT AS Día, @weekPROFIT AS Semana, @monthPROFIT AS Mes
GO



/* test query for ms checking 
EXEC sp_VentasInRange @initialDate='2016-06-07 20:10:16', @finalDate='2016-06-07 20:10:16.821'
EXEC report_Ventas @initialDATE='2016-06-01', @IdSucursal=6
*/
