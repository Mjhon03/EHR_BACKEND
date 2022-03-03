-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema easyhouserent
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema easyhouserent
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `easyhouserent` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `easyhouserent` ;

-- -----------------------------------------------------
-- Table `easyhouserent`.`departamento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `easyhouserent`.`departamento` (
  `iddepartamento` INT NOT NULL,
  `nombre` CHAR(100) NOT NULL,
  PRIMARY KEY (`iddepartamento`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `easyhouserent`.`usuarios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `easyhouserent`.`usuarios` (
  `idUsuarios` INT NOT NULL AUTO_INCREMENT,
  `nombre` CHAR(80) NOT NULL,
  `apellidos` CHAR(80) NOT NULL,
  `fechaNacimiento` DATE NOT NULL,
  `telefono` INT NOT NULL,
  `email` VARCHAR(120) NOT NULL,
  `contraseña` VARBINARY(200) NOT NULL,
  `estado` CHAR(1) NOT NULL,
  `iddepartamento` INT NOT NULL,
  PRIMARY KEY (`idUsuarios`),
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) VISIBLE,
  INDEX `iddepartamento_idx` (`iddepartamento` ASC) VISIBLE,
  CONSTRAINT `iddepartamento`
    FOREIGN KEY (`iddepartamento`)
    REFERENCES `easyhouserent`.`departamento` (`iddepartamento`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `easyhouserent`.`tipoestructura`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `easyhouserent`.`tipoestructura` (
  `idtipoEstructura` INT NOT NULL,
  `nombre` CHAR(100) NOT NULL,
  PRIMARY KEY (`idtipoEstructura`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `easyhouserent`.`anuncios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `easyhouserent`.`anuncios` (
  `idanuncios` INT NOT NULL AUTO_INCREMENT,
  `idusuario` INT NOT NULL,
  `titulo` CHAR(80) NOT NULL,
  `descripcion` VARCHAR(3000) NOT NULL,
  `puntuacion` INT NOT NULL,
  `direccion` VARCHAR(150) NOT NULL,
  `estado` CHAR(1) NOT NULL,
  `tipoEstructura` INT NOT NULL,
  `valor` FLOAT NOT NULL,
  `fecha` DATE NOT NULL,
  `certificado` VARCHAR(500) NOT NULL,
  `fotos` VARCHAR(500) NOT NULL,
  PRIMARY KEY (`idanuncios`),
  INDEX `idusuario_idx` (`idusuario` ASC) VISIBLE,
  INDEX `tipoEstructura_idx` (`tipoEstructura` ASC) VISIBLE,
  CONSTRAINT `idusuario`
    FOREIGN KEY (`idusuario`)
    REFERENCES `easyhouserent`.`usuarios` (`idUsuarios`),
  CONSTRAINT `tipoEstructura`
    FOREIGN KEY (`tipoEstructura`)
    REFERENCES `easyhouserent`.`tipoestructura` (`idtipoEstructura`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `easyhouserent`.`oferta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `easyhouserent`.`oferta` (
  `idoferta` INT NOT NULL,
  `idanuncio` INT NULL DEFAULT NULL,
  `idusuario` INT NULL DEFAULT NULL,
  PRIMARY KEY (`idoferta`),
  INDEX `idanuncio_idx` (`idanuncio` ASC) VISIBLE,
  INDEX `idusuario_idx` (`idusuario` ASC) VISIBLE,
  CONSTRAINT `anuncio`
    FOREIGN KEY (`idanuncio`)
    REFERENCES `easyhouserent`.`anuncios` (`idanuncios`),
  CONSTRAINT `oferta`
    FOREIGN KEY (`idusuario`)
    REFERENCES `easyhouserent`.`usuarios` (`idUsuarios`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
