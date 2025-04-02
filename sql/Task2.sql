-- Создание таблиц
CREATE TABLE Clients (
    Id BIGINT PRIMARY KEY,
    ClientName NVARCHAR(200)
);

CREATE TABLE ClientContacts (
    Id BIGINT PRIMARY KEY,
    ClientId BIGINT FOREIGN KEY REFERENCES Clients(Id),
    ContactType NVARCHAR(255),
    ContactValue NVARCHAR(255)
);

-- Наполнение
INSERT INTO Clients (Id, ClientName) VALUES
(1, N'ООО Ромашка'),
(2, N'ООО Картошка'),
(3, N'ИП Иван Иваныч'),
(4, N'ООО Дельта');

-- Вставка данных в таблицу контактов
INSERT INTO ClientContacts (Id, ClientId, ContactType, ContactValue) VALUES
(1, 1, N'Email', N'rmsh@example.com'),
(2, 1, N'Phone', N'+79999999999'),
(3, 2, N'Email', N'fksdo@example.com'),
(4, 2, N'Phone', N'+79992223344'),
(5, 2, N'Skype', N'cart_box'),
(6, 3, N'Email', N'ivanych@example.com')


-- 1. Написать запрос, который возвращает наименование клиентов и кол-во контактов клиентов

SELECT 
    c.ClientName,
    COUNT(cc.Id) AS ContactCount
FROM Clients c
LEFT JOIN ClientContacts cc ON c.Id = cc.ClientId
GROUP BY c.ClientName;

-- 2. Написать запрос, который возвращает список клиентов, у которых есть более 2 контактов

SELECT 
    c.ClientName
FROM Clients c
JOIN ClientContacts cc ON c.Id = cc.ClientId
GROUP BY c.Id, c.ClientName
HAVING COUNT(cc.Id) > 2;