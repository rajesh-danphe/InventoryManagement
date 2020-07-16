# InventoryManagement

This project consist of 3 layer :
1. sever model where you write you business logic
2. Dal layer inside that i have used respository pattern
3. Main controller 

## Installation
You need VS Code(for Client), visual studio(for API), MSSQL server(for Database), .Net core SDK 3.1, NodeJs, Angular 10



Download VS Code from [here](https://code.visualstudio.com/download)

Download Visual Studio from [here](https://visualstudio.microsoft.com/vs/)

Download MSSQL server from [here](https://www.microsoft.com/en-gb/sql-server/sql-server-downloads)

Download .Net Core SDK 3.1 [here](https://dotnet.microsoft.com/download/dotnet-core/3.1)

Download NodeJs from [here](https://nodejs.org/en/)

Download Angular 10 from [here](https://cli.angular.io/)


## Running the application
 #### Clone or download repository

```bash
https://github.com/rajesh-danphe/InventoryManagement.git
```

## Database Creation (Sql Server)
  We need databases for running InventoryManagement. So, we have .sql file into InventoryManagement/InventoryMangement/InventoryManagement.Database
#### Create Database with below steps

Open "InventoryManagementDB" file in you MSSQL Server Management
and run

## NPM Installation for Angular Project

To Install and Run angular project go through below steps:

Step 1: Go to InventoryManagement\InventoryMangement\InventoryMangement\wwwroot
\InventoryManagement path and copy.

Step 2: Open Your Node.js Command Prompt paste the copied path and execute npm install command.

Step 3: Once the npm install done successfully than execute ng build --watch command. So, some of you wondering that what is ng build and --watch. Here it is ng build ( It build you angular code) and --watch ( It runs in background so that whenever you change the code and save it. It gets build automatically.)

## Note :
you can also open Angular Project in visual studio code from there you will do npm install and ng build --watch.

## InventoryManagement Basic Changes, Build and Run Project
Step 1: Go to InventoryManagement\InventoryMangement path and double click on solution file to open project in Visual Studio 2019.

Step 2: Open Solution Explorer and find appsetting.json file into InventoryMangement Web Application and change the connectionstring properties as per database and server name.

Step 3: Once changes done than save the file.

Step 4: Now build InventoryMangement web Application and run it.

Step 5: For xUnit Test go to InventoryManagement\InventoryMangement
\InventoryManagement.Test in that open UnitTest1.cs and change the connectionstring properties as per database and server name. 
