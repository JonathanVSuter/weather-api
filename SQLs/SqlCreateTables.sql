--------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE [weatherapp.dev]
GO

/****** Object:  Table [dbo].[Wind]    Script Date: 23/01/2022 16:13:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Wind](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Speed] [real] NOT NULL,
	[Degree] [real] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
	[Gust] [real] NOT NULL,
 CONSTRAINT [PK_Wind] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


--------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE [weatherapp.dev]
GO

/****** Object:  Table [dbo].[Cloud]    Script Date: 23/01/2022 16:11:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cloud](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cloudiness] [real] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_Cloud] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE [weatherapp.dev]
GO

/****** Object:  Table [dbo].[Coordinate]    Script Date: 23/01/2022 19:46:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Coordinate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Longitude] [float] NOT NULL,
	[Latitude] [float] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_Coordinate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



--------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE [weatherapp.dev]
GO

/****** Object:  Table [dbo].[Local]    Script Date: 23/01/2022 16:12:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Local](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [varchar](70) NOT NULL,
	[Timezone] [int] NOT NULL,
	[CoordinateId] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[LastUpdate] [datetime] NULL,
 CONSTRAINT [PK_Local] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Local]  WITH CHECK ADD  CONSTRAINT [FK_Local_Coordinate] FOREIGN KEY([CoordinateId])
REFERENCES [dbo].[Coordinate] ([Id])
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE [weatherapp.dev]
GO

/****** Object:  Table [dbo].[Weather]    Script Date: 23/01/2022 16:13:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Weather](
	[Id] [int] NOT NULL,
	[Main] [varchar](20) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Icon] [varchar](10) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE [weatherapp.dev]
GO

/****** Object:  Table [dbo].[Local_Cloud]    Script Date: 23/01/2022 16:15:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Local_Cloud](
	[fk_Local_Id] [int] NOT NULL,
	[fk_Cloud_Id] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[LastUpdate] [datetime] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Local_Cloud]  WITH CHECK ADD  CONSTRAINT [FK_Local_Cloud_Cloud] FOREIGN KEY([fk_Cloud_Id])
REFERENCES [dbo].[Cloud] ([Id])
GO

ALTER TABLE [dbo].[Local_Cloud] CHECK CONSTRAINT [FK_Local_Cloud_Cloud]
GO

ALTER TABLE [dbo].[Local_Cloud]  WITH CHECK ADD  CONSTRAINT [FK_Local_Cloud_Local] FOREIGN KEY([fk_Local_Id])
REFERENCES [dbo].[Local] ([Id])
GO

ALTER TABLE [dbo].[Local_Cloud] CHECK CONSTRAINT [FK_Local_Cloud_Local]
GO


--------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE [weatherapp.dev]
GO

/****** Object:  Table [dbo].[Local_Weather]    Script Date: 23/01/2022 16:16:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Local_Weather](
	[fk_Local_Id] [int] NOT NULL,
	[fk_Weather_Id] [int] NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Local_Weather]  WITH CHECK ADD  CONSTRAINT [FK_Local_Weather_Local] FOREIGN KEY([fk_Local_Id])
REFERENCES [dbo].[Local] ([Id])
GO

ALTER TABLE [dbo].[Local_Weather] CHECK CONSTRAINT [FK_Local_Weather_Local]
GO

ALTER TABLE [dbo].[Local_Weather]  WITH CHECK ADD  CONSTRAINT [FK_Local_Weather_Weather] FOREIGN KEY([fk_Weather_Id])
REFERENCES [dbo].[Weather] ([Id])
GO

ALTER TABLE [dbo].[Local_Weather] CHECK CONSTRAINT [FK_Local_Weather_Weather]
GO


--------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE [weatherapp.dev]
GO

/****** Object:  Table [dbo].[Local_Wind]    Script Date: 23/01/2022 16:17:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Local_Wind](
	[fk_Local_Id] [int] NOT NULL,
	[fk_Wind_Id] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[LastUpdate] [datetime] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Local_Wind]  WITH CHECK ADD  CONSTRAINT [FK_Local_Wind_Local] FOREIGN KEY([fk_Local_Id])
REFERENCES [dbo].[Local] ([Id])
GO

ALTER TABLE [dbo].[Local_Wind] CHECK CONSTRAINT [FK_Local_Wind_Local]
GO

ALTER TABLE [dbo].[Local_Wind]  WITH CHECK ADD  CONSTRAINT [FK_Local_Wind_Wind] FOREIGN KEY([fk_Wind_Id])
REFERENCES [dbo].[Wind] ([Id])
GO

ALTER TABLE [dbo].[Local_Wind] CHECK CONSTRAINT [FK_Local_Wind_Wind]
GO






