using System;
namespace org.hbo_ict.examples.EnumaratorIteratorAdapter;

/// <summary>
///     An iterator to iterate over all possible Fibonacci number
///     in the scope of a UInt64 (64 bit long unsigned integer)
///
///     Fibonacci numbers: https://en.wikipedia.org/wiki/Fibonacci_sequence
///     Iterator: https://en.wikipedia.org/wiki/Iterator_pattern
/// </summary>
public class FibonacciIterator : IIterator<UInt64>
{
    UInt64 _current = 0;
    UInt64 _previous = 1;

    public bool hasNext()
    {
        return !(_previous > UInt64.MaxValue / 2);
    }
    
    public ulong next()
    {
        UInt64 t = _current;
        _current += _previous;
        _previous = t;
        return t;

    }

}

/// <summary>
///     The Iterable Class to generate a Typed iterator.
/// </summary>
public class FibonacciIterable : IIterable<UInt64>
{
    public IIterator<UInt64> Iterator()
    {
        return new FibonacciIterator();
    }

}

