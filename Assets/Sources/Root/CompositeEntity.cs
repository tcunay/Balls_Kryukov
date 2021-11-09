using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.Root
{
    public abstract class CompositeEntity : MonoBehaviour
    {
        public abstract void Compose(IDictionary<Type, dynamic> dictionary);
    }
}