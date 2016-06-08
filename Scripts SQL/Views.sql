USE PosPF;
GO

CREATE VIEW [dbo].[View_CajaPorSucursal]
AS
SELECT        dbo.CAJA.IdCaja, dbo.CAJA.Dinero, dbo.CAJA.UltimoCierre, dbo.CAJA.Estado, dbo.SUCURSAL.IdSucursal, dbo.SUCURSAL.Nombre, dbo.SUCURSAL.Direccion, dbo.SUCURSAL.Telefono, dbo.SUCURSAL.Estado AS EstadoSucursal
FROM            dbo.CAJA INNER JOIN
                         dbo.CAJA_POR_SUCURSAL ON dbo.CAJA.IdCaja = dbo.CAJA_POR_SUCURSAL.IdCaja INNER JOIN
                         dbo.SUCURSAL ON dbo.CAJA_POR_SUCURSAL.IdSucursal = dbo.SUCURSAL.IdSucursal
Where dbo.CAJA_POR_SUCURSAL.Estado = 'A'

GO

CREATE VIEW [dbo].[View_EmpleadoPorRol]
AS
SELECT        dbo.EMPLEADO.IdEmpleado, dbo.EMPLEADO.Contraseña, dbo.EMPLEADO.Cedula, dbo.EMPLEADO.Nombre, dbo.EMPLEADO.Apellidos, dbo.EMPLEADO.Estado, dbo.ROL.IdRol, dbo.ROL.Nombre AS NombreRol, 
                         dbo.ROL.Estado AS EstadoRol
FROM            dbo.EMPLEADO INNER JOIN
                         dbo.EMPLEADO_POR_ROL ON dbo.EMPLEADO.IdEmpleado = dbo.EMPLEADO_POR_ROL.IdEmpleado INNER JOIN
                         dbo.ROL ON dbo.EMPLEADO_POR_ROL.IdRol = dbo.ROL.IdRol
Where dbo.EMPLEADO_POR_ROL.Estado = 'A'
GO

CREATE VIEW [dbo].[View_EmpleadoPorSucursal]
AS
SELECT        dbo.EMPLEADO.IdEmpleado, dbo.EMPLEADO.Contraseña, dbo.EMPLEADO.Cedula, dbo.EMPLEADO.Nombre, dbo.EMPLEADO.Apellidos, dbo.EMPLEADO.Estado, dbo.SUCURSAL.IdSucursal, 
                         dbo.SUCURSAL.Nombre AS NombreSucursal, dbo.SUCURSAL.Direccion, dbo.SUCURSAL.Telefono, dbo.SUCURSAL.Estado AS EstadoSucursal
FROM            dbo.EMPLEADO INNER JOIN
                         dbo.EMPLEADO_POR_SUCURSAL ON dbo.EMPLEADO.IdEmpleado = dbo.EMPLEADO_POR_SUCURSAL.IdEmpleado INNER JOIN
                         dbo.SUCURSAL ON dbo.EMPLEADO_POR_SUCURSAL.IdSucursal = dbo.SUCURSAL.IdSucursal
Where dbo.EMPLEADO_POR_SUCURSAL.Estado = 'A'
GO

CREATE VIEW [dbo].[View_ProductoPorVenta]
AS
SELECT        dbo.PRODUCTO.IdProducto, dbo.PRODUCTO.EAN, dbo.PRODUCTO.Nombre, dbo.PRODUCTO.Precio, dbo.PRODUCTO_POR_VENTA.Cantidad, dbo.PRODUCTO.Estado, dbo.VENTA.Timestamp, dbo.VENTA.IdVenta, 
                         dbo.CAJA.IdCaja, dbo.SUCURSAL.IdSucursal, dbo.SUCURSAL.Nombre AS NombreSucursal
FROM            dbo.VENTA INNER JOIN
                         dbo.PRODUCTO_POR_VENTA INNER JOIN
                         dbo.PRODUCTO ON dbo.PRODUCTO_POR_VENTA.IdProducto = dbo.PRODUCTO.IdProducto ON dbo.VENTA.IdVenta = dbo.PRODUCTO_POR_VENTA.IdVenta INNER JOIN
                         dbo.VENTA_POR_CAJA ON dbo.VENTA.IdVenta = dbo.VENTA_POR_CAJA.IdVenta INNER JOIN
                         dbo.SUCURSAL INNER JOIN
                         dbo.CAJA INNER JOIN
                         dbo.CAJA_POR_SUCURSAL ON dbo.CAJA.IdCaja = dbo.CAJA_POR_SUCURSAL.IdCaja ON dbo.SUCURSAL.IdSucursal = dbo.CAJA_POR_SUCURSAL.IdSucursal ON dbo.VENTA_POR_CAJA.IdCaja = dbo.CAJA.IdCaja
Where dbo.PRODUCTO_POR_VENTA.Estado = 'A'
GO


CREATE VIEW [dbo].[View_ProductoPorSucursal]
AS
SELECT        dbo.PRODUCTO.*, dbo.PRODUCTO_POR_SUCURSAL.Stock, dbo.PRODUCTO_POR_SUCURSAL.StockMinimo, dbo.SUCURSAL.IdSucursal, dbo.SUCURSAL.Nombre AS NombreSucursal, dbo.SUCURSAL.Direccion, 
                         dbo.SUCURSAL.Telefono, dbo.SUCURSAL.Estado AS EstadoSucursal
FROM            dbo.PRODUCTO INNER JOIN
                         dbo.PRODUCTO_POR_SUCURSAL ON dbo.PRODUCTO.IdProducto = dbo.PRODUCTO_POR_SUCURSAL.IdProducto INNER JOIN
                         dbo.SUCURSAL ON dbo.PRODUCTO_POR_SUCURSAL.IdSucursal = dbo.SUCURSAL.IdSucursal
Where dbo.PRODUCTO_POR_SUCURSAL.Estado = 'A'
GO

CREATE VIEW [dbo].[View_ProductoPorProveedor]
AS
SELECT        dbo.PRODUCTO.IdProducto, dbo.PRODUCTO.EAN, dbo.PRODUCTO.Nombre, dbo.PRODUCTO.Precio, dbo.PRODUCTO.Estado, dbo.PROVEEDOR.IdProveedor, dbo.PROVEEDOR.Nombre AS NombreProveedor, 
                         dbo.PROVEEDOR.Estado AS EstadoProveedor
FROM            dbo.PRODUCTO INNER JOIN
                         dbo.PRODUCTO_POR_PROVEEDOR ON dbo.PRODUCTO.IdProducto = dbo.PRODUCTO_POR_PROVEEDOR.IdProducto INNER JOIN
                         dbo.PROVEEDOR ON dbo.PRODUCTO_POR_PROVEEDOR.IdProveedor = dbo.PROVEEDOR.IdProveedor
Where dbo.PRODUCTO_POR_PROVEEDOR.Estado = 'A'
GO

CREATE VIEW [dbo].[View_VentaPorCaja]
AS
SELECT        dbo.CAJA.IdCaja, dbo.CAJA.Dinero, dbo.CAJA.UltimoCierre, dbo.CAJA.Estado, dbo.VENTA.IdVenta, dbo.VENTA.Timestamp, dbo.VENTA.Estado AS EstadoVenta
FROM            dbo.CAJA INNER JOIN
                         dbo.VENTA_POR_CAJA ON dbo.CAJA.IdCaja = dbo.VENTA_POR_CAJA.IdCaja INNER JOIN
                         dbo.VENTA ON dbo.VENTA_POR_CAJA.IdVenta = dbo.VENTA.IdVenta
Where dbo.VENTA_POR_CAJA.Estado = 'A'
GO

CREATE VIEW [dbo].[View_VentaPorCliente]
AS
SELECT        dbo.VENTA.IdVenta, dbo.VENTA.Timestamp, dbo.VENTA.Estado, dbo.CLIENTE.IdCliente, dbo.CLIENTE.Cedula, dbo.CLIENTE.Nombre, dbo.CLIENTE.Apellidos, dbo.CLIENTE.FechaNacimiento, 
                         dbo.CLIENTE.Estado AS EstadoCliente
FROM            dbo.CLIENTE INNER JOIN
                         dbo.VENTA_POR_CLIENTE ON dbo.CLIENTE.IdCliente = dbo.VENTA_POR_CLIENTE.IdCliente INNER JOIN
                         dbo.VENTA ON dbo.VENTA_POR_CLIENTE.IdVenta = dbo.VENTA.IdVenta
Where dbo.VENTA_POR_CLIENTE.Estado = 'A'
GO

<<<<<<< HEAD
CREATE VIEW [dbo].[View_VentaPorClienteYCaja]
AS
SELECT        dbo.CLIENTE.IdCliente, dbo.CLIENTE.Cedula, dbo.CLIENTE.Apellidos, dbo.CLIENTE.FechaNacimiento, dbo.CLIENTE.Estado AS EstadoCliente, dbo.CLIENTE.Nombre AS NombreCliente, 
                         dbo.VENTA.Timestamp AS FechaVenta, dbo.VENTA.Estado AS EstadoVenta, dbo.VENTA.IdVenta, dbo.VENTA_POR_CAJA.IdCaja
FROM            dbo.VENTA_POR_CAJA INNER JOIN
                         dbo.VENTA ON dbo.VENTA_POR_CAJA.IdVenta = dbo.VENTA.IdVenta INNER JOIN
                         dbo.VENTA_POR_CLIENTE ON dbo.VENTA.IdVenta = dbo.VENTA_POR_CLIENTE.IdVenta INNER JOIN
                         dbo.CLIENTE ON dbo.VENTA_POR_CLIENTE.IdCliente = dbo.CLIENTE.IdCliente
Where dbo.VENTA.Estado = 'A'
GO
=======
CREATE VIEW [dbo].[View_VentasPorSucursal]
AS
SELECT        dbo.SUCURSAL.Nombre, dbo.VENTA_POR_CAJA.IdVenta, dbo.VENTA_POR_CAJA.Estado
FROM            dbo.CAJA_POR_SUCURSAL INNER JOIN
                         dbo.SUCURSAL ON dbo.CAJA_POR_SUCURSAL.IdSucursal = dbo.SUCURSAL.IdSucursal INNER JOIN
                         dbo.VENTA_POR_CAJA ON dbo.CAJA_POR_SUCURSAL.IdCaja = dbo.VENTA_POR_CAJA.IdCaja

GO
>>>>>>> origin/master
