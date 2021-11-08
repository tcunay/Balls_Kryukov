using System;

namespace Sources.Abstract
{
    public interface IHeatlhValue
    {
        public event Action ValueChanged;
        public int Value { get; }
    }
}