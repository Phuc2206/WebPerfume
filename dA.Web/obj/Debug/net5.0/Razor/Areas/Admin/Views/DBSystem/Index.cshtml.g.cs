#pragma checksum "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Areas\Admin\Views\DBSystem\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d65394e11a253d583f2935ac2a9c250db8de6585"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_DBSystem_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/DBSystem/Index.cshtml")]
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
#line 1 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Areas\Admin\Views\_ViewImports.cshtml"
using dA.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Areas\Admin\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Areas\Admin\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Areas\Admin\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Areas\Admin\Views\_ViewImports.cshtml"
using dA.Data.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Areas\Admin\Views\_ViewImports.cshtml"
using X.PagedList.Web.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Areas\Admin\Views\_ViewImports.cshtml"
using dA.Web.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d65394e11a253d583f2935ac2a9c250db8de6585", @"/Areas/Admin/Views/DBSystem/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"77701ec721b52d214721ffd2329b5d102da70939", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_DBSystem_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dA.Web.common.AppSystemEnv>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("autocomplete", new global::Microsoft.AspNetCore.Html.HtmlString("off"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Areas\Admin\Views\DBSystem\Index.cshtml"
  
    ViewData["Title"] = "Th??ng tin c???a h??ng";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d65394e11a253d583f2935ac2a9c250db8de65855579", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d65394e11a253d583f2935ac2a9c250db8de65855841", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 9 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Areas\Admin\Views\DBSystem\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
                WriteLiteral(@"    <div class=""form-group"">
            <div class=""card"">
                <div class=""card-header"">
                    <h3 class=""card-title"">Th??ng tin c?? b???n</h3>
                    <div class=""card-tools"">
                    </div>
                </div>
");
                WriteLiteral(@"                </div>
                <div class=""row"">
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <label for=""Phone"" class=""control-label"">S??? ??i???n tho???i 1</label>
                            <input id=""Phone""
                                   placeholder=""S??? ??i???n tho???i....""
                                   name=""Phone"" class=""form-control""");
                BeginWriteAttribute("value", " value=\'", 3418, "\'", 3441, 1);
#nullable restore
#line 65 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Areas\Admin\Views\DBSystem\Index.cshtml"
WriteAttributeValue("", 3426, Model["Phone"], 3426, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                        </div>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <label for=""BrandName"" class=""control-label"">T??n c???a h??ng</label>
                            <input id=""BrandName""
                                   placeholder=""T??n c???a h??ng....""
                                   name=""BrandName"" class=""form-control""");
                BeginWriteAttribute("value", " value=\'", 3945, "\'", 3972, 1);
#nullable restore
#line 75 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Areas\Admin\Views\DBSystem\Index.cshtml"
WriteAttributeValue("", 3953, Model["BrandName"], 3953, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                        </div>
                    </div>
                </div>
            </div>
            <div class=""form-group"">
                <label for=""Address"" class=""control-label"">?????a ch??? c???a h??ng</label>
                <textarea rows=""3""
                          id=""Address""
                          placeholder=""?????a ch??? c???a h??ng...""
                          name=""Address"" class=""form-control""");
                BeginWriteAttribute("value", "\r\n                          value=\'", 4403, "\'", 4455, 1);
#nullable restore
#line 86 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Areas\Admin\Views\DBSystem\Index.cshtml"
WriteAttributeValue("", 4438, Model["Address"], 4438, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 86 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Areas\Admin\Views\DBSystem\Index.cshtml"
                                               Write(Model["Address"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</textarea>
            </div>
    </div>



    <div class=""form-group"">
        <button type=""submit"" class=""btn btn-success""><i class=""fa fa-save""></i> L??u</button>
        <button type=""reset"" class=""btn btn-default""><i class=""fa fa-undo""></i> Nh???p l???i</button>
    </div>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dA.Web.common.AppSystemEnv> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
