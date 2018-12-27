using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BlogSite.Tests
{
    public class AsyncEnumerableQueryableReturn<T> : IAsyncEnumerable<T>, IQueryable<T>
    {
        private readonly IAsyncEnumerable<T> _asyncItems;
        private readonly T[] _rawItems;

        public Expression Expression => _rawItems.AsQueryable().Expression;
        public Type ElementType => _rawItems.AsQueryable().ElementType;
        public IQueryProvider Provider => _rawItems.AsQueryable().Provider;

        public AsyncEnumerableQueryableReturn(params T[] spItems)
        {
            _rawItems = spItems;
            _asyncItems = spItems.ToAsyncEnumerable();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _asyncItems.ToEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IAsyncEnumerator<T> IAsyncEnumerable<T>.GetEnumerator()
        {
            return _asyncItems.GetEnumerator();
        }
    }
}