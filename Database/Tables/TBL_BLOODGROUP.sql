CREATE TABLE TBL_BLOODGROUP(
RowId INT IDENTITY(1,1) NOT NULL,
BloodGroup NVARCHAR(10) NULL,
)

INSERT INTO TBL_BLOODGROUP
(BloodGroup) VALUES ('A+')
INSERT INTO TBL_BLOODGROUP
(BloodGroup) VALUES ('A-')
INSERT INTO TBL_BLOODGROUP
(BloodGroup) VALUES ('B+')
INSERT INTO TBL_BLOODGROUP
(BloodGroup) VALUES ('B-')
INSERT INTO TBL_BLOODGROUP
(BloodGroup) VALUES ('AB+')
INSERT INTO TBL_BLOODGROUP
(BloodGroup) VALUES ('AB-')
INSERT INTO TBL_BLOODGROUP
(BloodGroup) VALUES ('O+')
INSERT INTO TBL_BLOODGROUP
(BloodGroup) VALUES ('A-')

select * from tbl_Bloodgroup

