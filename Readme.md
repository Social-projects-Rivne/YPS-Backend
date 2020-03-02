
# Installation
- All the code required to get started

## Clone 
- Clone this repo to your local machine using https://github.com/Social-projects-Rivne/YPS-Backend

## Setup
- Add DB and updated 

	```bash 	
	add-migration "Your migration"
	update-database 
	```
	


- Run project in VS  
	- Press Ctrl + F5
- Run project in console
	```bash
	dotnet run
	dotnet build
	```
	
## Configuration
#### There is the configuration file on this path
``` .\YPS-Backend\src\YPS.WebUI\appsettings.json ```

```yaml	
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "YPSDataBase": "put_connection_string_here"
  },
  "ApiKey": "put_apikey_here"
}
```
- #### Logging
> Display all warnings in the console. <br/>
> If you want more information about logging , go to <br/> https://docs.microsoft.com/uk-ua/aspnet/core/fundamentals/logging/?view=aspnetcore-3.1.
- #### AllowedHosts
> Is a special configuration that accepts a semicolon-delimited list of host names without port numbers<br/>
> If you want more information about allowed hosts , go to <br/> https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-2.2#host-filtering.
- #### ConnectionStrings
> This is to enable you to interact with the database. <br/>
>If you want more information about connection string , go to <br/> https://docs.microsoft.com/uk-ua/aspnet/core/tutorials/razor-pages/sql?view=aspnetcore-3.1&tabs=visual-studio
- #### ApiKey
> For protect your API with API Keys <br/>
>If you want more information about api key , go to <br/> https://josefottosson.se/asp-net-core-protect-your-api-with-api-keys

## Api 
> You can see all samples and how to use all requests on https://*hostname*/swagger/index.html. <br/>
> If you want more information about swagger , go to  https://swagger.io/.
