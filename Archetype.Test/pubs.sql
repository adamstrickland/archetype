USE [master]
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE DATABASE [pubs]
GO

USE [pubs]
GO

CREATE TABLE [dbo].[authors](
	[id] int IDENTITY(1,1) NOT NULL,
	[name] varchar(50) NOT NULL,
	CONSTRAINT [pk_authors] PRIMARY KEY (id)
)
GO

CREATE TABLE [dbo].[books](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NOT NULL,
	[author_id] [int] NOT NULL,
	CONSTRAINT [pk_books] PRIMARY KEY (id),
	CONSTRAINT [fk_books_authors] FOREIGN KEY (author_id) REFERENCES authors
)
GO