USE [master]
GO
/****** Object:  Database [Ultia]    Script Date: 23.03.2023 07:12:45 ******/
CREATE DATABASE [Ultia]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ultia', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Ultia.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Ultia_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Ultia_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Ultia] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ultia].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ultia] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ultia] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ultia] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ultia] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ultia] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ultia] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Ultia] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ultia] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ultia] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ultia] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ultia] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ultia] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ultia] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ultia] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ultia] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Ultia] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ultia] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ultia] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ultia] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ultia] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ultia] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Ultia] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ultia] SET RECOVERY FULL 
GO
ALTER DATABASE [Ultia] SET  MULTI_USER 
GO
ALTER DATABASE [Ultia] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ultia] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ultia] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ultia] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Ultia] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Ultia] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Ultia', N'ON'
GO
ALTER DATABASE [Ultia] SET QUERY_STORE = OFF
GO
USE [Ultia]
GO
/****** Object:  Table [dbo].[Birim]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Birim](
	[BirimID] [int] IDENTITY(1,1) NOT NULL,
	[BirimAdi] [nvarchar](10) NOT NULL,
	[AktifMi] [bit] NULL,
 CONSTRAINT [PK_Birim] PRIMARY KEY CLUSTERED 
(
	[BirimID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Depo]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Depo](
	[DepoID] [int] IDENTITY(1,1) NOT NULL,
	[DepoAdi] [nvarchar](20) NOT NULL,
	[SirketID] [int] NOT NULL,
	[AktifMi] [bit] NULL,
 CONSTRAINT [PK_Depo] PRIMARY KEY CLUSTERED 
(
	[DepoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Duyuru]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Duyuru](
	[DuyuruID] [int] IDENTITY(1,1) NOT NULL,
	[DuyuruAdi] [nvarchar](50) NOT NULL,
	[DuyuruIcerigi] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Duyuru] PRIMARY KEY CLUSTERED 
(
	[DuyuruID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ekip]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ekip](
	[EkipID] [int] IDENTITY(1,1) NOT NULL,
	[EkipAdi] [nvarchar](20) NOT NULL,
	[SirketID] [int] NOT NULL,
	[AktifMi] [bit] NULL,
 CONSTRAINT [PK_Ekip] PRIMARY KEY CLUSTERED 
(
	[EkipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EkipZimmet]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EkipZimmet](
	[EkipZimmetID] [int] IDENTITY(1,1) NOT NULL,
	[EkipID] [int] NOT NULL,
	[ZimmetID] [int] NOT NULL,
	[AktifMi] [bit] NULL,
 CONSTRAINT [PK_EkipZimmet] PRIMARY KEY CLUSTERED 
(
	[EkipZimmetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fiyat]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fiyat](
	[FiyatID] [int] IDENTITY(1,1) NOT NULL,
	[VarlikID] [int] NOT NULL,
	[ParaMiktari] [decimal](18, 0) NOT NULL,
	[GuncellemeTarihi] [date] NOT NULL,
	[ParaBirimiID] [int] NOT NULL,
	[AktifMi] [bit] NULL,
 CONSTRAINT [PK_Fiyat] PRIMARY KEY CLUSTERED 
(
	[FiyatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici](
	[KullaniciID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [nvarchar](20) NOT NULL,
	[AdSoyad] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[YoneticiID] [int] NULL,
	[RoleID] [int] NULL,
	[EkipID] [int] NULL,
	[Sifre] [nvarchar](16) NOT NULL,
	[AktifMi] [bit] NULL,
 CONSTRAINT [PK_Kullanici] PRIMARY KEY CLUSTERED 
(
	[KullaniciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KullaniciZimmet]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KullaniciZimmet](
	[KullaniciZimmetID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciID] [int] NULL,
	[ZimmetID] [int] NULL,
	[AktifMi] [bit] NULL,
 CONSTRAINT [PK_KullaniciZimmet] PRIMARY KEY CLUSTERED 
(
	[KullaniciZimmetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marka]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marka](
	[MarkaID] [int] IDENTITY(1,1) NOT NULL,
	[MarkaAdi] [nvarchar](20) NULL,
	[AktifMi] [bit] NULL,
 CONSTRAINT [PK_Marka] PRIMARY KEY CLUSTERED 
(
	[MarkaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Model]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Model](
	[ModelID] [int] IDENTITY(1,1) NOT NULL,
	[MarkaID] [int] NOT NULL,
	[ModelAd] [nvarchar](20) NOT NULL,
	[AktifMi] [bit] NULL,
 CONSTRAINT [PK_Model] PRIMARY KEY CLUSTERED 
(
	[ModelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteri]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteri](
	[MusteriID] [int] IDENTITY(1,1) NOT NULL,
	[MusteriAdSoyad] [nvarchar](30) NOT NULL,
	[MusteriTel] [char](11) NOT NULL,
	[AktifMi] [bit] NULL,
 CONSTRAINT [PK_Musteri] PRIMARY KEY CLUSTERED 
(
	[MusteriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MusteriVarlik]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MusteriVarlik](
	[MusteriVarlikID] [int] IDENTITY(1,1) NOT NULL,
	[MusteriID] [int] NOT NULL,
	[VarlikID] [int] NOT NULL,
	[Aciklama] [nvarchar](50) NULL,
	[AktifMi] [bit] NULL,
 CONSTRAINT [PK_MusteriVarlik] PRIMARY KEY CLUSTERED 
(
	[MusteriVarlikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParaBirimi]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParaBirimi](
	[ParaBirimiID] [int] IDENTITY(1,1) NOT NULL,
	[ParaBirimi] [nvarchar](10) NULL,
	[AktifMi] [bit] NULL,
 CONSTRAINT [PK_ParaBirimi] PRIMARY KEY CLUSTERED 
(
	[ParaBirimiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[RolID] [int] IDENTITY(1,1) NOT NULL,
	[RolAdi] [nvarchar](10) NULL,
	[AktifMi] [bit] NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[RolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sirket]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sirket](
	[SirketID] [int] IDENTITY(1,1) NOT NULL,
	[SirketAdi] [nvarchar](20) NOT NULL,
	[AktifMi] [bit] NULL,
 CONSTRAINT [PK_Sirket] PRIMARY KEY CLUSTERED 
(
	[SirketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Soru]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Soru](
	[SoruID] [int] IDENTITY(1,1) NOT NULL,
	[SoruBasligi] [nvarchar](50) NOT NULL,
	[SoruCevabi] [nvarchar](max) NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_Soru] PRIMARY KEY CLUSTERED 
(
	[SoruID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UrunTipi]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UrunTipi](
	[UrunTipiID] [int] IDENTITY(1,1) NOT NULL,
	[UrunTipi] [nvarchar](50) NOT NULL,
	[AktifMi] [bit] NULL,
 CONSTRAINT [PK_UrunTipi] PRIMARY KEY CLUSTERED 
(
	[UrunTipiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Varlik]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Varlik](
	[VarlikID] [int] IDENTITY(1,1) NOT NULL,
	[Barkod] [uniqueidentifier] NULL,
	[VarlikDurumID] [int] NULL,
	[UrunTipiID] [int] NOT NULL,
	[ModelID] [int] NOT NULL,
	[GarantiliMi] [bit] NOT NULL,
	[OlusturulmaTarihi] [date] NOT NULL,
	[UrunEmeklilikTarihi] [date] NULL,
	[UrunMaliyeti] [decimal](18, 0) NOT NULL,
	[UrunParaBirimiID] [int] NOT NULL,
	[Aciklama] [nvarchar](30) NOT NULL,
	[DosyaYolu] [nvarchar](max) NOT NULL,
	[AktifMi] [bit] NOT NULL,
	[OlusturanKisiID] [int] NULL,
	[DuzenleyenKisiID] [int] NULL,
	[DuzenlemeTarihi] [date] NULL,
	[BirimID] [int] NULL,
	[Miktar] [int] NULL,
 CONSTRAINT [PK_Varlik] PRIMARY KEY CLUSTERED 
(
	[VarlikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VarlikDepo]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VarlikDepo](
	[VarlikDepoID] [int] IDENTITY(1,1) NOT NULL,
	[VarlikID] [int] NOT NULL,
	[DepoID] [int] NOT NULL,
	[Aciklama] [nvarchar](50) NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_VarlikDepo] PRIMARY KEY CLUSTERED 
(
	[VarlikDepoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VarlikDurum]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VarlikDurum](
	[VarlikDurumID] [int] IDENTITY(1,1) NOT NULL,
	[VarlikDurum] [nvarchar](15) NULL,
	[AktifMi] [bit] NULL,
 CONSTRAINT [PK_VarlikDurum] PRIMARY KEY CLUSTERED 
(
	[VarlikDurumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zimmet]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zimmet](
	[ZimmetID] [int] IDENTITY(1,1) NOT NULL,
	[ZimmetNedeniID] [int] NOT NULL,
	[ZimmetTuruID] [int] NOT NULL,
	[BaslangicTarihi] [date] NOT NULL,
	[BitisTarihi] [date] NULL,
	[Aciklama] [nvarchar](max) NULL,
	[AktifMi] [bit] NOT NULL,
	[OlusturanKisiID] [int] NULL,
	[DuzenleyenKisiID] [int] NULL,
	[DuzenlemeTarihi] [date] NULL,
	[OlusturmaTarihi] [date] NULL,
	[VarlikDepoID] [int] NULL,
 CONSTRAINT [PK_Zimmet] PRIMARY KEY CLUSTERED 
(
	[ZimmetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZimmetNedeni]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZimmetNedeni](
	[ZimmetNedeniID] [int] IDENTITY(1,1) NOT NULL,
	[ZimmetNedeni] [nvarchar](50) NOT NULL,
	[AktifMi] [bit] NULL,
 CONSTRAINT [PK_ZimmetNedeni] PRIMARY KEY CLUSTERED 
(
	[ZimmetNedeniID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZimmetTuru]    Script Date: 23.03.2023 07:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZimmetTuru](
	[ZimmetTuruID] [int] IDENTITY(1,1) NOT NULL,
	[ZimmetTuru] [nvarchar](30) NOT NULL,
	[AktifMi] [bit] NULL,
 CONSTRAINT [PK_ZimmetTuru] PRIMARY KEY CLUSTERED 
(
	[ZimmetTuruID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Depo]  WITH CHECK ADD  CONSTRAINT [FK_Depo_Sirket] FOREIGN KEY([SirketID])
REFERENCES [dbo].[Sirket] ([SirketID])
GO
ALTER TABLE [dbo].[Depo] CHECK CONSTRAINT [FK_Depo_Sirket]
GO
ALTER TABLE [dbo].[Ekip]  WITH CHECK ADD  CONSTRAINT [FK_Ekip_Sirket] FOREIGN KEY([SirketID])
REFERENCES [dbo].[Sirket] ([SirketID])
GO
ALTER TABLE [dbo].[Ekip] CHECK CONSTRAINT [FK_Ekip_Sirket]
GO
ALTER TABLE [dbo].[EkipZimmet]  WITH CHECK ADD  CONSTRAINT [FK_EkipZimmet_Ekip] FOREIGN KEY([EkipID])
REFERENCES [dbo].[Ekip] ([EkipID])
GO
ALTER TABLE [dbo].[EkipZimmet] CHECK CONSTRAINT [FK_EkipZimmet_Ekip]
GO
ALTER TABLE [dbo].[EkipZimmet]  WITH CHECK ADD  CONSTRAINT [FK_EkipZimmet_Zimmet] FOREIGN KEY([ZimmetID])
REFERENCES [dbo].[Zimmet] ([ZimmetID])
GO
ALTER TABLE [dbo].[EkipZimmet] CHECK CONSTRAINT [FK_EkipZimmet_Zimmet]
GO
ALTER TABLE [dbo].[Fiyat]  WITH CHECK ADD  CONSTRAINT [FK_Fiyat_ParaBirimi] FOREIGN KEY([ParaBirimiID])
REFERENCES [dbo].[ParaBirimi] ([ParaBirimiID])
GO
ALTER TABLE [dbo].[Fiyat] CHECK CONSTRAINT [FK_Fiyat_ParaBirimi]
GO
ALTER TABLE [dbo].[Fiyat]  WITH CHECK ADD  CONSTRAINT [FK_Fiyat_Varlik] FOREIGN KEY([VarlikID])
REFERENCES [dbo].[Varlik] ([VarlikID])
GO
ALTER TABLE [dbo].[Fiyat] CHECK CONSTRAINT [FK_Fiyat_Varlik]
GO
ALTER TABLE [dbo].[Kullanici]  WITH CHECK ADD  CONSTRAINT [FK_Kullanici_Ekip] FOREIGN KEY([EkipID])
REFERENCES [dbo].[Ekip] ([EkipID])
GO
ALTER TABLE [dbo].[Kullanici] CHECK CONSTRAINT [FK_Kullanici_Ekip]
GO
ALTER TABLE [dbo].[Kullanici]  WITH CHECK ADD  CONSTRAINT [FK_Kullanici_Kullanici] FOREIGN KEY([YoneticiID])
REFERENCES [dbo].[Kullanici] ([KullaniciID])
GO
ALTER TABLE [dbo].[Kullanici] CHECK CONSTRAINT [FK_Kullanici_Kullanici]
GO
ALTER TABLE [dbo].[Kullanici]  WITH CHECK ADD  CONSTRAINT [FK_Kullanici_Rol] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Rol] ([RolID])
GO
ALTER TABLE [dbo].[Kullanici] CHECK CONSTRAINT [FK_Kullanici_Rol]
GO
ALTER TABLE [dbo].[KullaniciZimmet]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciZimmet_Kullanici] FOREIGN KEY([KullaniciID])
REFERENCES [dbo].[Kullanici] ([KullaniciID])
GO
ALTER TABLE [dbo].[KullaniciZimmet] CHECK CONSTRAINT [FK_KullaniciZimmet_Kullanici]
GO
ALTER TABLE [dbo].[KullaniciZimmet]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciZimmet_Zimmet] FOREIGN KEY([ZimmetID])
REFERENCES [dbo].[Zimmet] ([ZimmetID])
GO
ALTER TABLE [dbo].[KullaniciZimmet] CHECK CONSTRAINT [FK_KullaniciZimmet_Zimmet]
GO
ALTER TABLE [dbo].[Model]  WITH CHECK ADD  CONSTRAINT [FK_Model_Marka] FOREIGN KEY([MarkaID])
REFERENCES [dbo].[Marka] ([MarkaID])
GO
ALTER TABLE [dbo].[Model] CHECK CONSTRAINT [FK_Model_Marka]
GO
ALTER TABLE [dbo].[MusteriVarlik]  WITH CHECK ADD  CONSTRAINT [FK_MusteriVarlik_Musteri] FOREIGN KEY([MusteriID])
REFERENCES [dbo].[Musteri] ([MusteriID])
GO
ALTER TABLE [dbo].[MusteriVarlik] CHECK CONSTRAINT [FK_MusteriVarlik_Musteri]
GO
ALTER TABLE [dbo].[MusteriVarlik]  WITH CHECK ADD  CONSTRAINT [FK_MusteriVarlik_Varlik] FOREIGN KEY([VarlikID])
REFERENCES [dbo].[Varlik] ([VarlikID])
GO
ALTER TABLE [dbo].[MusteriVarlik] CHECK CONSTRAINT [FK_MusteriVarlik_Varlik]
GO
ALTER TABLE [dbo].[Varlik]  WITH CHECK ADD  CONSTRAINT [FK_Varlik_Birim] FOREIGN KEY([BirimID])
REFERENCES [dbo].[Birim] ([BirimID])
GO
ALTER TABLE [dbo].[Varlik] CHECK CONSTRAINT [FK_Varlik_Birim]
GO
ALTER TABLE [dbo].[Varlik]  WITH CHECK ADD  CONSTRAINT [FK_Varlik_Model] FOREIGN KEY([ModelID])
REFERENCES [dbo].[Model] ([ModelID])
GO
ALTER TABLE [dbo].[Varlik] CHECK CONSTRAINT [FK_Varlik_Model]
GO
ALTER TABLE [dbo].[Varlik]  WITH CHECK ADD  CONSTRAINT [FK_Varlik_ParaBirimi] FOREIGN KEY([UrunParaBirimiID])
REFERENCES [dbo].[ParaBirimi] ([ParaBirimiID])
GO
ALTER TABLE [dbo].[Varlik] CHECK CONSTRAINT [FK_Varlik_ParaBirimi]
GO
ALTER TABLE [dbo].[Varlik]  WITH CHECK ADD  CONSTRAINT [FK_Varlik_UrunTipi] FOREIGN KEY([UrunTipiID])
REFERENCES [dbo].[UrunTipi] ([UrunTipiID])
GO
ALTER TABLE [dbo].[Varlik] CHECK CONSTRAINT [FK_Varlik_UrunTipi]
GO
ALTER TABLE [dbo].[Varlik]  WITH CHECK ADD  CONSTRAINT [FK_Varlik_VarlikDurum] FOREIGN KEY([VarlikDurumID])
REFERENCES [dbo].[VarlikDurum] ([VarlikDurumID])
GO
ALTER TABLE [dbo].[Varlik] CHECK CONSTRAINT [FK_Varlik_VarlikDurum]
GO
ALTER TABLE [dbo].[VarlikDepo]  WITH CHECK ADD  CONSTRAINT [FK_VarlikDepo_Depo] FOREIGN KEY([DepoID])
REFERENCES [dbo].[Depo] ([DepoID])
GO
ALTER TABLE [dbo].[VarlikDepo] CHECK CONSTRAINT [FK_VarlikDepo_Depo]
GO
ALTER TABLE [dbo].[VarlikDepo]  WITH CHECK ADD  CONSTRAINT [FK_VarlikDepo_Varlik] FOREIGN KEY([VarlikID])
REFERENCES [dbo].[Varlik] ([VarlikID])
GO
ALTER TABLE [dbo].[VarlikDepo] CHECK CONSTRAINT [FK_VarlikDepo_Varlik]
GO
ALTER TABLE [dbo].[Zimmet]  WITH CHECK ADD  CONSTRAINT [FK_Zimmet_VarlikDepo] FOREIGN KEY([VarlikDepoID])
REFERENCES [dbo].[VarlikDepo] ([VarlikDepoID])
GO
ALTER TABLE [dbo].[Zimmet] CHECK CONSTRAINT [FK_Zimmet_VarlikDepo]
GO
ALTER TABLE [dbo].[Zimmet]  WITH CHECK ADD  CONSTRAINT [FK_Zimmet_ZimmetNedeni] FOREIGN KEY([ZimmetNedeniID])
REFERENCES [dbo].[ZimmetNedeni] ([ZimmetNedeniID])
GO
ALTER TABLE [dbo].[Zimmet] CHECK CONSTRAINT [FK_Zimmet_ZimmetNedeni]
GO
ALTER TABLE [dbo].[Zimmet]  WITH CHECK ADD  CONSTRAINT [FK_Zimmet_ZimmetTuru] FOREIGN KEY([ZimmetTuruID])
REFERENCES [dbo].[ZimmetTuru] ([ZimmetTuruID])
GO
ALTER TABLE [dbo].[Zimmet] CHECK CONSTRAINT [FK_Zimmet_ZimmetTuru]
GO
USE [master]
GO
ALTER DATABASE [Ultia] SET  READ_WRITE 
GO
