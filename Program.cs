using LINQ.DataSources;
using LINQ.Models;
using System.Collections;

namespace LINQ
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Var & Dynamic

			// Var : Compilation Time

			//int x = 10;

			//var y = 10; // Compiler Will Detect The Type 'int'
			//var name = "Hossam";

			//var Numbers = new List<int>();

			////name = 10; Wrong

			////var test = null; Wrong

			////var z; Wrong


			//int p = 10;
			//var u = p;

			// ========================================================

			//// Dynamic => Runtime => When App Starts

			//dynamic x;
			//x = 10;
			//x = "Hossam";
			//x = 12.2;
			//x = 15.2F;
			//x = 'A'; // Last Assigned Value

			////Console.WriteLine(x.GetType());

			//dynamic Z = 10;

			//Console.WriteLine(Z.Length);


			#endregion

			#region Anonymous Type

			//var Employee1 = new { Id = 1, Name = "Hossam", Salary = 5000 };

			////Console.WriteLine(Employee1.ToString());
			////Console.WriteLine(Employee1.GetType());

			//var Employee2 = new { Id = 2, Name = "Ahmed", Salary = 4000 };

			// Same Properties , Same Types , Same Order => Compiler Will Reuse ONE TYPE
			//Console.WriteLine(Employee1.GetType() == Employee2.GetType());

			//var Employee3 = new { id = 3, name = "Mona", salary = 3000 };
			////Console.WriteLine(Employee1.GetType()); // Anonymous0`3
			////Console.WriteLine(Employee2.GetType()); // Anonymous0`3
			////Console.WriteLine(Employee3.GetType()); // Anonymous1`3

			//var Employee4 = new { Id = 4, Salary = 6000, Name = "Ali" };
			////Console.WriteLine(Employee1.GetType()); // Anonymous0`3
			////Console.WriteLine(Employee2.GetType()); // Anonymous0`3
			////Console.WriteLine(Employee3.GetType()); // Anonymous1`3
			////Console.WriteLine(Employee4.GetType()); // Anonymous2`3

			//// Equal() => Compare By Values  ,
			//// == => Compare By REFERENCES

			//var Emp1Copy = new { Id = 1, Name = "Hossam", Salary = 5000 };
			////Console.WriteLine(Employee1.Equals(Emp1Copy));
			//Console.WriteLine(Employee1 == Emp1Copy);


			#endregion

			#region LINQ Queries 

			var Student = new List<Student>
			{
				new() {Name = "Ahmed" , Grade = 60 , Major = "CS"},
				new() {Name = "Ali" , Grade = 70 , Major = "IS"},
				new() {Name = "Hossam" , Grade = 80 , Major = "CS"},
				new() {Name = "Mona" , Grade = 90 , Major = "IT"}
			};

			#region Query Syntax


			/*
			 * Get Student With Major 'CS' And Grade Greater Than or Equal 80
			 * 
			 *  Query in SQL Server
			 * Select S.Name , S.Grade
			 * From Students S
			 * Where S.Grade >= 80 AND S.Major = 'CS'
			 * 
			 */

			//var Query = from s in Student
			//			where s.Grade >= 80 && s.Major == "CS" // Filter
			//			orderby s.Grade descending // Ordering
			//			select new {s.Name, s.Grade}; // Display

			#endregion

			#region Method Syntax

			//var MethodSyntax = Student.Where(S => S.Grade >= 80 && S.Major == "CS")
			//						  .OrderByDescending(S => S.Grade)
			//						  .Select(S => new { S.Name , S.Grade});

			#endregion

			//foreach (var s in MethodSyntax)
			//	Console.WriteLine(s);

			#endregion

			#region Deferred & Immediate Execution

			//var Numbers = new List<int> { 1, 2, 3, 4, 5 };

			// ======Deferred Execution=======

			//var Result = Numbers.Where(N => N % 2 == 0); 

			//Numbers.Add(6);

			// ======Immediate Execution======
			// Forcing Query to Execute

			//var Result = Numbers.Where(N => N % 2 == 0).ToList();

			//Numbers.Add(8);

			//foreach (var num in Result)
			//	Console.WriteLine(num);

			#endregion

			#region Filteration - Restiraction

			#region Where()

			// 1) Get All Products Are Out Of Stock

			//var result = Source.ProductList.Where(P => P.UnitsInStock == 0);

			//result = from P in Source.ProductList
			//		 where P.UnitsInStock == 0
			//		 select P;
			//=====================================================================
			// 2) Get All Products Are In Stock AND Price > 20 

			//var result = Source.ProductList.Where(P => P.UnitsInStock > 0 && P.UnitPrice > 200);

			//result = from P in Source.ProductList
			//		 where P.UnitsInStock > 0 && P.UnitPrice > 200
			//		 select P;

			// ===================================================================

			// Indexed Where

			// Get Products Are Out Of Stock First 20 Product (Index 0 : 19)
			//var result = Source.ProductList.Where((P, I) => P.UnitsInStock == 0 && I < 20);



			#endregion

			#region OfType<>

			//ArrayList Collection = new() { 1, 2, 12.2, 'A', "Ahmed" };

			//var result = Collection.OfType<double>();

			#endregion

			#endregion

			#region Projection 

			#region Select

			// 1) Get All PRoduct Names

			//var result = Source.ProductList.Select(P => P.ProductName);

			//result = from P in Source.ProductList
			//		 select P.ProductName;

			// ====================================================

			// 2) Get All Product Name , Category And Price

			//var result = Source.ProductList.Select(P => new { P.ProductName , P.Category , P.UnitPrice});
			//var  result1 = Source.ProductList.Select((P , I) => )


			// Search For 'Indexed Select' With Example in Assignment

			#endregion

			#region SelectMany

			var result = Source.CustomerList.SelectMany(C => C.Orders);

			#endregion

			#endregion

			//foreach (var item in result)
			//	Console.WriteLine(item);

		}
	}
}
