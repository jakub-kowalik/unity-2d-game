using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabEnemy : Enemy
{

    public Transform player;
    bool isFlipped = false;
	public void LookAtPlayer()
	{
		if (player != null)
		{
			Vector3 flipped = transform.localScale;
			flipped.z *= -1f;

			if (transform.position.x > player.position.x && isFlipped)
			{
				transform.localScale = flipped;
				transform.Rotate(0f, 180f, 0f);
				isFlipped = false;
			}
			else if (transform.position.x < player.position.x && !isFlipped)
			{
				transform.localScale = flipped;
				transform.Rotate(0f, 180f, 0f);
				isFlipped = true;
			}
		}
	}
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
