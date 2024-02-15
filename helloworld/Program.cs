///*** STRING ***
string myFirstFriend =
"Bobby";

myFirstFriend = myFirstFriend.Replace(" ", "");
string mySecondFriend = "Bryan";

string friends = $"Hello {myFirstFriend} and {mySecondFriend} and Bryan";

Console.WriteLine(friends.Contains("Bobby"));
Console.WriteLine(friends.ToUpper()); // string is immutable, donc on obtient une nouvelle string
Console.WriteLine(friends.Length); // taille d'une string : length
Console.WriteLine(friends.StartsWith("hel"));


/// *** NUMBERS *** 
int a = 18;
int b = 2;
int c = a + b;
Console.WriteLine(a + b);
Console.WriteLine(c);

int e = 2100000000;
int f = 2100000000;
int g = e + f;
Console.WriteLine(g); // -9497296

long h = e + f;
Console.WriteLine(h); // -9497296 Car l'opération se fait d'abord (en mode int) puis le résultat est assigné !!

long k = e + (long)f;
Console.WriteLine(k);  // 4200000000 !!!

// long j = checked(e + f); // Exception thrown: 'System.OverflowException' in helloworld.dll

int aa = (int)2.2;
int bb = (int)3.8;
Console.WriteLine(aa + bb); // 5

double cc = 42.1; // natural type
float dd = 3.8F; // explicit type
double ee = cc + dd;
Console.WriteLine(ee); // 45,899999952316286 au lieu de 45.9

decimal ff = 42.1M; // decimal plus précis mais plus de stockage
decimal gg = 2.8M; // M pour Maths ?
Console.WriteLine($"the answer is {ff + gg}."); // 44.9


/// *** CONDITIONAL and LOOPS ***
int m = 5;
int n = 6;
if (m + n > 10)
    Console.WriteLine($"{m + n} is greater than 10"); // fonctionne parfaitement

/* mais on peut être explicite et mettre des {} */
if (m + n > 10)
{
    Console.WriteLine($"{m + n} is greater than 10");
}

bool myTest = m + n > 20;

if (myTest)
{
    Console.WriteLine($"{m + n} is greater than 10");
}
else
{
    Console.WriteLine(myTest);
}

if (myTest && m == n)
{ // et : &&    ;    ou : ||
    Console.WriteLine("> 10 ET égaux");
}
else
{
    Console.WriteLine("<10 OU m != n");
}

/// *** WHILE ***
int counter = 0;

counter++;
Console.WriteLine(counter);
counter++;
Console.WriteLine(counter);
counter++;


while (counter < 5)
{
    Console.WriteLine("in the while");
    counter++;
    Console.WriteLine(counter);
}

counter = 0;

do
{
    Console.WriteLine("in the while");
    counter++;
    Console.WriteLine(counter);
}
while (counter < 5);

for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"boucle for : i = {i}");
}


var names = new List<string> { "Scott", "Anna", "Felipe" };

Console.WriteLine(names.Count); // Pour la longueur d'une liste : count

names.Add("toto"); // List is not immutable 

foreach (var name in names)
{
    Console.WriteLine(name.ToUpper());
}

Console.WriteLine($"names[0] = {names[0]}");
Console.WriteLine($"names[{names.Count - 1}] = {names[names.Count - 1]}");
Console.WriteLine(names[^1]); // ^1 : Count from the back of the array
Console.WriteLine(names[^2]); // ^2 : l'avant-dernier

foreach (var name in names[1..3])
{
    Console.WriteLine(name); // Anna Felipe => name[1] et name[2]
}

var namesArray = new string[] {
    "Scott",
    "Bobby",
    "Bryan"
};
// namesArray.Add("Damian"); NOR WORKING : cause ARRAY LENGTH IS FIXED!!!!!

namesArray = [.. names, "Damian"]; // Copy all from my previous array, and add "Damian". This create a new array!!!
Console.WriteLine("sort!");
names.Sort();

foreach (var name in names)
{
    Console.WriteLine(name);
}

var grades = new List<int> { 45, 33, 46, 49, 50 };
grades.Sort();
foreach (var grade in grades)
{
    Console.WriteLine(grade);
}

Console.WriteLine($"I found 45 at index : {grades.IndexOf(45)}");

// Syntaxic sugar for List :
List<int> scores = [97, 82, 92, 81, 60];

for (int i = 0; i < scores.Count; i++)
{
    if (scores[i] > 80)
    {
        Console.WriteLine($"Found a score over 80 : {scores[i]}");
    }
}

/// LANGUAGE INTEGRATED QUERY (LINQ)
/// DEFINE THE QUERY EXPRESSION : 
IEnumerable<int> scoreQuery =
    from score in scores
    where score > 80
    orderby score descending
    select score;

/// Execute the query
foreach (int j in scoreQuery)
{
    Console.WriteLine(j);
}

IEnumerable<string> scoreQuery2 = // query syntax : IMPORTANT : C'EST UNE QUESTION! QUI N'EST RESOLUE QUE LORSQU'ELLE EST APPELLEE!!
    from score in scores
    where score > 80
    orderby score descending
    select $"The select score is {score}";

int scoreCount = scoreQuery2.Count(); // Ici la query est appellé: la question  est posée, résolue puis affectée!!
Console.WriteLine(scoreCount);


foreach (var q in scoreQuery2)
{
    Console.WriteLine(q);
}

var scoreQuery3 = scores.Where(s => s > 90).OrderByDescending(s => s);

foreach (var s in scoreQuery3)
{
    Console.WriteLine(s);
}

Console.WriteLine("hello oop");

var p1 = new Person("Scott", "Hanselman", new DateOnly(1970,1,1));
var p2 = new Person("David", "Fowler", new DateOnly(1986,1,1));

p1.Pets.Add(new Dog("Doggy"));
p1.Pets.Add(new Dog("doggy2"));

p2.Pets.Add(new Cat("Beyonce"));

List<Person> people = [p1, p2];
Console.WriteLine(people.Count);

foreach(var p in people){
    Console.WriteLine($"{p.First} has pet : ");

    foreach(Pet pet in p.Pets)
    {
        Console.WriteLine($" {pet}");
    }
}

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

    public override string ToString()
    {
        return $"{firstname} and I am a {GetType().Name} and I {MakeNoise()}";
    }
}

public class Cat(string firstname) : Pet(firstname)
{

    public override string MakeNoise() => "mewo";
}

public class Dog(string firstname) : Pet(firstname)
{

    public override string MakeNoise() {return "bark";}
}


