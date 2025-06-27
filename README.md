# FhirPatientApiWithTests

A simple .NET 8 Web API that fetches and parses HL7 FHIR patient data from a remote JSON source.  
Includes integration testing using xUnit and WebApplicationFactory.

---

## Description

This project demonstrates how to:

- Build a RESTful API using C# and ASP.NET Core
- Fetch external JSON data from the official HL7 FHIR specification
- Extract and return patient information (ID, name, gender, birthdate)
- Test the API using integration tests with xUnit

---

## Technologies Used

- .NET 8
- ASP.NET Core Web API
- xUnit (for testing)
- HttpClient (for external requests)
- Microsoft.AspNetCore.Mvc.Testing (test host)

##  Project Structure

```
PatientInfoSolution/
├── PatientInfoService/
│   ├── Controllers/
│   │   └── PatientController.cs
│   └── Program.cs
├── PatientInfoService.Tests/
│   └── PatientApiTests.cs
└── PatientInfoSolution.sln
```
