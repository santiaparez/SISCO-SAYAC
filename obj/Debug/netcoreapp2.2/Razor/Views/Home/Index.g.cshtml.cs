#pragma checksum "C:\Users\santiago\source\repos\SISCO-SAYACv3.5\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82f83a404cb560cca9e4ab24a800257f55d94e72"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\santiago\source\repos\SISCO-SAYACv3.5\Views\_ViewImports.cshtml"
using SISCO_SAYACv3._5;

#line default
#line hidden
#line 2 "C:\Users\santiago\source\repos\SISCO-SAYACv3.5\Views\_ViewImports.cshtml"
using SISCO_SAYACv3._5.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82f83a404cb560cca9e4ab24a800257f55d94e72", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3366503af605cef63ab97eeceaa7e13cf93ec3e7", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\santiago\source\repos\SISCO-SAYACv3.5\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Inicio";

#line default
#line hidden
            BeginContext(42, 1461, true);
            WriteLiteral(@"
<main role=""main"">

    <!-- Main jumbotron for a primary marketing message or call to action -->
    <div class=""jumbotron"">
        <div class=""container"">
            <h1 class=""display-3""> SISCO-SAYAC</h1>
            <p>Aqui una pequeña descripcion de lo que es SISCO-SAYAC.</p>
            <p><a class=""btn btn-primary btn-lg"" href=""#"" role=""button"">Quieres saber mas? &raquo;</a></p>
        </div>
    </div>

    <div class=""container"">
        <!-- Example row of columns -->
        <div class=""row"">
            <div class=""col-md-3"">
                <h2>Obras</h2>
                
                <p><a class=""btn btn-secondary"" href=""Obras"" role=""button"">Detalles &raquo;</a></p>
            </div>
            <div class=""col-md-3"">
                <h2>Contratistas</h2>
                
                <p><a class=""btn btn-secondary"" href=""Contratistas"" role=""button"">Detalles &raquo;</a></p>
            </div>
            <div class=""col-md-3"">
                <h2>Contratos</h");
            WriteLiteral(@"2>
                
                <p><a class=""btn btn-secondary"" href=""Contratos"" role=""button"">Detalles &raquo;</a></p>
            </div>
            <div class=""col-md-3"">
                <h2>Reportes</h2>
                
                <p><a class=""btn btn-secondary"" href=""Reportes"" role=""button"">Detalles &raquo;</a></p>
            </div>
        </div>

        <hr>

    </div> <!-- /container -->

</main>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
