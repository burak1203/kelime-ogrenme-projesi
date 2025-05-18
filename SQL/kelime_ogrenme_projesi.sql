CREATE DATABASE  IF NOT EXISTS `kelime_ogrenme_projesi` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `kelime_ogrenme_projesi`;
-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: localhost    Database: kelime_ogrenme_projesi
-- ------------------------------------------------------
-- Server version	8.0.40

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Temporary view structure for view `aktifkullanicilarview`
--

DROP TABLE IF EXISTS `aktifkullanicilarview`;
/*!50001 DROP VIEW IF EXISTS `aktifkullanicilarview`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `aktifkullanicilarview` AS SELECT 
 1 AS `KullaniciID`,
 1 AS `KullaniciAdi`,
 1 AS `Eposta`,
 1 AS `Ad`,
 1 AS `Soyad`,
 1 AS `Durum`,
 1 AS `Rol`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `kategoriler`
--

DROP TABLE IF EXISTS `kategoriler`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kategoriler` (
  `KategoriID` int NOT NULL AUTO_INCREMENT,
  `KategoriAdi` varchar(100) NOT NULL,
  PRIMARY KEY (`KategoriID`),
  UNIQUE KEY `KategoriAdi` (`KategoriAdi`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kategoriler`
--

LOCK TABLES `kategoriler` WRITE;
/*!40000 ALTER TABLE `kategoriler` DISABLE KEYS */;
INSERT INTO `kategoriler` VALUES (2,'Akademik Kelimeler'),(3,'Gunluk Kelimeler'),(1,'Is Ingilizcesi');
/*!40000 ALTER TABLE `kategoriler` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `kelimeistatistikleriview`
--

DROP TABLE IF EXISTS `kelimeistatistikleriview`;
/*!50001 DROP VIEW IF EXISTS `kelimeistatistikleriview`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `kelimeistatistikleriview` AS SELECT 
 1 AS `KelimeAdi`,
 1 AS `Tur`,
 1 AS `Tanim`,
 1 AS `KullanilmaSayisi`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `kelimekategorileri`
--

DROP TABLE IF EXISTS `kelimekategorileri`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kelimekategorileri` (
  `KelimeID` int NOT NULL,
  `Tur` varchar(50) NOT NULL,
  PRIMARY KEY (`KelimeID`),
  CONSTRAINT `kelimekategorileri_ibfk_1` FOREIGN KEY (`KelimeID`) REFERENCES `kelimeler` (`KelimeID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kelimekategorileri`
--

LOCK TABLES `kelimekategorileri` WRITE;
/*!40000 ALTER TABLE `kelimekategorileri` DISABLE KEYS */;
INSERT INTO `kelimekategorileri` VALUES (1,'İsim'),(2,'İsim'),(3,'İsim'),(4,'İsim'),(5,'İsim'),(6,'İsim'),(7,'İsim'),(8,'İsim'),(9,'İsim'),(10,'İsim'),(11,'Fiil'),(12,'Sıfat'),(13,'Fiil'),(14,'Fiil'),(15,'Fiil'),(16,'Fiil'),(17,'Fiil'),(18,'Fiil'),(19,'Fiil'),(20,'Fiil'),(21,'Sıfat'),(22,'Sıfat'),(23,'Sıfat'),(24,'Sıfat'),(25,'Sıfat'),(26,'Sıfat'),(27,'Sıfat'),(28,'Sıfat'),(29,'Sıfat'),(31,'İsim'),(32,'sad');
/*!40000 ALTER TABLE `kelimekategorileri` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kelimeler`
--

DROP TABLE IF EXISTS `kelimeler`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kelimeler` (
  `KelimeID` int NOT NULL AUTO_INCREMENT,
  `KelimeAdi` varchar(100) NOT NULL,
  `Tanim` text,
  `Tur` varchar(50) DEFAULT NULL,
  `OrnekCumle` text,
  PRIMARY KEY (`KelimeID`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kelimeler`
--

LOCK TABLES `kelimeler` WRITE;
/*!40000 ALTER TABLE `kelimeler` DISABLE KEYS */;
INSERT INTO `kelimeler` VALUES (1,'Table','Masa','İsim','The book is on the table...'),(2,'Chair','Sandalye','İsim','He sat on the chair.'),(3,'Window','Pencere','İsim','The window is open.'),(4,'Book','Kitap','İsim','She is reading a book.'),(5,'Car','Araba','İsim','I bought a new car yesterday.'),(6,'House','Ev','İsim','We live in a big house.'),(7,'Dog','Köpek','İsim','The dog is barking loudly.'),(8,'Cat','Kedi','İsim','The cat is sleeping under the table.'),(9,'Tree','Ağaç','İsim','There is a tall tree in the garden.'),(10,'School','Okul','İsim','The children are going to school.'),(11,'Run','Koşmak','Fiil','He runs very fast.'),(12,'Beautiful','Güzel','Sıfat','This is a beautiful day.'),(13,'Eat','Yemek','Fiil','We eat dinner at 7 pm.'),(14,'Sleep','Uyumak','Fiil','I usually sleep for 8 hours.'),(15,'Walk','Yürümek','Fiil','He walks to work every morning.'),(16,'Write','Yazmak','Fiil','She writes in her diary every night.'),(17,'Speak','Konuşmak','Fiil','They speak English very well.'),(18,'Read','Okumak','Fiil','I read a lot of books.'),(19,'Drink','İçmek','Fiil','He drinks coffee every morning.'),(20,'Cook','Yemek pişirmek','Fiil','She cooks delicious meals.'),(21,'Happy','Mutlu','Sıfat','She is a very happy person.'),(22,'Sad','Üzgün','Sıfat','He looks sad today.'),(23,'Fast','Hızlı','Sıfat','This car is very fast.'),(24,'Slow','Yavaş','Sıfat','The old man walks slow.'),(25,'Hot','Sıcak','Sıfat','The soup is too hot.'),(26,'Cold','Soğuk','Sıfat','The weather is very cold today.'),(27,'Beautiful','Güzel','Sıfat','This is a beautiful day.'),(28,'Tall','Uzun','Sıfat','He is a tall basketball player.'),(29,'Short','Kısa','Sıfat','The story is short but interesting.'),(31,'Door','Kapı','İsim','Close the door.'),(32,'Stone','taş','sad','sdasda\r\n'),(33,'0','0','0','0'),(34,'0','0','0','0'),(35,'sa','dsa','sda','sda');
/*!40000 ALTER TABLE `kelimeler` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kullaniciilerlemesi`
--

DROP TABLE IF EXISTS `kullaniciilerlemesi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kullaniciilerlemesi` (
  `IlerlemeID` int NOT NULL AUTO_INCREMENT,
  `KullaniciID` int NOT NULL,
  `KelimeID` int NOT NULL,
  `Durum` varchar(50) NOT NULL,
  PRIMARY KEY (`IlerlemeID`),
  KEY `idx_kullaniciID` (`KullaniciID`),
  KEY `idx_kelimeID` (`KelimeID`),
  CONSTRAINT `kullaniciilerlemesi_ibfk_1` FOREIGN KEY (`KullaniciID`) REFERENCES `kullanicilar` (`KullaniciID`) ON DELETE CASCADE,
  CONSTRAINT `kullaniciilerlemesi_ibfk_2` FOREIGN KEY (`KelimeID`) REFERENCES `kelimeler` (`KelimeID`) ON DELETE CASCADE,
  CONSTRAINT `kullaniciilerlemesi_chk_1` CHECK ((`Durum` in (_utf8mb4'Ogrenildi',_utf8mb4'TekrarGerekli',_utf8mb4'Bilinmiyor')))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kullaniciilerlemesi`
--

LOCK TABLES `kullaniciilerlemesi` WRITE;
/*!40000 ALTER TABLE `kullaniciilerlemesi` DISABLE KEYS */;
/*!40000 ALTER TABLE `kullaniciilerlemesi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kullanicilar`
--

DROP TABLE IF EXISTS `kullanicilar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kullanicilar` (
  `KullaniciID` int NOT NULL AUTO_INCREMENT,
  `KullaniciAdi` varchar(50) NOT NULL,
  `Sifre` varchar(255) NOT NULL,
  `Eposta` varchar(100) NOT NULL,
  `TCKimlik` char(11) NOT NULL,
  `Ad` varchar(50) DEFAULT NULL,
  `Soyad` varchar(50) DEFAULT NULL,
  `DogumTarihi` date DEFAULT NULL,
  `Durum` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT 'Aktif',
  `Rol` varchar(50) DEFAULT 'Kullanici',
  PRIMARY KEY (`KullaniciID`),
  UNIQUE KEY `KullaniciAdi` (`KullaniciAdi`),
  UNIQUE KEY `Eposta` (`Eposta`),
  UNIQUE KEY `TCKimlik` (`TCKimlik`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kullanicilar`
--

LOCK TABLES `kullanicilar` WRITE;
/*!40000 ALTER TABLE `kullanicilar` DISABLE KEYS */;
INSERT INTO `kullanicilar` VALUES (1,'kullanici1','hashedpassword1','kullanici1@ornek.com','12345678901','Ahmet','Yilmaz','1990-01-01','Aktif','Kullanici'),(4,'admin','admin123','admin@example.com','12345678902','Admin','User','1990-01-01','Aktif','Admin'),(14,'burak','burak123','burak@example.com','40195541582','Burak Ali','Çelik','2003-05-03','Aktif','Kullanici');
/*!40000 ALTER TABLE `kullanicilar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `kullaniciperformansview`
--

DROP TABLE IF EXISTS `kullaniciperformansview`;
/*!50001 DROP VIEW IF EXISTS `kullaniciperformansview`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `kullaniciperformansview` AS SELECT 
 1 AS `KullaniciAdi`,
 1 AS `ToplamQuiz`,
 1 AS `OrtalamaPuan`,
 1 AS `EnYuksekPuan`,
 1 AS `EnDusukPuan`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `kullaniciquizsonuclariview`
--

DROP TABLE IF EXISTS `kullaniciquizsonuclariview`;
/*!50001 DROP VIEW IF EXISTS `kullaniciquizsonuclariview`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `kullaniciquizsonuclariview` AS SELECT 
 1 AS `KullaniciAdi`,
 1 AS `QuizID`,
 1 AS `Puan`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `quizler`
--

DROP TABLE IF EXISTS `quizler`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `quizler` (
  `QuizID` int NOT NULL AUTO_INCREMENT,
  `KullaniciID` int NOT NULL,
  `Puan` int NOT NULL,
  `Tarih` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DogruSayisi` int NOT NULL DEFAULT '0',
  `ToplamSoru` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`QuizID`),
  KEY `KullaniciID` (`KullaniciID`),
  CONSTRAINT `quizler_ibfk_1` FOREIGN KEY (`KullaniciID`) REFERENCES `kullanicilar` (`KullaniciID`) ON DELETE CASCADE,
  CONSTRAINT `quizler_chk_1` CHECK ((`Puan` between 0 and 100))
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quizler`
--

LOCK TABLES `quizler` WRITE;
/*!40000 ALTER TABLE `quizler` DISABLE KEYS */;
INSERT INTO `quizler` VALUES (1,1,60,'2025-01-06 01:22:30',0,0),(2,4,0,'2025-01-06 01:22:30',0,0),(3,1,80,'2025-01-06 02:34:06',0,0),(4,4,100,'2025-01-06 02:38:56',0,0),(5,4,100,'2025-01-06 02:39:19',0,0),(8,4,80,'2025-01-06 03:29:51',0,0),(9,4,90,'2025-01-06 03:34:57',0,0),(10,1,100,'2025-01-06 03:37:22',0,0),(11,1,20,'2025-01-06 03:46:51',0,0),(12,1,0,'2025-01-06 03:49:45',0,0),(13,1,3,'2025-01-06 03:49:57',0,0),(14,1,0,'2025-01-06 03:53:35',0,0),(15,1,10,'2025-01-06 03:55:00',0,0),(16,4,40,'2025-01-06 03:58:31',4,10),(17,1,90,'2025-01-06 03:59:46',9,10),(18,4,10,'2025-01-06 04:04:12',1,10),(19,4,10,'2025-01-06 06:05:45',0,0),(22,4,100,'2025-01-07 12:47:44',10,10),(25,4,70,'2025-01-29 18:09:19',7,10),(26,4,0,'2025-01-29 18:09:57',0,10);
/*!40000 ALTER TABLE `quizler` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `sonquizlerview`
--

DROP TABLE IF EXISTS `sonquizlerview`;
/*!50001 DROP VIEW IF EXISTS `sonquizlerview`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `sonquizlerview` AS SELECT 
 1 AS `QuizID`,
 1 AS `KullaniciAdi`,
 1 AS `Puan`,
 1 AS `DogruSayisi`,
 1 AS `ToplamSoru`,
 1 AS `Tarih`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `aktifkullanicilarview`
--

/*!50001 DROP VIEW IF EXISTS `aktifkullanicilarview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `aktifkullanicilarview` AS select `kullanicilar`.`KullaniciID` AS `KullaniciID`,`kullanicilar`.`KullaniciAdi` AS `KullaniciAdi`,`kullanicilar`.`Eposta` AS `Eposta`,`kullanicilar`.`Ad` AS `Ad`,`kullanicilar`.`Soyad` AS `Soyad`,`kullanicilar`.`Durum` AS `Durum`,`kullanicilar`.`Rol` AS `Rol` from `kullanicilar` where (`kullanicilar`.`Durum` = 'Aktif') order by `kullanicilar`.`KullaniciAdi` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `kelimeistatistikleriview`
--

/*!50001 DROP VIEW IF EXISTS `kelimeistatistikleriview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `kelimeistatistikleriview` AS select `k`.`KelimeAdi` AS `KelimeAdi`,`k`.`Tur` AS `Tur`,`k`.`Tanim` AS `Tanim`,count(`q`.`QuizID`) AS `KullanilmaSayisi` from (`kelimeler` `k` left join `quizler` `q` on((`k`.`KelimeID` = `q`.`QuizID`))) group by `k`.`KelimeID`,`k`.`KelimeAdi`,`k`.`Tur`,`k`.`Tanim` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `kullaniciperformansview`
--

/*!50001 DROP VIEW IF EXISTS `kullaniciperformansview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `kullaniciperformansview` AS select `k`.`KullaniciAdi` AS `KullaniciAdi`,count(`q`.`QuizID`) AS `ToplamQuiz`,avg(`q`.`Puan`) AS `OrtalamaPuan`,max(`q`.`Puan`) AS `EnYuksekPuan`,min(`q`.`Puan`) AS `EnDusukPuan` from (`kullanicilar` `k` left join `quizler` `q` on((`k`.`KullaniciID` = `q`.`KullaniciID`))) group by `k`.`KullaniciID`,`k`.`KullaniciAdi` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `kullaniciquizsonuclariview`
--

/*!50001 DROP VIEW IF EXISTS `kullaniciquizsonuclariview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `kullaniciquizsonuclariview` AS select `k`.`KullaniciAdi` AS `KullaniciAdi`,`q`.`QuizID` AS `QuizID`,`q`.`Puan` AS `Puan` from (`quizler` `q` join `kullanicilar` `k` on((`q`.`KullaniciID` = `k`.`KullaniciID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `sonquizlerview`
--

/*!50001 DROP VIEW IF EXISTS `sonquizlerview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `sonquizlerview` AS select `q`.`QuizID` AS `QuizID`,`k`.`KullaniciAdi` AS `KullaniciAdi`,`q`.`Puan` AS `Puan`,`q`.`DogruSayisi` AS `DogruSayisi`,`q`.`ToplamSoru` AS `ToplamSoru`,`q`.`Tarih` AS `Tarih` from (`quizler` `q` join `kullanicilar` `k` on((`q`.`KullaniciID` = `k`.`KullaniciID`))) order by `q`.`Tarih` desc limit 10 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-18 22:55:28
