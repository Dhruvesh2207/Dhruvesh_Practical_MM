-- ************  Create A State Table ***********

create table t_state
(
	c_stateid int primary key identity(1,1),
	c_statename varchar(20)
)

insert into t_state (c_statename) values ('Gujarat'),('Maharashtra');
select * from t_state

--************  Create A City Table ***********

create table t_city
(
	c_cityid int primary key identity(1,1),
	c_cityname varchar(20),
	c_stateid int FOREIGN KEY references t_state(c_stateid) on delete cascade
)

insert into t_city (c_cityname , c_stateid) values ('Surat',1) , ('Bardoli' , 1);
insert into t_city (c_cityname , c_stateid) values ('Mumbai',2) , ('Pune' , 2);
select * from t_city


--************  Create A Employee Table ***********


create table t_employee
(
	c_empid int primary key identity(1,1),
	c_empname varchar(100) not null,
	c_empemail varchar(100) not null,
	c_empphone varchar(10) not null,
	c_empaddress varchar(200) not null,	
	c_empstate int foreign key references t_state(c_stateid) on delete cascade,
	c_empcity varchar(20) not null,
	c_createddate datetime,
)


--************  ALL STORE PROCEDURES FOR THE CRUD ***********

	--*** INSERT STORE PROCEDURE ***

create procedure SP_AddEmployee
	@c_empname varchar(100),
	@c_empemail varchar(100),
	@c_empphone varchar(10),
	@c_empaddress varchar(200),
	@c_empstate int,
	@c_empcity varchar(20),
	@c_createddate datetime
AS
BEGIN
INSERT INTO t_employee (c_empname, c_empemail, c_empphone, c_empaddress, c_empstate, c_empcity, c_createddate) 
            VALUES 
            (@c_empname, @c_empemail, @c_empphone, @c_empaddress, @c_empstate, @c_empcity, @c_createddate);
End;

	--*** GET ALL EMPLOYEE STORE PROCEDURE ***
	
create procedure SP_GetAllEmployee
AS
BEGIN
    SELECT 
	e.c_empid,
        e.c_empname,
        e.c_empemail,
        e.c_empphone,
        e.c_empaddress,
        s.c_statename,
        e.c_empcity,
        e.c_createddate
    FROM t_employee e
    INNER JOIN t_state s ON e.c_empstate = s.c_stateid
    ORDER BY e.c_empid DESC;
END;

	--*** GET EMPLOYEE BY ID STORE PROCEDURE ***

create procedure SP_GetEmployeeByID
	@id int
As
BEGIN
	select * from t_employee where c_empid = @id;
END;

	--*** UPDATE EMPLOYEE STORE PROCEDURE ***

create procedure SP_UpdateEmployee
    @c_empid INT,                   
    @c_empname VARCHAR(100),       
    @c_empemail VARCHAR(100),       
    @c_empphone VARCHAR(10),        
    @c_empaddress VARCHAR(200),     
    @c_empstate VARCHAR(20),      
    @c_empcity VARCHAR(20),        
    @c_createddate DATETIME         
AS
BEGIN
    
    UPDATE t_employee
    SET
        c_empname = @c_empname,
        c_empemail = @c_empemail,
        c_empphone = @c_empphone,
        c_empaddress = @c_empaddress,
        c_empstate = @c_empstate,
        c_empcity = @c_empcity,
        c_createddate = @c_createddate
    WHERE
        c_empid = @c_empid;
END;


	--*** DELETE EMPLOYEE STORE PROCEDURE ***

create procedure SP_DeleteEmployee
	@id int
As
BEGIN
	Delete  from t_employee where c_empid = @id;
END;


--	*** GET ALL STATE STORE PROCEDURE ***

create procedure SP_GetAllState
As
BEGIN
	select c_stateid , c_statename from t_state;
END;

--	*** GET CITY BY STATE STORE PROCEDURE ***

cerate procedure SP_GetCityByState
	@id int
AS
BEGIN
select * from t_city where c_stateid = @id;
END;