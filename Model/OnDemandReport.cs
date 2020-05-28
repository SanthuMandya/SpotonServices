using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotonServices.Model
{
    public class OnDemandReport
    {
        public string CrmCaseNumber { get; set; }
        public string CaseAccountNumber { get; set; }
        public string ConNumber { get; set; }
        public string Consignee { get; set; }
        public string Consignor { get; set; }
        public string CaseType { get; set; }
        public string ComplaintSource { get; set; }
        public DateTime? DueDate { get; set; }
        public string DeliveryDate { get; set; }
        public int OpStatusCode { get; set; }
        public int CaseMainCatId { get; set; }
        public string MainCategoryName { get; set; }
        public int CaseSubCatId { get; set; }
        public string SubCategoryName { get; set; }
        public string FailCatName { get; set; }
        public string PriMstName { get; set; }
        public string OriginBranch { get; set; }
        public string DestinationBranch { get; set; }
        public string StatusBranch { get; set; }
        public string StatusDate { get; set; }
        public string CaseAssignedTo { get; set; }
        public string AgentCode { get; set; }
        public string AgentName { get; set; }
        public string TlCode { get; set; }
        public string GroupName { get; set; }
        public string EmpSuperviserId { get; set; }
        public string AgeingBucket { get; set; }
        public decimal TimeSpentInHrs { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedOn { get; set; }
        public string Level { get; set; }
        public string Dept { get; set; }
        public string StageName { get; set; }
        public string StatusReason { get; set; }
        public bool IsAudited { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SlaStatus { get; set; }
        public string Descriptionn { get; set; }
        public string ClosedBy { get; set; }
    }
}
