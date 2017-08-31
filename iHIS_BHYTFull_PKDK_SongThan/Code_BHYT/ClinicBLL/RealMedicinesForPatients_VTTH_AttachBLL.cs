using ClinicDAL;
using ClinicModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ClinicBLL
{
    public class RealMedicinesForPatients_VTTH_AttachBLL
    {
        public static Int32 InsReal(RealMedicinesForPatients_VTTH_AttachInf info, ref decimal refID)
        {
            return RealMedicinesForPatients_VTTH_AttachDAL.InsReal(info, ref refID);
        }
        public static Int32 InsRealDetail(RealMedicinesForPatients_VTTH_Attach_DetailInf info)
        {
            return RealMedicinesForPatients_VTTH_AttachDAL.InsRealDetail(info);
        }
        public static Int32 Del_RealMedicinesForPatients_VTTH_Attach_Detail(decimal dRealID, string sItemCode, decimal dRowID)
        {
            return RealMedicinesForPatients_VTTH_AttachDAL.Del_RealMedicinesForPatients_VTTH_Attach_Detail(dRealID, sItemCode, dRowID);
        }
        public static DataTable DTRealMedicinesForEmergency_VTTH_Attach_Detail(decimal dRealRowID)
        {
            return RealMedicinesForPatients_VTTH_AttachDAL.DTRealMedicinesForEmergency_VTTH_Attach_Detail(dRealRowID);
        }
        public static DataTable DTRealMedicinesForPatients_VTTH_Attach_Detail(string sCode)
        {
            return RealMedicinesForPatients_VTTH_AttachDAL.DTRealMedicinesForPatients_VTTH_Attach_Detail(sCode);
        }
    }
}
