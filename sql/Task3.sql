-- �������� ������� � ���������� ������

CREATE TABLE Dates
(
	Id bigint,
    Dt date
)

INSERT INTO Dates (Id, Dt) VALUES
(1, '2021-01-01'),
(1, '2021-01-10'),
(1, '2021-01-30'),
(2, '2021-01-15'),
(2, '2021-01-30')


-- 1. �������� ������, ������� ���������� ��������� ��� ���������� Id. ��������, ���� ����� ����� ������

WITH IntervalData AS (
    SELECT 
        Id,
        Dt AS Sd,
        LEAD(Dt) OVER (PARTITION BY Id ORDER BY Dt) AS Ed
    FROM Dates
)
SELECT *
FROM IntervalData
WHERE Ed IS NOT NULL;