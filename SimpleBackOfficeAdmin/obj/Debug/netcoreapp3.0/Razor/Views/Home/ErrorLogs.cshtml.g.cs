#pragma checksum "E:\C#文件夹\SimpleBackOfficeAdmin\SimpleBackOfficeAdmin\Views\Home\ErrorLogs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a564e4e6207bb61ca86a2d7d6d9e5a34b3d9eced"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ErrorLogs), @"mvc.1.0.view", @"/Views/Home/ErrorLogs.cshtml")]
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
#line 1 "E:\C#文件夹\SimpleBackOfficeAdmin\SimpleBackOfficeAdmin\Views\_ViewImports.cshtml"
using SimpleBackOfficeAdmin.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\C#文件夹\SimpleBackOfficeAdmin\SimpleBackOfficeAdmin\Views\_ViewImports.cshtml"
using SimpleBackOfficeAdmin.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a564e4e6207bb61ca86a2d7d6d9e5a34b3d9eced", @"/Views/Home/ErrorLogs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"823c696b2a38b963fc6bc48f2bafe53afc126aea", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ErrorLogs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<LogViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/forms/select2.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/forms/select2-bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\C#文件夹\SimpleBackOfficeAdmin\SimpleBackOfficeAdmin\Views\Home\ErrorLogs.cshtml"
  
    ViewBag.Tittle = "错误日志";

#line default
#line hidden
#nullable disable
            DefineSection("Css", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a564e4e6207bb61ca86a2d7d6d9e5a34b3d9eced5227", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a564e4e6207bb61ca86a2d7d6d9e5a34b3d9eced6405", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n<div class=\"content-wrapper\">\r\n    <div class=\"page-header\">\r\n        <h3 class=\"page-title\"> ");
#nullable restore
#line 12 "E:\C#文件夹\SimpleBackOfficeAdmin\SimpleBackOfficeAdmin\Views\Home\ErrorLogs.cshtml"
                           Write(ViewBag.Tittle);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h3>\r\n        <nav aria-label=\"breadcrumb\">\r\n            <ol class=\"breadcrumb\">\r\n                <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a564e4e6207bb61ca86a2d7d6d9e5a34b3d9eced8129", async() => {
                WriteLiteral("<i class=\"icon-home\"></i>首页");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n                <li class=\"breadcrumb-item active\" aria-current=\"page\">");
#nullable restore
#line 16 "E:\C#文件夹\SimpleBackOfficeAdmin\SimpleBackOfficeAdmin\Views\Home\ErrorLogs.cshtml"
                                                                  Write(ViewBag.Tittle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n            </ol>\r\n        </nav>\r\n    </div>\r\n");
            WriteLiteral(@"    <div class=""row "">
        <div class=""col-12 stretch-card grid-margin"">
            <div class=""card card-secondary"">
                <span class=""card-header"">
                    查询条件
                </span>
                <div class=""card-body d-lg-flex align-items-center"">
                    <div class=""form-group mb-lg-0"">
                        <label>模糊查询</label>
                        <input type=""text"" class=""form-control"" id=""searchName"" placeholder=""查询信息"">
                    </div>
                    <button type=""button"" target=""_blank"" id=""Search"" class=""btn ml-lg-auto btn-dark""><i class=""icon-magnifier""></i>查询</button>
                </div>
            </div>
        </div>
    </div>
");
            WriteLiteral(@"    <div class=""row"">
        <section class=""col-lg-12 grid-margin stretch-card"">
            <div class=""card"">
                <div class=""card-header"">
                    <div class=""dropdown"">
                        <button class=""btn btn-secondary dropdown-toggle"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                            显示风格
                        </button>
                        <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
                            <a class=""dropdown-item"" href=""javascript:void(0)"" onclick=""DefaultStyle()"">默 认</a>
                            <a class=""dropdown-item"" href=""javascript:void(0)"" onclick=""StripedStyle()"">间 隔</a>
                        </div>
                    </div>
                </div>
                <div class=""card-body"">
                    <h6 class=""card-title"">错误日志 </h6>
                    <table class=""table table-hover table-responsive"">
   ");
            WriteLiteral(@"                     <tr>
                            <th>时 间</th>
                            <th>账 号</th>
                            <th>请求路径</th>
                            <th>请求方式</th>
                            <th>异常信息</th>
                            <th>主机名</th>
                            <th>相关组件</th>
                        </tr>
                        <tbody>
");
#nullable restore
#line 65 "E:\C#文件夹\SimpleBackOfficeAdmin\SimpleBackOfficeAdmin\Views\Home\ErrorLogs.cshtml"
                             foreach (var log in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 68 "E:\C#文件夹\SimpleBackOfficeAdmin\SimpleBackOfficeAdmin\Views\Home\ErrorLogs.cshtml"
                               Write(log.Operatingtime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 69 "E:\C#文件夹\SimpleBackOfficeAdmin\SimpleBackOfficeAdmin\Views\Home\ErrorLogs.cshtml"
                               Write(log.Identity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 70 "E:\C#文件夹\SimpleBackOfficeAdmin\SimpleBackOfficeAdmin\Views\Home\ErrorLogs.cshtml"
                               Write(log.Requesturl);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 71 "E:\C#文件夹\SimpleBackOfficeAdmin\SimpleBackOfficeAdmin\Views\Home\ErrorLogs.cshtml"
                               Write(log.Method);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <a href=\"javascript:void(0)\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3311, "\"", 3338, 3);
            WriteAttributeValue("", 3321, "Detail(\'", 3321, 8, true);
#nullable restore
#line 73 "E:\C#文件夹\SimpleBackOfficeAdmin\SimpleBackOfficeAdmin\Views\Home\ErrorLogs.cshtml"
WriteAttributeValue("", 3329, log.Id, 3329, 7, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3336, "\')", 3336, 2, true);
            EndWriteAttribute();
            WriteLiteral(">详  情</a>\r\n                                    <div class=\"modal fade\"");
            BeginWriteAttribute("id", " id=\"", 3409, "\"", 3428, 2);
            WriteAttributeValue("", 3414, "Detail_", 3414, 7, true);
#nullable restore
#line 74 "E:\C#文件夹\SimpleBackOfficeAdmin\SimpleBackOfficeAdmin\Views\Home\ErrorLogs.cshtml"
WriteAttributeValue("", 3421, log.Id, 3421, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"">
                                        <div class=""modal-dialog"" role=""document"">
                                            <div class=""modal-content"">
                                                <div class=""modal-header"">
                                                    <h4 class=""modal-title text-left"" id=""myModalLabel"">详  情</h4>
                                                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">×</span></button>
                                                </div>
                                                <div class=""modal-body "">
                                                    <div style=""white-space:normal;height:auto;width:auto;margin:10px;background-color:wheat;"">
                                                        <p>");
#nullable restore
#line 83 "E:\C#文件夹\SimpleBackOfficeAdmin\SimpleBackOfficeAdmin\Views\Home\ErrorLogs.cshtml"
                                                      Write(log.Exception);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                                    </div>
                                                </div>
                                                <div class=""modal-footer"">
                                                    <button type=""button"" class=""btn btn-default"" data-dismiss=""modal""><span class=""glyphicon	glyphicon-remove"" aria-hidden=""true""></span>关闭</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                                <td>");
#nullable restore
#line 93 "E:\C#文件夹\SimpleBackOfficeAdmin\SimpleBackOfficeAdmin\Views\Home\ErrorLogs.cshtml"
                               Write(log.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 94 "E:\C#文件夹\SimpleBackOfficeAdmin\SimpleBackOfficeAdmin\Views\Home\ErrorLogs.cshtml"
                               Write(log.Loger);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 96 "E:\C#文件夹\SimpleBackOfficeAdmin\SimpleBackOfficeAdmin\Views\Home\ErrorLogs.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </section>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<LogViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
