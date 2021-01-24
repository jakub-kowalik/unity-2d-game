using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabEnemy : Enemy
{

    public Transform player;
	
	public override void TakeDamage(int damage)
	{
		healthPoints -= damage;
		GetComponent<Animator>().SetBool("isDamaged", true);
		GetComponent<Animator>().SetTrigger("Hurt");

		if (healthPoints <= 700)
        {
			GetComponent<Renderer>().material.SetColor("_Color", Color.red);
			GetComponent<Animator>().SetBool("isEnraged", true);
		}
		if (healthPoints <= 0)
		{
			Die();
		}
	}
}
