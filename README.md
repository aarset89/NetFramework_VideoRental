# Notes

### prerequisites

• Visual studio 2017 or superior.
• Sql Server 2012 or superior.
• Web browser with lastest updates.

## In order to execute the project, 

1) Clone project in your local drive.
2) Create new database in any instance of Sql Server database.
3) Modify the web.config file > connectionStrings with the information related to database created before. (This project uses CodeFirst approach)
4) Open Package manager console in visualStudio
5) Excecute next command: Update-Database
6) Clean and rebuild the whole project
7) Execute following commands in database created before:

insert into [dbo].[MembershipTypes] values ('Monthly',20,1,0)
insert into [dbo].[MembershipTypes] values ('Quarterly',57,3,5)
insert into [dbo].[MembershipTypes] values ('Semester',108,6,10)
insert into [dbo].[MembershipTypes] values ('Annually',204,12,15)

insert into [Vidly].[dbo].[Genres] values ('Comedy')
insert into [Vidly].[dbo].[Genres] values ('Fantasy')
insert into [Vidly].[dbo].[Genres] values ('Crime')
insert into [Vidly].[dbo].[Genres] values ('Drama')
insert into [Vidly].[dbo].[Genres] values ('Music')
insert into [Vidly].[dbo].[Genres] values ('Adventure')
insert into [Vidly].[dbo].[Genres] values ('History')


## Use

Create customer 
Create movie
Create New rental