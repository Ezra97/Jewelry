#pragma checksum "C:\Users\estol\OneDrive\Desktop\אופק ועזרא פרוייקט גמר\Jewelry\Jewelry\Views\Home\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d4988450e69df7c904d9d2c5a75be016332912c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Details), @"mvc.1.0.view", @"/Views/Home/Details.cshtml")]
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
#line 1 "C:\Users\estol\OneDrive\Desktop\אופק ועזרא פרוייקט גמר\Jewelry\Jewelry\Views\_ViewImports.cshtml"
using Jewelry;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\estol\OneDrive\Desktop\אופק ועזרא פרוייקט גמר\Jewelry\Jewelry\Views\_ViewImports.cshtml"
using Jewelry.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d4988450e69df7c904d9d2c5a75be016332912c", @"/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01a929cedc3423f6dc9c5d44906652b1d8b1169b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Jewelry.ViewModel.VMJewelAndLastPrice>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Users\estol\OneDrive\Desktop\אופק ועזרא פרוייקט גמר\Jewelry\Jewelry\Views\Home\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>פרטי תכשיט</h1>\r\n<div>\r\n    <h4></h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n");
#nullable restore
#line 10 "C:\Users\estol\OneDrive\Desktop\אופק ועזרא פרוייקט גמר\Jewelry\Jewelry\Views\Home\Details.cshtml"
         if (Model.Jewel.Photo.Count > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dt class=\"row-cols-1\"></dt>\r\n");
#nullable restore
#line 13 "C:\Users\estol\OneDrive\Desktop\אופק ועזרא פרוייקט גמר\Jewelry\Jewelry\Views\Home\Details.cshtml"
            foreach (Photo photo in Model.Jewel.Photo)
            {               

#line default
#line hidden
#nullable disable
            WriteLiteral("                <dt class=\"row-cols-1\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 413, "\"", 482, 2);
            WriteAttributeValue("", 419, "data:image;base64,", 419, 18, true);
#nullable restore
#line 16 "C:\Users\estol\OneDrive\Desktop\אופק ועזרא פרוייקט גמר\Jewelry\Jewelry\Views\Home\Details.cshtml"
WriteAttributeValue("", 437, System.Convert.ToBase64String(photo.MyPhoto), 437, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"300\" height=\"300\" />\r\n                </dt>\r\n");
#nullable restore
#line 18 "C:\Users\estol\OneDrive\Desktop\אופק ועזרא פרוייקט גמר\Jewelry\Jewelry\Views\Home\Details.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </dl>\r\n</div>\r\n<hr/>\r\n<div>\r\n    <dl class=\"col\">\r\n        <dt class=\"col-sm-2\">");
#nullable restore
#line 25 "C:\Users\estol\OneDrive\Desktop\אופק ועזרא פרוייקט גמר\Jewelry\Jewelry\Views\Home\Details.cshtml"
                        Write(Model.Jewel.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n        <dd class=\"col-sm-3\">");
#nullable restore
#line 26 "C:\Users\estol\OneDrive\Desktop\אופק ועזרא פרוייקט גמר\Jewelry\Jewelry\Views\Home\Details.cshtml"
                        Write(Model.Jewel.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n        <dd class=\"col-sm\">");
#nullable restore
#line 27 "C:\Users\estol\OneDrive\Desktop\אופק ועזרא פרוייקט גמר\Jewelry\Jewelry\Views\Home\Details.cshtml"
                      Write(Model.MaleTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n        <dd class=\"col-sm\">");
#nullable restore
#line 28 "C:\Users\estol\OneDrive\Desktop\אופק ועזרא פרוייקט גמר\Jewelry\Jewelry\Views\Home\Details.cshtml"
                      Write(Model.FemailTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n        <dd class=\"col-sm\">");
#nullable restore
#line 29 "C:\Users\estol\OneDrive\Desktop\אופק ועזרא פרוייקט גמר\Jewelry\Jewelry\Views\Home\Details.cshtml"
                      Write(Model.WeightTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n        <dd class=\"col-sm\">");
#nullable restore
#line 30 "C:\Users\estol\OneDrive\Desktop\אופק ועזרא פרוייקט גמר\Jewelry\Jewelry\Views\Home\Details.cshtml"
                      Write(Model.ColorTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n        <dd class=\"col-sm\">");
#nullable restore
#line 31 "C:\Users\estol\OneDrive\Desktop\אופק ועזרא פרוייקט גמר\Jewelry\Jewelry\Views\Home\Details.cshtml"
                      Write(Model.PriceTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n        <dd class=\"col-sm\">");
#nullable restore
#line 32 "C:\Users\estol\OneDrive\Desktop\אופק ועזרא פרוייקט גמר\Jewelry\Jewelry\Views\Home\Details.cshtml"
                      Write(Model.DiscountTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n        <dd class=\"col-sm\">");
#nullable restore
#line 33 "C:\Users\estol\OneDrive\Desktop\אופק ועזרא פרוייקט גמר\Jewelry\Jewelry\Views\Home\Details.cshtml"
                      Write(Model.FinalTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 37 "C:\Users\estol\OneDrive\Desktop\אופק ועזרא פרוייקט גמר\Jewelry\Jewelry\Views\Home\Details.cshtml"
Write(Html.ActionLink("הוסף לסל", "AddToCart", new { id = Model.Jewel.ID }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
#nullable restore
#line 38 "C:\Users\estol\OneDrive\Desktop\אופק ועזרא פרוייקט גמר\Jewelry\Jewelry\Views\Home\Details.cshtml"
Write(Html.ActionLink("חזרה ל"+Model.Jewel.Parent.Name,"Index",new { id=Model.Jewel.Parent.ID}));

#line default
#line hidden
#nullable disable
            WriteLiteral("|\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d4988450e69df7c904d9d2c5a75be016332912c8596", async() => {
                WriteLiteral("חזרה לחנות");
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
            WriteLiteral("\r\n</div>\r\n<br/>\r\n<br/>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Jewelry.ViewModel.VMJewelAndLastPrice> Html { get; private set; }
    }
}
#pragma warning restore 1591
