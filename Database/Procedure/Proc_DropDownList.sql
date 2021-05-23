CREATE OR ALTER PROCEDURE [dbo].[PROC_DROPDOWNLIST]
(
    @Status					VARCHAR(150) =	NULL,
    @Param					VARCHAR(100) =	NULL,
    @User					VARCHAR(100) =	NULL,
    @Flag					VARCHAR(100) =	NULL
)
AS
BEGIN
 IF (@Flag = 'DonorDropDown')
    BEGIN
        SELECT FullName,DonorId
               
        FROM TBL_Donor WITH (NOLOCK);
    END;

	Else  IF (@Flag = 'BloodGroup')
    BEGIN
        SELECT BloodGroup,RowId
               
        FROM TBL_BLOODGROUP WITH (NOLOCK);
    END;
	Else  IF (@Flag = 'Gender')
    BEGIN
        SELECT Gender,GenderId
               
        FROM TBL_GENDER WITH (NOLOCK);
    END;
End


