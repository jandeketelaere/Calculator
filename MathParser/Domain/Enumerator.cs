using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Enumerator<T> where T : class
    {
        private readonly IList<T> _values;
        private int _currentPosition;

        public Enumerator(IEnumerable<T> values)
        {
            _values = values.ToList();
            _currentPosition = -1;
        }

        public bool HasNext()
        {
            return _values.ElementAtOrDefault(_currentPosition + 1) != null;
        }

        public void MoveNext()
        {
            _currentPosition++;
        }

        public T Current
            => _values.ElementAtOrDefault(_currentPosition);

        public T Peek()
        {
            if (!HasNext())
                return null;

            return _values.ElementAt(_currentPosition + 1);
        }

    }
}