# Contact Management API

### Description

Restful API implemenation for managing contact information using C#, Web API, Repository, Unity, Partial Response,FluentValidation, Exception Handling, Unit tests, HATEOAS, Swagger, AutoMapper, Azure SQL, Azure APP Service, Entity Framework

Sample application is deployed on Azure App Service using Azure SQL.
http://contactmanagementapi.azurewebsites.net/swagger

Operations Allowed:
1. GET -gets the list of all contacts, for partial response - use a comma-separated list (fields=firstname,email) to select multiple fields.
/api/contact

2. GET By Id - gets the contact information for any id
/api/contact/{id}

3. POST - create new contact

4. PUT - update existing contact

5. DELETE - change status from action to inactive 

## Project Structure

-- ContactManagement.API : Web API project having dependency injection, HATEOAS implementation, Swagger

-- ContactManagement.API.Tests : Web API unit tests

-- ContactManagement.Contracts : Request and response contracts for API

-- ContactManagement.Services : Service layer for fetching data from repository 

-- ContactManagement.Models : Holding business entities and uses entity framework code first approach.

-- ContactManagement.Repository : Generic repository for fetching data from SQL Server

## How to run 

Sample application is hosted on Azure APP Service and pointing to Azure SQL.

For running application locally, change connection string in web.config file to point to correct SQL Server.

Test
