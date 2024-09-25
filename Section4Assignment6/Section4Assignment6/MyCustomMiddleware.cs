
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace Section4Assignment6
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path == "/" && context.Request.Method == "POST")
            {
                // Read response body as stream
                StreamReader reader = new StreamReader(context.Request.Body);
                string body = await reader.ReadToEndAsync();

                // Parse the request body from string into Dictionary
                Dictionary<string, StringValues> queryDict = QueryHelpers.ParseQuery(body);

                string? email = null, password = null;

                if (queryDict.ContainsKey("email"))
                {
                    // Convert to String, because we now know it is not null, so not 'String?' anymore
                    email = Convert.ToString(queryDict["email"][0]);
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'email'\n");
                }

                //read 'secondNumber' if submitted in the request body
                if (queryDict.ContainsKey("password"))
                {
                    password = Convert.ToString(queryDict["password"][0]);
                }
                else
                {
                    if (context.Response.StatusCode == 200)
                        context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'password'\n");
                }

                //if both email and password are submitted in the request
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    //valid email and password as per the requirement specification
                    string validEmail = "admin@example.com", validPassword = "admin1234";
                    bool isValidLogin;

                    //if email and password are valid
                    if (email == validEmail && password == validPassword)
                    {
                        isValidLogin = true;
                    }
                    else
                    {
                        isValidLogin = false;
                    }

                    //send response
                    if (isValidLogin)
                    {
                        await context.Response.WriteAsync("Successful login\n");
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Invalid login\n");
                    }

                } //end of "if !string.IsNullOrEmpty"
            } //end of "if method == POST"
              //else, invoke subsequent middleware (if any)
            else
            {
                await next(context);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
