CREATE TRIGGER checkStock 
	ON PRODUCTO_POR_SUCURSAL AFTER UPDATE 
	AS BEGIN
		DECLARE @newStock smallINT, @StockMinimo smallINT, @IdProducto INT
		SELECT @newStock=i.Stock, @StockMinimo=i.StockMinimo, @IdProducto=i.IdProducto FROM inserted i

		IF @StockMinimo > @newStock/* Shoud return IdP and IdS to let the app decide who to show the warning */
			PRINT 'Stock ALERT on product'
			PRINT @IdProducto
	END
GO
	/*
	SELECT * FROM PRODUCTO_POR_SUCURSAL
	UPDATE PRODUCTO_POR_SUCURSAL SET Stock=5 WHERE IdProducto=2 AND IdSucursal=1
	*/

CREATE TRIGGER hundrethPurchase
	ON VENTA_POR_CLIENTE AFTER UPDATE
	AS BEGIN
		DECLARE @NoCompras smallINT, @Current char(15)

		SELECT @Current=i.IdCliente FROM inserted i

		SELECT @NoCompras=COUNT(IdVenta)
		FROM VENTA_POR_CLIENTE
		WHERE @Current=IdCliente

		IF @NoCompras=100
			PRINT 'Congratulaaaaaaaaaaaaatiooooooooooooons! This is you hundreth purchase! get 10% off!'
	END
GO






