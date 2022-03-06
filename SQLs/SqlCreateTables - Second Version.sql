USE [weatherapp.dev]
GO

USE [weatherapp.dev]
GO

/****** Object:  Table [dbo].[Wind]    Script Date: 27/02/2022 14:20:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Wind](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Speed] [float] NOT NULL,
	[Deg] [int] NOT NULL,
	[Gust] [float] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Wind] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

===================================================================================================================================================================

USE [weatherapp.dev]
GO

/****** Object:  Table [dbo].[Weather]    Script Date: 27/02/2022 14:20:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Weather](
	[Id] [int] NOT NULL,
	[Description] [nchar](50) NOT NULL,
	[Main] [varchar](15) NOT NULL,
	[Icon] [nchar](10) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Weather] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


===================================================================================================================================================================

USE [weatherapp.dev]
GO

/****** Object:  Table [dbo].[SysAttribute]    Script Date: 04/03/2022 01:17:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SysAttribute](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sunrise] [int] NOT NULL,
	[Sunset] [int] NOT NULL,
	[Country] [nchar](60) NOT NULL,
	[Type] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_SysAttributes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



===================================================================================================================================================================

USE [weatherapp.dev]
GO

/****** Object:  Table [dbo].[Local]    Script Date: 27/02/2022 14:20:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Local](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](100) NOT NULL,
	[Timezone] [int] NOT NULL,
	[Cod] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Local] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

===================================================================================================================================================================

USE [weatherapp.dev]
GO

/****** Object:  Table [dbo].[Cloud]    Script Date: 27/02/2022 15:32:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cloud](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[All] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Clouds] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

===================================================================================================================================================================

USE [weatherapp.dev]
GO

/****** Object:  Table [dbo].[Atmosphere_condition]    Script Date: 27/02/2022 14:19:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Atmosphere_condition](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Temp] [float] NOT NULL,
	[FeelsLike] [float] NOT NULL,
	[TempMin] [float] NOT NULL,
	[TempMax] [float] NOT NULL,
	[Pressure] [int] NOT NULL,
	[Humidity] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Atmosphere_conditions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

===================================================================================================================================================================

USE [weatherapp.dev]
GO

/****** Object:  Table [dbo].[Weather]    Script Date: 27/02/2022 15:58:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Weather](
	[Id] [int] NOT NULL,
	[Description] [nchar](50) NOT NULL,
	[Main] [varchar](15) NOT NULL,
	[Icon] [nchar](10) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Weather] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

===================================================================================================================================================================

USE [weatherapp.dev]
GO

/****** Object:  Table [dbo].[Current_Local_Weather]    Script Date: 27/02/2022 14:19:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Current_Local_Weather](
	[Id] [int] NOT NULL,
	[Wind_Id] [int] NOT NULL,
	[Local_Id] [int] NOT NULL,
	[Atmosphere_conditions_Id] [int] NOT NULL,
	[Clouds_Id] [int] NOT NULL,
	[SysAttributes_Id] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Current_Local_Weather] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

===================================================================================================================================================================

USE [weatherapp.dev]
GO

/****** Object:  Table [dbo].[Current_Local_Weather_Weather]    Script Date: 27/02/2022 14:19:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Current_Local_Weather_Weather](
	[Weather_Id] [int] NOT NULL,
	[Current_Local_Weather_Weather_Id] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Current_Local_Weather_Weather] PRIMARY KEY CLUSTERED 
(
	[Weather_Id] ASC,
	[Current_Local_Weather_Weather_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Current_Local_Weather_Weather]  WITH CHECK ADD  CONSTRAINT [FK_Current_Local_Weather_Weather_Current_Local_Weather] FOREIGN KEY([Current_Local_Weather_Weather_Id])
REFERENCES [dbo].[Current_Local_Weather] ([Id])
GO

ALTER TABLE [dbo].[Current_Local_Weather_Weather] CHECK CONSTRAINT [FK_Current_Local_Weather_Weather_Current_Local_Weather]
GO

ALTER TABLE [dbo].[Current_Local_Weather_Weather]  WITH CHECK ADD  CONSTRAINT [FK_Current_Local_Weather_Weather_Weather] FOREIGN KEY([Weather_Id])
REFERENCES [dbo].[Weather] ([Id])
GO

ALTER TABLE [dbo].[Current_Local_Weather_Weather] CHECK CONSTRAINT [FK_Current_Local_Weather_Weather_Weather]
GO

===================================================================================================================================================================