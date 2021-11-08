using UnityEngine;
using Sources.Setup;
using Sources.View;

namespace Sources.Root
{
    public class ClickerEntity : CompositeEntity
    {
        [SerializeField] private ClickerView _template;
        
        private readonly ClickerSetup _clickerSetup = new ClickerSetup();

        private Camera _camera;

        public override void Compose(Camera camera)
        {
            _camera = camera;
        }

        private void Start()
        {
            var view = Instantiate(_template);

            _clickerSetup.Setup(view, _camera);
        }
    }
}