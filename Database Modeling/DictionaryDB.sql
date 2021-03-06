USE [master]
GO
/****** Object:  Database Dictionary    Script Date: 04-Oct-15 19:58:26 ******/
CREATE DATABASE Dictionary
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Dictionary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Dictionary.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Dictionary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Dictionary_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE Dictionary SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC Dictionary.[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE Dictionary SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE Dictionary SET ANSI_NULLS OFF 
GO
ALTER DATABASE Dictionary SET ANSI_PADDING OFF 
GO
ALTER DATABASE Dictionary SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE Dictionary SET ARITHABORT OFF 
GO
ALTER DATABASE Dictionary SET AUTO_CLOSE OFF 
GO
ALTER DATABASE Dictionary SET AUTO_SHRINK OFF 
GO
ALTER DATABASE Dictionary SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE Dictionary SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE Dictionary SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE Dictionary SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE Dictionary SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE Dictionary SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE Dictionary SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE Dictionary SET  DISABLE_BROKER 
GO
ALTER DATABASE Dictionary SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE Dictionary SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE Dictionary SET TRUSTWORTHY OFF 
GO
ALTER DATABASE Dictionary SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE Dictionary SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE Dictionary SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE Dictionary SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE Dictionary SET RECOVERY SIMPLE 
GO
ALTER DATABASE Dictionary SET  MULTI_USER 
GO
ALTER DATABASE Dictionary SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE Dictionary SET DB_CHAINING OFF 
GO
ALTER DATABASE Dictionary SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE Dictionary SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE Dictionary SET DELAYED_DURABILITY = DISABLED 
GO
USE Dictionary
GO
/****** Object:  Table [dbo].[Bulgarian_English]    Script Date: 04-Oct-15 19:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bulgarian_English](
	[Bulgarian_Id] [int] NOT NULL,
	[English_Id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BulgarianWords]    Script Date: 04-Oct-15 19:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BulgarianWords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Word] [nvarchar](50) NOT NULL,
	[Explanation] [ntext] NULL,
	[Synonyms_Id] [int] NULL,
 CONSTRAINT [PK_BulgarianWords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EnglishWords]    Script Date: 04-Oct-15 19:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnglishWords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Word] [nvarchar](50) NOT NULL,
	[Explanation] [ntext] NULL,
	[Synonyms_Id] [int] NULL,
 CONSTRAINT [PK_EnglishWords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[German_Bulgarian]    Script Date: 04-Oct-15 19:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[German_Bulgarian](
	[German_Id] [int] NOT NULL,
	[Bulgarian_Id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[German_English]    Script Date: 04-Oct-15 19:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[German_English](
	[German_Id] [int] NOT NULL,
	[English_Id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GermanWords]    Script Date: 04-Oct-15 19:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GermanWords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Word] [nvarchar](50) NOT NULL,
	[Explanation] [ntext] NULL,
	[Synonyms_Id] [int] NULL,
 CONSTRAINT [PK_GermanWords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[Bulgarian_English] ([Bulgarian_Id], [English_Id]) VALUES (1, 1)
INSERT [dbo].[Bulgarian_English] ([Bulgarian_Id], [English_Id]) VALUES (2, 2)
INSERT [dbo].[Bulgarian_English] ([Bulgarian_Id], [English_Id]) VALUES (4, 3)
INSERT [dbo].[Bulgarian_English] ([Bulgarian_Id], [English_Id]) VALUES (7, 3)
SET IDENTITY_INSERT [dbo].[BulgarianWords] ON 

INSERT [dbo].[BulgarianWords] ([Id], [Word], [Explanation], [Synonyms_Id]) VALUES (1, N'Маса', N'Мебел, върху който могат да се поставят различни предмети.', NULL)
INSERT [dbo].[BulgarianWords] ([Id], [Word], [Explanation], [Synonyms_Id]) VALUES (2, N'Стол', N'Мебел за сядане', NULL)
INSERT [dbo].[BulgarianWords] ([Id], [Word], [Explanation], [Synonyms_Id]) VALUES (4, N'Шише', N'Съд за течности', 7)
INSERT [dbo].[BulgarianWords] ([Id], [Word], [Explanation], [Synonyms_Id]) VALUES (7, N'Бутилка', N'Съд за течности', 4)
SET IDENTITY_INSERT [dbo].[BulgarianWords] OFF
SET IDENTITY_INSERT [dbo].[EnglishWords] ON 

INSERT [dbo].[EnglishWords] ([Id], [Word], [Explanation], [Synonyms_Id]) VALUES (1, N'Table', N'Furniture you can put things on top of it.', NULL)
INSERT [dbo].[EnglishWords] ([Id], [Word], [Explanation], [Synonyms_Id]) VALUES (2, N'Chair', N'Furnitur for sitting', NULL)
INSERT [dbo].[EnglishWords] ([Id], [Word], [Explanation], [Synonyms_Id]) VALUES (3, N'Bottle', N'Liquid container', NULL)
SET IDENTITY_INSERT [dbo].[EnglishWords] OFF
INSERT [dbo].[German_Bulgarian] ([German_Id], [Bulgarian_Id]) VALUES (1, 1)
INSERT [dbo].[German_Bulgarian] ([German_Id], [Bulgarian_Id]) VALUES (2, 2)
INSERT [dbo].[German_Bulgarian] ([German_Id], [Bulgarian_Id]) VALUES (3, 4)
INSERT [dbo].[German_English] ([German_Id], [English_Id]) VALUES (1, 1)
INSERT [dbo].[German_English] ([German_Id], [English_Id]) VALUES (2, 2)
INSERT [dbo].[German_English] ([German_Id], [English_Id]) VALUES (3, 3)
SET IDENTITY_INSERT [dbo].[GermanWords] ON 

INSERT [dbo].[GermanWords] ([Id], [Word], [Explanation], [Synonyms_Id]) VALUES (1, N'Tasche', N'Mobel fur verschiedenen objekten', NULL)
INSERT [dbo].[GermanWords] ([Id], [Word], [Explanation], [Synonyms_Id]) VALUES (2, N'Stuhl', N'fur sitzgelegenheiten', NULL)
INSERT [dbo].[GermanWords] ([Id], [Word], [Explanation], [Synonyms_Id]) VALUES (3, N'Flasche', N'Flussigkeiten Behalter', NULL)
SET IDENTITY_INSERT [dbo].[GermanWords] OFF
ALTER TABLE [dbo].[Bulgarian_English]  WITH CHECK ADD  CONSTRAINT [FK_Bulgarian_English_BulgarianWords] FOREIGN KEY([Bulgarian_Id])
REFERENCES [dbo].[BulgarianWords] ([Id])
GO
ALTER TABLE [dbo].[Bulgarian_English] CHECK CONSTRAINT [FK_Bulgarian_English_BulgarianWords]
GO
ALTER TABLE [dbo].[Bulgarian_English]  WITH CHECK ADD  CONSTRAINT [FK_Bulgarian_English_EnglishWords] FOREIGN KEY([English_Id])
REFERENCES [dbo].[EnglishWords] ([Id])
GO
ALTER TABLE [dbo].[Bulgarian_English] CHECK CONSTRAINT [FK_Bulgarian_English_EnglishWords]
GO
ALTER TABLE [dbo].[BulgarianWords]  WITH CHECK ADD  CONSTRAINT [FK_BulgarianWords_BulgarianWords] FOREIGN KEY([Synonyms_Id])
REFERENCES [dbo].[BulgarianWords] ([Id])
GO
ALTER TABLE [dbo].[BulgarianWords] CHECK CONSTRAINT [FK_BulgarianWords_BulgarianWords]
GO
ALTER TABLE [dbo].[EnglishWords]  WITH CHECK ADD  CONSTRAINT [FK_EnglishWords_EnglishWords] FOREIGN KEY([Synonyms_Id])
REFERENCES [dbo].[EnglishWords] ([Id])
GO
ALTER TABLE [dbo].[EnglishWords] CHECK CONSTRAINT [FK_EnglishWords_EnglishWords]
GO
ALTER TABLE [dbo].[German_Bulgarian]  WITH CHECK ADD  CONSTRAINT [FK_German_Bulgarian_BulgarianWords] FOREIGN KEY([Bulgarian_Id])
REFERENCES [dbo].[BulgarianWords] ([Id])
GO
ALTER TABLE [dbo].[German_Bulgarian] CHECK CONSTRAINT [FK_German_Bulgarian_BulgarianWords]
GO
ALTER TABLE [dbo].[German_Bulgarian]  WITH CHECK ADD  CONSTRAINT [FK_German_Bulgarian_GermanWords] FOREIGN KEY([German_Id])
REFERENCES [dbo].[GermanWords] ([Id])
GO
ALTER TABLE [dbo].[German_Bulgarian] CHECK CONSTRAINT [FK_German_Bulgarian_GermanWords]
GO
ALTER TABLE [dbo].[German_English]  WITH CHECK ADD  CONSTRAINT [FK_German_English_EnglishWords] FOREIGN KEY([English_Id])
REFERENCES [dbo].[EnglishWords] ([Id])
GO
ALTER TABLE [dbo].[German_English] CHECK CONSTRAINT [FK_German_English_EnglishWords]
GO
ALTER TABLE [dbo].[German_English]  WITH CHECK ADD  CONSTRAINT [FK_German_English_GermanWords] FOREIGN KEY([German_Id])
REFERENCES [dbo].[GermanWords] ([Id])
GO
ALTER TABLE [dbo].[German_English] CHECK CONSTRAINT [FK_German_English_GermanWords]
GO
ALTER TABLE [dbo].[GermanWords]  WITH CHECK ADD  CONSTRAINT [FK_GermanWords_GermanWords] FOREIGN KEY([Synonyms_Id])
REFERENCES [dbo].[GermanWords] ([Id])
GO
ALTER TABLE [dbo].[GermanWords] CHECK CONSTRAINT [FK_GermanWords_GermanWords]
GO
USE [master]
GO
ALTER DATABASE Dictionary SET  READ_WRITE 
GO
