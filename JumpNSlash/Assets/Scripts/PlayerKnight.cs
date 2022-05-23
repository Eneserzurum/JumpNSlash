using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnight : MonoBehaviour
{
    [SerializeField]
    private float jumpStrength;
    Rigidbody2D rb;
    public GameObject swordDamageArea;
    Animator anim;
    
    bool isAlive;

    private int score;

    void Start()
    {
        isAlive = true;
        anim = this.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void ScoreUp()
    {
        score++;
    }
    public int ShowScore()
    {
        return score;
    }
    public bool IsHeAlive()
    {
        return isAlive;
    }
    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            Jump();
            anim.SetTrigger("jump");
        }
        if (Input.GetKeyDown("l"))
        {
            GetDown();
        }
        if (Input.GetKeyDown("j"))
        {
            Attack();
        }
    }
    bool IsInGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -0.25f, 0), Vector2.down, 0.1f);
        if (hit.collider)
        {
            return true;
        }    
        else
        {
            return false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("MushMan"))
        {
            collision.gameObject.GetComponent<Enemy>().Die();
            Jump();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MushMan") || collision.gameObject.CompareTag("BatMonster"))
        {
            isAlive = false;
            anim.SetTrigger("death");
        }
    }
    public void Jump()
    {
        if (isAlive)
        {
            if (IsInGround())
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpStrength);
            }
        }
    }
    public void GetDown()
    {
        if (isAlive)
        {
            if (!IsInGround())
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.down * jumpStrength);
            }
        }
    }
    public void Attack()
    {
        if (isAlive)
        {
            anim.SetTrigger("attack");
            StartCoroutine(SwordOffOn());
        }
    }
    IEnumerator SwordOffOn()
    {
        swordDamageArea.SetActive(true);
        yield return new WaitForSeconds(0.45f);
        swordDamageArea.SetActive(false);
    }


}
