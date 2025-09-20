using Unity.VisualScripting;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Playercontroller playercontroller;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        int choice = Random.Range(0, 2);
        if (playercontroller.Condition())
        {
            Walking();
        }
        else
        {
            if (choice == 0)
            {
                Standing();
            }
            else
            {
                Eating();
            }
        }
    }

    void Walking()
    {
        animator.SetTrigger("walking");
        animator.ResetTrigger("standing");
        animator.ResetTrigger("eating");
    }

    void Standing()
    {
        animator.SetTrigger("standing");
        animator.ResetTrigger("walking");
        animator.ResetTrigger("eating");
    }
    void Eating()
    {
        animator.SetTrigger("eating");
        animator.ResetTrigger("standing");
    }
}
