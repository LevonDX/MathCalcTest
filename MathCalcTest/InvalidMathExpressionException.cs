using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCalcTest
{
	public class InvalidMathExpressionException : Exception
	{
		public InvalidMathExpressionException()
		{

		}

		public InvalidMathExpressionException(string message)
			: base(message)
		{
		}

		public InvalidMathExpressionException(string message, Exception innerException)
			: base(message, innerException)
		{

		}
	}
}