CREATE DATABASE  IF NOT EXISTS `kosmoeye_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `kosmoeye_db`;
-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: kosmoeye_db
-- ------------------------------------------------------
-- Server version	8.4.5

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
-- Table structure for table `Artworks`
--

DROP TABLE IF EXISTS `Artworks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Artworks` (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Title` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FileUrl` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `AuthorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `IsFreeToUse` tinyint(1) NOT NULL,
  `IsDownloadable` tinyint(1) NOT NULL,
  `IsPaid` tinyint(1) NOT NULL,
  `Price` decimal(65,30) DEFAULT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Artworks`
--

LOCK TABLES `Artworks` WRITE;
/*!40000 ALTER TABLE `Artworks` DISABLE KEYS */;
INSERT INTO `Artworks` (`Id`, `Title`, `Description`, `FileUrl`, `AuthorId`, `IsFreeToUse`, `IsDownloadable`, `IsPaid`, `Price`, `CreatedAt`) VALUES ('16698183-0213-430f-a8f5-793c6fda3dbf','Nebulosa Rising','string','https://cdn.kosmoeye.com/artworks/nebula.png','15b38bc7-a2a1-4b59-9167-0ac538187a65',0,0,1,18.000000000000000000000000000000,'2025-07-06 05:29:00.239836'),('6e02564f-e4f6-4eeb-841a-78c4c00cb55d','Teste artwork','testando','string','3fa85f64-5717-4562-b3fc-2c963f66afa6',1,1,0,NULL,'2025-07-17 01:47:04.840006'),('dba1554c-06b5-4191-a6a6-cd6fe905e5e8','Excluir','Excluir Artwork','string','3fa85f64-5717-4562-b3fc-2c963f66afa6',1,1,0,NULL,'2025-07-21 02:46:35.652673');
/*!40000 ALTER TABLE `Artworks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Comments`
--

DROP TABLE IF EXISTS `Comments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Comments` (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `ArtworkId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Content` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Comments`
--

LOCK TABLES `Comments` WRITE;
/*!40000 ALTER TABLE `Comments` DISABLE KEYS */;
/*!40000 ALTER TABLE `Comments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `FavoriteArtworks`
--

DROP TABLE IF EXISTS `FavoriteArtworks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `FavoriteArtworks` (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `ArtworkId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `FavoriteArtworks`
--

LOCK TABLES `FavoriteArtworks` WRITE;
/*!40000 ALTER TABLE `FavoriteArtworks` DISABLE KEYS */;
INSERT INTO `FavoriteArtworks` (`Id`, `UserId`, `ArtworkId`, `CreatedAt`) VALUES ('25c942f5-96a9-4267-9db6-acff71fa3c1b','2fee4a5a-da68-47f7-9249-7b06edd87ce6','16698183-0213-430f-a8f5-793c6fda3dbf','2025-07-26 22:24:45.294414'),('b2f74df8-30de-4a7a-bca7-60c1feb40a41','15b38bc7-a2a1-4b59-9167-0ac538187a65','16698183-0213-430f-a8f5-793c6fda3dbf','2025-07-26 22:22:48.531662');
/*!40000 ALTER TABLE `FavoriteArtworks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Follows`
--

DROP TABLE IF EXISTS `Follows`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Follows` (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `FollowerId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `FollowedId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Follows`
--

LOCK TABLES `Follows` WRITE;
/*!40000 ALTER TABLE `Follows` DISABLE KEYS */;
INSERT INTO `Follows` (`Id`, `FollowerId`, `FollowedId`, `CreatedAt`) VALUES ('1c786049-6165-48f4-b969-af5f7f6cb9d2','15b38bc7-a2a1-4b59-9167-0ac538187a65','10d08f35-9107-4823-b900-eb4e06200334','2025-07-27 00:11:52.446188'),('3be5e1f3-331c-401f-8e09-754931b6f65b','15b38bc7-a2a1-4b59-9167-0ac538187a65','3fa85f64-5717-4562-b3fc-2c963f66afa6','2025-07-27 00:11:22.123135'),('c5f9a8cd-382c-4fbb-9e67-2f3286b4419e','15b38bc7-a2a1-4b59-9167-0ac538187a65','2fee4a5a-da68-47f7-9249-7b06edd87ce6','2025-07-26 23:23:24.699578');
/*!40000 ALTER TABLE `Follows` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Likes`
--

DROP TABLE IF EXISTS `Likes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Likes` (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `ArtworkId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `LikedAt` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Likes`
--

LOCK TABLES `Likes` WRITE;
/*!40000 ALTER TABLE `Likes` DISABLE KEYS */;
INSERT INTO `Likes` (`Id`, `UserId`, `ArtworkId`, `LikedAt`) VALUES ('c429a5cc-ab1f-4dd4-9686-c6264d50248d','15b38bc7-a2a1-4b59-9167-0ac538187a65','16698183-0213-430f-a8f5-793c6fda3dbf','2025-07-23 02:47:45.633031');
/*!40000 ALTER TABLE `Likes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `RefreshTokens`
--

DROP TABLE IF EXISTS `RefreshTokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `RefreshTokens` (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Token` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `ExpiresAt` datetime(6) NOT NULL,
  `RevokedAt` datetime(6) DEFAULT NULL,
  `CreatedByIp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `RevokedByIp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ReplacedByToken` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RefreshTokens_UserId` (`UserId`),
  CONSTRAINT `FK_RefreshTokens_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `RefreshTokens`
--

LOCK TABLES `RefreshTokens` WRITE;
/*!40000 ALTER TABLE `RefreshTokens` DISABLE KEYS */;
INSERT INTO `RefreshTokens` (`Id`, `Token`, `CreatedAt`, `ExpiresAt`, `RevokedAt`, `CreatedByIp`, `RevokedByIp`, `ReplacedByToken`, `UserId`) VALUES ('00b398dd-ddb3-47d3-9657-edf9baebf4a9','R+E7mb77u08SaLYGoFEvZkaM8Yo+7yVTb1NoqsgOD6ooLUOKXNwAHgBwa46Qwm83+seNWHdZnpbhFBXxdDh6yA==','2025-07-06 13:46:53.276032','2025-07-13 13:46:53.276031',NULL,'::1',NULL,NULL,'15b38bc7-a2a1-4b59-9167-0ac538187a65'),('04575eaa-17d3-4195-b263-b816eeb60be4','O0Na+RDrM06VasoInazJSf81HGeGP9yaVMy7mjWNuLuDVnqoW6r1jIQHTVse8+yN1mNc/aw1b3e2hgI5TVBRRg==','2025-07-26 23:22:26.087074','2025-08-02 23:22:26.086985',NULL,'::1',NULL,NULL,'15b38bc7-a2a1-4b59-9167-0ac538187a65'),('064e4fd2-1d15-497f-b530-fe43aff866b4','N2B6gIDE9nAXGWK4FIjHYDFJVvf0eF2jop1VibXoH0B0LX/8aA9UoTn04//WBoOlDof2/jHWTJKGOliksijYVA==','2025-07-02 02:31:02.553541','2025-07-09 02:31:02.553492',NULL,'::1',NULL,NULL,'3ecba18d-66b2-44fc-b925-88e048fa39e4'),('081c8642-d14b-43fd-a69b-138d536c4a07','OFDhIKDkdHSf9ci5Cbvio50jhxnunA/gokAcxpODResgZHFxevNdUsoMfIoM3smIdtcfdAYoKoCBFRlFEBqCIw==','2025-07-26 22:47:16.687637','2025-08-02 22:47:16.687520',NULL,'::1',NULL,NULL,'15b38bc7-a2a1-4b59-9167-0ac538187a65'),('17bb504f-f7ee-4ae6-9cc2-be2319fc459f','3+l7lv17Pjyt/3736W5/shkKeVj7rJqazQS4JMjkiP6PpLiTK1RwSy+c2EjpxJuBKf4vcWpmdhdqL73UCqYEqw==','2025-07-04 03:04:09.621024','2025-07-11 03:04:09.620965',NULL,'::1',NULL,NULL,'15b38bc7-a2a1-4b59-9167-0ac538187a65'),('1fc1ee6e-aedc-4bc5-9ff3-f498994bb5d8','gJAhCQilmRY1VKmumiyTFmpZfxHCZXuuTMo3me5nPAxF2vPnavcedxlISig85SN/XVle9Uy9xeNvPP6gV4sgpg==','2025-07-17 01:37:14.481850','2025-07-24 01:37:14.481802',NULL,'::1',NULL,NULL,'c8bdcfb3-e34a-4ad5-bef7-ca255b55e4b6'),('26c68602-dc6f-4273-abd1-5d31ab18c0e8','fcQh6NDuB8sx4umth74jWCXlTPUcEbkqM8A4+yToGDIDR05IGaYIsiRfnxl4PO0+g3mv+CgvvTyqz7dqBeQRDg==','2025-07-02 02:33:12.765198','2025-07-09 02:33:12.765097',NULL,'::1',NULL,NULL,'59b8aba8-73f0-4bee-a8d1-17c62b88a5e9'),('33c5d72b-a04b-43bb-8f44-8d440ba98ce8','+Ba/EPWO4bRn6Z/SVowqg/cwtrOkHF5PK94MsnWiw8cQBQT0RKA4WmK080dPX97KXadYjJSFGZ2GLPJ6TdjlvA==','2025-07-04 02:55:05.567363','2025-07-11 02:55:05.567306',NULL,'::1',NULL,NULL,'457dd774-06c4-4e83-9859-9f176f241f6d'),('5c4fa73e-7aa3-4a25-9ae8-aa7df4b1957f','88mllbp6k5ThkNvJxccBTDgv7DBF13aCMYOzud4rT5PWu06umBqoREUd6xH77MJD6jZom3pcAZx9nfyvd/rybQ==','2025-07-26 22:20:22.385711','2025-08-02 22:20:22.385611',NULL,'::1',NULL,NULL,'15b38bc7-a2a1-4b59-9167-0ac538187a65'),('5e6779c4-aa81-401a-beb1-c693f831838c','do8X4OuAkeP9gg07vw4IS6the9q5M875/ZPdtwxnCdR18QtYi1fEEanZgq9eWpWb85u/0YMm+cXlnbZXAMeXsQ==','2025-07-02 02:21:38.938350','2025-07-09 02:21:38.938296',NULL,'::1',NULL,NULL,'5effbe4a-3386-4325-a816-d6289cc61d23'),('742b65b4-7673-4dc3-8d5b-0cc4b7145af4','sMNZeyqLakhTBoMzuLpUyAXgPHAnBKTXTxBOmTQE5sS45SPUlGzjSQyld/bgpoRUtyiSX9Qr04XpQX7pXiZwFQ==','2025-07-02 02:36:15.818411','2025-07-09 02:36:15.818326',NULL,'::1',NULL,NULL,'7e4e7624-6743-473f-9f79-52f1f6ddecc1'),('773e8a96-2e3d-46ab-a5a5-1faec1befe0e','Iech20CVwVoOHFT6nR5walJfgYdTuDYbLuC9z4WIx/BFRnc44Z2aonFtLWb06wCnpNUAb+6HYxLqSRTI8Q6SWg==','2025-07-23 02:46:50.380305','2025-07-30 02:46:50.379923',NULL,'::1',NULL,NULL,'15b38bc7-a2a1-4b59-9167-0ac538187a65'),('7c356f36-bccd-4a09-beff-845f90c76af0','GatQApWKRLmxOZhzy5ihGOaeDQSX0LBcAk3PFI5ux1W9J+MkbJKoftrjrXxDNkP63vcZ1TVP+HvJ/s/NWT9SYg==','2025-07-26 22:23:56.334060','2025-08-02 22:23:56.334060',NULL,'::1',NULL,NULL,'2fee4a5a-da68-47f7-9249-7b06edd87ce6'),('81a635e0-711e-402e-ada3-92ec3840033a','3HmMseO5hYieIIM1cP4Z1ypqMyd9dKc7h9I1MI+Au3Y5bMZT7rg8k0C1RtsuRlLDkqaRhOGplMvupp/jpcCbVg==','2025-07-17 01:23:19.700916','2025-07-24 01:23:19.700840',NULL,'::1',NULL,NULL,'c8bdcfb3-e34a-4ad5-bef7-ca255b55e4b6'),('8e6abccc-e9e1-4f73-8613-1f6e504a8415','kyqJNmc91eEyxrb1d2tYt+L6QXHoWerX19PG3klzV5kbu+qfxSSLnM9nQ1bcz7JUunweYAmbhF78/fq5sSj0yA==','2025-07-17 02:02:11.473180','2025-07-24 02:02:11.473179',NULL,'::1',NULL,NULL,'c8bdcfb3-e34a-4ad5-bef7-ca255b55e4b6'),('93bacb10-8ba9-439f-a840-ba7cfd3ca607','0OF0opgjDwnzOf8Kol4xrUuI842AxmImZxWP4HhpCTyzdeFIpESk9NmCQXJEO4ldzH49okqnh/CNi1LgWdHTig==','2025-07-17 01:31:11.402054','2025-07-24 01:31:11.401965',NULL,'::1',NULL,NULL,'c8bdcfb3-e34a-4ad5-bef7-ca255b55e4b6'),('99ac6a5d-0c29-4b07-8052-181da076534b','ntk7uRCwCwv/qcWM8iMyfKBwD6oEUV2APZXKYKC+P3xeOzH6vcP/AfIhqE2vKLAfWbVAl7uIClGMOaJXI3gT2Q==','2025-07-21 02:47:51.356676','2025-07-28 02:47:51.356675',NULL,'::1',NULL,NULL,'15b38bc7-a2a1-4b59-9167-0ac538187a65'),('a8eb86c6-2fe3-42a8-a646-beff6b181c49','6bY/DRzA74YZbuFRZN/HnfWNPqQUQV+TLUFNERYUtkyFT/pBnshkcNxL5jS4TiwLe/k+JK7PxmQnAenPljUmzw==','2025-07-04 03:21:31.900345','2025-07-11 03:21:31.900273',NULL,'::1',NULL,NULL,'3ecba18d-66b2-44fc-b925-88e048fa39e4'),('abdd0065-dadb-4a89-9343-503a52659ab7','gc3HoCq6NQAI3B7YFsiNZ+33tMz2KS0ndKiUmVQitcvMSGmbxJUoyhRUqtTSTK9++3ReIrL0XKVdZmSMAfa24g==','2025-07-04 03:16:18.364762','2025-07-11 03:16:18.364672',NULL,'::1',NULL,NULL,'3ecba18d-66b2-44fc-b925-88e048fa39e4'),('bcc2a644-b5d7-40d3-a58a-7d2fc092bd87','cuLTj9oHgs/XySVXX5UXsp4AibguZ4VFcQlQsLs/S6B4u9VKONX/ZF4hgODdFtIWx6SEigyuUd0XuT2vf4mbYA==','2025-07-27 00:10:12.602511','2025-08-03 00:10:12.602442',NULL,'::1',NULL,NULL,'15b38bc7-a2a1-4b59-9167-0ac538187a65'),('d1d4eaef-6344-4bae-9dfc-8e44483ce39f','m4jJ3ePu62YRdOeNU/fSpcCPMIyTUjkiJdMuxR1DK5CkK6Wfcg4r3+gglUmpDWrWvdVz8xFi6dfnVTwM6nvGiQ==','2025-07-26 21:45:39.549718','2025-08-02 21:45:39.549658',NULL,'::1',NULL,NULL,'15b38bc7-a2a1-4b59-9167-0ac538187a65'),('d6ee3e1a-6f0e-4332-8c14-0c2924f532f6','FQ01HRKItIfoFeln1VtPwCpesAhWtMIiLXVGNIKA87weInxfGKxr9qNn+i3dlPqBfrFPOUDWXC7PtmvOl2qMCQ==','2025-07-06 13:45:45.585813','2025-07-13 13:45:45.585755',NULL,'::1',NULL,NULL,'15b38bc7-a2a1-4b59-9167-0ac538187a65'),('e9d543b0-b485-49d3-8da8-017c21bea4db','Xka+n05DLZjKH1WKIywMNcsbbGLv8h83cI07Skzwp3GjerFV+kPjQwbijEXDBHFPzlohJsAvpwUb7DzuFJb35g==','2025-07-17 01:59:57.958451','2025-07-24 01:59:57.958450',NULL,'::1',NULL,NULL,'15b38bc7-a2a1-4b59-9167-0ac538187a65'),('ed12b932-3a90-456d-a179-e2500f203d68','elGXln6wMVgGi/z/NmzIWJTO8LqGC0NH1f6lKeUrjTegmMqpEESJqNXTxPY2t4mWxmihCbjl5TwvejEuOesYkQ==','2025-07-06 05:27:39.032207','2025-07-13 05:27:39.032107',NULL,'::1',NULL,NULL,'15b38bc7-a2a1-4b59-9167-0ac538187a65'),('ee7d032a-36ef-462b-9ba1-66a9f685b6a9','DkHakl2Ao5fubdw1sCSAztpOWYAycvB+5cu1fjB2ysHpsP/ZHXUZ0sNKTCSjhOrfJfhVqbM17l9SqWDMg2sr9Q==','2025-07-21 02:42:07.994328','2025-07-28 02:42:07.994256',NULL,'::1',NULL,NULL,'15b38bc7-a2a1-4b59-9167-0ac538187a65'),('f127ae73-33cf-4686-ac17-9a6cb9e6e436','ZXrOat9Oklw0g8EKMfTTMwXrmNP7bwOLxwLfBbmcca+yVPDQfC4W5C5CO2Rb8g2jy/uMosEIuyFeniiiPKnFXw==','2025-07-26 22:22:20.737078','2025-08-02 22:22:20.737077',NULL,'::1',NULL,NULL,'15b38bc7-a2a1-4b59-9167-0ac538187a65'),('fed6e058-af35-4c30-9b91-d004ad3a079c','zawUQDhOwF/efky9FK1/mSNYAA9fpn2aFPYrmnxVOCtuzLZ78bIEvYt+mtrssTNQTqT/WWt5fAFzZxPuxWWHjQ==','2025-07-17 01:57:05.133888','2025-07-24 01:57:05.133836',NULL,'::1',NULL,NULL,'c8bdcfb3-e34a-4ad5-bef7-ca255b55e4b6'),('ff735323-793f-4193-98c6-cffbd57834f1','vD5PmScENY907KZ5sLk2dbxxYuO8Alm65d1edYRrIn2pw2tHLlKo/hmyZxdj105tX3A8nlkBpsTrc+0UN1xqFQ==','2025-07-26 21:23:21.403939','2025-08-02 21:23:21.403823',NULL,'::1',NULL,NULL,'15b38bc7-a2a1-4b59-9167-0ac538187a65');
/*!40000 ALTER TABLE `RefreshTokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Users`
--

DROP TABLE IF EXISTS `Users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Users` (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Username` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Bio` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PictureUrl` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Users`
--

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;
INSERT INTO `Users` (`Id`, `Username`, `Email`, `PasswordHash`, `Bio`, `PictureUrl`, `CreatedAt`) VALUES ('10d08f35-9107-4823-b900-eb4e06200334','createdAt','created@gmail.com','$2a$11$9DTTQTFBPfVa4UP1dY6VkeclkEH0cb5QnDXyTga3zem40TxzOBpMS',NULL,NULL,'2025-07-11 02:15:44.894141'),('15b38bc7-a2a1-4b59-9167-0ac538187a65','jepas','joao@gmail.com','$2a$11$VaFc/GeVQRY/BrhW7BoQeeZYIy2mwWCevaUuM5fQJR3qMwZAu.xg2','string','string','0001-01-01 00:00:00.000000'),('2a42ff6a-42e7-4458-bbf2-a1f3e6790530','joaoteste','joaoteste@gmail.com','$2a$11$SqByhkshpbf.UsPq76kioODNgkmLha0JRfy3FtKGCzevBEYK2Ghgq',NULL,NULL,'0001-01-01 00:00:00.000000'),('2fee4a5a-da68-47f7-9249-7b06edd87ce6','jupus','jupus@gmail.com','$2a$11$QJbj11mBe5q0Kjb4WxJs/ut.9rUsEXAXCrfW1P1Y5y1pMG5Oo.2qC',NULL,NULL,'0001-01-01 00:00:00.000000'),('3ecba18d-66b2-44fc-b925-88e048fa39e4','testeTrocou','testinho@gmai.com','$2a$11$CYouEzQWYtjUG7zaQ2bgQeTs3pQgvMejANFrNRmJ1wmDh/5SHMa0m','string','string','0001-01-01 00:00:00.000000'),('457dd774-06c4-4e83-9859-9f176f241f6d','testejwt','jwt@gmail.com','$2a$11$OJqJCMz5CLQ7wJjFXZAlb.InCielqpX3ZNWJBmN3YW3.cDD8RCV72',NULL,NULL,'0001-01-01 00:00:00.000000'),('59b8aba8-73f0-4bee-a8d1-17c62b88a5e9','admin','admin@admin.co.','$2a$11$mqGYznYwncimIGMOveW77eh0mMIPE0ePx94tbsuIkuTc143TXowxi',NULL,NULL,'0001-01-01 00:00:00.000000'),('5effbe4a-3386-4325-a816-d6289cc61d23','batman','batman@gmail.com','$2a$11$OWaWN9.PW.l4AAZ4h5nBte0ApRrFjOXjmPmdBy4SZOu.gF99i.EEe',NULL,NULL,'0001-01-01 00:00:00.000000'),('653ae060-e581-4adf-bda9-9e1ccbc2471c','lilly','chaestetic@gmail.com','$2a$11$PRVZN450hKpKJDLcS.0UVezQhd43oTwoAJU/Xym.ZHqWRQBli.cfa',NULL,NULL,'2025-07-10 23:54:26.499369'),('6b2016b4-6224-4c76-81c4-40d50384d82d','rafaelly','rafaelly@gmail.com','$2a$11$RPq/MZs5QHNCUVi404ZqsuS6YJhjYKZjmWnmG1nN55/D/N1iBKUES',NULL,NULL,'0001-01-01 00:00:00.000000'),('7e4e7624-6743-473f-9f79-52f1f6ddecc1','teste','teste@','$2a$11$dilCnDL1Q9JwXYZooJZ/HurLdIF8heRJnZUaC0yhEH3Dbmc1QKFsK',NULL,NULL,'0001-01-01 00:00:00.000000'),('8a886a56-bd20-42ee-bd54-7921b9afa765','ronaldo','ronaldo@gmail.com','$2a$11$bcfuJnB3dL8WkzBZL2xOUOxtt7yZoOdYugrbRRkqkn465xE2vcM.6',NULL,NULL,'0001-01-01 00:00:00.000000'),('bddf47e1-7f31-43e2-adab-2f47ff24043b','jetta','jetta@gmail.com','$2a$11$Xw9zX5QLN9xil6OI8WQAAewo95vV/DgRHOJcDNGJiw7jcrrWQTVaC',NULL,NULL,'0001-01-01 00:00:00.000000'),('c871bb35-6379-4879-b134-eb2337f1f67b','admin','admin@gmail.com','$2a$11$Y4/c8QQGD3c.k7OaeKgiCuho4iqwkrFnshWPtJ9pu0iSyYJhZ98fm',NULL,NULL,'0001-01-01 00:00:00.000000'),('c8bdcfb3-e34a-4ad5-bef7-ca255b55e4b6','João Victor','joao123@gmail.com','$2a$11$mCKaU2lKOYxEuawYGBCSjuqhJ8P.S/5ZBX8Y7IHy4./0diuLWC5HO',NULL,NULL,'2025-07-17 01:23:02.130527'),('e89aee55-36d3-4e81-9739-0df0a392ea57','data teste','data@gmail.com','$2a$11$dMxwO13CyVdUKDhKcoZq7uF.C.oDk9SvrPr6L68BwJilQ7wH4Szs.',NULL,NULL,'2025-07-11 02:21:23.617451');
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES ('20250628045624_InitialMigration','8.0.13'),('20250628154035_AddAllEntities','8.0.13'),('20250701233548_ConfigureRefreshToken','8.0.13'),('20250710231328_AddCreatedAtUser','8.0.13'),('20250723022617_RefactoringCreatedAtToLikedAt','8.0.13');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'kosmoeye_db'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-07-26 23:05:12
