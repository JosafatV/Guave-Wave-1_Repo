USE PosPF
SELECT * FROM CAJA
SELECT * FROM CAJA_POR_SUCURSAL
SELECT * FROM PROVEEDOR
SELECT * FROM EMPLEADO;
SELECT * FROM SUCURSAL;
SELECT * FROM ROL;
SELECT * FROM PROVEEDOR;
SELECT * FROM EMPLEADO_POR_ROL;
SELECT * FROM CLIENTE;
SELECT * FROM PRODUCTO;
SELECT * FROM PRODUCTO_POR_PROVEEDOR;
SELECT * FROM PRODUCTO_POR_SUCURSAL;
SELECT * FROM VENTA;
SELECT * FROM VENTA_POR_CAJA;
SELECT * FROM VENTA_POR_CLIENTE;

SELECT * FROM View_Ventas
SELECT * FROM View_ProductoPorVenta

SELECT * FROM PRODUCTO_POR_SUCURSAL WHERE IdSucursal=4
EXEC sp_Stock @IdProducto=1,@Stock=50,@StockMinimo=10,@IdSucursal=4
EXEC sp_reStock @IdProduct=3,@Quantity=-40,@IdSucursal=4
EXEC sp_checkStock @IdSucursal=4
EXEC sp_UpdateStockMinimo @IdSucursal=4,@IdProducto=3,@newStockMinimo=15

SELECT * FROM CAJA
EXEC sp_CierreDeCaja @IdCaja=1,@DineroCierre=50450
EXEC sp_CierreDeCaja @IdCaja=2,@DineroCierre=50450
EXEC sp_AperturaDeCaja @IdCaja=1,@DineroApertura=50000

SELECT * FROM View_VentaPorCaja
SELECT * FROM VENTA
EXEC report_TiempoEnCaja @IdCaja=1

/*
/* EJEMPLO DE VENTA */
	/* Inserta la venta */
EXEC sp_insert_Venta @IdCaja=1, @IdCliente=1;
SELECT * FROM VENTA /* Obtener el IdVenta */
	/* Inserta los productos vendidos */
EXEC sp_insert_ProductosPorVenta @IdProducto=2, @IdVenta=7, @Cantidad=2, @IdCaja=1;
EXEC sp_insert_ProductosPorVenta @IdProducto=3, @IdVenta=7, @Cantidad=4, @IdCaja=1;
*/