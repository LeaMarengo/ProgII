USE [Carrera1]
GO
/****** Object:  Table [dbo].[Asignaturas]    Script Date: 1/9/2023 22:20:17 ******/
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
/****** Object:  Table [dbo].[Carreras]    Script Date: 1/9/2023 22:20:17 ******/
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
/****** Object:  Table [dbo].[Detalle_Carrera]    Script Date: 1/9/2023 22:20:17 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_ConsultarAsignaturas]    Script Date: 1/9/2023 22:20:17 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLE]    Script Date: 1/9/2023 22:20:17 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_MAESTRO]    Script Date: 1/9/2023 22:20:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_INSERTAR_MAESTRO]
	@nom_carrera varchar(300),
	@id_Carrera int OUTPUT
as
begin
	insert into Carreras(Titulo)
	values (@nom_carrera);
	set @id_Carrera = SCOPE_IDENTITY();
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_ProximaCarrera]    Script Date: 1/9/2023 22:20:17 ******/
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
