Console.WriteLine("hello oop");

var p1 = new Person("Scott", "Hanselman", new DateOnly(1970,1,1));
var p2 = new Person("David", "Fowler", new DateOnly(1986,1,1));

p1.Pets.Add(new Pet("Dog"));

List<Person> people = [p1, p2];
Console.WriteLine(people.Count);

public class Person(string firstnme, string lastname, DateOnly birthday)
{
    public string First {get;} = firstnme;
    public string Last {get;} = lastname;

    public DateOnly Birthday {get;} = birthday;

    public List<Pet> Pets { get; } = new();
}

public abstract class Pet(string firstname)
{
    public string First {get;} = firstname;

    public abstract string MakeNoise();
}

public class Cat(string firstname) : Pet(firstname)
{

    public override string MakeNoise() => "mewo";
}

public class Dog(string firstname) : Pet(firstname)
{

    public override string MakeNoise() {return "bark";}
}

