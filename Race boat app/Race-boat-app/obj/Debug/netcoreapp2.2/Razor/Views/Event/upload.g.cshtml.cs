#pragma checksum "C:\Users\user\Desktop\new boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\upload.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56428266a985f3397f49d10ece3ad0e3339406ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Event_upload), @"mvc.1.0.view", @"/Views/Event/upload.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Event/upload.cshtml", typeof(AspNetCore.Views_Event_upload))]
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
#line 1 "C:\Users\user\Desktop\new boat app\RCBR_Front_End-master\Race-boat-app\Views\_ViewImports.cshtml"
using Race_boat_app;

#line default
#line hidden
#line 2 "C:\Users\user\Desktop\new boat app\RCBR_Front_End-master\Race-boat-app\Views\_ViewImports.cshtml"
using Race_boat_app.Models;

#line default
#line hidden
#line 2 "C:\Users\user\Desktop\new boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\upload.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56428266a985f3397f49d10ece3ad0e3339406ea", @"/Views/Event/upload.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c5a3f5aabc245a5c220e2b6dae0dc8c7387a054", @"/Views/_ViewImports.cshtml")]
    public class Views_Event_upload : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EventIn>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\user\Desktop\new boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\upload.cshtml"
  
    ViewData["Title"] = "Upload File";

#line default
#line hidden
            BeginContext(92, 457, true);
            WriteLiteral(@"<h1>Register</h1>
<div class=""container py-5"">
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""row"">
                <div class=""col-md-6 mx-auto"">
                    <!-- form card login -->
                    <div class=""card rounded-0"">
                        <div class=""card-header"">
                            <h3 class=""mb-0"">Login</h3>
                        </div>
                        <div class=""card-body"">
");
            EndContext();
#line 18 "C:\Users\user\Desktop\new boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\upload.cshtml"
                             if (Context.Session.GetString("_Admin") == "true")
                            {

#line default
#line hidden
            BeginContext(659, 2153, true);
            WriteLiteral(@"                                <script src=""https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.3.1.min.js""></script>
                                <script>
                                    $(document).ready(function () {
                                        $('#btnUploadFile').on('click', function () {
                                            var data = new FormData();
                                            var files = $(""#fileUpload"").get(0).files;
                                            console.log(files);
                                            // Add the uploaded image content to the form data collection
                                            if (files.length > 0) {
                                                data.append(""UploadedImage"", files[0]);
                                            }
                                            console.log(""Here"")
                                            // Make Ajax request with the contentType = false, and procesDate = false
  ");
            WriteLiteral(@"                                          var ajaxRequest = $.ajax({
                                                type: ""POST"",
                                                url: ""Upload"",
                                                contentType: false,
                                                processData: false,
                                                data: data
                                            });
                                            ajaxRequest.done(function (xhr, textStatus) {
                                                console.log(""Here2"")
                                                // Do other operation
                                            });
                                        });
                                    });
                                </script>
                                <input class=""form-control form-control-lg rounded-0"" type=""file"" name=""FileUpload1"" id=""fileUpload"" required /><br />
                                <");
            WriteLiteral("input class=\"btn btn-success btn-lg float-right\" id=\"btnUploadFile\" type=\"button\" value=\"Upload File\" />\n");
            EndContext();
#line 49 "C:\Users\user\Desktop\new boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\upload.cshtml"
                            }

#line default
#line hidden
            BeginContext(2842, 28, true);
            WriteLiteral("                            ");
            EndContext();
#line 50 "C:\Users\user\Desktop\new boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\upload.cshtml"
                             if (Context.Session.GetString("_Admin") == "false")
                            {

#line default
#line hidden
            BeginContext(2953, 79, true);
            WriteLiteral("                                <p>You Don\'t have permision to access this</p>\n");
            EndContext();
#line 53 "C:\Users\user\Desktop\new boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\upload.cshtml"
                            }

#line default
#line hidden
            BeginContext(3062, 281, true);
            WriteLiteral(@"                        </div>
                        <!--/card-block-->
                    </div>
                    <!-- /form card login -->
                </div>
            </div>
            <!--/row-->
        </div>
        <!--/col-->
    </div>
    <!--/row-->
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EventIn> Html { get; private set; }
    }
}
#pragma warning restore 1591