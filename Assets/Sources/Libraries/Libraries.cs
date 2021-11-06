using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.Libraries
{
    public abstract class Libraries<T>
    {
        protected abstract List<T> ReturnedObjects { get; }

        public T GetRandom()
        {
            return ReturnedObjects[Random.Range(0, ReturnedObjects.Count)];
        }
    }
}