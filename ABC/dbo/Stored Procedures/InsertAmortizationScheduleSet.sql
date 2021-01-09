CREATE PROCEDURE dbo.InsertAmortizationScheduleSet
	@set AmortizationScheduleUDT readonly
as
begin
	INSERT INTO [dbo].[AmortizationSchedule]
	SELECT NEWID(), [PersonUnitId], [Date], [Principal], [Interest], [LoanAmount], [NoOfDays], [Total], [Balance]
	FROM @set;
end
