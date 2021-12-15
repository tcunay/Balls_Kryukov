using System;
using UnityEngine;

namespace Sources.Root
{
    public abstract class CompositeEntity : MonoBehaviour
    {
        public virtual void Compose<T1>(T1 t1)
        {
            throw new NotImplementedException();
        }
        
        public virtual void Compose<T1, T2>(T1 t1, T2 t2)
        {
            throw new NotImplementedException();
        }
    }
}