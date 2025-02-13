
namespace Week6
{
    public interface IPlayerMoveable
    {
        public void Forward();
        public void Backward();
        public void Left();
        public void Right();
    }

    public interface IInteractable
    {
        public void Interact();
        public void Drop();
    }
}