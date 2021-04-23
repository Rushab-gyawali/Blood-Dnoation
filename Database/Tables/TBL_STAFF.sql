CREATE TABLE TBL_STAFF(
 StaffId INT IDENTITY(1,1)  NOT NULL
,StaffFirstName NVARCHAR(100) NOT NULL
,StaffMiddleName NVARCHAR(100) NULL
,StaffLastname NVARCHAR(100) NOT NULL
,StaffFullName AS StaffFirstName + ' ' + ISNULL([StaffMiddleName],'') + ' '  + StaffLastname
,Gender			Varchar(20)			Not Null
,Email		Nvarchar(255)		not Null
,PhoneNo		nvarchar(10)  not Null
,DateOfBirth	DateTime			Not Null
,District NVARCHAR(100) NOT NULL
,Munciplity NVARCHAR(100) NOT NULL
,City NVARCHAR(100) NOT NULL
,WardNo INT NOT NULL
,StaffAddress  Nvarchar(100)						Not Null
,CreatedBy		Nvarchar(100)						Not Null
,CreatedDate		DateTime							Not Null
,CreatedDateUTC		DateTime						Not Null	
,UpdatedBy		Nvarchar(100)						 Null
,UpdatedDate		DateTime							 Null
,UpdatedDateUTC		DateTime						 Null
,IsActive				Bit							 Null	
,Designation			NvARCHAR(100)				Not Null

)


