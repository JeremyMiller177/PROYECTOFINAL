




CREATE DATABASE ANALISISPRO

use ANALISISPRO


Create table Productos(
id_Producto int identity(1,1) not null,
Nombre varchar(100),
CantidadExistente int,
CantidadEntrante int,
Precio Decimal(10,0),
Detalle varchar(100)
)



ALTER TABLE Productos add total as (CantidadExistente + CantidadEntrante);



ALTER TABLE Productos add Codigo varchar(50)




CREATE TABLE REGISTROS
(
    [INT IDENTITY(1,1) NOT NULL,
    [Nombre] VARCHAR(50) NULL,
    [Correo] VARCHAR(100) NULL,
    [Edad] INT NULL,
    [Usuario] VARCHAR(50) NULL,
    [Clave] VARCHAR(50) NULL,

	)






CREATE PROCEDURE sp_Registrar
    @Nombre varchar(50),
    @Correo varchar(100),
    @Edad int,
    @Usuario varchar(50),
    @Clave varchar(50)

as
BEGIN
    INSERT INTO REGISTROS
    VALUES(@Nombre, @Correo, @Edad, @Usuario, @Clave)
end



CREATE PROCEDURE sp_logi
    @Usuario varchar(50),
    @Clave varchar(50)
	
as
BEGIN
    SELECT *
    FROM REGISTROS
    WHERE Usuario=@Usuario and Clave=@Clave 
end


CREATE PROCEDURE sp_InsertProduct
    @Nombre varchar(100),
    @CantidadExistente int,
    @CantidadEntrante int,
	@Precio decimal,
    @Detalle varchar(100),
    @Codigo varchar(100)

as
BEGIN
    INSERT INTO Productos 
    VALUES(@Nombre, @CantidadEntrante, @CantidadExistente, @Precio, @Detalle, @Codigo)
end

select * from Productos


Create table Empleados(
id_Empleados int identity(1,1) not null,
Nombre varchar(100),
Puesto varchar(100),

)


CREATE PROCEDURE sp_InsertEmpleado
    @Nombre varchar(100),
    @Puesto varchar(100)

as
BEGIN
    INSERT INTO Empleados
    VALUES(@Nombre,@Puesto)
end


CREATE PROCEDURE sp_bproductos
    @Nombre varchar(50),
    @CantidadExistente int,
	@CantidadEntrante int,
	@Precio decimal,
	@Detalle varchar (50),
	@Codigo varchar (50)
	
	
as
BEGIN
    SELECT *
    FROM Productos
    WHERE Nombre=@Nombre and CantidadExistente=@CantidadExistente and CantidadEntrante=@CantidadEntrante and Precio=@Precio and Detalle=@Detalle and  Codigo=@Codigo
end


