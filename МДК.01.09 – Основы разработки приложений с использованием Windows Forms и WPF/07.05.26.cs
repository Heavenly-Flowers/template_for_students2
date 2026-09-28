using System;
using System.Collections.Generic;
using System.Linq;

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
}