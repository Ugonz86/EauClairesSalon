# Eau Claire's Salon _01/17/2020_

## By _**Uriel Gonzalez**_

### Description

A C# and .NET Database Basics Project - This build out application uses a one-to-many relationship with Entity. The application includes two models, both with full CRUD functionality. With this functionality, the business owner will be able to add/read/edit the stylist's clientele.

The user can:

1. Add, view, edit, search and delete one or multiple stylists.
2. Add, view, edit, search and delete one or multiple clients.

## Setup/Installation Requirements

* This application requires MySQL.

1. Clone this repository:

  ```sh
  $git clone https://github.com/Ugonz86/EauClairesSalon.git
  $cd EauClairesSalon.Solution/HairSalon
  $dotnet restore
  $dotnet run
  ```

2. Open the App Settings file (EauClaireSalon/HairSalon/appsettings.json) and ensure that the MySQL username and password matches your MySQL credentials.

## Database Setup

```sh
1. mysql start
2. Access MySql by executing the command: `mysql -uroot -pepicodus`
3. CREATE DATABASE `uriel_gonzalez`
4. USE `uriel_gonzalez`
5. CREATE TABLE `clients` (`ClientId` int(11) NOT NULL AUTO_INCREMENT, `ClientName` varchar(255) DEFAULT NULL, `StylistId` int(11) DEFAULT NULL, PRIMARY KEY (`ClientId`))
6. CREATE TABLE `stylists` (`StylistId` int(11) NOT NULL AUTO_INCREMENT, `StylistName` varchar(255) DEFAULT NULL, PRIMARY KEY (`StylistId`))
7. CREATE TABLE `appointments` (`AppointmentId` int(11) NOT NULL AUTO_INCREMENT, `StylistId` int(11) NOT NULL, `ClientId` int(11) NOT NULL, `DateTime` datetime(6) NOT NULL, PRIMARY KEY (`AppointmentId`))
8. Run program with dotnet run (or $ dotnet watch run).

```

## Known Bugs

* Currently, the search bar in the clients page (Views/Index) is case sensitive. I am doing my research to resolve the issue apparently related to the method Include(). The search bar in the stylists page is not experiencing that issue.

## Technologies Used

* C# / .NET / ASP.NET Core MVC / HTML / My SQL / Entity

## Support and contact details

_Please contact me with questions and comments: ugonzalez86@gmail.com._

### License

* *MIT License*

Copyright (c) 2019 **_Uriel Gonzalez_**
