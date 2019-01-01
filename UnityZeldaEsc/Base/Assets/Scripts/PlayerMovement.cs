﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    public enum PlayerState
    {
        walk,
        attack,
        interact
    }
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    //references

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        currentState = PlayerState.walk;
        
	}
	
	// Update is called once per frame
	void Update () {
        change = Vector3.zero;

        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack")&& currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());

        }
        else if(currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();

        }

        
       

        
	}
    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.33f);
        currentState = PlayerState.walk;

    }
    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);

        }
        else
        {
            animator.SetBool("moving", false);
        }

    }
    void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin"))
        {
            col.GetComponent<Coins>().CoinUpdate();

            
   
            


        }
    }
}
