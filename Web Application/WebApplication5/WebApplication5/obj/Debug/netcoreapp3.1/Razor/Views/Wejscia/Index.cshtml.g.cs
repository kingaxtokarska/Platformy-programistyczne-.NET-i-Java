<<<<<<< HEAD
#pragma checksum "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2f303ae9582c0b7ff5cdb08ce2b811058935e6eb"
=======
#pragma checksum "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "79e4d3718c5674a570d0352df328fc3e355c8e6c"
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Wejscia_Index), @"mvc.1.0.view", @"/Views/Wejscia/Index.cshtml")]
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
#line 1 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\_ViewImports.cshtml"
using WebApplication5;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\_ViewImports.cshtml"
using WebApplication5.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79e4d3718c5674a570d0352df328fc3e355c8e6c", @"/Views/Wejscia/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ac7a6a20369a094c1643b76f0e92e19ec3cef6a", @"/Views/_ViewImports.cshtml")]
    public class Views_Wejscia_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApplication5.Models.Wejscia>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
 if (User.Identity.IsAuthenticated && User.Claims.FirstOrDefault(c => c.Type == "Role")?.Value == "Prezes" || User.Claims.FirstOrDefault(c => c.Type == "Role")?.Value == "Specjalista")

{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>Wejścia</h1>\r\n");
#nullable restore
#line 12 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
     using (Html.BeginForm())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>\r\n            Find: ");
#nullable restore
#line 15 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
             Write(Html.TextBox("SearchString"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <input type=\"submit\" value=\"Search\" />\r\n        </p>\r\n");
#nullable restore
#line 18 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 23 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
               Write(Html.ActionLink("Imie", "Index", new { sortOrder = ViewBag.NameSortParm }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 26 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
               Write(Html.ActionLink("Nazwisko", "Index", new { sortOrder = ViewBag.SurnameSortParm }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 29 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
               Write(Html.ActionLink("Data wejscia", "Index", new { sortOrder = ViewBag.DateSortParm }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 32 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
               Write(Html.ActionLink("Godzina wejscia", "Index", new { sortOrder = ViewBag.TimeSortParm }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 38 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 42 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.IdPracownikNavigation.Imie));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 45 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.IdPracownikNavigation.Nazwisko));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 48 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
                   Write(item.DataWejscia.ToString("yyyy-MM-dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 51 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.GodzinaWejscia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 54 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
                         if (ViewData["Rola"].ToString() == "Prezes")
                        {

#line default
#line hidden
#nullable disable
<<<<<<< HEAD
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2f303ae9582c0b7ff5cdb08ce2b811058935e6eb9780", async() => {
=======
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "79e4d3718c5674a570d0352df328fc3e355c8e6c9321", async() => {
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
<<<<<<< HEAD
#line 51 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
                                       WriteLiteral(item.IdPracownik);
=======
#line 56 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
                                                   WriteLiteral(item.IdPracownik);
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445

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
<<<<<<< HEAD
            WriteLiteral(" |\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2f303ae9582c0b7ff5cdb08ce2b811058935e6eb12054", async() => {
                WriteLiteral("Details");
=======
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "79e4d3718c5674a570d0352df328fc3e355c8e6c11527", async() => {
                WriteLiteral("Delete");
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445
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
<<<<<<< HEAD
#line 52 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
                                          WriteLiteral(item.IdPracownik);
=======
#line 57 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
                                                     WriteLiteral(item.IdPracownik);
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445

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
<<<<<<< HEAD
            WriteLiteral(" |\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2f303ae9582c0b7ff5cdb08ce2b811058935e6eb14335", async() => {
                WriteLiteral("Delete");
=======
            WriteLiteral("\r\n");
#nullable restore
#line 58 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "79e4d3718c5674a570d0352df328fc3e355c8e6c13963", async() => {
                WriteLiteral("Details");
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445
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
<<<<<<< HEAD
#line 53 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
                                         WriteLiteral(item.IdPracownik);
=======
#line 59 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
                                                  WriteLiteral(item.IdPracownik);
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445

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
            WriteLiteral("\r\n\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
<<<<<<< HEAD
#line 56 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
        }
=======
#line 63 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 66 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Wejscia\Index.cshtml"
}
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebApplication5.Models.Wejscia>> Html { get; private set; }
    }
}
#pragma warning restore 1591
