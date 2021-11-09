using Sources.Model;

namespace Sources.Abstract
{
    public interface IClickable : IModel
    {
        int Reward { get; }
    }
}