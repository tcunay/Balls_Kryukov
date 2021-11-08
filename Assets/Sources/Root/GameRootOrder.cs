using System.Collections.Generic;
using UnityEngine;

namespace Sources.Root
{
    public class GameRootOrder : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private List<CompositeEntity> _order;

        private void Awake()
        {
            foreach (var entity in _order)
            {
                entity.Compose(_camera);
                entity.enabled = true;
            }
        }
    }
}