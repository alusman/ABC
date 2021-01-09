create procedure dbo.UpdatePerson
@Id uniqueidentifier,
@Name nvarchar(50),
@Address nvarchar(255)
as


UPDATE [dbo].[Person]
   SET [Name] = @Name
      ,[Address] = @Address
 WHERE [Id] = @Id
