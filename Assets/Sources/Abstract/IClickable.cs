using Sources.Model;

namespace Sources.Abstract
{
    public interface IClickable : IView
    {
        Damageable Damageable { get; }
    }
}