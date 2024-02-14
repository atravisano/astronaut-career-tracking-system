# Changelog

## Getting Started

* Added solution file after opening .csproj in Visual Studio
* Create database file `starbase.db` by running the command `dotnet ef database update`

## Enforcing Rules

> A Person is uniquely identified by their Name.

Was already implemented, `CreatePersonPreProcessor` to be configured in `Program.cs`

> A Person who has not had an astronaut assignment will not have Astronaut records.

_

> A Person will only ever hold one current Astronaut Duty Title, Start Date, and Rank at a time.

_

> A Person's Current Duty will not have a Duty End Date.

_

> A Person's Previous Duty End Date is set to the day before the New Astronaut Duty Start Date when a new Astronaut Duty is received for a Person.

_

> A Person is classified as 'Retired' when a Duty Title is 'RETIRED'.

_

> A Person's Career End Date is one day before the Retired Duty Start Date.

_
