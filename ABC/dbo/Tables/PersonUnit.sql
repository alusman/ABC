CREATE TABLE [dbo].[PersonUnit] (
    [Id]       UNIQUEIDENTIFIER CONSTRAINT [DF_PersonUnit_Id] DEFAULT (newid()) NOT NULL,
    [PersonId] UNIQUEIDENTIFIER NOT NULL,
    [UnitId]   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_PersonUnit] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PersonUnit_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_PersonUnit_Unit] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[Unit] ([Id])
);

