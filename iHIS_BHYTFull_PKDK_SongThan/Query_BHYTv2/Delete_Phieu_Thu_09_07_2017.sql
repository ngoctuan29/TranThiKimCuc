USE [iHIS_SongThan]
----Sung-09/08/2017
GO
ALTER procedure [dbo].[prDel_PhieuThuTien]
(
	@iresult int output,
	@RowID numeric(18, 0),
	@ReceiveID numeric(18, 0),
	@PatientCode varchar(50),
	@ServiceCode varchar(50)
)
as
begin
	if exists(select ReceiptID from SuggestedServiceReceipt where ReceiptID=@RowID and PatientCode=@PatientCode and ServiceCode=@ServiceCode and RefID=@ReceiveID)
	begin
		if exists(select ReceiptID from SuggestedServiceReceipt where ReceiptID=@RowID and PatientCode=@PatientCode and ServiceCode=@ServiceCode and RefID=@ReceiveID and  Status=0 AND Paid=0)
			begin 
				delete from SuggestedServiceReceipt where ReceiptID=@RowID and PatientCode=@PatientCode and ServiceCode=@ServiceCode and RefID=@ReceiveID and  Status=0 AND Paid=0
				set @iresult =1
			end
		else
		begin
			set @iresult =-1
		end
	end
	else
		set @iresult =-2
end


