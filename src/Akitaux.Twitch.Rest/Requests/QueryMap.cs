using System;
using System.Collections;
using System.Collections.Generic;

namespace Akitaux.Twitch.Rest
{
    // TODO: Should this be Utf8String?
    public abstract class QueryMap : IQueryMap
    {
        private IDictionary<string, object> _map = null;

        public abstract IDictionary<string, object> CreateQueryMap();
        private IDictionary<string, object> Map
        {
            get
            {
                if (_map == null)
                    _map = CreateQueryMap();
                return _map;
            }
        }

        // IDictionary
        object IDictionary<string, object>.this[string key] { get => Map[key]; set => throw new NotSupportedException(); }
        ICollection<string> IDictionary<string, object>.Keys => Map.Keys;
        ICollection<object> IDictionary<string, object>.Values => Map.Values;

        void IDictionary<string, object>.Add(string key, object value) => throw new NotSupportedException();
        bool IDictionary<string, object>.ContainsKey(string key) => Map.ContainsKey(key);
        bool IDictionary<string, object>.Remove(string key) => throw new NotSupportedException();
        bool IDictionary<string, object>.TryGetValue(string key, out object value) => Map.TryGetValue(key, out value);

        // ICollection
        int ICollection<KeyValuePair<string, object>>.Count => Map.Count;
        bool ICollection<KeyValuePair<string, object>>.IsReadOnly => true;
        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item) => throw new NotSupportedException();
        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item) => throw new NotSupportedException();
        void ICollection<KeyValuePair<string, object>>.Clear() => throw new NotSupportedException();
        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item) => Map.Contains(item);
        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex) => Map.CopyTo(array, arrayIndex);

        // IEnumerable
        IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator() => Map.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Map.GetEnumerator();
    }

    // Used to hide IDictionary extension methods
    internal interface IQueryMap : IDictionary<string, object> { }
}