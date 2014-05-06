USE [master]
GO

/****** Object:  Database [DomainLayerSample]    Script Date: 11/04/2013 07:31:46 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'DomainLayerSample')
BEGIN
ALTER DATABASE [DomainLayerSample] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
DROP DATABASE [DomainLayerSample]
END
GO

/****** Object:  Database [DomainLayerSample]    Script Date: 11/03/2013 13:08:47 ******/
CREATE DATABASE [DomainLayerSample] ON  PRIMARY 
( NAME = N'DomainLayerSample', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\DomainLayerSample.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DomainLayerSample_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\DomainLayerSample_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DomainLayerSample] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DomainLayerSample].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DomainLayerSample] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [DomainLayerSample] SET ANSI_NULLS OFF
GO
ALTER DATABASE [DomainLayerSample] SET ANSI_PADDING OFF
GO
ALTER DATABASE [DomainLayerSample] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [DomainLayerSample] SET ARITHABORT OFF
GO
ALTER DATABASE [DomainLayerSample] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [DomainLayerSample] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [DomainLayerSample] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [DomainLayerSample] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [DomainLayerSample] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [DomainLayerSample] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [DomainLayerSample] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [DomainLayerSample] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [DomainLayerSample] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [DomainLayerSample] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [DomainLayerSample] SET  DISABLE_BROKER
GO
ALTER DATABASE [DomainLayerSample] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [DomainLayerSample] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [DomainLayerSample] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [DomainLayerSample] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [DomainLayerSample] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [DomainLayerSample] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [DomainLayerSample] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [DomainLayerSample] SET  READ_WRITE
GO
ALTER DATABASE [DomainLayerSample] SET RECOVERY SIMPLE
GO
ALTER DATABASE [DomainLayerSample] SET  MULTI_USER
GO
ALTER DATABASE [DomainLayerSample] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [DomainLayerSample] SET DB_CHAINING OFF
GO

USE [DomainLayerSample]
GO

CREATE TABLE [dbo].[Location](
	[LocationID] [int] IDENTITY(1,1) NOT NULL,
	[WashableContainerID] [int] NULL,
	[HouseID] [int] NULL,
	[KitchenCabinetID] [int] NULL,
	[FridgeID] [int] NULL,
	[DishwasherID] [int] NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_UC_Location] ON [dbo].[Location] 
(
	[DishwasherID] ASC,
	[FridgeID] ASC,
	[HouseID] ASC,
	[KitchenCabinetID] ASC,
	[WashableContainerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Avatar]    Script Date: 11/03/2013 13:08:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Avatar](
	[AvatarID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[CaloriesConsumed] [int] NOT NULL,
 CONSTRAINT [PK_Avatar] PRIMARY KEY CLUSTERED 
(
	[AvatarID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WashableContainerObjectType]    Script Date: 11/03/2013 13:08:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WashableContainerObjectType](
	[WashableContainerTypeID] [int] NOT NULL,
	[WashableContainerTypeDescription] [varchar](50) NOT NULL,
 CONSTRAINT [PK_WashableContainerObjectType] PRIMARY KEY CLUSTERED 
(
	[WashableContainerTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WideWorld]    Script Date: 11/03/2013 13:08:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WideWorld](
	[WideWorldID] [int] IDENTITY(1,1) NOT NULL,
	[AvatarID] [int] NOT NULL,
 CONSTRAINT [PK_WideWorld] PRIMARY KEY CLUSTERED 
(
	[WideWorldID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WashableObjectType]    Script Date: 11/03/2013 13:08:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WashableObjectType](
	[WashableObjectTypeID] [int] NOT NULL,
	[WashableObjectTypeDescription] [varchar](50) NOT NULL,
 CONSTRAINT [PK_WashableObjectType] PRIMARY KEY CLUSTERED 
(
	[WashableObjectTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Yard]    Script Date: 11/03/2013 13:08:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Yard](
	[YardID] [int] IDENTITY(1,1) NOT NULL,
	[WideWorldID] [int] NOT NULL,
	[Street] [varchar](100) NOT NULL,
	[Unit] [varchar](10) NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](2) NOT NULL,
	[Zip] [varchar](5) NOT NULL,
 CONSTRAINT [PK_Yard] PRIMARY KEY CLUSTERED 
(
	[YardID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WashableObject]    Script Date: 11/03/2013 13:08:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WashableObject](
	[WashableObjectID] [int] IDENTITY(1,1) NOT NULL,
	[WashableObjectTypeID] [int] NOT NULL,
	[LocationID] [int] NOT NULL,
	[PercentClean] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_WashableObject] PRIMARY KEY CLUSTERED 
(
	[WashableObjectID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WashableContainerObject]    Script Date: 11/03/2013 13:08:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WashableContainerObject](
	[WashableContainerObjectID] [int] NOT NULL,
	[WashableContainerObjectTypeID] [int] NOT NULL,
	[LocationID] [int] NOT NULL,
	[PercentClean] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_WashableContainerObject] PRIMARY KEY CLUSTERED 
(
	[WashableContainerObjectID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[House]    Script Date: 11/03/2013 13:08:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[House](
	[HouseID] [int] IDENTITY(1,1) NOT NULL,
	[YardID] [int] NOT NULL,
	[ColorInRGB] [varchar](6) NOT NULL,
	[NumberOfStories] [int] NOT NULL,
 CONSTRAINT [PK_House] PRIMARY KEY CLUSTERED 
(
	[HouseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KitchenCabinet]    Script Date: 11/03/2013 13:08:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KitchenCabinet](
	[KitchenCabinetID] [int] IDENTITY(1,1) NOT NULL,
	[HouseID] [int] NOT NULL,
	[IsLocked] [bit] NOT NULL CONSTRAINT [DF_KitchenCabinet_IsLocked]  DEFAULT ((0)),
 CONSTRAINT [PK_KitchenCabinet] PRIMARY KEY CLUSTERED 
(
	[KitchenCabinetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fridge]    Script Date: 11/03/2013 13:08:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fridge](
	[FridgeID] [int] IDENTITY(1,1) NOT NULL,
	[HouseID] [int] NOT NULL,
	[BeerRemaining] [int] NOT NULL,
 CONSTRAINT [PK_Fridge] PRIMARY KEY CLUSTERED 
(
	[FridgeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dog]    Script Date: 11/03/2013 13:08:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dog](
	[DogID] [int] IDENTITY(1,1) NOT NULL,
	[WideWorldID] [int] NULL,
	[YardID] [int] NULL,
	[HouseID] [int] NULL,
	[AvatarID] [int] NULL,
	[PercentClean] [decimal](18, 0) NULL,
	[DogName] [varchar](50) NOT NULL,
	[ColorInRGB] [varchar](6) NOT NULL,
 CONSTRAINT [PK_Dog] PRIMARY KEY CLUSTERED 
(
	[DogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dishwasher]    Script Date: 11/03/2013 13:08:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dishwasher](
	[DishwasherID] [int] IDENTITY(1,1) NOT NULL,
	[HouseID] [int] NOT NULL,
	[IsLocked] [bit] NOT NULL CONSTRAINT [DF_Dishwasher_IsLocked]  DEFAULT ((0)),
 CONSTRAINT [PK_Dishwasher] PRIMARY KEY CLUSTERED 
(
	[DishwasherID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Yard_WideWorld]    Script Date: 11/03/2013 13:08:49 ******/
ALTER TABLE [dbo].[Yard]  WITH CHECK ADD  CONSTRAINT [FK_Yard_WideWorld] FOREIGN KEY([WideWorldID])
REFERENCES [dbo].[WideWorld] ([WideWorldID])
GO
ALTER TABLE [dbo].[Yard] CHECK CONSTRAINT [FK_Yard_WideWorld]
GO
/****** Object:  ForeignKey [FK_WashableObject_Location]    Script Date: 11/03/2013 13:08:49 ******/
ALTER TABLE [dbo].[WashableObject]  WITH CHECK ADD  CONSTRAINT [FK_WashableObject_Location] FOREIGN KEY([LocationID])
REFERENCES [dbo].[Location] ([LocationID])
GO
ALTER TABLE [dbo].[WashableObject] CHECK CONSTRAINT [FK_WashableObject_Location]
GO
/****** Object:  ForeignKey [FK_WashableObject_WashableObjectType]    Script Date: 11/03/2013 13:08:49 ******/
ALTER TABLE [dbo].[WashableObject]  WITH CHECK ADD  CONSTRAINT [FK_WashableObject_WashableObjectType] FOREIGN KEY([WashableObjectTypeID])
REFERENCES [dbo].[WashableObjectType] ([WashableObjectTypeID])
GO
ALTER TABLE [dbo].[WashableObject] CHECK CONSTRAINT [FK_WashableObject_WashableObjectType]
GO
/****** Object:  ForeignKey [FK_WashableContainerObject_Location]    Script Date: 11/03/2013 13:08:49 ******/
ALTER TABLE [dbo].[WashableContainerObject]  WITH CHECK ADD  CONSTRAINT [FK_WashableContainerObject_Location] FOREIGN KEY([LocationID])
REFERENCES [dbo].[Location] ([LocationID])
GO
ALTER TABLE [dbo].[WashableContainerObject] CHECK CONSTRAINT [FK_WashableContainerObject_Location]
GO
/****** Object:  ForeignKey [FK_WashableContainerObject_WashableContainerObjectType]    Script Date: 11/03/2013 13:08:49 ******/
ALTER TABLE [dbo].[WashableContainerObject]  WITH CHECK ADD  CONSTRAINT [FK_WashableContainerObject_WashableContainerObjectType] FOREIGN KEY([WashableContainerObjectTypeID])
REFERENCES [dbo].[WashableContainerObjectType] ([WashableContainerTypeID])
GO
ALTER TABLE [dbo].[WashableContainerObject] CHECK CONSTRAINT [FK_WashableContainerObject_WashableContainerObjectType]
GO
/****** Object:  ForeignKey [FK_House_Yard]    Script Date: 11/03/2013 13:08:49 ******/
ALTER TABLE [dbo].[House]  WITH CHECK ADD  CONSTRAINT [FK_House_Yard] FOREIGN KEY([YardID])
REFERENCES [dbo].[Yard] ([YardID])
GO
ALTER TABLE [dbo].[House] CHECK CONSTRAINT [FK_House_Yard]
GO
/****** Object:  ForeignKey [FK_KitchenCabinet_House]    Script Date: 11/03/2013 13:08:49 ******/
ALTER TABLE [dbo].[KitchenCabinet]  WITH CHECK ADD  CONSTRAINT [FK_KitchenCabinet_House] FOREIGN KEY([HouseID])
REFERENCES [dbo].[House] ([HouseID])
GO
ALTER TABLE [dbo].[KitchenCabinet] CHECK CONSTRAINT [FK_KitchenCabinet_House]
GO
/****** Object:  ForeignKey [FK_Fridge_House]    Script Date: 11/03/2013 13:08:49 ******/
ALTER TABLE [dbo].[Fridge]  WITH CHECK ADD  CONSTRAINT [FK_Fridge_House] FOREIGN KEY([HouseID])
REFERENCES [dbo].[House] ([HouseID])
GO
ALTER TABLE [dbo].[Fridge] CHECK CONSTRAINT [FK_Fridge_House]
GO
/****** Object:  ForeignKey [FK_Dog_Avatar]    Script Date: 11/03/2013 13:08:49 ******/
ALTER TABLE [dbo].[Dog]  WITH CHECK ADD  CONSTRAINT [FK_Dog_Avatar] FOREIGN KEY([AvatarID])
REFERENCES [dbo].[Avatar] ([AvatarID])
GO
ALTER TABLE [dbo].[Dog] CHECK CONSTRAINT [FK_Dog_Avatar]
GO
/****** Object:  ForeignKey [FK_Dog_House]    Script Date: 11/03/2013 13:08:49 ******/
ALTER TABLE [dbo].[Dog]  WITH CHECK ADD  CONSTRAINT [FK_Dog_House] FOREIGN KEY([HouseID])
REFERENCES [dbo].[House] ([HouseID])
GO
ALTER TABLE [dbo].[Dog] CHECK CONSTRAINT [FK_Dog_House]
GO
/****** Object:  ForeignKey [FK_Dog_WideWorld]    Script Date: 11/03/2013 13:08:49 ******/
ALTER TABLE [dbo].[Dog]  WITH CHECK ADD  CONSTRAINT [FK_Dog_WideWorld] FOREIGN KEY([WideWorldID])
REFERENCES [dbo].[WideWorld] ([WideWorldID])
GO
ALTER TABLE [dbo].[Dog] CHECK CONSTRAINT [FK_Dog_WideWorld]
GO
/****** Object:  ForeignKey [FK_Dog_Yard]    Script Date: 11/03/2013 13:08:49 ******/
ALTER TABLE [dbo].[Dog]  WITH CHECK ADD  CONSTRAINT [FK_Dog_Yard] FOREIGN KEY([YardID])
REFERENCES [dbo].[Yard] ([YardID])
GO
ALTER TABLE [dbo].[Dog] CHECK CONSTRAINT [FK_Dog_Yard]
GO
/****** Object:  ForeignKey [FK_Dishwasher_House]    Script Date: 11/03/2013 13:08:49 ******/
ALTER TABLE [dbo].[Dishwasher]  WITH CHECK ADD  CONSTRAINT [FK_Dishwasher_House] FOREIGN KEY([HouseID])
REFERENCES [dbo].[House] ([HouseID])
GO
ALTER TABLE [dbo].[Dishwasher] CHECK CONSTRAINT [FK_Dishwasher_House]
GO
