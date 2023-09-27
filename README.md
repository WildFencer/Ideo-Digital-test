# Ideo-Digital-test

Server side:
For simplicity used Minimal API architecture.
** The V1 of the project is working and can be checked via swagger or postmen. **
TODO: Logs infrastructure should be added.
Possible TODO: Unit tests could be added.

DB:
Used minimalistic structure:
Customer (Id, Surname, Name, Address, Email, Subscribtion Period).
Invoice (Id, CustomerId, Amount, Description, BillingStatusId, CreateDate).
BillingStatus (Id, StatusName).
** DB Migration (with initial seeds) created on server side and can be checked **

Client Side:
General Architecture provided with basic code examples for most of parts.
State management did not implemented by the reason of excessive complexity in current stage.
** This project version did not finished and can't be run **
TODO: Implement all missing parts.
TODO: Build unit tests (Karma).
