
Create or ALTER   PROC [dbo].[proc_Donor]
(
@Flag NVARCHAR(50) = NULL
,@DonorId INT = NULL
,@FirstName NVARCHAR(100) = NULL
,@MiddleName NVARCHAR(100) = NULL
,@LastName NVARCHAR(100) = NULL
,@Gender NVARCHAR(50) = NULL
,@DateofBirth Date = NULL
,@BloodGroup NVARCHAR(50) = NULL
,@Email NVARCHAR(100) = NULL
,@PhoneNo NVARCHAR(10) = NUll
,@District NVARCHAR(100) = NULL
,@Munciplity NVARCHAR(100) = NULL
,@City NVARCHAR(100) = NULL
,@WardNo INT = NULL
,@CreatedBy NVARCHAR(100) = NULL
,@CreatedDate DATETIME = NULL
)

AS 
	BEGIN
		IF(@Flag = 'List')
		Begin
		SELECT * FROM TBL_DONOR (NOLOCK) WHERE IsActive = '1'
		END

		IF(@Flag = 'Insert')
		BEGIN
		INSERT INTO TBL_DONOR(FirstName,MiddleName,LastName,Gender,BateOfBirth,BloodGroup,Email,PhoneNo,District,Munciplity,City,WardNo,CreatedBy, CreatedDate)
		VALUES (@FirstName,@MiddleName,@LastName,@Gender,@DateofBirth,@BloodGroup,@Email,@PhoneNo,@District,@Munciplity,@City,@WardNo,@CreatedBy, GETDATE())
		SELECT '0' AS ErrorCode, 'Succesfully Added' As Msg
		END

		IF(@Flag = 'Update')
		BEGIN
		UPDATE TBL_DONOR
		SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName,Gender = @Gender,BateOfBirth= @DateofBirth,BloodGroup = @BloodGroup,Email = @Email,PhoneNo = @PhoneNo ,District=@District,Munciplity = @Munciplity,City = @City,WardNo = @WardNo,CreatedBy = 'admin', CreatedDate = GETDATE()
		Where DonorId = @DonorId
		select '0' as ErrorCode,'Sucessfully Updated' as Msg
		END

		IF(@Flag = 'Delete')
		BEGIN
		UPDATE TBL_DONOR 
		SET IsActive = '0' WHERE DonorId = @DonorId
		select '0' as ErrorCode,'Sucessfully Deleted' as Msg
		END
	END