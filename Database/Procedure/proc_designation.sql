CREATE OR ALTER PROCEDURE PROC_DESIGNATION
(
@Flag			Nvarchar(100)			= Null
,@DesignationId	nvarchar(100)			=Null
,@Designationname Nvarchar(100)			=Null
,@Remarks			Nvarchar(500)		= Null
,@User				Nvarchar(100)		= Null
)
AS 
	BEGIN
		IF(@Flag = 'List')
		BEGIN
		SELECT * FROM TBL_DESIGNATION (NOLOCK)
		END

		ELSE IF(@Flag='GetDesignationById')
		BEGIN
		SELECT * FROM TBL_DESIGNATION where DesignationId =@DesignationId
		END

		ELSE IF (@Flag = 'Insert')
		 BEGIN        
			IF EXISTS (SELECT 'X' FROM TBL_DESIGNATION WHERE DesignationName = @Designationname)
			BEGIN
			    SELECT 1 AS ErrorCode,
			           'Designation Already Exists!' AS [Message];
			END;
			ELSE
			BEGIN TRY
			    BEGIN TRANSACTION;			    
			    INSERT INTO TBL_DESIGNATION
			    (DesignationId,DesignationName,Remarks,CreatedBy,CreatedDate,IsActive)
				VALUES
			    (@DesignationId,@Designationname,@Remarks,@User,GETDATE(),'1');            
			    BEGIN
			        COMMIT TRANSACTION;
			        SELECT '0' errorCode,'Designation Added Succesfully' msg;
			    END;
			END TRY
			BEGIN CATCH
			    IF (@@ERROR > 0)
			    BEGIN
			        ROLLBACK TRANSACTION;
			        SELECT '1' AS errorCode,
			               ERROR_MESSAGE() AS msg,
			               ERROR_LINE() id;
			    END;
			END CATCH;
		END;
		ELSE IF (@Flag = 'Update')
		 BEGIN        
			IF EXISTS (SELECT 'X' FROM TBL_DESIGNATION WHERE DesignationName <> @Designationname)
			BEGIN
			    SELECT 1 AS ErrorCode,
			           'Designation Not Exists!' AS [Message];
			END;
			ELSE
			BEGIN TRY
			    BEGIN TRANSACTION;			    
			    UPDATE  TBL_DESIGNATION SET
			    DesignationId=@DesignationId,DesignationName=@Designationname,Remarks=@Remarks,CreatedBy=@User,CreatedDate=GETDATE(),IsActive='1'
	            where DesignationId= @DesignationId
			    BEGIN
			        COMMIT TRANSACTION;
			        SELECT '0' errorCode,'Designation Updated Succesfully' msg;
			    END;
			END TRY
			BEGIN CATCH
			    IF (@@ERROR > 0)
			    BEGIN
			        ROLLBACK TRANSACTION;
			        SELECT '1' AS errorCode,
			               ERROR_MESSAGE() AS msg,
			               ERROR_LINE() id;
			    END;
			END CATCH;
		END;

		
END