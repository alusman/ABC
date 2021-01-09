CREATE procedure [dbo].[InsertPersonUnit]
@PersonId nvarchar(50),
@UnitId nvarchar(255),
@Id uniqueidentifier output
as

select @Id = NEWID()

INSERT INTO [dbo].[PersonUnit] ([Id], [PersonId], [UnitId])
     VALUES (@Id, @PersonId, @UnitId)

select @Id
