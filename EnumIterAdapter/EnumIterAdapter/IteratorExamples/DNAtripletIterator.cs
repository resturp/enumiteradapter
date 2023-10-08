using System;
namespace org.hbo_ict.examples.EnumaratorIteratorAdapter;

/// <summary>
///     An iterator to iterate over all possible Fibonacci number
///     in the scope of a UInt64 (64 bit long unsigned integer)
///
///     Fibonacci numbers: https://en.wikipedia.org/wiki/Fibonacci_sequence
///     Iterator: https://en.wikipedia.org/wiki/Iterator_pattern
/// </summary>
public class DNATripletIterator : IIterator<string>
{
    int _current = 0;
    string _dna;

    public DNATripletIterator(string dna)
    {
        _dna = dna;
    }

    public bool hasNext()
    {
        return _current < _dna.Length - 2;
    }

    public string next()
    {
        return _dna.Substring(_current++,3);
    }

}

/// <summary>
///     The Iterable Class to generate a Typed iterator.
/// </summary>
public class DNATripletIterable : IIterable<string>
{
    private string _dna;

    public DNATripletIterable(string dna)
    {
        _dna = dna;
    }

    public IIterator<String> Iterator()
    {
        return new DNATripletIterator(_dna);
    }

}

