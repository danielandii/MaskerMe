using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeJump : MonoBehaviour
{
	Animator anim;
    private Vector2 startTouchPosition, endTouchPosition;
	private Rigidbody2D rb;
	private float jumpForce = 800f;
	private bool jumpAllowed = false;
	private bool SlideAllowed = false;

	// Use this for initialization
	private void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	private void Update () {
		SwipeCheck ();			
	}

	private void FixedUpdate()
	{
		JumpIfAllowed ();
	}

	private void SwipeCheck()
	{
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began)
			startTouchPosition = Input.GetTouch (0).position;

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended) {
			endTouchPosition = Input.GetTouch (0).position;
			if (endTouchPosition.y > startTouchPosition.y && rb.velocity.y == 0) {
				anim.SetTrigger("normal");
				jumpAllowed = true;
				SlideAllowed = false;
			}
			if (endTouchPosition.y < startTouchPosition.y && rb.velocity.y == 0) {
				anim.SetTrigger("sliding");
				SlideAllowed = true;
				jumpAllowed = false;
			}
		}

		if (Input.GetMouseButtonDown(0))
			startTouchPosition = new Vector2(Input.mousePosition.x,Input.mousePosition.y);

		if (Input.GetMouseButtonUp(0)) {
			endTouchPosition = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
			if (endTouchPosition.y > startTouchPosition.y && rb.velocity.y == 0) {
				anim.SetTrigger("normal");
				jumpAllowed = true;
				SlideAllowed = false;
			}
			if (endTouchPosition.y < startTouchPosition.y && rb.velocity.y == 0) {
				anim.SetTrigger("sliding");
				SlideAllowed = true;
				jumpAllowed = false;
			}
		}
		
	}

	private void JumpIfAllowed()
	{
		if (jumpAllowed) {
			rb.AddForce (Vector2.up * jumpForce);
			anim.SetTrigger("normal");
			jumpAllowed = false;
			SlideAllowed = false;
		}
		if (SlideAllowed) {
			anim.SetTrigger("normal");
			SlideAllowed = false;
			jumpAllowed = false;
		}
	}
}
