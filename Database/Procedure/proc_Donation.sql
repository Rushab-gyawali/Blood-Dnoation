create or alter procedure proc_Donation
@Flag nvarchar(200)	=null
,@DonorId	NVARCHAR(10)	=null
,@LastDonationDate datetime = null
,@DonationDate	datetime	=null
as
begin
If @Flag = 'GetLastDonationDate'
begin
select DonorId,LastDonationDate from table_1 where DonorId = @DonorId
end
else if @Flag = 'Donation'
begin
insert into Table_1 
(DonorId,LastDonationDate,Newdonationdate)
values
(@DonorId,@LastDonationDate,@DonationDate)
	SELECT '0' AS ErrorCode, 'Succesfully Added' As Msg
end

end


