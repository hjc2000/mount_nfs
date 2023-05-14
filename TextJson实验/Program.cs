using StringLib;
using System.Text.Json;

string? jsonText = @"ffff{""Name"":""\u5F20\u4E09"",""Age"":18}fff";
jsonText = Slice.SliceMaxOn(jsonText, '{', '}');
if (jsonText != null)
{
	Console.WriteLine(jsonText);
	Person? person = JsonSerializer.Deserialize<Person>(jsonText);
	Console.WriteLine(person);
}

internal class Person
{
	public string? Name { get; set; }
	public int Age { get; set; }
	public override string ToString()
	{
		return $"姓名：{Name}，年龄：{Age}";
	}
}