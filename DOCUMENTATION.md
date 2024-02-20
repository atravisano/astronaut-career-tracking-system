# Documentation

## Getting Started

* Added solution file after opening .csproj in Visual Studio
* Create database file `starbase.db` by running the command `dotnet ef database update`

## Enforcing Rules

> A Person is uniquely identified by their Name.

Was already implemented, `CreatePersonPreProcessor` to be configured in `Program.cs`

> A Person who has not had an astronaut assignment will not have Astronaut records.

already implemented, no changes required.

> A Person will only ever hold one current Astronaut Duty Title, Start Date, and Rank at a time.

This is true by utilizing the `AstronautDetail` table.

> A Person's Current Duty will not have a Duty End Date.

Already implemented in `CreateAstronautDuty`.

> A Person's Previous Duty End Date is set to the day before the New Astronaut Duty Start Date when a new Astronaut Duty is received for a Person.

Already implemented in `CreateAstronautDuty`.

> A Person is classified as 'Retired' when a Duty Title is 'RETIRED'.

Already implemented in `CreateAstronautDuty`.

> A Person's Career End Date is one day before the Retired Duty Start Date.

Already implemented in `CreateAstronautDuty`.

## Improve defensive coding

* Resolve SQL injection

## Add unit tests

* Identify the most impactful methods requiring tests: `CreateAstronautDutyHandler` has the most business logic.
* reach >50% code coverage

## Implement process logging

* Log exceptions
* Log successes
* Store the logs in the database

This could be done by using NuGet libraries such as Serilog, OpenTelemetry dotnet, or custom middleware logic.

Alternatively, in an Azure environment, Azure App Insights can be used to capture this information with minimal code changes.

As a side note, it could be captured per endpoint but that would not be a scalable solution.

## Wishlist

* Should use .NET 8, .NET 7 EOL is May 2024
* Should align as a team to determine if the use of Dapper is necessary
  * Dapper has been known to be faster, however with latest EF Core improvements Dapper may not have as much of an advantage
  * Writing raw sql queries can be convenient but can require more maintenance
    * For example, if a property/column name is changed the compiler will catch the places it is used but the sql queries will not until runtime.
  * EF can write more efficient queries that lead to fewer trips to the DB
    * For example, in cases where it is making one query for the person (parent) and another query for their astronaut details (child)
* Understand if the of `GetResponse` and related `try/catch` are necessary
  * I think this format could be vulnerable to displaying internal errors to API consumers
  * Are the properties `Success` and `ResponseCode` providing additional information to the consumer? The response code is already provided to the user without reading the response body
  * The current implementation only allows for 200 which is not always suitable for the scenario
  * If in agreement, refactor usage of `GetResponse` and related `try/catch` into middleware
* POST endpoints should return 201 when successfull and a `Location` header on how to GET the data
  * This can also be done by using `CreatedAtAction`
* Seperate business logic and data layers into seperate projects for easier reusability, scalability, and testing
