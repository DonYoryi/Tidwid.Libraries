USE [Tidwid.Library] 
CREATE TABLE [dbo].[Library](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](250) NULL,
	[Description] [nvarchar](250) NULL,
	[Language] [nvarchar](250) NULL,
	[IsPublic] [bit] NULL,
	[ParentLibrary] [nvarchar](250) NULL,
	[UrlImage] [nvarchar](250) NULL,
	[PublishDate] [date] NULL,
	[FilePath] [nvarchar](250) NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [nvarchar](250) NULL,
	[ModifiedAt] [datetime] NULL,
	[ModifiedBy] [nvarchar](250) NULL,
 CONSTRAINT [PK_Library] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Tidwid.Library] SET  READ_WRITE 
GO
