# CoffeeShop API

A weather-aware coffee brewing API that serves hot or iced coffee based on the current temperature.

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- OpenWeatherMap API key (sign up at https://openweathermap.org/api)

### Configuration

1. Create a copy of `appsettings.Development.json` and name it `appsettings.Local.json` (this file will be ignored by git)
2. Add your OpenWeatherMap API key to the configuration:

```json
{
  "OpenWeatherMap": {
    "ApiKey": "your-api-key-here"
  }
}
```

### Running the Application

1. Clone the repository
2. Navigate to the project directory:
   ```bash
   cd CoffeeShop.Api
   ```
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Run the application:
   ```bash
   dotnet run
   ```
   The API will be available at `https://localhost:7001` and `http://localhost:5001`

### API Endpoints

#### Brew Coffee

```http
GET /coffee/brew-coffee?location={city}
```

Parameters:
- `location` (optional): City name for weather check (defaults to "New York")

Responses:
- `200 OK`: Coffee brewed successfully
  - Returns iced coffee if temperature > 30°C
  - Returns hot coffee if temperature ≤ 30°C
- `418 I'm a teapot`: When request is made on April 1st
- `503 Service Unavailable`: Every 5th request per machine

Example:
```bash
curl "http://localhost:5001/coffee/brew-coffee?location=London"
```

### Running Tests

```bash
dotnet test
```

# Clean Architecture Implementation

This project follows Clean Architecture principles to maintain a separation of concerns and ensure the application is testable, maintainable, and scalable.

## Architecture Overview

```
┌──────────────────┐
│      API        │  REST API, Controllers, DTOs
├──────────────────┤
│   Application   │  Use Cases, Interfaces, Business Rules
├──────────────────┤
│     Domain      │  Entities, Value Objects, Core Rules
└──────────────────┘
        ▲
        │
┌──────────────────┐
│  Infrastructure  │  External Services, Persistence
└──────────────────┘

Dependencies flow inward:
Infrastructure → Application → Domain
```

## Architecture Layers

### Domain Layer (`_Domain/`)
- Core business entities and logic
- No dependencies on other layers or external frameworks
- Contains the `CoffeeMachine` entity which represents our core domain model
- Pure C# with no external dependencies

### Application Layer (`_Application/`)
- Contains business rules and use cases
- Implements CQRS pattern with Commands and Handlers
- Defines interfaces (ports) that are implemented by the infrastructure layer
- Key components:
  - Commands (e.g., `BrewCoffeeCommand`)
  - Command Handlers (e.g., `BrewCoffeeCommandHandler`)
  - Interfaces (e.g., `IWeatherService`, `ICoffeeMachineState`)
  - Business Rules (e.g., April Fools rule, 503 rule)

### Infrastructure Layer (`_Infrastructure/`)
- Implements interfaces defined in the Application layer
- Handles external concerns like:
  - External API communication (OpenWeatherMap)
  - State management
  - System time
- Examples:
  - `OpenWeatherMapService`: Implements `IWeatherService`
  - `CoffeeMachineState`: Implements `ICoffeeMachineState`

### API Layer (Root)
- Entry point of the application
- Handles HTTP requests and responses
- Depends on Application layer, not on Infrastructure
- Uses dependency injection to wire up implementations
- Contains:
  - Controllers
  - DTOs
  - Configuration
  - Dependency injection setup

## Key Principles Applied

1. **Dependency Inversion**
   - Core business logic doesn't depend on external concerns
   - Interfaces defined in Application layer, implemented in Infrastructure

2. **Separation of Concerns**
   - Each layer has a specific responsibility
   - Clear boundaries between business logic and external concerns

3. **CQRS Pattern**
   - Commands for write operations (brewing coffee)
   - Clear separation of command models and response DTOs

4. **Dependency Injection**
   - All dependencies are injected
   - Makes the application more testable and maintainable

5. **Interface Segregation**
   - Small, focused interfaces (e.g., `IWeatherService`, `ICoffeeMachineState`)
   - Each interface serves a specific purpose

# Project Structure

