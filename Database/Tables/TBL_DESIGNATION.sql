CREATE TABLE TBL_DESIGNATION
(
RowId INT IDENTITY(1,1) NOT NULL
,DesignationId NVARCHAR(200)  NULL
,DesignationName NVARCHAR(200) NOT NULL
,Remarks NVARCHAR(500) NOT NULL
,IsActive BIT DEFAULT ('1') NULL
,CreatedBy NVARCHAR(100)NOT NULL
,CreatedDate DATETIME DEFAULT GETDATE() NOT NULL
,UpdatedBy NVARCHAR(100) NULL
,UpdatedDate DATETIME NULL
)

