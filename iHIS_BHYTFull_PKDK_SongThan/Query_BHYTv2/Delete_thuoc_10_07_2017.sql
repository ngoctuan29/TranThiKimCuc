USE [iHIS_SongThan]
----Sung-10/08/2017
GO
alter procedure [dbo].[prDel_Thuoc]
(
	@iresult int output,
	@RowID numeric(18, 0),
	@MedicalRecordCode varchar(50),
	@ItemCode varchar(50)
)
as
begin
	if exists(select RowID from MedicinesForPatientsDetail where MedicalRecordCode=@MedicalRecordCode and ItemCode=@ItemCode)
	begin
		if exists(select MD.RowID from MedicinesForPatientsDetail MD, MedicinesForPatients MP where MD.MedicalRecordCode=@MedicalRecordCode and MD.MedicalRecordCode=MP.MedicalRecordCode and MD.ItemCode=@ItemCode and MD.Paid=0 and MP.Done=0)
			begin 
				delete from MedicinesForPatientsDetail where MedicalRecordCode=@MedicalRecordCode and ItemCode=@ItemCode and Paid=0
				set @iresult = 1
					update MedicalPrescriptionDetail set Status=0 where MedicalRecordCode=@MedicalRecordCode 
				if not exists(select MD.RowID from MedicinesForPatientsDetail MD, MedicinesForPatients MP where MD.MedicalRecordCode=@MedicalRecordCode and MD.MedicalRecordCode=MP.MedicalRecordCode)
					delete from MedicinesForPatients where MedicalRecordCode=@MedicalRecordCode
			end
		else
		begin
			set @iresult =-1
		end
	end
	else
	begin
		set @iresult =-2
	end
end





