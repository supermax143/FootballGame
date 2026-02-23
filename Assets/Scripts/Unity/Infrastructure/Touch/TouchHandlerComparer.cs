using System.Collections.Generic;

using Environments.Common.Scripts;

namespace Environments.Land.Scripts.Runtime.Controllers
{
    public class TouchHandlerComparer : IComparer<ITouchHandler>
    {
        public int Compare(ITouchHandler a, ITouchHandler b)
        {
            if (ReferenceEquals(a, b)) return 0;
            if (ReferenceEquals(null, b)) return 1;
            if (ReferenceEquals(null, a)) return -1;
            return ((byte)a.Type).CompareTo((byte)b.Type);
        }
    }
}