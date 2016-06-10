CREATE DATABASE PosPF;
GO

USE PosPF;

CREATE TABLE ROL (
	IdRol TinyINT IDENTITY(1,1),
	Nombre CHAR(15) NOT NULL,
	Estado CHAR(1) DEFAULT 'A',

	PRIMARY KEY (IdRol)
	)

CREATE TABLE EMPLEADO (
	IdEmpleado INT IDENTITY(1,1),
	Contraseņa CHAR(15) NOT NULL,
	Cedula CHAR(10) NOT NULL,
	Nombre CHAR (15),
	Apellidos CHAR(30),
	Estado CHAR(1) DEFAULT 'A',

	PRIMARY KEY (IdEmpleado),
	UNIQUE (Cedula)
	)

CREATE TABLE CLIENTE (
	IdCliente INT IDENTITY(1,1),
	Cedula CHAR(10) NOT NULL,
	Nombre CHAR (15),
	Apellidos CHAR(30),
	FechaNacimiento DATE,
	Estado CHAR(1) DEFAULT 'A',

	PRIMARY KEY (IdCliente),
	UNIQUE (Cedula)
	)

CREATE TABLE SUCURSAL (
	IdSucursal INT IDENTITY(1,1),
	Nombre CHAR (15),
	Direccion CHAR(30),
	Telefono INT,
	Estado CHAR(1) DEFAULT 'A',

	PRIMARY KEY (IdSucursal)
	)

CREATE TABLE CAJA (
	IdCaja INT IDENTITY(1,1),
	Dinero MONEY,
	UltimoCierre DATETIME,
	Estado CHAR(1) DEFAULT 'A',

	PRIMARY KEY (IdCaja)
	)

CREATE TABLE PRODUCTO(
	IdProducto INT IDENTITY(1,1),
	EAN CHAR(13) NOT NULL,
	Nombre CHAR(15),
	Precio MONEY NOT NULL,
	Estado CHAR(1) DEFAULT 'A',

	PRIMARY KEY (IdProducto),
	UNIQUE (EAN)
	)

CREATE TABLE PROVEEDOR (
	IdProveedor INT IDENTITY(1,1),
	Nombre CHAR(15),
	Estado CHAR(1) DEFAULT 'A',

	PRIMARY KEY (IdProveedor)
)

CREATE TABLE VENTA(
	IdVenta INT IDENTITY(1,1),
	Timestamp DATETIME,
	Duracion smallINT,
	Estado CHAR(1) DEFAULT 'A',

	PRIMARY KEY (IdVenta)
)


CREATE TABLE EMPLEADO_POR_ROL (
	IdRol tinyINT,
	IdEmpleado INT,
	Estado CHAR(1) DEFAULT 'A',
	PRIMARY KEY (IdRol, IdEmpleado),
	FOREIGN KEY (IdRol) REFERENCES ROL(IdRol) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (IdEmpleado) REFERENCES EMPLEADO(IdEmpleado) ON DELETE CASCADE ON UPDATE CASCADE
	)
	
CREATE TABLE EMPLEADO_POR_SUCURSAL (
	IdSucursal INT,
	IdEmpleado INT,
	Estado CHAR(1) DEFAULT 'A',
	PRIMARY KEY (IdSucursal, IdEmpleado),
	FOREIGN KEY (IdEmpleado) REFERENCES EMPLEADO(IdEmpleado) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (IdSucursal) REFERENCES SUCURSAL(IdSucursal) ON DELETE CASCADE ON UPDATE CASCADE
	)

CREATE TABLE PRODUCTO_POR_SUCURSAL (
	IdSucursal INT,
	IdProducto INT,
	Stock SMALLINT,
	StockMinimo SMALLINT,
	Estado CHAR(1) DEFAULT 'A',
	PRIMARY KEY (IdSucursal, IdProducto),
	FOREIGN KEY (IdProducto) REFERENCES PRODUCTO(IdProducto) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (IdSucursal) REFERENCES SUCURSAL(IdSucursal) ON DELETE CASCADE ON UPDATE CASCADE
	)

CREATE TABLE PRODUCTO_POR_VENTA (
	IdProducto INT,
	IdVenta INT,
	Cantidad SMALLINT,
	Estado CHAR(1) DEFAULT 'A',
	PRIMARY KEY (IdVenta, IdProducto),
	FOREIGN KEY (IdProducto) REFERENCES PRODUCTO(IdProducto) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (IdVenta) REFERENCES VENTA(IdVenta) ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE VENTA_POR_CLIENTE (
	IdVenta INT,
	IdCliente INT,
	Estado CHAR(1) DEFAULT 'A',
	PRIMARY KEY (IdVenta, IdCliente),
	FOREIGN KEY (IdVenta) REFERENCES VENTA(IdVenta) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (IdCliente) REFERENCES CLIENTE(IdCliente) ON DELETE CASCADE ON UPDATE CASCADE
	)

CREATE TABLE VENTA_POR_CAJA (
	IdVenta INT,
	IdCaja INT,
	Estado CHAR(1) DEFAULT 'A',
	PRIMARY KEY (IdVenta, IdCaja),
	FOREIGN KEY (IdVenta) REFERENCES VENTA(IdVenta) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (IdCaja) REFERENCES CAJA(IdCaja) ON DELETE CASCADE ON UPDATE CASCADE
	)
	
CREATE TABLE PRODUCTO_POR_PROVEEDOR (
	IdProducto INT,
	IdProveedor INT,
	Estado CHAR(1) DEFAULT 'A',
	PRIMARY KEY (IdProducto, IdProveedor),
	FOREIGN KEY (IdProducto) REFERENCES PRODUCTO(IdProducto) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (IdProveedor) REFERENCES PROVEEDOR(IdProveedor) ON DELETE CASCADE ON UPDATE CASCADE
	)

CREATE TABLE CAJA_POR_SUCURSAL (
	IdCaja INT,
	IdSucursal INT,
	Estado CHAR(1) DEFAULT 'A',
	PRIMARY KEY (IdSucursal, IdCaja),
	FOREIGN KEY (IdSucursal) REFERENCES SUCURSAL(IdSucursal) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (IdCaja) REFERENCES CAJA(IdCaja) ON DELETE CASCADE ON UPDATE CASCADE
	)