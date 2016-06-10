USE PosPF;
GO

/* Roles */
EXEC sp_insert_rol @Nombre='DBAdmin';
EXEC sp_insert_rol @Nombre='Manager';
EXEC sp_insert_rol @Nombre='Ventas';
EXEC sp_insert_rol @Nombre='ServicioAlCliente';
EXEC sp_insert_rol @Nombre='Misceláneo';

/* Sucursales */
EXEC sp_insert_sucursal @Nombre='Heredia', @Direccion='Centro',@Telefono=85420136;
EXEC sp_insert_sucursal @Nombre='San José', @Direccion='Centro',@Telefono=85420137;
EXEC sp_insert_sucursal @Nombre='San José', @Direccion='Curridabat',@Telefono=85420138;
EXEC sp_insert_sucursal @Nombre='Alajuela', @Direccion='Centro',@Telefono=85420139;
INSERT INTO SUCURSAL (Nombre,Direccion,Telefono,Estado) VALUES ('Cartago', 'Centro', 85420136,'R'); /* Renovación */
INSERT INTO SUCURSAL (Nombre,Direccion,Telefono, Estado) VALUES ('San José', 'Escazú', 85420136, 'X'); /* Cerrada */

/* Proveedor */
EXEC sp_insert_proveedor @Nombre='Abbott Laboratories';
EXEC sp_insert_proveedor @Nombre='Johnson & Johnson';
EXEC sp_insert_proveedor @Nombre='GlaxoSmithKline';
EXEC sp_insert_proveedor @Nombre='Sanofi-Aventis';
EXEC sp_insert_proveedor @Nombre='Novartis';
EXEC sp_insert_proveedor @Nombre='Pfizer';

/* Cliente */
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('001100001','John','Doe','01/01/1990');
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('323453234', 'Alfred', 'Cen', '1889-01-02');
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('323453815', 'Kregor', 'Than', '1815-01-02');
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('323453816', 'Khiron', 'Ruberec', '1820-01-02');
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('323453817', 'Meric', 'Voyen', '1785-01-02');
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('323453652', 'Fabius', 'Bile', '1525-01-02');
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('323453818', 'Corbulo', 'Sanguinary', '1230-01-02');
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('323453830', 'Ulrik', 'Lupus', '1526-01-02');
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('323453832', 'Sternhammer', 'Stormfang', '1702-01-02');
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('323453833', 'Fabrikus', 'Farbarius', '1562-01-02');
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('323453834', 'Garreon', 'Abnett', '1468-01-02');



/* Empleados - Deben existir los roles */
EXEC sp_insert_Empleado @Contraseña='admin', @Cedula=402260398, @Nombre='Josafat', @Apellidos='Vargas Gamboa', @IdRol=1;
EXEC sp_insert_Empleado @Contraseña='123456', @Cedula=402270398, @Nombre='Sebastian', @Apellidos='Gonzalez', @IdRol=2;
EXEC sp_insert_Empleado @Contraseña='123456', @Cedula=402280398, @Nombre='Giovanni', @Apellidos='Villalobos', @IdRol=3;
EXEC sp_insert_Empleado @Contraseña='123456', @Cedula=402290398, @Nombre='Joseph', @Apellidos='Campos Porras', @IdRol=4;

/*Cajas - Deben existir sucursales */
EXEC sp_insert_Caja @Dinero=50000.00, @idSucursal=1;
EXEC sp_insert_Caja @Dinero=50000.00, @idSucursal=1;
	EXEC sp_insert_Caja @Dinero=50000.00, @idSucursal=2;
	EXEC sp_insert_Caja @Dinero=50000.00, @idSucursal=2;
	EXEC sp_insert_Caja @Dinero=50000.00, @idSucursal=2;
EXEC sp_insert_Caja @Dinero=50000.00, @idSucursal=3;
EXEC sp_insert_Caja @Dinero=50000.00, @idSucursal=3;
	EXEC sp_insert_Caja @Dinero=50000.00, @idSucursal=4;

/* Productos - Deben existir proveedores*/
EXEC sp_insert_Producto @Nombre='Acetaminophen', @EAN='556095512398', @Precio=50.00, @IdProveedor=1;
EXEC sp_insert_producto @Nombre='Gravol', @EAN='966713401796', @Precio=100.00, @IdProveedor=1;
EXEC sp_insert_producto @Nombre='Lidocaína', @EAN='312000192190', @Precio=200.00, @IdProveedor=1;
EXEC sp_insert_producto @Nombre='Ibuprofeno', @EAN='883611840295', @Precio=75.00, @IdProveedor=2;
EXEC sp_insert_producto @Nombre='Paracetamol', @EAN='664959343448', @Precio=50.00, @IdProveedor=2;
EXEC sp_insert_producto @Nombre='Alka-Seltzer', @EAN='360123228345', @Precio=150.00, @IdProveedor=3;
EXEC sp_insert_producto @Nombre='Panadol', @EAN='470728100617', @Precio=25.00, @IdProveedor=4;
EXEC sp_insert_producto @Nombre='Yodo', @EAN='845746951938', @Precio=220.00, @IdProveedor=5;
EXEC sp_insert_producto @Nombre='Listerine', @EAN='354541047700', @Precio=350.00, @IdProveedor=6;
EXEC sp_insert_producto @Nombre='Curitas', @EAN='843514793928', @Precio=100.00, @IdProveedor=6;

/* Productos por sucursal - Deben existir productos y sucursales */
EXEC sp_Stock @IdProducto=1, @Stock=50, @StockMinimo=10, @idSucursal=1;
EXEC sp_Stock @IdProducto=2, @Stock=50, @StockMinimo=10, @idSucursal=1;
EXEC sp_Stock @IdProducto=3, @Stock=50, @StockMinimo=10, @idSucursal=1;
EXEC sp_Stock @IdProducto=4, @Stock=50, @StockMinimo=10, @idSucursal=1;
EXEC sp_Stock @IdProducto=5, @Stock=50, @StockMinimo=10, @idSucursal=1;
	EXEC sp_Stock @IdProducto=2, @Stock=50, @StockMinimo=10, @idSucursal=2;
	EXEC sp_Stock @IdProducto=3, @Stock=50, @StockMinimo=10, @idSucursal=2;
	EXEC sp_Stock @IdProducto=4, @Stock=50, @StockMinimo=10, @idSucursal=2;
	EXEC sp_Stock @IdProducto=5, @Stock=50, @StockMinimo=10, @idSucursal=2;
	EXEC sp_Stock @IdProducto=6, @Stock=50, @StockMinimo=10, @idSucursal=2;
EXEC sp_Stock @IdProducto=6, @Stock=50, @StockMinimo=10, @idSucursal=3;
EXEC sp_Stock @IdProducto=7, @Stock=50, @StockMinimo=10, @idSucursal=3;
EXEC sp_Stock @IdProducto=8, @Stock=50, @StockMinimo=10, @idSucursal=3;
EXEC sp_Stock @IdProducto=9, @Stock=50, @StockMinimo=10, @idSucursal=3;
EXEC sp_Stock @IdProducto=10, @Stock=50, @StockMinimo=10, @idSucursal=3;
	EXEC sp_Stock @IdProducto=3, @Stock=50, @StockMinimo=10, @idSucursal=4;
	EXEC sp_Stock @IdProducto=4, @Stock=50, @StockMinimo=10, @idSucursal=4;
	EXEC sp_Stock @IdProducto=7, @Stock=50, @StockMinimo=10, @idSucursal=4;
	EXEC sp_Stock @IdProducto=9, @Stock=50, @StockMinimo=10, @idSucursal=4;
	EXEC sp_Stock @IdProducto=10, @Stock=50, @StockMinimo=10, @idSucursal=4;


/* Ventas -Deben eistir productos, sucursales, clientes, cajas, pps */
EXEC sp_insert_Venta @IdCaja=1, @IdCliente=1, @Duracion=232;
EXEC sp_insert_Venta @IdCaja=3, @IdCliente=1, @Duracion=173;
EXEC sp_insert_Venta @IdCaja=4, @IdCliente=2, @Duracion=216;
EXEC sp_insert_Venta @IdCaja=6, @IdCliente=3, @Duracion=124;
EXEC sp_insert_Venta @IdCaja=8, @IdCliente=1, @Duracion=261;



/* Productos Por Venta -Debe existir la venta, y Producto en la Sucursal, activa el Trigger reduce_stock */
EXEC sp_insert_ProductosPorVenta @IdProducto=1, @IdVenta=1, @Cantidad=2, @IdCaja=1;
EXEC sp_insert_ProductosPorVenta @IdProducto=3, @IdVenta=1, @Cantidad=1, @IdCaja=1;
EXEC sp_insert_ProductosPorVenta @IdProducto=4, @IdVenta=1, @Cantidad=2, @IdCaja=1;
	EXEC sp_insert_ProductosPorVenta @IdProducto=2, @IdVenta=2, @Cantidad=3, @IdCaja=3;
	EXEC sp_insert_ProductosPorVenta @IdProducto=6, @IdVenta=2, @Cantidad=1, @IdCaja=3;
EXEC sp_insert_ProductosPorVenta @IdProducto=3, @IdVenta=3, @Cantidad=4, @IdCaja=4;
	EXEC sp_insert_ProductosPorVenta @IdProducto=6, @IdVenta=4, @Cantidad=5, @IdCaja=6;
	EXEC sp_insert_ProductosPorVenta @IdProducto=7, @IdVenta=4, @Cantidad=2, @IdCaja=6;
	EXEC sp_insert_ProductosPorVenta @IdProducto=8, @IdVenta=4, @Cantidad=2, @IdCaja=6;
	EXEC sp_insert_ProductosPorVenta @IdProducto=10, @IdVenta=4, @Cantidad=3, @IdCaja=6;
EXEC sp_insert_ProductosPorVenta @IdProducto=9, @IdVenta=5, @Cantidad=1, @IdCaja=8;

/* Resuplir */
/*SELECT * FROM PRODUCTO_POR_SUCURSAL AS Pps WHERE IdProducto=1 AND IdSucursal=1;*/
EXEC sp_reStock @IdProduct=1, @Quantity=200, @IdSucursal=1;
/*SELECT * FROM PRODUCTO_POR_SUCURSAL AS Pps WHERE IdProducto=1 AND IdSucursal=1;*/