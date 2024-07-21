--1.Create table with name tblEmployee


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



--2.Write query to insert data in table : 

INSERT INTO t_employee (c_empname, c_empemail, c_empphone, c_empaddress, c_empstate, c_empcity, c_createddate) 
            VALUES 
            (@c_empname, @c_empemail, @c_empphone, @c_empaddress, @c_empstate, @c_empcity, @c_createddate);

----  Insert Data so this is a c_empid = 1

INSERT INTO t_employee (c_empname, c_empemail, c_empphone, c_empaddress, c_empstate, c_empcity, c_createddate) 
            VALUES ('Dhruvesh' , 'dm.narigara@gmail.com' , '9979267737' , 'Katargam' , 1 , 'Surat' , '2000-10-14');

--3. Write query to update record in table

UPDATE t_employee SET
        c_empname = @c_empname,
        c_empemail = @c_empemail,
        c_empphone = @c_empphone,
        c_empaddress = @c_empaddress,
        c_empstate = @c_empstate,
        c_empcity = @c_empcity,
        c_createddate = @c_createddate
    WHERE
        c_empid = @c_empid;

--- Here Updateing email of a empid = 1 

UPDATE t_employee SET
        c_empname = 'Dhruvesh',
        c_empemail = 'dhruvesh@gmail.com',
        c_empphone = '9979267737',
        c_empaddress = 'Katargam',
        c_empstate = 1,
        c_empcity = 'Surat',
        c_createddate = '2000-10-14'
    WHERE
        c_empid = 1;

--4. Write query to get all data, last inserted data should show first

SELECT  *
FROM t_employee
ORDER BY c_empid DESC;

--5. Write query to get all employees who are leaving in State Gujarat

SELECT	emp.c_empid,
		emp.c_empname,
		emp.c_empemail,
		emp.c_empphone,
		emp.c_empaddress, 
		states.c_statename AS StateName,
		emp.c_empcity, emp.c_createddate
FROM 
	t_employee emp
JOIN t_state states ON emp.c_empstate = states.c_stateid
WHERE states.c_statename = 'Gujarat';

--6. Write query to get all employees who are leaving in State Maharashtra and city Pune

SELECT	emp.c_empid,
		emp.c_empname,
		emp.c_empemail,
		emp.c_empphone,
		emp.c_empaddress, 
		states.c_statename AS StateName,
		emp.c_empcity, emp.c_createddate
FROM 
	t_employee emp
JOIN t_state states ON emp.c_empstate = states.c_stateid
WHERE states.c_statename = 'Maharashtra' AND emp.c_empcity = 'Pune';

--7. Write query to get all data which are inserted in last 15 days

SELECT *
FROM t_employee
WHERE c_createddate >= DATEADD(DAY, -15, GETDATE());

--8.Write qwerty to get all data which contains name with ‘sh’ characters

SELECT *
FROM t_employee
WHERE c_empname LIKE '%sh%';

--9. Write query to return last inserted record only

SELECT TOP 1 *
FROM t_employee
ORDER BY c_empid DESC;


