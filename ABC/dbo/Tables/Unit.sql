CREATE TABLE [dbo].[Unit] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [ProjectName]    NVARCHAR (50)    NOT NULL,
    [CondoUnit]      NVARCHAR (50)    NOT NULL,
    [LoanAmount]     DECIMAL (18)     NOT NULL,
    [Term]           INT              NOT NULL,
    [StartOfPayment] DATETIME         NOT NULL,
    [InterestRate]   FLOAT (53)       NOT NULL,
    CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED ([Id] ASC)
);

