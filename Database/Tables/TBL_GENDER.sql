CREATE TABLE TBL_GENDER(
GenderId INT IDENTITY(1,1) NOT NULL,
Gender NVARCHAR(10) NULL,
)
INSERT INTO TBL_GENDER
(Gender) Values ('Male')

INSERT INTO TBL_GENDER
(Gender) Values ('FeMale')

INSERT INTO TBL_GENDER
(Gender) Values ('Other')

select * from tbl_gender

