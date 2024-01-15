CREATE TABLE Person
(
    PersonId INT PRIMARY KEY,
    UserName NVARCHAR(255),
    Password NVARCHAR(255),
    CansOwned INT DEFAULT 0,

);