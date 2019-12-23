-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 172.17.0.5
-- Thời gian đã tạo: Th12 23, 2019 lúc 07:27 AM
-- Phiên bản máy phục vụ: 5.7.28
-- Phiên bản PHP: 7.2.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `ACB-Auth`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `AspNetRoleClaims`
--

CREATE TABLE `AspNetRoleClaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4,
  `ClaimValue` longtext CHARACTER SET utf8mb4
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `AspNetRoles`
--

CREATE TABLE `AspNetRoles` (
  `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `AspNetUserClaims`
--

CREATE TABLE `AspNetUserClaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4,
  `ClaimValue` longtext CHARACTER SET utf8mb4
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `AspNetUserLogins`
--

CREATE TABLE `AspNetUserLogins` (
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `ProviderKey` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8mb4,
  `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `AspNetUserRoles`
--

CREATE TABLE `AspNetUserRoles` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `AspNetUsers`
--

CREATE TABLE `AspNetUsers` (
  `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4,
  `SecurityStamp` longtext CHARACTER SET utf8mb4,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4,
  `PhoneNumber` longtext CHARACTER SET utf8mb4,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

--
-- Đang đổ dữ liệu cho bảng `AspNetUsers`
--

INSERT INTO `AspNetUsers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
('0bffab3a-5582-4d66-a64a-43336da137ee', 'MiMi', 'MIMI', 'ltdung@fenc.vn', 'LTDUNG@FENC.VN', 0, 'AQAAAAEAACcQAAAAEKayXl1XALeiidKrj8eh3jDW305/Gz2v+FZpPZpWJHH+Dc0sZckoPhgntetGsF/QaQ==', 'UCADEWE3VBARTAXOXGMHZOM7ML22YXZT', '4de8610c-e48d-4787-9527-5527cafcbfb6', NULL, 0, 0, NULL, 0, 0),
('c7baafc6-ee6d-4e79-a150-3084ec8bfd74', 'dunglt', 'DUNGLT', 'ltdung@fenc.vn', 'LTDUNG@FENC.VN', 0, 'AQAAAAEAACcQAAAAEC+9caqdAydA7xWEdQh5UW8PFmbfstNI9MTFge4ewUkvkp45xzAHsK6XMKP+rS6iWA==', '2KNWFVDHRBOL5TFU3FPCW3R6NIRIAEFZ', '7fb79410-e525-498a-9ae2-d8297f9e3949', NULL, 0, 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `AspNetUserTokens`
--

CREATE TABLE `AspNetUserTokens` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `__EFMigrationsHistory`
--

CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(95) COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `ProductVersion` varchar(32) COLLATE utf8mb4_vietnamese_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

--
-- Đang đổ dữ liệu cho bảng `__EFMigrationsHistory`
--

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20191219111524_AddingIdentity', '3.0.0');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `AspNetRoleClaims`
--
ALTER TABLE `AspNetRoleClaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Chỉ mục cho bảng `AspNetRoles`
--
ALTER TABLE `AspNetRoles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Chỉ mục cho bảng `AspNetUserClaims`
--
ALTER TABLE `AspNetUserClaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Chỉ mục cho bảng `AspNetUserLogins`
--
ALTER TABLE `AspNetUserLogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Chỉ mục cho bảng `AspNetUserRoles`
--
ALTER TABLE `AspNetUserRoles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Chỉ mục cho bảng `AspNetUsers`
--
ALTER TABLE `AspNetUsers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Chỉ mục cho bảng `AspNetUserTokens`
--
ALTER TABLE `AspNetUserTokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Chỉ mục cho bảng `__EFMigrationsHistory`
--
ALTER TABLE `__EFMigrationsHistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `AspNetRoleClaims`
--
ALTER TABLE `AspNetRoleClaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `AspNetUserClaims`
--
ALTER TABLE `AspNetUserClaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `AspNetRoleClaims`
--
ALTER TABLE `AspNetRoleClaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE;

--
-- Các ràng buộc cho bảng `AspNetUserClaims`
--
ALTER TABLE `AspNetUserClaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

--
-- Các ràng buộc cho bảng `AspNetUserLogins`
--
ALTER TABLE `AspNetUserLogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

--
-- Các ràng buộc cho bảng `AspNetUserRoles`
--
ALTER TABLE `AspNetUserRoles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

--
-- Các ràng buộc cho bảng `AspNetUserTokens`
--
ALTER TABLE `AspNetUserTokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
