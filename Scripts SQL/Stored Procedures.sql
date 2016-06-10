USE PosPF;
GO

/* Inserts a new Caja tuple */
CREATE PROCEDURE sp_insert_Caja
	@Dinero money, @IdSucursal INT
	AS
		DECLARE @IdCaja INT
		INSERT INTO CAJA (Dinero, UltimoCierre) VALUES (@Dinero, GETDATE())
		SELECT @IdCaja = @@IDENTITY

		INSERT INTO CAJA_POR_SUCURSAL (IdCaja,IdSucursal) VALUES (@IdCaja,@IdSucursal)
		RETURN @IdCaja
	GO
	
/* Inserts a new Cliente tuple */
CREATE PROCEDURE sp_insert_Cliente
	@Cedula char(10), @Nombre char(15), @Apellidos char(30), @FechaNacimiento date
	AS
		DECLARE @IdCliente INT
		INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES (@Cedula, @Nombre, @Apellidos, @FechaNacimiento)
		SELECT @IdCliente = @@IDENTITY
		RETURN @IdCliente
	GO

/* Inserts a new Proveedor tuple */
CREATE PROCEDURE sp_insert_Proveedor
	@Nombre char(15)
	AS
		DECLARE @IdProveedor tinyINT
		INSERT INTO PROVEEDOR (Nombre) VALUES (@Nombre)
		SELECT @IdProveedor = @@IDENTITY
		RETURN @IdProveedor
	GO

/* Inserts a new Rol tuple */
CREATE PROCEDURE sp_insert_Rol 
	@Nombre char(15)
	AS
		DECLARE @IdRol tinyINT
		INSERT INTO ROL (Nombre) VALUES (@Nombre)
		SELECT @IdRol = @@IDENTITY
		RETURN @IdRol
	GO

/* Inserts a new Empleado and it's Rol */
--
CREATE PROCEDURE sp_insert_Empleado
	@Contraseña CHAR(15), @Cedula CHAR(19), @Nombre CHAR(15), @Apellidos CHAR(30), @IdRol tinyINT
	AS
		DECLARE @IdEmpleado INT
		INSERT INTO EMPLEADO (Contraseña,Cedula,Nombre,Apellidos) VALUES (@Contraseña,@Cedula,@Nombre,@Apellidos)
		SELECT @IdEmpleado=@@IDENTITY

		INSERT INTO EMPLEADO_POR_ROL (IdRol, IdEmpleado) VALUES (@IdRol, @IdEmpleado)
		RETURN @IdEmpleado
	GO

/* Inserts a new Sucursal tuple */
CREATE PROCEDURE sp_insert_Sucursal
	@Nombre char(15), @Direccion char(30), @Telefono INT
	AS
		DECLARE @IdSucursal INT
		INSERT INTO SUCURSAL (Nombre,Direccion,Telefono) VALUES (@Nombre,@Direccion,@Telefono)
		SELECT @IdSucursal = @@IDENTITY
	GO

/* Inserts a new Producto tuple and it's relationship with Proveedor */
CREATE PROCEDURE sp_insert_Producto
	@Nombre char(15), @EAN char(13), @Precio money, @idProveedor INT
	AS
		DECLARE @IdProducto INT
		INSERT INTO PRODUCTO (Nombre, EAN, Precio) VALUES (@Nombre, @EAN, @Precio)
		SELECT @IdProducto = @@IDENTITY
		INSERT INTO PRODUCTO_POR_PROVEEDOR (IdProducto, IdProveedor) VALUES (@IdProducto,@IdProveedor)
		RETURN @IdProducto
	GO

/* Inserts a new Venta tuple, and its relationships */
--
CREATE PROCEDURE sp_insert_Venta
	@IdCaja INT, @IdCliente INT, @Duracion smallINT
	AS
		DECLARE @IdVenta INT

		INSERT INTO VENTA (Timestamp, Duracion) VALUES (GETDATE(), @Duracion)
		SELECT @IdVenta = @@IDENTITY
		
		INSERT INTO VENTA_POR_CAJA (IdVenta, IdCaja) VALUES (@IdVenta,@IdCaja)
		INSERT INTO VENTA_POR_CLIENTE (IdVenta, IdCliente) VALUES (@IdVenta,@IdCliente)

		RETURN @IdVenta
	GO

/* Inserts the Productos bought in a Venta and how many and updates the quantity in stock in the Sucursal*/
--
CREATE PROCEDURE sp_insert_ProductosPorVenta
	@IdProducto INT, @IdVenta INT, @Cantidad smallINT, @IdCaja INT
	AS
		INSERT INTO PRODUCTO_POR_VENTA (IdProducto,IdVenta,Cantidad) VALUES (@IdProducto,@IdVenta,@Cantidad)

		DECLARE @IdSucursal INT,
				@Precio money

		SELECT @IdSucursal=Cps.IdSucursal FROM  CAJA_POR_SUCURSAL AS Cps WHERE Cps.IdCaja=@IdCaja
		SELECT @Precio=P.Precio FROM PRODUCTO AS P WHERE P.IdProducto=@IdProducto

		/* Reduce Stock en la sucursal donde está la caja */
		UPDATE PRODUCTO_POR_SUCURSAL SET Stock=Stock-@Cantidad WHERE IdProducto=@IdProducto

		/* Aumenta la cantidad de Dinero en la caja según el precio del producto y la cantidad */
		UPDATE CAJA SET Dinero=Dinero+(@Precio*@Cantidad) WHERE IdCaja=@IdCaja
	GO


/* Inserts a Producto into a Sucursal's stock and how many */
CREATE PROCEDURE sp_Stock
	@IdProducto INT, @Stock smallINT, @StockMinimo smallINT, @IdSucursal INT
	AS
		INSERT INTO PRODUCTO_POR_SUCURSAL (IdProducto,Stock,StockMinimo,IdSucursal) VALUES (@IdProducto,@Stock,@StockMinimo,@IdSucursal)
	GO

/* Updates the value of a Producto in a Sucursal after restocking */
CREATE PROCEDURE sp_reStock
	@IdProduct INT, @Quantity smallINT, @IdSucursal int
	AS
		UPDATE PRODUCTO_POR_SUCURSAL SET Stock=Stock+@Quantity WHERE IdProducto=@IdProduct AND IdSucursal=@IdSucursal
	GO

CREATE PROCEDURE sp_checkStock
	@IdSucursal INT
	AS
		SELECT Pps.IdProducto, Pps.Nombre, Pps.Stock, Pps.NombreSucursal, Pps.Direccion
		FROM View_ProductoPorSucursal AS Pps 
		WHERE Pps.Stock<Pps.StockMinimo AND Pps.IdSucursal=@IdSucursal AND Pps.Estado='A' AND Pps.EstadoSucursal='A'
	GO

CREATE PROCEDURE sp_UpdateStockMinimo
	@IdSucursal INT, @IdProducto INT, @newStockMinimo smallINT
	AS
		UPDATE PRODUCTO_POR_SUCURSAL 
		SET StockMinimo=@newStockMinimo
		WHERE IdSucursal=@IdSucursal AND IdProducto=@IdProducto
	GO

CREATE PROCEDURE sp_CierreDeCaja
	@IdCaja INT, @DineroCierre money
	AS
		SELECT Cps.IdCaja, Cps.Dinero-@DineroCierre
		FROM View_CajaPorSucursal AS Cps
		WHERE Cps.IdCaja=@IdCaja

		UPDATE CAJA
		SET Dinero=@DineroCierre, UltimoCierre=GETDATE()
		WHERE IdCaja=@IdCaja
	GO
		
CREATE PROCEDURE sp_AperturaDeCaja
	@IdCaja INT, @DineroApertura INT
	AS
		UPDATE CAJA
		SET Dinero=50000
		WHERE @IdCaja=IdCaja
	GO