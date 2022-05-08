# EmployeeAppT

СОДЕРЖАНИЕ:
1). Папка EmployeeApp содержит проект по заданию по c# 

2). Документ SQLQuery1.sql - содержит:
    - создание базы данных 
    - создание таблиц
    - наполнение таблиц данными (приложение может работать когда таблицы пустые) 
    - проверочные запросы, которое использовались

3). Документ SQL Tasks_042022.docx который содержит ответы на вопросы по заданию по SQL 


Для создания базы данных использовал MS SQL SERVER 18.9.1

ВАЖНО!
1) Для работы приложения на WinForms с базой данных использовал ADO.NET
2) Перед началом запуска приложения, стоит выполнить скрипты с документа SQLQuery1.sql 
3) Для того чтоб приложение подключалось к базе данных стоит отредактировать 
поле connectionString, которое находится по пути /Model/Filter.cs
-> стоит отредактировать следующее -> Data Source={имя сервера};Initial Catalog={база данных};Integrated Security=True


ЛОГИКА РАБОТЫ ПРИЛОЖЕНИЯ:
1. Сначала создаються отделы, затем в них можно добавить должности, и только потом за должностями закрепляются сотрудники. 
Строгость соблюдения такой логики необходима для корректной работы приложения, так как при закреплении сотрудника должность 
выбирается из выпадающего списка уже созданных, а отдел подтягиватся автоматически в соответствии с выбранной должностью 
(ручное указание отдела и должности не реализовано, для избежания ошибок при закреплении сотрудника)
2. Удалять позиции, за которыми закреплены сотрудники нельзя, потому что изначально решается вопрос с переводом на другую позицию или увольнением
сотрудников - тоесть изначально нужно снять сотрудников с позиций.
3. Для удаления департамента, у него не должно быть позиций (смотри п.2)


ДОПОЛНИТЕЛЬНО:
1. По желанию заказчика, указанная мной выше логика, может быть изменена на следующую: возможность удаления отдела с должностями и
закрепленными за ними сотрудниками.
2. Так же реализовано сохранение данных по сотрудникам в формате excel (для удобства)


#Задание 

1) БД

С помощью любой БД (указать выбранную БД, её версионность) обеспечить хранение таких данных сотрудников:

1) Уникальный код сотрудника
2)	Имя сотрудника
3)	Фамилия сотрудника
4)	Отчество сотрудника
5)	Телефон
6)	Адрес
7)	Отдел 
8)	Должность
9)	Оклад
10)	KPI (оценка сотрудника, по которой высчитывается премия: A,B,C)

Привести Нормализацию отношений к 3НФ

2) C#

Разработать приложение на windows forms с использованием ООП и подключением к созданной БД

Приложение должно включать в себя:

Главное меню — В главном меню должны отображаться навигация по приложению, а также перечень сотрудников компании (ФИО, отдел, должность, оклад, оценка, премия (описано после описания меню) с возможностью фильтрации по отделам.

По нажатию на сотрудника должно открываться отдельное окно, в котором будет отображаться полная информация по данному сотруднику, реализовать редактирование данных сотрудника, а также удаление сотрудника. 

Меню (при нажатии на пункты меню открываются новые окна):
1.	Редактирование отделов — вывод всех отделов, добавление \ удаление \ редактирование.
2.	Редактирование должностей — вывод всех должностей, добавление \ удаление \ редактирование.
3.	Добавление сотрудника — окно, в котором можно будет добавить нового сотрудника.
4.	Выплаты — отображается сумма денег, отведенная на зарплату всех сотрудников, возможность фильтрации по отделам.
5.	Отчет — формирование текстового файла — Содержимое информации о сотрудниках (ФИО\отдел\должность\ оклад\оценка,\премия ) отсортировать по отделам. 

В главном меню при смене оклада сотрудника должно просчитываться ежемесячная премия в зависимости от оценки, а именно: А — оклад — 20%, B – Оклад — 30%, С – Оклад — 40%.

 Удаление записей не должно нарушать целостность базы

