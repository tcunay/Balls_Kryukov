using System;
using System.Collections.Generic;
using UnityEngine;
using Sources.Model;

namespace Sources.Root
{
    public class SceneCompiler : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private List<CompositeEntity> _order;

        private readonly PlayerModel _player = new PlayerModel(new Health(100));

        private void Awake()
        {
            foreach (var entity in _order)
            {
                PatametrsIterator.IterateOverAllParameters(entity, _player, _camera);
                entity.enabled = true;
            }
        }
    }

    public class PatametrsIterator
    {
        public static void IterateOverAllParameters<T1>(CompositeEntity entity, T1 t1)
        {
            entity.Compose(t1);
        }

        public static void IterateOverAllParameters<T1, T2>(CompositeEntity entity, T1 t1, T2 t2)
        {
            try
            {
                entity.Compose(t1);
            }
            catch
            {
                try
                {
                    entity.Compose(t2);
                }
                catch
                {
                    try
                    {
                        entity.Compose(t1, t2);
                    }
                    catch
                    {
                        try
                        {
                            entity.Compose(t2, t1);
                        }
                        catch
                        {
                            throw new InvalidOperationException();
                        }
                    }
                }
            }
        }
    }
}