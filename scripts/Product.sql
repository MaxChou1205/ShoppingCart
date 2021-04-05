-- Create table.
CREATE TABLE [dbo].[Product](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL
) ON [PRIMARY]
GO

-- Insert Data
INSERT INTO Product (Name,Price) 
values 
('Item1',10),
('Item2',5),
('Item3',30)