using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace SpotonServices.Model
{
    public static class DataTableToModelConverter
    {

        public static List<UserList> UserListToModel(DataTable dt)
        {
            List<UserList> Userlist = dt.AsEnumerable().Select(x => new UserList
            {
                EmployeeId = (string)(x["EmployeeId"] != DBNull.Value ? x["EmployeeId"] : ""),
                EmployeeName = (string)(x["EmployeeName"] != DBNull.Value ? x["EmployeeName"] : ""),
                EmailId = (string)(x["EmailID"] != DBNull.Value ? x["EmailID"] : ""),
                SupervisorName = (string)(x["SupervisorName"] != DBNull.Value ? x["SupervisorName"] : ""),
                SupervisorId = (string)(x["SupervisorId"] != DBNull.Value ? x["SupervisorId"] : ""),
                SubGroup = (string)(x["SubGroup"] != DBNull.Value ? x["SubGroup"] : ""),
                Department = (string)(x["Department"] != DBNull.Value ? x["Department"] : "")
            }).ToList();

            return Userlist;
        }

        public static List<EmployeeDetail> EmployeeDetailToModel(DataTable dt)
        {
            List<EmployeeDetail> emp = dt.AsEnumerable().Select(x => new EmployeeDetail
            {
                EmployeeId = (string)(x["EmpCode"] != DBNull.Value ? x["EmpCode"] : ""),
                EmployeeName = (string)(x["EmpName"] != DBNull.Value ? x["EmpName"] : ""),
                EmailId = (string)(x["EmailID"] != DBNull.Value ? x["EmailID"] : ""),
                GroupId = (int)(x["GroupID"] != DBNull.Value ? x["GroupID"] : 0)
            }).ToList();

            return emp;
        }


        public static List<EmpMst> EmpmstToModel(DataTable dt)
        {
            List<EmpMst> emp = dt.AsEnumerable().Select(x => new EmpMst
            {
                EmployeeId = (string)(x["EMPCD"] != DBNull.Value ? x["EMPCD"] : ""),
                EmployeeName = (string)(x["EMPNM"] != DBNull.Value ? x["EMPNM"] : ""),
                ActiveFlag = (string)(x["ActiveFlag"] != DBNull.Value ? x["ActiveFlag"] : ""),
                ManagerEmpCode = (string)(x["ManagerEmpCd"] != DBNull.Value ? x["ManagerEmpCd"] : ""),
                Dept = (string)(x["DEPT"] != DBNull.Value ? x["DEPT"] : ""),
                Email = (string)(x["e_mailID"] != DBNull.Value ? x["e_mailID"] : ""),
            }).ToList();

            return emp;
        }

        public static List<ComplainSource> ComplainSourceToModel(DataTable dt)
        {
            List<ComplainSource> complainSource = dt.AsEnumerable().Select(x => new ComplainSource
            {
                ID = (int)(x["ID"] != DBNull.Value ? x["ID"] : 0),
                Description = (string)(x["Description"] != DBNull.Value ? x["Description"] : ""),
                isactive = (bool)(x["isactive"] != DBNull.Value ? x["isactive"] : ""),

            }).ToList();

            return complainSource;
        }

        public static List<WipStatus> WipStatusToModel(DataTable dt)
        {
            List<WipStatus> wipStatus = dt.AsEnumerable().Select(x => new WipStatus
            {
                StatusId = (int)(x["Statusid"] != DBNull.Value ? x["Statusid"] : 0),
                Name = (string)(x["Name"] != DBNull.Value ? x["Name"] : ""),
                Description = (string)(x["Description"] != DBNull.Value ? x["Description"] : ""),
                Mode = (string)(x["Mode"] != DBNull.Value ? x["Mode"] : ""),

            }).ToList();

            return wipStatus;
        }

        public static List<OperationUtyMst> OperationUtyMstToModel(DataTable dt)
        {
            List<OperationUtyMst> operationUtyMst = dt.AsEnumerable().Select(x => new OperationUtyMst
            {
                OperationsUtyID = (int)(x["OperationsUtyID"] != DBNull.Value ? x["OperationsUtyID"] : 0),
                code = (string)(x["Code"] != DBNull.Value ? x["Code"] : ""),
                OpCode = (string)(x["OpCode"] != DBNull.Value ? x["OpCode"] : ""),
                Description = (string)(x["Description"] != DBNull.Value ? x["Description"] : ""),
                IsReminderdate = (bool)(x["isreminderdate"] != DBNull.Value ? x["isreminderdate"] : false), //IsTTSStatus
                IsTTSStatus = (bool)(x["IsTTSStatus"] != DBNull.Value ? x["IsTTSStatus"] : false)
            }).ToList();

            return operationUtyMst;
        }

        public static List<TtsCategory> TtscategoryToModel(DataTable dt)
        {
            List<TtsCategory> ttsCategories = dt.AsEnumerable().Select(x => new TtsCategory
            {
                CategoryID = (int)(x["CategoryID"] != DBNull.Value ? x["CategoryID"] : 0),
                CategoryName = (string)(x["CategoryName"] != DBNull.Value ? x["CategoryName"] : ""),
                CloseCat = (bool?)(x["CloseCat"] != DBNull.Value ? x["CloseCat"] : null),
                MainCategoryID = (int)(x["MainCategoryID"] != DBNull.Value ? x["MainCategoryID"] : 0),
                ParentID = (int)(x["ParentID"] != DBNull.Value ? x["ParentID"] : 0),
                Priority = (string)(x["Priority"] != DBNull.Value ? x["Priority"] : "0"),
                IsActive = (bool)(x["IsActive"] != DBNull.Value ? x["IsActive"] : false),
                 CRMWarningSLA = (int) (x["CRM_FailureSLA"] != DBNull.Value? x["CRM_FailureSLA"] : 0),

            }).ToList();

            return ttsCategories;
        }

        public static List<StaticCaseDetails> Invoce(DataTable dt)
        {
            List<StaticCaseDetails> staticInv = dt.AsEnumerable().Select(x => new StaticCaseDetails
            {
                CaseAccountNumber = (string)(x["CaseAccountNumber"] != DBNull.Value ? x["CaseAccountNumber"] : ""),
                CaseAccountName = (string)(x["CaseAccountName"] != DBNull.Value ? x["CaseAccountName"] : ""),
                ProductType = (string)(x["ProductType"] != DBNull.Value ? x["ProductType"] : ""),
                ProductId = (int)(x["ProductID"] != DBNull.Value ? x["ProductID"] : 0),
                PkgsChargeWt = (string)(x["PkgsChargeWt"] != DBNull.Value ? x["PkgsChargeWt"] : ""),


            }).ToList();

            return staticInv;
        }

        public static List<StaticCaseDetails> Consignment(DataTable dt)
        {
            List<StaticCaseDetails> staticConsignment = dt.AsEnumerable().Select(x => new StaticCaseDetails
            {
                CaseAccountNumber = (string)(x["AccountNo"] != DBNull.Value ? x["AccountNo"] : ""),
                CaseAccountName = (string)(x["AccountName"] != DBNull.Value ? x["AccountName"] : ""),
                PickupDate = (string)(x["PickupDate"] != DBNull.Value ? x["PickupDate"] : ""),
                DeliveryDate = (string)(x["Delivery Date"] != DBNull.Value ? x["Delivery Date"] : ""),
                DueDate = (string)(x["CommittedDeliveryDate"] != DBNull.Value ? x["CommittedDeliveryDate"] : ""),
                OriginBranch = (string)(x["Origin Branch"] != DBNull.Value ? x["Origin Branch"] : ""),
                DestinationBranch = (string)(x["Destination Branch"] != DBNull.Value ? x["Destination Branch"] : ""),
                CurrentBranch = (string)(x["Current Branch"] != DBNull.Value ? x["Current Branch"] : ""),
                Consignee = (string)(x["Consignee"] != DBNull.Value ? x["Consignee"] : ""),
                Consigner = (string)(x["Consignor"] != DBNull.Value ? x["Consignor"] : ""),
                ProductType = (string)(x["ProductType"] != DBNull.Value ? x["ProductType"] : ""),
                ProductId = (int)(x["ProductID"] != DBNull.Value ? x["ProductID"] : 0),
                PkgsChargeWt = (string)(x["Pkgs/ChargeWt"] != DBNull.Value ? x["Pkgs/ChargeWt"] : ""),


            }).ToList();

            return staticConsignment;
        }

        public static List<StaticCaseDetails> Pickup(DataTable dt)
        {
            List<StaticCaseDetails> staticPickup = dt.AsEnumerable().Select(x => new StaticCaseDetails
            {
                CaseAccountNumber = (string)(x["CustomerCode"] != DBNull.Value ? x["CustomerCode"] : ""),
                CaseAccountName = (string)(x["CustomerName"] != DBNull.Value ? x["CustomerName"] : ""),
                // PickupDate = Convert.ToString((DateTime)(x["PickupDate"] != DBNull.Value ? x["PickupDate"] : "")),
                PickupDate = (string)(x["PickupDate"] != DBNull.Value ? x["PickupDate"] : ""),
                OriginBranch = (string)(x["PickupBranch"] != DBNull.Value ? x["PickupBranch"] : ""),
                ProductType = (string)(x["ProductType"] != DBNull.Value ? x["ProductType"] : ""),
                ProductId = (int)(x["ProductId"] != DBNull.Value ? x["ProductId"] : 0),


            }).ToList();

            return staticPickup;
        }

        public static List<SpotonAccountDetails> AccountDetailsListToModel(DataTable dt)
        {
            return dt.AsEnumerable().Select(x => new SpotonAccountDetails
            {
                AccountName = (string)(x["AccountName"] != DBNull.Value ? x["AccountName"] : ""),
                AccountNumber = (string)(x["AccountNumber"] != DBNull.Value ? x["AccountNumber"] : ""),
                MobileNumber = (string)(x["MobileNumber"] != DBNull.Value ? x["MobileNumber"] : ""),
                Email = (string)(x["Email"] != DBNull.Value ? x["Email"] : ""),
                Region = (string)(x["Region"] != DBNull.Value ? x["Region"] : ""),
                Depot = (string)(x["Depot"] != DBNull.Value ? x["Depot"] : ""),
                Branch = (string)(x["Branch"] != DBNull.Value ? x["Branch"] : ""),
                CsAgent = (string)(x["CsAgent"] != DBNull.Value ? x["CsAgent"] : ""),
            }).ToList();
        }

        public static List<CommonListDetails> AccountNameListToModel(DataTable dt)
        {
            return dt.AsEnumerable().Select(x => new CommonListDetails
            {
                ItemID = Convert.ToInt32((x["ItemID"] != DBNull.Value ? x["ItemID"] : 0)),
                ItemName = (string)(x["ItemName"] != DBNull.Value ? x["ItemName"] : ""),
            }).ToList();
        }

        public static AccountInfo AccountTypesListToModel(DataTable dt)
        {
            return dt.AsEnumerable().Select(x => new AccountInfo
            {
                AccountName = (string)(x["AccountName"] != DBNull.Value ? x["AccountName"] : ""),
                AccountNumber = (string)(x["AccountNumber"] != DBNull.Value ? x["AccountNumber"] : ""),
                CustBranchCode = (string)(x["CustBranchCode"] != DBNull.Value ? x["CustBranchCode"] : ""),
                ParentAccount = (string)(x["ParentAccount"] != DBNull.Value ? x["ParentAccount"] : ""),
                ProductType = (string)(x["ProductType"] != DBNull.Value ? x["ProductType"] : ""),
                AccountForPickup = (string)(x["AccountForPickup"] != DBNull.Value ? (bool)x["AccountForPickup"] == true ? "Regular" : "One Time" : "")
            }).FirstOrDefault();
        }

        public static AccountCommunication CommunicationTypesListToModel(DataTable dt)
        {
            return dt.AsEnumerable().Select(x => new AccountCommunication
            {
                EmailId = (string)(x["EmailId"] != DBNull.Value ? x["EmailId"] : ""),
                MobileNumber = (string)(x["MobileNumber"] != DBNull.Value ? x["MobileNumber"] : ""),
                OtherPhone = (string)(x["OtherPhone"] != DBNull.Value ? x["OtherPhone"] : ""),
                Address = (string)(x["Address"] != DBNull.Value ? x["Address"] : ""),
                City = (string)(x["CITY"] != DBNull.Value ? x["CITY"] : ""),
                PinCode = (string)(x["PinCode"] != DBNull.Value ? x["PinCode"] : ""),
                State = (string)(x["State"] != DBNull.Value ? x["State"] : ""),
            }).FirstOrDefault();
        }

        public static List<ChildAccountDetails> ChildAccountDetailsListToModel(DataTable dt)
        {
            return dt.AsEnumerable().Select(x => new ChildAccountDetails
            {
                AccountNumber = (string)(x["AccountNumber"] != DBNull.Value ? x["AccountNumber"] : ""),
                AccountName = (string)(x["AccountName"] != DBNull.Value ? x["AccountName"] : ""),
            }).ToList();
        }

        public static AccountDetails AccountDetailListToModel(DataTable dt)
        {
            return dt.AsEnumerable().Select(x => new AccountDetails
            {
                //neh
                CategoryName = (string)(x["CategoryName"] != DBNull.Value ? x["CategoryName"] : ""),
                Category = (int)(x["Category"] != DBNull.Value ? x["Category"] : ""),
                CreditBillingTerm = (double)(x["CreditBillingTerm"] != DBNull.Value ? x["CreditBillingTerm"] : ""),
                FtcBillingTerm = (double)(x["FtcBillingTerm"] != DBNull.Value ? x["FtcBillingTerm"] : ""),
                CashCode = (string)(x["CashCode"] != DBNull.Value ? x["CashCode"] : ""),
                CustomerType = (string)(x["CustomerType"] != DBNull.Value ? x["CustomerType"] : ""),
                Territory = (string)(x["Territory"] != DBNull.Value ? x["Territory"] : ""),
                TerritoryManager = (string)(x["TerritoryManager"] != DBNull.Value ? x["TerritoryManager"] : ""),
                IndustryType = (string)(x["IndustryType"] != DBNull.Value ? x["IndustryType"] : ""),
                CsAgent = (string)(x["CsAgent"] != DBNull.Value ? x["CsAgent"] : "")
            }).FirstOrDefault();
        }

        public static List<AccountInfo> AccountContactsListToModel(DataTable dt)
        {
            return dt.AsEnumerable().Select(x => new AccountInfo
            {
                AccountNumber = (string)(x["AccountNumber"] != DBNull.Value ? x["AccountNumber"] : "")
            }).ToList();
        }

        public static List<CRMContactDetails> CustomerContactsListToModel(DataTable dt)
        {
            return dt.AsEnumerable().Select(x => new CRMContactDetails
            {
                ContPtmsptcd = (string)(x["ContPtmsptcd"] != DBNull.Value ? x["ContPtmsptcd"] : ""),
                ContPtmsptnm = (string)(x["ContPtmsptnm"] != DBNull.Value ? x["ContPtmsptnm"] : ""),
                ContJobTitle = (string)(x["ContJobTitle"] != DBNull.Value ? x["ContJobTitle"] : ""),
                ContBusinessPhone = (string)(x["ContBusinessPhone"] != DBNull.Value ? x["ContBusinessPhone"] : ""),
                FullName = (string)(x["FullName"] != DBNull.Value ? x["FullName"] : ""),
                ContMobileNumber = (string)(x["ContMobileNumber"] != DBNull.Value ? x["ContMobileNumber"] : ""),
                ContEmail = (string)(x["ContEmail"] != DBNull.Value ? x["ContEmail"] : ""),
                ContSource = (string)(x["ContSource"] != DBNull.Value ? x["ContSource"] : ""),
                ContId = (int)(x["ContId"] != DBNull.Value ? x["ContId"] : "")
            }).ToList();
        }

        public static List<CallDetails> ContactDetailsListToModel(DataTable dt)
        {
            return dt.AsEnumerable().Select(x => new CallDetails
            {
                AccountName = (string)(x["AccountName"] != DBNull.Value ? x["AccountName"] : ""),
                AccountNumber = (string)(x["AccountNumber"] != DBNull.Value ? x["AccountNumber"] : ""),
                MobileNumber = (string)(x["MobileNumber"] != DBNull.Value ? x["MobileNumber"] : ""),
                BusinessPhoneNumber = (string)(x["BusinessPhoneNumber"] != DBNull.Value ? x["BusinessPhoneNumber"] : ""),
                ContactPerson = (string)(x["ContactPerson"] != DBNull.Value ? x["ContactPerson"] : ""),
                Source = (string)(x["Source"] != DBNull.Value ? x["Source"] : ""),
            }).ToList();
        }

        public static CommonListDetails SupervisorDetailsListToModel(DataTable dt)
        {
            return dt.AsEnumerable().Select(x => new CommonListDetails
            {
                StrItemID = (string)(x["StrItemID"] != DBNull.Value ? x["StrItemID"] : ""),
                ItemName = (string)(x["ItemName"] != DBNull.Value ? x["ItemName"] : ""),

            }).FirstOrDefault();
        }

        public static CaseAccountDetails CaseAccountDetailsListToModel(DataTable dt)
        {
            return dt.AsEnumerable().Select(x => new CaseAccountDetails
            {
                AccountNumber = (string)(x["AccountNumber"] != DBNull.Value ? x["AccountNumber"] : ""),
                CustomerName = (string)(x["CustomerName"] != DBNull.Value ? x["CustomerName"] : ""),
                PickupDate = (DateTime)(x["PickupDate"] != DBNull.Value ? x["PickupDate"] : ""),
                DeliveryDate = (DateTime)(x["DeliveryDate"] != DBNull.Value ? x["DeliveryDate"] : ""),
                OriginBranch = (string)(x["OriginBranch"] != DBNull.Value ? x["OriginBranch"] : ""),
                DestinationBranch = (string)(x["DestinationBranch"] != DBNull.Value ? x["DestinationBranch"] : ""),
                CurrentBranch = (string)(x["CurrentBranch"] != DBNull.Value ? x["CurrentBranch"] : ""),
                Consignee = (string)(x["Consignee"] != DBNull.Value ? x["Consignee"] : ""),
                Consigner = (string)(x["Consigner"] != DBNull.Value ? x["Consigner"] : "")
            }).FirstOrDefault();
        }

        public static TTSAutoAssignDetails TTSAccountDetailsListToModel(DataTable dt)
        {
            return dt.AsEnumerable().Select(x => new TTSAutoAssignDetails
            {
                AccountCode = (string)(x["AccountCode"] != DBNull.Value ? x["AccountCode"] : ""),
                EmpCode = (string)(x["EmpCode"] != DBNull.Value ? x["EmpCode"] : ""),

            }).FirstOrDefault();
        }

        public static TTSAutoAssignDetails TTSAutoAssignDetailsListToModel(DataTable dt)
        {
            return dt.AsEnumerable().Select(x => new TTSAutoAssignDetails
            {
                EmpCode = (string)(x["EmpCode"] != DBNull.Value ? x["EmpCode"] : ""),

            }).FirstOrDefault();
        }

        public static TTSAutoAssignDetails PtMSAssignDetailsListToModel(DataTable dt)
        {
            return dt.AsEnumerable().Select(x => new TTSAutoAssignDetails
            {
                BRCD = (string)(x["Ptmsbrcd"] != DBNull.Value ? x["Ptmsbrcd"] : ""),

            }).FirstOrDefault();
        }

        public static List<ConStatusCodeDetails> StatusCodeDetailsListToModel(DataTable dt)
        {
            return dt.AsEnumerable().Select(x => new ConStatusCodeDetails
            {
                Autoid = (int)(x["autoid"] != DBNull.Value ? x["autoid"] : ""),
                Code = (string)(x["Code"] != DBNull.Value ? x["Code"] : ""),
                CodeDesc = (string)(x["CodeDesc"] != DBNull.Value ? x["CodeDesc"] : "")
            }).ToList();
        }

        public static List<TtsComplaintMainCategory> MainCategoryToModel(DataTable dt)
        {
            List<TtsComplaintMainCategory> data = dt.AsEnumerable().Select(x => new TtsComplaintMainCategory
            {
                ItemID = (int)(x["MainCategoryID"] != DBNull.Value ? x["MainCategoryID"] : ""),
                ItemName = (string)(x["Description"] != DBNull.Value ? x["Description"] : ""),
                IsActive = (bool)(x["isactive"] != DBNull.Value ? x["isactive"] : false)

            }).ToList();

            return data;
        }

        public static List<MemberGroupDetails> MemberGroupListToModel(DataTable dt)
        {
            List<MemberGroupDetails> data = dt.AsEnumerable().Select(x => new MemberGroupDetails
            {
                GroupID = (int)(x["GroupID"] != DBNull.Value ? x["GroupID"] : ""),
                GroupName = (string)(x["GroupName"] != DBNull.Value ? x["GroupName"] : ""),
                Description = (string)(x["Description"] != DBNull.Value ? x["Description"] : "")

            }).ToList();

            return data;
        }

        public static List<TTSAutoAssignDetails> TTSAccountListToModel(DataTable dt)
        {
            return dt.AsEnumerable().Select(x => new TTSAutoAssignDetails
            {
                AccountCode = (string)(x["AccountCode"] != DBNull.Value ? x["AccountCode"] : ""),
                EmpCode = (string)(x["EmpCode"] != DBNull.Value ? x["EmpCode"] : ""),

            }).ToList();
        }

        //public static List<BRMS> BrmsToModel(DataTable dt)
        //{
        //    List<BRMS> data = dt.AsEnumerable().Select(x => new BRMS
        //    {
        //        ItemID = (string)(x["BRCD"] != DBNull.Value ? x["BRCD"] : ""),
        //        ItemName = (string)(x["BRNM"] != DBNull.Value ? x["BRNM"] : ""),
        //    }).ToList();
        //    return data;
        //}

        public static List<BRMS> BrmsToModel(DataTable dt)
        {
            List<BRMS> data = dt.AsEnumerable().Select(x => new BRMS
            {
                ItemID = (string)(x["BRCD"] != DBNull.Value ? x["BRCD"] : ""),
                ItemName = (string)(x["BRNM"] != DBNull.Value ? x["BRNM"] : ""),
                RegionId = (string)(x["RGALPH"] != DBNull.Value ? x["RGALPH"] : ""),
                DepoCode = (string)(x["DEPOT_CODE"] != DBNull.Value ? x["DEPOT_CODE"] : ""),
            }).ToList();
            return data;
        }


        public static List<StatusDetails> StatusToModel(DataTable dt)
        {
            List<StatusDetails> data = dt.AsEnumerable().Select(x => new StatusDetails
            {
                StatusID = (int)(x["StatusID"] != DBNull.Value ? x["StatusID"] : 0),
                Name = (string)(x["Name"] != DBNull.Value ? x["Name"] : ""),
                Description = (string)(x["Description"] != DBNull.Value ? x["Description"] : ""),
            }).ToList();
            return data;
        }

        public static List<EmployeeDetail> ttsMemberToModel(DataTable dt)
        {
            List<EmployeeDetail> emp = dt.AsEnumerable().Select(x => new EmployeeDetail
            {
                EmployeeId = (string)(x["EmpCode"] != DBNull.Value ? x["EmpCode"] : ""),
                EmployeeName = (string)(x["EmpName"] != DBNull.Value ? x["EmpName"] : ""),

            }).ToList();

            return emp;
        }

        public static List<ConsignmentDestinationDetail> ConsignmentDestinationToModel(DataTable dt)
        {
            List<ConsignmentDestinationDetail> con = dt.AsEnumerable().Select(x => new ConsignmentDestinationDetail
            {
                DestinationDate = (DateTime)(x["ARRV_DT"] != DBNull.Value ? x["ARRV_DT"] : ""),
                Consignments = (string)(x["DOCKNO"] != DBNull.Value ? x["DOCKNO"] : ""),

            }).ToList();

            return con;
        }
        public static List<CrmTblRoleAssignment> RoleAssignmentToModel(DataTable dt)
        {
            List<CrmTblRoleAssignment> roleAssign = dt.AsEnumerable().Select(x => new CrmTblRoleAssignment
            {
                EMPCD = (string)(x["EMPCD"] != DBNull.Value ? x["EMPCD"] : ""),
                EmpSuperviserId = (string)(x["EmpSuperviserId"] != DBNull.Value ? x["EmpSuperviserId"] : ""),
                isDeleted = (bool)(x["IsDeleted"] != DBNull.Value ? x["IsDeleted"] : ""),
                GroupMasterId = (int)(x["GroupMasterID"] != DBNull.Value ? x["GroupMasterID"] : 0)
            }).ToList();

            return roleAssign;
        }

        public static List<TblDeptMst> TblDeptMstToModel(DataTable dt)
        {
            List<TblDeptMst> con = dt.AsEnumerable().Select(x => new TblDeptMst
            {
                DeptId = (int)(x["DeptID"] != DBNull.Value ? x["DeptID"] : 0),
                DeptName = (string)(x["Dept"] != DBNull.Value ? x["Dept"] : ""),

            }).ToList();

            return con;
        }

        public static List<TTSAutoAssignDetails> TTSAccountDetailsListsToModel(DataTable dt)
        {
            return dt.AsEnumerable().Select(x => new TTSAutoAssignDetails
            {
                AccountCode = (string)(x["AccountCode"] != DBNull.Value ? x["AccountCode"] : ""),
                EmpCode = (string)(x["EmpCode"] != DBNull.Value ? x["EmpCode"] : ""),

            }).ToList();
        }

        //public static List<TTSAutoAssignDetails> TTSAccountDetailsListsToModel(DataTable dt)
        //{
        //    return dt.AsEnumerable().Select(x => new TTSAutoAssignDetails
        //    {
        //        AccountCode = (string)(x["AccountCode"] != DBNull.Value ? x["AccountCode"] : ""),
        //        EmpCode = (string)(x["EmpCode"] != DBNull.Value ? x["EmpCode"] : ""),

        //    }).ToList();
        //}

        public static List<TTSAutoAssignDetails> PtMSAssignDetailsListsToModel(DataTable dt)
        {
            return dt.AsEnumerable().Select(x => new TTSAutoAssignDetails
            {
                BRCD = (string)(x["Ptmsbrcd"] != DBNull.Value ? x["Ptmsbrcd"] : ""),

            }).ToList();
        }

        public static List<CommonListDetails> Consignmentvalidation(DataTable dt)
        {
            List<CommonListDetails> con = dt.AsEnumerable().Select(x => new CommonListDetails
            {

                ItemName = (string)(x["Dockno"] != DBNull.Value ? x["Dockno"] : ""),

            }).ToList();

            return con;
        }

        public static List<CommonListDetails> Invoicevalidation(DataTable dt)
        {
            List<CommonListDetails> con = dt.AsEnumerable().Select(x => new CommonListDetails
            {

                ItemName = (string)(x["InvoiceNumber"] != DBNull.Value ? x["InvoiceNumber"] : ""),

            }).ToList();

            return con;
        }

        public static List<CommonListDetails> Pickupvalidation(DataTable dt)
        {
            List<CommonListDetails> con = dt.AsEnumerable().Select(x => new CommonListDetails
            {
                ItemName = (string)(x["REFNO"] != DBNull.Value ? x["REFNO"] : ""),

            }).ToList();

            return con;
        }
        public static List<StaticCaseDetails> MultipleOpening(DataTable dt)
        {
            List<StaticCaseDetails> staticConsignment = dt.AsEnumerable().Select(x => new StaticCaseDetails
            {
                CaseAccountNumber = (string)(x["AccountNo"] != DBNull.Value ? x["AccountNo"] : ""),
                CaseAccountName = (string)(x["AccountName"] != DBNull.Value ? x["AccountName"] : ""),
                CaseRefNumber = (string)(x["ConNumber"] != DBNull.Value ? x["ConNumber"] : ""),
                ProductId = (int)(x["ProductID"] != DBNull.Value ? x["ProductID"] : 0),

            }).ToList();

            return staticConsignment;
        }


        public static List<BackupAssignment> AgentPrimaryDetailsToModel(DataTable dt)
        {
            List<BackupAssignment> lstCommon = dt.AsEnumerable().Select(x => new BackupAssignment
            {
                AccountCode = (string)(x["Code"] != DBNull.Value ? x["Code"] : ""),
                Name = (string)(x["Name"] != DBNull.Value ? x["Name"] : ""),
                SubordinateId = (string)(x["EmpCode"] != DBNull.Value ? x["EmpCode"] : "")
            }).Distinct().ToList();

            return lstCommon;
        }

        #region esclation

        public static List<DeptLevelMaster> TblDeptLevelMstToModel(DataTable dt)
        {
            List<DeptLevelMaster> con = dt.AsEnumerable().Select(x => new DeptLevelMaster
            {
                AutoID = (int)(x["AutoID"] != DBNull.Value ? x["AutoID"] : 0),
                DeptID = (int)(x["DeptID"] != DBNull.Value ? x["DeptID"] : 0),
                BranchType = (string)(x["BranchType"] != DBNull.Value ? x["BranchType"] : ""),
                Level = (int)(x["Level"] != DBNull.Value ? x["Level"] : 0),
                Description = (string)(x["Description"] != DBNull.Value ? x["Description"] : ""),
                IsActive = (bool)(x["IsActive"] != DBNull.Value ? x["IsActive"] : ""),
                CreatedBy = (string)(x["CreatedBy"] != DBNull.Value ? x["CreatedBy"] : ""),
                CretedOn = (DateTime)(x["CreatedOn"] != DBNull.Value ? x["CreatedOn"] : ""),
                UpdatedBy = (string)(x["UpdatedBy"] != DBNull.Value ? x["UpdatedBy"] : "")
                // UpdatedOn = (DateTime)(x["UpdatedOn"] != DBNull.Value ? x["UpdatedOn"] : "")



            }).ToList();

            return con;
        }

        //public static List<CommonListDetails> EsclationBranchListToModel(DataTable dt)
        //{
        //    return dt.AsEnumerable().Select(x => new CommonListDetails
        //    {
        //        ItemID = Convert.ToInt32((x["BRCD"] != DBNull.Value ? x["BRCD"] : 0)),
        //        ItemName = (string)(x["ItemName"] != DBNull.Value ? x["ItemName"] : ""),
        //    }).ToList();
        //}

        public static List<EsclationEmpDetails> EsclationEmpDetail(DataTable dt)
        {
            List<EsclationEmpDetails> con = dt.AsEnumerable().Select(x => new EsclationEmpDetails
            {
                EmployeeCode = (string)(x["EMPCD"] != DBNull.Value ? x["EMPCD"] : ""),
                EmployeeName = (string)(x["EMPNM"] != DBNull.Value ? x["EMPNM"] : ""),
                ContactNumber = (string)(x["mobileno"] != DBNull.Value ? x["mobileno"] : ""),
                Branch = (string)(x["Branch"] != DBNull.Value ? x["Branch"] : ""),
                Level = (int)(x["Level"] != DBNull.Value ? x["Level"] : 0),
                Department = (string)(x["Dept"] != DBNull.Value ? x["Dept"] : ""),
                emailID = (string)(x["e_mailID"] != DBNull.Value ? x["e_mailID"] : ""),


            }).ToList();

            return con;
        }

        public static List<EsclationBranchDetail> EsclationBranch(DataTable dt)
        {

            return dt.AsEnumerable().Select(x => new EsclationBranchDetail
            {
                BranchCode = (string)(x["BRCD"] != DBNull.Value ? x["BRCD"] : ""),
                BranchName = (string)(x["BRNM"] != DBNull.Value ? x["BRNM"] : ""),
                BranchType = (string)(x["BranchType"] != DBNull.Value ? x["BranchType"] : ""),

            }).ToList();
        }

        public static List<CommonListDetails> EsclationReason(DataTable dt)
        {

            return dt.AsEnumerable().Select(x => new CommonListDetails
            {
                ItemID = Convert.ToInt32((x["AutoID"] != DBNull.Value ? x["AutoID"] : 0)),
                ItemName = (string)(x["ReasonCode"] != DBNull.Value ? x["ReasonCode"] : ""),
            }).ToList();
        }

        #endregion

        #region account types for reports
        public static List<CommonListDetails> AccountListToModel(DataTable dt)
        {
            List<CommonListDetails> lstCommon = dt.AsEnumerable().Select(x => new CommonListDetails
            {
                ItemID = (int)(x["AccountTypeId"] != DBNull.Value ? x["AccountTypeId"] : 0),
                ItemName = (string)(x["AccountType"] != DBNull.Value ? x["AccountType"] : ""),

            }).ToList();

            return lstCommon;
        }
        #endregion

        public static List<OnDemandReport> OnDemandReport(DataTable dt)
        {
            try
            {
                List<OnDemandReport> lstreport = dt.AsEnumerable().Select(x => new OnDemandReport
                {
                    CrmCaseNumber = (string)(x["CRM_CASE_NUMBER"] != DBNull.Value ? x["CRM_CASE_NUMBER"] : ""),
                    CaseAccountNumber = (string)(x["CASE_ACCOUNT_NUMBER"] != DBNull.Value ? x["CASE_ACCOUNT_NUMBER"] : ""),
                    ConNumber = (string)(x["ConNumber"] != DBNull.Value ? x["ConNumber"] : ""),
                    Consignee = (string)(x["Consignee"] != DBNull.Value ? x["Consignee"] : ""),
                    Consignor = (string)(x["Consignor"] != DBNull.Value ? x["Consignor"] : ""),
                    CaseType = (string)(x["CASE_TYPE"] != DBNull.Value ? x["CASE_TYPE"] : ""),
                    ComplaintSource = (string)(x["COMPLAINTSOURCE"] != DBNull.Value ? x["COMPLAINTSOURCE"] : ""),
                    DueDate = (DateTime?)(x["DueDate"] != DBNull.Value ? x["DueDate"] : (DateTime?)null),
                    DeliveryDate = (x["Delivery Date"] != DBNull.Value ? x["Delivery Date"].ToString() : ""),
                    OpStatusCode = (int)(x["OP_STATUS_CODE"] != DBNull.Value ? x["OP_STATUS_CODE"] : 0),
                    CaseMainCatId = (int)(x["CASE_MAIN_CAT_ID"] != DBNull.Value ? x["CASE_MAIN_CAT_ID"] : 0),
                    MainCategoryName = (string)(x["MainCategoryName"] != DBNull.Value ? x["MainCategoryName"] : ""),
                    CaseSubCatId = (int)(x["CASE_SUB_CAT_ID"] != DBNull.Value ? x["CASE_SUB_CAT_ID"] : 0),
                    SubCategoryName = (string)(x["SubCategoryName"] != DBNull.Value ? x["SubCategoryName"] : ""),
                    FailCatName = (string)(x["FAIL_CAT_NAME"] != DBNull.Value ? x["FAIL_CAT_NAME"] : ""),
                    PriMstName = (string)(x["PRI_MST_NAME"] != DBNull.Value ? x["PRI_MST_NAME"] : ""),
                    OriginBranch = (string)(x["Origin Branch"] != DBNull.Value ? x["Origin Branch"] : ""),
                    DestinationBranch = (string)(x["Destination Branch"] != DBNull.Value ? x["Destination Branch"] : ""),
                    StatusBranch = (string)(x["STATUS_BRANCH"] != DBNull.Value ? x["STATUS_BRANCH"] : ""),
                    StatusDate = (string)(x["STATUS_DATE"] != DBNull.Value ? x["STATUS_DATE"] : ""),
                    CaseAssignedTo = (string)(x["CASE_ASSIGNED_TO"] != DBNull.Value ? x["CASE_ASSIGNED_TO"] : ""),
                    AgentCode = (string)(x["AgentCode"] != DBNull.Value ? x["AgentCode"] : ""),
                    AgentName = (string)(x["AgentName"] != DBNull.Value ? x["AgentName"] : ""),
                    TlCode = (string)(x["TlCode"] != DBNull.Value ? x["TlCode"] : ""),
                    GroupName = (string)(x["GroupName"] != DBNull.Value ? x["GroupName"] : ""),
                    EmpSuperviserId = (string)(x["EmpSuperviserId"] != DBNull.Value ? x["EmpSuperviserId"] : ""),
                    AgeingBucket = (string)(x["Ageing bucket"] != DBNull.Value ? x["Ageing bucket"] : ""),
                    TimeSpentInHrs = (decimal)(x["TimeSpent_In_Hrs"] != DBNull.Value ? x["TimeSpent_In_Hrs"] : ""),
                    CreatedOn = (DateTime)(x["CREATEDON"] != DBNull.Value ? x["CREATEDON"] : ""),
                    ModifiedOn = (x["MODIFIEDON"] != DBNull.Value ? Convert.ToDateTime(x["MODIFIEDON"]).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : ""),
                    //ModifiedOn = (string)(x["MODIFIEDON"] != DBNull.Value ? x["MODIFIEDON"] : ""),
                    Level = (string)(x["Level"] != DBNull.Value ? x["Level"] : ""),
                    Dept = (string)(x["Dept"] != DBNull.Value ? x["Dept"] : ""),
                    StageName = (string)(x["STAGE_NAME"] != DBNull.Value ? x["STAGE_NAME"] : ""),
                    StatusReason = (string)(x["STATUS_REASON"] != DBNull.Value ? x["STATUS_REASON"] : ""),
                    IsAudited = (bool)(x["IS_AUDITED"] != DBNull.Value ? x["IS_AUDITED"] : ""),
                    Name = (string)(x["Name"] != DBNull.Value ? x["Name"] : ""),
                    Description = (string)(x["Description"] != DBNull.Value ? x["Description"] : ""),
                    SlaStatus = (string)(x["SLA STATUS"] != DBNull.Value ? x["SLA STATUS"] : ""),
                    Descriptionn = (string)(x["Description"] != DBNull.Value ? x["Description"] : ""),
                    ClosedBy = (string)(x["Closed By"] != DBNull.Value ? x["Closed By"] : "")
                }).ToList();
                return lstreport;
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public static List<PickupDetails> PickupListToModel(DataTable dt)
        {
            List<PickupDetails> lstCommon = dt.AsEnumerable().Select(x => new PickupDetails
            {
                Name = (string)(x["Type"] != DBNull.Value ? x["Type"] : ""),
                ODA = (int?)(x["ODA"] != DBNull.Value ? x["ODA"] : 0),
                STD = (int?)(x["STD"] != DBNull.Value ? x["STD"] : 0),
                CS = (int?)(x["Source_CS"] != DBNull.Value ? x["Source_CS"] : 0),
                System = (int?)(x["Source_Others"] != DBNull.Value ? x["Source_Others"] : 0),
                North = (int?)(x["NORTH"] != DBNull.Value ? x["NORTH"] : 0),
                South = (int?)(x["SOUTH"] != DBNull.Value ? x["SOUTH"] : 0),
                West = (int?)(x["WEST"] != DBNull.Value ? x["WEST"] : 0),
                East = (int?)(x["EAST"] != DBNull.Value ? x["EAST"] : 0),
            }).ToList();

            return lstCommon;
        }


        public static List<ConMovementDetails> ConMovementsToModel(DataTable dt)
        {
            List<ConMovementDetails> lstCommon = dt.AsEnumerable().Select(x => new ConMovementDetails
            {
                Name = (string)(x["DocStatus"] != DBNull.Value ? x["DocStatus"] : ""),
                Total = (int)(x["ConMovementTotal"] != DBNull.Value ? x["ConMovementTotal"] : 0),
                Crossed = (int?)(x["Date Crossed"] != DBNull.Value ? x["Date Crossed"] : 0),
                NotCrossed = (int?)(x["Date Not Crossed"] != DBNull.Value ? x["Date Not Crossed"] : 0),
                Air = (int?)(x["ProdAR"] != DBNull.Value ? x["ProdAR"] : 0),
                Surface = (int?)(x["ProdSR"] != DBNull.Value ? x["ProdSR"] : 0),
            }).ToList();

            return lstCommon;
        }

        public static List<ConMovements> ConMovementsDetailsToModel(DataTable dt)
        {
            List<ConMovements> lstCommon = dt.AsEnumerable().Select(x => new ConMovements
            {
                DockNo = (string)(x["DockNo"] != DBNull.Value ? x["DockNo"] : ""),
                Origin = (string)(x["Origin"] != DBNull.Value ? x["Origin"] : ""),
                Destination = (string)(x["Destination"] != DBNull.Value ? x["Destination"] : ""),
                CurrentLocation = (string)(x["CurrentLocation"] != DBNull.Value ? x["CurrentLocation"] : ""),
                BookingDate = (x["BookingDate"] != DBNull.Value ? Convert.ToDateTime(x["BookingDate"]).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : ""),
                DueDate = (x["DueDate"] != DBNull.Value ? Convert.ToDateTime(x["DueDate"]).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : ""),
                AccountCode = (string)(x["AccountCode"] != DBNull.Value ? x["AccountCode"] : ""),
                CSAgent = (string)(x["CSAgent"] != DBNull.Value ? x["CSAgent"] : ""),
                Wt_Pcs = (string)(x["Wt_Pcs"] != DBNull.Value ? x["Wt_Pcs"] : ""),
                LatestStatusCode = (string)(x["LatestStatusCode"] != DBNull.Value ? x["LatestStatusCode"] : ""),
                ProductType = (string)(x["ProductType"] != DBNull.Value ? x["ProductType"] : ""),
                DocStatus = (string)(x["DocStatus"] != DBNull.Value ? x["DocStatus"] : ""),
            }).ToList();

            return lstCommon;
        }

        public static List<PickupStatusDetails> PickupStatusDetailsToModel(DataTable dt)
        {
            List<PickupStatusDetails> lstCommon = dt.AsEnumerable().Select(x => new PickupStatusDetails
            {
                AccountCode = (string)(x["AccountCode"] != DBNull.Value ? x["AccountCode"] : ""),
                CSAgent = (string)(x["CSAgent"] != DBNull.Value ? x["CSAgent"] : ""),
                IsODA = (bool)(x["IsODA"] != DBNull.Value ? x["IsODA"] : ""),
                OrderNo = (string)(x["OrderNo"] != DBNull.Value ? x["OrderNo"] : ""),
                PickupDate = (x["PickupDate"] != DBNull.Value ? Convert.ToDateTime(x["PickupDate"]).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : ""),
                PickupRegion = (string)(x["PickupRegion"] != DBNull.Value ? x["PickupRegion"] : ""),
                Weight = (decimal)(x["Weight"] != DBNull.Value ? x["Weight"] : 0.0),
                RegSource = (string)(x["RegSource"] != DBNull.Value ? x["RegSource"] : ""),
                PType = (string)(x["PType"] != DBNull.Value ? x["PType"] : ""),
            }).ToList();

            return lstCommon;
        }

        #region region and depo details for reports
        public static List<CommonListDetails> RegionListToModel(DataTable dt)
        {
            List<CommonListDetails> lstCommon = dt.AsEnumerable().Select(x => new CommonListDetails
            {
                StrItemID = (string)(x["Region"] != DBNull.Value ? x["Region"] : 0),
                ItemName = (string)(x["RegionName"] != DBNull.Value ? x["RegionName"] : ""),

            }).ToList();

            return lstCommon;
        }

        public static List<CommonListDetails> DepoListToModel(DataTable dt)
        {
            List<CommonListDetails> lstCommon = dt.AsEnumerable().Select(x => new CommonListDetails
            {
                StrItemID = (string)(x["DepoCode"] != DBNull.Value ? x["DepoCode"] : 0),
                ItemName = (string)(x["Description"] != DBNull.Value ? x["Description"] : ""),

            }).ToList();

            return lstCommon;
        }
        #endregion

    }
}
