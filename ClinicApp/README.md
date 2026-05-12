# ClinicApp - Klinika Randevu Sistemi

## Clean Architecture strukturu

```
ClinicApp/
├── ClinicApp.sln
└── src/
    ├── ClinicApp.Domain/         # Entities, Enums, Interfaces
    ├── ClinicApp.Application/    # DTOs, Services, Interfaces
    ├── ClinicApp.Infrastructure/ # EF Core, Repositories, DbContext
    └── ClinicApp.API/            # Controllers, Program.cs
```

## Başlatma addımları

```bash
# 1. Nuget paketlərini yüklə
dotnet restore

# 2. Migration yarat (ClinicApp.API qovluğunda)
dotnet ef migrations add InitialCreate --project ../ClinicApp.Infrastructure --startup-project .

# 3. Database yarat
dotnet ef database update --project ../ClinicApp.Infrastructure --startup-project .

# 4. Layihəni işlət
dotnet run
```

## API Endpoints

### Doctors
- GET    /api/doctors
- GET    /api/doctors/{id}
- GET    /api/doctors/available
- GET    /api/doctors/specialization/{specialization}
- POST   /api/doctors
- PUT    /api/doctors/{id}
- DELETE /api/doctors/{id}

### Patients
- GET    /api/patients
- GET    /api/patients/{id}
- GET    /api/patients/email/{email}
- POST   /api/patients
- PUT    /api/patients/{id}
- DELETE /api/patients/{id}

### Appointments
- GET    /api/appointments
- GET    /api/appointments/{id}
- GET    /api/appointments/doctor/{doctorId}
- GET    /api/appointments/patient/{patientId}
- GET    /api/appointments/date/{date}
- POST   /api/appointments
- PUT    /api/appointments/{id}
- PATCH  /api/appointments/{id}/cancel
- DELETE /api/appointments/{id}

## Swagger UI
http://localhost:5000/swagger
