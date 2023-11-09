namespace MathCalcTest
{
	internal class Program
	{
		static void Main(string[] args)
		{
			CalcExpression calcExpression1 = new CalcExpression("sqrt(100)");

			// inch vor xeloq baner
			double result1 = calcExpression1.Calculate();

			Console.WriteLine(result1);
		}
	}
}