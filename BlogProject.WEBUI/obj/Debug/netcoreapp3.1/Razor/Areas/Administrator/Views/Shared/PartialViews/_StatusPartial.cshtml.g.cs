#pragma checksum "C:\Users\CmR\Desktop\12.07.2021\Github Blog Projesi\BlogProject\BlogProject.WEBUI\Areas\Administrator\Views\Shared\PartialViews\_StatusPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "253c56d552162e6d06ab393df4b1faa34e101a8e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administrator_Views_Shared_PartialViews__StatusPartial), @"mvc.1.0.view", @"/Areas/Administrator/Views/Shared/PartialViews/_StatusPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Administrator/Views/Shared/PartialViews/_StatusPartial.cshtml", typeof(AspNetCore.Areas_Administrator_Views_Shared_PartialViews__StatusPartial))]
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
#line 1 "C:\Users\CmR\Desktop\12.07.2021\Github Blog Projesi\BlogProject\BlogProject.WEBUI\Areas\Administrator\Views\_ViewImports.cshtml"
using BlogProject.WEBUI;

#line default
#line hidden
#line 2 "C:\Users\CmR\Desktop\12.07.2021\Github Blog Projesi\BlogProject\BlogProject.WEBUI\Areas\Administrator\Views\_ViewImports.cshtml"
using BlogProject.WEBUI.Models;

#line default
#line hidden
#line 3 "C:\Users\CmR\Desktop\12.07.2021\Github Blog Projesi\BlogProject\BlogProject.WEBUI\Areas\Administrator\Views\_ViewImports.cshtml"
using BlogProject.MODEL.Entities;

#line default
#line hidden
#line 4 "C:\Users\CmR\Desktop\12.07.2021\Github Blog Projesi\BlogProject\BlogProject.WEBUI\Areas\Administrator\Views\_ViewImports.cshtml"
using BlogProject.CORE.Entity.Enums;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"253c56d552162e6d06ab393df4b1faa34e101a8e", @"/Areas/Administrator/Views/Shared/PartialViews/_StatusPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"343ba7ab7ff4a825ac5a1bdc8a3c2d398e24058f", @"/Areas/Administrator/Views/_ViewImports.cshtml")]
    public class Areas_Administrator_Views_Shared_PartialViews__StatusPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Status>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(15, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\CmR\Desktop\12.07.2021\Github Blog Projesi\BlogProject\BlogProject.WEBUI\Areas\Administrator\Views\Shared\PartialViews\_StatusPartial.cshtml"
 switch (Model)
{
    case Status.None:

#line default
#line hidden
            BeginContext(60, 66, true);
            WriteLiteral("        <span class=\"badge badge-primary\">İşlem Yapılmadı</span>\r\n");
            EndContext();
#line 7 "C:\Users\CmR\Desktop\12.07.2021\Github Blog Projesi\BlogProject\BlogProject.WEBUI\Areas\Administrator\Views\Shared\PartialViews\_StatusPartial.cshtml"
        break;
    case Status.Active:

#line default
#line hidden
            BeginContext(167, 56, true);
            WriteLiteral("        <span class=\"badge badge-success\">Aktif</span>\r\n");
            EndContext();
#line 10 "C:\Users\CmR\Desktop\12.07.2021\Github Blog Projesi\BlogProject\BlogProject.WEBUI\Areas\Administrator\Views\Shared\PartialViews\_StatusPartial.cshtml"
        break;
    case Status.Deleted:

#line default
#line hidden
            BeginContext(265, 55, true);
            WriteLiteral("        <span class=\"badge badge-danger\">Pasif</span>\r\n");
            EndContext();
#line 13 "C:\Users\CmR\Desktop\12.07.2021\Github Blog Projesi\BlogProject\BlogProject.WEBUI\Areas\Administrator\Views\Shared\PartialViews\_StatusPartial.cshtml"
        break;
    case Status.Updated:

#line default
#line hidden
            BeginContext(362, 62, true);
            WriteLiteral("        <span class=\"badge badge-warning\">Güncellendi</span>\r\n");
            EndContext();
#line 16 "C:\Users\CmR\Desktop\12.07.2021\Github Blog Projesi\BlogProject\BlogProject.WEBUI\Areas\Administrator\Views\Shared\PartialViews\_StatusPartial.cshtml"
        break;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Status> Html { get; private set; }
    }
}
#pragma warning restore 1591