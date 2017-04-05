CREATE TABLE [dbo].[Employees]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Payrate] DECIMAL NULL, 
    [Shift] NCHAR(10) NULL, 
    [StartDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NULL, 
    [FullTime] BIT NULL, 
    [Volunteer] BIT NULL, 
    [PersonInfo] INT NOT NULL REFERENCES [PersonPrivate] ON UPDATE CASCADE ON DELETE CASCADE 
)
