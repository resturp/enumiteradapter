using org.hbo_ict.examples.EnumaratorIteratorAdapter;

namespace EnumIterAdapterTests
{
    internal class CharInString : IIterator<char>, IIterable<char>
    {
        private string _inject;
        private int _pos;

        public CharInString(string inject)
        {
            _inject = inject;
        }

        public bool hasNext()
        {
            return _pos < _inject.Length;
        }

        public IIterator<char> Iterator()
        {
            _pos = 0;
            return this;
        }

        public char next()
        {
            return _inject[_pos++];
        }
    }
}