using System;
using System.IO;
using System.Xml.Serialization;

namespace Task1
{
	[Serializable]
	public class ComplexNumber
	{
		public int a;
		public int b;
		public double i;

		public ComplexNumber()
		{
		}

		public ComplexNumber(int a, int b, double i)
		{
			this.a = a;
			this.b = b;
			this.i = i;
			
		}
		public override string ToString()
		{
			double ComplexNum = a + b * Convert.ToInt32(i);
			return ComplexNum.ToString();
		}
	}




	class Program
	{
		public static void Serialize()
		{
			ComplexNumber Example = new ComplexNumber();
			Example.a = int.Parse(Console.ReadLine());
			Example.b = int.Parse(Console.ReadLine());
			Example.i = double.Parse(Console.ReadLine());
			Console.WriteLine(Example.ToString());

			FileStream File = new FileStream("order.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
			XmlSerializer xml = new XmlSerializer(typeof(ComplexNumber));
			xml.Serialize(File, Example);
			File.Close();
		}

		public static void DeSerialize()
		{
			FileStream File = new FileStream("order.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
			try
			{
				XmlSerializer xml = new XmlSerializer(typeof(ComplexNumber));
				ComplexNumber Example = xml.Deserialize(File) as ComplexNumber;
				Console.WriteLine(Example.ToString());
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				File.Close();
			}
		}

		static void Main(string[] args)
		{
			Serialize();
			//DeSerialize();
		}
	}
}
