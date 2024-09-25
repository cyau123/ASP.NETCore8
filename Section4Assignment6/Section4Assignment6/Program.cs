/*
 * Requirement: Create an Asp.Net Core Web Application that receives username and password via POST request (from Postman).

It receives "email" and "password" as query string from request body.



Parameters:

email: any email address

password: any password string

Finally, it should return message as either "Successful login" or "Invalid login".



Process:

If email is "admin@example.com" and password is "admin1234", it is treated as a valid login; otherwise invalid login.
 */

using Section4Assignment6;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

// Invoking custom middleware
app.UseLoginMiddleware();

app.Run(async context =>
{
    await context.Response.WriteAsync("No response");
});
app.Run();