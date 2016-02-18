
********************************************************************
******************* HOW TO GENERATE THE DATABASE *******************
********************************************************************

 The Data Layer in RecipeCalculator uses EntityFramework Code First and SQL Express LocalDB. To auto-generate the database from the dbcontext in the Data Access layer (DataAccess.proj), you'll need to do the following:

 If you do not have Sql Server Express installed, please visit https://www.microsoft.com/en-us/download/details.aspx?id=42299 to download and install. 

 Tip: A quick way to check if you have SQL Server of any kind installed, is to run the following command from any location in your command prompt:

 sc queryex type= service | find "MSSQL"
  - or -
 sc queryex type= service | find "SQL"


 Afterwards please follow these steps..

 1. Delete the migration scripts (ex title: 201602162242183_CreateDBWithTestData.cs") from the Migrations folder within the DataAccess project *if they're present*, it's auto generated so don't worry.
 
 2. Open the "Package Manager Console" within visual studio. (Tools > NuGet Package Manager > Package Manager Console).

 3. Type or paste: Add-Migration InitialCreateWithTestData
  - press enter - 

 4. Type or paste: Update-Database -Verbose
  - press enter - 

  The same Package Manager Console commands can be run to update the database schema, in the event that you make changes to the code first data model (the objects in the Models folder within the DataAccess project). Be sure to name the migration schema (in the above example the migration schema name is InitialCreateWithTestData) uniquely.