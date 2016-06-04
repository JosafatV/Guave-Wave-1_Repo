SELECT * FROM EMPLEADO;
SELECT * FROM SUCURSAL;
SELECT * FROM ROL;
SELECT * FROM EMPLEADO_POR_ROL;

EXEC sp_insert_rol @Nombre='DBAdmin';
EXEC sp_insert_rol @Nombre='Manager';
EXEC sp_insert_rol @Nombre='Ventas';
EXEC sp_insert_rol @Nombre='ServicioAlCliente';
EXEC sp_insert_rol @Nombre='Misceláneo';

EXEC sp_insert_sucursal @Nombre='Heredia', @Direccion='Centro',@Telefono=85420136;
EXEC sp_insert_sucursal @Nombre='San José', @Direccion='Centro',@Telefono=85420137;
EXEC sp_insert_sucursal @Nombre='San José', @Direccion='Curridabat',@Telefono=85420138;
EXEC sp_insert_sucursal @Nombre='Alajuela', @Direccion='Centro',@Telefono=85420139;
INSERT INTO SUCURSAL (Nombre,Direccion,Telefono,Estado) VALUES ('Cartago', 'Centro', 85420136,'R');
INSERT INTO SUCURSAL (Nombre,Direccion,Telefono, Estado) VALUES ('San José', 'Escazú', 85420136, 'X');

/* Deben existir los roles */
EXEC sp_insert_Empleado @Contraseña='admin', @Cedula=402260398, @Nombre='Josafat', @Apellidos='Vargas Gamboa', @Rol=1
EXEC sp_insert_Empleado @Contraseña='admin', @Cedula=402270398, @Nombre='Sebastian', @Apellidos='Gonzalez', @Rol=5
EXEC sp_insert_Empleado @Contraseña='admin', @Cedula=402280398, @Nombre='Giovanni', @Apellidos='Villalobos', @Rol=5
EXEC sp_insert_Empleado @Contraseña='admin', @Cedula=402290398, @Nombre='Joseph', @Apellidos='Campos Porras', @Rol=5

