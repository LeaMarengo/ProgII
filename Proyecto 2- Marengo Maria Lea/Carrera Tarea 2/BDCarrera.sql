USE [master]
GO
/****** Object:  Database [Carrera1]    Script Date: 24/10/2023 11:24:41 ******/
CREATE DATABASE [Carrera1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Carrera1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MYSQLSERVER19\MSSQL\DATA\Carrera1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Carrera1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MYSQLSERVER19\MSSQL\DATA\Carrera1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Carrera1] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Carrera1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Carrera1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Carrera1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Carrera1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Carrera1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Carrera1] SET ARITHABORT OFF 
GO
ALTER DATABASE [Carrera1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Carrera1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Carrera1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Carrera1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Carrera1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Carrera1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Carrera1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Carrera1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Carrera1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Carrera1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Carrera1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Carrera1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Carrera1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Carrera1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Carrera1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Carrera1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Carrera1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Carrera1] SET RECOVERY FULL 
GO
ALTER DATABASE [Carrera1] SET  MULTI_USER 
GO
ALTER DATABASE [Carrera1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Carrera1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Carrera1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Carrera1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Carrera1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Carrera1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Carrera1', N'ON'
GO
ALTER DATABASE [Carrera1] SET QUERY_STORE = ON
GO
ALTER DATABASE [Carrera1] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Carrera1]
GO
/****** Object:  Table [dbo].[Asignaturas]    Script Date: 24/10/2023 11:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignaturas](
	[id_asignatura] [int] IDENTITY(1,1) NOT NULL,
	[nombre_asignatura] [varchar](30) NULL,
 CONSTRAINT [pk_Asignatura] PRIMARY KEY CLUSTERED 
(
	[id_asignatura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carreras]    Script Date: 24/10/2023 11:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carreras](
	[id_Carrera] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](50) NULL,
 CONSTRAINT [pk_Carrera] PRIMARY KEY CLUSTERED 
(
	[id_Carrera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_Carrera]    Script Date: 24/10/2023 11:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Carrera](
	[id_Carrera] [int] NOT NULL,
	[id_DetCar] [int] IDENTITY(1,1) NOT NULL,
	[AnioCursado] [datetime] NULL,
	[Cuatrimestre] [int] NULL,
	[id_asignatura] [int] NULL,
 CONSTRAINT [pk_DC1] PRIMARY KEY CLUSTERED 
(
	[id_Carrera] ASC,
	[id_DetCar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Asignaturas] ON 
GO
INSERT [dbo].[Asignaturas] ([id_asignatura], [nombre_asignatura]) VALUES (1, N'Matemáticas')
GO
INSERT [dbo].[Asignaturas] ([id_asignatura], [nombre_asignatura]) VALUES (2, N'Física')
GO
INSERT [dbo].[Asignaturas] ([id_asignatura], [nombre_asignatura]) VALUES (3, N'Programación')
GO
SET IDENTITY_INSERT [dbo].[Asignaturas] OFF
GO
SET IDENTITY_INSERT [dbo].[Carreras] ON 
GO
INSERT [dbo].[Carreras] ([id_Carrera], [Titulo]) VALUES (1, N'Ingeniería en Informática')
GO
INSERT [dbo].[Carreras] ([id_Carrera], [Titulo]) VALUES (3, N'HELPER')
GO
INSERT [dbo].[Carreras] ([id_Carrera], [Titulo]) VALUES (5, N'Ingenieria en Sistemas')
GO
INSERT [dbo].[Carreras] ([id_Carrera], [Titulo]) VALUES (6, N'Ingenieria Industrial')
GO
SET IDENTITY_INSERT [dbo].[Carreras] OFF
GO
SET IDENTITY_INSERT [dbo].[Detalle_Carrera] ON 
GO
INSERT [dbo].[Detalle_Carrera] ([id_Carrera], [id_DetCar], [AnioCursado], [Cuatrimestre], [id_asignatura]) VALUES (2, 1, CAST(N'2023-09-01T00:00:00.000' AS DateTime), 1, 1)
GO
INSERT [dbo].[Detalle_Carrera] ([id_Carrera], [id_DetCar], [AnioCursado], [Cuatrimestre], [id_asignatura]) VALUES (2, 2, CAST(N'2023-09-01T00:00:00.000' AS DateTime), 2, 2)
GO
SET IDENTITY_INSERT [dbo].[Detalle_Carrera] OFF
GO
ALTER TABLE [dbo].[Detalle_Carrera]  WITH CHECK ADD  CONSTRAINT [fk_DC_Asignatura] FOREIGN KEY([id_asignatura])
REFERENCES [dbo].[Asignaturas] ([id_asignatura])
GO
ALTER TABLE [dbo].[Detalle_Carrera] CHECK CONSTRAINT [fk_DC_Asignatura]
GO
/****** Object:  StoredProcedure [dbo].[sp_ConsultarAsignaturas]    Script Date: 24/10/2023 11:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_ConsultarAsignaturas]
AS
BEGIN
    SELECT id_asignatura, nombre_asignatura
    FROM Asignaturas;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ConsultarCarreras]    Script Date: 24/10/2023 11:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_ConsultarCarreras]
AS
BEGIN
    SELECT id_Carrera, Titulo
    FROM Carreras;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLE]    Script Date: 24/10/2023 11:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_INSERTAR_DETALLE]
	@id_Carrera int OUTPUT,
	@anioCursado datetime,
	@Cuatrimestre int,
	@id_asignatura int
as
begin
	insert into Detalle_Carrera(AnioCursado,Cuatrimestre,id_asignatura)
	values (getdate(),@Cuatrimestre,@id_asignatura);
	set @id_Carrera = SCOPE_IDENTITY();
end
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_MAESTRO]    Script Date: 24/10/2023 11:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_MAESTRO]
	@nombre_asignatura varchar(300),
	@id_asignatura int OUTPUT
as
begin
	insert into Asignaturas(nombre_asignatura)
	values (@nombre_asignatura);
	set @id_asignatura = SCOPE_IDENTITY();
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_ProximaCarrera]    Script Date: 24/10/2023 11:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[Sp_ProximaCarrera]
@next int OUTPUT
AS
BEGIN
	SET @next = (SELECT MAX(id_carrera)+1  FROM Carreras);
END
GO
USE [master]
GO
ALTER DATABASE [Carrera1] SET  READ_WRITE 
GO
