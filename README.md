В проекте используется таблица вида:

CREATE TABLE `FIO_PhoneBook` (
`ROW_ID`           INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,    // primary_key
`NAME`             VARCHAR(200),                                // ФИО
`CELL_NUM`         VARCHAR(11),                                 // Номер мобильного
`STATIONARY_NUM`   VARCHAR(45),                                 // Номер домашнего
`BIRTH_DATE`       DATE,                                        // Дата рождения
PRIMARY KEY(`ROW_ID`)
)
