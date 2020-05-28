using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpotonServices.Controllers;
using SpotonServices.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpotonServices.Controllers
{
    [Produces("application/json")]
    [Route("CaseController")]
    public class CaseController : Controller
    {
        DataAccess obj = new DataAccess();
        // GET: api/<controller>
        //[HttpGet]
        //[Route("Consignment")]
        //public List<SpotonStaticCaseDetails> Get(string conNumber)
        //{
        //    List<SpotonStaticCaseDetails> spotonStaticCaseDetails = new List<SpotonStaticCaseDetails>();

        //    DataTable dt = obj.CaseAccountDetailsInfo(conNumber);
        //    spotonStaticCaseDetails = DataTableToModelConverter.ConvertToList<SpotonStaticCaseDetails>(dt);
        //    return spotonStaticCaseDetails;
        //}

        [HttpGet]
        [Route("UserList")]
        public List<UserList> UserList(string loggegUserID)
        {
            List<UserList> userList = new List<UserList>();

            DataTable dt = obj.UserList(loggegUserID);
            userList = DataTableToModelConverter.UserListToModel(dt);
            return userList;
        }

        [HttpGet]
        [Route("EmployeeDetail")]
        public List<EmployeeDetail> EmpDetail()
        {
            List<EmployeeDetail> empDetail = new List<EmployeeDetail>();

            DataTable dt = obj.EmployeeDetails();
            empDetail = DataTableToModelConverter.EmployeeDetailToModel(dt);
            return empDetail;
        }

        [HttpGet]
        [Route("Empmst")]
        public List<EmpMst> EmpMst()
        {
            List<EmpMst> emp = new List<EmpMst>();

            DataTable dt = obj.GetEmpMst();
            emp = DataTableToModelConverter.EmpmstToModel(dt);
            return emp;
        }

        [HttpGet]
        [Route("ComplainSource")]
        public List<ComplainSource> ComplainSource()
        {
            List<ComplainSource> complainSources = new List<ComplainSource>();

            DataTable dt = obj.GetComplaintSource();
            complainSources = DataTableToModelConverter.ComplainSourceToModel(dt);
            return complainSources;
        }


        [HttpGet]
        [Route("WipStatus")]
        public List<WipStatus> WipStatus()
        {
            List<WipStatus> wipStatus = new List<WipStatus>();
            DataTable dt = obj.GetWIPStatus();
            wipStatus = DataTableToModelConverter.WipStatusToModel(dt);
            return wipStatus;
        }

        [HttpGet]
        [Route("OperationUtyCode")]
        public List<OperationUtyMst> OperationUtyCode()
        {
            List<OperationUtyMst> operationUtyMst = new List<OperationUtyMst>();
            DataTable dt = obj.GetOperationsUtyMst();
            operationUtyMst = DataTableToModelConverter.OperationUtyMstToModel(dt);
            return operationUtyMst;
        }

        [HttpGet]
        [Route("TtsCategory")]
        public List<TtsCategory> TtsCategory()
        {
            List<TtsCategory> ttsCategory = new List<TtsCategory>();
            DataTable dt = obj.GetTTSCategory();
            ttsCategory = DataTableToModelConverter.TtscategoryToModel(dt);
            return ttsCategory;
        }

        [HttpGet]
        [Route("InvoiceDetail")]
        public List<StaticCaseDetails> InvoiceDetail(string invNumber)
        {
            List<StaticCaseDetails> invoice = new List<StaticCaseDetails>();
            DataTable dt = obj.GetInvoiceDetail(invNumber);
            invoice = DataTableToModelConverter.Invoce(dt);
            return invoice;
        }

        [HttpGet]
        [Route("ConsignmentDetail")]
        public List<StaticCaseDetails> ConsignmentDetail(string conNumber)
        {
            List<StaticCaseDetails> invoice = new List<StaticCaseDetails>();
            DataTable dt = obj.GetConsignmentDetail(conNumber);
            invoice = DataTableToModelConverter.Consignment(dt);
            return invoice;
        }

        [HttpGet]
        [Route("PickupDetail")]
        public List<StaticCaseDetails> PickupDetail(string Pickup)
        {
            List<StaticCaseDetails> pickup = new List<StaticCaseDetails>();
            DataTable dt = obj.GetPickupDetail(Pickup);
            pickup = DataTableToModelConverter.Pickup(dt);
            return pickup;
        }

        [HttpGet]
        [Route("GetAccountDetailsByNameOrId")]
        public List<SpotonAccountDetails> GetAccountDetailsByNameOrId(string accountCodeOrName)
        {
            return DataTableToModelConverter.AccountDetailsListToModel(obj.GetAccountDetailsByNameOrId(accountCodeOrName));
        }

        [HttpGet]
        [Route("GetAccountNames")]
        public List<CommonListDetails> GetAccountNames()
        {
            return DataTableToModelConverter.AccountNameListToModel(obj.GetAccountNames());
        }

        [HttpGet]
        [Route("GetAccountTypesByAccount")]
        public AccountInfo GetAccountTypesByAccount(string accountCode)
        {
            return DataTableToModelConverter.AccountTypesListToModel(obj.GetAccountTypesByAccount(accountCode));
        }

        [HttpGet]
        [Route("GetCommunicationDetailsByAccount")]
        public AccountCommunication GetCommunicationDetailsByAccount(string accountCode)
        {
            return DataTableToModelConverter.CommunicationTypesListToModel(obj.GetCommunicationDetailsByAccount(accountCode));
        }

        [HttpGet]
        [Route("GetChildAccountDetailsByAccount")]
        public List<ChildAccountDetails> GetChildAccountDetailsByAccount(string accountCode)
        {
            return DataTableToModelConverter.ChildAccountDetailsListToModel(obj.GetChildAccountDetailsByAccount(accountCode));
        }

        [HttpGet]
        [Route("GetAccountDetailsByAccount")]
        public AccountDetails GetAccountDetailsByAccount(string accountCode)
        {
            return DataTableToModelConverter.AccountDetailListToModel(obj.GetAccountDetailsByAccount(accountCode));
        }

        [HttpGet]
        [Route("GetAccountNumbersByCode")]
        public List<AccountInfo> GetAccountNumbersByCode(string accountCode)
        {
            return DataTableToModelConverter.AccountContactsListToModel(obj.GetAccountNumbersByCode(accountCode));
        }

        [HttpGet]
        [Route("GetCustomerContactDetails")]
        public List<CRMContactDetails> GetCustomerContactDetails(string codeOrName)
        {
            return DataTableToModelConverter.CustomerContactsListToModel(obj.GetCustomerContactDetails(codeOrName));
        }

        [HttpGet]
        [Route("GetDocketNumberByRefType")]
        public bool GetDocketNumberByRefType(string refNumber)
        {
            return obj.GetDocketNumberByRefType(refNumber);
        }

        [HttpGet]
        [Route("GetPickupRefNoByRefType")]
        public bool GetPickupRefNoByRefType(string refNumber)
        {
            return obj.GetPickupRefNoByRefType(refNumber);
        }

        [HttpGet]
        [Route("GetInvoiceNoByRefType")]
        public bool GetInvoiceNoByRefType(string refNumber)
        {
            return obj.GetInvoiceNoByRefType(refNumber);
        }

        [HttpGet]
        [Route("GetPtmsRefNoByRefType")]
        public bool GetPtmsRefNoByRefType(string refNumber)
        {
            return obj.GetPtmsRefNoByRefType(refNumber);
        }

        [HttpGet]
        [Route("GetContactDetailsByNumber")]
        public List<CallDetails> GetContactDetailsByNumber(string number)
        {
            return DataTableToModelConverter.ContactDetailsListToModel(obj.GetContactDetailsByNumber(number));
        }

        [HttpGet]
        [Route("GetContactBySupervisorID")]
        public CommonListDetails GetContactBySupervisorID(string supervisorId)
        {
            return DataTableToModelConverter.SupervisorDetailsListToModel(obj.GetContactBySupervisorID(supervisorId));
        }

        [HttpGet]
        [Route("GetConsignmentDetailsByRefNo")]
        public CaseAccountDetails GetConsignmentDetailsByRefNo(string refNo)
        {
            return DataTableToModelConverter.CaseAccountDetailsListToModel(obj.GetConsignmentDetailsByRefNo(refNo));
        }

        [HttpGet]
        [Route("GetTTSAutoAssignBasedOnAccount")]
        public TTSAutoAssignDetails GetTTSAutoAssignBasedOnAccount(string AccountCode)
        {
            return DataTableToModelConverter.TTSAccountDetailsListToModel(obj.GetTTSAutoAssignBasedOnAccount(AccountCode));
        }

        [HttpGet]
        [Route("GetTTSAutoAssignBasedOnBranch")]
        public TTSAutoAssignDetails GetTTSAutoAssignBasedOnBranch(string BranchCode)
        {
            return DataTableToModelConverter.TTSAccountDetailsListToModel(obj.GetTTSAutoAssignBasedOnBranch(BranchCode));
        }

        [HttpGet]
        [Route("GetptmsAcntcode")]
        public TTSAutoAssignDetails GetptmsAcntcode(string AccountCode)
        {
            return DataTableToModelConverter.PtMSAssignDetailsListToModel(obj.GetptmsAcntcode(AccountCode));
        }

        [HttpGet]
        [Route("GetConTopStatusCodeDetails")]
        public List<ConStatusCodeDetails> GetConTopStatusCodeDetails()
        {
            return DataTableToModelConverter.StatusCodeDetailsListToModel(obj.GetConTopStatusCodeDetails());
        }

        [HttpGet]
        [Route("TtsComplaintMainCategory")]
        public List<TtsComplaintMainCategory> TtsComplaintMainCategory()
        {
            List<TtsComplaintMainCategory> data = new List<TtsComplaintMainCategory>();

            DataTable dt = obj.GetTtsComplaintMainCategory();
            data = DataTableToModelConverter.MainCategoryToModel(dt);
            return data;
        }

        [HttpGet]
        [Route("GetTTSMemberGroupDetails")]
        public List<MemberGroupDetails> GetTTSMemberGroupDetails()
        {
            List<MemberGroupDetails> data = new List<MemberGroupDetails>();

            DataTable dt = obj.GetTTSMemberGroupDetails();
            data = DataTableToModelConverter.MemberGroupListToModel(dt);
            return data;
        }

        [HttpGet]
        [Route("GetTTSAutoAssignDetails")]
        public List<TTSAutoAssignDetails> GetTTSAutoAssignDetails()
        {
            List<TTSAutoAssignDetails> data = new List<TTSAutoAssignDetails>();

            DataTable dt = obj.GetTTSAutoAssignDetails();
            data = DataTableToModelConverter.TTSAccountListToModel(dt);
            return data;
        }

        [HttpGet]
        [Route("BRMS")]
        public List<BRMS> BRMS()
        {
            List<BRMS> data = new List<BRMS>();
            DataTable dt = obj.GetBranchDetail();
            data = DataTableToModelConverter.BrmsToModel(dt);
            return data;
        }

        [HttpGet]
        [Route("Status")]
        public List<StatusDetails> GeTTSStatusDetail()
        {
            List<StatusDetails> data = new List<StatusDetails>();
            DataTable dt = obj.GeTTSStatusDetail();
            data = DataTableToModelConverter.StatusToModel(dt);
            return data;
        }

        [HttpGet]
        [Route("TtsMember")]
        public List<EmployeeDetail> TtsMember()
        {
            List<EmployeeDetail> empDetail = new List<EmployeeDetail>();

            DataTable dt = obj.ttsMember();
            empDetail = DataTableToModelConverter.ttsMemberToModel(dt);
            return empDetail;
        }

        [HttpGet]
        [Route("DestinationDateForConsignment")]
        public List<ConsignmentDestinationDetail> GetDestinationDateForConsignment(List<string> consignments)
        {
            return DataTableToModelConverter.ConsignmentDestinationToModel(obj.GetDestinationDateForConsignment(consignments));
        }

        [HttpGet]
        [Route("TblRoleAssignment")]
        public List<CrmTblRoleAssignment> TblRoleAssignment()
        {
            List<CrmTblRoleAssignment> roleAssign = new List<CrmTblRoleAssignment>();
            DataTable dt = obj.CrmTblRoleAssignment();
            roleAssign = DataTableToModelConverter.RoleAssignmentToModel(dt);
            return roleAssign;
        }

        [HttpGet]
        [Route("TblDeptMst")]
        public List<TblDeptMst> TblDeptMst()
        {
            List<TblDeptMst> dept = new List<TblDeptMst>();
            DataTable dt = obj.TblDeptMst();
            dept = DataTableToModelConverter.TblDeptMstToModel(dt);
            return dept;
        }

        [HttpGet]
        [Route("ValidateConNumberFromDocket")]
        public List<CommonListDetails> ValidateConNumberFromDocket(List<string> refNumber)
        {
            List<CommonListDetails> data = new List<CommonListDetails>();
            DataTable dt = obj.ValidateConNumberFromDocket(refNumber);
            data = DataTableToModelConverter.Consignmentvalidation(dt);
            return data;
        }

        [HttpGet]
        [Route("ValidateConNumberFromInvoice")]
        public List<CommonListDetails> ValidateConNumberFromInvoice(List<string> refNumber)
        {
            List<CommonListDetails> data = new List<CommonListDetails>();
            DataTable dt = obj.ValidateConNumberFromInvoice(refNumber);
            data = DataTableToModelConverter.Invoicevalidation(dt);
            return data;
        }

        [HttpGet]
        [Route("ValidateConNumberFromPickup")]
        public List<CommonListDetails> ValidateConNumberFromPickup(List<string> refNumber)
        {
            List<CommonListDetails> data = new List<CommonListDetails>();
            DataTable dt = obj.ValidateConNumberFromPickup(refNumber);
            data = DataTableToModelConverter.Pickupvalidation(dt);
            return data;
        }

        [HttpGet]
        [Route("MultipleCaseOpeningConsignmentDetail")]
        public List<StaticCaseDetails> MultipleCaseOpeningListDetail(string conNumber)
        {
            List<StaticCaseDetails> consignement = new List<StaticCaseDetails>();
            DataTable dt = obj.GetMultipleCaseOpeningListDetail(conNumber);
            consignement = DataTableToModelConverter.MultipleOpening(dt);
            return consignement;
        }

        [HttpGet]
        [Route("MultipleCaseOpeningInvoiceDetail")]
        public List<StaticCaseDetails> MultipleCaseOpeningInvoiceDetail(string Invoice)
        {
            List<StaticCaseDetails> invoice = new List<StaticCaseDetails>();
            DataTable dt = obj.GetMultipleCaseOpeningInvoiceDetail(Invoice);
            invoice = DataTableToModelConverter.MultipleOpening(dt);
            return invoice;
        }

        [HttpGet]
        [Route("MultipleCaseOpeningPickupDetail")]
        public List<StaticCaseDetails> MultipleCaseOpeningPickupDetail(string Pickup)
        {
            List<StaticCaseDetails> pickup = new List<StaticCaseDetails>();
            DataTable dt = obj.GetMultipleCaseOpeningPickupDetail(Pickup);
            pickup = DataTableToModelConverter.MultipleOpening(dt);
            return pickup;
        }

        [HttpGet]
        [Route("GetTTSAutoAssignBasedOnAccountList")]
        public List<TTSAutoAssignDetails> GetTTSAutoAssignBasedOnAccountList(string AccountCode)
        {
            return DataTableToModelConverter.TTSAccountDetailsListsToModel(obj.GetTTSAutoAssignBasedOnAccountList(AccountCode));
        }

        [HttpGet]
        [Route("GetTTSAutoAssignBasedOnBranchList")]
        public List<TTSAutoAssignDetails> GetTTSAutoAssignBasedOnBranchList(string BranchCode)
        {
            return DataTableToModelConverter.TTSAccountDetailsListsToModel(obj.GetTTSAutoAssignBasedOnBranchList(BranchCode));
        }

        [HttpGet]
        [Route("GetptmsAcntcodeList")]
        public List<TTSAutoAssignDetails> GetptmsAcntcodeList(string AccountCode)
        {
            return DataTableToModelConverter.PtMSAssignDetailsListsToModel(obj.GetptmsAcntcodeList(AccountCode));
        }

        [HttpGet]
        [Route("AgentBranchAndAccountDetails")]
        public List<BackupAssignment> GetAgentBranchAndAccountDetails(string empCode)
        {
            List<BackupAssignment> dept = new List<BackupAssignment>();
            DataTable dt = obj.PrimaryAgentAccountAndBranchDetails(empCode);
            dept = DataTableToModelConverter.AgentPrimaryDetailsToModel(dt);
            return dept;
        }

        #region esclation

        [HttpGet]
        [Route("TblDeptLevelMaster")]
        public List<DeptLevelMaster> TblDeptLevelMaster()
        {
            List<DeptLevelMaster> dept = new List<DeptLevelMaster>();
            DataTable dt = obj.GetEsclationLevelDetail();
            dept = DataTableToModelConverter.TblDeptLevelMstToModel(dt);
            return dept;
        }

        [HttpGet]
        [Route("EsclationBranchDetail")]
        public List<EsclationBranchDetail> EsclationBranchDetail()
        {
            List<EsclationBranchDetail> EsclationBranch = new List<EsclationBranchDetail>();
            DataTable dt = obj.GetBranchForEsclation();
            EsclationBranch = DataTableToModelConverter.EsclationBranch(dt);
            return EsclationBranch;
        }

        [HttpGet]
        [Route("EmployeeDetailForEsclation")]
        public List<EsclationEmpDetails> EmployeeDetailForEsclation(string branch, int Level, int DeptId)
        {
            List<EsclationEmpDetails> EmpDetail = new List<EsclationEmpDetails>();
            DataTable dt = obj.GetEsclationEmpDetail(branch, Level, DeptId);
            EmpDetail = DataTableToModelConverter.EsclationEmpDetail(dt);
            return EmpDetail;
        }

        [HttpGet]
        [Route("EsclationReason")]
        public List<CommonListDetails> EsclationReason(int DeptId, string BranchType)
        {
            List<CommonListDetails> reason = new List<CommonListDetails>();
            DataTable dt = obj.GetEsclationReason(DeptId, BranchType);
            reason = DataTableToModelConverter.EsclationReason(dt);
            return reason;
        }

        #endregion

        #region account types for reports
        [HttpGet]
        [Route("AccountTypes")]
        public List<CommonListDetails> GetAccountTypeDetails()
        {
            List<CommonListDetails> dept = new List<CommonListDetails>();
            DataTable dt = obj.GetAccountTypeDetails();
            dept = DataTableToModelConverter.AccountListToModel(dt);
            return dept;
        }
        #endregion


        [HttpGet]
        [Route("EsclationReasonName")]
        public List<CommonListDetails> EsclationReasonName(List<string> Id)
        {
            List<CommonListDetails> reason = new List<CommonListDetails>();
            DataTable dt = obj.GEsclationReasonName(Id);
            reason = DataTableToModelConverter.EsclationReason(dt);
            return reason;
        }

        [HttpGet]
        [Route("OnDemand")]
        public List<OnDemandReport> OnDemandReport(string fromDate, string toDate, string teamLead, int? accountCode, int? caseType, int? caseStatus)
        {
            List<OnDemandReport> reason = new List<OnDemandReport>();
            DataTable dt = obj.GetDatForOnDemand(fromDate, toDate, teamLead, accountCode, caseType, caseStatus);
            reason = DataTableToModelConverter.OnDemandReport(dt);
            return reason;
        }

        #region region and depo details for reports
        [HttpGet]
        [Route("Region")]
        public List<CommonListDetails> GetRegionDetails()
        {
            List<CommonListDetails> dept = new List<CommonListDetails>();
            DataTable dt = obj.GetRegionDetails();
            dept = DataTableToModelConverter.RegionListToModel(dt);
            return dept;
        }

        [HttpGet]
        [Route("Depo")]
        public List<CommonListDetails> GetDepoDetails()
        {
            List<CommonListDetails> dept = new List<CommonListDetails>();
            DataTable dt = obj.GetDepoDetails();
            dept = DataTableToModelConverter.DepoListToModel(dt);
            return dept;
        }
        #endregion

        #region Dashboards

        [HttpGet]
        [Route("PickupDetails")]
        public List<PickupDetails> GetPickupDetails(string empId)
        {
            List<PickupDetails> dept = new List<PickupDetails>();

            DataTable dt = obj.GetPickupDetails(empId);
            dept = DataTableToModelConverter.PickupListToModel(dt);

            return dept;
        }

        [HttpGet]
        [Route("ConMovements")]
        public List<ConMovementDetails> GetConMovementDetails(string userIds)
        {
            List<ConMovementDetails> dept = new List<ConMovementDetails>();
            DataTable dt = obj.GetConMovementDetails(userIds);
            dept = DataTableToModelConverter.ConMovementsToModel(dt);

            return dept;
        }

        [HttpGet]
        [Route("ConMovementDetails")]
        public List<ConMovements> GetConMovementDetailsById(string userIds, string docStatus, string pType, string dueDate)
        {
            List<ConMovements> dept = new List<ConMovements>();
            DataTable dt = obj.GetConMovementDetailsById(userIds, docStatus, pType, dueDate);
            dept = DataTableToModelConverter.ConMovementsDetailsToModel(dt);

            return dept;
        }

        [HttpGet]
        [Route("PickupStatusDetails")]
        public List<PickupStatusDetails> GetPickupDetailsById(string userIds, string pickStatus, string IsSTDorODA, string closureType, string regionType)
        {
            List<PickupStatusDetails> dept = new List<PickupStatusDetails>();
            DataTable dt = obj.GetPickupDetailsById(userIds, pickStatus, IsSTDorODA, closureType, regionType);
            dept = DataTableToModelConverter.PickupStatusDetailsToModel(dt);

            return dept;
        }


        #endregion
    }
}
