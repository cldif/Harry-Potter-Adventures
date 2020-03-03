# Harry-Potter-Adventures

# Backend
The backend was generated with [Visual Studio 2019](https://visualstudio.microsoft.com/fr/vs/).

## Requirements
Some tools are required to use the back. You need to install : 
- Visual Studio
- - with IISExpress
- - with SQL LocalDb
- EntityFramework 4.7.2
- SQL Management Studio

## Development
The project is called `Isima`.
#### Files
To launch the project, double click on the file `Isima.sln`
The project is divided in subparts.
##### Isima.API
Contains the API and the controllers to add routes.
##### Isima.Business
Contains the Business Layer.
##### Isima.DAL
Contains the Data Access Layer
- The EMDX file with the database model
- The repository of each class (Scenario and Choice)
- The class Scenario and Choice

##### Isima.DTO
Contains the DTO for each class (Scenario and Choice)

##### Isima.Tools
Contains some useful functions in the `Extensions.cs` file :
- ToEntity create an entity from a Dto Element
- ToDto create a Dto element from an entity

### Database
The database is stored on our Azure account. If you want to access to it, you need to ask for permission by sending us an email.

## Starting
Click the `IISExpress (Google Chrome)` button (the greed triangle button) to start the backend
It will automaticaly open a web browser with the url `http://localhost:4034/`. 
### Swagger
To see the swagger screen of the different API available, navigate to `http://localhost:4034/swagger`
### API
To get the result of our API : 
`http://localhost:4034/api/Scenario`
`http://localhost:4034/api/Choice`


# Frontend

The Frontend was generated with [Angular CLI](https://github.com/angular/angular-cli) version 8.3.23.

## Requirements

Angular requires a current, active LTS, or maintenance LTS version of Node.js.
You can install the Node Packet Manager by running the following command on a Debian-based system:

```
apt install npm
```

Then, you will need to install the Angular CLI to be able to launch the development server.
Please run the following command:

```
npm install -g @angular/cli
```

## Development server

Before starting the server, always make sure that the dependencies are up to date. To do this, please run the following command in the "Front" folder of our project:

```
npm install
```

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
