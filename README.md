# Project Structure

This document outlines the project structure of the CoffeeShop.Api application.

## Root Directory

- `.gitattributes`: Git attributes configuration.
- `.gitignore`: Specifies intentionally untracked files to ignore.
- `appsettings.Development.json`: Application settings for the Development environment.
- `appsettings.json`: Base application settings.
- `CoffeeShop.Api.csproj`: C# project file for the API.
- `CoffeeShop.Api.http`: HTTP client request definitions.
- `CoffeeShop.Api.slnx`: Solution file.
- `Program.cs`: Entry point of the application.
- `README.md`: Project README file.
- `WeatherForecast.cs`: Example weather forecast model.


## `_Application/`

This directory contains application-specific logic, including interfaces and command handlers.

- `DependencyInjection.cs`: Dependency injection configuration for the application layer.
- `ICoffeeMachineState.cs`: Interface for managing coffee machine state.
- `IDateTimeProvider.cs`: Interface for providing date and time.

### `_Application/_Rules/`

This folder is intended for application-specific business rules.

### `_Application/BrewCoffee/`

This directory contains files related to the "Brew Coffee" feature.

- `BrewCoffeeCommand.cs`: Command for brewing coffee.
- `BrewCoffeeCommandHandler.cs`: Handler for the `BrewCoffeeCommand`.
- `BrewCoffeeResponse.cs`: Response for the "Brew Coffee" command.

## `_Domain/`

This directory contains the core domain entities and logic.

- `CoffeeMachine.cs`: Represents the `CoffeeMachine` domain entity.

## `_Infrastructure/`

This directory contains infrastructure-related implementations, such as data access and external service integrations.

- `CoffeeMachineState.cs`: Implementation of `ICoffeeMachineState`.
- `DependencyInjection.cs`: Dependency injection configuration for the infrastructure layer.
- `SystemDateTimeProvider.cs`: Implementation of `IDateTimeProvider` using the system's date and time.

## `bin/`

This folder contains the compiled binaries of the application.

## `Controllers/`

This directory contains API controllers.

- `CoffeeController.cs`: API controller for coffee-related operations.
- `WeatherForecastController.cs`: Example API controller for weather forecasts.

## `obj/`

This folder contains intermediate build outputs.

## `Properties/`

This directory contains project properties and settings.

- `launchSettings.json`: Debug launch settings for the application.
