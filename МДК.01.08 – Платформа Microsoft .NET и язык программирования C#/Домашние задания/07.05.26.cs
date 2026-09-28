
using System.Collections.Generic;
using System.Linq;
/* ЗАДАЧА 1
class Person
{
	public string Name { get; set; }
	public int Age { get; set; }
	public string City { get; set; }
}

class Program
{
	static void Main()
	{
		List<Person> people = new List<Person>
{
new Person { Name = "Анна", Age = 22, City = "Москва" },
new Person { Name = "Иван", Age = 30, City = "Москва" },
new Person { Name = "Олег", Age = 19, City = "Казань" },
new Person { Name = "Мария", Age = 27, City = "Санкт-Петербург" },
new Person { Name = "Алексей", Age = 24, City = "Москва" }
};

		Console.WriteLine("Только имена:");
		var names = people.Select(p => p.Name);

		foreach (var name in names)
			Console.WriteLine(name);

		Console.WriteLine("\nЖивут в Москве:");
		var moscowPeople = people.Where(p => p.City == "Москва");

		foreach (var person in moscowPeople)
			Console.WriteLine($"{person.Name}, {person.Age}");

		Console.WriteLine("\nСтарше 25 лет:");
		var olderThan25 = people.Where(p => p.Age > 25);

		foreach (var person in olderThan25)
			Console.WriteLine($"{person.Name}, {person.Age}");

		Console.WriteLine("\nМладше 25 лет, от младшего к старшему:");
		var youngerThan25 = people
		.Where(p => p.Age < 25)
		.OrderBy(p => p.Age);

		foreach (var person in youngerThan25)
			Console.WriteLine($"{person.Name}, {person.Age}");
	}
}*/

// ЗАДАЧА 2
class Product
{
	public string Name { get; set; }
	public decimal Price { get; set; }
	public string Category { get; set; }
	public int Rating { get; set; }
}

class Program
{
	static void Main()
	{
		List<Product> products = new List<Product>
{
new Product { Name = "Телефон", Price = 900, Category = "Электроника", Rating = 5 },
new Product { Name = "Ноутбук", Price = 1500, Category = "Электроника", Rating = 4 },
new Product { Name = "Мышка", Price = 500, Category = "Аксессуары", Rating = 5 },
new Product { Name = "Клавиатура", Price = 800, Category = "Аксессуары", Rating = 4 },
new Product { Name = "Наушники", Price = 700, Category = "Аудио", Rating = 5 }
};

		Console.WriteLine("Товары дешевле 1000:");
		var cheapProducts = products.Where(p => p.Price < 1000);

		foreach (var product in cheapProducts)
			Console.WriteLine($"{product.Name} - {product.Price}");

		Console.WriteLine("\nТовары с оценкой 5:");
		var ratingFive = products.Where(p => p.Rating == 5);

		foreach (var product in ratingFive)
			Console.WriteLine($"{product.Name} - оценка {product.Rating}");

		Console.WriteLine("\nГруппировка по категориям:");
		var groupedProducts = products.GroupBy(p => p.Category);

		foreach (var group in groupedProducts)
		{
			Console.WriteLine($"\nКатегория: {group.Key}");

			foreach (var product in group)
				Console.WriteLine(product.Name);
		}
	}
}