USE PosPf

/* QUERIES -> to be coded directly into ssrs, it will never fail*/

/* Ventas por sucursal */
SELECT Vps.Nombre AS Sucursal, COUNT(Vps.IdVenta) AS CantidadDeVentas
FROM View_VentasPorSucursal AS Vps
WHERE Vps.Estado='A'
GROUP BY Vps.Nombre
GO

/* Productos más vendidos -> would fall in big DB*/
SELECT Ppv.Nombre, SUM(Ppv.Cantidad) AS Total 
FROM View_ProductoPorVenta AS Ppv
WHERE Ppv.Estado='A'
GROUP BY Ppv.Nombre
GO

/* 5 Productos más vendidos */
SELECT TOP 5 Ppv.Nombre, SUM(Ppv.Cantidad) AS Total 
FROM View_ProductoPorVenta AS Ppv
WHERE Ppv.Estado='A'
GROUP BY Ppv.Nombre
GO



/* STORED PROCEDURES -> allow to change the report without changing ssrs */

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