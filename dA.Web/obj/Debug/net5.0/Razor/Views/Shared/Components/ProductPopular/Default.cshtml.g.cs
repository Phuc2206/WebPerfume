#pragma checksum "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\Shared\Components\ProductPopular\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "84464c1b9d430fa3408626d07c502c1a0604c785"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ProductPopular_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ProductPopular/Default.cshtml")]
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
#line 4 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\_ViewImports.cshtml"
using X.PagedList.Web.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84464c1b9d430fa3408626d07c502c1a0604c785", @"/Views/Shared/Components/ProductPopular/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba4301690a30c71ac652d61c76737287460836d0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_ProductPopular_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<dA.Data.JsonViewModels.Product.ProductListItemJM>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "SanPham", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-size-lg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ProductDetail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card_product card-size-lg swiper-slide"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<section class=\"content_item-header\">\r\n\t<h2>Most Popular PerFume <i class=\"fas fa-question-circle\"></i></h2>\r\n\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84464c1b9d430fa3408626d07c502c1a0604c7855800", async() => {
                WriteLiteral("Xem th??m &nbsp;<i class=\"fas fa-arrow-right\"></i>");
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
            WriteLiteral("\r\n</section>\r\n<section class=\"content_item\">\r\n\r\n\t<div class=\"content_item-body swiper new-swiper\">\r\n\t\t<div class=\"swiper-wrapper\">\r\n\r\n");
#nullable restore
#line 12 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\Shared\Components\ProductPopular\Default.cshtml"
             if (Model != null)
			{
				

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\Shared\Components\ProductPopular\Default.cshtml"
                 foreach (var item in Model)
				{
					

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\Shared\Components\ProductPopular\Default.cshtml"
                     if (item.ListProductPicture.Count >= 1)
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84464c1b9d430fa3408626d07c502c1a0604c7858069", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 19 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\Shared\Components\ProductPopular\Default.cshtml"
                             foreach (var iPic in item.ListProductPicture)
							{

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t\t\t\t\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "84464c1b9d430fa3408626d07c502c1a0604c7858625", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 785, "~/Images/Product/", 785, 17, true);
#nullable restore
#line 21 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\Shared\Components\ProductPopular\Default.cshtml"
AddHtmlAttributeValue("", 802, iPic.Name, 802, 10, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 22 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\Shared\Components\ProductPopular\Default.cshtml"
								break;
							}

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t\t\t\t<div class=\"product_name\">\r\n\t\t\t\t\t\t\t\t");
#nullable restore
#line 25 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\Shared\Components\ProductPopular\Default.cshtml"
                           Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t<div class=\"product_foodter\">\r\n");
#nullable restore
#line 28 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\Shared\Components\ProductPopular\Default.cshtml"
                                  
									var giaBan = item.Price;
								

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t\t\t\t\t<div> Gi?? b??n : ");
#nullable restore
#line 31 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\Shared\Components\ProductPopular\Default.cshtml"
                                           Write(giaBan?.ToString("#,### VN??"));

#line default
#line hidden
#nullable disable
                WriteLiteral(" </div>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 18 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\Shared\Components\ProductPopular\Default.cshtml"
                                                                                 WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 34 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\Shared\Components\ProductPopular\Default.cshtml"
					}

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\Shared\Components\ProductPopular\Default.cshtml"
                     

				}

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "D:\DoAnCoSo\DoAnCoSo2\dA.Web\Views\Shared\Components\ProductPopular\Default.cshtml"
                 
			}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</div>\r\n\r\n\t\t<div class=\"swiper-pagination\"></div>\r\n\t</div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<dA.Data.JsonViewModels.Product.ProductListItemJM>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
