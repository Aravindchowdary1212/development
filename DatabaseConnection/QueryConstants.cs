using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccuConnect.Core
{
    public static class QueryConstants
    {
        public static string userloginName = "user_Verifylogin";
        public static string ReadUserbyUserName = "user_ReadUserbyUserName";
        public static string GetuserGroups = "user_GetGroups";
        public static string GroupDetailsRead = "user_GroupDetailsRead";
        public static string podGetParameterOptions = "pod_GetAllParameterOptions";
        public static string podGetOrderTypes = "pod_GetOrderTypes";
        public static string podGetOrderTypeParameters = "pod_GetOrderTypeParameters";
        public static string podGetAdminEditOptionDetails = "pod_GetAdminEditOptionDetails";
        public static string podGetAdminEditOptionAttributeDetails = "pod_GetAdminEditOptionAttributeDetails";
        public static string podEditOrderTypeOption = "pod_EditOrderTypeOption";
        public static string podCreateOrderTypeOption = "pod_CreateOrderTypeOption";
        public static string podDeleteOrderTypeOptions = "pod_DeleteOrderTypeOptions";
        public static string podReadAllParamters = "pod_ReadAllParamters";
        public static string podGetEditParameterDetails = "pod_GetEditParameterDetails";
        public static string podAddOrEditOrderParameter = "pod_AddOrEditOrderParameter";
        public static string podDeleteordertypeparameters = "pod_Deleteordertypeparameters";
        public static string podGetRecommendedAdminCustomizeTypes = "pod_GetRecommendedAdminCustomizeTypes";
        public static string podGetParametersWithOptions = "pod_GetParametersWithOptions";
        public static string podGetparametermappings = "pod_Getparametermappings";
        public static string podReadtemplate = "pod_Readtemplate";
        public static string podTemplateDuplicateCheck = "pod_TemplateDuplicateCheck";
        public static string podGetTemplateParameters = "pod_GetTemplateParameters";
        public static string podWriteTemplate = "pod_WriteTemplate";
        public static string podWriteTemplateParameters = "pod_WriteTemplateParameters";
        public static string podWriteTemplateParameterOptions = "pod_WriteTemplateParameterOptions";
        public static string podGetmappedproductsbytemplateId = "pod_GetmappedproductsbytemplateId";
        public static string podUpdateprintfinishoptionsxml = "pod_Updateprintfinishoptionsxml";
        public static string podReadprintfinishoptionsxml = "pod_Readprintfinishoptionsxml";
        public static string podDeleteTemplate = "pod_DeleteTemplate";
        public static string podGetAllPriceDetailsByOptionId = "pod_GetAllPriceDetailsByOptionId";
        public static string podWritePriceDetails = "pod_WritePriceDetails";
        public static string podDeletePriceDetailsById = "pod_DeletePriceDetailsById";
        public static string podGetOrgunitOrderElements = "pod_GetOrgunitOrderElements";
        public static string podUpdatePODConfig = "pod_UpdatePODConfig";
        public static string podWriteParameterOptionConfig = "pod_WriteParameterOptionConfig";
        public static string podDeleteParameterOptionConfig = "pod_DeleteParameterOptionConfig";
        public static string podGetparameterOptionConfigbyOptionConfigpk = "pod_GetparameterOptionConfigbyOptionConfigpk";
        public static string podGetParameterOptionConfig = "pod_GetParameterOptionConfig";
        public static string podWriteParamterOptionRestriction = "pod_WriteParamterOptionRestriction"; //from
        public static string podDeleteParamterOptionRestriction = "pod_DeleteParamterOptionRestriction";
        public static string podGetParamterOptionRestrictionByRestrictionPk="pod_GetParamterOptionRestrictionByRestrictionPk";
        public static string podGetParamterOptionRestrictionByConfigPk="pod_GetParamterOptionRestrictionByConfigPk";
        public static string podWritePrintImpressionConfig="pod_WritePrintImpressionConfig";
        public static string podGetAllPrintImpressionConfig="pod_GetAllPrintImpressionConfig";
        public static string podGetPrintImpressionConfigByImpressionPk="pod_GetPrintImpressionConfigByImpressionPk";
        public static string podDeletePrintImpressionConfig="pod_DeletePrintImpressionConfig";
        public static string ConnectGetDBConnections="Connect_GetDBConnections";
    }

}
