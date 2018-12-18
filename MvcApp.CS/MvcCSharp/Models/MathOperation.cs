using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcCSharp.Models
{
    public class MathOperation
    {
        [Required]
        [Display(Name = "Number 1:")]
        [Range(0,1000)]
        public double? NumberOne { get; set; }

        [Required]
        [Display(Name = "Number 2:")]
        public double? NumberTwo { get; set; }
        public string Operation { get; set; }

        public double Answer { get; private set; } = 0;

        public List<string> Choices => new List<string>
        {
            "Add",
            "Subtract",
            "Multiply",
            "Divide"
        };

        public void Calculate()
        {
            var num1 = NumberOne ?? 0;
            var num2 = NumberTwo ?? 0;

            switch (Operation.ToLower())
            {
                case "add":
                    Answer = num1 + num2;
                    break;
                case "subtract":
                    Answer = num1 - num2;
                    break;
                case "multiply":
                    Answer = num1 * num2;
                    break;
                default:
                    Answer = num1 / num2;
                    break;
            }
        }
    }
}