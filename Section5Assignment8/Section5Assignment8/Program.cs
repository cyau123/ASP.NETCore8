/*
 * Requirement: Create an Asp.Net Core Web Application that serves country details based on the request path.

Consider the following hard-coded list of countries:

1, United States

2, Canada

3, United Kingdom

4, India

5, Japan

You can store these countries directly as a dictionary.
*/
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Dictionary<int, string> countries = new Dictionary<int, string>
{
    { 1, "United States" },
    { 2, "Canada" },
    { 3, "United Kingdom" },
    { 4, "India" },
    { 5, "Japan" }
};

app.UseRouting();

app.UseEndpoints((endpoints) =>

{

    endpoints.MapGet("/countries", async (context) =>

    {

        context.Response.StatusCode = 200;

        foreach (var country in countries)

        {

            await context.Response.WriteAsync($"{country.Key}, {country.Value} \n");

        }
    });

    endpoints.MapGet("/countries/{countryID:int}", async (context) =>

    {

        int getId = Convert.ToInt32(context.Request.RouteValues["countryID"]);

        if (getId >= 1 && getId <= 100)

        {

            if (getId <= countries.Count)

            {

                await context.Response.WriteAsync($"{countries[getId]}");

            }

            else

            {

                context.Response.StatusCode = 404;

                await context.Response.WriteAsync("[No country]");

            }

        }

        else

        {

            context.Response.StatusCode = 400;

            await context.Response.WriteAsync("The countryId should be between 1 and 100");

        }

    });

});



app.Run((context) =>

{

    return context.Response.WriteAsync("Default path");

});



app.Run();


