# waimakua

 waimakua is an open source directory for Kauai legends.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine

### Installing

First, you'll need to clone down the repo into a directory. Open your terminal and enter

```
git clone git@github.com:rosewisotzky/waimakua.git
```
Open up your editor which we prefer to be Visual Studio, through the terminal with the command

```
cd waimakua
```

```
start waimakua.sln
```

Now, you'll be taken to Visual Studio with the project opened up. The next thing you'll want to do is to go to Tools and open the NuGet Package Manager and 
select the Package Manager Console. Once that is open, type in and enter Update-Database. Once the database has been successfully updated, go to View and select
SQL Server Object Explorer. Select your local database and click refresh. Now, for the fun part! Let's run our application. Make sure you've selected BangazonSite.

###### You are now ready to use waimakua. 


## User instructions
The user will be presented with the landing page that gives a little description of what is ahead. Let's click enter! Here a user may login or register
as a new user. Once logged in, they will be able to search locations and see details of locations. Each location has a list of legends that
are associated with it. Clicking on the title of the legend will direct the user to a view with more information. Users may also comment on locations,
should there be important information to have such as parking or road conditions. A user may also submit a new legend if they desire. That 
legend will be pending approval until an administrator approves it. Enjoy!





## Built With

* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) - The language we used
* [Azure Data Studio](https://docs.microsoft.com/en-us/sql/azure-data-studio/download?view=sql-server-2017) - Cloud for database
* [ASP.NET MVC](https://dotnet.microsoft.com/apps/aspnet/mvc) - MVC Framework for Web app 
* [Entity Framework](https://dotnet.microsoft.com/apps/aspnet/entity-framework) - Object Relational Mapper
* [Identity Framework](https://dotnet.microsoft.com/apps/aspnet/identity) - Authentication and user related data in ASP.NET MVC



## Author

* **Rose Ku'uleialoha Wisotzky** 




## Acknowledgments

* [PurpleBooth](https://gist.githubusercontent.com/PurpleBooth/109311bb0361f32d87a2/raw/8254b53ab8dcb18afc64287aaddd9e5b6059f880/README-Template.md) - For their template
