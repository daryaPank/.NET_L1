#pragma checksum "C:\Users\Darya\Desktop\универ\3 курс\ДОТНЕТ\Новая папка\Library\Views\BookAuthor\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9080f6b5c3b655c4fa6aa6ce17b92759c1383da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BookAuthor_Index), @"mvc.1.0.view", @"/Views/BookAuthor/Index.cshtml")]
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
#line 1 "C:\Users\Darya\Desktop\универ\3 курс\ДОТНЕТ\Новая папка\Library\Views\_ViewImports.cshtml"
using Library;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Darya\Desktop\универ\3 курс\ДОТНЕТ\Новая папка\Library\Views\_ViewImports.cshtml"
using Library.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9080f6b5c3b655c4fa6aa6ce17b92759c1383da", @"/Views/BookAuthor/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dadb7a731bfbb305c411bc5eb7a307dbd6008a89", @"/Views/_ViewImports.cshtml")]
    public class Views_BookAuthor_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BusinessInterop.Data.BookAuthorDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Darya\Desktop\универ\3 курс\ДОТНЕТ\Новая папка\Library\Views\BookAuthor\Index.cshtml"
  
    ViewData["Title"] = "Авторство";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n\r\n<h2  style=\"font-size:x-large; color:#dda0dd;\">Авторство</h2>\r\n\r\n<hr />\r\n\r\n<div class=\"container\" style=\"border-radius: 5px\">\r\n    \r\n            <div align=\"center\">\r\n                ");
#nullable restore
#line 16 "C:\Users\Darya\Desktop\универ\3 курс\ДОТНЕТ\Новая папка\Library\Views\BookAuthor\Index.cshtml"
           Write(Html.ActionLink("Добавить", "Create", "BookAuthor", null, new { @class = "btn btn-outline-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n</div>\r\n\r\n<div class=\"main\" style=\"display:flex; flex-direction:row; align-content:center; flex-wrap:wrap; padding:5px;\">\r\n");
#nullable restore
#line 21 "C:\Users\Darya\Desktop\универ\3 курс\ДОТНЕТ\Новая папка\Library\Views\BookAuthor\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div style=\"width:150px; height:150px; margin:5px; border:2px solid #dda0dd; \">\r\n            <p style=\"text-align:center\">");
#nullable restore
#line 24 "C:\Users\Darya\Desktop\универ\3 курс\ДОТНЕТ\Новая папка\Library\Views\BookAuthor\Index.cshtml"
                                    Write(item.Book.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n            <p style=\"text-align:center\">");
#nullable restore
#line 25 "C:\Users\Darya\Desktop\универ\3 курс\ДОТНЕТ\Новая папка\Library\Views\BookAuthor\Index.cshtml"
                                    Write(item.Author.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <div align=\"center\">\r\n                ");
#nullable restore
#line 27 "C:\Users\Darya\Desktop\универ\3 курс\ДОТНЕТ\Новая папка\Library\Views\BookAuthor\Index.cshtml"
           Write(Html.ActionLink("Редактировать", "Update", new { id = item.Id }, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 30 "C:\Users\Darya\Desktop\универ\3 курс\ДОТНЕТ\Новая папка\Library\Views\BookAuthor\Index.cshtml"
        
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BusinessInterop.Data.BookAuthorDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
