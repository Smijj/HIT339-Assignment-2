#pragma checksum "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Tutors\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "51caf5405818ec7a2892eabbfc1594d7e6c33868"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tutors_Index), @"mvc.1.0.view", @"/Views/Tutors/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51caf5405818ec7a2892eabbfc1594d7e6c33868", @"/Views/Tutors/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79b1c63acbd0332de855cf8e4b87850b136ca9cb", @"/Views/_ViewImports.cshtml")]
    public class Views_Tutors_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AssignmentOne_CYCC.Models.Tutor>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Tutors\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "51caf5405818ec7a2892eabbfc1594d7e6c338684355", async() => {
                WriteLiteral("Create New");
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
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Tutors\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.fName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Tutors\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.lName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Tutors\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Tutors\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 31 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Tutors\Index.cshtml"
         foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td data-href=\"/Tutors/Details/");
#nullable restore
#line 33 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Tutors\Index.cshtml"
                                          Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                    ");
#nullable restore
#line 34 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Tutors\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.fName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td data-href=\"/Tutors/Details/");
#nullable restore
#line 36 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Tutors\Index.cshtml"
                                          Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                    ");
#nullable restore
#line 37 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Tutors\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.lName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td data-href=\"/Tutors/Details/");
#nullable restore
#line 39 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Tutors\Index.cshtml"
                                          Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                    ");
#nullable restore
#line 40 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Tutors\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td data-href=\"/Tutors/Details/");
#nullable restore
#line 42 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Tutors\Index.cshtml"
                                          Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                    ");
#nullable restore
#line 43 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Tutors\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "51caf5405818ec7a2892eabbfc1594d7e6c338689877", async() => {
                WriteLiteral("<img src=\"img/edit.png\" alt=\"Edit\" class=\"row-icon\" />");
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
#line 46 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Tutors\Index.cshtml"
                                           WriteLiteral(item.Id);

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
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "51caf5405818ec7a2892eabbfc1594d7e6c3386812120", async() => {
                WriteLiteral("<img src=\"img/del.png\" alt=\"Delete\" class=\"row-icon\" />");
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
#line 47 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Tutors\Index.cshtml"
                                             WriteLiteral(item.Id);

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
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 50 "D:\GItRepos\HIT339-Assignment-2\AssignmentOne-CYCC\AssignmentOne-CYCC\Views\Tutors\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js""></script>
    <script>
        jQuery(document).ready(function ($) {
            $('*[data-href]').on('click', function () {
                window.location = $(this).data(""href"");
            });
        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AssignmentOne_CYCC.Models.Tutor>> Html { get; private set; }
    }
}
#pragma warning restore 1591
