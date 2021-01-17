-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Ven 11 Décembre 2020 à 09:33
-- Version du serveur :  5.6.17
-- Version de PHP :  5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données :  `commande`
--

-- --------------------------------------------------------

--
-- Structure de la table `category`
--

CREATE TABLE IF NOT EXISTS `category` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `Category` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Contenu de la table `category`
--

INSERT INTO `category` (`id`, `Category`) VALUES
(1, '3 Mbps'),
(2, '5 Mbps'),
(3, '8 Mbps'),
(4, '10 Mbps');

-- --------------------------------------------------------

--
-- Structure de la table `commande`
--

CREATE TABLE IF NOT EXISTS `commande` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `Connexion` varchar(50) NOT NULL,
  `Description` varchar(50) NOT NULL,
  `Prix` varchar(50) NOT NULL,
  `Client` varchar(50) NOT NULL,
  `Abonnement` varchar(50) NOT NULL,
  `Expiration` varchar(50) NOT NULL,
  `Paiement` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=10 ;

--
-- Contenu de la table `commande`
--

INSERT INTO `commande` (`id`, `Connexion`, `Description`, `Prix`, `Client`, `Abonnement`, `Expiration`, `Paiement`) VALUES
(1, 'Résidentiel', 'pour utilisation familiale', '100 000', 'Marcel', '2020-12-10', '2020-12-10', 'Cash'),
(5, 'Standard', 'pour petit bureau', '250 000', 'Hope', '0000-00-00', '2020-12-02', 'Cash'),
(6, 'Standard Plus', 'Connexion coorporate', '500 000', 'SAMUEL', '0000-00-00', 'December 9, 2020', 'Chèque'),
(7, 'Standard', 'Connexion coorporate', '500 000', 'dd', '0000-00-00', 'January 8, 2021', 'Chèque'),
(8, 'Standard Plus', 'Connexion coorporate', '500 000', 'DAVID', 'December 10, 2020', 'January 9, 2021', 'Cash'),
(9, 'Standard', 'pour petit bureau', '500 000', 'OSAO', 'December 11, 2020', 'January 10, 2021', 'Chèque');

-- --------------------------------------------------------

--
-- Structure de la table `description`
--

CREATE TABLE IF NOT EXISTS `description` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `description` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Contenu de la table `description`
--

INSERT INTO `description` (`id`, `description`) VALUES
(1, 'Pour Utilisation familiale'),
(2, 'pour petit bureau'),
(3, 'Connexion coorporate'),
(4, 'pour bureau à taille moyenne');

-- --------------------------------------------------------

--
-- Structure de la table `login`
--

CREATE TABLE IF NOT EXISTS `login` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `task` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `ido` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Contenu de la table `login`
--

INSERT INTO `login` (`id`, `name`, `task`, `username`, `password`, `ido`) VALUES
(1, 'VITAL CIRHUZA', 'Admin', 'Quetzal', '741', 'QV75Y'),
(2, 'DAVID BAHATI', 'Admin', 'Dav', '123', 'FG456'),
(3, 'Ndala', 'Utilisateur', 'Ndala 1', '12369', '37592'),
(4, 'Sammy MARCEL', 'Manager', 'Sam', 'Marcel', '592A4');

-- --------------------------------------------------------

--
-- Structure de la table `produit`
--

CREATE TABLE IF NOT EXISTS `produit` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `category` varchar(50) NOT NULL COMMENT 'produit',
  `produit` varchar(50) NOT NULL,
  `Prix` varchar(20) NOT NULL,
  `NO` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=9 ;

--
-- Contenu de la table `produit`
--

INSERT INTO `produit` (`id`, `category`, `produit`, `Prix`, `NO`) VALUES
(6, '8 Mbps', 'Standard Plus', '500 000', '08254'),
(7, '5 Mbps', 'Standard', '250 000', '7A921'),
(8, '3 Mbps', 'Residentiel', '100 000', '81037');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
