#pragma checksum "C:\Users\comfy\Desktop\Net\Lab3\PhotoAndVideoServices\PhotoAndVideoServices\Views\Shared\_ServiceTypeAdditionsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9303f962089fe972e2ca679fe0c3b9ceb1a7e71e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ServiceTypeAdditionsPartial), @"mvc.1.0.view", @"/Views/Shared/_ServiceTypeAdditionsPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_ServiceTypeAdditionsPartial.cshtml", typeof(AspNetCore.Views_Shared__ServiceTypeAdditionsPartial))]
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
#line 1 "C:\Users\comfy\Desktop\Net\Lab3\PhotoAndVideoServices\PhotoAndVideoServices\Views\_ViewImports.cshtml"
using PhotoAndVideoServices;

#line default
#line hidden
#line 2 "C:\Users\comfy\Desktop\Net\Lab3\PhotoAndVideoServices\PhotoAndVideoServices\Views\_ViewImports.cshtml"
using PhotoAndVideoServices.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9303f962089fe972e2ca679fe0c3b9ceb1a7e71e", @"/Views/Shared/_ServiceTypeAdditionsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9883fcafc79c6e52e6c8d5c2f41de6de129b6614", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ServiceTypeAdditionsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AdditionPM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(27, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\comfy\Desktop\Net\Lab3\PhotoAndVideoServices\PhotoAndVideoServices\Views\Shared\_ServiceTypeAdditionsPartial.cshtml"
  
    var additions = (List<AdditionPM>)Model;

#line default
#line hidden
            BeginContext(82, 1248, true);
            WriteLiteral(@"
<script>
    $(document).ready(function () {
        $("".addition-span"").click(function () {
            $(this).prev().trigger(""click"");
            //var clickedAdditionCheckedProp = $(this).prev().prop(""checked"");
            //var clickedAdditionPrice = $(this).prev().attr(""data-price"");
            //var summ = $(""#price"").val();
            //if (clickedAdditionCheckedProp == true) {
            //    $(""#price"").val(Number(summ) + Number(clickedAdditionPrice));
            //}
            //else if (clickedAdditionCheckedProp == false) {
            //    $(""#price"").val(Number(summ) - Number(clickedAdditionPrice));
            //}
        });

        $("".addition-input"").click(function () {
            var clickedAdditionCheckedProp = $(this).prop(""checked"");
            var clickedAdditionPrice = $(this).attr(""data-price"");
            var summ = $(""#price"").val();
            if (clickedAdditionCheckedProp == true) {
                $(""#price"").val(Number(summ) + Number(clicke");
            WriteLiteral("dAdditionPrice));\r\n            }\r\n            else if (clickedAdditionCheckedProp == false) {\r\n                $(\"#price\").val(Number(summ) - Number(clickedAdditionPrice));\r\n            }\r\n        });\r\n    });\r\n</script>\r\n\r\n");
            EndContext();
#line 37 "C:\Users\comfy\Desktop\Net\Lab3\PhotoAndVideoServices\PhotoAndVideoServices\Views\Shared\_ServiceTypeAdditionsPartial.cshtml"
 if (additions.Count != 0)
{

#line default
#line hidden
            BeginContext(1361, 167, true);
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"ml-4 mt-2\">\r\n            Добавить в основной пакет:\r\n        </div>\r\n    </div>\r\n    <div class=\"row addition-checkboxes\">\r\n");
            EndContext();
#line 45 "C:\Users\comfy\Desktop\Net\Lab3\PhotoAndVideoServices\PhotoAndVideoServices\Views\Shared\_ServiceTypeAdditionsPartial.cshtml"
         foreach (var addition in additions)
        {

#line default
#line hidden
            BeginContext(1585, 123, true);
            WriteLiteral("            <div class=\"col-12 p-2 pl-5\">\r\n                <input name=\"additionIds\" class=\"addition-input\" type=\"checkbox\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1708, "\"", 1728, 1);
#line 48 "C:\Users\comfy\Desktop\Net\Lab3\PhotoAndVideoServices\PhotoAndVideoServices\Views\Shared\_ServiceTypeAdditionsPartial.cshtml"
WriteAttributeValue("", 1716, addition.Id, 1716, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1729, 13, true);
            WriteLiteral(" data-price=\"");
            EndContext();
            BeginContext(1743, 14, false);
#line 48 "C:\Users\comfy\Desktop\Net\Lab3\PhotoAndVideoServices\PhotoAndVideoServices\Views\Shared\_ServiceTypeAdditionsPartial.cshtml"
                                                                                                             Write(addition.Price);

#line default
#line hidden
            EndContext();
            BeginContext(1757, 50, true);
            WriteLiteral("\" />\r\n                <span class=\"addition-span\">");
            EndContext();
            BeginContext(1808, 13, false);
#line 49 "C:\Users\comfy\Desktop\Net\Lab3\PhotoAndVideoServices\PhotoAndVideoServices\Views\Shared\_ServiceTypeAdditionsPartial.cshtml"
                                       Write(addition.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1821, 2, true);
            WriteLiteral(" +");
            EndContext();
            BeginContext(1824, 14, false);
#line 49 "C:\Users\comfy\Desktop\Net\Lab3\PhotoAndVideoServices\PhotoAndVideoServices\Views\Shared\_ServiceTypeAdditionsPartial.cshtml"
                                                       Write(addition.Price);

#line default
#line hidden
            EndContext();
            BeginContext(1838, 35, true);
            WriteLiteral("</span><br />\r\n            </div>\r\n");
            EndContext();
#line 51 "C:\Users\comfy\Desktop\Net\Lab3\PhotoAndVideoServices\PhotoAndVideoServices\Views\Shared\_ServiceTypeAdditionsPartial.cshtml"
        }

#line default
#line hidden
            BeginContext(1884, 12, true);
            WriteLiteral("    </div>\r\n");
            EndContext();
#line 53 "C:\Users\comfy\Desktop\Net\Lab3\PhotoAndVideoServices\PhotoAndVideoServices\Views\Shared\_ServiceTypeAdditionsPartial.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AdditionPM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
