CREATE PROCEDURE sp_insert_Caja
	@Dinero money
	AS
		INSERT INTO CAJA (Dinero) VALUES (@Dinero)
	GO


CREATE PROCEDURE sp_insert_Cliente
	@Cedula char(10), @Nombre char(15), @Apellidos char(30), @FechaNacimiento date
	AS
		INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES (@Cedula, @Nombre, @Apellidos, @FechaNacimiento)
	GO

CREATE PROCEDURE sp_insert_Empleado
	@Contraseña char(15), @Cedula char(10), @Nombre char(15), @Apellidos char(30), @Rol tinyint
	AS
		DECLARE @IdEmpleado int
		INSERT INTO EMPLEADO (Contraseña,Cedula,Nombre,Apellidos) /*OUTPUT inserted.IdEmpleado*/ VALUES (@Contraseña, @Cedula, @Nombre, @Apellidos)		
		/* Obtain IdEmpleado from the Empleado just created */
		SELECT @IdEmpleado = @@IDENTITY
		/* INSERT INTO Relationship table */
		INSERT INTO EMPLEADO_POR_ROL (IdRol, IdEmpleado) VALUES (@Rol, @IdEmpleado)
	GO

CREATE PROCEDURE sp_insert_Producto
	@Nombre char(15), @EAN char(13), @Precio money, @Stock smallINT, @StockMinimo smallINT, @idSucursal INT
	AS
		DECLARE @IdProducto INT
		INSERT INTO PRODUCTO (Nombre, EAN, Precio, Stock, StockMinimo) VALUES (@Nombre, @EAN, @Precio, @Stock, @StockMinimo)
		/* Obtain IdEmpleado from the Empleado just created */
		SELECT @IdProducto = @@IDENTITY
		/* INSERT INTO Relationship table */
		INSERT INTO PRODUCTO_POR_SUCURSAL (IdProducto, IdSucursal) VALUES (@IdProducto, @idSucursal)
	GO

CREATE PROCEDURE sp_insert_Proveedor
	@Nombre char(15)
	AS
		INSERT INTO PROVEEDOR (Nombre) VALUES (@Nombre)
	GO

CREATE PROCEDURE sp_insert_Rol 
	@Nombre char(15)
	AS
		INSERT INTO ROL (Nombre) VALUES (@Nombre)
	GO

CREATE PROCEDURE sp_insert_Sucursal
	@Nombre char(15), @Direccion char(30), @Telefono INT
	AS
		INSERT INTO SUCURSAL (Nombre,Direccion,Telefono) VALUES (@Nombre,@Direccion,@Telefono)
	GO

CREATE PROCEDURE sp_insert_Venta
	@IdProduct int, @Quantity smallINT, @IdCaja INT, @IdCliente INT
	AS
		DECLARE @Stock INT, @IdVenta INT
		/*SELECT @Stock = SELECT P. FROM PRODUCTO AS P WHERE P.IdProducto=@IdProduct*/
		INSERT INTO VENTA (Timestamp) VALUES (GETDATE())
		
		SELECT @IdVenta = @@IDENTITY
		
		INSERT INTO VENTA_POR_CAJA (IdVenta, IdCaja) VALUES (@IdVenta,@IdCaja)
		INSERT INTO VENTA_POR_CLIENTE (IdVenta, IdCliente) VALUES (@IdVenta,@IdCliente)
		INSERT INTO VENTA_POR_PRODUCTO (IdVenta, IdPRoducto) VALUES (@IdVenta,@IdProduct)

		UPDATE PRODUCTO SET Stock=Stock-@Stock WHERE IdProducto=@IdProduct
	GO