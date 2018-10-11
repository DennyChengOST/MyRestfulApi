# MyRetailService

### Software Stack Used
* C#/ .NET 4.5.2
  * I used C# because it's the language I primarily use while building out Microservices and API's
* ServiceStack 5.4
  * I utilize ServiceStack since it's the framework I'm most confident in and felt I could build a super simple but stable API
* AutoMapper
  * Simple lightweight mapping library. I like this since it does alot of the heavy lifting in terms of mapping from class to class.
* MongoDB(MongoDb.Driver)
  * Use the C# Driver for MongoDB so I could quickly interact with my Local MongoDB without too much configuration.
* MS Unit Test
  * I'm a very firm believer in not only writing quality code but quality tests as well. 
  * I tested each layer (Service/Manager/Repository) to the best my ability but I do admit I ran into issues with testing the repository due to my lack of experience with MongoDB but I got 75% of the test case written out.
* Shoudly
  * Just a preference but I've discovered Shoudly as a asserting library but have also used Assert/Nunit oriented assertions as well.
* Swagger UI
  * ServiceStack has a intuitive plugin for Swagger which allows a user to interact with the API with a generic UI


## Instructions
*Please Have Google Chrome Installed before attempting the build*
#### Downloading MongoDB
Please refer to [Microsoft/Windows](https://docs.mongodb.com/manual/tutorial/install-mongodb-on-windows/) or [Mac/Apple](https://treehouse.github.io/installation-guides/mac/mongo-mac.html) documentation to install MongoDb on your machine
1. Once Installed follow the command prompts in your terminal to run MongoDb
2. Example prompt "C:\Program Files\MongoDB\Server\4.0\bin\mongod.exe"

### Downloading and running the API
1. Download the project and open it in Visual Studio
2. Go into Tools/Nuget Package Manager/Manager Nuget Packages For Solution and download all nuget packages needed
3. Once project is built make sure MyRetailService project is set for the start up project. If you are unsure just right click on MyRetailService project and select Set As Startup Project indicated by the little cog icon.
4. Press IIS Express (Google Chrome)
5. Select SwaggerUI under Plugin Links
6. Select Products and you should see two routes /(GET/PUT)/Products{id}
7. Select each route you want to test! 

##### Data Used


:turtle: Thank you to whoever is reviewing my code! I'm always open for feedback so please let me know how I can improve! Thank you!
:pineapple::jack_o_lantern:
