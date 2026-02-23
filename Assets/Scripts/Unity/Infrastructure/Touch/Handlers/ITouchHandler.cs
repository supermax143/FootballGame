using System.Collections.Generic;

namespace Environments.Common.Scripts
{
    public interface ITouchHandler
    {
        //нужен для сортировки
        TouchHandlerType Type { get; }
        
        bool OnTouchBegin(IReadOnlyCollection<TouchData> touches);
        void OnTouchEnd(IReadOnlyCollection<TouchData> touches);
        void OnTouchMove(IReadOnlyCollection<TouchData> touches);
        bool TryConsumeClick(TouchData touches);
    }
}