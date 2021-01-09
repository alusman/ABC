CREATE procedure [dbo].[UpdateUnit]
@Id uniqueidentifier,
@ProjectName nvarchar(50),
@CondoUnit nvarchar(50),
@LoanAmount decimal(18,0),
@Term int,
@StartOfPayment datetime,
@InterestRate float
as

UPDATE [dbo].[Unit]
   SET [ProjectName] = @ProjectName
	  ,[CondoUnit] = @CondoUnit
      ,[LoanAmount] = @LoanAmount
      ,[Term] = @Term
      ,[StartOfPayment] = @StartOfPayment
      ,[InterestRate] = @InterestRate
 WHERE [Id] = @Id
