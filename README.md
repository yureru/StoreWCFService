# StoreWCFService

A three layer Windows Communication Foundation service that uses a Microsoft SQL database to update products.
These are the **Service interface** (StoreService project),
the **Business logic** (StoreLogic project), and **Data access** (StoreDAL).

# Projects

**StoreBDO**: The Business Domain Object (BDO) is the class that represents one of the
data contracts from the service but with several more properties. It is used across the
business logic layer, the data access layer, and the service layer.
And it is not exposed to the service clients.

**StoreClient**: This is the client app, currently using a Command-line application, it also
defines the proxy client (Service reference). These were generated with the SvcUtil.exe program.
Here you can consume the service with whatever application you want, might be a Winforms,
or WPF, among others.

**StoreDAL**: DAL stands for Data Access Layer. If any service operation requires database
connection it will be exposed here, and the Business Logic Layer can consume it.

**StoreDataContracts**: Here we define all the Data Contracts exposed to the service,
note that we use primitive types as the member of the class so the interoperability of the
service is broader.

**StoreLogic**: Here’s where the main business logic will reside, the Service layer delegates
to this layer, and here we will in turn delegate any database access to the DAL.

**StoreService**: This is the service layer where all the service contracts and operation
contracts are defined. We handle any exceptions that the service might throw and return
fault contracts instead, it delegates the functionality to the logic layer.

# Installation

- Create a SQL Server instance, download the database file from here: https://www.microsoft.com/en-us/download/details.aspx?id=23654

- Extract the files in the directory of your choice.

- Open Microsoft SQL Server Management Studio, and then run a new query, here you will paste the contents
of the instnwnd.sql file from the package you extracted earlier.

- Run the query and then you will have the Northwind database installed.

- Open the App.config file in the StoreService project, there in the node connectionStrings
in the attribute connectionString put the location of your SQL server instace.

- You can then use your client to consume this WCF service.