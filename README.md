# GzipBundle
A simple Bundle with Gzip compression.

## Installation

You can download this bundle in the [NuGet](https://www.nuget.org/packages/GzipBundle/).

## How to use

You can use this like the current bundle

```
/* JS */
bundles.Add(new GzipScriptBundle("~/bundles/jqueryval", new JsMinify()).Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));
                
//CDN
bundles.Add(new GzipScriptBundle("~/bundles/jquery",
                "http://code.jquery.com/jquery-2.1.4.min.js"));

/* CSS */                

bundles.Add(new GzipStyleBundle("~/Content/themes/base/css", new CssMinify()).Include(
                "~/Content/themes/base/jquery.ui.core.css",
                "~/Content/themes/base/jquery.ui.resizable.css",
                "~/Content/themes/base/jquery.ui.selectable.css",
                "~/Content/themes/base/jquery.ui.accordion.css",
                "~/Content/themes/base/jquery.ui.autocomplete.css",
                "~/Content/themes/base/jquery.ui.button.css",
                "~/Content/themes/base/jquery.ui.dialog.css",
                "~/Content/themes/base/jquery.ui.slider.css",
                "~/Content/themes/base/jquery.ui.tabs.css",
                "~/Content/themes/base/jquery.ui.datepicker.css",
                "~/Content/themes/base/jquery.ui.progressbar.css",
                "~/Content/themes/base/jquery.ui.theme.css"));
                
//CDN
bundles.Add(new GzipStyleBundle("~/Content/bootstrap",
                "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"));                
```
