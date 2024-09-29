/*Create an Asp.Net Core Web Application that demonstrates the usage of configuration in Asp.Net Core. It displays social media links based on the configuration settings stored in the config files.



You will store the following configuration in appsettings.json:

  "SocialMediaLinks":
  {
    "Facebook": "http://www.facebook.com/microsoft",
    "Instagram": "http://www.instagram.com/microsoft",
    "Twitter": "http://www.twitter.com/microsoft",
    "Youtube": "http://www.youtube.com/microsoft"
  }


You have different links for "Development" environment. So you will store the following social media links in appsettings.Development.json:

  "SocialMediaLinks":
  {
    "Facebook": "http://www.facebook.com/dotnet",
    "Twitter": "http://www.twitter.com/dotnet",
    "Youtube": "http://www.youtube.com/dotnet"
  }


Notice, there is no instagram link for Development environment.

So you'll not display instagram link in case of Development environment.

*/

using Section14Assignment24;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("SocialMediaLinksConfig.json", optional: true, reloadOnChange: true);
});
builder.Services.AddControllersWithViews();
builder.Services.Configure<SocialMediaLinksOptions>(builder.Configuration.GetSection("SocialMediaLinksOptions"));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
