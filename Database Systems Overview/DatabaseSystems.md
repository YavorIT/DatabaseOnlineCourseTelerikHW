#####**Database Systems - Homework**#####

###**1. What database models do you know?**###
	
	##**There are a lot of database models here are some of them:**##
		**1. Hierarchical model** - the data is organized into a tree-like structure.
		**2. Network model** - a flexible way of representing objects and their relationships
		**3. Relational model** - managing data using a structure and language cinsistent with first-order predicate logic.
		**4. Object model** - the infromation is represented as object as used in the OOP.
			and so on...
	
###**2. Which are the main functions performed by a Relational Database Management System (RDBMS)?**###

	1. Data dictionary management
		It's where the DBMS stores definitions of the data elements and their realtionships.
	2. Data storage management
		Used for the storage of data and any related data entry forms.
	3. Data transformation and presentation
		Trasnformin any entered data into required data structure.
	4. Security management
		One of the most improtant functions of DBMS. Sets specific rules, determining specific users that are allowed to access the database.
	5. Multiuser access control
		Enables multiple users to access the database without affecting the integrity of the database.
	6. Backup and recovery
	7. Data integrity management
		Reduces things such as data redundancy (when the data is stored in more than one place).
	8. Database access languages
	9. Database communication interfaces
	10. Transaction management
	
###**3. Define what is "table" in database terms.**###
	A "table" is a collection of related data held in a structured format within a database.

###**4. Explain the difference between a primary and a foreign key.**###
	A primary key is a unique key that is stored in the database to make each entry unique from the others
	A foreign key is a field or collection of fields in one table that identifies a row of another table uniquely.
	
###**5. Explain the different kinds of relationships between tables in relational databases.**###
	**One-to-one** - it's a relationship in which one entry of a table can't be connected to more than one.
	**One-to-many** - one entry can be connected to many others.
	**Many-to-many** - many entries are connected to monay other entries. Usually is implemented by a third table connecting the other two tables.

###**6. When is a certain database schema normalized?  What are the advantages of normalized databases?**###
	A database schema is normalized when all the tables are written to contain the data without repeating.
	**Advantages:**
		The work is faster.
		More flexible.
		More compact.
	**Disadvantages**
		More tables to join.
		Tables contain more codes than data.

###**7. What are database integrity constraints and when are they used?**###
	Integrity constraints is somethin you tell the database to match. You set rules of the database information.
	There are domain integrity, entity integrity, referential integrity and foreign key integrity.
	
	Domain integrity is the definition of a valid set of values for an attribute.
	**Entity integrity constraint** - primary keys can't be null.
	**Referential integrity constraint** - Used to maintain the consistency among rows between two tables.
	
	**Foreign key integrity constraint - There are two types:**
		Cascade update related fields - whenever you change the primary key of a row in the primary table, the foreign key values are updated.
		Cacsade delete related rows - the same thing as the other but in case you delete a primary key.
		
###**8. Point out the pros and cons of using indexes in a database.**###
	**Advantage**:
		- quick access to the data int the database.
	**Disadvantage**:
		- writing to the table is slower.

###**9. What's the main purpose of the SQL language?**###
	The main purpose of the SQL is managing the data held in a RDBMS.
	
###**10. What are transactions used for? Give an example.**###
	A transaction is every change in the database. Transactions make sure that there will be no errors in a systme failure and prevents the database from using it concurrently.
	Example: If you and your friend have one bank account and want to get some money at the same time you won't be able to do it. First will be the first one who enters the account, the other one waits.
	
###**11. What is a NoSQL database?**###
	Non relational database - the data is not stored in tables.
	
###**12. Explain the classical non-relational data models.**###
	**Key-value storage** - very powerful model, data is represented as a collection of key-value pairs.
	**Document store** - documents in the database are addressed via a unique key.
	**Graph** - designed for data whose relations are represented as a graph.
	
###**13. Give few examples of NoSQL databases and their pros and cons.**###
	**MongoDB** - suitable in case there will be a lot of writing to the database and Big Data volumes.
	**Redis** - fast and good performance, stores the data in RAM.
	**CouchDB** - best for Web, every change is stored on the disk as a file.
	**HBase** - spreads the data out among nodes using HDFS. Used for managing huge tables consisting of billions of rows.
