# Real-Time Weather Monitoring and Reporting Service

## Description
This console application simulates a real-time weather monitoring and reporting service. It processes raw weather data from various weather stations and activates different types of bots based on the weather conditions.

## Features
- Supports multiple input formats: JSON and XML.
- Configurable bots (RainBot, SunBot, SnowBot) that react to weather data.
- Configuration settings controlled via a JSON file.
- Follows SOLID design principles with Observer and Strategy design patterns.

## Input Formats

### JSON
```json
{"Location": "City Name", "Temperature": 23.0, "Humidity": 85.0}

```
### XML
```xml
<WeatherData><Location>City Name</Location><Temperature>23.0</Temperature><Humidity>85.0</Humidity></WeatherData>
```
## Configuration
The application uses a configuration file (`AppConfigSetting.json`) to manage bot settings, including:

##### Enabled/disabled status

##### Activation thresholds

##### Activation messages
## Getting Started
### Clone the repository
```Arduion
git clone https://github.com/yourusername/real-time-weather-monitoring.git
cd real-time-weather-monitoring
```
### Run the appliccation
```vs
dotnet run
```
And just enter the city after city information to activate the `Bots`.
[![Build and Test](https://github.com/RasheedHendawi/Real-time-weather-monitoring-and-reporting-service/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/RasheedHendawi/Real-time-weather-monitoring-and-reporting-service/actions/workflows/build-and-test.yml)
