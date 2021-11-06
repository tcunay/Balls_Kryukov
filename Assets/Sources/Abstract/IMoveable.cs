namespace Sources.Abstract
{
    public interface IMoveable : IUpdateable
    {
        public float InitableSpeed { get; }
        public float CurrentSpeed { get; }
    }
}