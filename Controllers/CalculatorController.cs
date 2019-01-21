using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace calculadora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }
        
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                var subtraction = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(subtraction.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("divition/{firstNumber}/{secondNumber}")]
        public IActionResult Divition(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                var divition = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(divition.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(multiplication.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                var mean = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(mean.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("square-root/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (IsNumeric(number)) {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(number));
                return Ok(squareRoot.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string value) {
            double number;

            bool isNumber = double.TryParse(value, 
                                            System.Globalization.NumberStyles.Any,
                                            System.Globalization.NumberFormatInfo.InvariantInfo,
                                            out number);

            return isNumber;
        }

        private decimal ConvertToDecimal(string value) {
            decimal decimalValue;

            if (decimal.TryParse(value, out decimalValue)) {
                return decimalValue;
            }

            return 0;
        }
    }
}
