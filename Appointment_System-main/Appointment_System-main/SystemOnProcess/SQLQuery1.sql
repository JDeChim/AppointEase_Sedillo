CREATE PROCEDURE sp_newUser 
@username nvarchar(50), 
@password nvarchar(50), 
@roleId int,
@createdBy int
AS
INSERT INTO UserAccount(userName, UserPassword, roleId, createdBy)
VALUES (@username, @password, @roleId, @createdBy)