#pragma checksum "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3d50d306d02705645a03ab28afc4a06e9566e5e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Event_Events), @"mvc.1.0.view", @"/Views/Event/Events.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Event/Events.cshtml", typeof(AspNetCore.Views_Event_Events))]
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
#line 1 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\_ViewImports.cshtml"
using Race_boat_app;

#line default
#line hidden
#line 2 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\_ViewImports.cshtml"
using Race_boat_app.Models;

#line default
#line hidden
#line 2 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d50d306d02705645a03ab28afc4a06e9566e5e1", @"/Views/Event/Events.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c5a3f5aabc245a5c220e2b6dae0dc8c7387a054", @"/Views/_ViewImports.cshtml")]
    public class Views_Event_Events : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Download>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("eventSID1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("eventSID2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("eventSID3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
  
    ViewData["Title"] = "Events";
    var eventRegs = ViewData["eventRegs"] as List<EventReg>;


#line default
#line hidden
            BeginContext(150, 30, true);
            WriteLiteral("\n\n\n\n\n<ul  hidden id=\"events\">\n");
            EndContext();
#line 14 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
     foreach (var element in eventRegs)
    {

#line default
#line hidden
            BeginContext(226, 23, true);
            WriteLiteral("        <li data-store=");
            EndContext();
            BeginContext(250, 15, false);
#line 16 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
                  Write(element.EventID);

#line default
#line hidden
            EndContext();
            BeginContext(265, 7, true);
            WriteLiteral("></li>\n");
            EndContext();
#line 17 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
    }

#line default
#line hidden
            BeginContext(278, 29, true);
            WriteLiteral("</ul>\n<ul hidden id=\"teams\">\n");
            EndContext();
#line 20 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
     foreach (var element in eventRegs)
    {

#line default
#line hidden
            BeginContext(353, 23, true);
            WriteLiteral("        <li data-store=");
            EndContext();
            BeginContext(377, 14, false);
#line 22 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
                  Write(element.TeamID);

#line default
#line hidden
            EndContext();
            BeginContext(391, 7, true);
            WriteLiteral("></li>\n");
            EndContext();
#line 23 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
    }

#line default
#line hidden
            BeginContext(404, 47, true);
            WriteLiteral("</ul>\n<ul hidden id=\"user\">\n    <li data-store=");
            EndContext();
            BeginContext(452, 34, false);
#line 26 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
              Write(Context.Session.GetString("_Team"));

#line default
#line hidden
            EndContext();
            BeginContext(486, 43, true);
            WriteLiteral("></li>\n</ul>\n\n\n<div id=\'calendar\'></div>\n\n\n");
            EndContext();
            BeginContext(1215, 1438, true);
            WriteLiteral(@"
<div class=""modal"" id=""calendarModal"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">

            <!-- Modal Header -->
            <div class=""modal-header"">
                <h4 class=""modal-title"" id=""modalTitle""></h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>

            <!-- Modal body -->
            <div id=""modalBody"" class=""modal-body"">
                <div class=""col-md-12"">
                    <span class=""col-md-4"">Location</span>:
                    <span class=""col-md-7"" id=""eventLoc""></span>
                </div>
                <div class=""col-md-12"">
                    <span class=""col-md-4"">Date</span>:
                    <span class=""col-md-7"" id=""eventDate""></span>
                </div>
                <div class=""col-md-12"">
                    <span class=""col-md-4"">Start Time</span>:
                    <span class=""col-md-7"" id=""eventSTime""></span>
                </div>
                <div c");
            WriteLiteral(@"lass=""col-md-12"">
                    <span class=""col-md-4"">End Time</span>:
                    <span class=""col-md-7"" id=""eventETime""></span>
                </div>
                <div class=""col-md-12"">
                    <span class=""col-md-4"">Desc</span>:
                    <span class=""col-md-7"" id=""eventDesc""></span>
                </div>
                <div class=""col-md-12"">

                    ");
            EndContext();
            BeginContext(2653, 273, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3d50d306d02705645a03ab28afc4a06e9566e5e19871", async() => {
                BeginContext(2701, 25, true);
                WriteLiteral("\n                        ");
                EndContext();
                BeginContext(2726, 60, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3d50d306d02705645a03ab28afc4a06e9566e5e110277", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#line 83 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2786, 133, true);
                WriteLiteral("\n                        <button type=\"submit\" class=\"btn btn-success btn-sm float-left\">Download Flyer</button>\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 82 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
AddHtmlAttributeValue("", 2667, Url.Action("Download", "Event"), 2667, 32, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2926, 119, true);
            WriteLiteral("\n\n                </div>\n            </div>\n\n            <!-- Modal footer -->\n            <div class=\"modal-footer\">\n\n");
            EndContext();
#line 93 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
                 if (Context.Session.GetString("_LoggedIn") == "true" && Context.Session.GetString("_Team") != "null")
                {

#line default
#line hidden
            BeginContext(3182, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(3202, 418, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3d50d306d02705645a03ab28afc4a06e9566e5e114597", async() => {
                BeginContext(3268, 26, true);
                WriteLiteral("\n\n                        ");
                EndContext();
                BeginContext(3294, 60, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3d50d306d02705645a03ab28afc4a06e9566e5e115006", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#line 97 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3354, 25, true);
                WriteLiteral("\n                        ");
                EndContext();
                BeginContext(3379, 82, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3d50d306d02705645a03ab28afc4a06e9566e5e117158", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                BeginWriteTagHelperAttribute();
#line 98 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
                         WriteLiteral(Context.Session.GetString("_Team"));

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#line 98 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.TeamId);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3461, 152, true);
                WriteLiteral("\n                        <input type=\"submit\" class=\"btn btn-success btn-sm float-left\" id=\"RegButton\" name=\"\" value=\"Register\" />\n\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 95 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
AddHtmlAttributeValue("", 3230, Url.Action("RegisterTeam", "Event"), 3230, 36, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3620, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 102 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
                }

#line default
#line hidden
            BeginContext(3639, 16, true);
            WriteLiteral("                ");
            EndContext();
#line 103 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
                 if (Context.Session.GetString("_Admin") == "true")
                {

#line default
#line hidden
            BeginContext(3725, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(3745, 305, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3d50d306d02705645a03ab28afc4a06e9566e5e122188", async() => {
                BeginContext(3808, 26, true);
                WriteLiteral("\n\n                        ");
                EndContext();
                BeginContext(3834, 60, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3d50d306d02705645a03ab28afc4a06e9566e5e122597", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#line 107 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3894, 149, true);
                WriteLiteral("\n                        <input type=\"submit\" class=\"btn btn-success btn-sm float-left\" id=\"EditButton\" name=\"\" value=\"Edit\" />\n\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 105 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
AddHtmlAttributeValue("", 3773, Url.Action("EditEvent", "Event"), 3773, 33, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4050, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 111 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
                }

#line default
#line hidden
            BeginContext(4069, 412, true);
            WriteLiteral(@"                
                <button type=""button"" class=""btn btn-danger"" data-dismiss=""modal"">Close</button>
            </div>

        </div>
    </div>
</div>

<script>
        function RegisterEvent()
            {
                //var dataRow = {
                //    'id': EventID,
                //    'NewEventStart': EventStart,
                //    'NewEventEnd': EventEnd
                //}
");
            EndContext();
            BeginContext(4846, 931, true);
            WriteLiteral(@"
                //$.ajax({
                //    type: ""POST"",
                //    url: url,
                //    data: EventID,
                //    cache: false,
                //    dataType: 'json',
                //    success: function (result) {
                //        if (result == '200') {
                //            alert('successfuly inserted');
                //        }
                //        else {
                //            alert('some error occured');
                //        }
                //    }
                //});

                //$.ajax({
                //    url: '/Event/ViewEvent/' + EventID,
                //}).done(function () {

                //});
                var eId = sessionStorage.getItem('e_id');
                console.log(""ssid"", eId);
                $.ajax({
                type: ""POST"",
                url: 'viewEvent/'+eId,
                //url: '");
            EndContext();
            BeginContext(5778, 23, false);
#line 168 "C:\Users\user\Desktop\2303 boat app\RCBR_Front_End-master\Race-boat-app\Views\Event\Events.cshtml"
                   Write(Url.Action("ViewEvent"));

#line default
#line hidden
            EndContext();
            BeginContext(5801, 374, true);
            WriteLiteral(@"',
                dataType: ""json"",
                contentType: ""application/json; charset=utf-8"",
                success: function (data) {
                alert(data);
                },
                failure: function (errMsg) {
                alert(errMsg);
                }
                }).done(function () {

                });
                }
</script>

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Download> Html { get; private set; }
    }
}
#pragma warning restore 1591
