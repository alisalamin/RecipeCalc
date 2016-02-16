
********************************************************************
******************* HOW TO GENERATE THE DATABASE *******************
********************************************************************

 The Data Layer in RecipeCalculator uses EntityFramework Code First and SQL Express LocalDB. To auto-generate the database from the Data Model in the Data Access layer (DataAccess.proj), you'll need to do the following:

 If you do not have Sql Server Express installed, please visit https://www.microsoft.com/en-us/download/details.aspx?id=42299 to download and install. Afterwards please follow these steps..


 1. Delete the Migrations folder within the DataAccess project if it's present, it's auto generated so don't worry.
 
 2. Open the "Package Manager Console" within visual studio. (Tools > NuGet Package Manager > Package Manager Console)

 3. Type or paste: Enable-Migrations -Force

  - press enter - 

 4. Type or paste: Add-Migration IinitialCreate

  - press enter - 

 5. Type or paste: Update-Database

  - press enter - 

  The same Package Manager Console commands can be run to add to or update the database schema, in the event that changes are made to the code first data model (the objects in the Models folder within the DataAccess project).

