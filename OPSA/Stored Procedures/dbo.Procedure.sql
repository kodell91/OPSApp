CREATE PROCEDURE [dbo].[SelectEmployees]
	@RockStarKey int,
	@EmployeeName nvarchar(255),
	@Tenure float,
	@StartDate datetime,
	@Position nvarchar(255),
	@Branch nvarchar(255)
AS
	SELECT @RockStarKey, @EmployeeName, @Tenure, @StartDate, @Position, @Branch
	FROM [Four WK Rockstars] Where @RockStarKey IS NOT NULL
