# FullStackAppTest

Решение тестового задания по созданию FullStack приложения ASP.NET Core + React js.

## Задача 1
Необходимо реализовать веб-приложение на Asp.Net Core.
Серверная часть
Разработать 2 метода API по технологии REST.
### 1 метод
Получает на вход json, который содержит массив объектов, и сохраняет его в БД.
Описание объекта:
●  	code – код. Тип int.
●  	value – значение. Тип string.
Пример json:
[
        	{“1”: “value1”},
        	{“5”: “value2”},
			{“10”: “value32”},
….
]
Полученный массив необходимо отсортировать по полю code и сохранить в БД (в решении необходимо описать структуру таблицы).
В таблице должно быть 3 поля:
●  	порядковый номер
●  	код
●  	значение
Перед сохранением данных таблицу необходимо очистить.
### 2 метод
Возвращает данные клиенту из таблицы в виде json.
Возвращаемые данные:
●  	порядковый номер
●  	код
●  	значение
Добавить возможность фильтрации возвращаемых данных.
Клиентская часть
Сделать загрузку и отображение списка используя описанные выше методы. Вывод данных в таблицу с использованием пагинации приветствуется.

## Задача 2
Даны таблицы:
Clients - клиенты
(
        	Id bigint, -- Id клиента
        	ClientName nvarchar(200) -- Наименование клиента
);
ClientContacts - контакты клиентов
(
        	Id bigint, -- Id контакта
        	ClientId bigint, -- Id клиента
        	ContactType nvarchar(255), -- тип контакта
        	ContactValue nvarchar(255) --  значение контакта
);
    1. Написать запрос, который возвращает наименование клиентов и кол-во контактов клиентов
    2. Написать запрос, который возвращает список клиентов, у которых есть более 2 контактов
## Задача 3 (опционально)
Дана таблица:
Dates - клиенты
(
        	Id bigint,
        	Dt date
);
    1. Написать запрос, который возвращает интервалы для одинаковых Id. Например, есть такой набор данных:
	
	
| Id | Dt         |
|----|------------|
| 1  | 01.01.2021 |
| 1  | 10.01.2021 |
| 1  | 30.01.2021 |
| 2  | 15.01.2021 |
| 2  | 30.01.2021 |


Результатом выполнения запроса должен быть такой набор данных:

| Id | Sd         | Ed          |
|----|------------|-------------|
| 1  | 01.01.2021 | 10.01.2021  |
| 1  | 10.01.2021 | 30.01.2021  |
| 2  | 15.01.2021 | 30.01.2021  |
