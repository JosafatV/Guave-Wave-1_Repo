CREATE TRIGGER checkStock 
	ON PRODUCTO_POR_SUCURSAL AFTER UPDATE 
	AS BEGIN
		DECLARE @newStock smallINT, @StockMinimo smallINT, @IdProducto INT
		SELECT @newStock=i.Stock, @StockMinimo=i.StockMinimo, @IdProducto=i.IdProducto FROM inserted i

		IF @StockMinimo > @newStock/* Shoud return IdP and IdS to let the app decide who to show the warning */
			PRINT 'Stock ALERT on product'
			PRINT @IdProducto
	END

	/*
	SELECT * FROM PRODUCTO_POR_SUCURSAL
	UPDATE PRODUCTO_POR_SUCURSAL SET Stock=5 WHERE IdProducto=2 AND IdSucursal=1
	*/