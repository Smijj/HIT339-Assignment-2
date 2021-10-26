#pragma checksum "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "981b386c82e3fb4c13b123142dc0b50a7ed8b56e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Emails_InvoiceEmail), @"mvc.1.0.view", @"/Views/Emails/InvoiceEmail.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
using RazorHtmlEmails.RazorClassLib.Views.Emails.InvoiceEmail;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"981b386c82e3fb4c13b123142dc0b50a7ed8b56e", @"/Views/Emails/InvoiceEmail.cshtml")]
    public class Views_Emails_InvoiceEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InvoiceEmailViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
  
    ViewData["EmailTitle"] = "CYCM - Invoice";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<p>Dear ");
#nullable restore
#line 8 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
   Write(Model.StudentFName);

#line default
#line hidden
#nullable disable
            WriteLiteral(",</p>\r\n<p>");
#nullable restore
#line 9 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
Write(Model.Comment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>\r\n    Welcome to all existing students and new students. Term ");
#nullable restore
#line 11 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
                                                       Write(Model.Term);

#line default
#line hidden
#nullable disable
            WriteLiteral(" will commence ");
#nullable restore
#line 11 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
                                                                                 Write(Model.TermStartDate.ToString("D, dd MMMM, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(". Please ensure your payment is finalised by ");
#nullable restore
#line 11 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
                                                                                                                                                                               Write(Model.PaymentFinalDate.ToString("D, dd MMMM, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@". If a student is no longer attending lessons, please email the CYCM to be removed off the email list.
</p>
<p>
    If paying by Bank Transfer- EFT, please forward a copy of your payment to the office, to follow up and allocate to the student.
</p>
<p>
    <b>PAYMENT DETAILS:</b>
    <br />
    <table style=""text-align: left;"">
        <tbody>
            <tr>
                <th>Ref#</th>
                <td>");
#nullable restore
#line 23 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
               Write(Model.ReferenceNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Student</th>\r\n                <td>");
#nullable restore
#line 27 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
               Write(Model.StudentFullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Amount</th>\r\n                <td>$");
#nullable restore
#line 31 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
                Write(Model.TotalCost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n</p>\r\n<p><b>Please follow this <a");
            BeginWriteAttribute("href", " href=\"", 1215, "\"", 1435, 10);
            WriteAttributeValue("", 1222, "https://webpay.cdu.edu.au/musicschool/tran?tran-type=006&REFNO=", 1222, 63, true);
#nullable restore
#line 36 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
WriteAttributeValue("", 1285, Model.ReferenceNo, 1285, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1305, "&CUSTNAME=", 1305, 10, true);
#nullable restore
#line 36 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
WriteAttributeValue("", 1315, Model.StudentLName, 1315, 21, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1336, "_", 1336, 1, true);
#nullable restore
#line 36 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
WriteAttributeValue("", 1337, Model.StudentFName, 1337, 21, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1358, "&PARENTSNAME=", 1358, 13, true);
#nullable restore
#line 36 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
WriteAttributeValue("", 1371, Model.StudentGuardianName, 1371, 28, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1399, "&UNITAMOUNTINCTAX=", 1399, 18, true);
#nullable restore
#line 36 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
WriteAttributeValue("", 1417, Model.TotalCost, 1417, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">link</a> to make payment for term ");
#nullable restore
#line 36 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
                                                                                                                                                                                                                                                                                                      Write(Model.Term);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 36 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
                                                                                                                                                                                                                                                                                                                   Write(Model.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n<p><b>Apply for your Sport Vouchers for ");
#nullable restore
#line 37 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
                                   Write(Model.Semester);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 37 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
                                                    Write(Model.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(@", please visit the <a href=""https://sportvoucher.nt.gov.au/"" target=""_blank"">sport-voucher website</a>, as schools are no longer providing students with a sport voucher.</b></p>
<p><b>Alternatively pay via Bank Transfer - EFT - CUD bank details, delete old bank details:</b></p>
<table style=""text-align: left;"">update
    <tbody>
        <tr>
            <th colspan=""2"">New Bank details:</th>
        </tr>
        <tr>
            <th>Bank</th>
            <td>");
#nullable restore
#line 46 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
           Write(Model.Bank);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <th>Account Name</th>\r\n            <td>");
#nullable restore
#line 50 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
           Write(Model.AccountName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <th>BSB Number</th>\r\n            <td>");
#nullable restore
#line 54 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
           Write(Model.BSB);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <th>Account Number</th>\r\n            <td>");
#nullable restore
#line 58 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
           Write(Model.AccountNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <th>Reference number</th>\r\n            <td>please include \'CYCM, Reference number and student name\'</td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n<p>\r\n    Regards,<br />\r\n    ");
#nullable restore
#line 68 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\RazorHtmlEmails.RazorClassLib\Views\Emails\InvoiceEmail.cshtml"
Write(Model.Signature);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InvoiceEmailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591