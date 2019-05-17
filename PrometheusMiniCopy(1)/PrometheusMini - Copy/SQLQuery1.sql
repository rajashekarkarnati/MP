CREATE TABLE Student_174852
(
	StudentId INT IDENTITY(1,1) NOT NULL, 
	Username VARCHAR(50) NOT NULL,
    FName VARCHAR(50) NOT NULL, 
    LName VARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(50) NOT NULL, 
    DOB DATE NOT NULL, 
    City VARCHAR(20) NOT NULL, 
    Password NVARCHAR(10) NOT NULL, 
    MobileNo NVARCHAR(10) NOT NULL
	CONSTRAINT [PK_Student_174852] PRIMARY KEY(StudentId)
)
drop table Student_174852
select * from Student_174852
----------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Teachers_174852
(
	TeacherId INT IDENTITY(1,1) NOT NULL,
	Username VARCHAR(50) NOT NULL, 
    FirstName VARCHAR(50) NOT NULL, 
    LastName VARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(50) NOT NULL, 
    DOB DATE NOT NULL, 
    City VARCHAR(20) NOT NULL, 
    Password VARCHAR(50) NOT NULL, 
    MobileNumber NVARCHAR(10) NOT NULL, 
    IsAdmin VARCHAR(10) NULL, 
    CONSTRAINT [PK_Teachers_174852] PRIMARY KEY (TeacherId)
)
select * from Teachers_174852
----------------------------------------------------------------------------------------------------------------------------


CREATE TABLE Courses_174852
(
	CourseId INT NOT NULL PRIMARY KEY, 
    CourseName VARCHAR(20) NULL, 
    StartDate VARCHAR(20)  NULL, 
    EndDate VARCHAR(20) NULL
)
insert into Courses_174852 Values (1,'English','12-NOV-2019','12-Jan-2019')
insert into Courses_174852 Values (2,'Mathematics','12-July-2019','12-Aug-2019')  
Select * from Courses_174852

----------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Teaches_174852

(
	TeacherId INT Primary key, 
    CourseId INT Foreign KEY references Courses_174852(CourseId)
)

----------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Enrollment_174852
(
	CourseId INT PRIMARY KEY foreign key references Courses_174852(CourseId), 
    StudentId INT foreign key references Student_174852(StudentId)
)
Select * from Enrollment_174852
drop table Enrollment_174852
----------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Homework_174852
(
	HomeWorkId INT NOT NULL PRIMARY KEY, 
    [Description] VARCHAR(50) NOT NULL, 
    Deadline VARCHAR(20) NOT NULL, 
    ReqTime VARCHAR(20) NOT NULL, 
    LongDescription VARCHAR(100) NOT NULL
)
insert into Homework_174852 Values (1,'English','12-NOV-2019','12-Jan-2019','Complete all exercises within time')
insert into Homework_174852 Values (2,'Mathematics','12-July-2019','12-Aug-2019','Complete Algebra chapter 1&2')  
Select * from Homework_174852

alter table Homework_174852 add CourseId  INT foreign key references Courses_174852(CourseId)
update Homework_174z852 set CourseId=2 where HomeWorkId=2
----------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Assignments_174852
 (
    HomeWorkId INT  PRIMARY KEY Foreign key REFERENCES Homework_174852(HomeWorkId),
    TeacherId  INT  Foreign key REFERENCES Teachers_174852(TeacherId) NOT NULL,
    CourseId   INT  Foreign key REFERENCES Courses_174852(CourseId)  NOT NULL,
)
insert into Assignments_174852 values(1, 1, 1)
select * from Assignments_174852
drop table Assignments_174852
drop table Teaches_174852

----------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Planning_174852
(
    StudentId INT primary key foreign key references Student_174852(StudentId),
	Monday NVARCHAR(20) NOT NULL, 
    Tuesday NVARCHAR(20) NOT NULL, 
    Wednesday NVARCHAR(20) NOT NULL, 
    Thursday NVARCHAR(20) NOT NULL, 
    Friday NVARCHAR(20) NOT NULL, 
    Saturday NVARCHAR(20) NOT NULL 
)
drop table Planning_174852
insert into Planning_174852 Values (1,'a','b','c','d','a','b')
Select * from Planning_174852
Select * from Enrollment_174852
Select * from Courses_174852
select * from Assignments_174852
select * from Homework_174852
select * from Teaches_174852
select * from Teachers_174852
select * from Student_174852
insert into Teaches_174852 values(1, 1)
insert into Assignments_174852 values(1, 1, 1)

