using System;

namespace Sources.Abstract
{
    public interface IDestroyable
    {
        event Action Destoyed;

        void Destroy();
    }
}