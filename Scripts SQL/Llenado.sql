SELECT * FROM EMPLEADO;
SELECT * FROM SUCURSAL;
SELECT * FROM ROL;
SELECT * FROM PROVEEDOR;
SELECT * FROM PRODUCTO;
SELECT * FROM EMPLEADO_POR_ROL;

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
INSERT INTO SUCURSAL (Nombre,Direccion,Telefono,Estado) VALUES ('Cartago', 'Centro', 85420136,'R');
INSERT INTO SUCURSAL (Nombre,Direccion,Telefono, Estado) VALUES ('San José', 'Escazú', 85420136, 'X');

/* Proveedor */
EXEC sp_insert_proveedor @Nombre='Abbott Laboratories';
EXEC sp_insert_proveedor @Nombre='Johnson & Johnson';
EXEC sp_insert_proveedor @Nombre='GlaxoSmithKline';
EXEC sp_insert_proveedor @Nombre='Sanofi-Aventis';
EXEC sp_insert_proveedor @Nombre='Novartis';
EXEC sp_insert_proveedor @Nombre='Pfizer';

/* Cliente */
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento,Estado) VALUES ('01100001','John','Doe','01/01/1990','A')
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('323453234', 'Alfred', 'Cen', '1889-01-02', 'Colorado', 'A');
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('323453815', 'Kregor', 'Than', '1815-01-02', 'Jericho Reach', 'A');
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('323453816', 'Khiron', 'Ruberec', '1820-01-02', 'Karybdis', 'A');
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('323453817', 'Meric', 'Voyen', '1785-01-02', 'Barbarus', 'B');
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('323453652', 'Fabius', 'Bile', '1525-01-02', 'Chemos', 'A');
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('323453818', 'Corbulo', 'Sanguinary', '1230-01-02', 'Baal', 'A');
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('323453830', 'Ulrik', 'Lupus', '1526-01-02', 'Fenris', 'A');
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('323453832', 'Sternhammer', 'Stormfang', '1702-01-02', 'Fenris', 'A');
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('323453833', 'Fabrikus', 'Farbarius', '1562-01-02', 'Terra', 'I');
INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES ('323453834', 'Garreon', 'Abnett', '1468-01-02', 'Badab Primaris', 'I');

/* Empleados - Deben existir los roles */
EXEC sp_insert_Empleado @Contraseña='admin', @Cedula=402260398, @Nombre='Josafat', @Apellidos='Vargas Gamboa', @Rol=1;
EXEC sp_insert_Empleado @Contraseña='admin', @Cedula=402270398, @Nombre='Sebastian', @Apellidos='Gonzalez', @Rol=2;
EXEC sp_insert_Empleado @Contraseña='admin', @Cedula=402280398, @Nombre='Giovanni', @Apellidos='Villalobos', @Rol=3;
EXEC sp_insert_Empleado @Contraseña='admin', @Cedula=402290398, @Nombre='Joseph', @Apellidos='Campos Porras', @Rol=4;

/*Cajas - Deben existir sucursales */
sp_insert_Caja @Dinero=50000.00, @idSucursal=1;
sp_insert_Caja @Dinero=50000.00, @idSucursal=1;
	sp_insert_Caja @Dinero=50000.00, @idSucursal=2;
	sp_insert_Caja @Dinero=50000.00, @idSucursal=2;
	sp_insert_Caja @Dinero=50000.00, @idSucursal=2;
sp_insert_Caja @Dinero=50000.00, @idSucursal=3;
sp_insert_Caja @Dinero=50000.00, @idSucursal=3;
	sp_insert_Caja @Dinero=50000.00, @idSucursal=4;

/* Productos - Deben existir proveedores*/
EXEC sp_insert_Producto @Nombre='Acetaminophen', @EAN='556095512398 ', @Precio='', @IdProveedor=1;
EXEC sp_insert_producto @Nombre='Gravol', @EAN='966713401796 ', @Precio='', @IdProveedor=1;
EXEC sp_insert_producto @Nombre='Lidocaína', @EAN='312000192190 ', @Precio='', @IdProveedor=1;
EXEC sp_insert_producto @Nombre='Ibuprofeno', @EAN='883611840295 ', @Precio='', @IdProveedor=2;
EXEC sp_insert_producto @Nombre='Paracetamol', @EAN='664959343448 ', @Precio='', @IdProveedor=2;
EXEC sp_insert_producto @Nombre='Alka-Seltzer', @EAN='360123228345 ', @Precio='', @IdProveedor=3;
EXEC sp_insert_producto @Nombre='Panadol', @EAN='470728100617 ', @Precio='', @IdProveedor=4;
EXEC sp_insert_producto @Nombre='Yodo', @EAN='845746951938 ', @Precio='', @IdProveedor=5;
EXEC sp_insert_producto @Nombre='Listerine', @EAN='354541047700 ', @Precio='', @IdProveedor=6;
EXEC sp_insert_producto @Nombre='Curitas', @EAN='843514793928  ', @Precio='', @IdProveedor=6;

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
EXEC sp_insert_venta