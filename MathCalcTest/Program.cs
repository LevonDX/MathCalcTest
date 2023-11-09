namespace MathCalcTest
{
	internal class Program
	{
		static void Main(string[] args)
		{
			CalcExpression calcExpression1 = new CalcExpression("sqrt(100)");

			double result1 = calcExpression1.Calculate();

			Console.WriteLine(result1);
		}
	}
}