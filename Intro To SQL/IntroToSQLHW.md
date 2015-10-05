#**Intro to Structured Query Language (SQL)**#

###**Homework**###

1. What is SQL? What is DML? What is DDL? Recite the most important SQL commands.
2. What is Transact-SQL (T-SQL)?
3. Start SQL Management Studio and connect to the database TelerikAcademy. Examine the major tables in the "TelerikAcademy" database.
4. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
5. Write a SQL query to find all department names.
6. Write a SQL query to find the salary of each employee.
7. Write a SQL to find the full name of each employee.
8. Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like "John.Doe@telerik.com". The produced column should be named "Full Email Addresses".
9. Write a SQL query to find all different employee salaries.
10. Write a SQL query to find all information about the employees whose job title is "Sales Representative".
11. Write a SQL query to find the names of all employees whose first name starts with "SA".
12. Write a SQL query to find the names of all employees whose last name contains "ei".
13. Write a SQL query to find the salary of all employees whose salary is in the range [20000...30000].
14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
15. Write a SQL query to find all employees that do not have manager.
16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
17. Write a SQL query to find the top 5 best paid employees.
18. Write a SQL query to find all employees along with their address. Use inner join with ON clause.
19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
20. Write a SQL query to find all employees along with their manager.
21. Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.
22. Write a SQL query to find all departments and all town names as a single list. Use UNION.
23. Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join.
24. Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.




**1. What is SQL? What is DML? What is DDL? Recite the most important SQL commands.** 

*What is SQL*

	SQL - Structured Query Language. 
	Used to manipulate the database and take out data.
	Standard language to communicate with realtional databases.
	Common databases that use SQL are: Oracle, MySQL, MSSQL Server.
	
*What is DML*

	DML stands for Data manipulation Language.
	Used for selecting, updating, deleting and inserting data in the database.
	
*What is DDL*

	DDL - Data Definition Language.
	Giving the creating, altering, dropping, granting, revoking commands.

*Most important SQL commands*

		Select - selects columns from a database table or multiple tables.
		Update - Updates data in the table.
		Delete - delete data from the table.
		Create Table - creates table in the database.
		Drop Table - deletes table from the database.
		Insert into - inserts data in the table.
		Alter Table - alter a table.
		

**2. What is Transact-SQL (T-SQL)?**
	
	T-SQL - extension to the SQL language which adds functionalties like
	cycles, if statements, exceptions and other things used in the programming languages.
	
	
**3. "TelerikAcademy" database script [HERE](https://github.com/TelerikAcademy/Databases/blob/master/07.%20Intro%20to%20SQL/Demo/Create-TelerikAcademy-Database-SQL-Script.sql) !**

