if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Service' and b.name ='Attach_Items')
	alter table Service add Attach_Items bit default 0 not null
go
update Service set Attach_Items=1 where ServiceCode in( select ServiceCode from Service_Item_Attach)
go
if exists(select name from sysobjects where name ='pro_Ins_MedicalRecord')
	drop procedure pro_Ins_MedicalRecord
go
create procedure pro_Ins_MedicalRecord
(
	@MedicalRecordCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(50),
	@DepartmentCode varchar(50),
	@EmployeeCode varchar(50),
	@DiagnosisCode numeric(18,0),
	@DescriptionNode nvarchar(1000),
	@PostingDate datetime,
	@AppointmentDate datetime,
	@ReferenceCode varchar(50),
	@Symptoms nvarchar(250),
	@Status int,
	@ObjectCode int,
	@Advices nvarchar(250),
	@DiagnosisEnclosed numeric(18,0),
	@TackleCode int,
	@ServiceCode varchar(50),
	@RowIDMedicalPattern int =-1,
	@ContentMedicalPattern nvarchar(max),
	@EmployeeCodeDoctor varchar(50),
	@DiagnosisCustom nvarchar(250),
	@TypeMedical int =1,
	@ReceiptID numeric(18,0)=0,
	@ShiftWork char(2),
	@Treatments nvarchar(200)='',
	@Pregnant bit=0,
	@Breastfeeding bit=0,
	@Use_Smoking bit=0,
	@Use_Alcohol bit=0,
	@EmployeeCodeDoing varchar(50)='',
	@ICD10_Custom varchar(20)='',
	@ICD10Name_Custom nvarchar(500)='',
	@ResultMedicalCode varchar(50) output
)
as
begin
	if(@ReceiptID=0)
		set @ReceiptID = (select top(1) ReceiptID from SuggestedServiceReceipt where PatientCode=@PatientCode and RefID=@PatientReceiveID and DepartmentCode=@DepartmentCode and Note='TIEPDON' and ServiceCode=@ServiceCode)
	if exists(select MedicalRecordCode from MedicalRecord where MedicalRecordCode=@MedicalRecordCode)
		begin		
			update MedicalRecord set PatientReceiveID=@PatientReceiveID,PatientCode=@PatientCode,DepartmentCode=@DepartmentCode,EmployeeCode=@EmployeeCode,DiagnosisCode=@DiagnosisCode,
			DescriptionNode=@DescriptionNode,PostingDate=@PostingDate,AppointmentDate=@AppointmentDate,ReferenceCode=@ReferenceCode,Symptoms=@Symptoms,ObjectCode=@ObjectCode,
			Advices=@Advices,DiagnosisEnclosed=@DiagnosisEnclosed,TackleCode=@TackleCode,RowIDMedicalPattern=@RowIDMedicalPattern,ContentMedicalPattern=@ContentMedicalPattern,EmployeeCodeDoctor=@EmployeeCodeDoctor,ReceiptID=@ReceiptID,DiagnosisCustom=@DiagnosisCustom,Treatments=@Treatments,
			Pregnant=@Pregnant,Breastfeeding=@Breastfeeding,Use_Smoking=@Use_Smoking,Use_Alcohol=@Use_Alcohol,EmployeeCodeDoing=@EmployeeCodeDoing,ICD10_Custom=@ICD10_Custom,ICD10Name_Custom=@ICD10Name_Custom
			where MedicalRecordCode=@MedicalRecordCode
			set @ResultMedicalCode=@MedicalRecordCode
		end
	else
	begin
		set @MedicalRecordCode =(SELECT 'BA' + CONVERT(char(8),GETDATE(),112) + REPLACE(CONVERT(VARCHAR(15),GETDATE(),114),':','') Code)
		insert into MedicalRecord(MedicalRecordCode,PatientReceiveID,PatientCode,DepartmentCode,EmployeeCode,DiagnosisCode,DescriptionNode,PostingDate,AppointmentDate,ReferenceCode,Symptoms,Status,ObjectCode,Advices,DiagnosisEnclosed,TackleCode,RowIDMedicalPattern,ContentMedicalPattern,EmployeeCodeDoctor,ReceiptID,DiagnosisCustom,TypeMedical,ShiftWork,Treatments,Pregnant,Breastfeeding,Use_Smoking,Use_Alcohol,EmployeeCodeDoing,ICD10_Custom,ICD10Name_Custom) 
		values(@MedicalRecordCode,@PatientReceiveID,@PatientCode,@DepartmentCode,@EmployeeCode,@DiagnosisCode,@DescriptionNode,@PostingDate,@AppointmentDate,@ReferenceCode,@Symptoms,@Status,@ObjectCode,@Advices,@DiagnosisEnclosed,@TackleCode,@RowIDMedicalPattern,@ContentMedicalPattern,@EmployeeCodeDoctor,@ReceiptID,@DiagnosisCustom,@TypeMedical,@ShiftWork,@Treatments,@Pregnant,@Breastfeeding,@Use_Smoking,@Use_Alcohol,@EmployeeCodeDoing,@ICD10_Custom,@ICD10Name_Custom)
		update PatientReceive set status=1 where PatientCode=@PatientCode and PatientReceiveID=@PatientReceiveID
		update SuggestedServiceReceipt set status=1 where PatientCode=@PatientCode and RefID=@PatientReceiveID and DepartmentCode=@DepartmentCode and Note='TIEPDON' and ServiceCode=@ServiceCode
		set @ResultMedicalCode=@MedicalRecordCode
	end
end
go
if exists(select name from sysobjects where name ='pro_Ins_MedicalRecordForAttachItems')
	drop procedure pro_Ins_MedicalRecordForAttachItems
go
create procedure pro_Ins_MedicalRecordForAttachItems
(
	@MedicalRecordCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(50),
	@DepartmentCode varchar(50),
	@EmployeeCode varchar(50),
	@DiagnosisCode numeric(18,0),
	@DescriptionNode nvarchar(1000),
	@PostingDate datetime,
	@AppointmentDate datetime,
	@ReferenceCode varchar(50),
	@Symptoms nvarchar(250),
	@Status int,
	@ObjectCode int,
	@Advices nvarchar(250),
	@DiagnosisEnclosed numeric(18,0),
	@TackleCode int,
	@ServiceCode varchar(50),
	@RowIDMedicalPattern int =-1,
	@ContentMedicalPattern nvarchar(max),
	@EmployeeCodeDoctor varchar(50),
	@DiagnosisCustom nvarchar(250),
	@TypeMedical int =1,
	@ReceiptID numeric(18,0)=0,
	@ShiftWork char(2),
	@Treatments nvarchar(200)='',
	@Pregnant bit=0,
	@Breastfeeding bit=0,
	@Use_Smoking bit=0,
	@Use_Alcohol bit=0,
	@EmployeeCodeDoing varchar(50)='',
	@ICD10_Custom varchar(20)='',
	@ICD10Name_Custom nvarchar(500)='',
	@ResultMedicalCode varchar(50) output
)
as
begin
	if exists(select MedicalRecordCode from MedicalRecord where ReceiptID=@ReceiptID)
		begin		
			update MedicalRecord set PatientReceiveID=@PatientReceiveID,PatientCode=@PatientCode,DepartmentCode=@DepartmentCode,EmployeeCode=@EmployeeCode,DiagnosisCode=@DiagnosisCode,
			DescriptionNode=@DescriptionNode,PostingDate=@PostingDate,AppointmentDate=@AppointmentDate,ReferenceCode=@ReferenceCode,Symptoms=@Symptoms,ObjectCode=@ObjectCode,
			Advices=@Advices,DiagnosisEnclosed=@DiagnosisEnclosed,TackleCode=@TackleCode,RowIDMedicalPattern=@RowIDMedicalPattern,ContentMedicalPattern=@ContentMedicalPattern,EmployeeCodeDoctor=@EmployeeCodeDoctor,ReceiptID=@ReceiptID,DiagnosisCustom=@DiagnosisCustom,Treatments=@Treatments,
			Pregnant=@Pregnant,Breastfeeding=@Breastfeeding,Use_Smoking=@Use_Smoking,Use_Alcohol=@Use_Alcohol,EmployeeCodeDoing=@EmployeeCodeDoing,ICD10_Custom=@ICD10_Custom,ICD10Name_Custom=@ICD10Name_Custom
			where ReceiptID=@ReceiptID
			set @ResultMedicalCode=@MedicalRecordCode
		end
	else
	begin
		set @MedicalRecordCode =(SELECT 'BA' + CONVERT(char(8),GETDATE(),112) + REPLACE(CONVERT(VARCHAR(15),GETDATE(),114),':','') Code)
		insert into MedicalRecord(MedicalRecordCode,PatientReceiveID,PatientCode,DepartmentCode,EmployeeCode,DiagnosisCode,DescriptionNode,PostingDate,AppointmentDate,ReferenceCode,Symptoms,Status,ObjectCode,Advices,DiagnosisEnclosed,TackleCode,RowIDMedicalPattern,ContentMedicalPattern,EmployeeCodeDoctor,ReceiptID,DiagnosisCustom,TypeMedical,ShiftWork,Treatments,Pregnant,Breastfeeding,Use_Smoking,Use_Alcohol,EmployeeCodeDoing,ICD10_Custom,ICD10Name_Custom) 
		values(@MedicalRecordCode,@PatientReceiveID,@PatientCode,@DepartmentCode,@EmployeeCode,@DiagnosisCode,@DescriptionNode,@PostingDate,@AppointmentDate,@ReferenceCode,@Symptoms,@Status,@ObjectCode,@Advices,@DiagnosisEnclosed,@TackleCode,@RowIDMedicalPattern,@ContentMedicalPattern,@EmployeeCodeDoctor,@ReceiptID,@DiagnosisCustom,@TypeMedical,@ShiftWork,@Treatments,@Pregnant,@Breastfeeding,@Use_Smoking,@Use_Alcohol,@EmployeeCodeDoing,@ICD10_Custom,@ICD10Name_Custom)		
		set @ResultMedicalCode=@MedicalRecordCode
	end
end
go
if exists(select name from sysobjects where name = 'pro_Ins_SuggestedServiceReceipt')
 drop procedure pro_Ins_SuggestedServiceReceipt
go
create procedure pro_Ins_SuggestedServiceReceipt
(
	@ReceiptID numeric(18,0),
	@DepartmentCode varchar(50),
	@ServiceCode varchar(50),
	@ServicePrice numeric(18,0),
	@DisparityPrice numeric(18,0),
	@PatientCode varchar(50),
	@Status int,
	@Paid int,
	@ServicePackageCode varchar(50),
	@EmployeeCode varchar(50),
	@Note nvarchar(50),
	@RefID numeric(18,0),
	@ObjectCode int,
	@PatientType int,
	@WorkDate DateTime,
	@ReferenceCode varchar(50),
	@DepartmentCodeOrder varchar(50),
	@EmployeeCodeDoctor varchar(50),
	@ShiftWork char(2),
	@StatusDepartment int =0,
	@Quantity int =1,
	@IDAppointment247 nvarchar(50)='',
	@IDDoctorAppointment247 nvarchar(50)='',
	@NameDoctorAppointment247 nvarchar(100)='',
	@Content nvarchar(200)='',
	@Check_ int=0
)
as
begin
	declare @SampleTransfer int =0
	declare @SampleTransferPrice decimal(18,2)=0
	declare @RowIDPrice numeric(18,0)
	declare @STT int =1
	set @SampleTransfer = (select SampleTransfer from [Service] where ServiceCode=@ServiceCode)
	declare @DiscountIntro numeric(18,2)=0
	declare @DiscountDoctorDone numeric(18,2)=0
	declare @DiscountDoctor numeric(18,2)=0
	declare @IntroName nvarchar(200)=''
	select @IntroName=IntroName from PatientReceive where PatientReceiveID=@RefID
	if exists(select ServiceCode,SampleTransfer=@SampleTransfer from [Service] where ServiceCode=@ServiceCode and ServiceGroupCode='KCB')
		set @Note='TIEPDON'
	else
		set @Note=''
	--declare @DepartmentDone varchar(250)
	if exists(select ReceiptID from SuggestedServiceReceipt where ReceiptID=@ReceiptID)
	begin
		declare cur cursor read_only fast_forward
		for select RowID,UnitPrice,DisparityPrice,SampleTransferPrice,DiscountIntro,DiscountDoctorDone,DiscountDoctor from ServicePrice where Hide=0 and ServiceCode=@ServiceCode and ObjectCode=@ObjectCode
		open cur
		fetch next from cur into @RowIDPrice,@ServicePrice, @DisparityPrice,@SampleTransferPrice,@DiscountIntro,@DiscountDoctorDone,@DiscountDoctor
		while @@FETCH_STATUS = 0
		begin
			if exists(select MedicalRecordCode from MedicalRecord where ReceiptID=@ReceiptID and EmployeeCodeDoctor=@EmployeeCodeDoctor)
				begin
					if exists (select ReceiptID_DisparityPrice from SuggestedServiceReceipt where ReceiptID_DisparityPrice=@ReceiptID)
					begin
						update SuggestedServiceReceipt set DepartmentCode=@DepartmentCode,ServiceCode=@ServiceCode,ServicePrice=0,DisparityPrice=@DisparityPrice,PatientCode=@PatientCode,CreateDate=GETDATE(),ServicePackageCode=@ServicePackageCode,EmployeeCode=@EmployeeCode,Note=@Note,RefID=@RefID,ObjectCode=@ObjectCode,RowIDPrice=@RowIDPrice,WorkDate=@WorkDate,ReferenceCode=@ReferenceCode,@DepartmentCodeOrder=@DepartmentCodeOrder,EmployeeCodeDoctor=@EmployeeCodeDoctor,SampleTransfer=@SampleTransfer,SampleTransferPrice=@SampleTransferPrice,Quantity=@Quantity,IDAppointment247 =@IDAppointment247, IDDoctorAppointment247 = @IDDoctorAppointment247, NameDoctorAppointment247 = @NameDoctorAppointment247,DiscountIntro=@DiscountIntro,DiscountDoctorDone=@DiscountDoctorDone,DiscountDoctor=@DiscountDoctor,IntroName=@IntroName,Content=@Content where ReceiptID_DisparityPrice=@ReceiptID and Paid=0
						set @DisparityPrice=0
					end
					update SuggestedServiceReceipt set DepartmentCode=@DepartmentCode,ServiceCode=@ServiceCode,ServicePrice=@ServicePrice,DisparityPrice=@DisparityPrice,PatientCode=@PatientCode,CreateDate=GETDATE(),ServicePackageCode=@ServicePackageCode,EmployeeCode=@EmployeeCode,Note=@Note,RefID=@RefID,ObjectCode=@ObjectCode,RowIDPrice=@RowIDPrice,WorkDate=@WorkDate,ReferenceCode=@ReferenceCode,@DepartmentCodeOrder=@DepartmentCodeOrder,EmployeeCodeDoctor=@EmployeeCodeDoctor,SampleTransfer=@SampleTransfer,SampleTransferPrice=@SampleTransferPrice,Quantity=@Quantity,IDAppointment247 =@IDAppointment247, IDDoctorAppointment247 = @IDDoctorAppointment247, NameDoctorAppointment247 = @NameDoctorAppointment247,DiscountIntro=@DiscountIntro,DiscountDoctorDone=@DiscountDoctorDone,DiscountDoctor=@DiscountDoctor,IntroName=@IntroName,Content=@Content,Check_=@Check_ where ReceiptID=@ReceiptID and Paid=0
				end
			else
				begin
					if exists (select ReceiptID_DisparityPrice from SuggestedServiceReceipt where ReceiptID_DisparityPrice=@ReceiptID)
					begin
						update SuggestedServiceReceipt set DepartmentCode=@DepartmentCode,ServiceCode=@ServiceCode,ServicePrice=0,DisparityPrice=@DisparityPrice,PatientCode=@PatientCode,CreateDate=GETDATE(),ServicePackageCode=@ServicePackageCode,EmployeeCode=@EmployeeCode,Note=@Note,RefID=@RefID,ObjectCode=@ObjectCode,RowIDPrice=@RowIDPrice,WorkDate=@WorkDate,ReferenceCode=@ReferenceCode,@DepartmentCodeOrder=@DepartmentCodeOrder,EmployeeCodeDoctor=@EmployeeCodeDoctor,SampleTransfer=@SampleTransfer,SampleTransferPrice=@SampleTransferPrice,Quantity=@Quantity,IDAppointment247 =@IDAppointment247, IDDoctorAppointment247 = @IDDoctorAppointment247, NameDoctorAppointment247 = @NameDoctorAppointment247,DiscountIntro=@DiscountIntro,DiscountDoctorDone=@DiscountDoctorDone,DiscountDoctor=@DiscountDoctor,IntroName=@IntroName,Content=@Content where ReceiptID_DisparityPrice=@ReceiptID and Status=0
						set @DisparityPrice=0
					end
					update SuggestedServiceReceipt set DepartmentCode=@DepartmentCode,ServiceCode=@ServiceCode,ServicePrice=@ServicePrice,DisparityPrice=@DisparityPrice,PatientCode=@PatientCode,CreateDate=GETDATE(),ServicePackageCode=@ServicePackageCode,EmployeeCode=@EmployeeCode,Note=@Note,RefID=@RefID,ObjectCode=@ObjectCode,RowIDPrice=@RowIDPrice,WorkDate=@WorkDate,ReferenceCode=@ReferenceCode,@DepartmentCodeOrder=@DepartmentCodeOrder,EmployeeCodeDoctor=@EmployeeCodeDoctor,SampleTransfer=@SampleTransfer,SampleTransferPrice=@SampleTransferPrice,Quantity=@Quantity,IDAppointment247 =@IDAppointment247, IDDoctorAppointment247 = @IDDoctorAppointment247, NameDoctorAppointment247 = @NameDoctorAppointment247,DiscountIntro=@DiscountIntro,DiscountDoctorDone=@DiscountDoctorDone,DiscountDoctor=@DiscountDoctor,IntroName=@IntroName,Content=@Content,Check_=@Check_ where ReceiptID=@ReceiptID and Status=0-- and Paid=0
				end
			FETCH NEXT FROM cur into @RowIDPrice,@ServicePrice, @DisparityPrice,@SampleTransferPrice,@DiscountIntro,@DiscountDoctorDone,@DiscountDoctor
		end	 
		CLOSE cur
		DEALLOCATE cur
	end
	else
	begin
		if @StatusDepartment=0
		begin
			declare cur cursor read_only fast_forward
			for select RowID,UnitPrice,DisparityPrice,SampleTransferPrice,DiscountIntro,DiscountDoctorDone,DiscountDoctor from ServicePrice where Hide=0 and ServiceCode=@ServiceCode and ObjectCode=@ObjectCode
			open cur
			fetch next from cur into @RowIDPrice,@ServicePrice, @DisparityPrice,@SampleTransferPrice,@DiscountIntro,@DiscountDoctorDone,@DiscountDoctor
			while @@FETCH_STATUS = 0
			begin
				set @STT = (select isnull(max(STT),0)+1 from SuggestedServiceReceipt where CONVERT(date,CreateDate,103)=CONVERT(date,GETDATE(),103) and DepartmentCode=@DepartmentCode)
				insert into SuggestedServiceReceipt(DepartmentCode,ServiceCode,ServicePrice,DisparityPrice,PatientCode,[Status],Paid,CreateDate,ServicePackageCode,EmployeeCode,Note,RefID,ObjectCode,RowIDPrice,PatientType,WorkDate,ReferenceCode,STT,DepartmentCodeOrder,EmployeeCodeDoctor,ShiftWork,SampleTransfer,SampleTransferPrice,Quantity,PaidBV,IDAppointment247,IDDoctorAppointment247,NameDoctorAppointment247,DiscountIntro,DiscountDoctorDone,DiscountDoctor,IntroName,Content,Check_) values(@DepartmentCode,@ServiceCode,@ServicePrice,@DisparityPrice,@PatientCode,@Status,@Paid,GETDATE(),@ServicePackageCode,@EmployeeCode,@Note,@RefID,@ObjectCode,@RowIDPrice,@PatientType,@WorkDate,@ReferenceCode,@STT,@DepartmentCodeOrder,@EmployeeCodeDoctor,@ShiftWork,@SampleTransfer,@SampleTransferPrice,@Quantity,0,@IDAppointment247,@IDDoctorAppointment247,@NameDoctorAppointment247,@DiscountIntro,@DiscountDoctorDone,@DiscountDoctor,@IntroName,@Content,@Check_)
				set @ReceiptID = (select isnull(ReceiptID,0) ReceiptID from SuggestedServiceReceipt where DepartmentCode=@DepartmentCode and ServiceCode=@ServiceCode and ServicePrice=@ServicePrice and DisparityPrice=@DisparityPrice and PatientCode=@PatientCode and Status=@Status and Paid=@Paid and ServicePackageCode=@ServicePackageCode and EmployeeCode=@EmployeeCode and Note=@Note and RefID=@RefID and ObjectCode=@ObjectCode and RowIDPrice=@RowIDPrice and PatientType=@PatientType and WorkDate=@WorkDate and ReferenceCode=@ReferenceCode and STT=@STT and DepartmentCodeOrder=@DepartmentCodeOrder and EmployeeCodeDoctor=@EmployeeCodeDoctor and ShiftWork=@ShiftWork and SampleTransfer=@SampleTransfer)
				if(@ReceiptID>0 and @DisparityPrice >0)
				begin
					insert into SuggestedServiceReceipt(DepartmentCode,ServiceCode,ServicePrice,DisparityPrice,PatientCode,[Status],Paid,CreateDate,ServicePackageCode,EmployeeCode,Note,RefID,ObjectCode,RowIDPrice,PatientType,WorkDate,ReferenceCode,STT,DepartmentCodeOrder,EmployeeCodeDoctor,ShiftWork,SampleTransfer,SampleTransferPrice,Quantity,PaidBV,IDAppointment247,IDDoctorAppointment247,NameDoctorAppointment247,DiscountIntro,DiscountDoctorDone,DiscountDoctor,IntroName,Content,ReceiptID_DisparityPrice) values(@DepartmentCode,@ServiceCode,0,@DisparityPrice,@PatientCode,@Status,@Paid,GETDATE(),@ServicePackageCode,@EmployeeCode,@Note,@RefID,@ObjectCode,@RowIDPrice,@PatientType,@WorkDate,@ReferenceCode,@STT,@DepartmentCodeOrder,@EmployeeCodeDoctor,@ShiftWork,@SampleTransfer,@SampleTransferPrice,@Quantity,0,@IDAppointment247,@IDDoctorAppointment247,@NameDoctorAppointment247,@DiscountIntro,@DiscountDoctorDone,@DiscountDoctor,@IntroName,@Content,@ReceiptID)	
					update SuggestedServiceReceipt set DisparityPrice=0 where ReceiptID=@ReceiptID
				end
				FETCH NEXT FROM cur into @RowIDPrice,@ServicePrice, @DisparityPrice,@SampleTransferPrice,@DiscountIntro,@DiscountDoctorDone,@DiscountDoctor
			end	 
			CLOSE cur
			DEALLOCATE cur
		end
		else
		begin
			set @RowIDPrice =-1 set @ServicePrice =0 set @DisparityPrice =0
			set @STT = ( select isnull(max(STT),0)+1 from SuggestedServiceReceipt where CONVERT(date,CreateDate,103)=CONVERT(date,GETDATE(),103) and DepartmentCode=@DepartmentCode)
			insert into SuggestedServiceReceipt(DepartmentCode,ServiceCode,ServicePrice,DisparityPrice,PatientCode,[Status],Paid,CreateDate,ServicePackageCode,EmployeeCode,Note,RefID,ObjectCode,RowIDPrice,PatientType,WorkDate,ReferenceCode,STT,DepartmentCodeOrder,EmployeeCodeDoctor,ShiftWork,SampleTransfer,SampleTransferPrice,Quantity,PaidBV,IDAppointment247,IDDoctorAppointment247,NameDoctorAppointment247,DiscountIntro,DiscountDoctorDone,DiscountDoctor,IntroName,Content,Check_) values(@DepartmentCode,@ServiceCode,@ServicePrice,@DisparityPrice,@PatientCode,@Status,@Paid,GETDATE(),@ServicePackageCode,@EmployeeCode,@Note,@RefID,@ObjectCode,@RowIDPrice,@PatientType,@WorkDate,@ReferenceCode,@STT,@DepartmentCodeOrder,@EmployeeCodeDoctor,@ShiftWork,@SampleTransfer,@SampleTransferPrice,@Quantity,0,@IDAppointment247,@IDDoctorAppointment247,@NameDoctorAppointment247,@DiscountIntro,@DiscountDoctorDone,@DiscountDoctor,@IntroName,@Content,@Check_)
		end
	end
end
go
if exists(select name from sysobjects where name ='pro_Ins_MedicalRecord_Emergency')
	drop procedure pro_Ins_MedicalRecord_Emergency
go
create procedure pro_Ins_MedicalRecord_Emergency
(
	@MedicalRecordCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(50),
	@DepartmentCode varchar(50),
	@EmployeeCode varchar(50),
	@PostingDate datetime,
	@ReferenceCode varchar(50),
	@Status int,
	@ObjectCode int,
	@DiagnosisEnclosed numeric(18,0),
	@AppointmentDate datetime,
	@ShiftWork char(2),
	@Treatments nvarchar(max),
	@DiagnosisCustom nvarchar(200),
	@Advices nvarchar(250),
	@Symptoms nvarchar(250),
	@ReceiptID decimal=0,
	@ResultMedicalCode varchar(50) output
)
as
begin
	declare @DiagnosisCode numeric(18,0)=0
	select @DiagnosisCode=b.RowID from MedicalEmergency a inner join Diagnosis b on a.ICD10=b.DiagnosisCode where a.PatientCode=@PatientCode and a.MedicalEmergencyCode=@ReferenceCode
	if exists(select MedicalRecordCode from MedicalRecord where MedicalRecordCode=@MedicalRecordCode)
		begin		
			update MedicalRecord set DepartmentCode=@DepartmentCode,EmployeeCode=@EmployeeCode,
			PostingDate=@PostingDate,ObjectCode=@ObjectCode,DiagnosisCode=@DiagnosisCode,AppointmentDate=@AppointmentDate,ShiftWork=@ShiftWork,Treatments=@Treatments,DiagnosisCustom=@DiagnosisCustom,Advices=@Advices, Symptoms=@Symptoms,ReceiptID=@ReceiptID
			where MedicalRecordCode=@MedicalRecordCode and ReferenceCode=@ReferenceCode and PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode and Paid=0 and Status=0
			set @ResultMedicalCode=@MedicalRecordCode
		end
	else
	begin
		set @MedicalRecordCode =(SELECT 'BA' + CONVERT(char(8),GETDATE(),112) + REPLACE(CONVERT(VARCHAR(15),GETDATE(),114),':','') Code)
		insert into MedicalRecord(MedicalRecordCode,PatientReceiveID,PatientCode,DepartmentCode,EmployeeCode,PostingDate,ReferenceCode,Status,ObjectCode,DiagnosisEnclosed,DiagnosisCode,AppointmentDate,ShiftWork,Treatments,DiagnosisCustom,Advices,Symptoms,ReceiptID) 
		values(@MedicalRecordCode,@PatientReceiveID,@PatientCode,@DepartmentCode,@EmployeeCode,@PostingDate,@ReferenceCode,@Status,@ObjectCode,@DiagnosisEnclosed,@DiagnosisCode,@AppointmentDate,@ShiftWork,@Treatments,@DiagnosisCustom,@Advices,@Symptoms,@ReceiptID)
		set @ResultMedicalCode=@MedicalRecordCode
	end
end
go
if exists(select name from sysobjects where name ='pro_Ins_MedicalRecord_Surgeries')
	drop procedure pro_Ins_MedicalRecord_Surgeries
go
create procedure pro_Ins_MedicalRecord_Surgeries
(
	@MedicalRecordCode varchar(50),
	@PatientReceiveID numeric(18,0),
	@PatientCode varchar(50),
	@DepartmentCode varchar(50),
	@EmployeeCode varchar(50),
	@PostingDate datetime,
	@ReferenceCode varchar(50),
	@Status int,
	@ObjectCode int,
	@DiagnosisEnclosed numeric(18,0),
	@AppointmentDate datetime,
	@ResultMedicalCode varchar(50) output
)
as
begin
declare @DiagnosisCode numeric(18,0)
	select @DiagnosisCode=b.RowID from Surgeries a inner join Diagnosis b on a.ICD10On=b.DiagnosisCode where a.PatientCode=@PatientCode and a.SurgeriesCode=@ReferenceCode
	if exists(select MedicalRecordCode from MedicalRecord where MedicalRecordCode=@MedicalRecordCode)
		begin		
			update MedicalRecord set DepartmentCode=@DepartmentCode,EmployeeCode=@EmployeeCode,
			PostingDate=@PostingDate,ObjectCode=@ObjectCode,DiagnosisCode=@DiagnosisCode,AppointmentDate=@AppointmentDate
			where MedicalRecordCode=@MedicalRecordCode and ReferenceCode=@ReferenceCode and PatientReceiveID=@PatientReceiveID and PatientCode=@PatientCode
			set @ResultMedicalCode=@MedicalRecordCode
		end
	else
	begin
		set @MedicalRecordCode =(SELECT 'BA' + CONVERT(char(8),GETDATE(),112) + REPLACE(CONVERT(VARCHAR(15),GETDATE(),114),':','') Code)
		insert into MedicalRecord(MedicalRecordCode,PatientReceiveID,PatientCode,DepartmentCode,EmployeeCode,PostingDate,ReferenceCode,Status,ObjectCode,DiagnosisEnclosed,DiagnosisCode,AppointmentDate) 
		values(@MedicalRecordCode,@PatientReceiveID,@PatientCode,@DepartmentCode,@EmployeeCode,@PostingDate,@ReferenceCode,@Status,@ObjectCode,@DiagnosisEnclosed,@DiagnosisCode,@AppointmentDate)
		set @ResultMedicalCode=@MedicalRecordCode
	end
end
go
if exists(select name from sysobjects where name ='pro_Del_SuggestedServiceReceipt')
	drop procedure pro_Del_SuggestedServiceReceipt
go
create procedure pro_Del_SuggestedServiceReceipt
(
	@ReceiptID numeric(18,0),
	@iresult int output
)
as
begin
	if @ReceiptID=-1
	begin
		set @iresult=0
	end
	else if exists(select [Status] from SuggestedServiceReceipt where ReceiptID=@ReceiptID and [Status] in(1,2))
		set @iresult=-1
	else if exists(select Paid from SuggestedServiceReceipt where ReceiptID=@ReceiptID and Paid in(1))
		set @iresult=-2
	else if exists(select a.Status from MedicalPrescriptionDetail a inner join MedicalRecord b on a.MedicalRecordCode=b.MedicalRecordCode where b.ReceiptID=@ReceiptID and a.Status=1)
		set @iresult=-3
	else
	begin
		delete from MedicalPrescriptionDetail where MedicalRecordCode in(select b.MedicalRecordCode from MedicalPrescriptionDetail a inner join MedicalRecord b on a.MedicalRecordCode=b.MedicalRecordCode where b.ReceiptID=@ReceiptID and a.Status=0)
		delete from MedicalRecord where ReceiptID=@ReceiptID and Status=0
		delete from SuggestedServiceReceipt where ReceiptID=@ReceiptID
		set @iresult=1
	end
end
go
if exists(select name from sysobjects where name ='pro_Ins_MedicalPrescriptionDetail')
	drop procedure pro_Ins_MedicalPrescriptionDetail
go
create procedure pro_Ins_MedicalPrescriptionDetail
(
	@MedicalRecordCode varchar(50),
	@EmployeeCode varchar(50),
	@ItemCode varchar(50),
	@DateOfIssues int,
	@Morning varchar(50),
	@Noon varchar(50),
	@Afternoon varchar(50),
	@Evening varchar(50),
	@Quantity numeric(18,2),
	@Instruction nvarchar(max),
	@UnitPrice numeric(18,4),
	@Amount numeric(18,4),
	@PostingDate datetime,
	@Status int,
	@New int,
	@RepositoryCode varchar(50),
	@ObjectCode int =2,
	@DoseOf int,
	@DoseOfPills varchar(50),
	@BHYT int=0,
	@UnitOfMeasureCode_Medi varchar(15),
	@ObjectCode_Patient int
)
as
begin
	--declare @ListBHYT_Temp int =(select ListBHYT from Items where ItemCode=@ItemCode)
	--if( @ListBHYT_Temp=1 and @ObjectCode_Patient=1 and @ObjectCode=1)
	--	set @ObjectCode = @ObjectCode_Patient
	--else
	--	begin
	--		if(@ObjectCode_Patient=1)
	--			set @ObjectCode = 2
	--		else
	--			set @ObjectCode = @ObjectCode_Patient
	--	end
	declare @ItemCode_Temp varchar(50)
	declare @Quantity_Temp numeric(18,2)
	declare @AmountVirtual_Temp numeric(18,2)
	if exists(select ItemCode from MedicalPrescriptionDetail where MedicalRecordCode=@MedicalRecordCode and ItemCode=@ItemCode and Status=0 and RepositoryCode=@RepositoryCode)
		begin		
			select @ItemCode_Temp=ItemCode,@Quantity_Temp=Quantity from MedicalPrescriptionDetail where MedicalRecordCode=@MedicalRecordCode and ItemCode=@ItemCode and Status=0 and RepositoryCode=@RepositoryCode
			select @AmountVirtual_Temp=AmountVirtual from InventoryGeneral where ItemCode=@ItemCode_Temp and RepositoryCode=@RepositoryCode  and Hide = 0
			if @AmountVirtual_Temp>=@Quantity_Temp
			begin
				update InventoryGeneral set AmountVirtual=AmountVirtual-@Quantity_Temp where ItemCode=@ItemCode_Temp and RepositoryCode=@RepositoryCode  and Hide = 0
			end
			update MedicalPrescriptionDetail set EmployeeCode=@EmployeeCode,DateOfIssues=@DateOfIssues,Morning=@Morning,Noon=@Noon,Afternoon=@Afternoon,
			Evening=@Evening,Quantity=@Quantity,Instruction=@Instruction,UnitPrice=@UnitPrice,Amount=@Amount,PostingDate=@PostingDate,New=@New,ObjectCode=@ObjectCode,DoseOf=@DoseOf,DoseOfPills=@DoseOfPills,BHYT=@BHYT,UnitOfMeasureCode_Medi=@UnitOfMeasureCode_Medi
			where MedicalRecordCode=@MedicalRecordCode and ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Status=0
			update InventoryGeneral set AmountVirtual=AmountVirtual+@Quantity where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode  and Hide = 0
		end
	--else if exists(select ItemCode from MedicalPrescriptionDetail where MedicalRecordCode=@MedicalRecordCode and ItemCode=@ItemCode and Status=1)
		--begin
			--set @Status=1
		--end
	else
	begin
		insert into MedicalPrescriptionDetail(MedicalRecordCode,EmployeeCode,ItemCode,DateOfIssues,Morning,Noon,Afternoon,Evening,Quantity,Instruction,UnitPrice,Amount,PostingDate,Status,RepositoryCode,New,ObjectCode,DoseOf,DoseOfPills,BHYT,UnitOfMeasureCode_Medi) 
		values(@MedicalRecordCode,@EmployeeCode,@ItemCode,@DateOfIssues,@Morning,@Noon,@Afternoon,@Evening,@Quantity,@Instruction,@UnitPrice,@Amount,@PostingDate,@Status,@RepositoryCode,@New,@ObjectCode,@DoseOf,@DoseOfPills,@BHYT,@UnitOfMeasureCode_Medi)
		update InventoryGeneral set AmountVirtual=AmountVirtual+@Quantity where ItemCode=@ItemCode and RepositoryCode=@RepositoryCode and Hide = 0
	end
end
go
if exists(select name from sysobjects where name='pro_ResultMedicalDetail')
	drop procedure pro_ResultMedicalDetail
go
create procedure pro_ResultMedicalDetail
(
	@MedicalRecordCode varchar(50),
	@RepositoryGroupCode varchar(10),
	@ObjectCode int,
	@Active int =0,
	@Status int=0
)
as
	Declare @TableGroup table (RepositoryGroupCode int)
	insert into @TableGroup(RepositoryGroupCode)(select RepositoryGroupCode from RepositoryGroup where RepositoryGroupCode in(select * from dbo.fnSplitNumber(@RepositoryGroupCode,',')))
	if(@Active=0)
	begin
		select a.MedicalRecordCode,a.ItemCode,[dbo].[func_GetActive](b.Active,'+',b.ItemName,b.ItemContent) ItemName,a.DateOfIssues,(case when a.Morning <>'' then a.Morning+' '+uom_medi.UnitOfMeasureName else '' end) Morning,(case when a.Noon <>'' then a.Noon+' '+uom_medi.UnitOfMeasureName else '' end) Noon,(case when a.Afternoon <>'' then a.Afternoon+' '+uom_medi.UnitOfMeasureName else '' end) Afternoon,(case when a.Evening <>'' then a.Evening +' '+uom_medi.UnitOfMeasureName else '' end) Evening,
		a.Quantity,a.Instruction,a.UnitPrice,b.SalesPrice,b.RateBHYT,a.Amount,c.UnitOfMeasureName,b.BHYTPrice,a.Status,a.RepositoryCode,e.RepositoryName,b1.UsageName,uom_medi.UnitOfMeasureName as UnitOfMeasureName_Medi
		from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode inner join Usage b1 on b.UsageCode=b1.UsageCode
		inner join UnitOfMeasure c on b.UnitOfMeasureCode=c.UnitOfMeasureCode inner join MedicalRecord d on a.MedicalRecordCode=d.MedicalRecordCode
		inner join RepositoryCatalog e on a.RepositoryCode=e.RepositoryCode left join UnitOfMeasure uom_medi on a.UnitOfMeasureCode_Medi=uom_medi.UnitOfMeasureCode
		where a.MedicalRecordCode=@MedicalRecordCode and a.ObjectCode=( case when @ObjectCode=-1 then a.ObjectCode else @ObjectCode end) and e.RepositoryGroupCode in(select RepositoryGroupCode from @TableGroup)
		and a.Status =( case when @Status=-1 then a.Status else @Status end)
		order by a.RowID
	end
	else
	begin
		select a.MedicalRecordCode,a.ItemCode,(b.ItemName+' ' +b.ItemContent) ItemName,a.DateOfIssues,(case when a.Morning <>'' then a.Morning+' '+uom_medi.UnitOfMeasureName else '' end) Morning,(case when a.Noon <>'' then a.Noon+' '+uom_medi.UnitOfMeasureName else '' end) Noon,(case when a.Afternoon <>'' then a.Afternoon+' '+uom_medi.UnitOfMeasureName else '' end) Afternoon,(case when a.Evening <>'' then a.Evening +' '+uom_medi.UnitOfMeasureName else '' end) Evening,
		a.Quantity,a.Instruction,a.UnitPrice,b.SalesPrice,b.RateBHYT,a.Amount,c.UnitOfMeasureName,b.BHYTPrice,a.Status,a.RepositoryCode,e.RepositoryName,b1.UsageName
		from MedicalPrescriptionDetail a inner join Items b on a.ItemCode=b.ItemCode inner join Usage b1 on b.UsageCode=b1.UsageCode
		inner join UnitOfMeasure c on b.UnitOfMeasureCode=c.UnitOfMeasureCode inner join MedicalRecord d on a.MedicalRecordCode=d.MedicalRecordCode
		inner join RepositoryCatalog e on a.RepositoryCode=e.RepositoryCode left join UnitOfMeasure uom_medi on a.UnitOfMeasureCode_Medi=uom_medi.UnitOfMeasureCode
		where a.MedicalRecordCode=@MedicalRecordCode and a.ObjectCode=( case when @ObjectCode=-1 then a.ObjectCode else @ObjectCode end) and e.RepositoryGroupCode in(select RepositoryGroupCode from @TableGroup)
		and a.Status =( case when @Status=-1 then a.Status else @Status end)
		order by a.RowID
	end
go
--create day 15/07/2017
if exists(select name from sysobjects where name='pro_ReportDailyInvoice')
	drop procedure pro_ReportDailyInvoice
go
create procedure pro_ReportDailyInvoice
(
	@StartDate datetime,
	@EndDate datetime,
	@Cancel int=0
)
as
begin
	select ROW_NUMBER() OVER(ORDER BY a.BanksAccountCode DESC) AS RowNumber, b.PatientCode,b.PatientName,
	(case when b.PatientGender=1 then N'Nam' else N'Nữ' end)PatientGenderName,b.PatientBirthyear,a3.ObjectName,
	CONVERT(date,a.PostingDate,103) PostingDate,a.NoInvoice,(case when a.ShiftWork='AM' then N'Ca 1' when a.ShiftWork='PM' then N'Ca 2' when a.ShiftWork='EV' then N'Ca 3' else '' end) ShiftWork,
	a1.EmployeeName,a2.EmployeeName CashierName,(a.TotalAmount-BHYTPay ) as TotalReal,
	[dbo].func_PatientOfAddressFull(c.Address,c1.WardName,c2.DistrictName,c3.ProvincialName) PatientAddress,
	a4.EmployeeName EmployeeNameCancel,a.CancelDate,a.BanksAccountCode,a.ReferenceCode
	,a.ObjectCode,a.ReasonCancel, a.TotalAmount,a.Exemptions,a.TotalBHYTPay,a.BHYTPay,a.TotalSurcharge,a.PatientPay,convert(char(5),a.PostingDate,108) PostingTime,a.TotalBHYTPay-a.BHYTPay as DifferentPay, a.TotalBHYTPay
	from BanksAccount a inner join Patients b on a.PatientCode=b.PatientCode left join Employee a1 on a.EmployeeCode=a1.EmployeeCode left join Employee a2 on a.CashierCode=a2.EmployeeCode
	inner join Object a3 on a.ObjectCode=a3.ObjectCode inner join PatientReceive c on a.ReferenceCode=c.PatientReceiveID left join Employee a4 on a.EmployeeCodeCancel=a4.EmployeeCode
	left join Catalog_Ward c1 on c.WardCode=c1.WardCode left join Catalog_District c2 on c.DistrictCode=c2.DistrictCode left join Catalog_Provincial c3 on c.ProvincialCode=c3.ProvincialCode
	where a.PostingDate between @StartDate and @EndDate and a.Cancel=@Cancel
	order by a.PostingDate,a.NoInvoice
end
go
if exists(select name from sysobjects where name='pro_Report_View_DailyInvoiceDetail')
	drop procedure pro_Report_View_DailyInvoiceDetail
go
create procedure pro_Report_View_DailyInvoiceDetail
(
	
	@StartDate datetime,
	@EndDate datetime,
	@Cancel int=0
	)
as
begin
select lst.*  ,
 (case when lst.BHYTPay>0 then lst.PatientPay else 0 end) DifferentPay, (lst.Quantity * lst.DisparityPrice) DisparityAmount,
 (case when lst.BHYTPay>0 then 0 else lst.PatientPay end) ServiceAmount ,
 (case when lst.BHYTPay>0 then lst.Quantity* lst.DisparityPrice +lst.PatientPay  else lst.Quantity* lst.DisparityPrice +lst.PatientPay  end) TotalAmount
from (
	select p.PatientCode ,p.PatientName,(case when p.PatientGender=1 then N'Nam' else N'Nữ' end)PatientGenderName,p.PatientBirthyear,b3.ObjectName,
	(case when ab.ShiftWork='AM' then N'Ca 1' when ab.ShiftWork='PM' then N'Ca 2' when ab.ShiftWork='EV' then N'Ca 3' else '' end) ShiftWork,
 a4.EmployeeName as DepartmentNameOrder
,a2.ServiceCategoryName
,a3.ServiceGroupName
,a1.ServiceName,
ab1.ServiceCode
,sum(ab1.Quantity)Quantity, ab1.ServicePrice, sum(ab1.DisparityPrice)DisparityPrice, sum(ab1.BHYTPay)BHYTPay,ab1.PatientPay ,N'Lần' UnitOfMeasureName,
CONVERT(date,ab1.PostingDate,104) PostingDate,a5.EmployeeName as CashierName,CONVERT(varchar(5),ab1.PostingDate,108) PostingTime
from BanksAccount ab 
inner join BanksAccountDetail ab1 on ab.BanksAccountCode = ab1.BanksAccountCode 
inner join SuggestedServiceReceipt a on ab1.BanksAccountCode = a.BanksAccountCode and ab1.ReceiptID = a.ReceiptID
  inner  join Service a1 on ab1.ServiceCode = a1.ServiceCode inner join ServiceCategory a2 on a1.ServiceCategoryCode = a2.ServiceCategoryCode
                         inner join ServiceGroup a3 on a2.ServiceGroupCode = a3.ServiceGroupCode
                         left join Department b1 on a.DepartmentCodeOrder = b1.DepartmentCode inner
                         join Object b3 on a.ObjectCode = b3.ObjectCode
                         inner join PatientReceive c1 on a.RefID = c1.PatientReceiveID
                        inner join Employee a4 on a.EmployeeCodeDoctor = a4.EmployeeCode
						inner join Employee a5 on ab.CashierCode = a5.EmployeeCode
						inner join Patients p on ab.PatientCode = p.PatientCode 
 where 1=1  and  ab1.PostingDate between @StartDate and @EndDate and a.Paid in(1) and a.BanksAccountCode is not null
-- where 1=1  and CONVERT(date,ab1.PostingDate,103) between CONVERT(date,@StartDate,103) and CONVERT(date,@EndDate,103)  and a.Paid in(1) and a.BanksAccountCode is not null
 group by  p.PatientCode,p.PatientName,p.PatientGender,p.PatientBirthyear,b3.ObjectName,ab.ShiftWork, a4.EmployeeName 
,a2.ServiceCategoryName
,a3.ServiceGroupName
,a1.ServiceName,
ab1.ServiceCode,ab1.BHYTPay,ab1.STT
,ab1.Quantity,ab1.ServicePrice,ab1.PatientPay,CONVERT(date,ab1.PostingDate,104),a5.EmployeeName,CONVERT(varchar(5),ab1.PostingDate,108)
union all
select p.PatientCode ,p.PatientName,(case when p.PatientGender=1 then N'Nam' else N'Nữ' end)PatientGenderName,p.PatientBirthyear,b3.ObjectName,(case when ab.ShiftWork='AM' then N'Ca 1' when ab.ShiftWork='PM' then N'Ca 2' when ab.ShiftWork='EV' then N'Ca 3' else '' end) ShiftWork,
 
a4.EmployeeName as DepartmentNameOrder
,it1.ItemCategoryName ServiceCategoryName
,it2.GroupName ServiceGroupName
,it.ItemName ServiceName,
ab1.ServiceCode
,sum(ab1.Quantity)Quantity, ab1.ServicePrice, sum(ab1.DisparityPrice)DisparityPrice ,sum(ab1.BHYTPay)BHYTPay,ab1.PatientPay,un.UnitOfMeasureName,
CONVERT(date,ab1.PostingDate,104) PostingDate,a5.EmployeeName as CashierName,CONVERT(varchar(5),ab1.PostingDate,108) PostingTime
from BanksAccount ab inner join BanksAccountDetail ab1 on ab.BanksAccountCode = ab1.BanksAccountCode inner join Patients p on ab.PatientCode = p.PatientCode 
  inner join MedicinesForPatientsDetail me on ab1.BanksAccountCode = me.BanksAccountCode and me.ItemCode = ab1.ServiceCode
  inner join MedicalRecord a on me.MedicalRecordCode = a.MedicalRecordCode  
 left join Items it on ab1.ServiceCode = it.ItemCode
                         join ItemCategory it1 on it1.ItemCategoryCode = it.ItemCategoryCode
                         inner
                         join ItemGroup it2 on it1.GroupCode = it2.GroupCode
                         inner join  UnitOfMeasure un on it.UnitOfMeasureCode = un.UnitOfMeasureCode 
                        inner join Object b3 on a.ObjectCode = b3.ObjectCode
                        inner join Employee a4 on a.EmployeeCodeDoctor = a4.EmployeeCode
						inner join Employee a5 on ab.CashierCode = a5.EmployeeCode
	 where 1=1  and  ab1.PostingDate between @StartDate and @EndDate and a.Paid in(1) and a.BanksAccountCode is not null					
 --where 1=1  and CONVERT(date,a.PostingDate,103) between CONVERT(date,@StartDate,103) and CONVERT(date,@EndDate,103)  and a.Paid in(1) and a.BanksAccountCode is not null
 group by p.PatientCode,p.PatientName,p.PatientGender,p.PatientBirthyear,b3.ObjectName,ab.ShiftWork, a4.EmployeeName ,CONVERT(varchar(5),ab1.PostingDate,108)
,it1.ItemCategoryName 
,it2.GroupName 
,it.ItemName ,
ab1.ServiceCode,ab1.BHYTPay,ab1.STT
,ab1.Quantity,ab1.ServicePrice,ab1.PatientPay,un.UnitOfMeasureName, CONVERT(date,ab1.PostingDate,104),a5.EmployeeName
) lst
end


