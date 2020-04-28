#pragma checksum "C:\Users\PC COMPUTER\Source\Repos\BankZdjecOlsztyn\Views\Home\Mapa.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61d8d83c9a2ea35ca1f3569986dfaafdb6b807a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Mapa), @"mvc.1.0.view", @"/Views/Home/Mapa.cshtml")]
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
#line 1 "C:\Users\PC COMPUTER\Source\Repos\BankZdjecOlsztyn\Views\_ViewImports.cshtml"
using BankZdjecOlsztyn;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PC COMPUTER\Source\Repos\BankZdjecOlsztyn\Views\_ViewImports.cshtml"
using BankZdjecOlsztyn.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61d8d83c9a2ea35ca1f3569986dfaafdb6b807a1", @"/Views/Home/Mapa.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1889a5756d402158db50260cca3241e0a95159e6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Mapa : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div id=""map"" class=""map col-12""></div>
<script type=""text/javascript"">
    var mcdonald = new ol.Feature({
        geometry: new ol.geom.Point(ol.proj.fromLonLat([20.47746, 53.77309]))
      });

      var wydzial = new ol.Feature({
          geometry: new ol.geom.Point(ol.proj.fromLonLat([20.45594,53.74374]))
      });

      var plywalnia = new ol.Feature({
          geometry: new ol.geom.Point(ol.proj.fromLonLat([20.46583, 53.75738]))
      });


      var wieza = new ol.Feature({
          geometry: new ol.geom.Point(ol.proj.fromLonLat([20.5175, 53.75342]))
      });

      var szpital = new ol.Feature({
          geometry: new ol.geom.Point(ol.proj.fromLonLat([20.49235, 53.76985]))
      });


      var vectorSource = new ol.source.Vector({
        features: [mcdonald, wydzial, plywalnia, wieza, szpital]
      });



    var wydzial = ol.proj.fromLonLat([20.45594,53.74374]);
var view = new ol.View({
  center: wydzial,
  zoom: 11
});

var vectorSource = new ol.source");
            WriteLiteral(@".Vector({});
var places = [
    [20.47746, 53.77309, 'http://maps.google.com/mapfiles/ms/micons/blue.png'], [20.45594,53.74374,'http://maps.google.com/mapfiles/ms/micons/blue.png'],  
    [20.46583, 53.75738,'http://maps.google.com/mapfiles/ms/micons/blue.png'],
    [20.5175, 53.75342,'http://maps.google.com/mapfiles/ms/micons/blue.png',],
    [20.49235, 53.76985,'http://maps.google.com/mapfiles/ms/micons/blue.png'],
];

var features = [];
for (var i = 0; i < places.length; i++) {
  var iconFeature = new ol.Feature({
    geometry: new ol.geom.Point(ol.proj.transform([places[i][0], places[i][1]], 'EPSG:4326', 'EPSG:3857')),
  });

      
  var iconStyle = new ol.style.Style({
    image: new ol.style.Icon({
      src: places[i][2],
      color: places[i][3],
      crossOrigin: 'anonymous',
    })
  });
  iconFeature.setStyle(iconStyle);
  vectorSource.addFeature(iconFeature);
}



var vectorLayer = new ol.layer.Vector({
  source: vectorSource,
  updateWhileAnimating: true,
  updat");
            WriteLiteral(@"eWhileInteracting: true
});

var map = new ol.Map({
  target: 'map',
  view: view,
  layers: [
    new ol.layer.Tile({
      preload: 3,
      source: new ol.source.OSM(),
    }),
    vectorLayer,
  ],
  loadTilesWhileAnimating: true,
});
</script>



");
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
