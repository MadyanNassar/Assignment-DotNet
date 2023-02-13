using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using ThirdApp.Model;

namespace ThirdApp.Controllers
{
    [Route("runningtotal")]
    [ApiController]
    public class InputController : ControllerBase
    {
        [HttpPost]
        public int GetUser(
        [FromForm] string userInput)
        {
            try
            {
                bool isNum = int.TryParse(userInput, out int number);
                if (!isNum)
                {
                    throw new FormatException(string.Format("{0} is not a number", userInput));
                }
                var inputNumber =  int.Parse(userInput);

                var session = HttpContext.Session.GetString("input");

                if (session == null)
                {
                    InputModel input = new()
                    {
                        CurrentInput = inputNumber,
                        Sum = inputNumber,
                        FirstLvlInput = 0,
                        SecondLvlInput = 0
                    };

                    HttpContext.Session.SetString("input", JsonConvert.SerializeObject(input));

                    return input.Sum;
                }
                else
                {
                    var input = JsonConvert.DeserializeObject<InputModel>(HttpContext.Session.GetString("input"));

                    input.SecondLvlInput = input.FirstLvlInput;
                    input.FirstLvlInput = input.CurrentInput;
                    input.CurrentInput = inputNumber;
                    input.Sum = input.CurrentInput + input.FirstLvlInput + input.SecondLvlInput;

                    HttpContext.Session.SetString("input", JsonConvert.SerializeObject(input));
                    return input.Sum;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
};
