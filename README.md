# CinemaBooking

## Getting Started

### Set Up PostgreSQL

Navigate to the scripts/docker-compose/postgres folder within your Open CinemaBooking solution directory. Run the following command to start the PostgreSQL container:

```bash
docker-compose up -d
```

### Update Connection String

Open CinemaBooking.sln project. In the `appsettings.json` file of your Open CinemaBooking solution `CinemaBooking.sln`, update the connection string to point to the PostgreSQL instance

### Apply Migrations and Create Database

Open solution `CinemaBooking.sln` in the Visual Studio, open Package Manager Console. Chose default project `Infrastructure` and run command to update database:

```bash
Update-Database
```

## Functionality

- **Movie Management** is expertly handled through the `MoviesController`
- **Theater and Showtime Management** implemented in `TheatersController` and `ShowtimesController`
- **Seat Reservation** implemented in BookingsController POST method
  - Reservation Timeout is used Hangfire Background job
- **Booking Confirmation** is efficiently managed within the `BookingsController` through the PUT Confirm method.

## Todo

- Update Hangfire to use DataBase
- Enhanced Validation Rules
- Transition to Minimal API
- Implement Authentication
