-- �������� ������
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

-- ����������
INSERT INTO Clients (Id, ClientName) VALUES
(1, N'��� �������'),
(2, N'��� ��������'),
(3, N'�� ���� ������'),
(4, N'��� ������');

-- ������� ������ � ������� ���������
INSERT INTO ClientContacts (Id, ClientId, ContactType, ContactValue) VALUES
(1, 1, N'Email', N'rmsh@example.com'),
(2, 1, N'Phone', N'+79999999999'),
(3, 2, N'Email', N'fksdo@example.com'),
(4, 2, N'Phone', N'+79992223344'),
(5, 2, N'Skype', N'cart_box'),
(6, 3, N'Email', N'ivanych@example.com')


-- 1. �������� ������, ������� ���������� ������������ �������� � ���-�� ��������� ��������

SELECT 
    c.ClientName,
    COUNT(cc.Id) AS ContactCount
FROM Clients c
LEFT JOIN ClientContacts cc ON c.Id = cc.ClientId
GROUP BY c.ClientName;

-- 2. �������� ������, ������� ���������� ������ ��������, � ������� ���� ����� 2 ���������

SELECT 
    c.ClientName
FROM Clients c
JOIN ClientContacts cc ON c.Id = cc.ClientId
GROUP BY c.Id, c.ClientName
HAVING COUNT(cc.Id) > 2;