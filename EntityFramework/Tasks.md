#**Entity Framework**#

##Homework##

1. Using the Visual Studio Entity Framework designer create a DbContext for the Northwind database
2. Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers.
	* Write a testing class.
3. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
4. Implement previous by using native SQL query and executing it through the DbContext.
5. Write a method that finds all the sales by specified region and period (start / end dates).
6. Create a database called NorthwindTwin with the same structure as Northwind using the features from DbContext.
	* Find for the API for schema generation in MSDN or in Google.
7. Try to open two different data contexts and perform concurrent changes on the same records.
	* What will happen at SaveChanges()?
	* How to deal with it?
8. By inheriting the Employee entity class create a class which allows employees to access 
their corresponding territories as property of type EntitySet<T>.