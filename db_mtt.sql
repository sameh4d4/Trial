-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 27, 2020 at 05:16 PM
-- Server version: 10.4.13-MariaDB
-- PHP Version: 7.4.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbmtt`
--

-- --------------------------------------------------------

--
-- Table structure for table `barang`
--

CREATE TABLE `barang` (
  `idBarang` int(11) NOT NULL,
  `jenisBarang` varchar(45) DEFAULT NULL,
  `namaBarang` varchar(45) DEFAULT NULL,
  `stok` int(11) DEFAULT NULL,
  `harga` double DEFAULT NULL,
  `deskripsi` varchar(150) DEFAULT NULL,
  `supplier` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `barang`
--

INSERT INTO `barang` (`idBarang`, `jenisBarang`, `namaBarang`, `stok`, `harga`, `deskripsi`, `supplier`) VALUES
(1, 'Buku', 'Bukan Lagi Manusia, Tetapi Hewan Berkaki Dua', 50, 200000, 'Karya dari Dazai Ozamu', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `detilbarang`
--

CREATE TABLE `detilbarang` (
  `idBarang` int(11) NOT NULL,
  `noNota` varchar(15) NOT NULL,
  `jumlah` int(11) DEFAULT NULL,
  `subTotal` double DEFAULT NULL,
  `keterangan` varchar(105) NOT NULL,
  `kasir_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `transaksi`
--

CREATE TABLE `transaksi` (
  `noNota` varchar(15) NOT NULL,
  `tanggal` datetime DEFAULT NULL,
  `total` double DEFAULT NULL,
  `ppn` double DEFAULT NULL,
  `grandTotal` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `username` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `role` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id`, `username`, `password`, `role`, `name`) VALUES
(1, 'root', NULL, 'admin', 'abednegojoshua'),
(2, 'albert', 'nagasaki45', 'pembeli', 'albertyohanes'),
(3, 'anthony', 'lllhaoslll', 'penjual', 'jerichoanthony'),
(5, 'anang', 'anu', 'penjual', 'aneandra'),
(6, 'monet', 'yuki', 'penjual', 'yukiyukinomi'),
(7, 'albertlau', 'erweom89ek', 'pembeli', 'albert');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `barang`
--
ALTER TABLE `barang`
  ADD PRIMARY KEY (`idBarang`);

--
-- Indexes for table `detilbarang`
--
ALTER TABLE `detilbarang`
  ADD PRIMARY KEY (`keterangan`),
  ADD KEY `fk_detilBarang_transaksi1_idx` (`noNota`),
  ADD KEY `fk_detilBarang_barang1_idx` (`idBarang`),
  ADD KEY `fk_detilbarang_User1_idx` (`kasir_id`);

--
-- Indexes for table `transaksi`
--
ALTER TABLE `transaksi`
  ADD PRIMARY KEY (`noNota`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `barang`
--
ALTER TABLE `barang`
  MODIFY `idBarang` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `detilbarang`
--
ALTER TABLE `detilbarang`
  ADD CONSTRAINT `fk_detilBarang_barang1` FOREIGN KEY (`idBarang`) REFERENCES `barang` (`idBarang`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_detilBarang_transaksi1` FOREIGN KEY (`noNota`) REFERENCES `transaksi` (`noNota`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_detilbarang_User1` FOREIGN KEY (`kasir_id`) REFERENCES `user` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
