#pragma checksum "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b391b15e314a6f7081a3a69d914c1e1e1f6d0cc8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Letters_FinalLetter), @"mvc.1.0.view", @"/Views/Letters/FinalLetter.cshtml")]
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
#line 1 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\_ViewImports.cshtml"
using HIT339_Assignment1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\_ViewImports.cshtml"
using HIT339_Assignment1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b391b15e314a6f7081a3a69d914c1e1e1f6d0cc8", @"/Views/Letters/FinalLetter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f5c2ac91f6c34c18fc53dca6eefafec20acacc0", @"/Views/_ViewImports.cshtml")]
    public class Views_Letters_FinalLetter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HIT339_Assignment1.Models.Letter>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SetPaid", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
  
    ViewData["Title"] = "Final Letter";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h4>Dear ");
#nullable restore
#line 8 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
    Write(ViewBag.letter.student.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(",</h4>\r\n\r\n<p>");
#nullable restore
#line 10 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
Write(ViewBag.letter.comment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n<p>\r\n    Welcome to all existing students and new students. Term ");
#nullable restore
#line 13 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
                                                        Write((int)ViewBag.letter.currentTerm + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" will commence ");
#nullable restore
#line 13 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
                                                                                                            Write(ViewBag.letter.termStartDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(@".
    Please ensure your payment is finalised by <payment_final> If a student is no longer attending lessons, please email the CYCM to be 
    removed off the email list.
</p>

<p>
    If paying by Bank Transfer- EFT, please forward a copy of your payment to the office, to follow up and allocate to the student.
</p>

<h6>Payment Details</h6>
<p>
    Ref#: ");
#nullable restore
#line 24 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
     Write(ViewBag.letter.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("  <br />\r\n    Student: ");
#nullable restore
#line 25 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
        Write(ViewBag.letter.student.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n<h6>Unpaid Lessons:</h6>\r\n<ul>\r\n");
#nullable restore
#line 29 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
     foreach (Lesson lesson in ViewBag.LessonQuery) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>\r\n            Lesson ID: ");
#nullable restore
#line 31 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
                  Write(lesson.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(",  <br />\r\n            Lesson Date: ");
#nullable restore
#line 32 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
                    Write(lesson.dateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(",  <br />\r\n            Student: ");
#nullable restore
#line 33 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
                Write(lesson.student.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("   <br />\r\n            Cost: $");
#nullable restore
#line 34 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
              Write(lesson.duration.lessonCost);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </li>\r\n");
#nullable restore
#line 36 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>\r\n<p>Total Cost: $");
#nullable restore
#line 38 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
           Write(ViewBag.totalCost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n\r\n\r\n<p><b>Please follow the <a href=\"#\">link</a> to make payment for Term ");
#nullable restore
#line 42 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
                                                                  Write((int)ViewBag.letter.currentTerm + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 42 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
                                                                                                        Write(ViewBag.letter.currentYear);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</b></p>\r\n<p><b>Apply for your Sport Vouchers for Semester ");
#nullable restore
#line 43 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
                                            Write(ViewBag.letter.currentSemester);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 43 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
                                                                             Write(ViewBag.letter.currentYear);

#line default
#line hidden
#nullable disable
            WriteLiteral(@", please visit <a href=""http://www.sportvoucher.nt.gov.au"">www.sportvoucher.nt.gov.au</a>, 
    as schools are no longer providing stufents with a sports voucher.</b></p>

<p><b>Alternatively pay via Bank Transfer - EFT - CDU bank details, delete old bank details:</b></p>
<h6>New Bank Details:</h6>

<p><b>
    Bank: ");
#nullable restore
#line 50 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
     Write(ViewBag.letter.bankName);

#line default
#line hidden
#nullable disable
            WriteLiteral("  <br />\r\n    Account Name: ");
#nullable restore
#line 51 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
             Write(ViewBag.letter.accountName);

#line default
#line hidden
#nullable disable
            WriteLiteral("  <br />\r\n    BSB Number: ");
#nullable restore
#line 52 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
           Write(ViewBag.letter.bsb);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    Account Number: ");
#nullable restore
#line 53 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
               Write(ViewBag.letter.accountNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    Reference: ");
#nullable restore
#line 54 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
          Write(ViewBag.letter.Reference);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</b></p>\r\n\r\n<p><i>The CYCM is committed to providing students with quality lessons in a positive learning environment.</i></p>\r\n<p>Regards</p>\r\n<p>CDU</p>\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b391b15e314a6f7081a3a69d914c1e1e1f6d0cc813611", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b391b15e314a6f7081a3a69d914c1e1e1f6d0cc814775", async() => {
                WriteLiteral("Set Paid");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "C:\Users\slyer\OneDrive\__University\Year 3\Semester 2\HIT339 Distributed Development\Assessments\Assignment 1 ~ Due 1-10-21\HIT339 Assignment1\Views\Letters\FinalLetter.cshtml"
                          WriteLiteral(ViewBag.letter.StudentId);

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HIT339_Assignment1.Models.Letter> Html { get; private set; }
    }
}
#pragma warning restore 1591
