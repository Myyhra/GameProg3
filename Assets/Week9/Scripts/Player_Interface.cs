
using UnityEngine;

namespace Week9
{
    public interface IPlayerMoveable
    {
        public void Move(Vector2 direction);
        // public void Backwards(float back); //Refer in Player_Input script
        public void Jump(bool jump);
    }

    public interface IMouseMovable
    {
        public Vector2 UpdateCamera(Vector2 mouseDelta);
    }

    public interface ICameraDirection
    {
        Vector3 GetForwardDirection();
    }

    public interface IInteractable
    {
        public void Interact();
        public void Drop();
    }

    public interface IAttackable
    {
        public void Attack();
        public void AlternateAttack();
    }

    public interface IRayTest
    {
        public void RayTest(RaycastHit hit);
    }
}