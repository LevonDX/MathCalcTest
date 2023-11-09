using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MathCalcTest
{
	public class CalcExpression
	{
		public string Expression { get; }

		public CalcExpression(string expression)
		{
			Expression = expression;
		}

		public string GetMethodName()
		{
			// inch vor xeloq baner
			int index = Expression.IndexOf('(');   

			if (index == -1)
				throw new InvalidMathExpressionException("Invalid expression");

			string methodName = Expression.Substring(0, index);

			return methodName;
		}

		public double[] GetArguments()
		{
			int index1 = Expression.IndexOf("(");
			int index2 = Expression.IndexOf(")");

			if (index1 == -1 || index2 == -1 || index1 > index2)
			{
				throw new InvalidMathExpressionException("Invalid Expression");
			}

			string argStr = Expression.Substring(index1 + 1, index2 - index1 - 1);

			string[] args = argStr.Split(',');

			if (args.Length > 2 || args.Length < 1)
				throw new InvalidMathExpressionException("Invalid Expression",
					new ArgumentException("Invalid number of arguments"));

			double[] dargs = new double[args.Length];

			for (int i = 0; i < args.Length; i++)
			{
				if (!double.TryParse(args[i], out dargs[i]))
				{
					throw new InvalidMathExpressionException("Invalid Expression",
						new ArgumentException("Argument is not a number"));
				}
			}

			return dargs;
		}

		private string CapitalizeMethodName(string methodName)
		{
			return methodName.Substring(0, 1).ToUpper() + methodName.Substring(1);
		}

		public double Calculate()
		{
			string methodName = GetMethodName();
			methodName = CapitalizeMethodName(methodName);

			double[] args = GetArguments();

			Type type = typeof(Math);

			MethodInfo methodInfo = type.GetMethod(methodName, BindingFlags.Static | BindingFlags.Public);

			if (methodInfo == null)
				throw new InvalidMathExpressionException($"Method {methodName} not found");

			if (methodInfo.GetParameters().Length != args.Length)
				throw new InvalidMathExpressionException($"Method {methodName} has invalid number of arguments");

			object[] objArgs = new object[args.Length];
			for (int i = 0; i < args.Length; i++)
			{
				objArgs[i] = args[i]; // boxing
			}

			object resultObj = methodInfo.Invoke(null, objArgs);

			double? result = resultObj as double?;

			if (result == null)
				throw new InvalidMathExpressionException($"Method {methodName} does not return double");

			return (double)result;
		}
	}
}