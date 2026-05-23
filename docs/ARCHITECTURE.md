# Clinic Booking System - Architecture Design Document

## 1. Architecture Overview

The Clinic Booking System uses a **Layered Architecture** with clear separation of concerns:

```
┌─────────────────────────────────────────┐
│       Frontend Layer (Blazor WASM)      │
│  (Presentation, UI Components, Logic)   │
└────────────┬────────────────────────────┘
             │ HTTP/JSON
┌────────────▼────────────────────────────┐
│     API Layer (ASP.NET Core REST)       │
│  (Controllers, Routing, Authentication) │
└────────────┬────────────────────────────┘
             │
┌────────────▼────────────────────────────┐
│    Business Logic Layer (Services)      │
│  (Business Rules, Validations, DTOs)    │
└────────────┬────────────────────────────┘
             │
┌────────────▼────────────────────────────┐
│    Data Access Layer (Repository)       │
│  (EF Core, Queries, Unit of Work)       │
└────────────┬────────────────────────────┘
             │
┌────────────▼────────────────────────────┐
│      Database Layer (SQL Server)        │
│  (Tables, Indexes, Relationships)       │
└─────────────────────────────────────────┘
```

---

## 2. High-Level Components

### 2.1 Frontend - Blazor WebAssembly
- **Purpose**: Provide interactive user interface
- **Key Components**:
  - Authentication pages (Login, Register)
  - Patient dashboard
  - Booking workflow pages
  - Appointment management views
  - Admin/Clinic staff dashboards
- **Technology**: Blazor components, MudBlazor UI, FluentValidation
- **Communication**: HttpClient with JWT token headers

### 2.2 API Layer - ASP.NET Core Web API
- **Purpose**: Handle HTTP requests and delegate to business logic
- **Key Components**:
  - AuthController (Login, Register, Token refresh)
  - ClinicsController (GET clinics, services)
  - AppointmentsController (CRUD operations)
  - PatientsController (Profile management)
  - PractitionersController (Practitioner info)
  - TimeSlotController (Availability queries)
- **Features**: JWT authentication, exception handling middleware, logging

### 2.3 Business Logic Layer - Services
- **Purpose**: Implement core business rules and workflows
- **Key Services**:
  - `AppointmentService`: Booking, cancellation, rescheduling logic
  - `AvailabilityService`: Time slot generation and querying
  - `NotificationService`: Email/SMS sending (external integrations)
  - `ValidationService`: Business rule validation
  - `AuthenticationService`: JWT token management
  - `ReportingService`: Analytics and reporting

### 2.4 Data Access Layer - Repository Pattern
- **Purpose**: Abstract database operations
- **Key Repositories**:
  - `IPatientRepository`
  - `IClinicRepository`
  - `IAppointmentRepository`
  - `ITimeSlotRepository`
  - `IPractitionerRepository`
  - `IUnitOfWork`: Manages transactions and repository coordination

### 2.5 Database - SQL Server
- **Purpose**: Persistent data storage
- **Design**: Normalized relational schema with proper indexing
- **Tools**: Entity Framework Core Migrations

---

## 3. Data Flow Architecture

### 3.1 Booking Appointment Flow

```
Patient (Frontend) 
  ↓ 1. Search available clinics
Blazor Component (Display available slots, collect details)
  ↓ 2. POST /api/appointments/book
AppointmentsController
  ↓ 3. Call BookAppointment()
AppointmentService (Check rules, prevent double-booking)
  ↓ 4. SaveAsync()
AppointmentRepository
  ↓ 5. Database Update
SQL Server
  ↓ 6. Return success
NotificationService (Queue email)
  ↓ 7. Return DTO
Blazor Component (Display confirmation)
```

---

## 4. Design Patterns Used

### 4.1 Repository Pattern
Abstracts data access and provides a collection-like interface.

### 4.2 Unit of Work Pattern
Ensures data consistency across multiple repositories.

### 4.3 Service Layer Pattern
Encapsulates business logic separate from controllers.

### 4.4 Dependency Injection
Used throughout for loose coupling and testability.

### 4.5 DTO Pattern
Data Transfer Objects for API communication separate from domain models.

---

## 5. Security Architecture

### 5.1 Authentication Flow
1. User submits credentials to `/api/auth/login`
2. API validates credentials and generates JWT token
3. Frontend stores token in localStorage
4. Token included in Authorization header on subsequent requests

### 5.2 Authorization (Role-Based Access Control)
- **Patient Role**: Can book/cancel own appointments, view own profile
- **Clinic Staff Role**: Can manage clinic appointments, view clinic data
- **Admin Role**: Full system access

### 5.3 Data Protection
- Passwords: Hashed with bcrypt
- Communication: HTTPS/TLS only
- PII: Protected by healthcare compliance standards

---

## 6. Scalability Considerations

### 6.1 Database Optimization
- Indexing on frequently queried columns
- Connection pooling
- Query optimization using EF Core
- Partitioning for large tables (future)

### 6.2 API Scaling
- Stateless design for horizontal scaling
- Caching layer (Redis) for frequently accessed data
- Load balancing
- API rate limiting

### 6.3 Frontend Optimization
- Code splitting in Blazor WASM
- Lazy loading components
- Compression (gzip/brotli)
- CDN for static assets

---

## 7. Project Structure

```
Clinic/
├── src/
│   ├── Clinic.Api/
│   │   ├── Controllers/
│   │   ├── Services/
│   │   ├── Repositories/
│   │   ├── Data/
│   │   ├── Middlewares/
│   │   ├── Validators/
│   │   └── Program.cs
│   ├── Clinic.BlazorWasm/
│   │   ├── Pages/
│   │   ├── Components/
│   │   ├── Services/
│   │   └── Program.cs
│   └── Clinic.Shared/
│       ├── Models/
│       ├── DTOs/
│       └── Enums/
├── tests/
│   ├── Clinic.Api.Tests/
│   ├── Clinic.BlazorWasm.Tests/
│   └── Clinic.Integration.Tests/
└── docs/
```

---

## 8. Performance Metrics

| Metric | Target |
|--------|--------|
| Page Load Time | < 2s |
| API Response Time | < 500ms (95th percentile) |
| Database Query Time | < 100ms |
| Throughput | > 1000 requests/min |
| Error Rate | < 0.1% |

---

**Document Version**: 1.0  
**Last Updated**: 2026-05-23  
**Status**: Initial Release
