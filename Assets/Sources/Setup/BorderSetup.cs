using Sources.Model;
using Sources.View;

namespace Sources.Setup
{
    public class BorderSetup
    {
        public void Setup(BorderView view, Damageable player)
        {
            var borderModel = new BorderModel(new DontDestroyable(), player);
            
            view.Init(borderModel);
        }
    }
}