#pragma checksum "C:\Users\cman5\Desktop\Software Engineer I\GlucoSmart\Pages\Entries\Charts\GlucoseChart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "81d060cb6173fb0078533a9caac7d31b35690e3f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(GlucoSmart.Pages.Entries.Charts.Pages_Entries_Charts_GlucoseChart), @"mvc.1.0.razor-page", @"/Pages/Entries/Charts/GlucoseChart.cshtml")]
namespace GlucoSmart.Pages.Entries.Charts
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
#line 1 "C:\Users\cman5\Desktop\Software Engineer I\GlucoSmart\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\cman5\Desktop\Software Engineer I\GlucoSmart\Pages\_ViewImports.cshtml"
using GlucoSmart;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\cman5\Desktop\Software Engineer I\GlucoSmart\Pages\_ViewImports.cshtml"
using GlucoSmart.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81d060cb6173fb0078533a9caac7d31b35690e3f", @"/Pages/Entries/Charts/GlucoseChart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2cc4bd42db13b47ab15aecc275db6dffb481080", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Entries_Charts_GlucoseChart : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery-3.4.1.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/popper.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/bootstrap.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/mdb.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\cman5\Desktop\Software Engineer I\GlucoSmart\Pages\Entries\Charts\GlucoseChart.cshtml"
  
    ViewData["Title"] = "Glucose Chart";
    Layout = "~/Pages/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "81d060cb6173fb0078533a9caac7d31b35690e3f5599", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\cman5\Desktop\Software Engineer I\GlucoSmart\Pages\Entries\Charts\GlucoseChart.cshtml"
         if (User.IsInRole("Doctor"))
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <a");
                BeginWriteAttribute("href", " href=\"", 222, "\"", 276, 2);
                WriteAttributeValue("", 229, "/Entries/Glucose/Index?username=", 229, 32, true);
#nullable restore
#line 10 "C:\Users\cman5\Desktop\Software Engineer I\GlucoSmart\Pages\Entries\Charts\GlucoseChart.cshtml"
WriteAttributeValue("", 261, Model.Username, 261, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">View As Table</a>\r\n");
#nullable restore
#line 11 "C:\Users\cman5\Desktop\Software Engineer I\GlucoSmart\Pages\Entries\Charts\GlucoseChart.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\cman5\Desktop\Software Engineer I\GlucoSmart\Pages\Entries\Charts\GlucoseChart.cshtml"
         if (User.IsInRole("Patient"))
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <a href=\"/Entries/Glucose/Index\">View As Table</a>\r\n");
#nullable restore
#line 15 "C:\Users\cman5\Desktop\Software Engineer I\GlucoSmart\Pages\Entries\Charts\GlucoseChart.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"        <div class=""container"">
            <div class=""row d-flex justify-content-center mt-5"">
                <div class=""col-md-10"">
                    <canvas id=""breakfastChart""></canvas>
                </div>
            </div>
            <div class=""row d-flex justify-content-center mt-5"">
                <div class=""col-md-10"">
                    <canvas id=""lunchChart""></canvas>
                </div>
            </div>
            <div class=""row d-flex justify-content-center mt-5"">
                <div class=""col-md-10"">
                    <canvas id=""dinnerChart""></canvas>
                </div>
            </div>
        </div>

        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "81d060cb6173fb0078533a9caac7d31b35690e3f8082", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "81d060cb6173fb0078533a9caac7d31b35690e3f9272", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "81d060cb6173fb0078533a9caac7d31b35690e3f10462", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "81d060cb6173fb0078533a9caac7d31b35690e3f11653", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

        <script>
        var ctxL = document.getElementById(""breakfastChart"").getContext(""2d"");
        var gradientFill = ctxL.createLinearGradient(0, 0, 0, 290)
        gradientFill.addColorStop(0, ""rgba(173, 53, 186, 1)"");
        gradientFill.addColorStop(1, ""rgba(173, 53, 186, 0.1)"");
        var preReadings, postReadings, dates;
        preReadings = ");
#nullable restore
#line 45 "C:\Users\cman5\Desktop\Software Engineer I\GlucoSmart\Pages\Entries\Charts\GlucoseChart.cshtml"
                 Write(Html.Raw(Json.Serialize(Model.BreakfastPreReadings.ToArray())));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        postReadings = ");
#nullable restore
#line 46 "C:\Users\cman5\Desktop\Software Engineer I\GlucoSmart\Pages\Entries\Charts\GlucoseChart.cshtml"
                  Write(Html.Raw(Json.Serialize(Model.BreakfastPostReadings.ToArray())));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        dates = ");
#nullable restore
#line 47 "C:\Users\cman5\Desktop\Software Engineer I\GlucoSmart\Pages\Entries\Charts\GlucoseChart.cshtml"
           Write(Html.Raw(Json.Serialize(Model.BreakfastDates.ToArray())));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";

        var myLineChart = new Chart(ctxL, {
            type: 'line',
            data: {
                labels: dates,
                datasets: [{
                    label: ""Breakfast PreMeal Readings"",
                    data: preReadings,
                    backgroundColor: 'rgba(105, 0, 132, .2)',
                    borderColor: [
                        'rgba(200, 99, 132, .7)',
                    ],
                    borderWidth: 2
                },

                {
                    label: ""Breakfast PostMeal Readings"",
                    data: postReadings,
                    backgroundColor: [
                        'rgba(0, 137, 132, .2)'
                    ],
                    borderColor: [
                        'rgba(0, 10, 130, .7)'
                    ],
                    borderWidth: 2

                }]
            },
            options: {
                responsive: true
            }
        });
        </script>

        <scri");
                WriteLiteral(@"pt>
        var ctxL = document.getElementById(""lunchChart"").getContext(""2d"");
        var gradientFill = ctxL.createLinearGradient(0, 0, 0, 290)
        gradientFill.addColorStop(0, ""rgba(173, 53, 186, 1)"");
        gradientFill.addColorStop(1, ""rgba(173, 53, 186, 0.1)"");
        var preReadings, postReadings, dates;
        preReadings = ");
#nullable restore
#line 88 "C:\Users\cman5\Desktop\Software Engineer I\GlucoSmart\Pages\Entries\Charts\GlucoseChart.cshtml"
                 Write(Html.Raw(Json.Serialize(Model.LunchPreReadings.ToArray())));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        postReadings = ");
#nullable restore
#line 89 "C:\Users\cman5\Desktop\Software Engineer I\GlucoSmart\Pages\Entries\Charts\GlucoseChart.cshtml"
                  Write(Html.Raw(Json.Serialize(Model.LunchPostReadings.ToArray())));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        dates = ");
#nullable restore
#line 90 "C:\Users\cman5\Desktop\Software Engineer I\GlucoSmart\Pages\Entries\Charts\GlucoseChart.cshtml"
           Write(Html.Raw(Json.Serialize(Model.LunchDates.ToArray())));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";

        var myLineChart = new Chart(ctxL, {
            type: 'line',
            data: {
                labels: dates,
                datasets: [{
                    label: ""Lunch PreMeal Readings"",
                    data: preReadings,
                    backgroundColor: 'rgba(105, 0, 132, .2)',
                    borderColor: [
                        'rgba(200, 99, 132, .7)',
                    ],
                    borderWidth: 2
                },

                {
                    label: ""Lunch PostMeal Readings"",
                    data: postReadings,
                    backgroundColor: [
                        'rgba(0, 137, 132, .2)'
                    ],
                    borderColor: [
                        'rgba(0, 10, 130, .7)'
                    ],
                    borderWidth: 2

                }]
            },
            options: {
                responsive: true
            }
        });
        </script>

        <script>
   ");
                WriteLiteral(@"     var ctxL = document.getElementById(""dinnerChart"").getContext(""2d"");
        var gradientFill = ctxL.createLinearGradient(0, 0, 0, 290)
        gradientFill.addColorStop(0, ""rgba(173, 53, 186, 1)"");
        gradientFill.addColorStop(1, ""rgba(173, 53, 186, 0.1)"");
        var preReadings, postReadings, dates;
        preReadings = ");
#nullable restore
#line 131 "C:\Users\cman5\Desktop\Software Engineer I\GlucoSmart\Pages\Entries\Charts\GlucoseChart.cshtml"
                 Write(Html.Raw(Json.Serialize(Model.DinnerPreReadings.ToArray())));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        postReadings = ");
#nullable restore
#line 132 "C:\Users\cman5\Desktop\Software Engineer I\GlucoSmart\Pages\Entries\Charts\GlucoseChart.cshtml"
                  Write(Html.Raw(Json.Serialize(Model.DinnerPostReadings.ToArray())));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        dates = ");
#nullable restore
#line 133 "C:\Users\cman5\Desktop\Software Engineer I\GlucoSmart\Pages\Entries\Charts\GlucoseChart.cshtml"
           Write(Html.Raw(Json.Serialize(Model.DinnerDates.ToArray())));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";

        var myLineChart = new Chart(ctxL, {
            type: 'line',
            data: {
                labels: dates,
                datasets: [{
                    label: ""Dinner PreMeal Readings"",
                    data: preReadings,
                    backgroundColor: 'rgba(105, 0, 132, .2)',
                    borderColor: [
                        'rgba(200, 99, 132, .7)',
                    ],
                    borderWidth: 2
                },

                {
                    label: ""Dinner PostMeal Readings"",
                    data: postReadings,
                    backgroundColor: [
                        'rgba(0, 137, 132, .2)'
                    ],
                    borderColor: [
                        'rgba(0, 10, 130, .7)'
                    ],
                    borderWidth: 2

                }]
            },
            options: {
                responsive: true
            }
        });
        </script>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GlucoSmart.Pages.GlucoseChartModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GlucoSmart.Pages.GlucoseChartModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GlucoSmart.Pages.GlucoseChartModel>)PageContext?.ViewData;
        public GlucoSmart.Pages.GlucoseChartModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
