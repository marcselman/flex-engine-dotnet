using FlexEngine.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			var container = new FlexContainer(900, 600);
			var item1 = new FlexItem(container, 1, 1, FlexUnit.Pixels, 200);
			var item2 = new FlexItem(container, 3, 0, FlexUnit.Percent, 80);
			var item3 = new FlexItem(container, 4, 2, FlexUnit.Pixels, 100);
			container.Elements.Add(item1);
			container.Elements.Add(item2);
			container.Elements.Add(item3);

			Console.WriteLine(container.TotalBasis);
			Console.WriteLine(container.AvailableSpace);
			Console.WriteLine(container.GrowUnit);
			Console.WriteLine($"Size: {item1.FlexItemSize} Left: {item1.Left}");
			Console.WriteLine($"Size: {item2.FlexItemSize} Left: {item2.Left}");
			Console.WriteLine($"Size: {item3.FlexItemSize} Left: {item3.Left}");

			Console.ReadLine();
		}
	}
}