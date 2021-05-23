CREATE OR ALTER PROC proc_Staff
(
 @flag			Nvarchar(200)				=null
,@StaffId        int                       =null
,@user			Nvarchar(200)				=null
,@staffFirstName			Nvarchar(200)	=null
,@StaffMiddleName		Nvarchar(200)		=null
,@StaffLastName		Nvarchar(200)			=null
,@Gender NVARCHAR(50)					= NULL
,@DateofBirth Date						= NULL
,@Email NVARCHAR(100)					= NULL
,@PhoneNo NVARCHAR(10)					= NUll
,@District NVARCHAR(100)				= NULL
,@Munciplity NVARCHAR(100)				= NULL
,@City NVARCHAR(100)					= NULL
,@Designation NVARCHAR(100)					= NULL
,@StaffAddress NVARCHAR(100)			= NULL
,@WardNo INT							= NULL
,@CreatedBy NVARCHAR(100)				= NULL
,@CreatedDate DATETIME					= NULL
,@BloodGroup NVARCHAR(50) = NULL
,@Password NVARCHAR(50) = NULL
,@UserName NVARCHAR(50) = NULL
)
As 
	Begin 
	-----------------------------------------------------------------------------------------------------------------------------------------------
			If(@flag = 'List')
				Begin
				SELECT * FROM TBL_STAFF (NOLOCK) WHERE IsActive = '1' 
				END
	------------------------------------------------------------------------------------------------------------------------------------------------
			If (@flag = 'InsertStaff')
			Begin
				Insert Into TBL_STAFF(
				StaffFirstName,
				StaffMiddleName,
				StaffLastname,
				Gender,
				Email,
				PhoneNo,
				District,
				Munciplity,
				City,
				WardNo,
				StaffAddress,
				CreatedBy,
				CreatedDate,
				CreatedDateUTC,
				Designation,
				DateOfBirth,
				IsActive,
				UserName,
				[Password])
				Values(
				@staffFirstName,
				@StaffMiddleName,
				@StaffLastName,
				@Gender,
				@Email,
				@PhoneNo,
				@District,
				@Munciplity,
				@City,
				@WardNo,
				@StaffAddress,
				@CreatedBy,
				GETDATE(),
				GETUTCDATE(),
				'default',
				@DateofBirth,
				'1',
				@UserName,
				@Password)
				SELECT '0' AS ErrorCode, 'Succesfully Added' As Msg
			END
			IF(@flag ='getStaffById')
			BEGIN
			SELECT * FROM TBL_STAFF(NOLOCK) WHERE StaffId = @StaffId AND IsActive = '1'
			END
			IF(@Flag = 'Update')
		BEGIN
		UPDATE TBL_STAFF
		SET StaffFirstName = @staffFirstName, StaffMiddleName = @StaffMiddleName,
		StaffLastName = @StaffLastName,Gender = @Gender,
		DateOfBirth= @DateofBirth,Email = @Email,PhoneNo = @PhoneNo ,
		District=@District,Munciplity = @Munciplity,City = @City,WardNo = @WardNo,CreatedBy = 'admin', CreatedDate = GETDATE()
		
		Where StaffId = @StaffId
		select '0' as ErrorCode,'Sucessfully Updated' as Msg
		END
	------------------------------------------------------------------------------------------------------------------------------------------------
	End