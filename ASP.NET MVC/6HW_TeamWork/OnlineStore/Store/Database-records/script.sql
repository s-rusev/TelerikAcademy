USE [master]
GO
/****** Object:  Database [Store]    Script Date: 10/1/2013 5:24:01 PM ******/
CREATE DATABASE [Store]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Store', FILENAME = N'C:\Users\Subo Rusev\Store.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Store_log', FILENAME = N'C:\Users\Subo Rusev\Store_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Store] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Store].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Store] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Store] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Store] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Store] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Store] SET ARITHABORT OFF 
GO
ALTER DATABASE [Store] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Store] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Store] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Store] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Store] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Store] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Store] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Store] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Store] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Store] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Store] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Store] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Store] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Store] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Store] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Store] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Store] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Store] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Store] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Store] SET  MULTI_USER 
GO
ALTER DATABASE [Store] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Store] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Store] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Store] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Store]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 10/1/2013 5:24:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 10/1/2013 5:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetTokens]    Script Date: 10/1/2013 5:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetTokens](
	[Id] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
	[ValidUntilUtc] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetTokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 10/1/2013 5:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Key] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 10/1/2013 5:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserManagement]    Script Date: 10/1/2013 5:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserManagement](
	[UserId] [nvarchar](128) NOT NULL,
	[DisableSignIn] [bit] NOT NULL,
	[LastSignInTimeUtc] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserManagement] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 10/1/2013 5:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[RoleId] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 10/1/2013 5:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[PhotoPath] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserSecrets]    Script Date: 10/1/2013 5:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserSecrets](
	[UserName] [nvarchar](128) NOT NULL,
	[Secret] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserSecrets] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 10/1/2013 5:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Parent_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderedProducts]    Script Date: 10/1/2013 5:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderedProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.OrderedProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 10/1/2013 5:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Notes] [nvarchar](500) NULL,
	[OrderStatus] [int] NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 10/1/2013 5:24:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Price] [float] NOT NULL,
	[Stock] [int] NOT NULL,
	[PhotosFolderPath] [nvarchar](max) NULL,
	[Discount] [float] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201310010925040_AutomaticMigration', N'Store.Data.Migrations.Configuration', 0x1F8B0800000000000400ED5DD96EDC38167D1FA0FFA1504FDD03B4CB76304077607723B1E38131F18254D2AF012DD165A1B5D448AAC0FEB679984F9A5F1852A2242E9714492D550EFA252873B9BC1BAFC84BF2E47FFFF9EFD9EFCF49BCF886F322CAD2F3E5C9D1F17281D3200BA37473BEDC958F3FFFB2FCFDB71FFE76F6214C9E177F34EDDED076A4675A9C2F9FCA72FB76B52A82279CA0E22889823C2BB2C7F228C892150AB3D5E9F1F1AFAB93931526249684D66271F66997965182AB3FC89F17591AE06DB943F14D16E2B860E5A4665D515DDCA204175B14E0F3E5BACC727C74894AB45CBC8B23443858E3F871B940699A95A824FCBDFD52E0759967E966BD250528FEFCB2C5A4DD238A0BCCF87EDB35B715E1F8948AB0EA3A7AA960D90A47C4FB40D450BE50F62A11CF9717A8C49B2C7FE15B9176FFC22F420129BACFB32DCECB974FF891F5BD0E978B95D86F25776CBB717DE8F0E4575ABE395D2E6E77718C1E62DC6A8B536BA5FA7FE214E784CBF01E9525CE534A03576228A34B63D17F9BD1887988872D1737E8F9234E37E5D3F9F21FC4A5AEA2671C36058C812F6944FC91F429F31D06189406BD45DFA24DC5AF34FC3DCA099FCBC5271C57D5C553B4AD7DE7A8D1FAD7A6CD559E259FB2983308ABFABACE767940C5C8E0FACF28DFE0D281AB3C0B774159807CB1CAAFAD57708CC975EDC80D674A8386759EB5B355E78246C764D4FEF24B5FBF9406BDC4459047DB3A8C18C69E64F0FB3C0A5A912FB31DE9E94C83283DF8B3CF483D6C3C6565565C6571887362B5278322C84F2B45F4283D2A826C4727F820D19B19D5EFA4B651A09BE043A3801C9FB461C22B0ADCE5C454DF630C20EB896E4290DF9FA3C4DD2F6EB3121723CC66F328950DD644EC5D37167513A1DC9173B260CA3B7503AC9F9CFE32F1D7D9F41DAC44FBDA35E9FC5FAC51BC5FAA76FD3853B51818AAAB656668A98691AA6AD004ACDCBC1EF73D2A3067FEAAB03FDCCE12673F24288A4718C5E84DD63AA39AF9986DA2D42770551D49F1B788463E496EB047D39890778F79D27093CF47751676BCCF3DF8684168F0F4AEE669650A21D870C5CA6A9BAF1BB4D006E6F10C5FD879ADDCB3E2F60C425A3B3796F4B3B41CCA212FB0E5E406A5688313DD3E9492EE9A28DF17A01AF443B90DE48F262E2925BDBA682DC85A5B0132D5D50E9E1E9C163D264A13665C27CB6C6B2475D3425BAFA34D7ADDEE15DF67449D287526F61115654D89AE70BF9481FBA2D72F9C3ABA3534E974AEEFED4794B48F07D17EAA078DEA6CCD10AFF61BECED459551202F6A03080B4F9D0389354AF491AA5DA3A1D1AD2D8221E4CA6AA8F472625F077E2D6B8599D7099C730DF13FD9E01AF7F4B2F8E7EC4FECB58F792D26FF03C5BB096CAE8E12855F887263F74FA0D327E6224651E2632FAFDDE377B56D9353A45493748CC99DA31A69223FF4FBCA541C819F99AE06FCCE70D583574B6B1CE4D87BC55D87729F3577CF476022AF66D28EEB007A7DEF1239CBDE6472AF8BAB186D0A8E3CA98C5F083B7C6E5C94E506270F386FA86DC9176351F933D19622B7D0F63EC7695849CADA9F9ADB5F4569543CE1B06DFF4615B8168D2F7C57145910558E2E9D7F3407B0E2901FD270D1731ADBE541BB53929B5D5C46DB380A88C6CF977F5724D1936D5790FD648F8F8E4E649939F9CC622B273B3A06F5C73C1D87CD09AD83DCFA33E47EC14F96F2C4BF4B2F718C4BBC7817D4D72A2E5011A01098F68403B184C40A4C351FA1F88244BF3247515AAA81254A83688BE21EEEA57E96CB21CA573B825C7389C924A247493DF6B0199A3F3D545968479254D6A72107AF934E5374CEA13B5A914E9CFA2784892AE070767EEC202F9FE3D3B10526FCA4C3153741C164B148B13E94E89DAF5E93031068867901086D332A9C2599693A40D9299351B5A92AD1B87CAAD7D971B4595EB34BAA64BD7D47C3C14C3EA4D1F1C1FB929423D099589730E8AC5B67C126FCE26A99D1B81AC4D048A10AD6C60C9E064B6E33B036033C57C0EAF28EA6300224217DACAA236A1D95F6BD5204D99E2994293638F820C65D6E31AFE2749E05AE0B4D6E05DC8EE1C871775E0ECDB154C667F02A55F907EF525212CB145EA08C96185FEA9CAA63D40232613EEB7BEFF0A38E3F53FC51F57960DE52A7C4489F92F468334BD5A4A7AF3C68057E565342B4D31A97E2A63AA207335D8E4D4961282E2252E96E182A34DA5D690F896A7242045850ECE9DE6E0B2112DC9ED1828C8E8255677EF70252E11B58D063676620A97A11D2434447C0AA73756A06F5AE8FD36C04A8A6914E0216912CC8D469651D9D26E92C11E2268EE2F1DD9B15AE95E6598B3C97FBF3AAAD08E20C53A2427F2AD58A921023485B0B35A897E3553D98D3AC7689568EFF2E4A18F4A04DAD4EA508F98EB4AA0653DECF26F3C771DE4439830234893E0B3D7A082F5CE35325D766007B73801CBB2CA61A4486527E128186C7512456EE54C1921B935BD6E92D49107DFCB74E66F5E9D6432BF21D0D5521A60C8D4D8E86639A8D61905E935A910407E978BA04771F0976064DE2C0227560C3B545B26002ABF3AF317461AF47646043EB13EEA69654BE0C00DB58B7D3B2D96B494C37CB9E1E3303BBAB01D237C7E4ED9EA0AD3B5BD50FC259C1D94AF372FCEC066DB751BAE15E92B392C5BA7E467EF1F3DAFDF97652D3580542E0907730ED48640B43029F544B86269C5E457951D2EDCD03A287FA1761A234B3DD0135C3291B21D564CD92B3E9427F73DBADEA55FD916E95D4E9F08A8845C379252156173440D7057DCA8F62940357CC2EB27897A4FA0DAFBE777D3584EF0F5D33A93D45E25DD9D72ADA511246A2BEADAC61586C59D9027C756D650A6DCF7D5B4247417810CD13122AECE9B137CE3C2556644F83BD71E669B022073E9447CE024B4AAD83C6DAD7CC82BADA527B4AFC95049E96E9AAC2DEE614FB187BCE28E00573D5BD6F3E69FA4D339BEAD7C88255AB1287F9583F451626645D644F43B886C653122AECE93539459E942ECFB837EFAAD72A9ECED59D54B83B18DC6D1AFFE25E022BC1C8350AB1B7BE3C1D5604D2208B9930AA4E06D88D41EE74470E637994442922F553F8478F55AF0BFAFBEEF147CEBC94CB9F0EDCB4DD8D59799A4DB534B29F1E873533144FDC83130E0852DA7496B5298037F1D6F6D0F4D519457AD6CEEBB8E781BD9EA6F0565D5CE6691FE09BE8BD9ACF93EEF9AB9BF5F5542C5DC044601C1D1B16BEFC8B5869C6F255F6348187B18297AAD507E513BA6CA6B53BA84F09AD1D01EEAA537473758AD7AEEE3AD5588EB427C30C328AA741DC8CF19DA75FD8B9AFA70580B7965626D0F49BC606EC9D1A4F801539D1E05F434AB4F8AA83B12C979B1E10F480D799561636F4D5E95859A54CBA3AD1267ABA4794429EA72B76A405B81F5F7E50FED2DCBD18E030D01B486B8FD1751E6F2BA7CD63B27B25422213BC6B328789C4731FF0F8A2BBD5623CA2685BD91E44D0632B4DEE53BAB0A26AC52A783322F0D5396E7077BEB497F7BC3F2A4686BADDF175419FCEB6EF4FADA4950FF79CFD40BECDA2CFE5728D2CCF400065C3375E3C755D131BC105E02B3407E5013A59FB1D4039E4959BB4618895B47FB787BCEC80B51F335C3971AD9B2C174DAA80B8D54B51E284A571FF1D5FC45115589A0664B31B3DE2A2ACD676E7CBD3E39353097EDC030A7C5514617CA878E0511B574DA8AA03005DD26F280F9E50AE802DBB6216764188E3BC23E2F20C5FD23E1840FE52BEEED4D648DAC3B03C4AF5639CA1721848B5E4178320AA1B217F4CD0F34F666F039426C150FBC9A6A250FB08D805F0B127CF9EB0A227993A3C3C74487E9783E1A16D6689271AB48F1B345B49037315D0CA78C848F37B86A754B0B2A060EA150C1454E641D404E4E5C1418A3BFB9ACF315E3554F3683E76AF22318FEABF6ED362C067C07454342760EB68DA03F1581F22F798ABC562B5FCC27C9F58A77BF4F2213ADE0F14E768CAF2FC9C1D3A6EE568FA11E000077D5741E8C92966FCDEA0270FEA3B05EC9B6420C941E654C122A7983EBAE383B9F1174733AD08AF3882CA86630A7AC2FD81B4EA94A005BD9120740C6F366C42EAC205544090D1663CE399C80CE013F7B6288B4E9E30111A539372F442763C78DFD1BF6751877A553889837111E7B7BBEE25C45E8D6E3A3B9B09A7C6062A720C704886E401E37B4C86093917EC8CEE72B1EDB6714683BB803F7A4030EA1EC30F458C3C781730DE303E303F70006EDC174E63079503E2E74C06CD382750DEF704BE382F2EE27EFD64CEB062ED277B0D2816208AFB7412CB45EB2B730FFB25EDDE171D966888632C34193A198C59F6AAED6DBAC3BD579B4B57DB9A1DAD02FC219B4D048CEB520F5DCE4BC94AD457D9CE97E143466C5CA7CD0CC062F218ED1E5319A2AD8146B8D76177C9F4595851A8B37288368CB603C2E969210E21BAEF8AED2D2E61301A8838DB8A8123B03AF3301AB02F682C27BC45F3A81EC88C466046F3683078953C906690BE01EC88331047853A2BD7936F60212DB4C4A225A8265667D6130CA464C088EC8188348FD6C24C4AC3CD872409011D020F5EB4B9738BDEFB478BF417560ABBC275F5E1628E8D05A982A1ED51383E473708EB51C128330AA57C11A4B7F0E3083609A4A3BBA0EAE7C802F871FF788D0A3C63AFA04AAFAE70147B8E86C7E86EC329451B0171D15D28CB50B47F5845775B09CB0BE989A9BD780EB889EAD319B2DBD9A5F40E4AFDD7252EA24D4782BE064A7120EC73DA36D7E963D66CB7248E9A26D2F1FF0D2E51483641EFF2327A444149AA035C14FCFF3CF82179C0E1757AB72BB7BB92888C938758F8A6D26D9B69FC0A1C52E4F9ECAE7AA9508C2142758F877CEAEFD2F7BB28EEFE07C42BE0DA8E8604DD0FB24BEAD49625BDACBE796929DD66A92521A6BE761BFB1927DB98102BEED235FA86F5BCF5EB50D4D8D9658436394A0A46A3EB4FFE24EE1726CFBFFD1F2326F06656920000, N'6.0.0-rc1-20726')
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201310011423262_AutomaticMigration', N'Store.Data.Migrations.Configuration', 0x1F8B0800000000000400ED5DCD6EDC3812BE2FB0EFD0E8D3CC02E3B63D586036B06790D8F1C2D8F807E964AE01ADA6DBC2E8A7575207F6B3ED611F695F6129899228B28A22A9BFB63197A42D924556D5C722594595FEF79FFF9EFDF61C068BEF3449FD383A5F9E1C1D2F1734F2E28D1F6DCF97FBECF1A75F96BFFDFAD7BF9C7DDC84CF8BDFAB7A3FE7F558CB283D5F3E65D9EEDD6A957A4F3424E951E87B499CC68FD99117872BB28957A7C7C7FF589D9CAC2823B164B4168BB3CFFB28F3435AFCC1FEBC88238FEEB23D096EE20D0D52FE9C95AC0BAA8B5B12D274473C7ABE5C6771428F2E4946968BF7814FD808D634785C2E4814C519C9D8F8DE7D4DE93A4BE268BBDEB10724F8F2B2A3ACDE230952CAC7FDAEA96ECAC2F169CEC2AA69E8248265CD1C63EF231343F6920FAF60F17C794132BA8D9317B116ABF72FFAD27AC01EDD27F18E26D9CB67FAC8DB5E6F968B55BBDD4A6E583713DAE4DDB35F51F6F3E97271BB0F02F210D05A5A82580BD1FF93463461A3DCDC932CA34994D3A0051B4AEF525FF9BF556F4C3D0C61CBC50D79FE44A36DF674BEFC3B83D495FF4C37D5033E80AF91CFF0C8DA64C99E0203943ABD25DFFD6D315EA9FB7B92B0712E179F695014A74FFEAEC4CE5125F56F559DAB240E3FC781A0105EF46D1DEF132F672386CBBF90644B338B5125F166EF6529382E5EF8AD46853030B9ACEEB91A9952A11ABA38B4B35503412D3039B53F71E98A4BA9D34B9A7A89BF2BCD88A6EF513ABF4F7CAF66F932DEB396D63498D0BD3FBA94D4318CA7388BD3AB38D8D08469ED492308F6D348101D42F7532FDEE713BC17EBD58CEA06A9A9156826785F2B20DB27D44C385981BB84A9EA2DDA00B69F682604FBFDC50FED71711B67341D6036EB7B2974B0666CEF9BBE7298B49E5B8E9C6D989246DCC0D04F4E7F1977752E46CF14A75B0EDB75BE956014260354AE2C8B60256869D48D3697173EC46F65B134B0E2A9323F85A2FE33B366EB2D4E51CE9AB5D18580369CE5E6201C0AAD203C30485BEE314D46595745C759FDDF31D2EAFF5EA02E10534EA60F24A582B12B1E766F2E26D9557C0C891F0CD08B1683C632CB25F329DEFA918B0D281AB2C7DFFD02ACABEE16556546DEDE7C48DD8DBEFAA8F3A219FBD49D0FB6E4F65EB38AC5A750452ACE7BE1B1B2888A65BD8E95C03C9E60B19A56CB1DE74B472384EAB9D2A49BA665B30EA1C074243724225B1A625E979C745345D93401C5200EE53AB67BB99C122EAEBC141C5A5D000EAA29ED3D3D04293A4C94CACCD84E96C94E04EA113DAFBDF6B7D175ED19F910337192C89AD827926625A5FC3CF735F3EC8F786EE6D412D6D0A4C3A0EF8CA39CB40B82F2762A8206055BD5C5AB5D839D5154280542516D40B8796A00D42E51AC8F543CD8C9D6D0184250564DA513885D01FC5AF60A13EF130470F5C19FAC70049E4E1AFF12FF419DCE31AF45E5BF93603F82CED55EFCCD5726DCC07E09B45A622E02E2872EFA723A3DBEA9639B1C10C82599F7313A388A9E46C2A1DB2A538C085C669A12709D118A7BEF96D6D44BA8F38EBB34E52E7BEE8E45602454736E8705002EEF7D287BAEABB8C5757A15906D2A906785C10B1B8EE8AE6DF37243C3079A54D4766CC558147866D252F86ED5BD4F68B42938E5F54FF5F5AFFCC84F9FE8A6AEFFB3CA70C99AF8F07D9AC69E5F005D8AF655D70DDA5D7E8C368B8EBB078D1FB48909DEEC83CCDF05BEC7247EBEFC9BC2094EB6DE4176933D3E3A3A917916F8D3B3ADC431B101E241CD6684B5A3DA9C6FFCC64437E3274B79E2DF459734A0195DBCF7CA4B441724F5C80698F66C04ED27CC56D05CF23E092E98F5CB12E247996A58FCC8F37724E818BDD4CE703B948FABEE412EB9A46C12E551990E7D98742DC6CAD521D43D4922EB929005EAC0300C06117D4C468AB536D1360B10EA6394520F878742DDF02740A24E3F26DDD7C1BF4380221CAB45A1A204DE4680A31CB5EB36B80707498985E94129E9C9640042687B16608A71010C296090400AC876EE16508A00E09A4066279E9D70033034015800A64D7A853DAB13C243F668EB948ABAB7DBCA15C343D6C04123437A48AA649DB1838C60220C21323E782C497E454CC59893B1D16EE9391F7131420783400D1AD040A60A96C60448833937E9188D1A4D65B09A5885CE8C00810B17AD62448DADD2DC9B2870D81399324507076FC4845B9EDA8D358A2CF074D7B94F473125DC933B3460A9039F6A47FEBA202539BE75E605F282B7ED4B1987B1B45A80F7DC657FEF6C7ED4FE27B23FAA3C0F0C2DA51B9DB5C9588BDA1B5D4CFAFC3DC8BC803EAB7E84BCD19A666D479C9F07731BBFBCE2F65420D2A6D2DCCF5768D40E820E12C5E4840870A368D25C7C5100A62378433A08D6E74C8896700835208351306A2C1E87402A6205037A3C700F922A77351D443002468D8BD03DD4BA8CE99B3050CC4B8C036EE20CC894B12D8C4E15F992080933519942CD6BA2422DE44D52D9387407776A16DA53563133DDF11C234A2DA3C3EA1A88417D1F4D95833ED6B3D08665004934B35D230734BE339620E0373C5461748720CC8310022F8A25D4C8461B7690698E209BDA18774A07F48ADBF8C5879190EC093700A383945A17B255D1A07ED94ECFAC305CBE306958871CB112816A8C8370ACDC8E8539D7BA1C8D9D8E1223F8226AEC62EC92AD8354E4DB76AA40747E3313CF993068DE87867BC4E125310ED271848470B3140603E2CE3170E8988CDAC0853382D6C5974511BBD8C532E066E8B4E65D8E85113895AF75C13AC6CEBF26276069D0D5DEB143CDC099B707F7D585A7FAA456979DADCA4436FCC1D90AC978737643763B3FDA0A1970F893C5BA4C7F73F1D3DA3EED4C58D258792DC3219F2BEB9ED8C192193EA99475CD467AE52769961F3A1F487E3DEB62132AD54CCFA55577CAF1545559B56FAF9AE4BF854370910DE808DB6A3632BC626CE5E6BCE090AABB42A0E9224F414402920097852FE2601F46B81B026F5D5EF213DB4317064BA4486357BC0D8A7414375E5BDE46DAA8B7388EBA40367106AA405BCEAD098C422B918B48A855604E8FE7661129F147E634786E1691067F64310E25394B6B484AA985C4EA2C2C2D71D54FCD298997CB445ABA4B67B3CD29BE183BCE28F0D068309F9076E3CCA6328B4A4BABC5138BF958A650694DC8F291398DD685629152ABC09C5EE5E9154961DEDF79D1251C75FBC00C492352D031C29B86C038C0132E50B50D277AAFAA033E3225F4E2E06C0A2F37A78E6A6E0286F61A869B8DA4D7268987B2FAD82E3B3C4D8748873F0269B0DDEBC62F0274FCB2BF106495D7ADC40FFD88B0F231F0D1A1D5EB34FF7DF7F883A0DE7C943F1EB86A9B975D64BB3AD65ED87C7A1CD6CC50903803087B1829D47F69AC0A209D8DB13E90B69852A48C34A28C3B72E3E034EFC53433D2F284E5CED1D17B15FB11C9D7DA43FB38154308E8080C2363CD49474C6621CD58B1C89C2690D3A28552B5F8A03081B9AF8DE1A06601300602DC141374758351942E76AB712820CDA4985E4A7154889D32DEB8BF8DDF9670D4009026C1480548BB7174C05F311709F0475634C44406122DB1E860342B04237A183D20B1829186356D31192BBB94517727A867AFC97FD072EC358F2D6901F0139F1F145EAA1B4B3D0003A52F30460CD678B8A31CEAB8E6B7B15A9E6BF086D6142A6A07FAC0785573174C1B93AA6B99469EF23825E2EC96AE79A9523132DE9C087C8355E8DC7E5CE81D5AE745453BA0E6747C9DE6592FEAD41146DCCAD15C15074A5057AE52A3903FA9FFAE83BA3CA0DAFD6D1325C25A56592EAA932203D74B9AD1907BF1FE1D5C047E81ABAA023BEBF88F34CD8AA5FD7C797A7C722A7D26C5E19325AB34DD0487FADD12BF9E56BAD4D23D527145DF49E23D9144F928846DB6D90683C2C81B2236095424E9C36F92FF297C244AAB25EDA058F16B1A8F414C32FBFC3BE2C734245CF4FA9446C5E40F2179FE518F364068D2E732DC7853BF96D1CDE0A17F906214DC8BDFA0D8B0DF59EF6F509840DCF193132E20AD8E019AC115F9AD0684C68C5F441805234244D35D0FD22710069C8EC0BB6B1348DA11493040A1D5C7C97A2A1F20E845ADF59181DE565D88154D33199150CCEBF92AC16018BB573F3A30287EEDA6458F4DA72EB432656EF2C1A407A61E7FF0EDED2B9A76DC70557F9B69BD6744791F19CF93757A3061392E67879EA27930F9B432DFF65A57C12CCB63CCF8D9B22C1FD43A051C34E59CC9BDD4A9E6451E63FA60EEF6A9530D0FA6DA7626E10144D63F7DAE63665B9056E94335A03750E627CD4B2D26267561930BA3C5A3497FDA18C2043953EE4D130A5B2161A42462951FC22989F1C16307BF30AE76F50A53024F9C9A177B2BBD57D257F7F44DD327517D7BC97C2DA6FF1B85928D6AA70793E65591834AC13B44D25D9ED048223476AEDDA9D27961B7C54DFD1A132ADC26A9AE436A5B2C9D45DF4CBC070F01ED95F103C3814542DCB9F2DF3619C324DC8C9CF276CA04A46F29A9EDB4F966E7C5C99466C51827B31A1483E4B47382C4F03CF5CAE0617E4E9A7DD361986576888D264FD2281132CC4E7BD0FAD65DCA9F55E7D265D5CAE5A2A4EE91D5D6CE9BD9F8C61AA7ACE2362B2FA79E2F370F31D371E9D7D5E45794FBA84F9B4A177509D4C33D967D4FA6CFCD8A429D3F876823D90F41CAC27119EE42A880F685E726045399A2E965A10EDEA7BB5B9AC139AC20E2FCFC07F6C0CBF4DD203902A1BEAC72DDEA7B75C88AAB4D8AABEF0DCE7927778474D2D58119719E4057A1CE9FE3E4AB94BC0652E2261A14132FD3CB09CEBFA6C9CFDB919E57DF5B9DE257EA6EBA2CBE509259E0B52934A264D07AFE4CBDEECC4AA6B295E9AB3F9B63E6E155F3296A198597062833CEE06CD7840748B16BA1AFD9D8173DA6BD72E72A391FB52C2A4BA5946A6218C64649916BCFA8BA4E1B24D29D3FFFAD92EEB69351A555F370107D0E96DFD65E8763B23640065B7BA60CEDF2FC696AED75D5DA77496F709BB3679187567D35919D3DF7517E65ADFCEB92A6FEB62191BF6E1951AF75EAACEB5C478F7175F895465455916E0BDDD08C6CD891F47D92F98FC4CB58B147D354FC26F7C7F0816EAEA3BB7DB6DB678C651A3E04ADCD467E88D6F55F24DB6D8FF9ECAE78132C1D8285E2DA1FDB03DD451FF67ED07C1BFC0AB8E58790C84FE7FC1D915C9759FEAEC8F6A5A6741B478684B8F86AA7C2171AEE02462CBD8BD6E43BC5C7D62DC3B6C4CE2E7DB24D4898721A4D7BF62783DF267CFEF5FF1A4210D95EA00000, N'6.0.0-rc1-20726')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bc74952c-3f91-4ee6-9d47-489394a4466b', N'Administrator')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd72836f9-bcf8-4305-af34-eef524b2ef95', N'User')
INSERT [dbo].[AspNetUserLogins] ([LoginProvider], [ProviderKey], [UserId]) VALUES (N'Local', N'pesho1', N'fbe0323b-6873-4b09-bc9a-ee74c7cfd60c')
INSERT [dbo].[AspNetUserManagement] ([UserId], [DisableSignIn], [LastSignInTimeUtc]) VALUES (N'fbe0323b-6873-4b09-bc9a-ee74c7cfd60c', 0, CAST(0x0000A24A00C2445C AS DateTime))
INSERT [dbo].[AspNetUserRoles] ([RoleId], [UserId]) VALUES (N'bc74952c-3f91-4ee6-9d47-489394a4466b', N'83850763-8f8b-46f3-9de3-165be9cc76ea')
INSERT [dbo].[AspNetUserRoles] ([RoleId], [UserId]) VALUES (N'd72836f9-bcf8-4305-af34-eef524b2ef95', N'fbe0323b-6873-4b09-bc9a-ee74c7cfd60c')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PhotoPath], [Email], [Discriminator]) VALUES (N'83850763-8f8b-46f3-9de3-165be9cc76ea', N'globaladmin', N'~/img/Default/global-admin.jpg', N'gloabladmin@admins.ad', N'StoreUser')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PhotoPath], [Email], [Discriminator]) VALUES (N'fbe0323b-6873-4b09-bc9a-ee74c7cfd60c', N'pesho1', NULL, N'www.pesho@abv.bg', N'StoreUser')
INSERT [dbo].[AspNetUserSecrets] ([UserName], [Secret]) VALUES (N'globaladmin', N'AJ7dKvwD0zhfjHagtewMtmLI7qtj5SSIRtaqCKDLFbdUPEoPhCAOHT32b5pTCqhWmA==')
INSERT [dbo].[AspNetUserSecrets] ([UserName], [Secret]) VALUES (N'pesho1', N'AAQGQOI5qozidrEoC4vdlsIe9lFTIsWM1iY8ruTDpdqC464wO7IqB9YLdNZ9myBLJw==')
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [Parent_Id]) VALUES (1, N'Clothes', NULL)
INSERT [dbo].[Categories] ([Id], [Name], [Parent_Id]) VALUES (7, N'Foods', NULL)
INSERT [dbo].[Categories] ([Id], [Name], [Parent_Id]) VALUES (8, N'Drinks', NULL)
INSERT [dbo].[Categories] ([Id], [Name], [Parent_Id]) VALUES (9, N'Technology', NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [Stock], [PhotosFolderPath], [Discount], [CategoryId]) VALUES (3, N'Dress', N'A simple dress', 20, 20, NULL, 0.5, 1)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [Stock], [PhotosFolderPath], [Discount], [CategoryId]) VALUES (4, N'Shirt', N'A blue shirt', 10, 25, NULL, 0.1, 1)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [Stock], [PhotosFolderPath], [Discount], [CategoryId]) VALUES (5, N'Jeans', N'Sample jeans', 30, 15, NULL, 0.1, 1)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [Stock], [PhotosFolderPath], [Discount], [CategoryId]) VALUES (6, N'Acer v3', N'Awesome laptop', 1500, 5, NULL, 0.5, 9)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [Stock], [PhotosFolderPath], [Discount], [CategoryId]) VALUES (7, N'MacBook', N'Laptop for rich men', 3500, 2, NULL, 0, 9)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [Stock], [PhotosFolderPath], [Discount], [CategoryId]) VALUES (8, N'Sandwich', N'Delicious sandwich', 2, 100, NULL, 0, 7)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [Stock], [PhotosFolderPath], [Discount], [CategoryId]) VALUES (9, N'Beer', N'The most awesome drink ever', 2, 150, NULL, 0, 8)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 10/1/2013 5:24:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 10/1/2013 5:24:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 10/1/2013 5:24:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserManagement]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 10/1/2013 5:24:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 10/1/2013 5:24:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parent_Id]    Script Date: 10/1/2013 5:24:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_Parent_Id] ON [dbo].[Categories]
(
	[Parent_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderId]    Script Date: 10/1/2013 5:24:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderId] ON [dbo].[OrderedProducts]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 10/1/2013 5:24:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[OrderedProducts]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 10/1/2013 5:24:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Orders]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryId]    Script Date: 10/1/2013 5:24:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserManagement]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserManagement_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserManagement] CHECK CONSTRAINT [FK_dbo.AspNetUserManagement_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Categories_dbo.Categories_Parent_Id] FOREIGN KEY([Parent_Id])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_dbo.Categories_dbo.Categories_Parent_Id]
GO
ALTER TABLE [dbo].[OrderedProducts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderedProducts_dbo.Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderedProducts] CHECK CONSTRAINT [FK_dbo.OrderedProducts_dbo.Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderedProducts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderedProducts_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderedProducts] CHECK CONSTRAINT [FK_dbo.OrderedProducts_dbo.Products_ProductId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.Categories_CategoryId]
GO
USE [master]
GO
ALTER DATABASE [Store] SET  READ_WRITE 
GO
