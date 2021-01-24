using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsScript : MonoBehaviour
{

    public GameObject pickupEffect;
    public int pickUpScore = 100;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GlobalVariables.Score += pickUpScore;
        }
    }
}
