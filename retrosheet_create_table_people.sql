CREATE TABLE IF NOT EXISTS `people` (
  `PeopleID` int(11) NOT NULL AUTO_INCREMENT,
  `LastName` varchar(100) DEFAULT NULL,
  `FirstName` varchar(100) DEFAULT NULL,
  `RetrosheetID` varchar(20) DEFAULT NULL,
  `Debut` date DEFAULT NULL,
  PRIMARY KEY (`PeopleID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
