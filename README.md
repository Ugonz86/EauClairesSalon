## Eau Claire Salon _01/17/2020_

#### By _**Uriel Gonzalez**_

### Description

A C# and .NET Database Basics Project - This build out application uses a one-to-many relationship with Entity. The application includes two models, both with full CRUD functionality. With this functionality, the business owner will be able to add/read/edit the stylist's clientele.

The user can:

1. Add, view, edit and delete stylists
2. See a list of stylists
3. Add, view, edit and delete clients
4. Delete the stylist list
5. Delete the client list

## Setup/Installation Requirements

* This application requires MySQL.

1. Clone this repository:
  ```sh
  $ git clone https://github.com/Ugonz86/EauClaireSalon.git
  $ cd EauClairesSalon.Solution/HairSalon
  $ dotnet restore
  $ dotnet run
  ```

2. Open the App Settings file (EauClaireSalon/HairSalon/appsettings.json) and ensure that the MySQL username and password matches your MySQL credentials. database: uriel_gonzalez / password: epicodus

## Database Setup
```sh
1. CREATE DATABASE `uriel_gonzalez`
2. CREATE TABLE `clients` (`ClientId` int(11) NOT NULL AUTO_INCREMENT, `first_last` varchar(255) DEFAULT NULL, `StylistId` int(11) DEFAULT NULL, PRIMARY KEY (`ClientId`))
3. CREATE TABLE `stylists` (`StylistId` int(11) NOT NULL AUTO_INCREMENT, `Name` varchar(255) DEFAULT NULL, PRIMARY KEY (`StylistId`))

```
## Known Bugs
* No known bugs at this time.

## Technologies Used
* C# / .NET / ASP.NET Core MVC / HTML / My SQL / Entity

## Support and contact details

_Please contact me with questions and comments: ugonzalez86@gmail.com._

### License

*MIT License*

Copyright (c) 2019 **_Uriel Gonzalez_**
