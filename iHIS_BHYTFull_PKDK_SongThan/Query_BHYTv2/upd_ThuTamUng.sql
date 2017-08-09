if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Fee_Advance_Payment' and b.name='Counts')
	alter table Fee_Advance_Payment add Counts int not null default 1
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccount' and b.name='TotalBHYTPay')
	alter table BanksAccount add TotalBHYTPay decimal(18,2) not null default 0
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='BanksAccount' and b.name='TotalPatientPay')
	alter table BanksAccount add TotalPatientPay decimal(18,2) not null default 0
go
--- update pro_Ins_BanksAccount
IF NOT EXISTS (SELECT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Fee_NoteBook')
begin
CREATE TABLE Fee_NoteBook
(
	RowID int identity(100,1),
	Symbol nvarchar(100),
	NoteBookName nvarchar(200),
	FromNumber int not null,
	ToNumber int not null,
	WriteNumber int not null,
	NoteType int not null default 0,
	Hide int default 0,
	ShiftWork char(2),
	EmployeeCode varchar(15),
	EmployeeCodeUpd varchar(15),
	UDate varchar(20),
	CONSTRAINT pk_Fee_NoteBook PRIMARY KEY (RowID)
)
end
go
IF NOT EXISTS (SELECT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Fee_Advance_Payment')
begin
CREATE TABLE Fee_Advance_Payment
(
	RowID decimal(20,0) identity(100,1),
	PatientReceiveID numeric(18,0),
	PatientCode varchar(50),
	IDate datetime default getdate() not null,
	WorkingDateOrder varchar(20),
	AmountOrder decimal(20,0) not null default 0,
	EmployeeCodeOrder varchar(15),
	DepartmentCodeOrder varchar(15),
	ObjectCode int not null,
	Done smallint default 0,
	Paid smallint default 0,
	EmployeeCode varchar(15),
	AmountReal decimal(20,0),
	WorkingDate varchar(20),
	RowIDNoteBook int not null default 0,
	EmployeeCodeRePaid varchar(15),
	WorkingDateRePaid varchar(20),
	ReceiptNumber int not null,
	NoteRePaid nvarchar(200) default '' not null,
	BanksAccountCode varchar(20) default '' not null
	CONSTRAINT pk_Fee_Advance_Payment PRIMARY KEY (RowID),
	Constraint fk_FeePayment_Patients foreign key(PatientCode) references Patients(PatientCode),
	Constraint fk_FeePayment_PatientReceive foreign key(PatientReceiveID) references PatientReceive(PatientReceiveID)
)
end
go
--------
if exists(select name from sysobjects where name ='proIUFee_NoteBook')
	drop procedure proIUFee_NoteBook
go
create procedure proIUFee_NoteBook
(
	@RowID int,
	@Symbol nvarchar(100),
	@NoteBookName nvarchar(200),
	@FromNumber int,
	@ToNumber int,
	@WriteNumber int,
	@NoteType int,
	@Hide int,
	@ShiftWork char(2),
	@EmployeeCode varchar(15),
	@EmployeeCodeUpd varchar(15),
	@UDate varchar(20)
)
as
begin tran
	if exists(select RowID from Fee_NoteBook where RowID=@RowID)
		update Fee_NoteBook set Symbol=@Symbol,NoteBookName=@NoteBookName,FromNumber=@FromNumber,ToNumber=@ToNumber,WriteNumber=@WriteNumber,NoteType=@NoteType,Hide=@Hide,ShiftWork=@ShiftWork,EmployeeCode=@EmployeeCode,EmployeeCodeUpd=@EmployeeCodeUpd,UDate=@UDate where RowID=@RowID
	else
		insert into Fee_NoteBook(Symbol,NoteBookName,FromNumber,ToNumber,WriteNumber,NoteType,Hide,ShiftWork,EmployeeCode,EmployeeCodeUpd,UDate) values(@Symbol,@NoteBookName,@FromNumber,@ToNumber,@WriteNumber,@NoteType,@Hide,@ShiftWork,@EmployeeCode,@EmployeeCodeUpd,@UDate)
commit tran
go
if exists(select name from sysobjects where name ='proDelFee_NoteBook')
	drop procedure proDelFee_NoteBook
go
create procedure proDelFee_NoteBook
(
	@RowID int,
	@Result smallint output
)
as
begin tran
	if exists(select RowIDNoteBook from Fee_Advance_Payment where RowIDNoteBook=@RowID)
		set @Result=-1
	else
		begin
			delete from Fee_NoteBook where RowID=@RowID 
			set @Result=1 
		end
commit tran
go
-----
if exists(select name from sysobjects where name ='proIUFee_Advance_Payment')
	drop procedure proIUFee_Advance_Payment
go
create procedure proIUFee_Advance_Payment
(
	@RowID decimal(20,0),
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(50),
	@WorkingDateOrder varchar(20),
	@AmountOrder decimal(20,0),
	@EmployeeCodeOrder varchar(15),
	@DepartmentCodeOrder varchar(15),
	@ObjectCode int,
	@Done smallint,
	@Paid smallint,
	@EmployeeCode varchar(15),
	@AmountReal decimal(20,0),
	@WorkingDate varchar(20),
	@RowIDNoteBook int,
	@EmployeeCodeRePaid varchar(15),
	@WorkingDateRePaid varchar(20),
	@ReceiptNumber int,
	@NoteRePaid nvarchar(200),
	@BanksAccountCode varchar(20)
)
as
begin tran
	if not exists(select RowID from Fee_Advance_Payment where RowID=@RowID)
	begin
		insert into Fee_Advance_Payment(PatientReceiveID,PatientCode,WorkingDateOrder,AmountOrder,EmployeeCodeOrder,DepartmentCodeOrder,ObjectCode,Done,Paid,EmployeeCode,AmountReal,WorkingDate,RowIDNoteBook,EmployeeCodeRePaid,WorkingDateRePaid,ReceiptNumber,NoteRePaid,BanksAccountCode)
		values(@PatientReceiveID,@PatientCode,@WorkingDateOrder,@AmountOrder,@EmployeeCodeOrder,@DepartmentCodeOrder,@ObjectCode,@Done,@Paid,@EmployeeCode,@AmountReal,@WorkingDate,@RowIDNoteBook,@EmployeeCodeRePaid,@WorkingDateRePaid,@ReceiptNumber,@NoteRePaid,@BanksAccountCode)
		update Fee_NoteBook set WriteNumber=@ReceiptNumber where RowID=@RowIDNoteBook
	end
commit tran
go
if exists(select name from sysobjects where name ='proUpdCancel_AdvancePayment')
	drop procedure proUpdCancel_AdvancePayment
go
create procedure proUpdCancel_AdvancePayment
(
	@RowID decimal(20,0),
	@PatientReceiveID numeric(18,0),
	@Done smallint,
	@Paid smallint,
	@EmployeeCodeRePaid varchar(15),
	@WorkingDateRePaid varchar(20),
	@NoteRePaid nvarchar(200),
	@IsResult smallint=0 output
)
as
begin tran
	if not exists(select RowID from Fee_Advance_Payment where PatientReceiveID=@PatientReceiveID and Paid=0)
		set @IsResult=-1
	else if exists(select RowID from Fee_Advance_Payment where RowID=@RowID and Paid=0)
	begin
		update Fee_Advance_Payment set EmployeeCodeRePaid=@EmployeeCodeRePaid,WorkingDateRePaid=@WorkingDateRePaid,NoteRePaid=@NoteRePaid,Paid=-1 where RowID=@RowID and PatientReceiveID=@PatientReceiveID and Done=@Done and Paid=0
		set @IsResult=1
	end
	else
		set @IsResult=-1
commit tran
go
if exists(select name from sysobjects where name ='proPrintFee_AdvancePayment')
	drop procedure proPrintFee_AdvancePayment
go
create procedure proPrintFee_AdvancePayment
(
	@PatientCode varchar(15),
	@PatientReceiveID numeric(18,0),
	@WorkingDate char(10),
	@RowIDNoteBook int,
	@ReceiptNumber int
)
as
begin tran
	select a.PatientReceiveID,a.PatientCode,a.PatientName,a.PatientBirthday,a.PatientBirthyear,a.PatientAge,a.PatientAddress,a.PatientMobile,a.PatientEmail,a.PatientGenderName,a.EthnicName,b1.EmployeeName,sum(b.AmountReal) AmountReal,b.ReceiptNumber,b2.NoteBookName,convert(date,b.WorkingDate,103) WorkingDate,b.Counts
	 from
	(select a1.PatientReceiveID,a.PatientCode,a.PatientName,a.PatientBirthday,a.PatientBirthyear,a.PatientAge,[dbo].func_PatientOfAddress(@PatientReceiveID) PatientAddress,a.PatientMobile,a.PatientEmail,(case when a.PatientGender=0 then N'Nữ' else N'Nam' end) PatientGenderName,a2.EthnicName
    from Patients a inner join PatientReceive a1 on a.PatientCode=a1.PatientCode inner join Catalog_EThnic a2 on a1.EThnicID=a2.EThnicID 
    where a.PatientCode=@PatientCode and a1.PatientReceiveID=@PatientReceiveID) a 
	inner join Fee_Advance_Payment b on a.PatientCode=b.PatientCode and a.PatientReceiveID=b.PatientReceiveID
	inner join Employee b1 on b.EmployeeCode=b1.EmployeeCode inner join Fee_NoteBook b2 on b.RowIDNoteBook=b2.RowID
	where b.PatientCode=@PatientCode and b.PatientReceiveID=@PatientReceiveID and b.RowIDNoteBook=@RowIDNoteBook and b.ReceiptNumber=@ReceiptNumber and convert(date,b.WorkingDate,103)=convert(date,@WorkingDate,103)
	group by a.PatientReceiveID,a.PatientCode,a.PatientName,a.PatientBirthday,a.PatientBirthyear,a.PatientAge,a.PatientAddress,a.PatientMobile,a.PatientEmail,a.PatientGenderName,a.EthnicName,b1.EmployeeName,b.ReceiptNumber,b2.NoteBookName,convert(date,b.WorkingDate,103),b.Counts
commit tran
go
if exists(select name from sysobjects where name ='proUpdCountsFee_AdvancePayment')
	drop procedure proUpdCountsFee_AdvancePayment
go
create procedure proUpdCountsFee_AdvancePayment
(
	@PatientCode varchar(15),
	@PatientReceiveID numeric(18,0),
	@ReceiptNumber int
)
as
begin tran
	declare @Counts int =(select count(*) Quantity from (select distinct PatientReceiveID,ReceiptNumber from Fee_Advance_Payment where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID group by PatientReceiveID,ReceiptNumber) a)
	update Fee_Advance_Payment set Counts=@Counts where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID and ReceiptNumber=@ReceiptNumber
commit tran
go
if exists(select name from sysobjects where name ='proUpdCountsFee_AdvancePayment')
	drop procedure proUpdCountsFee_AdvancePayment
go
create procedure proUpdCountsFee_AdvancePayment
(
	@PatientCode varchar(15),
	@PatientReceiveID numeric(18,0),
	@ReceiptNumber int
)
as
begin tran
	declare @Counts int =(select count(*) Quantity from (select distinct PatientReceiveID,ReceiptNumber from Fee_Advance_Payment where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID group by PatientReceiveID,ReceiptNumber) a)
	update Fee_Advance_Payment set Counts=@Counts where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID and ReceiptNumber=@ReceiptNumber
commit tran
go
if exists(select name from sysobjects where name ='proRpt_AdvancePayment')
	drop procedure proRpt_AdvancePayment
go
create procedure proRpt_AdvancePayment
(
	@FromDate char(10),
	@ToDate char(10),
	@Paid int,
	@EmployeeCode varchar(100),
	@ObjectCode varchar(15),
	@Type varchar(10)
)
as
begin tran
	declare @query nvarchar(max)='select a.PatientCode,a1.PatientName,(case a1.PatientGender when 0 then N''Nữ'' else ''Nam'' end) PatientGenderName,a1.PatientBirthyear,a.ReceiptNumber,
	                a2.NoteBookName,a3.EmployeeName,a.AmountReal, convert(date,WorkingDate,103) WorkingDate,a4.EmployeeName as EmployeeNameRepaid,(case a.Paid when 1 then a.AmountReal else 0 end) AmountRepaidReal,a.WorkingDateRePaid,a.ObjectCode
	                from Fee_Advance_Payment a inner join Patients a1 on a.PatientCode=a1.PatientCode inner join Fee_NoteBook a2 on a.RowIDNoteBook=a2.RowID 
	                inner join Employee a3 on a.EmployeeCode=a3.EmployeeCode left join Employee a4 on a.EmployeeCodeRePaid=a4.EmployeeCode
                    where 1=1 and CONVERT(date,a.WorkingDate,103) between CONVERT(date,'''+@FromDate+''',103) and CONVERT(date,'''+@ToDate+''',103)'
	if @Paid=-1
		begin
			set @query=@query+'and a.Paid =-1'
			if @EmployeeCode<>''
				set @query=@query+'and a.EmployeeCodeRePaid in('+@EmployeeCode+')'
		end
	else
		begin
			set @query=@query+'and a.Paid in(0,1)'
			if @EmployeeCode<>''
				set @query=@query+'and a.EmployeeCode in('+@EmployeeCode+')'
		end
	if @ObjectCode <>''
			 set @query=@query+'and a.ObjectCode in('+@ObjectCode+')'
	declare @queryExec nvarchar(max)=''
	if @Type='Invoice'
		begin
			set @queryExec='select a.PatientCode,a.PatientName,a.PatientGenderName,a.PatientBirthyear,a.ReceiptNumber,a.NoteBookName,a.EmployeeName,sum(a.AmountReal) AmountReal,convert(date,a.WorkingDate,103) WorkingDate,a.EmployeeNameRepaid,sum(AmountRepaidReal) AmountRepaidReal,CONVERT(char(10),WorkingDateRePaid) WorkingDateRePaid  from(' + @query + ') a';
			set @queryExec = @queryExec + ' group by a.PatientCode,a.PatientName,a.PatientGenderName,a.PatientBirthyear,a.ReceiptNumber,a.NoteBookName,a.EmployeeName,convert(date, WorkingDate, 103),a.EmployeeNameRepaid,a.WorkingDateRePaid, CONVERT(char(10),WorkingDateRePaid) ';
		end
	else if @Type='Date'
		begin
			set @queryExec='select convert(char(10),b.WorkingDate,103) as WorkingDate,count(b.ReceiptNumber) as TotalInvoice,sum(b.AmountTotal) AmountTotal,sum(b.AmountBHYT) AmountBHYT, SUM(b.AmountThuPhi) AmountThuPhi 
			from (
				select  sum(a.AmountReal) AmountTotal, (case a.ObjectCode when 1 then sum(a.AmountReal) else 0 end) AmountBHYT,(case a.ObjectCode when 2 then sum(a.AmountReal) else 0 end) AmountThuPhi,(case a.ObjectCode when 5 then sum(a.AmountReal) else 0 end) AmountMien,a.WorkingDate,a.ReceiptNumber from(
				'+@query+'
				) a group by a.WorkingDate,a.ObjectCode,a.ReceiptNumber
			 ) b group by convert(char(10),b.WorkingDate,103)'
		end
	else if @Type='Employee'
		begin
			set @queryExec='select b.EmployeeName,count(b.ReceiptNumber) as TotalInvoice,sum(b.AmountTotal) AmountTotal,sum(b.AmountBHYT) AmountBHYT, SUM(b.AmountThuPhi) AmountThuPhi 
			from (
				select  sum(a.AmountReal) AmountTotal, (case a.ObjectCode when 1 then sum(a.AmountReal) else 0 end) AmountBHYT,(case a.ObjectCode when 2 then sum(a.AmountReal) else 0 end) AmountThuPhi,(case a.ObjectCode when 5 then sum(a.AmountReal) else 0 end) AmountMien,a.EmployeeName,a.ReceiptNumber from(
				'+@query+'
				) a group by a.EmployeeName,a.ObjectCode,a.ReceiptNumber
			 ) b group by b.EmployeeName'
		end
	exec(@queryExec)
	--print @queryExec
commit tran
go
-- exec proRpt_AdvancePayment '01/01/2017','28/02/2017',1,'','','Date'
--select * from CatalogComputer

