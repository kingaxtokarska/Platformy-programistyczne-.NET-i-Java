<<<<<<< HEAD
#pragma checksum "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e55d941aa63b62e9e307176c13fe94c0d748ee8a"
=======
#pragma checksum "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7150a7f70aa33ec41917163d6b5ed0541d238bcf"
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Godzinypracy_Worktime), @"mvc.1.0.view", @"/Views/Godzinypracy/Worktime.cshtml")]
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
#line 1 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\_ViewImports.cshtml"
using WebApplication5;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\_ViewImports.cshtml"
using WebApplication5.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7150a7f70aa33ec41917163d6b5ed0541d238bcf", @"/Views/Godzinypracy/Worktime.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ac7a6a20369a094c1643b76f0e92e19ec3cef6a", @"/Views/_ViewImports.cshtml")]
    public class Views_Godzinypracy_Worktime : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApplication5.Models.Podsumowanie>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
  
    ViewData["Title"] = "Worktime";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
<<<<<<< HEAD
#line 10 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
 using (Html.BeginForm())
=======
#line 7 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
 if (User.Identity.IsAuthenticated && User.Claims.FirstOrDefault(c => c.Type == "Role")?.Value == "Prezes" || User.Claims.FirstOrDefault(c => c.Type == "Role")?.Value == "Specjalista")
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>Podsumowanie miesięczne</h1>\r\n");
#nullable restore
#line 12 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
     using (Html.BeginForm())
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>\r\n            <input name=\"data\" type=\"month\" value=\"Search\" />\r\n            <input type=\"submit\" value=\"Search\" />\r\n        </p>\r\n");
#nullable restore
<<<<<<< HEAD
#line 17 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
=======
#line 19 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
<<<<<<< HEAD
#line 24 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
           Write(Html.DisplayNameFor(model => model.IdPracownik));
=======
#line 26 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
               Write(Html.DisplayNameFor(model => model.IdPracownik));
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
<<<<<<< HEAD
#line 27 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
           Write(Html.DisplayNameFor(model => model.Imie));
=======
#line 29 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
               Write(Html.DisplayNameFor(model => model.Imie));
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
<<<<<<< HEAD
#line 30 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
           Write(Html.DisplayNameFor(model => model.Nazwisko));
=======
#line 32 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
               Write(Html.DisplayNameFor(model => model.Nazwisko));
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
<<<<<<< HEAD
#line 33 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
           Write(Html.DisplayNameFor(model => model.CzasPracy));
=======
#line 35 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
               Write(Html.DisplayNameFor(model => model.CzasPracy));
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
<<<<<<< HEAD
#line 36 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
           Write(Html.DisplayNameFor(model => model.Nadgodziny));
=======
#line 38 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
               Write(Html.DisplayNameFor(model => model.Nadgodziny));
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
<<<<<<< HEAD
#line 39 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
           Write(Html.DisplayNameFor(model => model.Wynagrodzenie));
=======
#line 41 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
               Write(Html.DisplayNameFor(model => model.Wynagrodzenie));
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
<<<<<<< HEAD
#line 42 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
           Write(Html.DisplayNameFor(model => model.WynagrodzenieEuro));
=======
#line 44 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
               Write(Html.DisplayNameFor(model => model.WynagrodzenieEuro));
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
<<<<<<< HEAD
#line 48 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
         foreach (var item in Model)
        {
=======
#line 50 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
             foreach (var item in Model)
            {
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
<<<<<<< HEAD
#line 52 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
               Write(Html.DisplayFor(modelItem => item.IdPracownik));
=======
#line 54 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
                   Write(Html.DisplayFor(modelItem => item.IdPracownik));
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
<<<<<<< HEAD
#line 55 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
               Write(Html.DisplayFor(modelItem => item.Imie));
=======
#line 57 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Imie));
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
<<<<<<< HEAD
#line 58 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
               Write(Html.DisplayFor(modelItem => item.Nazwisko));
=======
#line 60 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Nazwisko));
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
<<<<<<< HEAD
#line 61 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
               Write(item.CzasPracy.ToString("F"));
=======
#line 63 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
                   Write(item.CzasPracy.ToString("F"));
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
<<<<<<< HEAD
#line 64 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
               Write(item.Nadgodziny.ToString("F"));
=======
#line 66 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
                   Write(item.Nadgodziny.ToString("F"));
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
<<<<<<< HEAD
#line 67 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
               Write(item.Wynagrodzenie.ToString("F"));
=======
#line 69 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
                   Write(item.Wynagrodzenie.ToString("F"));
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
<<<<<<< HEAD
#line 70 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
               Write(item.WynagrodzenieEuro.ToString("F"));
=======
#line 72 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
                   Write(item.WynagrodzenieEuro.ToString("F"));
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
<<<<<<< HEAD
#line 73 "C:\Users\pszcz\Desktop\materiały pwr\6 SEMESTR\PP.NiJ\MOJE I KINGI\Platformy-programistyczne-.NET-i-Java\Web Application\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
        }
=======
#line 75 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 78 "C:\Users\kinga\OneDrive\Pulpit\WebApplication5\WebApplication5\Views\Godzinypracy\Worktime.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebApplication5.Models.Podsumowanie>> Html { get; private set; }
    }
}
#pragma warning restore 1591
