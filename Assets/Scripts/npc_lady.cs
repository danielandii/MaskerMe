using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_lady : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    BoxCollider2D bc;
    SpriteRenderer mySpriteRenderer;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("isHappy", true);
            mySpriteRenderer.flipX = true;
            Debug.Log("happy");
            FindObjectOfType<AudioManager>().Play("Lady");
        }
    }
}
