using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Library.Application.Base
{
    public abstract class MapperBase<TEntry, TResponse>
        where TEntry : class
        where TResponse : class
    {
        public abstract TResponse Map(TEntry entry);

        public virtual IEnumerable<TResponse> Map(IEnumerable<TEntry> entries)
        {
            foreach (var entry in entries)
                yield return Map(entry);
        }
    }
}
