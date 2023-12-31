USE [WashDb]
GO
/****** Object:  Table [dbo].[Dryings]    Script Date: 25.09.2021 21:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dryings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](4) NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Dryings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Powders]    Script Date: 25.09.2021 21:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Powders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Powders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 25.09.2021 21:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 25.09.2021 21:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MachineId] [int] NOT NULL,
	[PowderId] [int] NOT NULL,
	[DryingId] [int] NOT NULL,
	[StaffId] [int] NOT NULL,
	[IsStatus] [bit] NULL,
	[Code] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 25.09.2021 21:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Staffs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WashingMachines]    Script Date: 25.09.2021 21:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WashingMachines](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_WashingMachines] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Dryings] ON 

INSERT [dbo].[Dryings] ([Id], [Name], [Price]) VALUES (1, N'Да', 150.0000)
INSERT [dbo].[Dryings] ([Id], [Name], [Price]) VALUES (2, N'Нет', 0.0000)
SET IDENTITY_INSERT [dbo].[Dryings] OFF
GO
SET IDENTITY_INSERT [dbo].[Powders] ON 

INSERT [dbo].[Powders] ([Id], [Name], [Price]) VALUES (1, N'Tide', 35.0000)
INSERT [dbo].[Powders] ([Id], [Name], [Price]) VALUES (2, N'Ariel', 25.0000)
INSERT [dbo].[Powders] ([Id], [Name], [Price]) VALUES (3, N'Persil', 30.0000)
SET IDENTITY_INSERT [dbo].[Powders] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Сотрудник')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'Администратор')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([Id], [MachineId], [PowderId], [DryingId], [StaffId], [IsStatus], [Code]) VALUES (3, 2, 3, 1, 7, 1, N'0001-24-9-2021')
INSERT [dbo].[Services] ([Id], [MachineId], [PowderId], [DryingId], [StaffId], [IsStatus], [Code]) VALUES (4, 2, 3, 2, 7, 1, N'0002-24-9-2021')
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
SET IDENTITY_INSERT [dbo].[Staffs] ON 

INSERT [dbo].[Staffs] ([Id], [LastName], [FirstName], [MiddleName], [Login], [Password], [RoleId]) VALUES (2, N'Ковалёва', N'Алиса', N'Георгиевна', N'kag', N'skhegi', 1)
INSERT [dbo].[Staffs] ([Id], [LastName], [FirstName], [MiddleName], [Login], [Password], [RoleId]) VALUES (3, N'Гущина', N'Антонина', N'Матвеевна', N'gam', N'frowth', 1)
INSERT [dbo].[Staffs] ([Id], [LastName], [FirstName], [MiddleName], [Login], [Password], [RoleId]) VALUES (4, N'Панфилова', N'Юстина', N'Никитевна', N'pun', N'luasgm', 1)
INSERT [dbo].[Staffs] ([Id], [LastName], [FirstName], [MiddleName], [Login], [Password], [RoleId]) VALUES (5, N'Дроздова', N'Радмила', N'Станиславовна', N'drs', N'ntxjpw', 1)
INSERT [dbo].[Staffs] ([Id], [LastName], [FirstName], [MiddleName], [Login], [Password], [RoleId]) VALUES (6, N'Воронова', N'Юланта', N'Всеволодовна', N'vuv', N'irzsln', 1)
INSERT [dbo].[Staffs] ([Id], [LastName], [FirstName], [MiddleName], [Login], [Password], [RoleId]) VALUES (7, N'Орлова', N'Ксения', N'Петровна', N'oka', N'nxfvyl', 1)
INSERT [dbo].[Staffs] ([Id], [LastName], [FirstName], [MiddleName], [Login], [Password], [RoleId]) VALUES (8, N'Носкова', N'Дания', N'Петровна', N'ndp', N'bxqdpa', 2)
INSERT [dbo].[Staffs] ([Id], [LastName], [FirstName], [MiddleName], [Login], [Password], [RoleId]) VALUES (9, N'Кулагина', N'Александра', N'Якововна', N'kay', N'ilswvx', 1)
INSERT [dbo].[Staffs] ([Id], [LastName], [FirstName], [MiddleName], [Login], [Password], [RoleId]) VALUES (10, N'Некрасова', N'Мария', N'Лаврентьевна', N'nml', N'aimgut', 1)
INSERT [dbo].[Staffs] ([Id], [LastName], [FirstName], [MiddleName], [Login], [Password], [RoleId]) VALUES (11, N'Кулагина', N'Беатриса', N'Рудольфовна', N'kbr', N'sgnvmm', 1)
INSERT [dbo].[Staffs] ([Id], [LastName], [FirstName], [MiddleName], [Login], [Password], [RoleId]) VALUES (12, N'Беспалова', N'Жюли', N'Евсеевна', N'bge', N'nuexgq', 1)
INSERT [dbo].[Staffs] ([Id], [LastName], [FirstName], [MiddleName], [Login], [Password], [RoleId]) VALUES (13, N'123', N'123', N'123', N'123', N'123', 2)
INSERT [dbo].[Staffs] ([Id], [LastName], [FirstName], [MiddleName], [Login], [Password], [RoleId]) VALUES (14, N'345', N'345', N'345', N'345', N'345', 1)
SET IDENTITY_INSERT [dbo].[Staffs] OFF
GO
SET IDENTITY_INSERT [dbo].[WashingMachines] ON 

INSERT [dbo].[WashingMachines] ([Id], [Name], [Price]) VALUES (1, N'Стиральная машина №1', 250.0000)
INSERT [dbo].[WashingMachines] ([Id], [Name], [Price]) VALUES (2, N'Стиральная машина №2', 250.0000)
SET IDENTITY_INSERT [dbo].[WashingMachines] OFF
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_Dryings] FOREIGN KEY([DryingId])
REFERENCES [dbo].[Dryings] ([Id])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_Dryings]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_Powders] FOREIGN KEY([PowderId])
REFERENCES [dbo].[Powders] ([Id])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_Powders]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_Staffs] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Staffs] ([Id])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_Staffs]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_WashingMachines] FOREIGN KEY([MachineId])
REFERENCES [dbo].[WashingMachines] ([Id])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_WashingMachines]
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [FK_Staffs_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [FK_Staffs_Roles]
GO
USE [master]
GO
ALTER DATABASE [WashDb] SET  READ_WRITE 
GO
