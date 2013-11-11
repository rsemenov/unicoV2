using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Unico.Tests
{
    public class LocalValue<T> where T : class
    {
        private Dictionary<string, T> _values = new Dictionary<string, T>();
        private Func<T> _constructor;
        private readonly object _lockObj = new object();

        public LocalValue(Func<T> constructor)
        {
            _constructor = constructor;
        }

        public T Value
        {
            get
            {
                lock (_lockObj)
                {
                    var testId = TestContext.CurrentContext.Test.Name;
                    if (!_values.ContainsKey(testId))
                    {
                        _values.Add(testId, _constructor());
                    }
                    return _values[testId];
                }
            }
            set
            {
                lock (_lockObj)
                {
                    var testId = TestContext.CurrentContext.Test.Name;
                    _values[testId] = value;
                }
            }
        }


    }

}
