using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Animator animator;

    public float runSpeed = 40f;

    bool jump = false;
    bool shot = false;

    float horizontalMove = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
	}
}
