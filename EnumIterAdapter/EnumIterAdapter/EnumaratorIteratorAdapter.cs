using System.Collections;
namespace org.hbo_ict.examples.EnumaratorIteratorAdapter;

/// <summary>
///     EnumaratorIteratorAdapter is an adaptor class that allows
///     an IIterator to be used for enumaration in an C# foreach()
///     control structure.
///
///     The Constructor needs to be injected with a object of
///     type IIterable<UInt64> that will generate a new instance of 
///     an iterator over the type T.
///
///     example: EnumaratorIteratorAdapter<UInt64> numbers =
///                 new(new NumberIterable());
///     where NumberIterable() is a class of type IIterable<UInt64>
/// </summary>
/// <typeparam name="T">the type of objects to iterate over</typeparam>
public class EnumaratorIteratorAdapter<T> : IEnumerator<T>
{

    public T Current => _current = _iterator.next();
    object? IEnumerator.Current => _current;

    private IIterable<T> _iterable;
    private IIterator<T> _iterator;
    private T _current;
    private bool _started;
    private bool _firstTime = true;

    public EnumaratorIteratorAdapter(IIterable<T> iterable)
    {
        _iterable = iterable;
        Reset();
    }

    public void Dispose() { Reset(); }

    public bool MoveNext()
    {
        if (!_iterator.hasNext()) return false;
        if (!_started) return _started = true;
        return true;
    }

    public void Reset()
    {
        _iterator = _iterable.Iterator();
        _current = default(T);       
        //if (_iterator.hasNext()) _current = _iterator.next();
        _started = false;
    }
}

/// <summary>
///     EnumarableIterableAdapter is an adapter that will allow
///     the generation of an Adapted Iterator to be useful in a
///     C# foreach control stucture.
///     
/// </summary>
/// <typeparam name="T">the type of objects to iterate over</typeparam>
public class EnumarableIterableAdapter<T> : IEnumerable<T>
{

    private IIterable<T> _iterable;
    
    public EnumarableIterableAdapter(IIterable<T> iterable)
    {
        _iterable = iterable;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new EnumaratorIteratorAdapter<T>(_iterable);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new EnumaratorIteratorAdapter<T>(_iterable);
    }


}

