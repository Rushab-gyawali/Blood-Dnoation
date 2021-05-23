CREATE OR ALTER PROCEDURE [dbo].[PROC_USER_LOGIN]
(
     @FLAG           NVARCHAR(20)       = NULL
    ,@UserName       NVARCHAR(100)      = NULL
    ,@Password       NVARCHAR(100)      = NULL
    ,@Ip             NVARCHAR(255)      = NULL
    ,@LastLoginTime  DATETIME           = NULL
    ,@LoginTime      DATETIME           = NULL
    ,@BrowserInfo    NVARCHAR(255)      = NULL
    ,@Status         BIT                = NULL
)
AS
BEGIN

    IF (@FLAG = 'login')
    BEGIN
        IF NOT EXISTS
        (
            SELECT 'X'
            FROM [dbo].TBL_STAFF
            WHERE UserName = @UserName
                  AND [Password] = @Password
                  AND isActive = 1
        )
        BEGIN
            INSERT INTO TBL_LOGIN_LOG
            (
                UserName,
                [Ip],
                LoginTime,
                BrowserInfo,
                [Status]
            )
            VALUES
            (@UserName, @Ip, GETDATE(), @BrowserInfo, 'Failed');

            SELECT '1' AS CODE,
                   'User not register ' AS Msg;
            RETURN;
        END;
        ELSE
        BEGIN
            BEGIN TRY
                BEGIN TRANSACTION;
                DECLARE @company VARCHAR(100);
                INSERT INTO TBL_LOGIN_LOG
                (
                    UserName,
                    [Ip],
                    LoginTime,
                    BrowserInfo,
                    [Status]
                )
                VALUES
                (@UserName, @Ip, GETDATE(), @BrowserInfo, 'Success');              
                SELECT '0' AS CODE,
                       'Login successful. ' AS Msg,
                       StaffFullName,
                       UserName   
                FROM dbo.TBL_Staff (NOLOCK)                   
                WHERE UserName = @UserName;
                BEGIN
                    COMMIT TRANSACTION;
                    SELECT '0' AS ErrorCode,
                           'Inserted Successfully' AS [Message];
                END;
            END TRY
            BEGIN CATCH
                IF @@trancount > 0
                BEGIN
                    ROLLBACK TRANSACTION;
                    SELECT '1' AS ErrorCode,
                           ERROR_MESSAGE() [Message];
                END;
            END CATCH;
            RETURN;
        END;
    END;
END;
GO
