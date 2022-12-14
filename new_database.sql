USE [Mylunch]
GO
/****** Object:  Table [dbo].[2NF_訂單細表]    Script Date: 2022/10/14 下午 04:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[2NF_訂單細表](
	[master_id] [int] IDENTITY(1,1) NOT NULL,
	[employee_id] [int] NULL,
	[date] [date] NULL,
 CONSTRAINT [PK_2NF_員工細節] PRIMARY KEY CLUSTERED 
(
	[master_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[2NF_員工清單]    Script Date: 2022/10/14 下午 04:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[2NF_員工清單](
	[employee_id] [int] IDENTITY(1,1) NOT NULL,
	[employee_name] [char](10) NULL,
 CONSTRAINT [PK_2NF_日期] PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[3NF_午餐]    Script Date: 2022/10/14 下午 04:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[3NF_午餐](
	[detail_id] [int] IDENTITY(1,1) NOT NULL,
	[master_id] [int] NULL,
	[lunch_id] [int] NULL,
 CONSTRAINT [PK_3NF_午餐] PRIMARY KEY CLUSTERED 
(
	[detail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[3NF_午餐種類]    Script Date: 2022/10/14 下午 04:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[3NF_午餐種類](
	[lunch_id] [int] IDENTITY(1,1) NOT NULL,
	[lunch] [nchar](10) NULL,
 CONSTRAINT [PK_3NF_午餐資訊] PRIMARY KEY CLUSTERED 
(
	[lunch_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[2NF_訂單細表]  WITH CHECK ADD  CONSTRAINT [FK_2NF_訂單細表_2NF_員工清單] FOREIGN KEY([employee_id])
REFERENCES [dbo].[2NF_員工清單] ([employee_id])
GO
ALTER TABLE [dbo].[2NF_訂單細表] CHECK CONSTRAINT [FK_2NF_訂單細表_2NF_員工清單]
GO
ALTER TABLE [dbo].[3NF_午餐]  WITH NOCHECK ADD  CONSTRAINT [FK_3NF_午餐_2NF_訂單細表] FOREIGN KEY([master_id])
REFERENCES [dbo].[2NF_訂單細表] ([master_id])
GO
ALTER TABLE [dbo].[3NF_午餐] CHECK CONSTRAINT [FK_3NF_午餐_2NF_訂單細表]
GO
ALTER TABLE [dbo].[3NF_午餐]  WITH CHECK ADD  CONSTRAINT [FK_3NF_午餐_3NF_午餐種類] FOREIGN KEY([lunch_id])
REFERENCES [dbo].[3NF_午餐種類] ([lunch_id])
GO
ALTER TABLE [dbo].[3NF_午餐] CHECK CONSTRAINT [FK_3NF_午餐_3NF_午餐種類]
GO
