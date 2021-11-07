using System.Collections.Generic;
using UnityEngine;

namespace Sources.Root
{
    public class GameRootOrder : MonoBehaviour
    {
        [SerializeField] private List<RootEntity> _order;

        private void Awake()
        {
            foreach (var entity in _order)
            {
                entity.Begin();
                entity.enabled = true;
            }
        }
    }
}