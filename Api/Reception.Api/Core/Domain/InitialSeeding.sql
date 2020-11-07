delete dbo.Complectation
delete dbo.Equipment

SET IDENTITY_INSERT DBO.Equipment on 
insert into dbo.Equipment ([Id], [Name], [IsNode], [ParentId]) values
(1, 'Ноутбуки', 1, null),
	(4, 'Asus', 1, 1),
		(13, 'Asus F35', 0, 4),
		(14, 'Asus X55', 0, 4),
	(5, 'Acer', 1, 1),
		(15, 'Acer Aspire 5320', 0, 5),
		(16, 'Acer Aspire 3 A351', 0, 5),
		(17, 'Acer Aspire 7 A784', 0, 5),
	(6, 'Lenovo', 1, 1),
		(18, 'Lenovo Ideapad V17', 0, 6),
		(19, 'Lenovo Ideapad G530', 0, 6),
	(2, 'Планшеты', 1, null),
		(7, 'Huawei MatePad Pro', 0, 2),
		(8, 'Lenovo Tab M10 HD', 0, 2),
		(9, 'Apple iPad 3', 0, 2),
(3, 'Бытовая техника', 1, null),
	(10, 'Холодильники', 1, 3),
		(20, 'Стинол 355', 0, 10),
	(11, 'Стириальные машины', 1, 3),
		(21, 'Zanussi ZWY50924CI', 0, 11),
	(12, 'Утюги', 1, 3),
		(22, 'Philips Azur GC4560', 0, 12)
SET IDENTITY_INSERT DBO.Equipment off

insert into dbo.Complectation ([EquipmentId], [Name]) values
(1, 'ноутбук'),
(1, 'блок питания'),
(1, 'силовой кабель'),
(2, 'планшет'),
(2, 'блок питания'),
(2, 'силовой кабель'),
(10, 'холодильник'),
(10, 'полки'),
(10, 'держатели продукты'),
(11, 'сма'),
(11, 'кювета'),
(11, 'контейнер'),
(12, 'утюг'),
(12, 'кювета')


merge into dbo.ClientType as trg
using(select * from(values(1, 'Физическое лицо'),(2, 'Юридичесое лицо'))v(Id, [Name])) as src
on trg.Id = src.Id
when not matched then
insert (Id, [Name]) values (Id, [Name]);

set identity_insert dbo.Client on
merge into dbo.Client as trg
using(select * from(values
(1,1, 'Виктор', 'Иванов', 'Петрович','+7-958-661-45-87',null,null, null, null),
(2, 1,'Петров', 'Иван', 'Иванович','ivanov@ya.ru', null,null, null, null),
(3, 1,'Сидоренко', 'Андрей', 'Павлович',null,'+7-922-789-56-21',null, null, null),
(4, 1,'Варчук', 'Олег', 'Ильич','face@mai.ru',null,null, null, null),
(5, 1,'Кривчиков', 'Евгений', 'Петрович','t.center@mai.ru',null,null, null, null),
(6, 1,'Строгова', 'Татьяна', 'Андреевна','t.strogova@gmail.com',null,null, null, null),
(7, 1,'Путин', 'Вовка', 'Вовкович','putin@kremlin.ru',null,null, null, null)
)v([Id], [ClientTypeId], [Name], [Inn], [Kpp], [FirstName], [LastName], [MiddleName], [Phone], [Email])) as src
on trg.Id = src.Id
when not matched then
insert ([Id], [ClientTypeId], [Name], [Inn], [Kpp], [FirstName], [LastName], [MiddleName], [Phone], [Email]) 
	values 
([Id], [ClientTypeId], [Name], [Inn], [Kpp], [FirstName], [LastName], [MiddleName], [Phone], [Email]);
set identity_insert dbo.Client off

merge into dbo.OrderStatus as trg
using(select * from(values
(1, 'Принят'),
(2, 'Диагностика'),
(3, 'Диагностика завершена'),
(4, 'Заказ деталей'),
(5, 'Детали поступили'),
(6, 'В работе'),
(7, 'Требуется оплата'),
(8, 'Завершено')
)v(Id, [Name])) as src
on trg.Id = src.id
when not matched then
insert (Id, [Name]) values (Id, [Name]);

set identity_insert dbo.[Order] on
merge into dbo.[Order] as trg
using(select * from(values
(1,'2020-09-01',1,2,20,'не включается','б/у, потертости',null,'холодильник, коробка, полки, подон, держатели продуктов (6 штук)',null),
(2,'2020-09-01',2,3,21,'слышен гул','б/у, потертости',null,'магнитола',3500),
(3,'2020-09-02',3,7,7,'разбит экран','б/у, потертости',null,'планшет',1900),
(4,'2020-09-02',4,6,15,'зависает через 5-10 минут','б/у, потертости',null,'ноутбук, БП',4800),
(5,'2020-09-03',5,6,13,'зависает через 5-10 минут','б/у, потертости',null,'ноутбук, БП',5800),
(6,'2020-09-03',6,6,14,'разбита матрица','б/у, потертости',null,'ноутбук, БП',5100),
(7,'2020-09-03',7,6,13,'разбита матрица','б/у, потертости',null,'ноутбук, БП',6100)
)v(Id, [CreationDate], [ClientId], [StatusId], [EquipmentId], [DefectDescription], [ExternalStateDescription], [DiagnosticResult], [Complectation], [RepairCost])) as src
on trg.Id = src.Id
when not matched then
insert (Id, [CreationDate], [ClientId], [StatusId], [EquipmentId], [DefectDescription], [ExternalStateDescription], [DiagnosticResult], [Complectation], [RepairCost])
values
(Id, [CreationDate], [ClientId], [StatusId], [EquipmentId], [DefectDescription], [ExternalStateDescription], [DiagnosticResult], [Complectation], [RepairCost]);

set identity_insert dbo.[Order] off