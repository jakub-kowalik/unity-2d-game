using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleEnemy : Enemy
{
    public float location = 30.0f;
    float posX;
    float posY;

    // Start is called before the first frame update
    void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(posX, posY) + Vector3.up * (Mathf.Round(Mathf.Sin(Time.realtimeSinceStartup) * 100)/100) * location;
    }

    protected override void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        GlobalVariables.Score += scoreValue;
    }
}
