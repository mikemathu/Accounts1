﻿namespace Accounts.Dtos
{
    public class ReadAccountDto
    {
        public int AccountClassID { get; set; }
        public int AccountID { get; set; }
        public int AccountNo { get; set; }
        public int CashFlowCategoryID { get; set; }
        public int CompanyBranchID { get; set; }
        public string AccountName { get; set; }
    }
}