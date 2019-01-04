# CustomerWebApi
> .Net Web API for maintaining contact information

>.Net web api using entity framework(code first), unity DI, repository pattern, fluent validation, exception handling.

## Project Organization
### API Project
This contains 

    APIs for POST, PUT, GET, DELETE methods.
    
    Validators for customer properties using FluentValidation. 
    
    Unity DI for customer services and repository for APIs.
    
    GlobalExceptionHandler in the ExLoger folder. Exceptions can be logged in a table or file.
 
### Contracts Project
  Contracts are used as request and response objects to/from APIs.

### Mappers Project
  Mappers are used to map the contract properties to customer entity properties and viceversa while POST, PUT, GET.

### Models Project
 >It contains the models: 
    
    The generic 'Entity<T>' model has the Id property which will act as a key where 'T' will be type of the key.
    
    AuditableEntity<T> model has the audit information like date created/updated and status(active/inactive). 
    It inherits the 'Entity<T>'.
    
    Customer model inherits AuditableEntity<T> and extends it by having its own properties like FirstName, LastName etc...
    
 >Uses entity framework code first approach.
    
    
### Repositories Project
  It contains a Generic repository to perform database operations on undelying entity.

### Services Project
  It has the Customer Service which uses the repository methods to perform operations.
  
### Tests Project
  It has the test methods for repositories using 'Moq'.
  
## How to run?
  Download, extract and open in the Visual Studio 2017.
  
  Go to package manager console and restore dependencies to download required packages.
  
  Build and run the project. This will open a browser instance. 
  
  Append '/swagger/ui/index' to the URL. This will show you the Swagger API documentation for Customer API controller
  
  Example URL: http://localhost:55619/swagger/ui/index
  
  Click on Customer in API documentation, this will show http methods available.
  
  ### API Details
  
  > GET /Active
  
  This fetches active customers only.
  
  Click 'Try it out' button, it will fetch and show customers with 'Status' active. 
  
  > GET /api/Customer 
    
    This fetches all customers.
  
    Click 'Try it out' button, it will fetch and show all customers.
    
  > POST /api/Customer
  
    This is used to create a customer. 
    
    The click on the example JSON, the example JSON will appear in the contract box. 
    
    Just provide the values in the JSON and click 'Try it out' button. 
    
    Watch for the responses and errors for creation status which will be shown below 'Try it out' button.
    
    Responce code 200 means successful customer creation. 
  
  > PUT /api/Customer
    This is used to update 'existing' customer information by using the JSON. 
    
    You can get a customer JSON from GET method above. Follow same steps stated in POST method description above.
    
  > DELETE /api/Customer/{id}
  
    This used to delete the existing active customers by passing the customer 'id' to this method.
  
  > GET /api/Customer/{id}
  
    This used to get the existing active customer details by providing the customer 'id' to this method.
  
  
  > If any EF database generation issue, run commands in given sequence in package manager console. First set default project as 'CustomerInfoApp.Models'.
  
    1. enable-migrations
    
      If already enabled, proceed to next command.
    
    2. update-database -verbose -force
    
      This will create the database for you as per DB connection string provided in the configuration.



