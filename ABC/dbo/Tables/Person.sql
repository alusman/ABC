CREATE TABLE [dbo].[Person] (
    [Id]      UNIQUEIDENTIFIER CONSTRAINT [DF_Person_Id] DEFAULT (newid()) NOT NULL,
    [Name]    NVARCHAR (50)    NOT NULL,
    [Address] NVARCHAR (255)   NOT NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id] ASC)
);

