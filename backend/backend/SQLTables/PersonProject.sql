CREATE TABLE PersonProject
(
    PersonId INT,
    ProjectId INT,
    CansInProject INT DEFAULT 0,
    TotalMetersInProject int DEFAULT 0,
    StartLocation geography,
    EndLocation geography,
    GeoRoute geography,

    PRIMARY KEY (PersonId, ProjectId),
    FOREIGN KEY (PersonId) REFERENCES Person(PersonId),
    FOREIGN KEY (ProjectId) REFERENCES Project(ProjectId)
);