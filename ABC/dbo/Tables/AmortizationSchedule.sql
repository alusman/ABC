CREATE TABLE [dbo].[AmortizationSchedule] (
    [Id]           UNIQUEIDENTIFIER CONSTRAINT [DF_AmortizationSchedule_Id] DEFAULT (newid()) NOT NULL,
    [PersonUnitId] UNIQUEIDENTIFIER NOT NULL,
    [Date]         DATETIME         NOT NULL,
    [Principal]    DECIMAL (18)     NOT NULL,
    [Interest]     DECIMAL (18)     NOT NULL,
    [LoanAmount]   DECIMAL (18)     NOT NULL,
    [NoOfDays]     INT              NOT NULL,
    [Total]        DECIMAL (18)     NOT NULL,
    [Balance]      DECIMAL (18)     NOT NULL,
    CONSTRAINT [PK_AmortizationSchedule] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AmortizationSchedule_PersonUnit] FOREIGN KEY ([PersonUnitId]) REFERENCES [dbo].[PersonUnit] ([Id])
);

