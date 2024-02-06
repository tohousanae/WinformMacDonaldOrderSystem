USE [master]
GO
/****** Object:  Database [WecDonald's]    Script Date: 2024/2/6 上午 01:24:20 ******/
CREATE DATABASE [WecDonald's]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WecDonald''s', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\WecDonald''s.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WecDonald''s_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\WecDonald''s_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [WecDonald's] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WecDonald's].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WecDonald's] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WecDonald's] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WecDonald's] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WecDonald's] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WecDonald's] SET ARITHABORT OFF 
GO
ALTER DATABASE [WecDonald's] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WecDonald's] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WecDonald's] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WecDonald's] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WecDonald's] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WecDonald's] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WecDonald's] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WecDonald's] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WecDonald's] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WecDonald's] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WecDonald's] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WecDonald's] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WecDonald's] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WecDonald's] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WecDonald's] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WecDonald's] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WecDonald's] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WecDonald's] SET RECOVERY FULL 
GO
ALTER DATABASE [WecDonald's] SET  MULTI_USER 
GO
ALTER DATABASE [WecDonald's] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WecDonald's] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WecDonald's] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WecDonald's] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WecDonald's] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WecDonald's] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'WecDonald''s', N'ON'
GO
ALTER DATABASE [WecDonald's] SET QUERY_STORE = OFF
GO
USE [WecDonald's]
GO
/****** Object:  Table [dbo].[carts]    Script Date: 2024/2/6 上午 01:24:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[carts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[amount] [int] NOT NULL,
 CONSTRAINT [PK_ShoppingCart] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[food_plan]    Script Date: 2024/2/6 上午 01:24:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[food_plan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[用餐方式] [nvarchar](50) NULL,
 CONSTRAINT [PK_用餐方式] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[members]    Script Date: 2024/2/6 上午 01:24:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[members](
	[mId] [int] IDENTITY(1,1) NOT NULL,
	[mName] [nvarchar](50) NOT NULL,
	[mAddr] [nvarchar](100) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[birthday] [date] NOT NULL,
	[mTel] [nvarchar](100) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[permission] [int] NOT NULL,
	[points] [int] NOT NULL,
	[cash] [int] NOT NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[mId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderForm]    Script Date: 2024/2/6 上午 01:24:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderForm](
	[oNo] [int] IDENTITY(1,1) NOT NULL,
	[sNo] [int] NOT NULL,
	[dNo] [int] NULL,
	[oAddr] [nvarchar](100) NULL,
	[time] [datetime] NOT NULL,
	[oTel] [nvarchar](100) NOT NULL,
	[mId] [int] NOT NULL,
 CONSTRAINT [PK_OrderForm] PRIMARY KEY CLUSTERED 
(
	[oNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 2024/2/6 上午 01:24:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pname] [nvarchar](500) NULL,
	[price] [int] NULL,
	[pdesc] [nvarchar](500) NULL,
	[pimage] [nvarchar](500) NULL,
	[type] [int] NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[type]    Script Date: 2024/2/6 上午 01:24:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[typeName] [nvarchar](50) NULL,
 CONSTRAINT [PK_product_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[carts] ON 

INSERT [dbo].[carts] ([id], [user_id], [product_id], [amount]) VALUES (1, 1, 2, 5)
INSERT [dbo].[carts] ([id], [user_id], [product_id], [amount]) VALUES (2, 1, 2, 114514)
INSERT [dbo].[carts] ([id], [user_id], [product_id], [amount]) VALUES (3, 1, 1, 1)
INSERT [dbo].[carts] ([id], [user_id], [product_id], [amount]) VALUES (4, 1, 1, 2)
INSERT [dbo].[carts] ([id], [user_id], [product_id], [amount]) VALUES (5, 1, 1, 4)
INSERT [dbo].[carts] ([id], [user_id], [product_id], [amount]) VALUES (6, 1, 6, 9)
INSERT [dbo].[carts] ([id], [user_id], [product_id], [amount]) VALUES (7, 1, 6, 9)
INSERT [dbo].[carts] ([id], [user_id], [product_id], [amount]) VALUES (8, 1, 6, 9)
INSERT [dbo].[carts] ([id], [user_id], [product_id], [amount]) VALUES (9, 1, 6, 9)
INSERT [dbo].[carts] ([id], [user_id], [product_id], [amount]) VALUES (10, 1, 6, 10)
INSERT [dbo].[carts] ([id], [user_id], [product_id], [amount]) VALUES (11, 1, 1, 10)
INSERT [dbo].[carts] ([id], [user_id], [product_id], [amount]) VALUES (12, 1, 5, 10)
INSERT [dbo].[carts] ([id], [user_id], [product_id], [amount]) VALUES (13, 1, 3, 10)
INSERT [dbo].[carts] ([id], [user_id], [product_id], [amount]) VALUES (14, 1, 4, 10)
INSERT [dbo].[carts] ([id], [user_id], [product_id], [amount]) VALUES (15, 1, 2, 10)
INSERT [dbo].[carts] ([id], [user_id], [product_id], [amount]) VALUES (16, 1, 7, 10)
SET IDENTITY_INSERT [dbo].[carts] OFF
GO
SET IDENTITY_INSERT [dbo].[members] ON 

INSERT [dbo].[members] ([mId], [mName], [mAddr], [email], [birthday], [mTel], [password], [permission], [points], [cash]) VALUES (1, N'許雷神', N'下北澤', N'114514@gmail.com', CAST(N'1919-08-10' AS Date), N'0800696969', N'114514', 1000, 0, 0)
INSERT [dbo].[members] ([mId], [mName], [mAddr], [email], [birthday], [mTel], [password], [permission], [points], [cash]) VALUES (4, N'西行寺幽幽子', N'白玉樓', N'youmu@mail.com', CAST(N'1114-05-14' AS Date), N'0900111222', N'1919810', 1, 0, 0)
SET IDENTITY_INSERT [dbo].[members] OFF
GO
SET IDENTITY_INSERT [dbo].[products] ON 

INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (1, N'麥克鷄塊(6塊)', 69, N'大家都愛麥克鷄塊！

嚴選優質鷄肉， 以鷄胸和鷄腿黃金比例調配，並依照麥當勞全球產品規範，以天然澱粉取代雞肉中做為保水成分的合法食品添加物-磷酸鹽，讓美味更簡單！

口感外酥內軟，搭上經典醣醋醬， 酸酸甜甜越吃越順口；還有多款沾醬，讓吃法充滿樂趣，男女老少都愛吃！你呢？今天麥克鷄塊了嗎？', N'2402021544007948.png', 1)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (2, N'大麥克', 80, N'麥當勞永遠的一號餐， 全球狂熱50年， 紐澳100%雙層純牛肉， 淋上大麥克招牌醬料， 加上生菜、吉事、洋蔥、酸黃瓜， 美味層層堆疊，口感樂趣無窮。 從美國總統到素人都是鐵粉， 經濟學家還發明「大麥克指數」致敬，果然，只有大麥克，才是大麥克！', N'2402021546482152.png', 1)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (3, N'麥香雞', 45, N'清脆爽口新鮮生菜，外酥內嫩麥香鷄排，淋上特製醬料，通通夾進撒上芝麻顆粒的滿意麵包！熟悉的經典美味， 不只超值，更有品質。', N'2402021837083567.png', 1)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (4, N'勁辣雞腿堡', 80, N'整塊勁辣鷄腿排，未吃份量先得分。 滿滿生菜搭配特製美乃滋，口感豐富多層次。 芝麻漢堡蓋上去，一口咬下過足癮。 夠辣夠帶勁！意猶未盡、就是吃不膩。', N'2402021550592511.png', 1)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (5, N'原味麥脆鷄腿(2塊)', 125, N'炸雞，就要麥脆鷄。 獨一無二「黃金美味3要點」！ 麥當勞炸雞使用嚴選帶骨雞腿，堅持三道裹粉五道翻滾，表皮酥脆有層次！ 首創先烤後炸工法，高溫鎖住肉汁，給你嫩、脆、爽的好滋味！ 吃過了，你也會這樣說。', N'2402021552115880.png', 1)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (6, N'辣味麥脆鷄腿(2塊)', 125, N'炸雞加辣更夠味！麥當勞獨家「黃金美味3要點」，火辣的凱恩辣椒，搭配秘製炸雞辛香料，香辣夠味；使用嚴選優質雞腿，大口咬下超過癮；經歷先烤後炸工法，高溫鎖住肉汁，外脆內嫩又多汁的麥脆鷄，讓人一口接一口，欲罷不能！炸雞，就要麥脆鷄！', N'2402021554037061.png', 1)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (7, N'A經典配餐：中薯+$38冷/熱飲', 65, N'選這味！經典美味！ 不管搭配什麼主餐，就是薯條飲料才對味！ 這組紅遍全球的經典配餐，你，絕對不容錯過！', N'2402021600226673.png', 2)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (8, N'B清爽配餐：四季沙拉+$38冷/熱飲', 70, N'選這味！清爽解膩！ 新鮮的多彩蔬果，配餐就選最爽口的四季沙拉， 無負擔感受視覺與味覺的雙重饗宴！', N'2402021601501902.png', 2)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (9, N'C勁脆配餐：麥脆鷄腿一塊(棒腿或大腿)+$38冷/熱飲', 84, N'選這味！酥脆有味！ 獨家「黃金美味三要點」炸鷄，就要麥脆鷄！ 不只主餐能夠大口吃鷄腿！配餐也能選到爽度100%的麥脆鷄腿！選這味，滿足感百分百!', N'2402021604584325.png', 2)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (10, N'D炫冰配餐：OREO冰炫風®+小薯+$38冷/熱飲', 99, N'炫冰來襲！冰炫風加小薯，選這味，夏天吃最解熱，冬天吃最痛快！ 冰火交融的甜鹹風味只要嚐過，從此愛上！還有麥當勞最經典的薯條，整顆馬鈴薯切條製成， 口感紮實就是好吃！', N'2402021606005673.png', 2)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (11, N'E豪吃配餐：六塊麥克鷄塊+小薯+$38冷/熱飲', 99, N'選這味，豪吃3件組讓你超滿足！六塊麥克鷄塊， 100%嚴選健康優質鷄肉， 調配鷄胸和鷄腿黃金比例， 口感外酥內軟。搭配麥當勞最經典的薯條，滿足百分百，豪吃就是好吃！', N'2402021607435180.png', 2)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (12, N'F地瓜配餐：金黃地瓜條+$38元冷/熱飲', 81, N'選這味！在地經典滋味！嚴選台農57號地瓜，口感外脆內鬆軟，淡淡的地瓜香氣在嘴中散開，不論搭配什麼主餐都超適合，身為正港台灣人的你，絕對不能錯過的美味！', N'240202160853440.png', 2)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (13, N'薯條(中)', 50, N'下午想來點什麼~ 當然是麥當勞最經典的薯條。 使用整顆馬鈴薯切條製成， 口感紮實就是好吃！', N'2402021613445026.png', 3)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (15, N'薯條(小)', 40, N'下午想來點什麼~ 當然是麥當勞最經典的薯條。 使用整顆馬鈴薯切條製成， 口感紮實就是好吃！', N'2402021616152089.png', 3)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (16, N'薯條(大)', 66, N'下午想來點什麼~ 當然是麥當勞最經典的薯條。 使用整顆馬鈴薯切條製成， 口感紮實就是好吃！', N'240202161628979.png', 3)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (17, N'OREO冰炫風', 59, N'就是這味，大人小孩都愛！ 麥當勞經典濃郁的奶香冰淇淋， 攪入酥脆巧克力OREO脆片， 兩大人氣點心，交融轉出不敗甜品， 只要嚐過，從此愛上！', N'2402021617465708.png', 3)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (18, N'蛋捲冰淇淋', 18, N'麥當勞經典冰品 – 蛋捲冰淇淋， 綿密滑順的口感，加上濃郁奶香， 搭配酥脆餅乾杯，就是簡單又經典的完美組合。 每嚐一口，就會想起初次品嚐的開心！ 現在還有大蛋捲冰淇淋，份量更多、享受加倍！', N'2402021619079098.png', 3)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (19, N'可口可樂(小)', 33, N'清涼暢快的百年傳奇經典飲料，氣泡口感，買套餐必搭！', N'2402021626027754.png', 4)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (20, N'可口可樂(中)', 38, N'清涼暢快的百年傳奇經典飲料，氣泡口感，買套餐必搭！', N'2402021622143241.png', 4)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (21, N'檸檬風味紅茶 (冰)(小)', 33, N'以檸檬汁融合經典紅茶，廣受台灣消費者喜愛的檸檬風味紅茶，口味清爽超有Fu！', N'2402021625126192.png', 4)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (22, N'檸檬風味紅茶 (冰)(中)', 38, N'以檸檬汁融合經典紅茶，廣受台灣消費者喜愛的檸檬風味紅茶，口味清爽超有Fu！', N'2402021625248256.png', 4)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (23, N'雪碧(小)', 33, N'清新的口感 再加上淡淡的檸檬香氣， 搭配套餐沁涼解膩、舒爽解渴！', N'2402021627589293.png', 4)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (24, N'雪碧(中)', 38, N'清新的口感 再加上淡淡的檸檬香氣， 搭配套餐沁涼解膩、舒爽解渴！', N'2402021628153432.png', 4)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (25, N'無糖綠茶(冰)(小)', 35, N'多層次甘甜茶湯，給消費者最像現泡綠茶的口感，百分之百無香料、無糖、無熱量，輕鬆享受無負擔。', N'2402021829022062.png', 4)
INSERT [dbo].[products] ([id], [pname], [price], [pdesc], [pimage], [type]) VALUES (26, N'無糖綠茶(冰)(中)', 41, N'多層次甘甜茶湯，給消費者最像現泡綠茶的口感，百分之百無香料、無糖、無熱量，輕鬆享受無負擔。', N'2402021835332354.png', 4)
SET IDENTITY_INSERT [dbo].[products] OFF
GO
SET IDENTITY_INSERT [dbo].[type] ON 

INSERT [dbo].[type] ([id], [typeName]) VALUES (1, N'超值A區')
INSERT [dbo].[type] ([id], [typeName]) VALUES (2, N'超值B區')
INSERT [dbo].[type] ([id], [typeName]) VALUES (3, N'點心')
INSERT [dbo].[type] ([id], [typeName]) VALUES (4, N'飲料')
INSERT [dbo].[type] ([id], [typeName]) VALUES (5, N'1+1=50星級點A區')
INSERT [dbo].[type] ([id], [typeName]) VALUES (6, N'1+1=50星級點B區')
SET IDENTITY_INSERT [dbo].[type] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Member]    Script Date: 2024/2/6 上午 01:24:20 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Member] ON [dbo].[members]
(
	[mName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[carts]  WITH CHECK ADD  CONSTRAINT [FK_carts_members] FOREIGN KEY([user_id])
REFERENCES [dbo].[members] ([mId])
GO
ALTER TABLE [dbo].[carts] CHECK CONSTRAINT [FK_carts_members]
GO
ALTER TABLE [dbo].[carts]  WITH CHECK ADD  CONSTRAINT [FK_carts_products] FOREIGN KEY([product_id])
REFERENCES [dbo].[products] ([id])
GO
ALTER TABLE [dbo].[carts] CHECK CONSTRAINT [FK_carts_products]
GO
ALTER TABLE [dbo].[OrderForm]  WITH CHECK ADD  CONSTRAINT [FK_OrderForm_members] FOREIGN KEY([mId])
REFERENCES [dbo].[members] ([mId])
GO
ALTER TABLE [dbo].[OrderForm] CHECK CONSTRAINT [FK_OrderForm_members]
GO
ALTER TABLE [dbo].[products]  WITH CHECK ADD  CONSTRAINT [FK_products_type] FOREIGN KEY([type])
REFERENCES [dbo].[type] ([id])
GO
ALTER TABLE [dbo].[products] CHECK CONSTRAINT [FK_products_type]
GO
USE [master]
GO
ALTER DATABASE [WecDonald's] SET  READ_WRITE 
GO
