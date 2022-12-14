USE [Mylunch]
GO
/****** Object:  Table [dbo].[lunchtable]    Script Date: 2022/9/21 下午 03:26:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lunchtable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](10) NULL,
	[lunch] [nchar](10) NULL,
 CONSTRAINT [PK_lunchtable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[lunchtable] ON 

INSERT [dbo].[lunchtable] ([id], [name], [lunch]) VALUES (1, N'陳瑋廷       ', N'香蕉        ')
INSERT [dbo].[lunchtable] ([id], [name], [lunch]) VALUES (2, N'蔡政廷       ', N'蘋果        ')
INSERT [dbo].[lunchtable] ([id], [name], [lunch]) VALUES (3, N'吉娃娃       ', N'香蕉        ')
INSERT [dbo].[lunchtable] ([id], [name], [lunch]) VALUES (4, N'陳水扁       ', N'紅茶        ')
INSERT [dbo].[lunchtable] ([id], [name], [lunch]) VALUES (5, N'蔡英文       ', N'高級牛排      ')
INSERT [dbo].[lunchtable] ([id], [name], [lunch]) VALUES (6, N'馬英九       ', N'便當        ')
INSERT [dbo].[lunchtable] ([id], [name], [lunch]) VALUES (7, N'陳時中       ', N'Covid-19  ')
INSERT [dbo].[lunchtable] ([id], [name], [lunch]) VALUES (8, N'習近平       ', N'蜂蜜        ')
INSERT [dbo].[lunchtable] ([id], [name], [lunch]) VALUES (9, N'陳其邁       ', N'蘋果        ')
INSERT [dbo].[lunchtable] ([id], [name], [lunch]) VALUES (10, N'馬東石       ', N'高級牛排      ')
INSERT [dbo].[lunchtable] ([id], [name], [lunch]) VALUES (11, N'小名        ', N'素食        ')
SET IDENTITY_INSERT [dbo].[lunchtable] OFF
GO
