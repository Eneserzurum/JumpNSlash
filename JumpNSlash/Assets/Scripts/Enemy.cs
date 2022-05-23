using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    bool isAlive;
    
    Animator anim;
    GameObject player;
    SpriteRenderer sr;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        sr = this.GetComponent<SpriteRenderer>();
        isAlive = true;
        player = GameObject.Find("PlayerKnight");
    }

    
    void Update()
    {
        if (isAlive == true)
        {
            if(player.GetComponent<PlayerKnight>().IsHeAlive() == true)
            {
                GoForward();
            }
            else
            {
                GoBackward();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }

    public void Die()
    {
        anim.SetTrigger("kill");
        isAlive = false;
        Destroy(this.gameObject,0.4f);
        player.GetComponent<PlayerKnight>().ScoreUp();
    }
    void GoForward()
    {
        sr.flipX = true;
        transform.Translate(-movementSpeed * Time.deltaTime, 0, 0);
    }
    void GoBackward()
    {
        sr.flipX = false;
        transform.Translate(movementSpeed * Time.deltaTime, 0, 0);
    }
}
