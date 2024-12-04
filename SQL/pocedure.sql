-- 1.1
/**
Table created in dbo.<table_name>

we can visualize it by making a SELECT * FROM dbo.<table_name>
**/

-- 1.2
USE FunctionalSql
CREATE TABLE exo (
	ID INT,
	Name VARCHAR(32)
	CONSTRAINT unique_ID UNIQUE(ID)
)

-- 1.3
PRINT('Bonjour, et bienvenue dans le
cours de Transact SQL !')

-- 1.4
CREATE TABLE #temp (
	mgs TEXT
)

INSERT INTO #temp
VALUES ('Bonjour, et bienvenue dans le
cours de Transact SQL !')

SELECT * FROM #temp

-- 1.5
/*
Violation of UNIQUE KEY constraint 'unique_ID'. Cannot insert duplicate key in object 'dbo.exo'. The duplicate key value is (1).

We can find the line using the unique id key since that is the constraint that we are violating 

*/

-- 1.6
/*
We can store a query by creating a PROCEDURE as follow 
CREATE PROCEDURE <procedure-name>
AS
BEGIN
    ...
END

We can execute that procedure by calling it like this 
EXEC <procedure-name>

If we want to us some argument we need to create a function instead,
where we would define de signature and the return type

- TODO
    - OBJECT_ID() (function)
    - GO (instruction)

*/

IF OBJECT_ID('getname', 'P') IS NOT NULL
BEGIN
    PRINT 'The procedure "getname" already exists. Query execution stopped.';
    RETURN;  -- This stops the execution of the query if the procedure exists
END;
GO
CREATE PROCEDURE getname AS
BEGIN
    SELECT e.Name
    FROM exo e;
END;

-- 2.1
PRINT('Le T-SQL, c’est bien
pratique !')

-- 2.2
DECLARE @hello VARCHAR(100);
SET @hello = 'Le T-SQL, c’est bien pratique !'; 

PRINT(@hello);

-- 2.3
DECLARE @person_nb INT;

SELECT @person_nb = COUNT(BusinessEntityID)
FROM Person.Person

PRINT(@person_nb)

-- 2.4
DECLARE @prenom_emp VARCHAR(50);

SELECT @prenom_emp = FirstName
FROM Person.Person
WHERE LastName = 'Eminhizer'

PRINT(@prenom_emp)


-- 2.5
/*
- Assigning a value with == does not work
- Variable name needs to start with '@'
- Missing a comma at the end of line 3
*/

-- 2.6
/*
-- Wrong type definition of varchar line 2
-- Incorect syntax line 6 for the implecite declaration + @x already exist
-- Bad syntax for PRINT
*/

-- 2.7
DECLARE @date_du_jour DATETIME = GETDATE();
PRINT(@date_du_jour)

-- 2.8
DECLARE
@f_name VARCHAR(50),
@l_name VARCHAR(50),
@id INT,
@hire_date VARCHAR(128),
@gender VARCHAR(1)
;

SELECT 
	@f_name = p.FirstName,
	@l_name = p.LastName,
	@id = e.BusinessEntityID,
	@hire_date = CONVERT(VARCHAR, e.HireDate, 102),
	@gender = e.Gender
FROM Person.Person p
LEFT JOIN HumanResources.Employee e 
ON e.BusinessEntityID = p.BusinessEntityID
WHERE LastName = 'Eminhizer'

PRINT (
'M.' + @l_name + 
' ' + @f_name + ' est l''employé numéro ' + 
CAST(@id AS VARCHAR) + ' et a été engagé le ' + 
@hire_date+
' et est ' + 
CASE WHEN @hire_date = 'M' THEN 'un homme' ELSE 'une femme' END
);

-- 2.9
DECLARE
@name VARCHAR(50) = 'Etienne',
@age INT = 26
;

PRINT(@name + CAST(@age AS VARCHAR))

-- 2.10
CREATE TABLE  #temp(
	result INT
);

DECLARE
@x INT = 1,
@y INT = 2,
@z INT = 3
;

INSERT INTO #temp
VALUES(@x+@y+@z)

SELECT * FROM #temp

-- 2.11
DECLARE
@id INT,
@title VARCHAR(50),
@b_date DATE
;

SELECT 
	@title = e.JobTitle,
	@b_date = BirthDate,
	@id = e.BusinessEntityID
FROM HumanResources.Employee e 

PRINT(CAST(@id AS VARCHAR)+' ' + @title +' '+ FORMAT(@b_date,'dd-MMMM-yyyy'))

-- 2.12
CREATE TABLE #temp (
    Title VARCHAR(8),
    FirstName VARCHAR(50),
	LastName VARCHAR(50)
);

INSERT INTO #temp (Title,FirstName, LastName)
SELECT Title, FirstName, LastName
FROM Person.Person;

SELECT * FROM #temp

-- 2.13 (2.12 same)


-- 3.1
DECLARE @seniority VARCHAR(50)
SELECT 
	@seniority = 
	
	CASE 
		WHEN DATEDIFF(YEAR, BirthDate,HireDate)>9 THEN 'senior'
		ELSE 'Junior'
	END 
FROM HumanResources.Employee 
WHERE BusinessEntityID = 21

PRINT('L’employé 21 est un '+ @seniority)

-- 3.2
DECLARE @FirstName VARCHAR(50);
DECLARE @MiddleName VARCHAR(50);
DECLARE @LastName VARCHAR(50);

IF EXISTS (SELECT 1 FROM Person.Person WHERE LastName = 'Zugelder')
BEGIN
    SELECT 
        @FirstName = FirstName, 
        @MiddleName = MiddleName, 
        @LastName = LastName
    FROM Person.Person
    WHERE LastName = 'Zugelder';
	PRINT (@FirstName +' '+ @MiddleName+ ' '+ @LastName);
END
ELSE
BEGIN
    PRINT 'Il n''existe personne portant ce nom !';
END

3.3
DECLARE @MenCount INT = 0;
DECLARE @WomenCount INT = 0;

SELECT 
    @MenCount = COUNT(CASE WHEN Gender = 'M' THEN 1 END),
    @WomenCount = COUNT(CASE WHEN Gender = 'F' THEN 1 END)
FROM HumanResources.Employee;

SELECT
	CASE
		WHEN @WomenCount > @MenCount THEN 'Les femmes domineront le monde !'
		ELSE 'La guerre des
sexes n’est pas finie… '
	END 'State'

-- 3.4
DECLARE 
@Resthours21 SMALLINT,
@Resthours27 SMALLINT,
@Vacationhours21 SMALLINT,
@Vacationhours27 SMALLINT

-- retrive info
SELECT
	@Resthours21 = SickLeaveHours,
	@Vacationhours21 = VacationHours
FROM HumanResources.Employee 
WHERE BusinessEntityID = 21;

SELECT
	@Resthours27 = SickLeaveHours,
	@Vacationhours27 = VacationHours
FROM HumanResources.Employee 
WHERE BusinessEntityID = 27;

SELECT
CASE 
	WHEN (@Resthours21+@Vacationhours21) - (@Resthours27+@Vacationhours27) !=0 THEN 'Disparité au niveau des heures de congés'
	WHEN (@Resthours21>@Resthours27 AND @Vacationhours21>@Vacationhours27) OR (@Resthours27>@Resthours21 AND @Vacationhours27>@Vacationhours21) THEN 'Les heures de congés sont allouées différemment'
	ELSE 'Tout va bien'
END 'Congé'

-- 3.5
CREATE TABLE #suivi (
	Suivi_employé VARCHAR(50)
)

INSERT INTO #suivi
SELECT
CASE
	WHEN YEAR(HireDate) BETWEEN 2017 AND 2018 THEN 'Junior'
	WHEN YEAR(HireDate) BETWEEN 2012 AND 2016 THEN 'Qualified'
	WHEN YEAR(HireDate) BETWEEN 2007 AND 2011 THEN 'Confirmed'
	ELSE 'President '
END 'Suivi_employé'
FROM HumanResources.Employee
WHERE BusinessEntityID = 50

SELECT *  FROM #suivi

-- 3.6

-- group by 

-- exemple using cursor

DECLARE 
@Delta INT = 5

SELECT
CASE
	WHEN DATEDIFF(Year,BirthDate,GETDATE()) + @Delta >  65 THEN   'Attention, retraite imminente pour '+ p.FirstName + ' '+p.LastName
	ELSE p.FirstName + ' '+p.LastName+ 'a encore de longues années à faire
chez nous '
END 'retraite'
FROM HumanResources.Employee e
LEFT JOIN Person.Person p ON p.BusinessEntityID = e.BusinessEntityID

-- 3.7
DECLARE @NameCounts TABLE (
    LastName VARCHAR(50),
    Count INT
);

INSERT INTO @NameCounts (LastName, Count)
VALUES ('Coleman', 0),
       ('Powell', 0),
       ('Suarez', 0),
       ('Vance', 0);

-- Create the CURSOR
DECLARE cnt CURSOR FOR
SELECT LastName
FROM Person.Person
WHERE LastName IN ('Coleman', 'Powell', 'Suarez', 'Vance');

DECLARE @CurrentLastName VARCHAR(50);

OPEN cnt;
FETCH NEXT FROM cnt INTO @CurrentLastName;

WHILE @@FETCH_STATUS = 0
BEGIN 
	UPDATE @NameCounts
	SET Count = Count + 1
	WHERE LastName = @CurrentLastName;

	FETCH NEXT FROM cnt INTO @CurrentLastName;
END

-- Free the CURSOR
CLOSE cnt;
DEALLOCATE cnt;

SELECT * FROM @NameCounts;


-- 3.8
BEGIN
	DECLARE @cnt INT;
	SELECT
		@cnt = COUNT(BusinessEntityID)
	FROM HumanResources.Employee
	WHERE (YEAR (BirthDate) < 1975) OR (YEAR (BirthDate) BETWEEN
1980 AND 1990)

	IF (@cnt>20)
	BEGIN
		SELECT
			BusinessEntityID,
			YEAR(BirthDate) 'Birth date',
			
			CASE 
				WHEN VacationHours + SickLeaveHours >= 80 THEN 'Excédant'
				WHEN VacationHours + SickLeaveHours BETWEEN 60 AND 79 THEN 'Dans la norme'
				WHEN VacationHours + SickLeaveHours BETWEEN 40 AND 59 THEN 'Bonne éléments'
				ELSE 'Realy ??'
			END 'Stats'
		FROM HumanResources.Employee
		WHERE (YEAR (BirthDate) < 1975) OR (YEAR (BirthDate) BETWEEN
1980 AND 1990)
	END
END
