using System;
namespace RazorHtmlEmails.RazorClassLib.Views.Emails.InvoiceEmail
{
    public class InvoiceEmailViewModel
    {
        public string StudentFullName;
        public string StudentLName;
        public string StudentFName;
        public string Comment;
        public string Term;
        public string Year { 
            get
            {
                return PaymentFinalDate.Year.ToString();
            } 
        }
        public DateTime TermStartDate;
        public DateTime PaymentFinalDate;
        public string ReferenceNo;
        public string TotalCost;
        public string Semester;
        public string StudentGuardianName;
        public string Bank;
        public string AccountName;
        public string BSB;
        public string AccountNo;
        public string Signature;

        public InvoiceEmailViewModel(string studentFullName, string studentLName, string studentFName, string comment, int term, DateTime termStartDate, DateTime paymentFinalDate, string referenceNo, float totalCost, int semester, string studentGuardianName, string bank, string accountName, string bSB, string accountNo, string signature)
        {
            StudentFullName = studentFullName ?? throw new ArgumentNullException(nameof(studentFullName));
            StudentLName = studentLName ?? throw new ArgumentNullException(nameof(studentLName));
            StudentFName = studentFName ?? throw new ArgumentNullException(nameof(studentFName));
            Comment = comment ?? throw new ArgumentNullException(nameof(comment));
            Term = term .ToString();
            TermStartDate = termStartDate;
            PaymentFinalDate = paymentFinalDate;
            ReferenceNo = referenceNo ?? throw new ArgumentNullException(nameof(referenceNo));
            TotalCost = totalCost.ToString("0.000");
            Semester = semester.ToString();
            StudentGuardianName = studentGuardianName ?? throw new ArgumentNullException(nameof(studentGuardianName));
            Bank = bank ?? throw new ArgumentNullException(nameof(bank));
            AccountName = accountName ?? throw new ArgumentNullException(nameof(accountName));
            BSB = bSB ?? throw new ArgumentNullException(nameof(bSB));
            AccountNo = accountNo ?? throw new ArgumentNullException(nameof(accountNo));
            Signature = signature ?? throw new ArgumentNullException(nameof(signature));
        }
    }
}
