CREATE TABLE [dbo].[Order](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Amount] [int] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO