--Crear la base de datos
CREATE DATABASE db_joyeria;
GO

--Usar la base de datos
USE db_joyeria;
GO

--Crear las tablas
CREATE TABLE Producto (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(100) NOT NULL,
	Descripcion NVARCHAR(200) NOT NULL,
	Precio DECIMAL(10,2) NOT NULL
);
GO

SELECT * FROM Producto;

--Inserción de datos
INSERT INTO Producto (Nombre, Descripcion, Precio)
VALUES ('Anillo Pandora','Anillo pandora super lujoso y hermoso',700000.00);
GO

SELECT * FROM Producto;
