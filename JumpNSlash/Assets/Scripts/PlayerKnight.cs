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

    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("MushMan"))
        {
            collision.gameObject.GetComponent<Enemy>().Die();
            Jump();
        }
    }
    public void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpStrength);
    }
    public void GetDown()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.down * jumpStrength);
    }
    public void Attack()
    {
        anim.SetTrigger("attack");
        StartCoroutine(SwordOffOn());
    }
    IEnumerator SwordOffOn()
    {
        swordDamageArea.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        swordDamageArea.SetActive(false);
    }


}
