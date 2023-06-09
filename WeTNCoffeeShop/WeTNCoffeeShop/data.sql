USE [master]
GO
/****** Object:  Database [CoffeeShop]    Script Date: 26/04/2023 15:54:03 ******/
CREATE DATABASE [CoffeeShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CoffeeShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CoffeeShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CoffeeShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CoffeeShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CoffeeShop] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CoffeeShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CoffeeShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CoffeeShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CoffeeShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CoffeeShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CoffeeShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [CoffeeShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CoffeeShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CoffeeShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CoffeeShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CoffeeShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CoffeeShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CoffeeShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CoffeeShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CoffeeShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CoffeeShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CoffeeShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CoffeeShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CoffeeShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CoffeeShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CoffeeShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CoffeeShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CoffeeShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CoffeeShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CoffeeShop] SET  MULTI_USER 
GO
ALTER DATABASE [CoffeeShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CoffeeShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CoffeeShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CoffeeShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CoffeeShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CoffeeShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CoffeeShop] SET QUERY_STORE = ON
GO
ALTER DATABASE [CoffeeShop] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CoffeeShop]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 26/04/2023 15:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Username] [varchar](20) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Role] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 26/04/2023 15:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[AreaID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 26/04/2023 15:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[BillID] [int] IDENTITY(1,1) NOT NULL,
	[NameProduct] [nvarchar](100) NOT NULL,
	[Quantity] [int] NOT NULL,
	[PercentSurcharge] [int] NOT NULL,
	[Amount] [bigint] NOT NULL,
	[ModeOfPayment] [int] NOT NULL,
	[NameOfWaiter] [nvarchar](100) NOT NULL,
	[Status] [int] NOT NULL,
	[DateCheckIn] [datetime] NOT NULL,
	[DateCheckOut] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[BillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 26/04/2023 15:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 26/04/2023 15:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[PhoneNumber] [bigint] NOT NULL,
	[NameOfCustomer] [nvarchar](100) NULL,
	[Points] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PhoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 26/04/2023 15:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[PerPrice] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statistic]    Script Date: 26/04/2023 15:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statistic](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[dateStaff] [datetime] NOT NULL,
	[nameOfProduct] [nvarchar](100) NOT NULL,
	[Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 26/04/2023 15:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[TableID] [int] IDENTITY(1,1) NOT NULL,
	[Status] [int] NOT NULL,
	[AreaID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountID], [Name], [Username], [Password], [Role]) VALUES (1, N'Nhân viên', N't', N't', 0)
INSERT [dbo].[Account] ([AccountID], [Name], [Username], [Password], [Role]) VALUES (2, N'Quản lý', N'n', N'n', 1)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Area] ON 

INSERT [dbo].[Area] ([AreaID], [Name]) VALUES (1, N'Khu vực dưới lầu')
INSERT [dbo].[Area] ([AreaID], [Name]) VALUES (2, N'Khu vực trên lầu')
INSERT [dbo].[Area] ([AreaID], [Name]) VALUES (3, N'Khu vực sân vườn')
SET IDENTITY_INSERT [dbo].[Area] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryID], [Name]) VALUES (1, N'Nước ngọt')
INSERT [dbo].[Category] ([CategoryID], [Name]) VALUES (2, N'Sinh tố')
INSERT [dbo].[Category] ([CategoryID], [Name]) VALUES (3, N'Trà sữa')
INSERT [dbo].[Category] ([CategoryID], [Name]) VALUES (4, N'Kem')
INSERT [dbo].[Category] ([CategoryID], [Name]) VALUES (5, N'Nước ép')
INSERT [dbo].[Category] ([CategoryID], [Name]) VALUES (6, N'Cà phê')
INSERT [dbo].[Category] ([CategoryID], [Name]) VALUES (7, N'Sữa chua')
INSERT [dbo].[Category] ([CategoryID], [Name]) VALUES (8, N'Trà trái cây')
INSERT [dbo].[Category] ([CategoryID], [Name]) VALUES (9, N'Bánh ngọt nhỏ')
INSERT [dbo].[Category] ([CategoryID], [Name]) VALUES (10, N'Freeze')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (1, 1, N'CocaCola', 10000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (2, 1, N'Pepsi', 10000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (3, 1, N'Nutriboots', 10000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (4, 1, N'Cam ép Twister', 10000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (5, 1, N'Bò húc', 15000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (6, 3, N'Trà sữa socola full topping', 25000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (7, 3, N'Trà sữa thái xanh full topping', 25000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (8, 3, N'Trà sữa khoai môn full topping', 25000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (9, 3, N'Trà sữa matcha full topping', 25000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (10, 3, N'Trà sữa kem trứng full topping', 25000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (11, 2, N'Sinh tố dưa hấu ', 20000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (12, 2, N'Sinh tố việt quất ', 20000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (13, 2, N'Sinh tố đá chanh', 20000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (14, 2, N'Sinh tố bơ', 20000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (15, 2, N'Sinh tố trái cây', 25000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (16, 4, N'Kem phô mai', 15000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (17, 4, N'Kem tươi', 12000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (18, 4, N'Kem bọc sữa trân châu', 25000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (19, 4, N'Kem mochi Nhật Bản', 30000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (20, 4, N'Kem socola bạc hà ', 25000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (21, 5, N'Nước ép cam', 20000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (22, 5, N'Nước ép dưa hấu', 20000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (23, 5, N'Nước ép trái cây', 25000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (24, 5, N'Nước ép dâu', 20000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (25, 5, N'Nước ép cà rốt', 15000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (26, 6, N'Cà phê đen đá ', 15000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (27, 6, N'Cà phê sữa đá ', 15000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (28, 6, N'Cà phê chanh muối', 25000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (29, 6, N'Cà phê trứng', 25000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (30, 6, N'Cappuccino', 30000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (31, 6, N'Espresso', 30000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (32, 6, N'Latte Macchiato', 30000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (33, 7, N'Sữa chua dâu', 20000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (34, 7, N'Sữa chua phúc bồn tử', 20000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (35, 7, N'Sữa chua việt quất', 20000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (36, 10, N'Freeze socola', 30000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (37, 10, N'Freeze trà xanh', 30000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (38, 10, N'Freeze sữa', 30000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (39, 7, N'Sữa chua chanh đá', 20000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (40, 7, N'Sữa chua chanh tuyết trân châu', 25000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (41, 9, N'Bánh rán Doraemon', 35000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (42, 9, N'Tiramisu socola nóng', 35000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (43, 9, N'Bánh Cupcake', 35000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (44, 9, N'Tiramisu việt quất mix cam', 35000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (45, 9, N'Bánh su kem', 35000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (46, 8, N'Trà bí đao', 25000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (47, 8, N'Trà đào cam sả', 25000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (48, 8, N'Trà dâu tằm', 25000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (49, 8, N'Trà chanh thái xanh', 25000)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [Name], [PerPrice]) VALUES (50, 8, N'Trà trái cây nhiệt đới', 25000)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Table] ON 

INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (1, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (2, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (3, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (4, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (5, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (6, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (7, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (8, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (9, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (10, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (11, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (12, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (13, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (14, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (15, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (16, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (17, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (18, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (19, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (20, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (21, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (22, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (23, 0, 2)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (24, 0, 2)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (25, 0, 2)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (26, 0, 2)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (27, 0, 2)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (28, 0, 2)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (29, 0, 2)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (30, 0, 2)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (31, 0, 2)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (32, 0, 2)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (33, 0, 3)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (34, 0, 3)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (35, 0, 3)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (36, 0, 3)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (37, 0, 3)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (38, 0, 3)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (39, 0, 3)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (40, 0, 3)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (41, 0, 3)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (42, 0, 3)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (43, 0, 3)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (44, 0, 3)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (45, 0, 3)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (46, 0, 3)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (47, 0, 3)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (48, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (49, 0, 1)
INSERT [dbo].[Table] ([TableID], [Status], [AreaID]) VALUES (50, 0, 1)
SET IDENTITY_INSERT [dbo].[Table] OFF
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [PercentSurcharge]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [DateCheckIn]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT (NULL) FOR [PhoneNumber]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT (NULL) FOR [NameOfCustomer]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ((0)) FOR [Points]
GO
ALTER TABLE [dbo].[Statistic] ADD  DEFAULT (getdate()) FOR [dateStaff]
GO
ALTER TABLE [dbo].[Statistic] ADD  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Table] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Table]  WITH CHECK ADD  CONSTRAINT [FK_Table_Area] FOREIGN KEY([AreaID])
REFERENCES [dbo].[Area] ([AreaID])
GO
ALTER TABLE [dbo].[Table] CHECK CONSTRAINT [FK_Table_Area]
GO
USE [master]
GO
ALTER DATABASE [CoffeeShop] SET  READ_WRITE 
GO
