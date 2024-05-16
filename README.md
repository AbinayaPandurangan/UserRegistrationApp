# User Registration App

The App collects the data from the users, validates them and registers the users in the Database. The collected data is then shown as a Confirmation for the Registered Users. As advised in the Test prompt, I restricted my use of Libraries and I styled the app using vanilla CSS.

## How it works

Step 1: The User information like Name, Date of Birth, Email, Phone No. and Gender is validated to check if it is in the correct data type and if it contains data (not empty) in the Client side.

Step 2: Then the data in validated in the server side, to check if the data is in the correct format and to check if the user is already registered, if not, the data is then saved to the database.

Step 3: As a confirmation, the registered user information is then received by the Client and is presented to the users.

## Set-up and run API:

Navigate to the root folder<br/>
In cmd line - run the below cmds <br/>
cd "Podme.UserRegistrationApp.Api"<br/>
dotnet run<br/>
To Confirm that the API is running, open in the browser "https://localhost:7039/index.html"

## Set-up and run UI:

Navigate to the root folder<br/>
In cmd line - run the below cmds<br/>
cd "Podme.UserRegistrationApp.Client"<br/>
npm install<br/>
npm run dev<br/>
Run in the Browser "https://localhost:3000"

## Test Data:

Test Data Files are available in the "TestData-ForApi" folder in the root path

## TechStack:

Backend:<br/>

1. .Net 6
2. SQLite
3. xUnit
4. Moq
5. Entity Framework
6. Fluent Validation
7. AutoMapper
8. Serilog

Frontend: </br>

1. React
2. TypeScript
3. Vanilla CSS
