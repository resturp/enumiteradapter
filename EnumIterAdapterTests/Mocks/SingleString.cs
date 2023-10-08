using org.hbo_ict.examples.EnumaratorIteratorAdapter;

namespace EnumIterAdapterTests
{
    internal class SingleString : IIterator<string>, IIterable<string>
    {
        private string _inject;
        private bool _hasnext;

        public bool hasNext()
        {
            return _hasnext;
        }

        public SingleString(string inject)
        {
            _inject = inject;
        }

        public string next()
        {
            _hasnext = false;
            return _inject;
        }

        public IIterator<string> Iterator()
        {
            _hasnext = true;
            return this;
        }
    }

}