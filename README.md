This is a simple app for Todo Listing. This is good simple practice for who just learned C# and .NET

What can this app do :
1.  Listing your todo, create, read, update, delete (CRUD)
2.  Sorting based on Created Date or Priority
3.  Checklist your Todo
4.  Indicate warning your Todo based on due date by changing the background color of the row (Today due date will be **yellow**, Over due date will be **red**)

How to run this app :
1.  git clone this repository to your local --> git clone https://github.com/muhrid44/TodoList.git
2.  using Visual Studio, open the UpscaleTest.sln file, then open appsettings.json to setup your database connection
3.  setup your database connection by changing the configuration of the "connstring"
4.  while setup connstring done, open the 'Package Manage Console' inside Visual Studio
5.  type Update-Database in Package Manage Console to execute database migrations
6.  once finished, you can start your app by pressing F5 or CTRL+F5

Techs used : HTML, CSS, Javascript, VueJS, jQuery, C#, .NET 6, Entity Framework, SQL Server (local)
