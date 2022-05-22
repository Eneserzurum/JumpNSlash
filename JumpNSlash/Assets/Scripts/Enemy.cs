using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    bool isAlive;
    
    Animator anim;
    
    void Start()
    {
        anim = this.GetComponent<Animator>();
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive == true)
        {
            GoForward();
            //karakter ölüyse geri git;
        }
    }
    public void Die()
    {
        anim.SetTrigger("kill");
        //karakterin skoru artsın
        isAlive = false;
        Destroy(this.gameObject,0.3f);
    }
    void GoForward()
    {
        transform.Translate(-movementSpeed * Time.deltaTime, 0, 0);
    }
    void GoBackward()
    {
        transform.Translate(movementSpeed * Time.deltaTime, 0, 0);
    }
}
