USE [master]
GO
/****** Object:  Database [SYSANALIZER2]    Script Date: 14-Nov-18 7:45:55 PM ******/
CREATE DATABASE [SYSANALIZER2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SYSANALIZER2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SYSANALIZER2.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SYSANALIZER2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SYSANALIZER2_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SYSANALIZER2] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SYSANALIZER2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SYSANALIZER2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SYSANALIZER2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SYSANALIZER2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SYSANALIZER2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SYSANALIZER2] SET ARITHABORT OFF 
GO
ALTER DATABASE [SYSANALIZER2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SYSANALIZER2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SYSANALIZER2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SYSANALIZER2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SYSANALIZER2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SYSANALIZER2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SYSANALIZER2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SYSANALIZER2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SYSANALIZER2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SYSANALIZER2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SYSANALIZER2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SYSANALIZER2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SYSANALIZER2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SYSANALIZER2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SYSANALIZER2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SYSANALIZER2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SYSANALIZER2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SYSANALIZER2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SYSANALIZER2] SET  MULTI_USER 
GO
ALTER DATABASE [SYSANALIZER2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SYSANALIZER2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SYSANALIZER2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SYSANALIZER2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SYSANALIZER2] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SYSANALIZER2]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 14-Nov-18 7:45:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[IdLog] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Criticidad] [varchar](50) NOT NULL,
	[Actividad] [varchar](255) NOT NULL,
	[InformacionAsociada] [varchar](4000) NOT NULL,
	[UsuarioId] [varchar](50) NULL,
	[DVH] [varchar](50) NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[IdLog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CanalVenta]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CanalVenta](
	[IdCanalVenta] [int] NOT NULL,
	[IdGrupoVenta] [int] NOT NULL,
	[Descripcion] [nvarchar](150) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] NOT NULL,
	[IdCuentaCorriente] [int] NOT NULL,
	[IdDomicilio] [int] NOT NULL,
	[Telefono] [nvarchar](12) NOT NULL,
	[NombreCompleto] [nvarchar](12) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[IdDetalle] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Importe] [float] NOT NULL,
	[Cantidad] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DigitoVerificadorVertical]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DigitoVerificadorVertical](
	[Entidad] [nvarchar](12) NOT NULL,
	[ValorDigitoVerificador] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Domicilio]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Domicilio](
	[IdDomicilio] [int] NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[IdLocalidad] [int] NOT NULL,
 CONSTRAINT [PK_Domicilio] PRIMARY KEY CLUSTERED 
(
	[IdDomicilio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoVenta]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoVenta](
	[IdEstadoVenta] [int] NOT NULL,
	[Descripcion] [nvarchar](12) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia](
	[FamiliaId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FamiliaPatente]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamiliaPatente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FamiliaId] [int] NOT NULL,
	[IdPatente] [int] NOT NULL,
	[DVH] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FamiliaUsuario]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamiliaUsuario](
	[FamiliaId] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[DVH] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FamiliaId] ASC,
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormularioPatente]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormularioPatente](
	[IdFormulario] [int] NOT NULL,
	[IdPatente] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Formularios]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Formularios](
	[IdFormulario] [int] NOT NULL,
	[NombreFormulario] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFormulario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GrupoVenta]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrupoVenta](
	[IdGrupoVenta] [int] NOT NULL,
	[Descripcion] [nvarchar](15) NOT NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_GrupoVenta] PRIMARY KEY CLUSTERED 
(
	[IdGrupoVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[IdIdioma] [int] NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Idioma] PRIMARY KEY CLUSTERED 
(
	[IdIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidad]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidad](
	[IdLocalidad] [int] NOT NULL,
	[Descripcion] [nvarchar](25) NOT NULL,
	[IdProvincia] [int] NOT NULL,
 CONSTRAINT [PK_Localidad] PRIMARY KEY CLUSTERED 
(
	[IdLocalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patente]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patente](
	[IdPatente] [int] NOT NULL,
	[Descripcion] [nvarchar](12) NOT NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[IdPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[PUnitario] [float] NOT NULL,
	[PVenta] [float] NOT NULL,
	[Stock] [int] NOT NULL,
	[DVH] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[IdProvincia] [int] NOT NULL,
	[Descripcion] [nvarchar](25) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoVenta]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoVenta](
	[IdTipoVenta] [int] NOT NULL,
	[Descripcion] [nvarchar](12) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Traduccion]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Traduccion](
	[IdTraduccion] [int] NOT NULL,
	[IdIdioma] [int] NOT NULL,
	[IdFormulario] [int] NOT NULL,
	[ControlName] [varchar](50) NULL,
	[MensajeCodigo] [varchar](50) NULL,
	[Traduccion] [varchar](300) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](20) NOT NULL,
	[Apellido] [nvarchar](12) NOT NULL,
	[Contraseña] [nvarchar](32) NOT NULL,
	[Email] [nvarchar](25) NOT NULL,
	[Telefono] [nvarchar](15) NOT NULL,
	[Domicilio] [nvarchar](50) NULL,
	[ContadorIngresosIncorrectos] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
	[IdCanalVenta] [int] NOT NULL,
	[IdIdioma] [int] NOT NULL,
	[PrimerLogin] [bit] NOT NULL,
	[DVH] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioPatente]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPatente](
	[UsuarioId] [int] NOT NULL,
	[IdPatente] [int] NOT NULL,
	[Negada] [bit] NOT NULL,
	[DVH] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC,
	[IdPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 14-Nov-18 7:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[IdVenta] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[IdEstado] [int] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Monto] [float] NOT NULL,
	[DigitoVerificadorH] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Domicilio]  WITH CHECK ADD  CONSTRAINT [FK_Domicilio_Domicilio] FOREIGN KEY([IdDomicilio])
REFERENCES [dbo].[Domicilio] ([IdDomicilio])
GO
ALTER TABLE [dbo].[Domicilio] CHECK CONSTRAINT [FK_Domicilio_Domicilio]
GO
ALTER TABLE [dbo].[GrupoVenta]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_GrupoVenta] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[GrupoVenta] ([IdGrupoVenta])
GO
ALTER TABLE [dbo].[GrupoVenta] CHECK CONSTRAINT [FK_Usuario_GrupoVenta]
GO
USE [master]
GO
ALTER DATABASE [SYSANALIZER2] SET  READ_WRITE 
GO
