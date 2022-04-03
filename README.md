# Todo app backend with .Net

Reimplementation of REST backend for a simple Todo application this time implemented with .Net MVC. 

The app supports 

* List tasks
* Add and update tasks
* Delete tasks

The original Java app was part of the blog post [MicroProfile & WebComponents — der neue Standard (Teil 1)](https://medium.com/@porocnik/microprofile-webcomponents-der-neue-standard-teil-1-a53c16fcd867)

### Setup

.Net can be used to create a project scaffold. Inside the (sub) project folder type:

    dotnet new webapi

Add EntityFramework modules (using .Net Core 3.1):

    dotnet add package Microsoft.EntityFrameworkCore --version 3.1.0
    dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 3.1.0


### Configuration 

To configure ports etc. use:

	launchSetting.json
	
The app is using a built-in in-memory db which is configured as servcie in: 

    Startup.cs

### Start local

    dotnet run

### Testing

For simple checking the responsiveness of the backend you can call: [http://localhost:5000/todo/tasks/](http://localhost:5000/todo/tasks/)

For automated testing switch to the test project. It can be scaffolded by typing

    dotnet new xunit
	
Add library for in-process testing MVC:
	
	dotnet add package Microsoft.AspNetCore.Mvc.Testing --version 3.1.0
	
To show Tests in the VS Code ".Net Core Test Explorer" the Testproject name msut match the apttern used in the Extension setting for "Test Project Path" e.g. "\*\*/\*Tests.csproj".
	
    
### Debugging

In VS Code start the application in the section (i.e. tab) of the Debug Extension via the ".Net Core Launch (web)" button. The regarding settings are configured in *.vscode/launch.json*.
	

### See also 

 * https://docs.microsoft.com/de-de/aspnet/core/tutorials/first-web-ap
 