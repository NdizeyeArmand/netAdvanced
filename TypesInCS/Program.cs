// Gedrag van "value type" variabele

using TypesInCS;

int a = 15;
int b = a;
a = 30;

Console.WriteLine("a = " + a + "     b = " + b);

// Gedrag van "reference type" variabele

TestClass tcA = new TestClass(15, "Eerste Object");
TestClass tcB = tcA;
tcA.Id = 30;
tcA.Name = "Tweede Object";

Console.WriteLine("tcA = " + tcA + "     tcB = " + tcB);