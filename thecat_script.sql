USE [TheCat]
GO
/****** Object:  User [rfcunha]    Script Date: 14/12/2022 14:51:21 ******/
CREATE USER [rfcunha] FOR LOGIN [rfcunha] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [rfcunha]
GO
/****** Object:  Table [dbo].[Breeds]    Script Date: 14/12/2022 14:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Breeds](
	[id] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[temperament] [varchar](100) NOT NULL,
	[origin] [varchar](50) NOT NULL,
	[description] [varchar](500) NOT NULL,
 CONSTRAINT [PK_breends] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BreedsImages]    Script Date: 14/12/2022 14:51:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BreedsImages](
	[id] [varchar](50) NOT NULL,
	[idbreeds] [varchar](50) NOT NULL,
	[url] [varchar](500) NOT NULL,
	[width] [smallint] NULL,
	[height] [smallint] NULL,
 CONSTRAINT [PK_images] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BreedsImages]  WITH CHECK ADD  CONSTRAINT [FK_BreedsImages_Breeds] FOREIGN KEY([idbreeds])
REFERENCES [dbo].[Breeds] ([id])
GO
ALTER TABLE [dbo].[BreedsImages] CHECK CONSTRAINT [FK_BreedsImages_Breeds]
GO
