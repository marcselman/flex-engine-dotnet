using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexEngine.NET
{
	public class FlexItem : FlexElement
	{
		private double _grow = 0;
		private double _shrink = 1;
		private FlexContainer _container;
		private FlexBasis _basis = new FlexBasis
		{
			Type = FlexBasisType.Auto
		};

		public FlexItem(FlexContainer container)
		{
			_container = container;
		}

		public FlexItem(FlexContainer container, FlexUnit basisUnit, double basisValue) : this(container, 0, 1, basisUnit, basisValue) { }

		public FlexItem(FlexContainer container, double grow, double shrink, FlexUnit basisUnit, double basisValue)
		{
			_container = container;
			_grow = grow;
			_shrink = shrink;
			_basis = new FlexBasis
			{
				Type = FlexBasisType.Value,
				Value = new FlexValue
				{
					Unit = basisUnit,
					Value = basisValue
				}
			};
		}

		public double Left
		{
			get
			{
				double l = _container.Left;
				foreach (var element in _container.Elements.OfType<FlexItem>())
				{
					if (element != this)
						l += element.FlexItemSize;
					else
						break;
				}
				return l;
			}
		}

		public double ShrinkFactor
		{
			get
			{
				return (InitialSize * _shrink) / _container.Elements.OfType<FlexItem>().Select(i => i.InitialSize * i.Shrink).Sum();
			}
		}

		public double ShrinkAmount
		{
			get
			{
				return ShrinkFactor * (_container.Width - _container.Elements.OfType<FlexItem>().Select(i => i.InitialSize).Sum());
			}
		}

		public double GrowAmount
		{
			get
			{
				return _container.AvailableSpace * (_grow / (_container.Elements.OfType<FlexItem>().Select(i => i._grow).Sum()));
			}
		}

		public double InitialSize
		{
			get
			{
				if (_basis.Value.Unit == FlexUnit.Percent)
				{
					return (_basis.Value.Value * _container.Width) / 100d;
				}
				else
				{
					return _basis.Value.Value;
				}
			}
		}

		public double FlexItemSize
		{
			get
			{
				if (_container.AvailableSpace < 0)
				{
					return InitialSize + (_container.AvailableSpace * ShrinkFactor);
				}
				else
				{
					return InitialSize + (_container.GrowUnit * _grow);
				}
			}
		}

		public FlexBasis Basis
		{
			get { return _basis; }
			set { _basis = value; }
		}

		public double Grow
		{
			get { return _grow; }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("Grow", value, "Grow property cannot be negative");
				_grow = value;
			}
		}

		public double Shrink
		{
			get { return _shrink; }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("Shrink", value, "Shrink property cannot be negative");
				_shrink = value;
			}
		}
	}
}
