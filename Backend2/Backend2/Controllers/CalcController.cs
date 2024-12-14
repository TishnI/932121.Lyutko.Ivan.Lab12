using Backend2.Models;
using Microsoft.AspNetCore.Mvc;


namespace Backend2.Controllers
{
    public class CalcController : Controller
    {
        public string Calculate(int firstNumber, int secondNumber, string operation)
        {
            string result;
            switch(operation)
            {
                case "+":
                    result = (firstNumber + secondNumber).ToString(); 
                    break;
                case "-":
                    result = (firstNumber - secondNumber).ToString(); 
                    break;
                case "*":
                    result = (firstNumber * secondNumber).ToString();
                    break;
                case "/":
                    result = (secondNumber != 0) ? ((float)firstNumber / secondNumber).ToString() : "Деление на 0";
                    break;
                default:
                    result = "Неопределенная операция";
                    break;
            }
            return result;
        }

        public IActionResult Manual()
        {
            ViewBag.Title = "Manual";
            if (Request.Method == "GET")
                return View();

            ViewBag.Title = "Result";
            var form = Request.Form;

            int firstNumber = Convert.ToInt32(form["firstNumber"]);
            int secondNumber = Convert.ToInt32(form["secondNumber"]);
            string operation = form["operation"];
            ViewBag.Result = $"{firstNumber} {operation} {secondNumber} = {Calculate(firstNumber, secondNumber, operation)}";
            return View();
        }

        [HttpGet]
        public IActionResult ManualWithSeparateHandlers()
        {
            ViewBag.Title = "ManualWithSeparateHandlers";
            return View();
        }

        [HttpPost]
        public IActionResult ManualWithSeparateHandlersResult()
        {
            ViewBag.Title = "Result";
            var form = Request.Form;
            int firstNumber = Convert.ToInt32(form["firstNumber"]);
            int secondNumber = Convert.ToInt32(form["secondNumber"]);
            string operation = form["operation"];
            ViewBag.Result = $"{firstNumber} {operation} {secondNumber} = {Calculate(firstNumber, secondNumber, operation)}";
            return View("ManualWithSeparateHandlers");
        }


        [HttpGet]
        public IActionResult ModelBindingInParameters()
        {
            ViewBag.Title = "ModelBindingInParameters";
            return View();
        }
        [HttpPost]
        public IActionResult ModelBindingInParameters(int firstNumber, int secondNumber, string operation)
        {
            ViewBag.Title = "Result";
            ViewBag.Result = $"{firstNumber} {operation} {secondNumber} = {Calculate(firstNumber, secondNumber, operation)}";
            return View();
        }

        [HttpGet]
        public IActionResult ModelBindingInSeparateModel()
        {
            CalcModel model = new CalcModel();
            ViewBag.Title = "ModelBindingInSeparateModel";
            return View(model);
        }

        [HttpPost]
        public IActionResult ModelBindingInSeparateModel(CalcModel model)
        {
            ViewBag.Title = "Result";
            string result = Calculate(model.firstNumber,
                                       model.secondNumber,
                                       model.operation);

            ViewBag.Result = $"{model.firstNumber} {model.operation} {model.secondNumber} = {result}";
            return View(model);
        }

    }
}
