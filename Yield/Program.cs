using System.Diagnostics;

/*foreach(var number in Fibonacci())
{
    Console.WriteLine(number);
}*/

var stopwatch1 = Stopwatch.StartNew();
var unUsed1 = Fibonacci_WithoutYield();
var x1 = unUsed1.FirstOrDefault();
stopwatch1.Stop();
Console.WriteLine($"time for first element of list without yield is: {stopwatch1.ElapsedTicks}");

var stopwatch2 = Stopwatch.StartNew();
var unUsed2 = Fibonacci_WithYield();
var x2 = unUsed2.FirstOrDefault();
stopwatch2.Stop();
Console.WriteLine($"time for first element of list with yield is: {stopwatch2.ElapsedTicks}");


// with yield, there is no need to define a list [ return of method must be IEnumerable ]
// whenever we want to use foreach on a list, it's better to use yield
// because after each yield code of foreach will be executed
// for example, after " yield return first ", code in foreach statement [ Console.WriteLine ] will be executed
// actualy the " MoveNext() " method of " IEnumerable " will be executed
static IEnumerable<int> Fibonacci_WithYield()
{
    int first = 0;
    int second = 1;

    yield return first;
    yield return second;

    while (second < 1000000)
    {
        (first, second) = (second, second + first);
        yield return second;
    }
}

static List<int> Fibonacci_WithoutYield()
{
    List<int> list = new();
    int first = 0;
    int second = 1;

    list.Add(first); 
    Thread.Sleep(10);
    list.Add(second);
    Thread.Sleep(10);
    while (second < 1000000)
    {
        (first, second) = (second, second + first);
        list.Add(second); 
        Thread.Sleep(10);
    }
    return list;
}