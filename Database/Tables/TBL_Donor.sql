
CREATE TABLE [dbo].[TBL_Donor](
	[DonorId] [INT] IDENTITY(1,1)NOT NULL,
	[FirstName] [NVARCHAR](100) NOT NULL,
	[MiddleName] [NVARCHAR](100) NULL,
	[LastName] [NVARCHAR](100) NOT NULL,
	[FullName] AS Firstname + ' ' + ISNULL(MiddleName,'') + ' '  + LastName,
	[Gender] [NVARCHAR](50) NOT NULL,
	[BateOfBirth] [DATE] NOT NULL,
	[BloodGroup] [NVARCHAR](100) NOT NULL,
	[Email] [NVARCHAR](100) NOT NULL,
	[PhoneNo] [NVARCHAR](10) NOT NULL,
	[District] [NVARCHAR](100) NOT NULL,
	[Munciplity] [NVARCHAR](100) NOT NULL,
	[City] [NVARCHAR](100) NOT NULL,
	[WardNo] [INT] NOT NULL,
	[IsActive] [BIT] DEFAULT ('1') NULL,
	[CreatedBy] [NVARCHAR](100)NOT NULL,
	[CreatedDate] [DATETIME] DEFAULT GETDATE() NOT NULL,
	
)


--select * from tbl_DONOR





