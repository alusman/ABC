CREATE procedure [dbo].[InsertPerson]
@Name nvarchar(50),
@Address nvarchar(255),
@Id uniqueidentifier output
as

select @Id = NEWID()

INSERT INTO [dbo].[Person] ([Id], [Name], [Address])
     VALUES (@Id, @Name, @Address)

select @Id
