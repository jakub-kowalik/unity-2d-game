using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : PickupsScript
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GlobalVariables.Score += pickUpScore;
            player.Finish();
        }
    }
}
