using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
	Animator anim;
	Rigidbody2D rb;
	private float jumpForce = 800f;

	// Use this for initialization
	private void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	private void Update () {

		if (CrossPlatformInputManager.GetButtonDown ("jump") && rb.velocity.y == 0)
			rb.AddForce (Vector2.up * jumpForce);

		SetAnimationState ();
	}

	void SetAnimationState()
	{

		if (rb.velocity.y == 0) {
			anim.SetBool ("isJumping", false);
			Debug.Log("y==0");
		}

		if (CrossPlatformInputManager.GetButtonDown ("slide") && rb.velocity.y == 0) {
			anim.SetBool ("isSliding", true);
			Debug.Log("sliding");
		}
		else {
			anim.SetBool ("isSliding", false);
		}

		if (rb.velocity.y > 0){
			anim.SetBool ("isJumping", true);
			Debug.Log("isJumping");
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("NoreGameOver");
        }
    }
}
