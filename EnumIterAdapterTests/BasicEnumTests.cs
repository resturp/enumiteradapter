namespace EnumIterAdapterTests;
using org.hbo_ict.examples.EnumaratorIteratorAdapter;
using static System.Net.Mime.MediaTypeNames;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void IterateOverAnEmptySet()
    {
        EnumarableIterableAdapter<int> emptySet = new(new EmptySet());
        foreach (int i in emptySet)
        {
            Assert.IsTrue(false);
        }
        Assert.Pass();
    }
    [Test]
    public void IterateOverASingleElement()
    {
        string inject = "Hello world";
        EnumarableIterableAdapter<string> singleStringSet = new(new SingleString(inject));
        List<string> result = new();
        foreach (string text in singleStringSet)
        {
            result.Add(text);
        }
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0], Is.EqualTo(inject));
    }

    [TestCase("", 0)]
    [TestCase("q", 1)]
    [TestCase("hq", 2)]
    [TestCase("0123456789", 10)]
    [TestCase("Hello world", 11)]
    public void IterateOverACharsInString(string inject, int lenght)
    {
        EnumarableIterableAdapter<char> charSet = new(new CharInString(inject));
        string result = "";
        int count = 0;
        foreach (char symbol in charSet)
        {
            result = $"{result}{symbol}";
            count++;
        }
        Assert.That(result.Equals(inject));
        Assert.That(count.Equals(lenght));
    }

    [TestCase("")]
    [TestCase("q")]
    [TestCase("hq")]
    [TestCase("0123456789")]
    [TestCase("Hello world")]
    public void IterateMultipleTimeOvertheSameIterator(string inject)
    {
        EnumarableIterableAdapter<char> charSet = new(new CharInString(inject));
        string result = "";
        foreach (char symbol in charSet)
        {
            result = $"{result}{symbol}";
        }
        foreach (char symbol in charSet)
        {
            result = $"{result}{symbol}";
        }
        foreach (char symbol in charSet)
        {
            result = $"{result}{symbol}";
        }
        Assert.That(result, Is.EqualTo($"{inject}{inject}{inject}"));
    }

    [Test]
    public void CheckCurrentValueMultipleTimes()
    {
        string inject = "ACTC";
        EnumarableIterableAdapter<string> singleStringSet = new(new DNATripletIterable(inject));
        IEnumerator<string> singleEnumerator = singleStringSet.GetEnumerator();

        string result = "";
        while (singleEnumerator.MoveNext())
        {
            result += singleEnumerator.Current;
            result += singleEnumerator.Current;
        }
        Assert.That(result, Is.EqualTo("ACTACTCTCCTC"));
    }
    
}
