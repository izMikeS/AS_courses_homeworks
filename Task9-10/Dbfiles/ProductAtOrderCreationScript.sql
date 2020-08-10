USE [OnlineStore]
GO

/****** Object:  Table [dbo].[ProductAtOrder]    Script Date: 11/16/2019 11:06:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductAtOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_ProductAtOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProductAtOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProductAtOrder_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO

ALTER TABLE [dbo].[ProductAtOrder] CHECK CONSTRAINT [FK_ProductAtOrder_Order]
GO

ALTER TABLE [dbo].[ProductAtOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProductAtOrder_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO

ALTER TABLE [dbo].[ProductAtOrder] CHECK CONSTRAINT [FK_ProductAtOrder_Product]
GO

