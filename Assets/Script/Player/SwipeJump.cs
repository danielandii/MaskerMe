using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SwipeJump : MonoBehaviour
{
	Animator anim;
	Rigidbody2D rb;
    // private Vector2 startTouchPosition, endTouchPosition;
	private float jumpForce = 800f;
	// private bool jumpAllowed = false;
	// private bool SlideAllowed = false;

	// Use this for initialization
	private void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	private void Update () {
		// SwipeCheck ();	
		// if(CrossPlatformInputManager.GetButtonDown("jump")){
		// 	buttonJump();
		// }		
		// if(CrossPlatformInputManager.GetButtonDown("slide")){
		// 	buttonSlide();
		// }		

		if (CrossPlatformInputManager.GetButtonDown ("jump") && rb.velocity.y == 0)
			rb.AddForce (Vector2.up * jumpForce);

		SetAnimationState ();
	}

	void SetAnimationState()
	{

		if (rb.velocity.y == 0) {
			anim.SetBool ("isJumping", false);
			// anim.SetBool ("isRunning", true);
			Debug.Log("y==0");
		}

		if (CrossPlatformInputManager.GetButtonDown ("slide") && rb.velocity.y == 0) {
			anim.SetBool ("isSliding", true);
			Debug.Log("sliding");
		}
		else {
			anim.SetBool ("isSliding", false);
		}
			// anim.SetBool ("isRunning", true);

		if (rb.velocity.y > 0){
		// if (CrossPlatformInputManager.GetButtonDown ("jump") && rb.velocity.y == 0) {
		// 	rb.AddForce (Vector2.up * jumpForce);
			anim.SetBool ("isJumping", true);
			Debug.Log("isJumping");
		}
		
		// if (rb.velocity.y < 0) {
		// 	anim.SetBool ("isJumping", false);
		// 	Debug.Log("y<0");
		// 	// rb.velocity = Vector3.zero;
		// 	// anim.SetBool ("isRunning", true);
		// }
	}

	// private void FixedUpdate()
	// {
	// 	JumpIfAllowed ();
	// }

	// private void SwipeCheck()
	// {
		// if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began)
		// 	startTouchPosition = Input.GetTouch (0).position;

		// if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended) {
		// 	endTouchPosition = Input.GetTouch (0).position;
		// 	if (endTouchPosition.y > startTouchPosition.y && rb.velocity.y == 0) {
		// 		anim.SetTrigger("normal");
		// 		jumpAllowed = true;
		// 		SlideAllowed = false;
		// 	}
		// 	if (endTouchPosition.y < startTouchPosition.y && rb.velocity.y == 0) {
		// 		anim.SetTrigger("sliding");
		// 		SlideAllowed = true;
		// 		jumpAllowed = false;
		// 	}
		// }

		// if (Input.GetMouseButtonDown(0))
		// 	startTouchPosition = new Vector2(Input.mousePosition.x,Input.mousePosition.y);

		// if (Input.GetMouseButtonUp(0)) {
		// 	endTouchPosition = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
		// 	if (endTouchPosition.y > startTouchPosition.y && rb.velocity.y == 0) {
		// 		anim.SetTrigger("normal");
		// 		jumpAllowed = true;
		// 		SlideAllowed = false;
		// 	}
		// 	if (endTouchPosition.y < startTouchPosition.y && rb.velocity.y == 0 && SlideAllowed == false && jumpAllowed == false) {
		// 		anim.SetTrigger("sliding");
		// 		SlideAllowed = true;
		// 		jumpAllowed = false;
		// 	}
		// }
		
	// }

	// private void JumpIfAllowed()
	// {
	// 	if (jumpAllowed) {
	// 		rb.AddForce (Vector2.up * jumpForce);
	// 		anim.SetTrigger("normal");
	// 		jumpAllowed = false;
	// 		SlideAllowed = false;
	// 	}
	// 	if (SlideAllowed) {
	// 		anim.SetTrigger("normal");
	// 		SlideAllowed = false;
	// 		jumpAllowed = false;
	// 	}
	// }

	// void buttonJump(){
	// 	Debug.Log("tust");
	// 	anim.SetTrigger("normal");
	// 	jumpAllowed = true;
	// 	SlideAllowed = false;
	// }

	// void buttonSlide(){
	// 	Debug.Log("tost");
	// 	anim.SetTrigger("sliding");
	// 	SlideAllowed = true;
	// 	jumpAllowed = false;
	// }

}
