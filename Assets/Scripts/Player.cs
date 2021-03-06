﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    BoxCollider2D bc;
    private float jumpForce = 800f;
    private float speed;
    public GameObject obj;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
        FindObjectOfType<AudioManager>().Play("Run");
        FindObjectOfType<AudioManager>().Unmute("Run");
        // speed = getObj.speed;
        speed = 0;
    }

    // Update is called once per frame
    private void Update()
    {

        if (CrossPlatformInputManager.GetButtonDown("jump") && rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * jumpForce);
            StopCoroutine(onJumpSound());
            StartCoroutine(onJumpSound());
        }

        if (CrossPlatformInputManager.GetButtonDown("slide"))
        {
            StopCoroutine(onSlideSound());
            StartCoroutine(onSlideSound());
        }


        SetAnimationState();
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= -15)
        {
            FindObjectOfType<AudioManager>().Play("GameOver");
            FindObjectOfType<AudioManager>().Mute("Run");
            Destroy(gameObject);
            SceneManager.LoadScene("NoreGameOver");
        }
    }

    IEnumerator onSlideSound()
    {
        //Debug.Log("slide sound");
        FindObjectOfType<AudioManager>().Play("Slide");
        FindObjectOfType<AudioManager>().Mute("Run");
        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioManager>().Unmute("Run");
    }
    IEnumerator onJumpSound()
    {
        //Debug.Log("slide sound");
        FindObjectOfType<AudioManager>().Play("Jump");
        FindObjectOfType<AudioManager>().Mute("Run");
        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioManager>().Unmute("Run");
    }


    void SetAnimationState()
    {

        if (rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            //Debug.Log("y==0");
        }

        if (CrossPlatformInputManager.GetButtonDown("slide") && rb.velocity.y == 0)
        {
            anim.SetBool("isSliding", true);
            // bc.size = new Vector2(2.4f, 3f);
            //Debug.Log(bc.size);
        }
        else
        {
            anim.SetBool("isSliding", false);
            //FindObjectOfType<AudioManager>().Unmute("Run");
            // bc.size = new Vector2(2.4f, 3.5f);
            //Debug.Log("run");
            //Debug.Log(bc.size);
        }

        if (rb.velocity.y > 0)
        {
            anim.SetBool("isJumping", true);
            //Debug.Log("isJumping");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            //FindObjectOfType<AudioManager>().Mute("ThemeSong");
            FindObjectOfType<AudioManager>().Play("Collide");
            FindObjectOfType<AudioManager>().Mute("Run");
            incraseSpeed getObj = obj.GetComponent<incraseSpeed>();
            speed = getObj.speed;
            anim.SetBool("isDead", true);
            // Destroy(gameObject);
            // SceneManager.LoadScene("NoreGameOver");
            Debug.Log("Collide");
        }

        if (other.CompareTag("People"))
        {
            anim.SetBool("isGiving", true);
            // Debug.Log("Give");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        anim.SetBool("isGiving", false);
    }
}
