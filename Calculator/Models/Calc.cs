namespace Calculator.Models
{
    public class Calc
    {
        public int Id { get; set; }
        public float Reduce { get; set; }
        public float Accumulate { get; set; }
        public Operation Operation { get; set; }
    }

    public enum Operation
    {
        Addition,
        Subtraction,
        Multiplication,
        Division

    }

    public static class OperationExtensions
    {
        public static string ToSymbol(this Operation operation) =>
            operation switch
            {
                Operation.Addition => "+",
                Operation.Subtraction => "-",
                Operation.Multiplication => "*",
                Operation.Division => "/",
                _ => throw new NotSupportedException()
            };
    }
}
