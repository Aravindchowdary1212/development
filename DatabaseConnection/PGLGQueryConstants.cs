using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccuConnect.Core
{
    public static class PGLGQueryConstants
    {
        public static string user_Verifylogin = "[Tblfnc][VerifyLoginName]";
        public static string user_ReadUserbyUserName = "[Tblfnc][readuserbyusername]";
        public static string user_GetGroups = "[Tblfnc][UserGetGroups]";
        public static string user_GroupDetailsRead = "[Tblfnc][GroupDetailsRead]";
        public static string pod_GetAllParameterOptions = "[Tblfnc][UPrint_GetAllParameterOptions]";
        public static string pod_GetOrderTypes = "[Tblfnc][UPrint_ReadOrderTypes]";
        public static string pod_GetOrderTypeParameters = "[Tblfnc][UPrint_GetOrderTypeParameters]";
        public static string pod_GetAdminEditOptionDetails = "[Tblfnc][UPrint_GetAdminEditOptionDetails]";
        public static string pod_GetAdminEditOptionAttributeDetails = "[Tblfnc][UPrint_GetAdminEditOptionAttributeDetails]";
        public static string pod_EditOrderTypeOption = "[Tblfnc][UPrint_EditOrderTypeOption]";
        public static string pod_CreateOrderTypeOption = "[Tblfnc][UPrint_CreateOrderTypeOption]";
        public static string pod_DeleteOrderTypeOptions = "[Tblfnc][UPrint_DeleteOrderTypeOptions]";
        public static string pod_ReadAllParamters = "[Tblfnc][readallparamters]"; 
        public static string pod_GetEditParameterDetails = "[Tblfnc][geteditparameterdetails]"; 
        public static string pod_AddOrEditOrderParameter = "[Proc][spaddoreditorderparameter]";
        public static string pod_Deleteordertypeparameters = "[Proc][SPDeleteordertypeparameters]";
        public static string pod_GetRecommendedAdminCustomizeTypes = "[Tblfnc][UPrint_GetRecommendedAdminCustomizeTypes]";
        public static string pod_GetParametersWithOptions = "[Tblfnc][UPrint_GetParametersWithOptions]";
        public static string pod_Getparametermappings = "[Tblfnc][uprint_getparametermappings]";
        public static string pod_Readtemplate = "[Tblfnc][uprint_readtemplate]";
        public static string pod_TemplateDuplicateCheck = "[Tblfnc][UPrint_TemplateDuplicateCheck]";
        public static string pod_GetTemplateParameters = "[Tblfnc][Uprint_GetTemplateParameters]";
        public static string pod_WriteTemplate = "[Tblfnc][UPrint_WriteTemplate]";
        public static string pod_WriteTemplateParameters = "[Tblfnc][UPrint_WriteTemplateParameters]";
        public static string pod_WriteTemplateParameterOptions = "[Tblfnc][UPrint_WriteTemplateParameterOptions]";
        public static string pod_GetmappedproductsbytemplateId = "[Tblfnc][getmappedproductsbytemplateid]";
        public static string pod_Updateprintfinishoptionsxml = "[Proc][spupdateprintfinishoptionsxml]";
        public static string pod_Readprintfinishoptionsxml = "[Tblfnc][readprintfinishoptionsxml]"; 
        public static string pod_DeleteTemplate = "[Tblfnc][UPrint_DeleteTemplate]";
        public static string pod_GetAllPriceDetailsByOptionId = "[Tblfnc][UPrint_GetAllPriceDetailsByOptionId]";
        public static string pod_WritePriceDetails = "[Tblfnc][Uprint_WritePriceDetails]";
        public static string pod_DeletePriceDetailsById = "[Tblfnc][Uprint_DeletePriceDetailsById]";
        public static string pod_GetOrgunitOrderElements = "[Tblfnc][getorgunitorderelements]";
        public static string pod_UpdatePODConfig = "[Proc][SpUpdatePODConfig]";
        public static string pod_WriteParameterOptionConfig = "[Proc][spwriteparameteroptionconfig]";
        public static string pod_DeleteParameterOptionConfig = "[Proc][spdeleteparameteroptionconfig]";
        public static string pod_GetParameterOptionConfigbyOptionConfigpk = "[Tblfnc][getparameteroptionconfigbyoptionconfigpk]";
        public static string pod_GetParameterOptionConfig = "[Tblfnc][getparameteroptionconfig]";
        public static string pod_WriteParamterOptionRestriction = "[Tblfnc][writeparamteroptionrestriction]";
        public static string pod_DeleteParamterOptionRestriction = "[Proc][spDeleteParamterOptionRestriction]";
        public static string pod_GetParamterOptionRestrictionByRestrictionPk = "[Tblfnc][getparamteroptionrestrictionbyrestrictionpk]";
        public static string pod_GetParamterOptionRestrictionByConfigPk = "[Tblfnc][getparamteroptionrestrictionbyconfigpk]";//to be change
        public static string pod_WritePrintImpressionConfig = "[Proc][spwriteprintimpressionconfig]";
        public static string pod_GetAllPrintImpressionConfig = "[Tblfnc][getallprintimpressionconfig]";
        public static string pod_GetPrintImpressionConfigByImpressionPk = "[Tblfnc][getprintimpressionconfigbyimpressionpk]";
        public static string pod_DeletePrintImpressionConfig = "[Proc][spdeleteprintimpressionconfig]";
        public static string Connect_GetDBConnections = "[Query][Select * from getDBConnections()]";

    }
}
