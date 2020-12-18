# How to run

 1. Build Auth service docker image from [Auth repository](https://github.com/CaptainOfPain/borrowIt.Auth): `docker build -t auth .`
 2. Build ToDo service docker image from [ToDo repository](https://github.com/CaptainOfPain/borrowIt.ToDo): `docker build -t todo .`
 3. Build Notifications service docker image from [Notifications repository](https://github.com/CaptainOfPain/borrowIt.Notifications): `docker build -t notifications .`
 4. Buid GatewayApi service docker image from [GatewayApi repository](https://github.com/CaptainOfPain/borrowIt.GatewayApi): `docker build -t gatewayapi .`
 5. Buid UI docker image from [UI repository](https://github.com/CaptainOfPain/borrowIt.UI): `docker build -t ui .`
 6. Run `docker-compose up` in root directory
 7. Open http://localhost in your browser

# What is BorrowIt
Borrowit is a basic microservices playground which contains in Borrowit.Common such functionalities as connecting and communication between services via RabbitMq, connecting to MongoDb, Generic Repositories, CQRS implementation, and Autofac registration modules, etc.

Other repositories shows how to use basic microservices architecture with Borrowit.Common:
 -  [Auth Service](https://github.com/CaptainOfPain/borrowIt.Auth) - service which provides JWT token authorization and user storage
 - [ToDo Service](https://github.com/CaptainOfPain/borrowIt.ToDo) - service which provides simple "To Do tasks" business logic. It synchronize Users from **Auth Service** by UserChangedEvent and then can create To Do Lists and Tasks for them.
- [Notifications Service](https://github.com/CaptainOfPain/borrowIt.Notifications) - service which provides push notifications. It synchronize Users from **Auth Service** by UserChangedEvent and then allows them to create push subscription. Also it catches ToDoListHourLeftEvent from **ToDo Service** and sends notification to user that his To Do List has an one hour left to finish.
- [GatewayApi Service](https://github.com/CaptainOfPain/borrowIt.GatewayApi) - service which provides GatewayApi functionallity using [Ocelot](https://ocelot.readthedocs.io/en/latest/introduction/gettingstarted.html)
- [UI](https://github.com/CaptainOfPain/borrowIt.UI) - Simple Front-End built with Angular and free template [Material Dashboard Angular](https://www.creative-tim.com/product/material-dashboard-angular2)