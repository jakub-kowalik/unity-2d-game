using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumEnemy : Enemy
{
    public Rigidbody2D rb;
    int move = -1;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Collectable"))
        {
            if (!collision.CompareTag("Bullet"))
            {
                if (!collision.CompareTag("Player"))
                {
                    move *= -1;

                    Vector3 flipped = transform.localScale;
                    flipped.z *= -1f;

                    transform.localScale = flipped;
                    transform.Rotate(0f, 180f, 0f);
                }
            }
        }
    }

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.hurt(damage);

            move *= -1;

            Vector3 flipped = transform.localScale;
            flipped.z *= -1f;

            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector2(move * 5f, rb.velocity.y);
        rb.velocity = targetVelocity;
    }
}
