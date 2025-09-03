using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core
{
    public static class SQLQueryConstants
    {
        public static string user_Verifylogin = "[Proc][SpVerifyLoginName]";
        public static string user_ReadUserbyUserName = "[Proc][SpReadUserbyUserName]";
        public static string user_GetGroups = "[Proc][SpUserGetGroups]";
        public static string user_GroupDetailsRead = "[Proc][SpGroupDetailsRead]";
        public static string pod_GetAllParameterOptions = "[Proc][UPrint_GetAllParameterOptions]";
        public static string pod_GetOrderTypes = "[Proc][UPrint_ReadOrderTypes]";
        public static string pod_GetOrderTypeParameters = "[Proc][UPrint_GetOrderTypeParameters]";
        public static string pod_GetAdminEditOptionDetails = "[Proc][UPrint_GetAdminEditOptionDetails]";
        public static string pod_GetAdminEditOptionAttributeDetails = "[Proc][UPrint_GetAdminEditOptionAttributeDetails]";
        public static string pod_EditOrderTypeOption = "[Proc][UPrint_EditOrderTypeOption]";
        public static string pod_CreateOrderTypeOption = "[Proc][UPrint_CreateOrderTypeOption]";
        public static string pod_DeleteOrderTypeOptions = "[Proc][UPrint_DeleteOrderTypeOptions]";
        public static string pod_ReadAllParamters = "[Proc][SpReadAllParamters]";
        public static string pod_GetEditParameterDetails = "[Proc][SpGetEditParameterDetails]";
        public static string pod_AddOrEditOrderParameter = "[Proc][SpAddOrEditOrderParameter]";
        public static string pod_Deleteordertypeparameters = "[Proc][SpDeleteOrderTypeParameters]";
        public static string pod_GetRecommendedAdminCustomizeTypes = "[Proc][UPrint_GetRecommendedAdminCustomizeTypes]";
        public static string pod_GetParametersWithOptions = "[Proc][UPrint_GetParametersWithOptions]";
        public static string pod_Getparametermappings = "[Proc][UPrint_GetParameterMappings]";
        public static string pod_Readtemplate = "[Proc][UPrint_ReadTemplate]";
        public static string pod_TemplateDuplicateCheck = "[Proc][UPrint_TemplateDuplicateCheck]";
        public static string pod_GetTemplateParameters = "[Proc][Uprint_GetTemplateParameters]";
        public static string pod_WriteTemplate = "[Proc][UPrint_WriteTemplate]";
        public static string pod_WriteTemplateParameters = "[Proc][UPrint_WriteTemplateParameters]";
        public static string pod_WriteTemplateParameterOptions = "[Proc][UPrint_WriteTemplateParameterOptions]";
        public static string pod_GetmappedproductsbytemplateId = "[Proc][SpGetMappedProductsByTemplateId]";
        public static string pod_Updateprintfinishoptionsxml = "[Proc][SpUpdatePrintFinishOptionsXML]";
        public static string pod_Readprintfinishoptionsxml = "[Proc][SpReadPrintFinishOptionsXML]";
        public static string pod_DeleteTemplate = "[Proc][UPrint_DeleteTemplate]";
        public static string pod_GetAllPriceDetailsByOptionId = "[Proc][UPrint_GetAllPriceDetailsByOptionId]";
        public static string pod_WritePriceDetails = "[Proc][Uprint_WritePriceDetails]";
        public static string pod_DeletePriceDetailsById = "[Proc][Uprint_DeletePriceDetailsById]";
        public static string pod_GetOrgunitOrderElements = "[Proc][ACG5_SPGETOrgUnitOrderElements]";
        public static string pod_UpdatePODConfig = "[Proc][SpUpdatePODConfig]";
        public static string pod_WriteParameterOptionConfig = "[Proc][SpWriteParameterOptionConfig]";
        public static string pod_DeleteParameterOptionConfig = "[Proc][SpDeleteParameterOptionConfig]";
        public static string pod_GetParameterOptionConfigbyOptionConfigpk = "[Proc][ACG5_spReadParameterOptionConfigByoptionConfigPk]";
        public static string pod_GetParameterOptionConfig = "[Proc][SpGetParameterOptionConfig]";
        public static string pod_WriteParamterOptionRestriction = "[Proc][spWriteParamterOptionRestriction]";
        public static string pod_DeleteParamterOptionRestriction = "[Proc][spDeleteParamterOptionRestriction]";
        public static string pod_GetParamterOptionRestrictionByRestrictionPk = "[Proc][ACG5_spGetParamterOptionRestrictionByRestrictionPk]";
        public static string pod_GetParamterOptionRestrictionByConfigPk = "[Proc][spGetParamterOptionRestrictionByConfigPk]";
        public static string pod_WritePrintImpressionConfig = "[Proc][spWritePrintImpressionConfig]";
        public static string pod_GetAllPrintImpressionConfig = "[Proc][spGetAllPrintImpressionConfig]";
        public static string pod_GetPrintImpressionConfigByImpressionPk = "[Proc][spGetPrintImpressionConfigByimpressionPk]";
        public static string pod_DeletePrintImpressionConfig = "[Proc][spDeletePrintImpressionConfig]";
        public static string Connect_GetDBConnections = "[Proc][spGetDBConnections]";
        

    }
}
