


CREATE VIEW [dbo].[View_ProductoPorSucursal]
AS
SELECT        dbo.PRODUCTO.*, dbo.PRODUCTO_POR_SUCURSAL.Stock, dbo.PRODUCTO_POR_SUCURSAL.StockMinimo, dbo.SUCURSAL.IdSucursal, dbo.SUCURSAL.Nombre AS NombreSucursal, dbo.SUCURSAL.Direccion, 
                         dbo.SUCURSAL.Telefono, dbo.SUCURSAL.Estado AS EstadoSucursal
FROM            dbo.PRODUCTO INNER JOIN
                         dbo.PRODUCTO_POR_SUCURSAL ON dbo.PRODUCTO.IdProducto = dbo.PRODUCTO_POR_SUCURSAL.IdProducto INNER JOIN
                         dbo.SUCURSAL ON dbo.PRODUCTO_POR_SUCURSAL.IdSucursal = dbo.SUCURSAL.IdSucursal

GO