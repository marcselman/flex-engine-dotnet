using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexEngine.NET
{
    public class FlexContainer : FlexElement
    {
		private double _width;
		private double _height;
		private double _top;
		private double _right;
		private double _bottom;
		private double _left;
		private List<FlexElement> _elements = new List<FlexElement>();

		public double Width
		{
			get { return _width; }
			set { _width = value; }
		}

		public double Height
		{
			get { return _height; }
			set { _height = value; }
		}

		public FlexContainer(double width, double height)
		{
			_width = width;
			_height = height;
		}

		public double TotalBasis
		{
			get
			{
				return _elements.OfType<FlexItem>().Where(i => i.Basis.Type == FlexBasisType.Value).Select(i => i.InitialSize).ToList().Sum();
			}
		}

		public double AvailableSpace
		{
			get
			{
				return _width - TotalBasis;
			}
		}

		public double GrowUnit
		{
			get
			{
				var growSum = _elements.OfType<FlexItem>().Select(i => i.Grow).Sum();
				if (growSum == 0) return 1;
				return AvailableSpace / _elements.OfType<FlexItem>().Select(i => i.Grow).Sum();
			}
		}

		public List<FlexElement> Elements
		{
			get { return _elements; }
			set { _elements = value; }
		}

		public double Left
		{
			get { return _left; }
		}

		public double Bottom
		{
			get { return _bottom; }
		}

		public double Right
		{
			get { return _right; }
		}

		public double Top
		{
			get { return _top; }
		}
	}
}
