#pragma checksum "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee39f6bc1bf1220134abc68933ccf926fd18c255"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Invoices_SendEmailConfirm), @"mvc.1.0.view", @"/Views/Invoices/SendEmailConfirm.cshtml")]
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
#line 1 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\_ViewImports.cshtml"
using AssignmentOne_CYCC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\_ViewImports.cshtml"
using AssignmentOne_CYCC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee39f6bc1bf1220134abc68933ccf926fd18c255", @"/Views/Invoices/SendEmailConfirm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79b1c63acbd0332de855cf8e4b87850b136ca9cb", @"/Views/_ViewImports.cshtml")]
    public class Views_Invoices_SendEmailConfirm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AssignmentOne_CYCC.Models.Invoice>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Invoices", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SendEmail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
  
    ViewData["Title"] = "Confirm Email";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Confirm Email</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>Student Name</th>\r\n            <th>Reference Number</th>\r\n            <th>Email</th>\r\n\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n        <tr>\r\n            <td>");
#nullable restore
#line 20 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
           Write(Model.Student.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 21 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
           Write(Model.ReferenceNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 22 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
           Write(Model.Student.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n\r\n<br />\r\n<hr />\r\n\r\n<p>Dear ");
#nullable restore
#line 30 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
   Write(Model.Student.FName);

#line default
#line hidden
#nullable disable
            WriteLiteral(",</p>\r\n<p>");
#nullable restore
#line 31 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
Write(Model.Comment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>\r\n    Welcome to all existing students and new students. Term ");
#nullable restore
#line 33 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
                                                       Write(Model.Term);

#line default
#line hidden
#nullable disable
            WriteLiteral(" will commence ");
#nullable restore
#line 33 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
                                                                                 Write(Model.TermStartDate.ToString("D, dd MMMM, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(". Please ensure your payment is finalised by ");
#nullable restore
#line 33 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
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
    <br /><br />
    Ref#: ");
#nullable restore
#line 41 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
     Write(Model.ReferenceNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n    Student: ");
#nullable restore
#line 42 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
        Write(Model.Student.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n    Amount: $");
#nullable restore
#line 43 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
        Write(Model.TotalCost);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <br /><br />\r\n</p>\r\n<p><b>Please follow this <a");
            BeginWriteAttribute("href", " href=\"", 1283, "\"", 1524, 10);
            WriteAttributeValue("", 1290, "https://webpay.cdu.edu.au/musicschool/tran?tran-type=006&REFNO=", 1290, 63, true);
#nullable restore
#line 46 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
WriteAttributeValue("", 1353, Model.ReferenceNo, 1353, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1373, "&CUSTNAME=", 1373, 10, true);
#nullable restore
#line 46 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
WriteAttributeValue("", 1383, Model.Student.LName, 1383, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1405, "_", 1405, 1, true);
#nullable restore
#line 46 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
WriteAttributeValue("", 1406, Model.Student.FName, 1406, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1428, "&PARENTSNAME=", 1428, 13, true);
#nullable restore
#line 46 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
WriteAttributeValue("", 1441, Model.Student.GuardianName, 1441, 29, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1470, "&UNITAMOUNTINCTAX=", 1470, 18, true);
#nullable restore
#line 46 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
WriteAttributeValue("", 1488, Model.TotalCost.ToString("0.000"), 1488, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">link</a> to make payment for term ");
#nullable restore
#line 46 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
                                                                                                                                                                                                                                                                                                                           Write(Model.Term);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 46 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
                                                                                                                                                                                                                                                                                                                                        Write(Model.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n<p><b>Apply for your Sport Vouchers for ");
#nullable restore
#line 47 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
                                   Write(Model.Semester);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 47 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
                                                    Write(Model.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(@", please visit the <a href=""https://sportvoucher.nt.gov.au/"" target=""_blank"">sport-voucher website</a>, as schools are no longer providing students with a sport voucher.</b></p>
<p><b>Alternatively pay via Bank Transfer - EFT - CUD bank details, delete old bank details:<br />New Bank details</b></p>
<p>
    <b>Bank:</b> ");
#nullable restore
#line 50 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
            Write(Model.Bank);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n    <b>Account Name:</b> ");
#nullable restore
#line 51 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
                    Write(Model.AccountName);

#line default
#line hidden
#nullable disable
            WriteLiteral(".<br />\r\n    <b>BSB Number:</b> ");
#nullable restore
#line 52 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
                  Write(Model.BSB);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n    <b>Account Number:</b> ");
#nullable restore
#line 53 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
                      Write(Model.AccountNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n    <b>Reference number - please include \'CYCM, Reference number and student name\'</b>\r\n</p>\r\n<p><em>The CYCM is committed to providing students with quality lessons in a positive learning environment.</em></p>\r\n<p>\r\n    Regards,<br />\r\n    ");
#nullable restore
#line 59 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
Write(Model.Signature);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n<br />\r\n<hr />\r\n<br />\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ee39f6bc1bf1220134abc68933ccf926fd18c25514287", async() => {
                WriteLiteral("Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ee39f6bc1bf1220134abc68933ccf926fd18c25515649", async() => {
                WriteLiteral("Send Email");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 66 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Invoices\SendEmailConfirm.cshtml"
                            WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AssignmentOne_CYCC.Models.Invoice> Html { get; private set; }
    }
}
#pragma warning restore 1591