CREATE TABLE ProjectMessage
(
    MessageId INT PRIMARY KEY,
    ProjectId INT,
    PersonId INT,
    Message NVARCHAR(MAX),
    Timestamp DATETIME,
    FOREIGN KEY (ProjectId) REFERENCES Project(ProjectId),
    FOREIGN KEY (PersonId) REFERENCES Person(PersonId)
);