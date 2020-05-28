using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace SpotonServices.Controllers
{
    public class DataAccess : IDisposable
    {
        string strConn = "Server=10.109.231.32;Database=ESTL_CRP2;user id=sa;password=password@123;MultipleActiveResultSets=true;Max Pool Size=1000;Timeout=120";
        string strConnCrm = "Server=10.109.231.32;Database=CRMDEV;user id=sa;password=password@123;MultipleActiveResultSets=true;Max Pool Size=1000;Timeout=120";
        SqlCommand cmd = null;
        SqlDataAdapter da = null;

        private DataTable Execute(string query)
        {
            SqlConnection con = null;
            try
            {
                DataTable dataTable = new DataTable();
                con = new SqlConnection(strConn);
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
                con.Close();
                return dataTable;
            }
            finally
            {
                con.Dispose();
            }
        }

        private DataTable ExecuteCrm(string query)
        {
            SqlConnection con = null;
            try
            {
                DataTable dataTable = new DataTable();
                con = new SqlConnection(strConnCrm);
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
                con.Close();
                return dataTable;
            }
            finally
            {
                con.Dispose();
            }
        }

        public void Dispose()
        {
            da.Dispose();
            cmd.Dispose();
        }

        public DataTable CrmTblRoleAssignment()
        {
            DataTable roleAssignment = null;
            string query = "select EMPCD , EmpSuperviserId, IsDeleted, GroupMasterID FROM TblCrmuserRoleAssignmentDtl WITH (NOLOCK)";
            roleAssignment = ExecuteCrm(query);
            return roleAssignment;
        }
        public DataTable UserList(string loggedInUser)
        {
            DataTable userList = null;

            string query = "SELECT  distinct [a].[EmailID], [a].[EmpCode] AS [EmployeeId], [a].[EmpName] AS [EmployeeName], " +
                            " [ttsgroup].[Description], [ttsgroup].[GroupName] AS[SubGroup], [empMaster].[ManagerEmpCd] AS[SupervisorId], [empMaster].[DEPT] AS[Department]," +
                            "[s].[EmpName] as SupervisorName FROM[TTS_Member] AS[a] with(nolock) INNER JOIN[EMPMST] AS[empMaster] with(nolock) ON[a].[EmpCode] = [empMaster].[EMPCD]" +
                            "LEFT JOIN[TTS_Group] AS[ttsgroup] with(nolock) ON[a].[GroupID] = [ttsgroup].[GroupID]" +
                           " inner join TTS_Member as [s] with(nolock) on empMaster.ManagerEmpCd=[s].EmpCode WHERE [a].[IsActive] = 1";


            userList = Execute(query);
            return userList;
        }
        public DataTable EmployeeDetails()
        {
            DataTable EmployeeDetails = null;

            string query = "select EmpCode , EmpName, EmailID, GroupID from TTS_Member with (nolock) where isactive = 1";
            EmployeeDetails = Execute(query);
            return EmployeeDetails;
        }

        public DataTable GetEmpMst()
        {
            DataTable EmployeeDetails = null;

            string query = "select EMPCD , EMPNM, ActiveFlag, ManagerEmpCd, DEPT,e_mailID FROM EMPMST WITH (NOLOCK)";
            EmployeeDetails = Execute(query);
            return EmployeeDetails;
        }
        public DataTable GetComplaintSource()
        {
            DataTable EmployeeDetails = null;

            string query = "SELECT * FROM tts_ComplaintSource with (nolock) where isactive =1";
            EmployeeDetails = Execute(query);
            return EmployeeDetails;
        }
        public DataTable GetWIPStatus()
        {
            DataTable EmployeeDetails = null;

            string query = "SELECT Statusid , Name , [Description] ,Mode  FROM TTS_WIP_StatusMaster with (nolock) where isactive=1 ";
            EmployeeDetails = Execute(query);
            return EmployeeDetails;
        }

        public DataTable GetOperationsUtyMst()
        {
            DataTable EmployeeDetails = null;

            string query = "select OperationsUtyID , Code, OpCode,[Description], isreminderdate, IsTTSStatus   from tblOperationsUtyMst with (nolock) where isactive=1 ";
            EmployeeDetails = Execute(query);
            return EmployeeDetails;
        }

        public DataTable GetTTSCategory()
        {
            DataTable EmployeeDetails = null;

            string query = "SELECT CategoryID , CategoryName, [Description], MainCategoryID , CloseCat , ParentID, [Priority], IsActive,CRM_FailureSLA FROM TTS_Category with (nolock) where isactive =1";
            EmployeeDetails = Execute(query);
            return EmployeeDetails;
        }

        public DataTable GetInvoiceDetail(string invoiceNo)
        {
            DataTable invoice = null;
            string query = "SELECT TOP 1 [pcust].[ptmsptcd] AS [CaseAccountNumber], [pcust].[PCUSTNAME] AS [CaseAccountName], " +
                             "CASE WHEN([d].[ProductID] <> 2) OR[d].[ProductID] IS NULL " +
                            "THEN N'Surface' ELSE N'Air' END AS[ProductType], [d].[ProductID], (CONVERT(nvarchar(max), [d].[PKGSNO]) + N'/') + CONVERT(nvarchar(max), [d].[CHRGWT]) AS[PkgsChargeWt]" +
                            "FROM[tblInvoice] AS[inv] with (nolock) INNER JOIN[PCUST_MAIN] AS[pcust] with (nolock) ON[inv].[PTMSPTCD] = [pcust].[ptmsptcd]" +
                            "INNER JOIN[tblInvoiceConMap] AS[ic] with (nolock) ON[inv].[InvoiceId] = [ic].[InvoiceId]" +
                            "INNER JOIN[DOCKET] AS[d] with (nolock) ON[ic].[DocketNumber] = [d].[DOCKNO]" +
                            "WHERE[inv].[InvoiceNumber] =" + invoiceNo;
            invoice = Execute(query);
            return invoice;
        }

        public DataTable GetConsignmentDetail(string consignNo)
        {
            DataTable consignment = null;
            string query = "SELECT  RTRIM(B.DOCKNO)[ConNumber] ,CASE WHEN B.PAYBAS = '3' THEN B.CSGECD ELSE B.CSGNCD END[AccountNo]," +
                            " CASE WHEN B.PAYBAS = '3' THEN B.CSGENM ELSE B.CSGNNM END[AccountName], CONVERT(VARCHAR(10), B.DOCKDT, 105) as [PickupDate] ,CONVERT(VARCHAR(10), B.CDELDT, 105) as [CommittedDeliveryDate] ," +
                            " B.CSGNCD + '-' + B.CSGNNM[Consignee] ,B.CSGECD + '-' + B.CSGENM[Consignor] ,B.PKGSNO AS[PACKAGES],B.DOC_CURLOC + '-' + CBR.BRNM[Current Branch] ," +
                            " OBR.BRCD + '-' + OBR.BRNM[Origin Branch] ,DBR.BRCD + '-' + DBR.BRNM[Destination Branch] ,ISNULL(CONVERT(VARCHAR(10), DD.DELY_DT, 105) + ' '" +
                            " + CONVERT(VARCHAR(5), DD.DELY_DT, 108), '')[Delivery Date] ,CASE WHEN B.ProductID = '2' THEN 'Air' ELSE 'Surface' " +
                            " END[ProductType] ,[ProductID],CONVERT(VARCHAR(10), B.PKGSNO) + ' / ' + CONVERT(VARCHAR(10), B.CHRGWT) [Pkgs/ChargeWt]" +
                            " FROM dbo.DOCKET B WITH (NOLOCK ) INNER JOIN dbo.brms OBR WITH (NOLOCK ) ON B.ORGNCD = OBR.BRCD " +
                            " INNER JOIN dbo.brms DBR WITH (NOLOCK ) ON B.DESTCD = DBR.BRCD INNER JOIN dbo.brms CBR WITH (NOLOCK ) ON B.DOC_CURLOC = CBR.BRCD " +
                            " LEFT OUTER JOIN dbo.DKT_DELY DD WITH (NOLOCK ) ON DD.DOCKNO = B.DOCKNO WHERE B.DOCKNO = " + consignNo;

            consignment = Execute(query);
            return consignment;
        }

        public DataTable GetPickupDetail(string pickupNo)
        {
            DataTable pickup = null;
            string query = "SELECT TOP 1 A.refno[Pickup Order No],CONVERT(VARCHAR(10), sh.ScheduleDate, 105) AS PickupDate," +
                            " A.ptcd AS CustomerCode , A.ptnm AS CustomerName ,  PAD.BRCD + '-' + br.BRNM AS PickupBranch,CASE WHEN a.ProductTypeID = '2' " +
                            " THEN 'Air' ELSE 'Surface' END[ProductType],[ProductTypeID] AS[ProductId] FROM(SELECT TOP 1 REFNO , PickupscheduleID " +
                            " FROM Pickup_Schedule A WITH (NOLOCK ) WHERE REFNO = '" + pickupNo + "' AND ScheduleDate <= (REPLACE(CONVERT(VARCHAR(10), GETDATE(), 111),'/', '-') + ' 23:59:00' )" +
                            " ORDER BY  ScheduleDate DESC) S INNER JOIN Pickup_Schedule sh WITH(NOLOCK ) ON sh.PickupscheduleID = S.PickupscheduleID " +
                            " INNER JOIN PICKUP_AUTHO A WITH (NOLOCK ) ON A.refno = S.REFNO LEFT JOIN CRMPickUpAddress PAD WITH (NOLOCK ) ON PAD.REFNO = S.REFNO " +
                            " INNER JOIN dbo.brms br WITH(NOLOCK) ON br.BRCD= pad.BRCD";


            pickup = Execute(query);
            return pickup;
        }

        public DataTable GetAccountDetailsByNameOrId(string accountCodeOrName)
        {
            //string query = "SELECT[P].[PTMSPTNM] AS [AccountName], [P].[PTMSPTCD] AS [AccountNumber], [P].[PTMSPTEL] AS [MobileNumber], [P].[PTMSEMAIL] AS [Email], " +
            //               "[B].[RGALPH] AS [Region], [B].[DEPOT_CODE] AS [Depot], [B].[BRNM] As [Branch], [E].[EMPNM] AS [CsAgent]" +
            //               "FROM[ESTL_CRP2].[dbo].[ptms] AS[P] WITH(NOLOCK) INNER JOIN[ESTL_CRP2].[dbo].[brms] AS[B] WITH(NOLOCK ) ON[P].[PTMSBRCD] = [B].[BRCD]" +
            //               "INNER JOIN[ESTL_CRP2].[dbo].[TTS_AutoAssign] AS[T] WITH(NOLOCK ) ON[P].[PTMSPTCD] = [T].[AccountCode] INNER JOIN[ESTL_CRP2].[dbo].[EMPMST]" +
            //               "AS[E] WITH(NOLOCK ) ON[T].[EmpCode] = [E].[EMPCD] WHERE [P].[PTMSPTCD] = '" + accountCodeOrName + "' OR[P].[PTMSPTNM] LIKE '%" + accountCodeOrName + "%'";

            string query = "SELECT[P].[PTMSPTNM] AS [AccountName], [P].[PTMSPTCD] AS [AccountNumber], [P].[PTMSPTEL] AS [MobileNumber], [P].[PTMSEMAIL] AS [Email], " +
                          "[B].[RGALPH] AS [Region], [B].[DEPOT_CODE] AS [Depot], [B].[BRNM] As [Branch], vb.EMPNAME AS [CsAgent]" +
                          "FROM[ESTL_CRP2].[dbo].[ptms] AS[P] WITH(NOLOCK) INNER JOIN[ESTL_CRP2].[dbo].[brms] AS[B] WITH(NOLOCK ) ON[P].[PTMSBRCD] = [B].[BRCD]" +
                          "CROSS APPLY dbo.UFN_GET_CSAGENTCODE_CUSTCODE(p.PTMSPTCD) vb" +
                          " WHERE [P].[PTMSPTCD] = '" + accountCodeOrName + "' OR[P].[PTMSPTNM] LIKE '%" + accountCodeOrName + "%'";


            return Execute(query);
        }

        public DataTable GetAccountNames()
        {
            return Execute("SELECT DISTINCT [P].[PTMSPTNM] AS [ItemName], [P].[PTMSPTCD] AS [ItemID] FROM [ESTL_CRP2].[dbo].[ptms] AS[P] WITH(NOLOCK)");
        }

        public DataTable GetAccountTypesByAccount(string accountCode)
        {
            string query = "SELECT TOP 1[PT].PTMSPTNM AS[AccountName], [PT].PTMSPTCD AS[AccountNumber], [PT].[PTMSBRCD] AS[CustBranchCode], [PT].[parentptmsptcd] AS[ParentAccount]," +
                           "[PT].[PType] AS[ProductType], (SELECT TOP 1 [P].[IsRecurring] FROM [ESTL_CRP2].[dbo].[PICKUP_AUTHO] AS[P] WITH(NOLOCK) WHERE[P].[PTCD] = '" + accountCode + "') AS[AccountForPickup]" +
                           "FROM[ESTL_CRP2].[dbo].[ptms] AS[PT] WITH(NOLOCK) WHERE[PT].[PTMSPTCD] =  '" + accountCode + "'";

            return Execute(query);
        }

        public DataTable GetCommunicationDetailsByAccount(string accountCode)
        {
            string query = "SELECT [PT].[PTMSEMAIL] AS [EmailId], [PT].[PTMSPTEL] AS [MobileNumber], [PT].[PTMSTELS] AS [OtherPhone], [PT].[PTMSADDRESS] AS [Address]," +
                           "[PT].[PTMSCITY] AS [CITY], [PT].[PTMSPIN] AS [PinCode], [S].AreaName AS [State] FROM [ESTL_CRP2].[dbo].[ptms] AS[PT] WITH(NOLOCK)" +
                           "INNER JOIN[ESTL_CRP2].[dbo].[brms] AS[B] WITH(NOLOCK ) ON[PT].[PTMSBRCD] = [B].[BRCD] INNER JOIN[ESTL_CRP2].[dbo].[tblCityMst] AS[C] WITH(NOLOCK ) ON[B].[BRCITYID] = [C].[CityID]" +
                            "INNER JOIN[ESTL_CRP2].[dbo].[tblStateAreaMst] AS[S] WITH(NOLOCK ) ON[B].[AreaID] = [S].AreaID WHERE[PT].[PTMSPTCD] = '" + accountCode + "'";

            return Execute(query);
        }

        public DataTable GetChildAccountDetailsByAccount(string accountCode)
        {
            return Execute("SELECT [P].[PTMSPTCD] AS [AccountNumber], [P].[PTMSPTNM] AS [AccountName] FROM [ESTL_CRP2].[dbo].[ptms] AS [P] WITH(NOLOCK) WHERE [P].parentptmsptcd = '" + accountCode + "'");
        }

        public DataTable GetAccountDetailsByAccount(string accountCode)
        {
            //string query = "SELECT TOP 1[PM].[AccountTypeID] AS[Category], [PM].[TBBCRDAYS] AS[CreditBillingTerm], [PM].[TOPAYCRDAYS] AS[FtcBillingTerm]," +
            //               "[P].[CCashAc] AS[CashCode], [T].[EmpCode] AS[CustomerType], [S].[saleTerritory] AS[Territory], [E].[EMPNM] AS[TerritoryManager]," +
            //               "[SIC].[SIC] AS[IndustryType], [EMP].[EMPNM] AS[CsAgent] FROM[ESTL_CRP2].[dbo].[PCUST_MAIN] AS[PM] WITH(NOLOCK)" +
            //               "INNER JOIN[ESTL_CRP2].[dbo].[ptms] AS[P] WITH(NOLOCK) ON[PM].[PTMSPTCD] = [P].[PTMSPTCD] INNER JOIN [ESTL_CRP2].[dbo].[tblsaleTerritoryMst] AS[S] WITH(NOLOCK) ON[PM].saleTerritoryId = [S].[saleTerritoryId]" +
            //               "INNER JOIN[ESTL_CRP2].[dbo].[EMPMST] AS[E] WITH(NOLOCK) ON[PM].saleTerritoryMangerID = [E].EMPCD INNER JOIN [ESTL_CRP2].[dbo].[tblSicMst] AS[SIC] WITH(NOLOCK) ON[PM].SICID = [SIC].sicid INNER JOIN[ESTL_CRP2].[dbo].[TTS_AutoAssign] AS[T] WITH(NOLOCK) ON[P].[PTMSPTCD] = [T].[AccountCode]" +
            //               "INNER JOIN[ESTL_CRP2].[dbo].[EMPMST] AS[EMP] WITH(NOLOCK) ON T.EmpCode = [EMP].EMPCD WHERE [P].[PTMSPTCD] = '" + accountCode + "'";


            string query = "SELECT TOP 1 ACCTY.AccountType AS [CategoryName],[PM].[AccountTypeID] AS[Category], [PM].[TBBCRDAYS] AS[CreditBillingTerm], [PM].[TOPAYCRDAYS] AS[FtcBillingTerm]," +
                           "[P].[CCashAc] AS[CashCode], [T].[EmpCode] AS[CustomerType], [S].[saleTerritory] AS[Territory], [E].[EMPNM] AS[TerritoryManager]," +
                           "[SIC].[SIC] AS[IndustryType], [EMP].[EMPNM] AS[CsAgent] FROM[ESTL_CRP2].[dbo].[PCUST_MAIN] AS[PM] WITH(NOLOCK)" +
                           "INNER JOIN[ESTL_CRP2].[dbo].[ptms] AS[P] WITH(NOLOCK) ON[PM].[PTMSPTCD] = [P].[PTMSPTCD] INNER JOIN [ESTL_CRP2].[dbo].[tblsaleTerritoryMst] AS[S] WITH(NOLOCK) ON[PM].saleTerritoryId = [S].[saleTerritoryId]" +
                           "INNER JOIN[ESTL_CRP2].[dbo].[EMPMST] AS[E] WITH(NOLOCK) ON[PM].saleTerritoryMangerID = [E].EMPCD INNER JOIN [ESTL_CRP2].[dbo].[tblSicMst] AS[SIC] WITH(NOLOCK) ON[PM].SICID = [SIC].sicid INNER JOIN[ESTL_CRP2].[dbo].[TTS_AutoAssign] AS[T] WITH(NOLOCK) ON[P].[PTMSPTCD] = [T].[AccountCode]" +
                           "INNER JOIN[ESTL_CRP2].[dbo].[EMPMST] AS[EMP] WITH(NOLOCK) ON T.EmpCode = [EMP].EMPCD " +
                           "INNER JOIN [ESTL_CRP2].[dbo].tblAccountTypeMst AS [ACCTY] WITH(NOLOCK) ON ACCTY.AccountTypeID = PM.AccountTypeID WHERE [P].[PTMSPTCD] = '" + accountCode + "'";
            return Execute(query);
        }

        public DataTable GetAccountNumbersByCode(string accountCode)
        {
            string query = "SELECT [P].[PTMSPTCD] AS [AccountNumber] FROM [ESTL_CRP2].[dbo].[ptms] AS [P] WITH(NOLOCK) WHERE [P].[PTMSPTCD] = '" + accountCode + "'";

            return Execute(query);
        }

        public bool GetDocketNumberByRefType(string refNumber)
        {
            string query = "select Dockno from dbo.docket with(nolock) where Dockno = " + refNumber + "";

            DataTable dt = Execute(query);

            if (dt != null)
                return dt.Rows.Count == 0 ? false : true;

            return false;
        }

        public bool GetPickupRefNoByRefType(string refNumber)
        {
            string query = "select REFNO from dbo.pickup_schedule with(nolock) where REFNO ='" + refNumber + "'";

            DataTable dt = Execute(query);

            if (dt != null)
                return dt.Rows.Count == 0 ? false : true;

            return false;
        }

        public bool GetInvoiceNoByRefType(string refNumber)
        {
            string query = "select InvoiceNumber from dbo.TblInvoice with(nolock) where InvoiceNumber = " + refNumber + "";

            DataTable dt = Execute(query);

            if (dt != null)
                return dt.Rows.Count == 0 ? false : true;

            return false;
        }

        public bool GetPtmsRefNoByRefType(string refNumber)
        {
            string query = "select Ptmsptcd from dbo.Ptms with(nolock) where Ptmsptcd = " + refNumber + "";

            DataTable dt = Execute(query);

            if (dt != null)
                return dt.Rows.Count == 0 ? false : true;

            return false;
        }

        public DataTable GetCustomerContactDetails(string codeorName)
        {
            string query = "SELECT  PT.PTMSPTCD ContPtmsptcd , PT.PTMSPTNM ContPtmsptnm , ISNULL(PC.Designation,'') ContJobTitle , ISNULL(PC.PhoneNo,'') ContBusinessPhone , ISNULL(PC.ContactPersonname,'') FullName , " +
                           "ISNULL(PC.MobileNo ,'')ContMobileNumber , ISNULL(PC.emailID,'') ContEmail , 'TSM' ContSource , PC.PCUSTContactPersonID ContId FROM dbo.tbltsm_PCUST_CONTACTPERSON PC WITH ( NOLOCK ) " +
                           "INNER JOIN dbo.pcust_main PM WITH ( NOLOCK ) ON PC.PCUSTNO = PM.PCUSTNO INNER JOIN dbo.ptms PT WITH ( NOLOCK ) ON PM.ptmsptcd = PT.PTMSPTCD WHERE " +
                           " PT.PTMSPTCD = '" + codeorName + "' or pt.PTMSPTNM LIKE '%" + codeorName + "%'";

            return Execute(query);
        }

        public DataTable GetContactDetailsByNumber(string number)
        {
            string query = "SELECT[PC].[ContactPersonname] AS[AccountName], [PC].[PCUSTNO] AS[AccountNumber], [PC].[MobileNo] AS[MobileNumber]," +
                           "[PC].[PhoneNo] AS[BusinessPhoneNumber],[PC].[ContactPersonname] AS[ContactPerson], 'SpotOn' AS[Source]" +
                           "FROM[dbo].[PCUST_CONTACTPERSON] PC with(nolock) WHERE(PC.MobileNo = '" + number + "' OR PC.PhoneNo = '" + number + "') AND(PC.IsActive = 1)";

            return Execute(query);
        }

        public DataTable GetContactBySupervisorID(string superId)
        {
            string query = "SELECT DISTINCT[TM].[EmpCode] AS[StrItemID] ,[TM].[EmpName] AS[ItemName] FROM[ESTL_CRP2].[dbo].[TTS_Member]  TM with(nolock)" +
                           "WHERE TM.IsActive = 1 and[TM].[EmpCode] = '" + superId + "'";

            return Execute(query);
        }

        public DataTable GetConsignmentDetailsByRefNo(string refNo)
        {
            string query = "SELECT TOP 1 (CASE WHEN CON.PAYBAS = '3' THEN CON.CSGECD ELSE CON.CSGNCD END) AS AccountNumber, (CASE WHEN CON.PAYBAS = '3' THEN CON.CSGENM ELSE CON.CSGNNM END) as CustomerName," +
                           "CON.DOCKDT AS[PickupDate], CON.CDELDT AS[DeliveryDate], BR.BRNM AS[OriginBranch], " +
                           "BR1.BRNM AS[DestinationBranch], B2.BRNM AS[CurrentBranch], CON.CSGNNM AS[Consignee], CON.CSGENM AS[Consigner] " +
                           "FROM[dbo].[DOCKET] AS CON with(nolock) INNER JOIN[dbo].[brms] AS BR  with(nolock) " +
                           "ON CON.ORGNCD = BR.BRCD INNER JOIN[dbo].[brms] AS BR1  with(nolock) ON CON.DESTCD = BR1.BRCD " +
                           "INNER JOIN [dbo].[brms] AS B2  with(nolock) ON CON.DOC_CURLOC = B2.BRCD WHERE CON.DOCKNO = '" + refNo + "'";

            return Execute(query);
        }

        public DataTable GetTTSAutoAssignBasedOnAccount(string AccountCode)
        {
            string query = "select AccountCode , EmpCode  from Tts_AutoAssign with(nolock) where isactive =1 and  accountcode='" + AccountCode + "'";
            return Execute(query);
        }

        public DataTable GetTTSAutoAssignBasedOnBranch(string BranchCode)
        {
            string query = "select AccountCode, EmpCode  from Tts_AutoAssign with(nolock) where isactive =1 and  Brcd='" + BranchCode + "'";
            return Execute(query);
        }


        public DataTable GetptmsAcntcode(string AccountCode)
        {
            string query = "select Ptmsbrcd from Ptms WITH (NOLOCK) where Ptmsptcd='" + AccountCode + "'";
            return Execute(query);
        }

        public DataTable GetConTopStatusCodeDetails()
        {
            string query = "select autoid , Code, CodeDesc  from [dbo].[TTS_ConTopStatusCodeMaster] WITH (NOLOCK)";

            return Execute(query);
        }

        public DataTable GetTtsComplaintMainCategory()
        {
            string query = "select MainCategoryId, [Description], isactive from tts_ComplaintMainCategory WITH (NOLOCK)";

            return Execute(query);
        }

        public DataTable GetBranchDetails()
        {
            string query = "SELECT [B].BRCD, [B].BRNM FROM [dbo].[brms] AS [B] WITH (NOLOCK)";

            return Execute(query);
        }

        public DataTable GetTTSMemberGroupDetails()
        {
            string query = "select[TG].GroupID, [TG].GroupName, [TG].[Description] from[dbo].[TTS_Group] as [TG] with(nolock) where isActiv = 1";
            return Execute(query);
        }

        public DataTable GetTTSAutoAssignDetails()
        {
            string query = "select AccountCode , EmpCode  from Tts_AutoAssign with(nolock) where isactive =1 ";
            return Execute(query);
        }

        //public DataTable GetBranchDetail()
        //{
        //    string query = "select BRCD,BRNM from Brms WITH (NOLOCK)";

        //    return Execute(query);
        //}

        public DataTable GetBranchDetail()
        {
            string query = "select BRCD, BRNM, RGALPH, DEPOT_CODE from Brms WITH (NOLOCK)";

            return Execute(query);
        }

        public DataTable GeTTSStatusDetail()
        {
            string query = "SELECT T.StatusID, T.Name, T.Description FROM [dbo].[TTS_Status] AS[T] with (nolock)";

            return Execute(query);
        }

        public DataTable ttsMember()
        {
            DataTable ttsMember = null;
            string query = "select distinct EmpCode , EmpName from TTS_Member with (nolock) where isactive = 1";
            ttsMember = Execute(query);
            return ttsMember;
        }

      
        public DataTable GetDestinationDateForConsignment(List<string> consignments)
        {
            string query = string.Format("SELECT DOCKNO,ARRV_DT FROM dbo.DOCKET WHERE  DOC_CURLOC=REASSIGN_DESTCD and DOCKNO in ({0})", string.Join(",", consignments));
            return Execute(query);
        }

        public DataTable TblDeptMst()
        {
            DataTable dept = null;
            string query = "select distinct DeptID,Dept from tblDeptMst with (nolock) where IsActive = 1";
            dept = Execute(query);
            return dept;
        }

        public DataTable GetTTSAutoAssignBasedOnAccountList(string AccountCode)
        {
            string query = string.Format("select AccountCode , EmpCode  from Tts_AutoAssign with(nolock) where isactive =1 and  accountcode in ({0})", string.Join(",", AccountCode));
            //='" + AccountCode + "'";
            return Execute(query);
        }
        public DataTable GetptmsAcntcodeList(string AccountCode)
        {
            string query = string.Format("select Ptmsbrcd from Ptms WITH (NOLOCK) where Ptmsptcd in ({0})", string.Join(",", AccountCode));
            //='" + AccountCode + "'";
            return Execute(query);
        }
        public DataTable GetTTSAutoAssignBasedOnBranchList(string BranchCode)
        {
            string query = string.Format("select  EmpCode  from Tts_AutoAssign with(nolock) where isactive =1 and  Brcd in ({0})", string.Join(",", BranchCode));
            return Execute(query);
        }
        public DataTable ValidateConNumberFromDocket(List<string> refNumber)
        {
            string query = string.Format("select Dockno from dbo.docket with(nolock) where Dockno in  ({0})", string.Join(",", refNumber));

            DataTable dt = Execute(query);


            return dt;
        }
        public DataTable ValidateConNumberFromInvoice(List<string> refNumber)
        {
            // List<string> ref_Number = refNumber[0].ToString().Split(",").ToList();
            //string query = string.Format("select InvoiceNumber from dbo.[tblInvoice] with(nolock) where InvoiceNumber in  ({0})", String.Join(",", refNumber.Select(s => "'" + s + "'")));
            string query = string.Format("select InvoiceNumber from dbo.[tblInvoice] with(nolock) where InvoiceNumber in  ({0})", string.Join(",", refNumber));
            DataTable dt = Execute(query);
            return dt;
        }

        public DataTable ValidateConNumberFromPickup(List<string> refNumber)
        {
            //List<string> ref_Number = refNumber[0].ToString().Split(",").ToList();
            //string query = string.Format("select REFNO from dbo.[Pickup_Schedule] with(nolock) where refno in  ({0})", String.Join(",", refNumber.Select(s => "'" + s + "'")));
            var data = refNumber[0].Replace(",", "','");
            string query = string.Format("select REFNO from dbo.[Pickup_Schedule] with(nolock) where refno in  ({0})", string.Join(",", "'" + data + "'"));
            DataTable dt = Execute(query);
            return dt;
        }

        public DataTable GetMultipleCaseOpeningListDetail(string consignNo)
        {
            DataTable consignment = null;
            string query = string.Format("SELECT  RTRIM(B.DOCKNO)[ConNumber] ,CASE WHEN B.PAYBAS = '3' THEN B.CSGECD ELSE B.CSGNCD END[AccountNo], " +
                             "CASE WHEN B.PAYBAS = '3' THEN B.CSGENM ELSE B.CSGNNM END[AccountName] ,[ProductID]" +
                             "FROM dbo.DOCKET B WITH(NOLOCK) INNER JOIN dbo.brms OBR WITH(NOLOCK) ON B.ORGNCD = OBR.BRCD " +
                             "INNER JOIN dbo.brms DBR WITH(NOLOCK) ON B.DESTCD = DBR.BRCD INNER JOIN dbo.brms CBR WITH(NOLOCK) ON B.DOC_CURLOC = CBR.BRCD " +
                             "LEFT OUTER JOIN dbo.DKT_DELY DD WITH(NOLOCK) ON DD.DOCKNO = B.DOCKNO WHERE B.DOCKNO in ({0})", string.Join(",", consignNo));

            consignment = Execute(query);
            return consignment;
        }

        public DataTable GetMultipleCaseOpeningInvoiceDetail(string consignNo)
        {
            DataTable Invoice = null;
            string query = string.Format("SELECT distinct [pcust].[ptmsptcd] AS [AccountNo], [pcust].[PCUSTNAME] AS [AccountName],[inv].[InvoiceNumber] as ConNumber,[d].[ProductID] " +
                                             "FROM [tblInvoice] AS[inv] with(nolock) " +
                                             "INNER JOIN[PCUST_MAIN] AS[pcust] " +
                                             "with(nolock) ON[inv].[PTMSPTCD] = [pcust].[ptmsptcd]INNER JOIN[tblInvoiceConMap] AS[ic] with(nolock) " +
                                             "ON[inv].[InvoiceId] = [ic].[InvoiceId]INNER JOIN[DOCKET] AS[d] with(nolock) " +
                                             "ON[ic].[DocketNumber] = [d].[DOCKNO]WHERE[inv].[InvoiceNumber] in ({0})", string.Join(",", consignNo));

            Invoice = Execute(query);
            return Invoice;
        }

        public DataTable GetMultipleCaseOpeningPickupDetail(string pickup)
        {
            DataTable Pickup = null;
            var data = pickup.Replace(",", "','");
            string query = string.Format("SELECT Top 50 A.ptcd AS AccountNo , A.ptnm AS AccountName ,A.refno as ConNumber,[ProductTypeID] AS[ProductID] " +
                                            "FROM(SELECT TOP 50 REFNO, PickupscheduleID  FROM Pickup_Schedule A WITH(NOLOCK) " +
                                            "WHERE REFNO in ({0})", String.Join(",", ("'" + data + "'"))) +
            //string.Join(",", pickup )) +
                                          "AND ScheduleDate <= (REPLACE(CONVERT(VARCHAR(10), GETDATE(), 111), '/', '-') + ' 23:59:00') " +
                                            "ORDER BY  ScheduleDate DESC) S INNER JOIN Pickup_Schedule sh WITH(NOLOCK) " +
                                            "ON sh.PickupscheduleID = S.PickupscheduleID  INNER JOIN PICKUP_AUTHO A WITH(NOLOCK) " +
                                            "ON A.refno = S.REFNO";
            Pickup = Execute(query);
            return Pickup;
        }


        public DataTable PrimaryAgentAccountAndBranchDetails(string empCode)
        {
            DataTable accDetails = null;

            string query = "SELECT DISTINCT (Case when TTA.AccountCode is not null then TTA.AccountCode when TTA.Brcd is not null then TTA.Brcd end) as Code, (Case when P.PTMSPTNM is not null then P.PTMSPTNM when B.BRNM is not null then B.BRNM end) as Name, TTA.EmpCode FROM TTS_AutoAssign TTA with(nolock) LEFT OUTER JOIN PTMS P with(nolock) ON TTA.AccountCode = P.PTMSPTCD LEFT OUTER JOIN BRMS B with(nolock) ON TTA.Brcd = B.BRCD WHERE TTA.EmpCode = '" + empCode + "' order by Code";
            accDetails = Execute(query);
            return accDetails;
        }


        //public DataTable GetTTSAutoAssignBasedOnAccountList(string AccountCode)
        //{
        //    string query = string.Format("select AccountCode , EmpCode  from Tts_AutoAssign with(nolock) where isactive =1 and  accountcode in ({0})", string.Join(",", AccountCode));
        //    //='" + AccountCode + "'";
        //    return Execute(query);
        //}

        #region esclation

        public DataTable GetEsclationLevelDetail()
        {
            string query = "Select AutoID,DeptID,BranchType,Level,Description,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn " +
                            "FROM tblDeptLevelMaster WITH(NOLOCK) where IsActive=1";

            return Execute(query);
        }

        public DataTable GetBranchForEsclation()
        {
            string query = "SELECT BRCD, BRNM,CASE WHEN ISNULL(HUBCENTER,'N') ='N' THEN 'SC' ELSE 'HUB' END [BranchType] FROM dbo.brms ";
            return Execute(query);
        }

        public DataTable GetEsclationEmpDetail(string branch, int Level, int DeptId)
        {
            string query = "SELECT E.EMPCD, E.EMPNM,b.Level,c.Dept, a.Branch, e.e_mailID, e.mobileno FROM tblDeptEscalationEmpDetails a " +
                            "INNER JOIN dbo.tblDeptLevelMaster b WITH ( NOLOCK ) ON a.DeptLevelMasterID = b.AutoID " +
                            "INNER JOIN dbo.tblDeptMst c WITH ( NOLOCK ) ON c.DeptID = b.DeptID " +
                            "INNER JOIN dbo.brms d WITH ( NOLOCK ) ON a.Branch = d.BRCD " +
                            "INNER JOIN dbo.EMPMST E WITH(NOLOCK) ON E.EMPCD=A.EmpID where a.Branch='" + branch + "' AND b.AutoID = " + Level + " AND c.DeptID= " + DeptId + " AND E.EMPST <> 'R' ";
            return Execute(query);
        }

        public DataTable GetEsclationReason(int DeptId, string BranchType)
        {
            string query = "SELECT A.AutoID,A.ReasonCode FROM tblDeptEsclReasonCodeMst A WITH ( NOLOCK ) " +
                            "INNER JOIN dbo.tblDeptMst B WITH(NOLOCK) ON B.DeptID = A.DeptID " +
                            "WHERE A.DeptID = " + DeptId + " AND A.BranchType='" + BranchType + "'";
            return Execute(query);
        }

        #endregion

        #region account types for reports
        public DataTable GetAccountTypeDetails()
        {
            DataTable accDT = null;

            string query = "select AccountTypeId, AccountType from [ESTL_CRP2].[dbo].[tblAccountTypeMaster] with (nolock)";

            accDT = Execute(query);
            return accDT;
        }
        #endregion

        #region region and depo for reports
        public DataTable GetDepoDetails()
        {
            DataTable depoDetails = null;

            string query = "SELECT DepoCode, Description FROM  [ESTL_CRP2].[dbo].tblDepoMaster DM  WITH ( NOLOCK ) ";

            depoDetails = Execute(query);
            return depoDetails;
        }

        public DataTable GetRegionDetails()
        {
            DataTable regionDetails = null;

            string query = "SELECT DISTINCT Region, RegionName FROM  [ESTL_CRP2].[dbo].tblDepoMaster DM  WITH ( NOLOCK ) WHERE REGION IN ('E','N','S','W')";

            regionDetails = Execute(query);
            return regionDetails;
        }

        #endregion

        public DataTable GEsclationReasonName(List<string> Id)
        {
            string query = string.Format("SELECT A.AutoID,A.ReasonCode FROM tblDeptEsclReasonCodeMst A WITH ( NOLOCK ) " +
                            "WHERE A.AutoID IN ({0}) ", string.Join(",", Id[0]));
            return Execute(query);
        }

        public DataTable GetDatForOnDemand(string fromDate, string toDate, string teamLead, int? accountCode, int? caseType, int? caseStatus)
        {
            DataTable OnDemandReport = new DataTable();
            try
            {

                using (SqlConnection conn = new SqlConnection(strConnCrm))
                {
                    SqlCommand cmd = new SqlCommand("p_getOnDemandReport", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@FromDate", fromDate));
                    cmd.Parameters.Add(new SqlParameter("@ToDate ", toDate));
                    cmd.Parameters.Add(new SqlParameter("@CaseType ", caseType));
                    cmd.Parameters.Add(new SqlParameter("@CaseStatus ", caseStatus));
                    cmd.Parameters.Add(new SqlParameter("@AccCode ", accountCode));
                    cmd.Parameters.Add(new SqlParameter("@TLEmpCode  ", teamLead));

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    {
                        adapter.Fill(OnDemandReport);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return OnDemandReport;
        }


        #region Spoton Dashboards

        public DataTable GetPickupDetails(string userIds)
        {
            DataTable accDT = null;
            List<string> totalEmp = new List<string>();
            string query = string.Empty;

            if (userIds.Length > 2)
            {
                totalEmp = JsonConvert.DeserializeObject<List<string>>(userIds);
                userIds = totalEmp.Aggregate((x, y) => x + "," + y);
                query = string.Format("SELECT  'Pickups Registered'[Type] ," +
                          "SUM((CASE WHEN IsODA = 1 THEN 1 ELSE 0 END)) [ODA] ," +
                          "SUM(CASE WHEN IsODA = 0 THEN 1 ELSE 0 END) [STD] ," +
                          "SUM(CASE WHEN RegSource = 'Others' THEN 0 ELSE 1 END) [Source_CS] ," +
                          "SUM(CASE WHEN RegSource = 'Others' THEN 1 ELSE 0 END) [Source_Others] ," +
                          "SUM(CASE WHEN PickupRegion = 'N' THEN 1 ELSE 0 END) [NORTH] ," +
                          "SUM(CASE WHEN PickupRegion = 'E' THEN 1 ELSE 0 END) [EAST] ," +
                          "SUM(CASE WHEN PickupRegion = 'W' THEN 1 ELSE 0 END) [WEST] ," +
                          "SUM(CASE WHEN PickupRegion = 'S' THEN 1 ELSE 0 END) [SOUTH]" +
                          "FROM tbleSpotonCRMPickupDashboard WITH(NOLOCK) where CSAgent in  ({0}) " +
                          " UNION ALL" + " " +
                          "SELECT  'Picked Up' [Type] ," +
                          "SUM((CASE WHEN IsODA = 1 THEN 1 ELSE 0  END )) [ODA] ," +
                          "SUM(CASE WHEN IsODA = 0 THEN 1 ELSE 0 END) [STD] ," +
                          "SUM(CASE WHEN RegSource = 'Others' THEN 0 ELSE 1 END) [Source_CS] ," +
                          "SUM(CASE WHEN RegSource = 'Others' THEN 1 ELSE 0 END) [Source_Others] ," +
                          "SUM(CASE WHEN PickupRegion = 'N' THEN 1 ELSE 0 END) [NORTH] ," +
                          "SUM(CASE WHEN PickupRegion = 'E' THEN 1 ELSE 0 END) [EAST] ," +
                          "SUM(CASE WHEN PickupRegion = 'W' THEN 1 ELSE 0 END) [WEST] ," +
                          "SUM(CASE WHEN PickupRegion = 'S' THEN 1 ELSE 0 END) [SOUTH]" +
                          "FROM tbleSpotonCRMPickupDashboard WITH(NOLOCK) WHERE PickupStatus = 'Successful' AND CSAgent in  ({1}) " +
                          " UNION ALL" + " " +
                          "SELECT  'Not Picked Up' [Type] ," +
                          "SUM((CASE WHEN IsODA = 1 THEN 1 ELSE 0  END )) [ODA] ," +
                          "SUM(CASE WHEN IsODA = 0 THEN 1 ELSE 0 END) [STD] ," +
                          "SUM(CASE WHEN RegSource = 'Others' THEN 0 ELSE 1 END) [Source_CS] ," +
                          "SUM(CASE WHEN RegSource = 'Others' THEN 1 ELSE 0 END) [Source_Others] ," +
                          "SUM(CASE WHEN PickupRegion = 'N' THEN 1 ELSE 0 END) [NORTH] ," +
                          "SUM(CASE WHEN PickupRegion = 'E' THEN 1 ELSE 0 END) [EAST] ," +
                          "SUM(CASE WHEN PickupRegion = 'W' THEN 1 ELSE 0 END) [WEST] ," +
                          "SUM(CASE WHEN PickupRegion = 'S' THEN 1 ELSE 0 END) [SOUTH]" +
                          "FROM tbleSpotonCRMPickupDashboard WITH(NOLOCK) WHERE PickupStatus <> 'Successful' AND CSAgent in  ({2}) ",
                          string.Join(",", userIds), string.Join(",", userIds), string.Join(",", userIds));
            }
            else
            {
                query = "SELECT  'Pickups Registered'[Type] ," +
                          "SUM((CASE WHEN IsODA = 1 THEN 1 ELSE 0 END)) [ODA] ," +
                          "SUM(CASE WHEN IsODA = 0 THEN 1 ELSE 0 END) [STD] ," +
                          "SUM(CASE WHEN RegSource = 'Others' THEN 0 ELSE 1 END) [Source_CS] ," +
                          "SUM(CASE WHEN RegSource = 'Others' THEN 1 ELSE 0 END) [Source_Others] ," +
                          "SUM(CASE WHEN PickupRegion = 'N' THEN 1 ELSE 0 END) [NORTH] ," +
                          "SUM(CASE WHEN PickupRegion = 'E' THEN 1 ELSE 0 END) [EAST] ," +
                          "SUM(CASE WHEN PickupRegion = 'W' THEN 1 ELSE 0 END) [WEST] ," +
                          "SUM(CASE WHEN PickupRegion = 'S' THEN 1 ELSE 0 END) [SOUTH]" +
                          "FROM tbleSpotonCRMPickupDashboard WITH(NOLOCK) " +
                          " UNION ALL" + " " +
                          "SELECT  'Picked Up' [Type] ," +
                          "SUM((CASE WHEN IsODA = 1 THEN 1 ELSE 0  END )) [ODA] ," +
                          "SUM(CASE WHEN IsODA = 0 THEN 1 ELSE 0 END) [STD] ," +
                          "SUM(CASE WHEN RegSource = 'Others' THEN 0 ELSE 1 END) [Source_CS] ," +
                          "SUM(CASE WHEN RegSource = 'Others' THEN 1 ELSE 0 END) [Source_Others] ," +
                          "SUM(CASE WHEN PickupRegion = 'N' THEN 1 ELSE 0 END) [NORTH] ," +
                          "SUM(CASE WHEN PickupRegion = 'E' THEN 1 ELSE 0 END) [EAST] ," +
                          "SUM(CASE WHEN PickupRegion = 'W' THEN 1 ELSE 0 END) [WEST] ," +
                          "SUM(CASE WHEN PickupRegion = 'S' THEN 1 ELSE 0 END) [SOUTH]" +
                          "FROM tbleSpotonCRMPickupDashboard WITH(NOLOCK) WHERE PickupStatus = 'Successful'" +
                          " UNION ALL" + " " +
                          "SELECT  'Not Picked Up' [Type] ," +
                          "SUM((CASE WHEN IsODA = 1 THEN 1 ELSE 0  END )) [ODA] ," +
                          "SUM(CASE WHEN IsODA = 0 THEN 1 ELSE 0 END) [STD] ," +
                          "SUM(CASE WHEN RegSource = 'Others' THEN 0 ELSE 1 END) [Source_CS] ," +
                          "SUM(CASE WHEN RegSource = 'Others' THEN 1 ELSE 0 END) [Source_Others] ," +
                          "SUM(CASE WHEN PickupRegion = 'N' THEN 1 ELSE 0 END) [NORTH] ," +
                          "SUM(CASE WHEN PickupRegion = 'E' THEN 1 ELSE 0 END) [EAST] ," +
                          "SUM(CASE WHEN PickupRegion = 'W' THEN 1 ELSE 0 END) [WEST] ," +
                          "SUM(CASE WHEN PickupRegion = 'S' THEN 1 ELSE 0 END) [SOUTH]" +
                          "FROM tbleSpotonCRMPickupDashboard WITH(NOLOCK) WHERE PickupStatus <> 'Successful'";
            }
            accDT = Execute(query);
            return accDT;
        }

        public DataTable GetConMovementDetails(string userIds)
        {
            DataTable accDT = null;
            List<string> totalEmp = new List<string>();
            string query = string.Empty;

            if (userIds.Length > 2)
            {
                totalEmp = JsonConvert.DeserializeObject<List<string>>(userIds);
                userIds = totalEmp.Aggregate((x, y) => x + "," + y);
                query = string.Format("SELECT  DocStatus , COUNT(DOCKNO) [ConMovementTotal] ," +
                              "SUM(CASE WHEN DueDate > CONVERT(DATE, GETDATE()) THEN 1 ELSE 0 END)[Date Crossed] ," +
                              "SUM(CASE WHEN DueDate < CONVERT(DATE, GETDATE()) THEN 1 ELSE 0 END)[Date Not Crossed] ," +
                              "SUM(CASE WHEN ProductType = 'SR' THEN 1 ELSE 0 END)[ProdSR] ," +
                              "SUM(CASE WHEN ProductType = 'AR' THEN 1 ELSE 0 END)[ProdAR] FROM tbleSpotonCRMConDashboard WITH(NOLOCK)" +
                              "where CSAgent in  ({0}) GROUP BY DocStatus", string.Join(",", userIds));

            }
            else
            {
                query = "SELECT  DocStatus , COUNT(DOCKNO) [ConMovementTotal] ," +
                             "SUM(CASE WHEN DueDate > CONVERT(DATE, GETDATE()) THEN 1 ELSE 0 END)[Date Crossed] ," +
                             "SUM(CASE WHEN DueDate < CONVERT(DATE, GETDATE()) THEN 1 ELSE 0 END)[Date Not Crossed] ," +
                             "SUM(CASE WHEN ProductType = 'SR' THEN 1 ELSE 0 END)[ProdSR] ," +
                             "SUM(CASE WHEN ProductType = 'AR' THEN 1 ELSE 0 END)[ProdAR] FROM tbleSpotonCRMConDashboard WITH(NOLOCK)" +
                             "GROUP BY DocStatus";
            }
            accDT = Execute(query);
            return accDT;
        }

        public DataTable GetConMovementDetailsById(string userIds, string docStatus, string pType, string dueDate)
        {
            DataTable accDT = null;
            List<string> totalEmp = new List<string>();
            string query = string.Empty;
            string prodType = !string.IsNullOrEmpty(pType) ? "1" : "0";
            dueDate = !string.IsNullOrEmpty(dueDate) ? dueDate : "0";

            if (userIds.Length > 2)
            {
                totalEmp = JsonConvert.DeserializeObject<List<string>>(userIds);
                userIds = totalEmp.Aggregate((x, y) => x + "," + y);
                query = string.Format("SELECT TOP 50 CD.DockNo, CD.Origin, CD.Destination, CD.CurrentLocation, CD.BookingDate, CD.DueDate," +
                          "CD.AccountCode, CD.CSAgent, CD.Wt_Pcs, CD.LatestStatusCode, CD.ProductType, CD.DocStatus" + " " +
                          "FROM tbleSpotonCRMConDashboard CD WITH(NOLOCK) WHERE CD.CSAgent IN ({0})" +
                          "AND CD.DocStatus = '" + docStatus + "'" +
                          "AND(('" + prodType + "' = '0'  AND CD.ProductType IN(SELECT DISTINCT C.ProductType FROM tbleSpotonCRMConDashboard C WITH(NOLOCK) ))" +
                          "OR ('" + prodType + "' <> '0' AND CD.ProductType = '" + pType + "') )  " +
                          "AND (('" + dueDate + "' = '0' AND CD.DueDate <> '') OR ('" + dueDate + "' = '2' AND CD.DueDate < CONVERT(DATE, GETDATE()))" +
                          "OR ('" + dueDate + "' = '1' AND CD.DueDate > CONVERT(DATE, GETDATE())))", string.Join(", ", userIds));
            }
            else
            {
                query = "SELECT TOP 50 CD.DockNo, CD.Origin, CD.Destination, CD.CurrentLocation, CD.BookingDate, CD.DueDate," +
                         "CD.AccountCode, CD.CSAgent, CD.Wt_Pcs, CD.LatestStatusCode, CD.ProductType, CD.DocStatus" + " " +
                         "FROM tbleSpotonCRMConDashboard CD WITH(NOLOCK)" + " " +
                         "WHERE CD.DocStatus = '" + docStatus + "'" +
                         "AND(('" + prodType + "' = '0'  AND CD.ProductType IN(SELECT DISTINCT C.ProductType FROM tbleSpotonCRMConDashboard C WITH(NOLOCK) ))" +
                         "OR ('" + prodType + "' <> '0' AND CD.ProductType = '" + pType + "') )  " +
                         "AND (('" + dueDate + "' = '0' AND CD.DueDate <> '') OR ('" + dueDate + "' = '2' AND CD.DueDate < CONVERT(DATE, GETDATE()))" +
                         "OR ('" + dueDate + "' = '1' AND CD.DueDate > CONVERT(DATE, GETDATE())))";
            }

            accDT = Execute(query);
            return accDT;
        }

        public DataTable GetPickupDetailsById(string userIds, string pickStatus, string IsSTDOrODA, string closureType, string regionType)
        {
            DataTable accDT = null;
            List<string> totalEmp = new List<string>();
            string query = string.Empty;
            string pickType = !string.IsNullOrEmpty(pickStatus) ? pickStatus.ToUpper() == "PICKUPSREGISTERED" ? "0" : pickStatus.ToUpper() == "PICKED UP" ? "1" : pickStatus.ToUpper() == "NOT PICKED UP" ? "2" : "0" : "0";
            string stdOrOda = !string.IsNullOrEmpty(IsSTDOrODA) ? IsSTDOrODA.ToUpper() == "STD" ? "1" : IsSTDOrODA.ToUpper() == "ODA" ? "2" : "0" : "0";
            string clsType = string.IsNullOrEmpty(closureType) ? "0" : "1";
            string rgnType = string.IsNullOrEmpty(regionType) ? "0" : "1";
            closureType = !string.IsNullOrEmpty(closureType) ? closureType.ToUpper() == "CS" ? "CS" : "Others" : null;

            if (userIds.Length > 2)
            {
                totalEmp = JsonConvert.DeserializeObject<List<string>>(userIds);
                userIds = totalEmp.Aggregate((x, y) => x + "," + y);
                query = string.Format("SELECT TOP 50 pd.AccountCode, pd.CSAgent, pd.IsODA, pd.OrderNo, pd.PickupDate, pd.PickupDate, pd.PickupRegion, pd.Weight, pd.RegSource, pd.PType" + " " +
                        "FROM    tbleSpotonCRMPickupDashboard pd WITH(NOLOCK) WHERE PD.CSAgent IN ({0})" +
                        "AND(('" + pickType + "' = '0'  AND pd.PickupStatus IN(SELECT DISTINCT C.PickupStatus FROM tbleSpotonCRMPickupDashboard C WITH(NOLOCK)))" +
                        "OR(  '" + pickType + "' = '1'  AND pd.PickupStatus = 'Successful')" +
                        "OR(  '" + pickType + "' = '2'  AND pd.PickupStatus <> 'Successful'))" +
                        "AND(('" + stdOrOda + "' = '0'  AND pd.IsODA IN(SELECT DISTINCT C.IsODA FROM tbleSpotonCRMPickupDashboard C WITH(NOLOCK)))" +
                        "OR(  '" + stdOrOda + "' = '1'  AND pd.IsODA = 0)  OR ('" + stdOrOda + "' = '2' AND pd.IsODA = 1))  " +
                        "AND(('" + clsType + "' = '0'  AND pd.RegSource IN(SELECT DISTINCT C.RegSource FROM tbleSpotonCRMPickupDashboard C WITH(NOLOCK)))" +
                        "OR(  '" + clsType + "' = '1'  AND pd.RegSource = '" + closureType + "')) " +
                        "AND(('" + rgnType + "' = '0'  AND pd.PickupRegion IN(SELECT DISTINCT C.PickupRegion FROM tbleSpotonCRMPickupDashboard C WITH(NOLOCK)))" +
                        "OR(  '" + rgnType + "' <> '0' AND PD.PickupRegion = '" + regionType + "'))", string.Join(", ", userIds));
            }
            else
            {
                query = "SELECT TOP 50 pd.AccountCode, pd.CSAgent, pd.IsODA, pd.OrderNo, pd.PickupDate, pd.PickupDate, pd.PickupRegion, pd.Weight, pd.RegSource, pd.PType" + " " +
                        "FROM    tbleSpotonCRMPickupDashboard pd WITH(NOLOCK)" + " " +
                        "WHERE (('" + pickType + "' = '0' AND pd.PickupStatus IN(SELECT DISTINCT C.PickupStatus FROM tbleSpotonCRMPickupDashboard C WITH(NOLOCK)))" +
                        "OR(  '" + pickType + "' = '1' AND pd.PickupStatus = 'Successful')" +
                        "OR(  '" + pickType + "' = '2' AND pd.PickupStatus <> 'Successful'))" +
                        "AND(('" + stdOrOda + "' = '0' AND pd.IsODA IN(SELECT DISTINCT C.IsODA FROM tbleSpotonCRMPickupDashboard C WITH(NOLOCK)))" +
                        "OR(  '" + stdOrOda + "' = '1' AND pd.IsODA = 0)  OR ('" + stdOrOda + "' = '2' AND pd.IsODA = 1))  " +
                        "AND(('" + clsType + "' = '0' AND pd.RegSource IN(SELECT DISTINCT C.RegSource FROM tbleSpotonCRMPickupDashboard C WITH(NOLOCK)))" +
                        "OR(  '" + clsType + "' = '1' AND pd.RegSource = '" + closureType + "')) " +
                        "AND(('" + rgnType + "' = '0' AND pd.PickupRegion IN(SELECT DISTINCT C.PickupRegion FROM tbleSpotonCRMPickupDashboard C WITH(NOLOCK)))" +
                        "OR(  '" + rgnType + "' <> '0' AND PD.PickupRegion = '" + regionType + "'))";
            }

            accDT = Execute(query);
            return accDT;
        }

        #endregion



    }
}
