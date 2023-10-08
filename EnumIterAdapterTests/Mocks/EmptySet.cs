using org.hbo_ict.examples.EnumaratorIteratorAdapter;

namespace EnumIterAdapterTests
{
    internal class EmptySet : IIterator<int>, IIterable<int>
    {
        public EmptySet()
        {
        }

        public bool hasNext()
        {
            return false;
        }

        public IIterator<int> Iterator()
        {
            return this;
        }

        public int next()
        {
            throw new NotImplementedException();
        }
    }
}