Console.WriteLine("Type in the unit size:");
string size = Convert.ToString(Console.ReadLine());
Console.WriteLine("Type in the type:");
string type = Convert.ToString(Console.ReadLine());
string code = $$"""
    Console.WriteLine("Enter the width (in {{size}}) of the triangle: ");
    {{type}} width = {{type}}.Parse(Console.ReadLine());
    Console.WriteLine("Enter the height (in {{size}}) of the triangle: ");
    {{type}} height = {{type}}.Parse(Console.ReadLine());
    {{type}} result = width * height / 2;
    Console.WriteLine($"{result} square {{size}}"); 
    """;
Console.WriteLine(code);