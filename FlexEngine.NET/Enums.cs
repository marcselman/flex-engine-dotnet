using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexEngine.NET
{
	public enum FlexDirection
	{
		Row,
		RowReverse,
		Column,
		ColumnReverse
	}

	public enum FlexUnit
	{
		Pixels,
		Percent
	}

	public enum FlexBasisType
	{
		Auto,
		Content,
		Value
	}
}
