namespace org.hbo_ict.examples.EnumaratorIteratorAdapter;
/// <summary>
///     The IIterator interface is the default Java iterator interface
///     In Java one can use an iterator in a for (object o in collection)
///     control structure.
///
///     In C# we would like to implement a simple interface like iterator
///     in a foreach (object o in collection) control structure.
/// </summary>
/// <typeparam name="T">The type of objects we want to iterate over</typeparam>

public interface IIterator<T>
{
    bool hasNext();
    T next();
}

public interface IIterable<T>
{
    IIterator<T> Iterator();
}