USE [QuatroDB]
GO
/****** Object:  Table [dbo].[AvtoParth]    Script Date: 12/27/2019 6:21:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvtoParth](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ParthCategoryID] [int] NULL,
	[Photo] [nvarchar](800) NULL,
	[Price] [float] NULL,
	[PriceTypeId] [int] NULL,
	[Description] [nvarchar](500) NULL,
	[NewOrOld] [bit] NULL,
	[VipID] [int] NULL,
	[CityID] [int] NULL,
	[PublishDatte] [datetime] NULL,
 CONSTRAINT [PK_AvtoParth] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Avtotechizat]    Script Date: 12/27/2019 6:21:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Avtotechizat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
 CONSTRAINT [PK_Avtotechizat] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brends]    Script Date: 12/27/2019 6:21:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brends](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrendPhoto] [nvarchar](800) NULL,
 CONSTRAINT [PK_Brends] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarsGalery]    Script Date: 12/27/2019 6:21:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarsGalery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Header] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[Photo] [nvarchar](800) NULL,
 CONSTRAINT [PK_CarsGalery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarSupply]    Script Date: 12/27/2019 6:21:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarSupply](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SupplyName] [nvarchar](100) NULL,
 CONSTRAINT [PK_CarSupply] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/27/2019 6:21:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CategoryPhoto] [nvarchar](800) NULL,
	[isProduct] [bit] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CellNumber]    Script Date: 12/27/2019 6:21:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CellNumber](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PhoneType] [nvarchar](3) NULL,
 CONSTRAINT [PK_CellNumber] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 12/27/2019 6:21:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CitName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FuelType]    Script Date: 12/27/2019 6:21:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FuelType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FuelName] [nvarchar](50) NULL,
 CONSTRAINT [PK_FuelType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marka]    Script Date: 12/27/2019 6:21:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marka](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[MarkaPhoto] [nvarchar](700) NULL,
 CONSTRAINT [PK_Marka] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Model]    Script Date: 12/27/2019 6:21:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Model](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[MarkaId] [int] NULL,
 CONSTRAINT [PK_Model] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MotorsCapacity]    Script Date: 12/27/2019 6:21:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotorsCapacity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Capacity] [nvarchar](50) NULL,
 CONSTRAINT [PK_MotorsCapacity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 12/27/2019 6:21:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreateDate] [datetime] NULL,
	[Description] [nvarchar](150) NULL,
	[SubDescription] [nvarchar](500) NULL,
	[NewPhoto] [nvarchar](800) NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PriceType]    Script Date: 12/27/2019 6:21:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[prcTypeName] [nvarchar](6) NULL,
 CONSTRAINT [PK_PriceType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produc_to_AvtoTechizat]    Script Date: 12/27/2019 6:21:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produc_to_AvtoTechizat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[productId] [int] NULL,
	[AvtoTechizat] [int] NULL,
 CONSTRAINT [PK_Produc_to_AvtoTechizat] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_To_Image]    Script Date: 12/27/2019 6:21:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_To_Image](
	[Id] [int] NOT NULL,
	[Photo] [nvarchar](800) NULL,
	[ProductId] [int] NULL,
	[AvtoPartPhotoID] [int] NULL,
 CONSTRAINT [PK_Product_To_Image] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductColors]    Script Date: 12/27/2019 6:21:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductColors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProductColors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12/27/2019 6:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Photo] [nvarchar](800) NULL,
	[PriceTypeId] [int] NULL,
	[Price] [float] NULL,
	[Description] [nvarchar](500) NULL,
	[NewOrOld] [bit] NULL,
	[Published] [bit] NULL,
	[IsActive] [bit] NULL,
	[VIPid] [int] NULL,
	[CategoryID] [int] NULL,
	[CityID] [int] NULL,
	[ProductionDate] [date] NULL,
	[PrublishDate] [datetime] NULL,
	[ProductTypeID] [int] NULL,
	[ModelId] [int] NULL,
	[PinNumber] [int] NULL,
	[IsCredit] [bit] NULL,
	[isBarter] [bit] NULL,
	[MotorCapacityId] [int] NULL,
	[HorsePower] [int] NULL,
	[FuelId] [int] NULL,
	[ColorId] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SliderTop]    Script Date: 12/27/2019 6:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SliderTop](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Header] [nvarchar](150) NULL,
	[Descriptions] [nvarchar](60) NULL,
	[SubDescriptions] [nvarchar](100) NULL,
	[SliderPhoto] [nvarchar](700) NULL,
 CONSTRAINT [PK_SliderTop] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supply_To_Products]    Script Date: 12/27/2019 6:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supply_To_Products](
	[Id] [int] NOT NULL,
	[CarSupplyId] [int] NULL,
	[ProductId] [int] NULL,
 CONSTRAINT [PK_Supply_To_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transmission]    Script Date: 12/27/2019 6:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transmission](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_to_CellNumber]    Script Date: 12/27/2019 6:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_to_CellNumber](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CellnumberId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_User_to_CellNumber] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/27/2019 6:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](20) NULL,
	[Password] [nvarchar](250) NULL,
	[IsActive] [bit] NULL,
	[RegisterDate] [datetime] NULL,
	[CellId] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VIP]    Script Date: 12/27/2019 6:21:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VIP](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Price] [float] NULL,
	[Amount] [int] NULL,
	[Deadline] [datetime] NULL,
	[StartDate] [datetime] NULL,
 CONSTRAINT [PK_VIP] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brends] ON 

INSERT [dbo].[Brends] ([Id], [BrendPhoto]) VALUES (2, N'/uploads/SecBrend/82bc6572-f87e-474a-aa80-8769affe2dad.jpg')
SET IDENTITY_INSERT [dbo].[Brends] OFF
SET IDENTITY_INSERT [dbo].[CellNumber] ON 

INSERT [dbo].[CellNumber] ([Id], [PhoneType]) VALUES (1, N'050')
INSERT [dbo].[CellNumber] ([Id], [PhoneType]) VALUES (2, N'051')
INSERT [dbo].[CellNumber] ([Id], [PhoneType]) VALUES (3, N'055')
INSERT [dbo].[CellNumber] ([Id], [PhoneType]) VALUES (4, N'070')
INSERT [dbo].[CellNumber] ([Id], [PhoneType]) VALUES (5, N'077')
SET IDENTITY_INSERT [dbo].[CellNumber] OFF
SET IDENTITY_INSERT [dbo].[FuelType] ON 

INSERT [dbo].[FuelType] ([Id], [FuelName]) VALUES (1, N'Dizel')
SET IDENTITY_INSERT [dbo].[FuelType] OFF
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([Id], [CreateDate], [Description], [SubDescription], [NewPhoto]) VALUES (2, CAST(N'2018-10-10T00:00:00.000' AS DateTime), N'Ikinci', N'as ikia asd', N'/uploads/newsPhotoF/f0a0f3a7-dbdc-47c1-8f29-b40c5281a664.jpg')
SET IDENTITY_INSERT [dbo].[News] OFF
SET IDENTITY_INSERT [dbo].[PriceType] ON 

INSERT [dbo].[PriceType] ([id], [prcTypeName]) VALUES (1, N'Azn')
INSERT [dbo].[PriceType] ([id], [prcTypeName]) VALUES (2, N'Euro')
INSERT [dbo].[PriceType] ([id], [prcTypeName]) VALUES (3, N'$')
SET IDENTITY_INSERT [dbo].[PriceType] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([id], [Name], [Photo], [PriceTypeId], [Price], [Description], [NewOrOld], [Published], [IsActive], [VIPid], [CategoryID], [CityID], [ProductionDate], [PrublishDate], [ProductTypeID], [ModelId], [PinNumber], [IsCredit], [isBarter], [MotorCapacityId], [HorsePower], [FuelId], [ColorId]) VALUES (3, NULL, N'/uploads/CarsAdmin/af0a7d14-fd3d-488e-8554-3844fb065d1b.png', 3, 8000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Products] ([id], [Name], [Photo], [PriceTypeId], [Price], [Description], [NewOrOld], [Published], [IsActive], [VIPid], [CategoryID], [CityID], [ProductionDate], [PrublishDate], [ProductTypeID], [ModelId], [PinNumber], [IsCredit], [isBarter], [MotorCapacityId], [HorsePower], [FuelId], [ColorId]) VALUES (4, NULL, N'/uploads/CarsAdmin/badd752b-4711-4db4-a731-d2ce55ed80b8.jpg', 3, 8000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Products] ([id], [Name], [Photo], [PriceTypeId], [Price], [Description], [NewOrOld], [Published], [IsActive], [VIPid], [CategoryID], [CityID], [ProductionDate], [PrublishDate], [ProductTypeID], [ModelId], [PinNumber], [IsCredit], [isBarter], [MotorCapacityId], [HorsePower], [FuelId], [ColorId]) VALUES (5, N'bmw', N'/uploads/CarsAdmin/4aa834e1-6b72-4de0-b2f5-19b5a64362f4.jpg', 2, 45000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Products] ([id], [Name], [Photo], [PriceTypeId], [Price], [Description], [NewOrOld], [Published], [IsActive], [VIPid], [CategoryID], [CityID], [ProductionDate], [PrublishDate], [ProductTypeID], [ModelId], [PinNumber], [IsCredit], [isBarter], [MotorCapacityId], [HorsePower], [FuelId], [ColorId]) VALUES (6, N'bmw', N'/uploads/CarsAdmin/7f13b9d7-c319-4fbf-a2f6-fd122990259b.jpg', 1, 50000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Products] ([id], [Name], [Photo], [PriceTypeId], [Price], [Description], [NewOrOld], [Published], [IsActive], [VIPid], [CategoryID], [CityID], [ProductionDate], [PrublishDate], [ProductTypeID], [ModelId], [PinNumber], [IsCredit], [isBarter], [MotorCapacityId], [HorsePower], [FuelId], [ColorId]) VALUES (7, NULL, N'/uploads/CarsAdmin/27fc520e-f13e-4a44-acea-0f88d3c66bec.jpg', 1, 15, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[SliderTop] ON 

INSERT [dbo].[SliderTop] ([Id], [Header], [Descriptions], [SubDescriptions], [SliderPhoto]) VALUES (2, N'bawliq 2', N'lorem 2', N'lorem 2', N'/uploads/section1Photo/f613aaa4-86a9-4b21-83db-3425c49c6dfb.jpg')
INSERT [dbo].[SliderTop] ([Id], [Header], [Descriptions], [SubDescriptions], [SliderPhoto]) VALUES (3, N'bawliq 3', N'lorem 3', N'lorem 3', N'/uploads/section1Photo/10c46be1-189a-4c9f-a0b6-6fd22737868c.jpg')
SET IDENTITY_INSERT [dbo].[SliderTop] OFF
SET IDENTITY_INSERT [dbo].[Transmission] ON 

INSERT [dbo].[Transmission] ([id], [TypeName]) VALUES (1, N'Avtomat')
SET IDENTITY_INSERT [dbo].[Transmission] OFF
SET IDENTITY_INSERT [dbo].[User_to_CellNumber] ON 

INSERT [dbo].[User_to_CellNumber] ([Id], [CellnumberId], [UserId]) VALUES (4, 1, 1)
SET IDENTITY_INSERT [dbo].[User_to_CellNumber] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [FullName], [Email], [Phone], [Password], [IsActive], [RegisterDate], [CellId]) VALUES (1, N'Eldar', N'eldar@gmail.com', N'5444445', N'456123', 1, CAST(N'2019-12-05T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[AvtoParth]  WITH CHECK ADD  CONSTRAINT [FK_AvtoParth_Category] FOREIGN KEY([ParthCategoryID])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[AvtoParth] CHECK CONSTRAINT [FK_AvtoParth_Category]
GO
ALTER TABLE [dbo].[AvtoParth]  WITH CHECK ADD  CONSTRAINT [FK_AvtoParth_Cities] FOREIGN KEY([CityID])
REFERENCES [dbo].[Cities] ([id])
GO
ALTER TABLE [dbo].[AvtoParth] CHECK CONSTRAINT [FK_AvtoParth_Cities]
GO
ALTER TABLE [dbo].[AvtoParth]  WITH CHECK ADD  CONSTRAINT [FK_AvtoParth_PriceType] FOREIGN KEY([PriceTypeId])
REFERENCES [dbo].[PriceType] ([id])
GO
ALTER TABLE [dbo].[AvtoParth] CHECK CONSTRAINT [FK_AvtoParth_PriceType]
GO
ALTER TABLE [dbo].[AvtoParth]  WITH CHECK ADD  CONSTRAINT [FK_AvtoParth_VIP] FOREIGN KEY([VipID])
REFERENCES [dbo].[VIP] ([id])
GO
ALTER TABLE [dbo].[AvtoParth] CHECK CONSTRAINT [FK_AvtoParth_VIP]
GO
ALTER TABLE [dbo].[Model]  WITH CHECK ADD  CONSTRAINT [FK_Model_Marka1] FOREIGN KEY([MarkaId])
REFERENCES [dbo].[Marka] ([id])
GO
ALTER TABLE [dbo].[Model] CHECK CONSTRAINT [FK_Model_Marka1]
GO
ALTER TABLE [dbo].[Produc_to_AvtoTechizat]  WITH CHECK ADD  CONSTRAINT [FK_Produc_to_AvtoTechizat_Avtotechizat] FOREIGN KEY([AvtoTechizat])
REFERENCES [dbo].[Avtotechizat] ([id])
GO
ALTER TABLE [dbo].[Produc_to_AvtoTechizat] CHECK CONSTRAINT [FK_Produc_to_AvtoTechizat_Avtotechizat]
GO
ALTER TABLE [dbo].[Produc_to_AvtoTechizat]  WITH CHECK ADD  CONSTRAINT [FK_Produc_to_AvtoTechizat_Products] FOREIGN KEY([productId])
REFERENCES [dbo].[Products] ([id])
GO
ALTER TABLE [dbo].[Produc_to_AvtoTechizat] CHECK CONSTRAINT [FK_Produc_to_AvtoTechizat_Products]
GO
ALTER TABLE [dbo].[Product_To_Image]  WITH CHECK ADD  CONSTRAINT [FK_Product_To_Image_AvtoParth] FOREIGN KEY([AvtoPartPhotoID])
REFERENCES [dbo].[AvtoParth] ([id])
GO
ALTER TABLE [dbo].[Product_To_Image] CHECK CONSTRAINT [FK_Product_To_Image_AvtoParth]
GO
ALTER TABLE [dbo].[Product_To_Image]  WITH CHECK ADD  CONSTRAINT [FK_Product_To_Image_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([id])
GO
ALTER TABLE [dbo].[Product_To_Image] CHECK CONSTRAINT [FK_Product_To_Image_Products]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Category]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Cities] FOREIGN KEY([CityID])
REFERENCES [dbo].[Cities] ([id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Cities]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_FuelType] FOREIGN KEY([FuelId])
REFERENCES [dbo].[FuelType] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_FuelType]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Model] FOREIGN KEY([ModelId])
REFERENCES [dbo].[Model] ([id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Model]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_MotorsCapacity] FOREIGN KEY([MotorCapacityId])
REFERENCES [dbo].[MotorsCapacity] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_MotorsCapacity]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_PriceType1] FOREIGN KEY([PriceTypeId])
REFERENCES [dbo].[PriceType] ([id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_PriceType1]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductColors] FOREIGN KEY([ColorId])
REFERENCES [dbo].[ProductColors] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductColors]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductType] FOREIGN KEY([ProductTypeID])
REFERENCES [dbo].[Transmission] ([id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductType]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_VIP] FOREIGN KEY([VIPid])
REFERENCES [dbo].[VIP] ([id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_VIP]
GO
ALTER TABLE [dbo].[Supply_To_Products]  WITH CHECK ADD  CONSTRAINT [FK_Supply_To_Products_CarSupply] FOREIGN KEY([CarSupplyId])
REFERENCES [dbo].[CarSupply] ([Id])
GO
ALTER TABLE [dbo].[Supply_To_Products] CHECK CONSTRAINT [FK_Supply_To_Products_CarSupply]
GO
ALTER TABLE [dbo].[Supply_To_Products]  WITH CHECK ADD  CONSTRAINT [FK_Supply_To_Products_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([id])
GO
ALTER TABLE [dbo].[Supply_To_Products] CHECK CONSTRAINT [FK_Supply_To_Products_Products]
GO
ALTER TABLE [dbo].[User_to_CellNumber]  WITH CHECK ADD  CONSTRAINT [FK_User_to_CellNumber_CellNumber] FOREIGN KEY([CellnumberId])
REFERENCES [dbo].[CellNumber] ([Id])
GO
ALTER TABLE [dbo].[User_to_CellNumber] CHECK CONSTRAINT [FK_User_to_CellNumber_CellNumber]
GO
ALTER TABLE [dbo].[User_to_CellNumber]  WITH CHECK ADD  CONSTRAINT [FK_User_to_CellNumber_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[User_to_CellNumber] CHECK CONSTRAINT [FK_User_to_CellNumber_Users]
GO
