#pragma checksum "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\Shared\_Pager.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4da81847801b235d1f269937ddcdc1de70f42c50"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Pager), @"mvc.1.0.view", @"/Views/Shared/_Pager.cshtml")]
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
#line 1 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\_ViewImports.cshtml"
using dA.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\_ViewImports.cshtml"
using dA.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\Shared\_Pager.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\Shared\_Pager.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\Shared\_Pager.cshtml"
using X.PagedList.Web.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4da81847801b235d1f269937ddcdc1de70f42c50", @"/Views/Shared/_Pager.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba4301690a30c71ac652d61c76737287460836d0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__Pager : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<object>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div class=\"my-4\">\r\n\t");
#nullable restore
#line 8 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\Shared\_Pager.cshtml"
Write(Html.PagedListPager((IPagedList)Model,
		page => Url.Action("Index", new { page = page }),
		new PagedListRenderOptions
		{
			LiElementClasses = new string[] { "page-item" },
			PageClasses = new string[] { "page-link" },
		}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<object>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
