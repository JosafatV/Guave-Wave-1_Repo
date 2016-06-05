/* Inserts a new Caja tuple */
CREATE PROCEDURE sp_insert_Caja
	@Dinero money, @idSucursal INT
	AS
		DECLARE @IdCaja INT
		INSERT INTO CAJA (Dinero) VALUES (@Dinero)
		SELECT @IdCaja = @@IDENTITY

		INSERT INTO CAJA_POR_SUCURSAL (IdCaja,IdSucursal) VALUES (@IdCaja,@IdSucursal)
	GO
	
/* Inserts a new Cliente tuple */
CREATE PROCEDURE sp_insert_Cliente
	@Cedula char(10), @Nombre char(15), @Apellidos char(30), @FechaNacimiento date
	AS
		INSERT INTO CLIENTE (Cedula,Nombre,Apellidos,FechaNacimiento) VALUES (@Cedula, @Nombre, @Apellidos, @FechaNacimiento)
	GO

/* Inserts a new Proveedor tuple */
CREATE PROCEDURE sp_insert_Proveedor
	@Nombre char(15)
	AS
		INSERT INTO PROVEEDOR (Nombre) VALUES (@Nombre)
	GO

/* Inserts a new Rol tuple */
CREATE PROCEDURE sp_insert_Rol 
	@Nombre char(15)
	AS
		INSERT INTO ROL (Nombre) VALUES (@Nombre)
	GO

/* Inserts a new Sucursal tuple */
CREATE PROCEDURE sp_insert_Sucursal
	@Nombre char(15), @Direccion char(30), @Telefono INT
	AS
		INSERT INTO SUCURSAL (Nombre,Direccion,Telefono) VALUES (@Nombre,@Direccion,@Telefono)
	GO

/* Inserts a new Producto tuple and it's relationship with Proveedor */
CREATE PROCEDURE sp_insert_Producto
	@Nombre char(15), @EAN char(13), @Precio money, @idProveedor INT
	AS
		DECLARE @IdProducto INT
		INSERT INTO PRODUCTO (Nombre, EAN, Precio) VALUES (@Nombre, @EAN, @Precio)
		SELECT @IdProducto = @@IDENTITY
		INSERT INTO PRODUCTO_POR_PROVEEDOR (IdProducto, IdProveedor) VALUES (@IdProducto,@IdProveedor)
	GO

/* Inserts a new Venta tuple, and its relationships */
CREATE PROCEDURE sp_insert_Venta
	@IdProduct int, @Quantity smallINT, @IdCaja INT, @IdCliente INT, @IdSucursal INT
	AS
		DECLARE @IdVenta INT

		INSERT INTO VENTA (Timestamp) VALUES (GETDATE())
		SELECT @IdVenta = @@IDENTITY
		
		INSERT INTO VENTA_POR_CAJA (IdVenta, IdCaja) VALUES (@IdVenta,@IdCaja)
		INSERT INTO VENTA_POR_CLIENTE (IdVenta, IdCliente) VALUES (@IdVenta,@IdCliente)
		INSERT INTO PRODUCTO_POR_VENTA(IdVenta, IdPRoducto, Cantidad) VALUES (@IdVenta,@IdProduct,@Quantity)
	GO

/* Inserts the Productos bought in a Venta and how many and updates the quantity in stock in the Sucursal*/
CREATE PROCEDURE sp_insert_ProductosPorVenta
	@IdProducto INT, @IdVenta INT, @Cantidad smallINT, @IdSucursal INT
	AS
		INSERT INTO PRODUCTO_POR_VENTA (IdProducto,IdVenta,Cantidad) VALUES (@IdProducto,@IdVenta,@Cantidad)
		UPDATE PRODUCTO_POR_SUCURSAL SET Stock=Stock-@Cantidad WHERE IdProducto=@IdProducto
	GO

/* Inserts a Producto into a Sucursal's stock and how many */
CREATE PROCEDURE sp_Stock
	@IdProduct INT, @Stock smallINT, @StockMinimo smallINT, @IdSucursal INT
	AS
		INSERT INTO PRODUCTO_POR_SUCURSAL (IdProducto,Stock,StockMinimo,IdSucursal) VALUES (@IdProduct,@Stock,@StockMinimo,@IdSucursal)
	GO

/* Updates the value of a Producto in a Sucursal after restocking */
CREATE PROCEDURE sp_reStock
	@IdProduct INT, @Quantity smallINT, @IdSucursal int
	AS
		UPDATE PRODUCTO_POR_SUCURSAL SET Stock=Stock+@Quantity WHERE IdProducto=@IdProduct AND IdSucursal=@IdSucursal
	GO

