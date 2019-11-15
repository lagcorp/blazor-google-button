#
Add to your
        <Galcorp.Blazor.GoogleButton.Shared.GButton></Galcorp.Blazor.GoogleButton.Shared.GButton>


Add to your
```
 public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            services.AddGalcorpGoogleButton();

			}
```

Add to your hosts.cs:

```
@page "/"
@namespace Revuo.Web.Paper.Pages
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Revuo papper</title>
    <base href="~/" />
    <link rel="stylesheet" href="css/bootstrap/bootstrap.min.css" />
    <link href="css/site.css" rel="stylesheet" />
</head>
<body>
    <app>
        @(await Html.RenderComponentAsync<App>(RenderMode.ServerPrerendered))
    </app>

    <script src="_framework/blazor.server.js"></script>
    
    <script src="_content/Galcorp.Blazor.GoogleButton/js/glogin.js"></script>
    <script async defer src="https://apis.google.com/js/api.js"
            onload="this.onload=function(){};glogin.loadAndInit()"
            onreadystatechange="if (this.readyState === 'complete') this.onload()"></script>
</body>
</html>

```

