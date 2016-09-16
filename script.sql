USE [master]
GO
/****** Object:  Database [QuanLiNhanSu]    Script Date: 9/16/2016 9:59:51 AM ******/
CREATE DATABASE [QuanLiNhanSu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLiNhanSu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\QuanLiNhanSu.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLiNhanSu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\QuanLiNhanSu_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLiNhanSu] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLiNhanSu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLiNhanSu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLiNhanSu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLiNhanSu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLiNhanSu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLiNhanSu] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLiNhanSu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLiNhanSu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLiNhanSu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLiNhanSu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLiNhanSu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLiNhanSu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLiNhanSu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLiNhanSu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLiNhanSu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLiNhanSu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLiNhanSu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLiNhanSu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLiNhanSu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLiNhanSu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLiNhanSu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLiNhanSu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLiNhanSu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLiNhanSu] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLiNhanSu] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLiNhanSu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLiNhanSu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLiNhanSu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLiNhanSu] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QuanLiNhanSu] SET DELAYED_DURABILITY = DISABLED 
GO
USE [QuanLiNhanSu]
GO
/****** Object:  Table [dbo].[tblNhanVien]    Script Date: 9/16/2016 9:59:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNhanVien](
	[IDNhanVien] [int] NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[QueQuan] [nvarchar](50) NULL,
	[ChucVu] [nvarchar](50) NULL,
	[IDQuanLi] [nvarchar](50) NULL,
	[Luong] [bigint] NULL,
	[IDPhong] [int] NULL,
 CONSTRAINT [PK_tblNhanVien] PRIMARY KEY CLUSTERED 
(
	[IDNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblPhongBan]    Script Date: 9/16/2016 9:59:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPhongBan](
	[IDPhong] [int] NOT NULL,
	[TenPhong] [nvarchar](50) NULL,
	[IDTruongPhong] [nvarchar](50) NULL,
	[NgayNhanChuc] [date] NULL,
 CONSTRAINT [PK_tblPhongBan] PRIMARY KEY CLUSTERED 
(
	[IDPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblTaiKhoan]    Script Date: 9/16/2016 9:59:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTaiKhoan](
	[TenDangNhap] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblTaiKhoan] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[tblNhanVien] ([IDNhanVien], [HoTen], [NgaySinh], [GioiTinh], [QueQuan], [ChucVu], [IDQuanLi], [Luong], [IDPhong]) VALUES (1, N'Lê Hải Sơn', NULL, N'Nam', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[tblNhanVien] ([IDNhanVien], [HoTen], [NgaySinh], [GioiTinh], [QueQuan], [ChucVu], [IDQuanLi], [Luong], [IDPhong]) VALUES (2, N'Hồ Sỹ Việt', NULL, N'Nam', NULL, NULL, N'1', NULL, 1)
INSERT [dbo].[tblNhanVien] ([IDNhanVien], [HoTen], [NgaySinh], [GioiTinh], [QueQuan], [ChucVu], [IDQuanLi], [Luong], [IDPhong]) VALUES (3, N'Nguyễn Thanh Tùng', NULL, N'Nam', NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[tblNhanVien] ([IDNhanVien], [HoTen], [NgaySinh], [GioiTinh], [QueQuan], [ChucVu], [IDQuanLi], [Luong], [IDPhong]) VALUES (4, N'Nguyễn Văn Tuấn Anh', NULL, N'Nam', NULL, NULL, N'3', NULL, 2)
INSERT [dbo].[tblNhanVien] ([IDNhanVien], [HoTen], [NgaySinh], [GioiTinh], [QueQuan], [ChucVu], [IDQuanLi], [Luong], [IDPhong]) VALUES (5, N'Nguyễn Thế Công', NULL, NULL, NULL, NULL, N'3', NULL, 2)
INSERT [dbo].[tblPhongBan] ([IDPhong], [TenPhong], [IDTruongPhong], [NgayNhanChuc]) VALUES (1, N'Phòng tài chính', NULL, NULL)
INSERT [dbo].[tblPhongBan] ([IDPhong], [TenPhong], [IDTruongPhong], [NgayNhanChuc]) VALUES (2, N'Phòng hậu cần', NULL, NULL)
INSERT [dbo].[tblPhongBan] ([IDPhong], [TenPhong], [IDTruongPhong], [NgayNhanChuc]) VALUES (3, N'Phòng nhân sự', NULL, NULL)
INSERT [dbo].[tblPhongBan] ([IDPhong], [TenPhong], [IDTruongPhong], [NgayNhanChuc]) VALUES (4, N'Phòng hành chính', NULL, NULL)
ALTER TABLE [dbo].[tblNhanVien]  WITH CHECK ADD  CONSTRAINT [FK_tblNhanVien_tblPhongBan] FOREIGN KEY([IDPhong])
REFERENCES [dbo].[tblPhongBan] ([IDPhong])
GO
ALTER TABLE [dbo].[tblNhanVien] CHECK CONSTRAINT [FK_tblNhanVien_tblPhongBan]
GO
USE [master]
GO
ALTER DATABASE [QuanLiNhanSu] SET  READ_WRITE 
GO
