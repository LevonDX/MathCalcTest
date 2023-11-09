namespace MathCalcTest.Tests
{

	[TestClass]
	public class TestingCalcExpressions
	{
		[TestMethod]
		public void TestGetMethodName()
		{
			// Init
			CalcExpression calcExpression1 = new CalcExpression("sqrt(100)");
			CalcExpression calcExpression2 = new CalcExpression("pow(3, 2)");
			CalcExpression calcExpression3 = new CalcExpression("pow[3, 2)");

			// Action
			string f1 = calcExpression1.GetMethodName();
			string f2 = calcExpression2.GetMethodName();

			// Assert
			Assert.AreEqual("sqrt", f1);
			Assert.AreEqual("pow", f2);

			Assert.ThrowsException<InvalidMathExpressionException>(calcExpression3.GetMethodName);
		}

		[TestMethod]
		public void TestGetArgs()
		{
			Assert.IsTrue(true);
		}

		[TestMethod]
		public void TestCalculate()
		{
			// Init
			CalcExpression calcExpression1 = new CalcExpression("sqrt(100)");
			CalcExpression calcExpression2 = new CalcExpression("pow(2, 3)");
			CalcExpression calcExpression3 = new CalcExpression("sqrt[100)");
			CalcExpression calcExpression4 = new CalcExpression("sqrt(100, 3)");
			CalcExpression calcExpression5 = new CalcExpression("sqrt(100, g)");


			// Action
			double result1 = calcExpression1.Calculate();
			double result2 = calcExpression2.Calculate();


			// Assert
			Assert.AreEqual(10, result1, "sqrt(100) problem");
			Assert.AreEqual(8, result2, "pow(2, 3) problem");

			Assert.ThrowsException<InvalidMathExpressionException>(() => calcExpression3.Calculate());
			Assert.ThrowsException<InvalidMathExpressionException>(() => calcExpression4.Calculate());
			Assert.ThrowsException<InvalidMathExpressionException>(() => calcExpression5.Calculate());
		}
	}
}