-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 23, 2020 at 08:17 AM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.2.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `isa_uts`
--

-- --------------------------------------------------------

--
-- Table structure for table `barang`
--

CREATE TABLE `barang` (
  `idBarang` int(11) NOT NULL,
  `idPenjual` int(11) NOT NULL,
  `jenisBarang` varchar(45) DEFAULT NULL,
  `namaBarang` varchar(45) DEFAULT NULL,
  `stok` int(11) DEFAULT NULL,
  `harga` double DEFAULT NULL,
  `deskripsi` varchar(150) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `barang`
--

INSERT INTO `barang` (`idBarang`, `idPenjual`, `jenisBarang`, `namaBarang`, `stok`, `harga`, `deskripsi`) VALUES
(1, 3, 'Buku', 'Bukan Lagi Manusia, Tetapi Hewan Berkaki Dua', 50, 200000, 'Karya dari Dazai Ozamu');

-- --------------------------------------------------------

--
-- Table structure for table `detilbarang`
--

CREATE TABLE `detilbarang` (
  `idUser` int(11) NOT NULL,
  `idBarang` int(11) NOT NULL,
  `idPenjual` int(11) NOT NULL,
  `noNota` varchar(15) NOT NULL,
  `jumlah` int(11) DEFAULT NULL,
  `subTotal` double DEFAULT NULL,
  `keterangan` varchar(105) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `promo`
--

CREATE TABLE `promo` (
  `kodePromo` int(11) NOT NULL,
  `potongan` double DEFAULT NULL,
  `batasTanggalBerlaku` datetime DEFAULT NULL
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
  ADD PRIMARY KEY (`idBarang`,`idPenjual`),
  ADD KEY `fk_barang_user1_idx` (`idPenjual`);

--
-- Indexes for table `detilbarang`
--
ALTER TABLE `detilbarang`
  ADD PRIMARY KEY (`idUser`,`idBarang`,`idPenjual`,`noNota`),
  ADD KEY `fk_user_has_barang_user1_idx` (`idUser`),
  ADD KEY `fk_detilBarang_transaksi1_idx` (`noNota`),
  ADD KEY `fk_detilBarang_barang1_idx` (`idBarang`,`idPenjual`);

--
-- Indexes for table `promo`
--
ALTER TABLE `promo`
  ADD PRIMARY KEY (`kodePromo`);

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
-- Constraints for table `barang`
--
ALTER TABLE `barang`
  ADD CONSTRAINT `fk_barang_user1` FOREIGN KEY (`idPenjual`) REFERENCES `user` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `detilbarang`
--
ALTER TABLE `detilbarang`
  ADD CONSTRAINT `fk_detilBarang_barang1` FOREIGN KEY (`idBarang`,`idPenjual`) REFERENCES `barang` (`idBarang`, `idPenjual`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_detilBarang_transaksi1` FOREIGN KEY (`noNota`) REFERENCES `transaksi` (`noNota`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_user_has_barang_user1` FOREIGN KEY (`idUser`) REFERENCES `user` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
