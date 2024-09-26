using Microsoft.AspNetCore.Mvc;

namespace Section6Assigment10.Controllers
{
    /* Requirement: Imagine a banking application. Create an Asp.Net Core Web Application that serves bank account details based on the request path.



        Consider the following hard-coded bank account details:

        accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000

        You can store these details as an anonymous object. Eg: new { property1 = value, property2 = value }

        */
    [Controller]
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Content("Welcome to the Best Bank");
        }

        [Route("/account-details")]
        public IActionResult AccountDetails()
        {
            //hard-coded data
            var bankAccount = new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };

            //send the object as JSON
            return Json(bankAccount);
        }

        [Route("/account-statement")]
        public IActionResult AccountStatement()
        {
            //send a pdf file (at wwwroot folder) as response
            return File("~/statement.pdf", "application/pdf");
        }

        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult GetCurrentBalance()
        {
            // Get the 'accountNumber' value from the route parameters using RouteData
            object accountNumberObj;
            if (HttpContext.Request.RouteValues.TryGetValue("accountNumber", out accountNumberObj) && accountNumberObj is string accountNumber)
            {
                // Check if the 'accountNumber' parameter is provided
                if (string.IsNullOrEmpty(accountNumber))
                {
                    return NotFound("Account Number should be supplied");
                }

                // Convert the 'accountNumber' to an integer
                if (int.TryParse(accountNumber, out int accountNumberInt))
                {
                    // Hard-coded data
                    var bankAccount = new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };

                    if (accountNumberInt == 1001)
                    {
                        // If accountNumber is 1001, return the current balance value
                        return Content(bankAccount.currentBalance.ToString());
                    }
                    else
                    {
                        // If accountNumber is not 1001, return HTTP 400
                        return BadRequest("Account Number should be 1001");
                    }
                }
                else
                {
                    // If the 'accountNumber' provided in the route parameter is not a valid integer, return HTTP 400
                    return BadRequest("Invalid Account Number format");
                }
            }
            else
            {
                // If 'accountNumber' is not found in the route parameters, handle the error
                // For example, redirect to an error page or return a specific error message
                // return RedirectToAction("Error");
                return NotFound("Account Number should be supplied");
            }
        }
    }
}