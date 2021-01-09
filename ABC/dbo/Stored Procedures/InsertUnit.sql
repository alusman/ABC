CREATE procedure [dbo].[InsertUnit]
@ProjectName nvarchar(50),
@CondoUnit nvarchar(50),
@LoanAmount decimal(18,0),
@Term int,
@StartOfPayment datetime,
@InterestRate float,
@Id uniqueidentifier output
as

select @Id = NEWID()

INSERT INTO [dbo].[Unit] ([Id], [ProjectName], [CondoUnit], [LoanAmount], [Term], [StartOfPayment], [InterestRate])
     VALUES (@Id, @ProjectName, @CondoUnit, @LoanAmount, @Term, @StartOfPayment, @InterestRate)

select @Id
