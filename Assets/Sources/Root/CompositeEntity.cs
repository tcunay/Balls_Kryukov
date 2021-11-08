using UnityEngine;

namespace Sources.Root
{
    public abstract class CompositeEntity : MonoBehaviour
    {
        public abstract void Compose(Camera camera);
    }
}