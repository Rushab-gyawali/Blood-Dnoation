CREATE OR ALTER PROC proc_Staff
(
@flag			Nvarchar(200)				=null
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
,@StaffAddress NVARCHAR(100)			= NULL
,@WardNo INT							= NULL
,@CreatedBy NVARCHAR(100)				= NULL
,@CreatedDate DATETIME					= NULL
)
As 
	Begin 
	-----------------------------------------------------------------------------------------------------------------------------------------------
			If(@flag = 'List')
				Begin
				SELECT * FROM TBL_STAFF (NOLOCK) WHERE IsActive = '1')
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
				IsActive)
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
				'1')
				SELECT '0' AS ErrorCode, 'Succesfully Added' As Msg
			END
			
	------------------------------------------------------------------------------------------------------------------------------------------------
	End