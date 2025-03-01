using UnityEngine;
using Week9;

public class BugsTester : MonoBehaviour, IPlayerMoveable,IAttackable
{
    //this place doesn't work at all lmao

    void Awake()
    {
	
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        InterfaceTest();
    }

    void InterfaceTest()
    {
        // Attack();
        // AlternateAttack();
    }


    public void Move(Vector2 direction)
    {
        Debug.Log("Player is moving");
    }

    public void Jump(bool jump)
    {
        Debug.Log("Player is jumping");
    }

    public void Attack()
    {
        Debug.Log("Player is attacking");
    }

    public void AlternateAttack()
    {
        Debug.Log("Player is using Skill");
    }
}
