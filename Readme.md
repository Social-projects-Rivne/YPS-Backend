
# Installation
- All the code required to get started

## Clone 
- Clone this repo to your local machine using https://github.com/Social-projects-Rivne/YPS-Backend

## Setup
- Add DB and updated 

	```batch
	add-migration "Your migration"
	update-database 
	```
	


- Run project in VS  
	- Press Ctrl + F5
- Run project in console
	```batch
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


## Api 
> You can see all samples and how to use all requests on https://*hostname*/swagger/index.html. <br/>
> If you want more information about swagger , go to  https://swagger.io/.
