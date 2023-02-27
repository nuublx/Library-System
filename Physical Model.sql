Create database Library 

Create Table Person (
PID int NOT NULL primary key identity(1,1),
Fname varchar(255) NOT NULL, 
Lname varchar(255) NOT NULL, 
Email varchar(255), 
Pass varchar(255), 
Reader varchar(20),
Admin varchar(20),
Author varchar(20)
); 

Create Table Author (
Author_ID int NOT NULL primary key, 
CONSTRAINT FK_AID FOREIGN KEY (Author_ID) REFERENCES Person (PID) 
); 

Create Table Library_Admin (
Admin_ID int NOT NULL primary key, 
CONSTRAINT FK_AdID FOREIGN KEY (Admin_ID) REFERENCES Person (PID) 
);

Create Table Reader (
Reader_ID int NOT NULL primary key, 
RType varchar(255), 
CONSTRAINT FK_RID FOREIGN KEY (Reader_ID) REFERENCES Person (PID) 
);

Create Table Books (
BID int NOT NULL primary key identity(1,1), 
Title varchar(255) NOT NULL, 
Category varchar(255), 
Price decimal NOT NULL, 
PubYear int NOT NULL Check (PubYear Between 0 and 2023) , 
AuthorID int NOT NULL, 
CONSTRAINT FK_Author FOREIGN KEY (AuthorID) REFERENCES Author(Author_ID) 
);

Create Table Uploads 
(
BookID int NOT NULL, 
AdminID int NOT NULL, 
CONSTRAINT FK_Book FOREIGN KEY (BookID) REFERENCES Books (BID) ON DELETE CASCADE,
CONSTRAINT FK_admin FOREIGN KEY (AdminID) REFERENCES Library_Admin (Admin_ID), 
CONSTRAINT PK_uploads PRIMARY KEY (BookID,AdminID)
);  

Create Table Buys (
BookID int NOT NULL, 
readerID int NOT NULL, 
MonthBought int NOT NULL, 
YearBought int not null, 
CONSTRAINT FK_buyBook FOREIGN KEY (BookID) REFERENCES Books (BID) ON DELETE CASCADE,
CONSTRAINT FK_reader FOREIGN KEY (readerID) REFERENCES Reader (Reader_ID),
CONSTRAINT PK_Buys PRIMARY KEY (BookID,readerID)
); 

Create Table Comments ( 
BookID int NOT NULL, 
readerID int NOT NULL, 
comment varchar (255), 
CONSTRAINT FK_bookRev FOREIGN KEY (BookID) REFERENCES Books (BID) ON DELETE CASCADE,
CONSTRAINT FK_readerRev FOREIGN KEY (readerID) REFERENCES Reader (Reader_ID),
CONSTRAINT PK_Comments PRIMARY KEY (BookID,readerID) 
); 


Insert into Person Values 
('William', 'Shakespeare', Null , Null,'false','false','true'), 
('Charles', 'Dickens', Null , Null,'false','false','true'), 
('Agatha', 'Christie', 'agatha@gmail.com' , '123','false','false','true'), 
('George', 'Orwell', Null , Null,'false','false','true'), 
('Colson', 'Whitehead', 'colson@gmail.com' , '123','false','false','true'), 
('Zadie', 'Smith' , 'zadie@gmail.com' , '123','false','false','true'), 
('Isabel', 'Allende', 'isabel@gmail.com' , '123','false','false','true'), 
('David', 'Mitchell', 'david@gmail.com' , '123','false','false','true'),
('Philip', 'Roth', Null , Null,'false','false','true'), 
('John', 'Updike', Null , Null,'false','false','true'),

('Fadia', 'Khaled' ,'fadia@gmail.com', '123', 'true', 'false', 'false'),
('Mai', 'Mostafa' ,'mai@gmail.com', '123', 'true', 'false', 'false'),
('Zeyad', 'Diaa' ,'zeyad@gmail.com', '123', 'true', 'false', 'false'),
('Habiba', 'Yasser' ,'habibaY@gmail.com', '123', 'true', 'false', 'false'),
('Habiba', 'Mohamed' ,'habibaM@gmail.com', '123', 'true', 'false', 'false'),
('Mohamed', 'Amr' ,'mohamedAmr@gmail.com', '123', 'true', 'false', 'false'),

('Hassan', 'Mohamed' ,'hassan@gmail.com', '123', 'false', 'true', 'false'),
('Maram', 'Omar' ,'maram@gmail.com', '123', 'false', 'true', 'false');

Insert into Author
select PID from Person 
where Author='true';

Insert into Reader(Reader_ID)
select PID from Person 
where Reader='true';

Insert into Library_Admin
select PID from Person 
where Admin='true';


Insert into Books Values
('Macbeth','Tragedy','120','1632','1'),
('Hamlet','Tragedy','120','1603','1'),
('A Tale Of two Cities','Novel;','130','1859','2'),
('The Murder of Roger Ackroyd','detective fiction','120','1926','3'),
('Animal Farm','Political satire','120','1945','4'),
('The Nickel Boys','Novel','100','1945','5'),
('White Teeth','Hysterical Realism','150','2019','6'),
('Violeta','Novel','120','2022','7'),
('Cloud Atlas','Science Fantasy','200','2004','8'),
('Oliver Twist','Novel','120','1838','2');

Insert into Uploads values
('1','17'),
('2','17'),
('3','17'),
('4','17'),
('5','17'),
('6','18'),
('7','18'),
('8','18'),
('9','18');

insert into Buys values
('1','11','1','2022'),
('2','11','4','2020'),
('3','11','3','2021'),
('1','12','4','2022'),
('6','12','5','2022'),
('9','12','4','2022'),
('1','13','4','2022'),
('9','13','4','2022'),
('1','14','4','2022'),
('8','14','4','2022'),
('9','14','1','2021'),
('1','15','4','2022'),
('9','15','9','2022'),
('7','16','3','2022'),
('6','16','4','2021');