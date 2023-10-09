using org.hbo_ict.examples.EnumaratorIteratorAdapter;

//Example "using" directive to simplyfy the use of the EnumaratorIteratorAdapter
//For usage se dnatriplet example.

Console.WriteLine("Fibonacci numbers generator");

EnumarableIterableAdapter<UInt64> fibonaccinumbers = new(new FibonacciIterable());

int i = 0;
foreach (UInt64 fn in fibonaccinumbers)
{
    Console.WriteLine($"nr {i++}: {fn}");
}

Console.WriteLine("Use the iterator again");
i = 0;
foreach (UInt64 fn in fibonaccinumbers)
{
    Console.WriteLine($"nr {i++}: {fn}");
}


// Find all triplets in a DNA sequence
EnumIterString dnatriplets = new(new DNATripletIterable("ttcgcaagcggtcaggtt"));

Console.WriteLine("Use the DNA Triplet Generator");
i = 0;
foreach (string triplet in dnatriplets)
{
    Console.WriteLine($"nr {i++}: {triplet}");
}

// test: CheckCurrentValueMultipleTimes checks that if we use Current
// multiple times the cursor should not be moved until we isseu :"MoveNext()"
// here is proof, Enumerators should have this behaviour...

string enumerable = "The quick brown fox jump over the lazy dog";
IEnumerator<char> enumerator = enumerable.GetEnumerator();

string toReturn = "";
while (enumerator.MoveNext())
{
    toReturn += enumerator.Current;
    toReturn += enumerator.Current;
}
Console.WriteLine(toReturn);
