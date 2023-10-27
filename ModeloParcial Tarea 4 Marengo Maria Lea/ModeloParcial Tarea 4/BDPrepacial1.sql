USE [master]
GO
/****** Object:  Database [PREPARCIAL1]    Script Date: 24/10/2023 10:56:04 ******/
CREATE DATABASE [PREPARCIAL1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PREPARCIAL1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MYSQLSERVER19\MSSQL\DATA\PREPARCIAL1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PREPARCIAL1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MYSQLSERVER19\MSSQL\DATA\PREPARCIAL1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PREPARCIAL1] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PREPARCIAL1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PREPARCIAL1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PREPARCIAL1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PREPARCIAL1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PREPARCIAL1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PREPARCIAL1] SET ARITHABORT OFF 
GO
ALTER DATABASE [PREPARCIAL1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PREPARCIAL1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PREPARCIAL1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PREPARCIAL1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PREPARCIAL1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PREPARCIAL1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PREPARCIAL1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PREPARCIAL1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PREPARCIAL1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PREPARCIAL1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PREPARCIAL1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PREPARCIAL1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PREPARCIAL1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PREPARCIAL1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PREPARCIAL1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PREPARCIAL1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PREPARCIAL1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PREPARCIAL1] SET RECOVERY FULL 
GO
ALTER DATABASE [PREPARCIAL1] SET  MULTI_USER 
GO
ALTER DATABASE [PREPARCIAL1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PREPARCIAL1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PREPARCIAL1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PREPARCIAL1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PREPARCIAL1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PREPARCIAL1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PREPARCIAL1', N'ON'
GO
ALTER DATABASE [PREPARCIAL1] SET QUERY_STORE = ON
GO
ALTER DATABASE [PREPARCIAL1] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PREPARCIAL1]
GO
/****** Object:  Table [dbo].[DetallesOrden]    Script Date: 24/10/2023 10:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesOrden](
	[id_detalle] [int] NULL,
	[id_orden] [int] NULL,
	[material] [int] NULL,
	[cantidad] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materiales]    Script Date: 24/10/2023 10:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materiales](
	[id_material] [int] IDENTITY(1,1) NOT NULL,
	[nom_material] [varchar](40) NULL,
	[stock_material] [int] NULL,
 CONSTRAINT [pk_materiales] PRIMARY KEY CLUSTERED 
(
	[id_material] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenesRetiro]    Script Date: 24/10/2023 10:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenesRetiro](
	[id_orden] [int] IDENTITY(1,1) NOT NULL,
	[fecha_orden] [datetime] NULL,
	[responsable] [varchar](50) NULL,
	[fecha_baja] [datetime] NULL,
 CONSTRAINT [pk_ordenes] PRIMARY KEY CLUSTERED 
(
	[id_orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DetallesOrden] ([id_detalle], [id_orden], [material], [cantidad]) VALUES (1, 1, 3, 1)
GO
INSERT [dbo].[DetallesOrden] ([id_detalle], [id_orden], [material], [cantidad]) VALUES (1, 2, 1, 1)
GO
INSERT [dbo].[DetallesOrden] ([id_detalle], [id_orden], [material], [cantidad]) VALUES (1, 3, 3, 2)
GO
INSERT [dbo].[DetallesOrden] ([id_detalle], [id_orden], [material], [cantidad]) VALUES (2, 3, 2, 4)
GO
INSERT [dbo].[DetallesOrden] ([id_detalle], [id_orden], [material], [cantidad]) VALUES (1, 4, 2, 2)
GO
INSERT [dbo].[DetallesOrden] ([id_detalle], [id_orden], [material], [cantidad]) VALUES (2, 4, 4, 5)
GO
INSERT [dbo].[DetallesOrden] ([id_detalle], [id_orden], [material], [cantidad]) VALUES (1, 5, 5, 3)
GO
SET IDENTITY_INSERT [dbo].[Materiales] ON 
GO
INSERT [dbo].[Materiales] ([id_material], [nom_material], [stock_material]) VALUES (1, N'Plastico', 999)
GO
INSERT [dbo].[Materiales] ([id_material], [nom_material], [stock_material]) VALUES (2, N'Cuero', 1000)
GO
INSERT [dbo].[Materiales] ([id_material], [nom_material], [stock_material]) VALUES (3, N'Algodon', 999)
GO
INSERT [dbo].[Materiales] ([id_material], [nom_material], [stock_material]) VALUES (4, N'Hierro', 1000)
GO
INSERT [dbo].[Materiales] ([id_material], [nom_material], [stock_material]) VALUES (5, N'Carton', 1000)
GO
SET IDENTITY_INSERT [dbo].[Materiales] OFF
GO
SET IDENTITY_INSERT [dbo].[OrdenesRetiro] ON 
GO
INSERT [dbo].[OrdenesRetiro] ([id_orden], [fecha_orden], [responsable], [fecha_baja]) VALUES (1, CAST(N'2023-10-05T00:00:00.000' AS DateTime), N'tomas', CAST(N'2023-10-16T13:40:28.530' AS DateTime))
GO
INSERT [dbo].[OrdenesRetiro] ([id_orden], [fecha_orden], [responsable], [fecha_baja]) VALUES (2, CAST(N'2023-09-03T00:00:00.000' AS DateTime), N'hhhh', CAST(N'2023-10-16T15:39:24.920' AS DateTime))
GO
INSERT [dbo].[OrdenesRetiro] ([id_orden], [fecha_orden], [responsable], [fecha_baja]) VALUES (3, CAST(N'2023-10-10T00:00:00.000' AS DateTime), N'Toto', CAST(N'2023-10-16T20:23:31.653' AS DateTime))
GO
INSERT [dbo].[OrdenesRetiro] ([id_orden], [fecha_orden], [responsable], [fecha_baja]) VALUES (4, CAST(N'2023-09-03T00:00:00.000' AS DateTime), N'to', NULL)
GO
INSERT [dbo].[OrdenesRetiro] ([id_orden], [fecha_orden], [responsable], [fecha_baja]) VALUES (5, CAST(N'2023-10-08T00:00:00.000' AS DateTime), N'tomi', NULL)
GO
SET IDENTITY_INSERT [dbo].[OrdenesRetiro] OFF
GO
ALTER TABLE [dbo].[DetallesOrden]  WITH CHECK ADD  CONSTRAINT [fk_materiales] FOREIGN KEY([material])
REFERENCES [dbo].[Materiales] ([id_material])
GO
ALTER TABLE [dbo].[DetallesOrden] CHECK CONSTRAINT [fk_materiales]
GO
ALTER TABLE [dbo].[DetallesOrden]  WITH CHECK ADD  CONSTRAINT [fk_orden_detalle] FOREIGN KEY([id_orden])
REFERENCES [dbo].[OrdenesRetiro] ([id_orden])
GO
ALTER TABLE [dbo].[DetallesOrden] CHECK CONSTRAINT [fk_orden_detalle]
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_ORDEN]    Script Date: 24/10/2023 10:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ACTUALIZAR_ORDEN]
@id_orden int,
@fecha_orden datetime,
@responsable varchar(50)
AS
BEGIN
	UPDATE [dbo].[OrdenesRetiro]
	SET responsable=@responsable,
	fecha_orden=@fecha_orden
	WHERE id_orden=@id_orden

	delete[dbo].[DetallesOrden]
	where id_orden=@id_orden
END
GO
/****** Object:  StoredProcedure [dbo].[SP_BORRAR_CARGAS]    Script Date: 24/10/2023 10:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_BORRAR_CARGAS]
@id_orden int = null
AS
BEGIN
DELETE DetallesOrden
WHERE id_orden=@id_orden
END
GO
/****** Object:  StoredProcedure [dbo].[SP_BORRAR_ORDEN]    Script Date: 24/10/2023 10:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_BORRAR_ORDEN]
@id_orden int = null
AS
BEGIN
UPDATE OrdenesRetiro
SET fecha_baja = getdate()
WHERE id_orden=@id_orden
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_CANT_STOCK]    Script Date: 24/10/2023 10:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_CONSULTAR_CANT_STOCK]
AS
BEGIN
SELECT nom_material,stock_material
FROM Materiales
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_DETALLES_ORDEN]    Script Date: 24/10/2023 10:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_DETALLES_ORDEN]
@id_orden int
AS 
BEGIN
SELECT id_detalle, id_material, nom_material, cantidad, o.fecha_orden,responsable,stock_material
	FROM DetallesOrden d JOIN Materiales m
		ON d.material=m.id_material
		join [dbo].[OrdenesRetiro] o 
		on o.id_orden=d.id_orden
WHERE d.id_orden=@id_orden
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_MATERIALES]    Script Date: 24/10/2023 10:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_CONSULTAR_MATERIALES]
AS
BEGIN
SELECT * FROM Materiales
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_ORDEN]    Script Date: 24/10/2023 10:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_ORDEN]
	@fecha_desde Datetime,
	@fecha_hasta Datetime,
	@responsable varchar(255)
AS
BEGIN
SELECT *
FROM OrdenesRetiro
WHERE(@fecha_desde is null OR fecha_orden >= @fecha_desde)
	AND (@fecha_hasta is null OR fecha_orden <= @fecha_hasta)
	AND (@responsable is null OR responsable LIKE '%' + @responsable + '%');
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_ORDENES_MAYOR]    Script Date: 24/10/2023 10:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_CONSULTAR_ORDENES_MAYOR]
@responsable varchar(30),
@fecha_orden datetime
AS
BEGIN
SELECT id_orden, responsable, fecha_orden
FROM OrdenesRetiro 
WHERE (responsable LIKE '%'+@responsable+'%')
AND fecha_orden<@fecha_orden
AND fecha_baja IS NULL
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_ORDENES_MENOR]    Script Date: 24/10/2023 10:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_CONSULTAR_ORDENES_MENOR]
@responsable varchar(30),
@fecha_orden datetime
AS
BEGIN
SELECT id_orden, responsable, fecha_orden
FROM OrdenesRetiro 
WHERE (responsable LIKE '%'+@responsable+'%')
AND fecha_orden>@fecha_orden
AND fecha_baja IS NULL
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLE]    Script Date: 24/10/2023 10:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_DETALLE]
@id_detalle int,
@id_orden int,
@material int,
@cantidad int
AS
BEGIN
INSERT INTO DetallesOrden(id_detalle,id_orden,material,cantidad)
VALUES(@id_detalle,@id_orden,@material,@cantidad)

END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_ORDEN]    Script Date: 24/10/2023 10:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_INSERTAR_ORDEN]
@fecha_orden datetime,
@responsable varchar(50),
@prox_orden int output
AS
BEGIN
INSERT INTO OrdenesRetiro(fecha_orden,responsable) VALUES (@fecha_orden,@responsable)
SET @prox_orden = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_PROXIMA_ORDEN]    Script Date: 24/10/2023 10:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_PROXIMA_ORDEN]
@next int OUTPUT
AS
BEGIN
    SET @next = (SELECT max(id_orden)+1 FROM OrdenesRetiro);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_REPORTE_PRODUCTOS]    Script Date: 24/10/2023 10:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_REPORTE_PRODUCTOS]
@fecha_desde datetime, 
@fecha_hasta datetime 
AS
BEGIN
	SELECT m.nom_material,SUM(stock_material) 'cantidad de stock'
	FROM[dbo].[OrdenesRetiro] o join
	[dbo].[DetallesOrden] d on d.id_orden=o.id_orden
	join[dbo].[Materiales] m on m.id_material=d.material
	WHERE fecha_orden between @fecha_desde and @fecha_hasta
	group by m.nom_material
END
GO
/****** Object:  StoredProcedure [dbo].[SP_REPORTE_STOCK]    Script Date: 24/10/2023 10:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_REPORTE_STOCK]
@fecha_desde datetime, 
@fecha_hasta datetime 
AS
BEGIN
	SELECT m.nom_material,stock_material
	FROM[dbo].[OrdenesRetiro] o join
	[dbo].[DetallesOrden] d on d.id_orden=o.id_orden
	join[dbo].[Materiales] m on m.id_material=d.material
	WHERE fecha_orden between @fecha_desde and @fecha_hasta
	
END
GO
USE [master]
GO
ALTER DATABASE [PREPARCIAL1] SET  READ_WRITE 
GO
