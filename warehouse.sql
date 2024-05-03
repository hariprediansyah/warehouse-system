-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 03 Bulan Mei 2024 pada 17.22
-- Versi server: 10.4.32-MariaDB
-- Versi PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `warehouse`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `branch`
--

CREATE TABLE `branch` (
  `Code` varchar(100) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `UserInput` varchar(100) NOT NULL,
  `TimeInput` datetime NOT NULL,
  `UserEdit` varchar(100) DEFAULT NULL,
  `TimeEdit` datetime DEFAULT NULL,
  `IsActive` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `category`
--

CREATE TABLE `category` (
  `Code` varchar(100) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Description` varchar(500) NOT NULL,
  `UserInput` varchar(100) NOT NULL,
  `TimeInput` datetime NOT NULL,
  `UserEdit` varchar(100) DEFAULT NULL,
  `TimeEdit` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `product`
--

CREATE TABLE `product` (
  `Code` varchar(100) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Description` varchar(500) NOT NULL,
  `Category` varchar(100) NOT NULL,
  `UserInput` varchar(100) NOT NULL,
  `TimeInput` datetime NOT NULL,
  `UserEdit` varchar(100) DEFAULT NULL,
  `TimeEdit` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `transaction`
--

CREATE TABLE `transaction` (
  `ID` bigint(20) NOT NULL,
  `WarehouseCode` varchar(100) NOT NULL,
  `TransactionType` varchar(2) NOT NULL,
  `TransactionDate` date NOT NULL,
  `UserInput` varchar(100) NOT NULL,
  `TimeInput` datetime NOT NULL,
  `UserEdit` varchar(100) NOT NULL,
  `TimeEdit` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `transactiondetail`
--

CREATE TABLE `transactiondetail` (
  `ID` bigint(20) NOT NULL,
  `TransactionID` bigint(20) NOT NULL,
  `ProductCode` varchar(100) NOT NULL,
  `Quantity` bigint(20) NOT NULL,
  `UserInput` varchar(100) NOT NULL,
  `TimeInput` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `user`
--

CREATE TABLE `user` (
  `UserName` varchar(255) NOT NULL,
  `FullName` varchar(100) NOT NULL,
  `Role` varchar(100) NOT NULL,
  `BranchCode` varchar(20) DEFAULT NULL,
  `NoHP` varchar(100) NOT NULL,
  `UserInput` varchar(100) DEFAULT NULL,
  `TimeInput` datetime(6) DEFAULT NULL,
  `Email` varchar(100) NOT NULL,
  `IsActive` varchar(1) NOT NULL,
  `LastLogin` datetime(6) DEFAULT NULL,
  `Password` varchar(500) NOT NULL,
  `TimeEdit` datetime(6) DEFAULT NULL,
  `UserEdit` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `warehouse`
--

CREATE TABLE `warehouse` (
  `Code` varchar(100) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `BranchCode` varchar(100) NOT NULL,
  `Address` varchar(500) NOT NULL,
  `UserInput` varchar(100) NOT NULL,
  `TimeInput` datetime NOT NULL,
  `UserEdit` varchar(100) DEFAULT NULL,
  `TimeEdit` datetime DEFAULT NULL,
  `IsActive` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `branch`
--
ALTER TABLE `branch`
  ADD PRIMARY KEY (`Code`);

--
-- Indeks untuk tabel `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`Code`);

--
-- Indeks untuk tabel `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`Code`);

--
-- Indeks untuk tabel `transaction`
--
ALTER TABLE `transaction`
  ADD PRIMARY KEY (`ID`);

--
-- Indeks untuk tabel `transactiondetail`
--
ALTER TABLE `transactiondetail`
  ADD PRIMARY KEY (`ID`);

--
-- Indeks untuk tabel `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`UserName`);

--
-- Indeks untuk tabel `warehouse`
--
ALTER TABLE `warehouse`
  ADD PRIMARY KEY (`Code`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `transaction`
--
ALTER TABLE `transaction`
  MODIFY `ID` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT untuk tabel `transactiondetail`
--
ALTER TABLE `transactiondetail`
  MODIFY `ID` bigint(20) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
