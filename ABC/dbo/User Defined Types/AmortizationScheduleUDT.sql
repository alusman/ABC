CREATE TYPE [dbo].[AmortizationScheduleUDT] AS TABLE (
    [PersonUnitId] UNIQUEIDENTIFIER NULL,
    [Date]         DATETIME         NULL,
    [Principal]    DECIMAL (18)     NULL,
    [Interest]     DECIMAL (18)     NULL,
    [LoanAmount]   DECIMAL (18)     NULL,
    [NoOfDays]     INT              NULL,
    [Total]        DECIMAL (18)     NULL,
    [Balance]      DECIMAL (18)     NULL);

