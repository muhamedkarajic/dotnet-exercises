#pragma checksum "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3176daf542cc45c68ee6cf95c71f83fe425e75aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Takmicenje_RezultatiTakmicenja), @"mvc.1.0.view", @"/Views/Takmicenje/RezultatiTakmicenja.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Takmicenje/RezultatiTakmicenja.cshtml", typeof(AspNetCore.Views_Takmicenje_RezultatiTakmicenja))]
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
#line 1 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
using RS1_Ispit_asp.net_core.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3176daf542cc45c68ee6cf95c71f83fe425e75aa", @"/Views/Takmicenje/RezultatiTakmicenja.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0909514ccbe15c9b46987fb6fc827edf50cf04a", @"/Views/_ViewImports.cshtml")]
    public class Views_Takmicenje_RezultatiTakmicenja : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RezultatiTakmicenjaTabelaVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ZakljucajRezultate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "TogglePrisustvo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-prisustvo", "false", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-prisustvo", "true", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(79, 97, true);
            WriteLiteral("\r\n\r\n<table class=\"table table-striped\">\r\n    <tr>\r\n        <td>Škola domaćin: </td>\r\n        <td>");
            EndContext();
            BeginContext(177, 18, false);
#line 8 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
       Write(Model.SkolaDomacin);

#line default
#line hidden
            EndContext();
            BeginContext(195, 68, true);
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Predmet: </td>\r\n        <td>");
            EndContext();
            BeginContext(264, 18, false);
#line 12 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
       Write(Model.PredmetNaziv);

#line default
#line hidden
            EndContext();
            BeginContext(282, 67, true);
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Razred: </td>\r\n        <td>");
            EndContext();
            BeginContext(350, 12, false);
#line 16 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
       Write(Model.Razred);

#line default
#line hidden
            EndContext();
            BeginContext(362, 66, true);
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Datum: </td>\r\n        <td>");
            EndContext();
            BeginContext(429, 34, false);
#line 20 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
       Write(Model.Datum.ToString("dd.MM.yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(463, 54, true);
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(517, 154, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c30b37223144d1db2fd358bbe2c0404", async() => {
                BeginContext(626, 41, true);
                WriteLiteral("\r\n                Zaključaj\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "hidden", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 24 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
AddHtmlAttributeValue("", 528, Model.Zakljucano, 528, 19, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-takmicenjeId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 24 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
                                                                                        WriteLiteral(Model.takmicenjeId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["takmicenjeId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-takmicenjeId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["takmicenjeId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(671, 453, true);
            WriteLiteral(@"
        </td>
        <td> </td>
    </tr>

</table>


<table class=""table table-striped"">
    <thead>
        <tr>
            <th>Odjeljenje</th>
            <th>
                Broj u
                dnevniku P
            </th>
            <th>Pristupio </th>
            <th>
                Rezultat bodovi
                (max 100)
            </th>
            <th>Akcija</th>
        </tr>
    </thead>

    <tbody>
");
            EndContext();
#line 52 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
         foreach (var red in Model.RezultatiTakmicenjaRedovi)
        {

#line default
#line hidden
            BeginContext(1198, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(1237, 14, false);
#line 55 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
               Write(red.Odjeljenje);

#line default
#line hidden
            EndContext();
            BeginContext(1251, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1279, 17, false);
#line 56 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
               Write(red.BrojUDnevniku);

#line default
#line hidden
            EndContext();
            BeginContext(1296, 9, true);
            WriteLiteral("</td>\r\n\r\n");
            EndContext();
#line 58 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
                 if (@red.Pristupio == true)
                {

#line default
#line hidden
            BeginContext(1370, 50, true);
            WriteLiteral("                    <td>\r\n                        ");
            EndContext();
            BeginContext(1420, 266, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f292eb0805504f7898883ffa81ee9910", async() => {
                BeginContext(1552, 37, true);
                WriteLiteral("\r\n                            <button");
                EndContext();
                BeginWriteAttribute("disabled", " disabled=\"", 1589, "\"", 1619, 1);
#line 62 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
WriteAttributeValue("", 1600, Model.Zakljucano, 1600, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1620, 59, true);
                WriteLiteral(" class=\"btn btn-info\">DA</button>\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-takmicenjeUcenikId", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 61 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
                                                                                           WriteLiteral(red.TakmicenjeUcenikId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["takmicenjeUcenikId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-takmicenjeUcenikId", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["takmicenjeUcenikId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-prisustvo", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["prisustvo"] = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1686, 29, true);
            WriteLiteral("\r\n                    </td>\r\n");
            EndContext();
#line 65 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(1775, 50, true);
            WriteLiteral("                    <td>\r\n                        ");
            EndContext();
            BeginContext(1825, 268, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "83cbd09fdbd24e61b61fe09afa3b2931", async() => {
                BeginContext(1957, 37, true);
                WriteLiteral("\r\n                            <button");
                EndContext();
                BeginWriteAttribute("disabled", " disabled=\"", 1994, "\"", 2024, 1);
#line 70 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
WriteAttributeValue("", 2005, Model.Zakljucano, 2005, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2025, 61, true);
                WriteLiteral(" class=\"btn btn-danger\">NE</button>\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-takmicenjeUcenikId", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 69 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
                                                                                            WriteLiteral(red.TakmicenjeUcenikId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["takmicenjeUcenikId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-takmicenjeUcenikId", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["takmicenjeUcenikId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-prisustvo", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["prisustvo"] = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2093, 29, true);
            WriteLiteral("\r\n                    </td>\r\n");
            EndContext();
#line 73 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
                }

#line default
#line hidden
            BeginContext(2141, 20, true);
            WriteLiteral("                <td>");
            EndContext();
            BeginContext(2161, 87, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "422adc08c2d244cf921a51bb19f1b7fb", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 74 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => red.Bodovi);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onchange", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2200, "prikaziBodove(this,", 2200, 19, true);
#line 74 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
AddHtmlAttributeValue(" ", 2219, red.TakmicenjeUcenikId, 2220, 23, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 2243, ")", 2243, 1, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2248, 56, true);
            WriteLiteral("</td>\r\n                <td>\r\n                    <button");
            EndContext();
            BeginWriteAttribute("disabled", " disabled=\"", 2304, "\"", 2352, 1);
#line 76 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
WriteAttributeValue("", 2315, Model.Zakljucano || !red.Pristupio, 2315, 37, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2353, 21, true);
            WriteLiteral(" class=\"btn btn-info\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2374, "\"", 2431, 3);
            WriteAttributeValue("", 2384, "dodajUcenikaFormToggle(", 2384, 23, true);
#line 76 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
WriteAttributeValue("", 2407, red.TakmicenjeUcenikId, 2407, 23, false);

#line default
#line hidden
            WriteAttributeValue("", 2430, ")", 2430, 1, true);
            EndWriteAttribute();
            BeginContext(2432, 59, true);
            WriteLiteral(">Uredi</button>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 79 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
        }

#line default
#line hidden
            BeginContext(2502, 670, true);
            WriteLiteral(@"    </tbody>
</table>

<script>
    function prikaziBodove(e, takmicenjeUcenikId) {
        let bodovi = $(e).val();
        console.log(""bodovi:"", bodovi, ""takmicenjeUcenikId"", takmicenjeUcenikId);
        $.ajax({
            url: '/Takmicenje/AzurirajBodoveUcenika',
            data: {
                takmicenjeUcenikId: takmicenjeUcenikId,
                bodovi: bodovi
            },
            success: function (data) {
                $('body').html(data);
                console.log(""SUCCESS!"");
            },
            method: 'POST'
        })

    }

</script>

<button class=""btn btn-info"" onclick=""dodajUcenikaFormToggle(0)""");
            EndContext();
            BeginWriteAttribute("disabled", " disabled=\"", 3172, "\"", 3202, 1);
#line 104 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
WriteAttributeValue("", 3183, Model.Zakljucano, 3183, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3203, 303, true);
            WriteLiteral(@">Dodaj ucenika</button>



<div id=""dodajUcenikaFormParent2"">

</div>


<script>
    function dodajUcenikaFormToggle(takmicenjeUcenikId) {
        console.log(""RUNNED!"");
        $.ajax({
            url: '/Takmicenje/DodajUrediUcenika',
            data: {
                takmicenjeId: ");
            EndContext();
            BeginContext(3507, 18, false);
#line 119 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
                         Write(Model.takmicenjeId);

#line default
#line hidden
            EndContext();
            BeginContext(3525, 84, true);
            WriteLiteral(",\r\n                takmicenjeUcenikId: takmicenjeUcenikId,\r\n                razred: ");
            EndContext();
            BeginContext(3610, 12, false);
#line 121 "C:\Users\HP\Documents\GitHub\Razvoj-Softvera-I\Ispiti\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Takmicenje\RezultatiTakmicenja.cshtml"
                   Write(Model.Razred);

#line default
#line hidden
            EndContext();
            BeginContext(3622, 202, true);
            WriteLiteral(",\r\n            },\r\n            success: function (data) {\r\n                console.log(data);\r\n                $(\'#dodajUcenikaFormParent2\').html(data);\r\n            }\r\n        });\r\n    }\r\n\r\n\r\n</script>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RezultatiTakmicenjaTabelaVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
