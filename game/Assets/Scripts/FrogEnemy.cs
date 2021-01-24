using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogEnemy : Enemy
{
    public Animator animator;

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

    public override void TakeDamage(int damage)
    {
        healthPoints -= damage;
        animator.SetTrigger("Hurt");

        if (healthPoints <= 0)
        {
            Die();
        }
    }

}
