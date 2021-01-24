using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int playerHealth = 100;
    private bool isAlive = true;
    private bool isFinished = false;
    [SerializeField]
    private float pushbackForce = 3;
    private bool isInvincible = false;

    [SerializeField]
    private Rigidbody2D rgBody2d;
    [SerializeField]
    private Text textTest;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject deathEffect;

    [SerializeField]
    private float invincibilityDurationSeconds = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScoreTimeSubstracterCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        updateScore();
    }

    IEnumerator ScoreTimeSubstracterCoroutine()
    {
        while (!GlobalVariables.isMenuOpen || isAlive)
        {
            yield return new WaitForSeconds(1);
            if (GlobalVariables.Score > 0) 
                GlobalVariables.Score--;

        }
    }

    public void updateScore()
    {
        textTest.text = "Score: " + GlobalVariables.Score.ToString();
    }

    public void hurt(int damage)
    {
        if (isInvincible) return;

        animator.SetTrigger("Hurt");
        rgBody2d.velocity = new Vector2(rgBody2d.velocity.x * -1, rgBody2d.velocity.y + 10f);

        playerHealth -= damage;
        if (0 >= playerHealth)
        {
            Die(1000);
        }

        if (!isInvincible)
        {
            StartCoroutine(BecomeTemporarilyInvincible());
        }
    }

    void Die(int scorePenalty)
    {
        if (isAlive)
        {
            isAlive = false;
            GlobalVariables.Score -= scorePenalty;
            if (GlobalVariables.Score < 0)
            {
                GlobalVariables.Score = 0;
            }
            updateScore();
            Die();
        }
    }

    void Die()
    {
        StartCoroutine(ShowResults());
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        GetComponent<SpriteRenderer>().forceRenderingOff = true;
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(GetComponent<CircleCollider2D>());
        GlobalVariables.isMenuOpen = true;
    }

    public void Finish()
    {
        isFinished = true;
        animator.SetBool("isFinished", isFinished);
        StartCoroutine(ShowResults());
    }

    public IEnumerator ShowResults()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync("levelResultScene");
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDurationSeconds);

        isInvincible = false;
    }

}
