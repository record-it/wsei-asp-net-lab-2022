namespace lecture_5.Models
{
    public class Calculator
    {
        public string Op { get; set; }  
        public double? a { get; set; } 
        public double? b { get; set; }

        public string Calculate()
        {
            switch (Op)
            {
                case "add":
                    return $"{a} + {b} = {a + b}";
                case "sub":
                    return $"{a} - {b} = {a - b}";
                case "mul":
                    return $"{a} * {b} = {a * b}";
                case "div":
                    return $"{a} / {b} = {a / b}";
                default:
                    return null;
            }
        }
    }
}
