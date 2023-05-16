
namespace InputActions
{
    public interface IInputAction
    {
        public bool IsPressed { get; }
        public bool IsReleased { get; }
        public bool IsHolding { get; }
    }
}