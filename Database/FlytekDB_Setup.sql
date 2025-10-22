-- Preparé el script para poder ejecutarse varias veces sin errores.
-- Se usan IF NOT EXISTS como haríamos en MySQL para evitar crear de nuevo la base, la tabla o duplicar datos,
-- así no falla si ya existen y se mantiene todo limpio y sin problema.

-- Crear la base de datos solo si no existe
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'FlytekDB')
BEGIN
    CREATE DATABASE FlytekDB;
    PRINT 'Base de datos FlytekDB creada.';
END
ELSE
    PRINT 'La base de datos FlytekDB ya existe.';
GO

USE FlytekDB;
GO

-- Creo la tabla Productos solo si no existe
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Productos' AND xtype='U')
BEGIN
    CREATE TABLE Productos (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(100) NOT NULL,
        Categoria NVARCHAR(50),
        Precio DECIMAL(10,2) NOT NULL,
        Stock INT,
        Imagen NVARCHAR(255),
        Descripcion NVARCHAR(255)
    );
    PRINT 'Tabla Productos creada.';
END
ELSE
    PRINT 'La tabla Productos ya existe.';
GO

-- Inserto solo si no hay registros
IF NOT EXISTS (SELECT 1 FROM Productos)
BEGIN
    INSERT INTO Productos (Nombre, Categoria, Precio, Stock, Imagen, Descripcion)
    VALUES
    ('Reloj inteligente', 'Wearables', 129.00, 10, 'pack://application:,,,/Resources/RELOJ.png', 'Smartwatch con control de ritmo cardíaco.'),
    ('Cascos inalámbricos', 'Audio', 89.00, 8, 'pack://application:,,,/Resources/CASCOS.png', 'Auriculares con cancelación de ruido.'),
    ('Gafas VR', 'Realidad Virtual', 159.00, 6, 'pack://application:,,,/Resources/GAFAS.png', 'Gafas de realidad virtual con sensor de movimiento.'),
    ('Altavoz portátil', 'Audio', 49.00, 12, 'pack://application:,,,/Resources/ALTAVOZ.png', 'Altavoz inalámbrico con Bluetooth.');
    PRINT 'Productos insertados correctamente.';
END
ELSE
    PRINT 'Los productos ya existen en la tabla.';
GO

-- Creo la tabla Pedidos
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Pedidos' AND xtype='U')
BEGIN
    CREATE TABLE Pedidos (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Producto NVARCHAR(100),
        Fecha DATETIME DEFAULT GETDATE()
    );
    PRINT 'Tabla Pedidos creada.';
END
ELSE
    PRINT 'La tabla Pedidos ya existe.';
GO

-- Creo la tabla Usuarios
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Usuarios' AND xtype='U')
BEGIN
    CREATE TABLE Usuarios (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(100),
        Apellidos NVARCHAR(100),
        Email NVARCHAR(100),
        Contrasena NVARCHAR(50),
        Rol NVARCHAR(50)
    );
    PRINT 'Tabla Usuarios creada.';
END
ELSE
    PRINT 'La tabla Usuarios ya existe.';
GO



-- Verificar
SELECT * FROM Productos;
SELECT * FROM Pedidos;
SELECT * FROM Usuarios;
