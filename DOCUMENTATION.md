# Changelog

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

* identify the most impactful methods requiring tests, `CreateAstronautDutyHandler` has the most business logic.
* reach >50% code coverage

## Implement process logging

* Log exceptions
* Log successes
* Store the logs in the database

This could be done by using NuGet libraries such as Serilog, OpenTelemetry dotnet, or custom middleware logic.

Alternatively, in an Azure environment, Azure App Insights can be used to capture this information with minimal code changes.

As a side note, it could be captured per endpoint but that would not be a scalable solution.
