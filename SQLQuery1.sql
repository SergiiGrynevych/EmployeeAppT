create database TPost
GO

use TPost2;

create table Employees
(
	EM_Id int IDENTITY PRIMARY KEY NOT NULL,
	EM_FirstName nvarchar(50)  NOT NULL,
	EM_MiddleName nvarchar(50)  NOT NULL,
	EM_LastName nvarchar(80)  NOT NULL,
	EM_PhoneNumber varchar(13) NULL,
	EM_Address nvarchar(250) NULL,
--	EM_Position int not null,
	CHECK (EM_PhoneNumber LIKE '[+][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' and len(EM_PhoneNumber)=13)
);

create table Subdivision
(
	SB_Id int IDENTITY PRIMARY KEY NOT NULL,
	SB_Department nvarchar(50) NOT NULL,
);

create table Appointment
(
	AP_Id int IDENTITY PRIMARY KEY NOT NULL,
	AP_Position nvarchar(50) NOT NULL,
	AP_IdSubdivision int FOREIGN KEY REFERENCES Subdivision(SB_Id) NOT NULL
)

create table EmployeeAppointment
(
	ES_EmployeeId int FOREIGN KEY REFERENCES Employees(EM_Id) NOT NULL,
	ES_AppointmentId int FOREIGN KEY REFERENCES Appointment(AP_Id) NOT NULL,
)

create table SalaryEmployee
(
	SE_IdEmployee int FOREIGN KEY REFERENCES Employees(EM_Id) NOT NULL,
	SE_Salary smallmoney NOT NULL,
	SE_Kpi char NULL --DEFAULT 'A'
)

/*----------------�������� ������----------------*/
/*���������� ����� �������� � � ������� ���������*/
/*
insert into Employees
values
('����', '��������', '������', '+380661112233', '����, ��. �����, 13, ��. 133'),
('�����', '��������', '������', '+380501112233', '����, �����. ������, 10, ��.1'),
('������', '����������','��������', '+380674445566', '����, ��. �����������, 1, ��. 14'),
('ϸ��', '�������������','������', '+380998889900', '����, ��. �����������, 7, ��. 10');

insert into Subdivision
values
('IT'),
('Management'),
('Logistic')

insert into Appointment
values 
('Front-end developer', 1),
('Back-end developer', 1),
('Director', 2),
('Operator', 3),
('HR', 2)

insert into EmployeeAppointment
values
(1, 1),
(2, 2),
(3, 3),
(4, 4);

insert into SalaryEmployee
(SE_IdEmployee, SE_Salary)
values
(1, 25000),
(2, 31000),
(3, 35000),
(4, 20000)
*/
/*-----------------------------------------------*/

---------------------------------------------------
/*-------------������� �� ���������--------------*/
--join department with position
select * from Subdivision s
join Appointment a
on s.SB_Id = a.AP_IdSubdivision
---------------------------------------------------
--to show employee position and department
select * from Employees e
left join EmployeeAppointment ea
on e.EM_Id = ea.ES_EmployeeId
left join Appointment a
on a.AP_Id = ea.ES_AppointmentId
left join Subdivision s
on s.SB_Id = a.AP_IdSubdivision
---------------------------------------------------
-------------���������� �� �����������-------------
select EM_ID, EM_FirstName, EM_MiddleName, EM_LastName, EM_PhoneNumber, EM_Address, SB_Department, AP_POSITION, SE_SALARY, SE_KPI 
from Employees e
left join EmployeeAppointment ea
on e.EM_Id = ea.ES_EmployeeId
left join Appointment a
on a.AP_Id = ea.ES_AppointmentId
left join Subdivision s
on a.AP_IdSubdivision = s.SB_Id
left join SalaryEmployee sa
on e.EM_Id = sa.SE_IdEmployee
---------------------------------------------------
------��� ������������ ������ �������� ������------
------���\�����\���������\�����\������\������------
select CONCAT(EM_LastName, ' ', EM_FirstName, ' ', EM_MiddleName) as ��� 
	 , SB_Department AS �����
	 , AP_Position AS ���������
	 , SE_Salary as �����
	 , SE_Kpi as ������
	 , CAST(case when SE_Kpi = 'a' then sum(SE_Salary * 0.2)
			when SE_Kpi = 'b' then sum(SE_Salary * 0.3)
			when SE_Kpi = 'b' then sum(SE_Salary * 0.4)
		end AS SMALLMONEY) as ������
from Employees e
left join EmployeeAppointment ea
on e.EM_Id = ea.ES_EmployeeId
left join Appointment a
on a.AP_Id = ea.ES_AppointmentId
left join Subdivision s
on s.SB_Id = a.AP_IdSubdivision
left join SalaryEmployee se
on e.EM_Id = se.SE_IdEmployee
group by EM_LastName, EM_FirstName, EM_MiddleName,  SB_Department, AP_Position, SE_Salary, SE_Kpi
order by SB_Department
---------------------------------------------------