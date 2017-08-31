--15082017
ALTER procedure [dbo].[pro_Ins_Items]
(
	@ItemCode varchar(50),
	@ItemName nvarchar(max),
	@Active nvarchar(max),
	@UsageCode varchar(50),
	@UnitOfMeasureCode varchar(50),
	@ItemCategoryCode varchar(50),
	@UnitPrice numeric(18, 3),
	@Status int,
	@SalesPrice numeric(18, 3),
	@SafelyQuantity int,
	@RepositoryCode nvarchar(250),
	@udate datetime,
	@EmployeeCode varchar(50),
	@BHYTPrice numeric(18, 3),
	@ListBHYT int,
	@RateBHYT int,
	@CountryCode varchar(6),
	@ProducerCode varchar(50),
	@Note nvarchar(100),
	@DisparityPrice numeric(18,4),
	@ListService int=0,
	@VendorCode varchar(200),
	@Packed nvarchar(50),
	@QtyOfMeasure int,
	@ItemContent nvarchar(50),
	@STTBCBHYT varchar(50),
	@SODKGP varchar(50),
	@STTQDPK varchar(50),
	@QUYCACH nvarchar(max),
	@Generic_BD char(1),
	@VENCode char(1),
	@Active_TT40 varchar(20)='',
	@SalesPrice_Retail decimal(18,4)=0,
	@UnitOfMeasureCode_Medi varchar(15)='',
	@Converted_Medi bit=1,
	@Is_Acttach_Service int,
	@Is_Service_Auto int
)
as
begin
	if exists(select ItemCode from Items where ItemCode=@ItemCode)
		begin		
			update Items set ItemName=@ItemName,Active=@Active,UsageCode=@UsageCode,UnitOfMeasureCode=@UnitOfMeasureCode,ItemCategoryCode=@ItemCategoryCode,UnitPrice=@UnitPrice,[Status]=@Status,SalesPrice=@SalesPrice,SafelyQuantity=@SafelyQuantity,RepositoryCode=@RepositoryCode,idate=GETDATE(),
			BHYTPrice=@BHYTPrice,ListBHYT=@ListBHYT,RateBHYT=@RateBHYT,CountryCode=@CountryCode,ProducerCode=@ProducerCode,Note=@Note,DisparityPrice=@DisparityPrice,ListService=@ListService,VendorCode=@VendorCode,Packed=@Packed,QtyOfMeasure=@QtyOfMeasure,ItemContent=@ItemContent,STTBCBHYT=@STTBCBHYT,
			SODKGP=@SODKGP,STTQDPK=@STTQDPK,QUYCACH=@QUYCACH,Generic_BD=@Generic_BD,VENCode=@VENCode,Active_TT40=@Active_TT40,SalesPrice_Retail=@SalesPrice_Retail,UnitOfMeasureCode_Medi=@UnitOfMeasureCode_Medi,Converted_Medi=@Converted_Medi ,
			Is_Acttach_Service=@Is_Acttach_Service , Is_Service_Auto=@Is_Service_Auto
			where ItemCode=@ItemCode
		end
	else
	begin
		declare @_ItemCode varchar(50)
		declare @_stt decimal(8,0)
		set @_stt = (select top(1) CONVERT(decimal(18,0),RIGHT(ItemCode,6)) maxcode from Items order by CONVERT(decimal(18,0),RIGHT(ItemCode,6)) desc)+1
		if(@_stt<=9)
			begin
				set @_ItemCode = 'TH00000'+convert(varchar(5),@_stt)
			end
		else if(@_stt>9 and @_stt<=99)
			begin
				set @_ItemCode = 'TH0000'+convert(varchar(6),@_stt)
			end
		else if(@_stt>99 and @_stt<=999)
			begin
				set @_ItemCode = 'TH000'+convert(varchar(6),@_stt)
			end
		else if(@_stt>999 and @_stt<=9999)
			begin
				set @_ItemCode = 'TH00'+convert(varchar(6),@_stt)
			end
		else if(@_stt>9999 and @_stt<=99999)
			begin
				set @_ItemCode = 'TH0'+convert(varchar(6),@_stt)
			end
		else if(@_stt>99999 and @_stt<=999999)
			begin
				set @_ItemCode = 'TH'+convert(varchar(6),@_stt)
			end
		else
			begin
				set @_ItemCode = 'TH000001'
			end
		insert into Items(ItemCode,ItemName,Active,UsageCode,UnitOfMeasureCode,ItemCategoryCode,UnitPrice,Status,SalesPrice,SafelyQuantity,RepositoryCode,idate,udate,EmployeeCode,BHYTPrice,ListBHYT,RateBHYT,CountryCode,ProducerCode,Note,DisparityPrice,ListService,VendorCode,Packed,QtyOfMeasure,ItemContent,STTBCBHYT,SODKGP,STTQDPK,QUYCACH,Generic_BD,VENCode,Active_TT40,SalesPrice_Retail,UnitOfMeasureCode_Medi,Converted_Medi,Is_Acttach_Service , Is_Service_Auto) 
		values(@_ItemCode,@ItemName,@Active,@UsageCode,@UnitOfMeasureCode,@ItemCategoryCode,@UnitPrice,@Status,@SalesPrice,@SafelyQuantity,@RepositoryCode,GETDATE(),@udate,@EmployeeCode,@BHYTPrice,@ListBHYT,@RateBHYT,@CountryCode,@ProducerCode,@Note,@DisparityPrice,@ListService,@VendorCode,@Packed,@QtyOfMeasure,@ItemContent,@STTBCBHYT,@SODKGP,@STTQDPK,@QUYCACH,@Generic_BD,@VENCode,@Active_TT40,@SalesPrice_Retail,@UnitOfMeasureCode_Medi,@Converted_Medi,@Is_Acttach_Service , @Is_Service_Auto)
	end
end
go
ALTER procedure [dbo].[proList_Items]
(
	@ItemCode varchar(50)
)
as
begin
	if exists(select ItemCode from Items where ItemCode=@ItemCode and Is_Acttach_Service=1)
	select a.AttachServiceCode,s.ServiceName from Attach_Service a inner join Service  s  on a.AttachServiceCode=s.ServiceCode where ItemCode=@ItemCode
end

go

Alter procedure [dbo].[pro_LayGia]
(
	@ServiceCode varchar(50)
)
as
begin
	select RowID,UnitPrice from ServicePrice where ServiceCode=@ServiceCode
end 
