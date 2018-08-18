using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyERP.Web.Others
{
    public static class ReportServices
    {
        public static object ReportGlobalizedTexts()
        {
            return new
            {
                Resources.Resources.R_BC_GD,
                Resources.Resources.R_BC_CHU_KY,
                Resources.Resources.R_BC_GS,
                Resources.Resources.R_BC_KTT,
                Resources.Resources.R_BC_KY_DAU,
                Resources.Resources.R_BC_NGAY,
                Resources.Resources.R_BC_NLB,
                Resources.Resources.R_NGAY_QD_CDKT,
                Resources.Resources.R_SO_QD_CDKT,
                Resources.Resources.R_PAGE,
                Resources.Resources.R_BC_THU_QUY,
                Resources.Resources.R_BC_NGUOI_LAP,
                Resources.Resources.R_BC_NGUOI_NHAN_TIEN,
                Resources.Resources.R_TY_GIA,
                Resources.Resources.R_SO_TIEN_LCY,
                Resources.Resources.R_SO_CT,
                Resources.Resources.R_DAY,
                Resources.Resources.R_MONTH,
                Resources.Resources.R_YEAR,
                Resources.Resources.R_DOI_TAC,
                Resources.Resources.R_DON_VI,
                Resources.Resources.R_DIA_CHI,
                Resources.Resources.R_TK,
                Resources.Resources.R_TK_DU,
                Resources.Resources.R_DIEN_GIAI,
                Resources.Resources.R_SO_TIEN,
                Resources.Resources.R_BANG_CHU,
                Resources.Resources.R_DA_NHAN_DU,
                Resources.Resources.R_SO_CT_KEM_THEO,
                Resources.Resources.R_CHUNG_TU_GOC,
                Resources.Resources.R_BC_CHU_KY_DAU
            };
        }
    }
}