-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 172.17.0.5
-- Thời gian đã tạo: Th12 23, 2019 lúc 07:55 AM
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
-- Cơ sở dữ liệu: `ACB-System`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Address`
--

CREATE TABLE `Address` (
  `AddressID` int(11) NOT NULL,
  `AddressLine1` text COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `AddressLine2` text COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `WardID` int(11) NOT NULL,
  `PostalCode` varchar(50) COLLATE utf8mb4_vietnamese_ci DEFAULT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `AddressType`
--

CREATE TABLE `AddressType` (
  `AddressTypeID` int(11) NOT NULL,
  `Name` text COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `BusinessEntity`
--

CREATE TABLE `BusinessEntity` (
  `BusinessEntityID` int(11) NOT NULL,
  `ModifiedDate` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `BusinessEntityAddress`
--

CREATE TABLE `BusinessEntityAddress` (
  `BusinessEntityID` int(11) NOT NULL,
  `AddressID` int(11) NOT NULL,
  `AddressTypeID` int(11) NOT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `BusinessEntityContact`
--

CREATE TABLE `BusinessEntityContact` (
  `BusinessEntityID` int(11) NOT NULL,
  `PersonID` int(11) NOT NULL,
  `ContactTypeID` int(11) NOT NULL,
  `ModifiedDate` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `BusinessEntityPhone`
--

CREATE TABLE `BusinessEntityPhone` (
  `BusinessEntityID` int(11) NOT NULL,
  `PhoneID` int(11) NOT NULL,
  `PhoneTypeID` int(11) NOT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ContactType`
--

CREATE TABLE `ContactType` (
  `ContactTypeID` int(11) NOT NULL,
  `Name` text COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `District`
--

CREATE TABLE `District` (
  `DistrictID` varchar(5) COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `DistrictName` text COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `EnglishName` text COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `Level` text COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `ProvinceID` varchar(5) COLLATE utf8mb4_vietnamese_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Employee`
--

CREATE TABLE `Employee` (
  `BusinessEntityID` int(11) NOT NULL,
  `NationalIDNumber` varchar(20) COLLATE utf8mb4_vietnamese_ci DEFAULT NULL,
  `LoginID` varchar(20) COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `Position` text COLLATE utf8mb4_vietnamese_ci,
  `JobTitle` text COLLATE utf8mb4_vietnamese_ci,
  `BirthDate` datetime NOT NULL,
  `MaritalStatus` varchar(1) COLLATE utf8mb4_vietnamese_ci NOT NULL COMMENT 'S=Single, M= Married',
  `Gender` varchar(1) COLLATE utf8mb4_vietnamese_ci NOT NULL COMMENT 'M=male, F= Female',
  `HireDate` datetime NOT NULL,
  `VacationHours` tinyint(4) NOT NULL DEFAULT '96',
  `SickLeaveHours` tinyint(4) NOT NULL DEFAULT '0',
  `CurrentFlag` tinyint(1) NOT NULL DEFAULT '0',
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Person`
--

CREATE TABLE `Person` (
  `BusinessEntityID` int(11) NOT NULL,
  `PersonType` varchar(2) COLLATE utf8mb4_vietnamese_ci NOT NULL COMMENT 'Primary type of person: SC = Store Contact, IN = Individual (retail) customer, SP = Sales person, EM = Employee (non-sales), VC = Vendor contact, GC = General contact',
  `Title` varchar(8) COLLATE utf8mb4_vietnamese_ci NOT NULL COMMENT 'A courtesy title. For example, Mr. or Ms.',
  `FirstName` text COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `LastName` text COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Phone`
--

CREATE TABLE `Phone` (
  `PhoneID` int(11) NOT NULL,
  `PhoneNumber` varchar(50) COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

--
-- Đang đổ dữ liệu cho bảng `Phone`
--

INSERT INTO `Phone` (`PhoneID`, `PhoneNumber`, `ModifiedDate`) VALUES
(1, '0987654321', '2019-12-19 10:18:56');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `PhoneType`
--

CREATE TABLE `PhoneType` (
  `PhoneTypeID` int(11) NOT NULL,
  `Name` text COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Product`
--

CREATE TABLE `Product` (
  `ProductID` int(11) NOT NULL,
  `Name` text COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `ProductNumber` varchar(50) COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `MakeFlag` tinyint(1) NOT NULL,
  `Color` varchar(15) COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `StandardCost` decimal(10,0) NOT NULL,
  `SafetyStockLevel` smallint(6) NOT NULL,
  `ReorderPoint` smallint(6) NOT NULL DEFAULT '1',
  `Size` varchar(5) COLLATE utf8mb4_vietnamese_ci DEFAULT NULL,
  `SizeUnitMeasureCode` varchar(3) COLLATE utf8mb4_vietnamese_ci DEFAULT NULL,
  `WeightUnitMeasureCode` varchar(3) COLLATE utf8mb4_vietnamese_ci DEFAULT NULL,
  `Weight` decimal(10,0) DEFAULT NULL,
  `Class` varchar(3) COLLATE utf8mb4_vietnamese_ci DEFAULT NULL,
  `Style` varchar(3) COLLATE utf8mb4_vietnamese_ci DEFAULT NULL,
  `ProductSubcategoryID` int(11) DEFAULT NULL,
  `ProductModelID` int(11) DEFAULT NULL,
  `SellStartDate` datetime NOT NULL,
  `SellEndDate` datetime DEFAULT NULL,
  `DiscontinuedDate` datetime DEFAULT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ProductCategory`
--

CREATE TABLE `ProductCategory` (
  `ProductCategoryID` int(11) NOT NULL,
  `Name` text COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ProductInventory`
--

CREATE TABLE `ProductInventory` (
  `ProductID` int(11) NOT NULL,
  `LocationID` int(11) DEFAULT NULL,
  `Shelf` int(11) DEFAULT NULL,
  `Bin` int(11) DEFAULT NULL,
  `Quantity` smallint(6) NOT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ProductListPriceHistory`
--

CREATE TABLE `ProductListPriceHistory` (
  `ProductID` int(11) NOT NULL,
  `StartDate` datetime DEFAULT NULL,
  `EndDate` datetime DEFAULT NULL,
  `ListPrice` decimal(10,0) NOT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ProductPhoto`
--

CREATE TABLE `ProductPhoto` (
  `ProductPhotoID` int(11) NOT NULL,
  `ThumbNailPhoto` varbinary(6553) DEFAULT NULL,
  `ThumbnailPhotoFileName` varchar(50) COLLATE utf8mb4_vietnamese_ci DEFAULT NULL,
  `LargePhoto` varbinary(6553) DEFAULT NULL,
  `LargePhotoFileName` varchar(150) COLLATE utf8mb4_vietnamese_ci DEFAULT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ProductProductPhoto`
--

CREATE TABLE `ProductProductPhoto` (
  `ProductID` int(11) NOT NULL,
  `ProductPhotoID` int(11) NOT NULL,
  `PrimaryImage` tinyint(1) NOT NULL,
  `QRcode` int(11) NOT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ProductSubCategory`
--

CREATE TABLE `ProductSubCategory` (
  `ProductSubCategoryID` int(11) NOT NULL,
  `ProductCategoryID` int(11) NOT NULL,
  `Name` text COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Province`
--

CREATE TABLE `Province` (
  `ProviceID` varchar(5) COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `ProviceName` text COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `EnglishName` text COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `Level` text COLLATE utf8mb4_vietnamese_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `PurchaseOrderDetail`
--

CREATE TABLE `PurchaseOrderDetail` (
  `PurchaseOrderID` int(11) NOT NULL,
  `PurchaseOrderDetailID` int(11) NOT NULL,
  `DueDate` datetime NOT NULL,
  `OrderQty` smallint(6) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `UnitPrice` decimal(10,0) NOT NULL,
  `LineTotal` decimal(10,0) NOT NULL,
  `ReceivedQty` int(11) NOT NULL,
  `RejectedQty` int(11) NOT NULL,
  `StockedQty` int(11) NOT NULL COMMENT 'Quantity accepted into inventory. Computed as ReceivedQty - RejectedQty.',
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `PurchaseOrderHeader`
--

CREATE TABLE `PurchaseOrderHeader` (
  `PurchaseOrderID` int(11) NOT NULL,
  `RevisionNumber` int(11) NOT NULL COMMENT 'Incremental number to track changes to the purchase order over time.',
  `Status` tinyint(4) NOT NULL COMMENT 'Order current status. 1 = Pending; 2 = Approved; 3 = Rejected; 4 = Complete',
  `EmployeeID` int(11) NOT NULL,
  `VendorID` int(11) NOT NULL,
  `OrderDate` datetime NOT NULL,
  `SubTotal` decimal(10,0) NOT NULL COMMENT 'Purchase order subtotal. Computed as SUM(PurchaseOrderDetail.LineTotal)for the appropriate PurchaseOrderID.',
  `TaxAmt` decimal(10,0) NOT NULL,
  `Freight` decimal(10,0) NOT NULL COMMENT 'Shipping cost.',
  `TotalDue` decimal(10,0) NOT NULL COMMENT 'Total due to vendor. Computed as Subtotal + TaxAmt + Freight.',
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `SaleOrderHeader`
--

CREATE TABLE `SaleOrderHeader` (
  `SalesOrderID` int(11) NOT NULL,
  `RevisionNumber` tinyint(4) NOT NULL COMMENT 'Incremental number to track changes to the sales order over time.',
  `OrderDate` datetime NOT NULL,
  `DueDate` datetime NOT NULL,
  `ShipDate` datetime NOT NULL,
  `Status` tinyint(4) NOT NULL COMMENT 'Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled',
  `OnlineOrderFlag` tinyint(1) NOT NULL,
  `SalesOrderNumber` varchar(20) COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `CustomerID` int(11) NOT NULL,
  `AccountNumber` varchar(15) COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `SalesPersonID` int(11) NOT NULL,
  `SubTotal` decimal(10,0) NOT NULL,
  `TaxAmt` decimal(10,0) NOT NULL,
  `Freight` decimal(10,0) NOT NULL COMMENT 'Shipping cost.',
  `TotalDue` decimal(10,0) NOT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `SalesOrderDetail`
--

CREATE TABLE `SalesOrderDetail` (
  `SalesOrderID` int(11) NOT NULL,
  `SalesOrderDetailID` int(11) NOT NULL,
  `OrderQty` smallint(6) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `SpecialOfferID` int(11) DEFAULT NULL,
  `UnitPrice` decimal(10,0) NOT NULL,
  `UnitPriceDiscount` decimal(10,0) NOT NULL,
  `LineTotal` decimal(10,0) NOT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `TransactionHistory`
--

CREATE TABLE `TransactionHistory` (
  `TransactionID` int(11) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `ReferenceOrderID` int(11) NOT NULL,
  `ReferenceOrderLineID` int(11) DEFAULT NULL,
  `TransactionDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `TransactionType` varchar(1) COLLATE utf8mb4_vietnamese_ci NOT NULL COMMENT 'W = WorkOrder, S = SalesOrder, P = PurchaseOrder',
  `Quantity` int(11) NOT NULL,
  `ActualCost` decimal(10,0) NOT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `UnitMeasure`
--

CREATE TABLE `UnitMeasure` (
  `UnitMeasureCode` varchar(3) COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `Name` text COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Vendor`
--

CREATE TABLE `Vendor` (
  `BusinessEntityID` int(11) NOT NULL,
  `AccountNumber` int(11) NOT NULL,
  `Name` int(11) NOT NULL,
  `ActiveFlag` int(11) NOT NULL COMMENT '0 = Vendor no longer used. 1 = Vendor is actively used.',
  `PreferredVendorStatus` int(11) NOT NULL COMMENT '0 = Do not use if another vendor is available. 1 = Preferred over other vendors supplying the same product.',
  `ModifiedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Ward`
--

CREATE TABLE `Ward` (
  `WarID` varchar(5) COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `WardName` text COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `EnglishName` text COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `Level` text COLLATE utf8mb4_vietnamese_ci NOT NULL,
  `DistrictID` varchar(5) COLLATE utf8mb4_vietnamese_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `Address`
--
ALTER TABLE `Address`
  ADD PRIMARY KEY (`AddressID`);

--
-- Chỉ mục cho bảng `AddressType`
--
ALTER TABLE `AddressType`
  ADD PRIMARY KEY (`AddressTypeID`);

--
-- Chỉ mục cho bảng `BusinessEntity`
--
ALTER TABLE `BusinessEntity`
  ADD PRIMARY KEY (`BusinessEntityID`);

--
-- Chỉ mục cho bảng `BusinessEntityAddress`
--
ALTER TABLE `BusinessEntityAddress`
  ADD PRIMARY KEY (`BusinessEntityID`),
  ADD KEY `AddressID` (`AddressID`),
  ADD KEY `AddressTypeID` (`AddressTypeID`);

--
-- Chỉ mục cho bảng `BusinessEntityContact`
--
ALTER TABLE `BusinessEntityContact`
  ADD PRIMARY KEY (`BusinessEntityID`),
  ADD KEY `ContactTypeID` (`ContactTypeID`);

--
-- Chỉ mục cho bảng `BusinessEntityPhone`
--
ALTER TABLE `BusinessEntityPhone`
  ADD PRIMARY KEY (`BusinessEntityID`),
  ADD KEY `PhoneID` (`PhoneID`);

--
-- Chỉ mục cho bảng `ContactType`
--
ALTER TABLE `ContactType`
  ADD PRIMARY KEY (`ContactTypeID`);

--
-- Chỉ mục cho bảng `District`
--
ALTER TABLE `District`
  ADD PRIMARY KEY (`DistrictID`),
  ADD KEY `ProvinceID` (`ProvinceID`);

--
-- Chỉ mục cho bảng `Employee`
--
ALTER TABLE `Employee`
  ADD PRIMARY KEY (`BusinessEntityID`);

--
-- Chỉ mục cho bảng `Person`
--
ALTER TABLE `Person`
  ADD PRIMARY KEY (`BusinessEntityID`);

--
-- Chỉ mục cho bảng `Phone`
--
ALTER TABLE `Phone`
  ADD PRIMARY KEY (`PhoneID`);

--
-- Chỉ mục cho bảng `PhoneType`
--
ALTER TABLE `PhoneType`
  ADD PRIMARY KEY (`PhoneTypeID`);

--
-- Chỉ mục cho bảng `Product`
--
ALTER TABLE `Product`
  ADD PRIMARY KEY (`ProductID`),
  ADD KEY `ProductSubcategoryID` (`ProductSubcategoryID`);

--
-- Chỉ mục cho bảng `ProductCategory`
--
ALTER TABLE `ProductCategory`
  ADD PRIMARY KEY (`ProductCategoryID`);

--
-- Chỉ mục cho bảng `ProductInventory`
--
ALTER TABLE `ProductInventory`
  ADD PRIMARY KEY (`ProductID`);

--
-- Chỉ mục cho bảng `ProductListPriceHistory`
--
ALTER TABLE `ProductListPriceHistory`
  ADD PRIMARY KEY (`ProductID`);

--
-- Chỉ mục cho bảng `ProductPhoto`
--
ALTER TABLE `ProductPhoto`
  ADD PRIMARY KEY (`ProductPhotoID`);

--
-- Chỉ mục cho bảng `ProductProductPhoto`
--
ALTER TABLE `ProductProductPhoto`
  ADD PRIMARY KEY (`ProductID`),
  ADD KEY `ProductPhotoID` (`ProductPhotoID`);

--
-- Chỉ mục cho bảng `ProductSubCategory`
--
ALTER TABLE `ProductSubCategory`
  ADD PRIMARY KEY (`ProductSubCategoryID`),
  ADD KEY `ProductCategoryID` (`ProductCategoryID`);

--
-- Chỉ mục cho bảng `Province`
--
ALTER TABLE `Province`
  ADD PRIMARY KEY (`ProviceID`);

--
-- Chỉ mục cho bảng `PurchaseOrderDetail`
--
ALTER TABLE `PurchaseOrderDetail`
  ADD PRIMARY KEY (`PurchaseOrderDetailID`,`PurchaseOrderID`),
  ADD KEY `ProductID` (`ProductID`),
  ADD KEY `PurchaseOrderID` (`PurchaseOrderID`);

--
-- Chỉ mục cho bảng `PurchaseOrderHeader`
--
ALTER TABLE `PurchaseOrderHeader`
  ADD PRIMARY KEY (`PurchaseOrderID`);

--
-- Chỉ mục cho bảng `SaleOrderHeader`
--
ALTER TABLE `SaleOrderHeader`
  ADD PRIMARY KEY (`SalesOrderID`);

--
-- Chỉ mục cho bảng `SalesOrderDetail`
--
ALTER TABLE `SalesOrderDetail`
  ADD PRIMARY KEY (`SalesOrderID`);

--
-- Chỉ mục cho bảng `TransactionHistory`
--
ALTER TABLE `TransactionHistory`
  ADD PRIMARY KEY (`TransactionID`);

--
-- Chỉ mục cho bảng `Vendor`
--
ALTER TABLE `Vendor`
  ADD PRIMARY KEY (`BusinessEntityID`);

--
-- Chỉ mục cho bảng `Ward`
--
ALTER TABLE `Ward`
  ADD PRIMARY KEY (`WarID`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `Address`
--
ALTER TABLE `Address`
  MODIFY `AddressID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `AddressType`
--
ALTER TABLE `AddressType`
  MODIFY `AddressTypeID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `BusinessEntity`
--
ALTER TABLE `BusinessEntity`
  MODIFY `BusinessEntityID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `ContactType`
--
ALTER TABLE `ContactType`
  MODIFY `ContactTypeID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `Employee`
--
ALTER TABLE `Employee`
  MODIFY `BusinessEntityID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `Phone`
--
ALTER TABLE `Phone`
  MODIFY `PhoneID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT cho bảng `PhoneType`
--
ALTER TABLE `PhoneType`
  MODIFY `PhoneTypeID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `Product`
--
ALTER TABLE `Product`
  MODIFY `ProductID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `ProductCategory`
--
ALTER TABLE `ProductCategory`
  MODIFY `ProductCategoryID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `ProductPhoto`
--
ALTER TABLE `ProductPhoto`
  MODIFY `ProductPhotoID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `ProductSubCategory`
--
ALTER TABLE `ProductSubCategory`
  MODIFY `ProductSubCategoryID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `PurchaseOrderDetail`
--
ALTER TABLE `PurchaseOrderDetail`
  MODIFY `PurchaseOrderDetailID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `PurchaseOrderHeader`
--
ALTER TABLE `PurchaseOrderHeader`
  MODIFY `PurchaseOrderID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `SaleOrderHeader`
--
ALTER TABLE `SaleOrderHeader`
  MODIFY `SalesOrderID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `SalesOrderDetail`
--
ALTER TABLE `SalesOrderDetail`
  MODIFY `SalesOrderID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `TransactionHistory`
--
ALTER TABLE `TransactionHistory`
  MODIFY `TransactionID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `Address`
--
ALTER TABLE `Address`
  ADD CONSTRAINT `Address_ibfk_1` FOREIGN KEY (`AddressID`) REFERENCES `BusinessEntityAddress` (`AddressID`);

--
-- Các ràng buộc cho bảng `AddressType`
--
ALTER TABLE `AddressType`
  ADD CONSTRAINT `AddressType_ibfk_1` FOREIGN KEY (`AddressTypeID`) REFERENCES `BusinessEntityAddress` (`AddressTypeID`);

--
-- Các ràng buộc cho bảng `BusinessEntityAddress`
--
ALTER TABLE `BusinessEntityAddress`
  ADD CONSTRAINT `BusinessEntityAddress_ibfk_2` FOREIGN KEY (`AddressID`) REFERENCES `Address` (`AddressID`),
  ADD CONSTRAINT `BusinessEntityAddress_ibfk_3` FOREIGN KEY (`AddressTypeID`) REFERENCES `AddressType` (`AddressTypeID`),
  ADD CONSTRAINT `BusinessEntityAddress_ibfk_4` FOREIGN KEY (`BusinessEntityID`) REFERENCES `BusinessEntity` (`BusinessEntityID`);

--
-- Các ràng buộc cho bảng `BusinessEntityContact`
--
ALTER TABLE `BusinessEntityContact`
  ADD CONSTRAINT `BusinessEntityContact_ibfk_1` FOREIGN KEY (`ContactTypeID`) REFERENCES `ContactType` (`ContactTypeID`),
  ADD CONSTRAINT `BusinessEntityContact_ibfk_3` FOREIGN KEY (`BusinessEntityID`) REFERENCES `Person` (`BusinessEntityID`),
  ADD CONSTRAINT `BusinessEntityContact_ibfk_4` FOREIGN KEY (`BusinessEntityID`) REFERENCES `BusinessEntity` (`BusinessEntityID`);

--
-- Các ràng buộc cho bảng `BusinessEntityPhone`
--
ALTER TABLE `BusinessEntityPhone`
  ADD CONSTRAINT `BusinessEntityPhone_ibfk_1` FOREIGN KEY (`PhoneID`) REFERENCES `Phone` (`PhoneID`),
  ADD CONSTRAINT `BusinessEntityPhone_ibfk_2` FOREIGN KEY (`BusinessEntityID`) REFERENCES `BusinessEntity` (`BusinessEntityID`);

--
-- Các ràng buộc cho bảng `ContactType`
--
ALTER TABLE `ContactType`
  ADD CONSTRAINT `ContactType_ibfk_1` FOREIGN KEY (`ContactTypeID`) REFERENCES `BusinessEntityContact` (`ContactTypeID`);

--
-- Các ràng buộc cho bảng `District`
--
ALTER TABLE `District`
  ADD CONSTRAINT `District_ibfk_1` FOREIGN KEY (`ProvinceID`) REFERENCES `Province` (`ProviceID`);

--
-- Các ràng buộc cho bảng `Employee`
--
ALTER TABLE `Employee`
  ADD CONSTRAINT `Employee_ibfk_1` FOREIGN KEY (`BusinessEntityID`) REFERENCES `BusinessEntity` (`BusinessEntityID`);

--
-- Các ràng buộc cho bảng `Person`
--
ALTER TABLE `Person`
  ADD CONSTRAINT `Person_ibfk_1` FOREIGN KEY (`BusinessEntityID`) REFERENCES `BusinessEntity` (`BusinessEntityID`);

--
-- Các ràng buộc cho bảng `Product`
--
ALTER TABLE `Product`
  ADD CONSTRAINT `Product_ibfk_1` FOREIGN KEY (`ProductSubcategoryID`) REFERENCES `ProductSubCategory` (`ProductSubCategoryID`);

--
-- Các ràng buộc cho bảng `ProductCategory`
--
ALTER TABLE `ProductCategory`
  ADD CONSTRAINT `ProductCategory_ibfk_1` FOREIGN KEY (`ProductCategoryID`) REFERENCES `ProductSubCategory` (`ProductCategoryID`);

--
-- Các ràng buộc cho bảng `ProductInventory`
--
ALTER TABLE `ProductInventory`
  ADD CONSTRAINT `ProductInventory_ibfk_1` FOREIGN KEY (`ProductID`) REFERENCES `Product` (`ProductID`);

--
-- Các ràng buộc cho bảng `ProductListPriceHistory`
--
ALTER TABLE `ProductListPriceHistory`
  ADD CONSTRAINT `ProductListPriceHistory_ibfk_1` FOREIGN KEY (`ProductID`) REFERENCES `Product` (`ProductID`);

--
-- Các ràng buộc cho bảng `ProductProductPhoto`
--
ALTER TABLE `ProductProductPhoto`
  ADD CONSTRAINT `ProductProductPhoto_ibfk_1` FOREIGN KEY (`ProductPhotoID`) REFERENCES `ProductPhoto` (`ProductPhotoID`),
  ADD CONSTRAINT `ProductProductPhoto_ibfk_2` FOREIGN KEY (`ProductID`) REFERENCES `Product` (`ProductID`);

--
-- Các ràng buộc cho bảng `ProductSubCategory`
--
ALTER TABLE `ProductSubCategory`
  ADD CONSTRAINT `ProductSubCategory_ibfk_1` FOREIGN KEY (`ProductCategoryID`) REFERENCES `ProductCategory` (`ProductCategoryID`),
  ADD CONSTRAINT `ProductSubCategory_ibfk_2` FOREIGN KEY (`ProductSubCategoryID`) REFERENCES `Product` (`ProductSubcategoryID`);

--
-- Các ràng buộc cho bảng `PurchaseOrderDetail`
--
ALTER TABLE `PurchaseOrderDetail`
  ADD CONSTRAINT `PurchaseOrderDetail_ibfk_1` FOREIGN KEY (`ProductID`) REFERENCES `Product` (`ProductID`),
  ADD CONSTRAINT `PurchaseOrderDetail_ibfk_2` FOREIGN KEY (`PurchaseOrderID`) REFERENCES `PurchaseOrderHeader` (`PurchaseOrderID`);

--
-- Các ràng buộc cho bảng `SaleOrderHeader`
--
ALTER TABLE `SaleOrderHeader`
  ADD CONSTRAINT `SaleOrderHeader_ibfk_1` FOREIGN KEY (`SalesOrderID`) REFERENCES `SalesOrderDetail` (`SalesOrderID`);

--
-- Các ràng buộc cho bảng `SalesOrderDetail`
--
ALTER TABLE `SalesOrderDetail`
  ADD CONSTRAINT `SalesOrderDetail_ibfk_1` FOREIGN KEY (`SalesOrderID`) REFERENCES `SaleOrderHeader` (`SalesOrderID`);

--
-- Các ràng buộc cho bảng `Vendor`
--
ALTER TABLE `Vendor`
  ADD CONSTRAINT `Vendor_ibfk_1` FOREIGN KEY (`BusinessEntityID`) REFERENCES `BusinessEntity` (`BusinessEntityID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
