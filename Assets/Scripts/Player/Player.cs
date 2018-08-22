using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Animator myAnimator;
    private Rigidbody2D myRigidbody2D;

    [SerializeField]
    private float movementSpeed = 5f;

    private bool facingRight = false;
    private bool attack = false;

    bool jump = false;
    bool shot = false;

    float horizontalMove = 0f;

	// Use this for initialization
	void Start () {
        facingRight = true;
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        HandleInput();
	}

	private void FixedUpdate()
	{
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        Flip(horizontal);
        HandleAttacks();
	}

    private void HandleAttacks() {
        if (attack) {
            myAnimator.SetTrigger("attack");
        }
    }

    private void HandleInput() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            attack = true;
        }
    }

	private void HandleMovement(float horizontal) {
        myRigidbody2D.velocity = new Vector2(horizontal*movementSpeed, myRigidbody2D.velocity.y);
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void Flip(float horizontal) {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
            facingRight = !facingRight;

            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }


    }
}
