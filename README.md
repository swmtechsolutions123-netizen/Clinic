# Clinic Booking System - PHCIS

A simplified Clinic Booking System for Primary Health Care Information System (PHCIS) built with Blazor WebAssembly and ASP.NET Core Web API.

## Project Overview

This project implements a comprehensive clinic appointment booking system that allows patients to book appointments at clinics, view available time slots, and receive confirmation.

### Technology Stack

**Frontend:**
- Blazor WebAssembly (.NET 8+)
- MudBlazor for UI components
- FluentValidation for client-side validation

**Backend:**
- ASP.NET Core Web API (.NET 8+)
- Entity Framework Core for data access
- SQL Server or PostgreSQL

**Testing:**
- xUnit for unit tests
- Moq for mocking
- bUnit for component testing

**DevOps:**
- GitHub Actions for CI/CD
- Docker for containerization

## Key Features

- ✅ Patient registration and profile management
- ✅ Clinic and practitioner management
- ✅ Appointment booking with time slot availability
- ✅ Double-booking prevention
- ✅ Appointment confirmation and notifications
- ✅ Appointment rescheduling and cancellation
- ✅ Role-based access control (Patient, Staff, Admin)
- ✅ Responsive UI with MudBlazor components
- ✅ Comprehensive error handling and logging

## Functional Requirements

- Patients can search for available clinics and services
- View available time slots for practitioners
- Book, reschedule, and cancel appointments
- Receive booking confirmations via email
- System prevents double-booking
- Clinic staff can manage schedules and view appointments
- Admin can manage clinics, practitioners, and users

## Non-Functional Requirements

- Secure data handling (healthcare compliance)
- High performance (< 2s page load, < 500ms API response)
- Scalability for 1000+ concurrent users
- 99.5% uptime target
- > 80% unit test coverage
- SOLID principles and clean code

## Getting Started

### Prerequisites

- .NET 8 SDK or later
- SQL Server or PostgreSQL
- Git

### Quick Start

1. Clone the repository:
```bash
git clone https://github.com/swmtechsolutions123-netizen/Clinic.git
cd Clinic
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Update database connection string in `appsettings.json`

4. Apply migrations:
```bash
cd src/Clinic.Api
dotnet ef database update
```

5. Run the API:
```bash
dotnet run --project src/Clinic.Api
```

6. Run the frontend (in another terminal):
```bash
dotnet run --project src/Clinic.BlazorWasm
```

## Project Structure

```
Clinic/
├── src/
│   ├── Clinic.Api/               # ASP.NET Core Web API
│   ├── Clinic.BlazorWasm/        # Blazor WebAssembly Frontend
│   └── Clinic.Shared/            # Shared DTOs and Models
├── tests/
│   ├── Clinic.Api.Tests/         # API Unit Tests
│   ├── Clinic.BlazorWasm.Tests/  # Component Tests
│   └── Clinic.Integration.Tests/ # Integration Tests
├── docs/
│   ├── REQUIREMENTS.md
│   └── ARCHITECTURE.md
└── .github/workflows/            # GitHub Actions
```

## Documentation

- [Requirements Document](docs/REQUIREMENTS.md) - Detailed functional and non-functional requirements
- [Architecture Document](docs/ARCHITECTURE.md) - System design and component overview

## Testing

Run unit tests:
```bash
dotnet test tests/Clinic.Api.Tests
```

Run all tests with coverage:
```bash
dotnet test /p:CollectCoverage=true
```

## Contributing

1. Create a feature branch: `git checkout -b feature/your-feature`
2. Commit changes: `git commit -am 'Add feature description'`
3. Push to branch: `git push origin feature/your-feature`
4. Submit a pull request

### Code Standards

- Follow SOLID principles
- Use meaningful naming conventions
- Include XML documentation for public methods
- Write unit tests for new functionality
- Maintain > 80% code coverage

## License

This project is proprietary software for PHCIS.

## Contact

For more information, visit: [swmtechsolutions123-netizen](https://github.com/swmtechsolutions123-netizen)
