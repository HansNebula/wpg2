﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float gravity=1;
    public float tookTime=2.5f;

    public GameObject handler;

    private Rigidbody2D rb;
    

    private Transform playerTransform;

    public bool isBringing, isDesk, gr;
    bool isClimbing, isLadder;

    public bool isGrounded(){
        return GetComponent<Rigidbody2D>().velocity.y == 0;
    }
    Animator anim;

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode interactKey;

    Vector3 scale;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        handler=GameObject.FindGameObjectWithTag("GameController");
        gameObject.GetComponent<Rigidbody2D>().gravityScale=gravity;
        scale=playerTransform.localScale;
        anim=gameObject.GetComponent<Animator>();
        
    }

    void Awake(){
       gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("posX"), -2.241536f, gameObject.transform.position.z);
    }

    void Update(){
        // gameObject.transform.position = new Vector3(gameObject.transform.position.x, -2.241536f, gameObject.transform.position.z);
        move();
        // climb();
        StorePos();
        if(handler.GetComponent<globalEvent>().isTutorial()){
            blocked();
        }

        if(Input.GetKey(KeyCode.E)){
            handler.GetComponent<globalEvent>().StoreData();
        }
    }
    
    void move(){
        anim.SetBool("isJumping", !isGrounded());
        isDesk=handler.GetComponent<handler>().isDesk;
        float horizontalInput = 0f;
        gr=isGrounded();
        if(!isDesk){
            if(isGrounded()){
                if (Input.GetKey(leftKey)){
                    horizontalInput = -1f;
                    anim.SetFloat("xVelocity", 1f);
                }
                else if (Input.GetKey(rightKey)){
                    horizontalInput = 1f;
                    anim.SetFloat("xVelocity", 1f);
                }
                if(horizontalInput!=0){
                    transform.localScale = new Vector3(scale.x*horizontalInput, transform.localScale.y, transform.localScale.z);
                }
                Vector2 movement = new Vector2(horizontalInput, 0);
                rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
                if(anim.runtimeAnimatorController != null){
                    if(rb.velocity.x!=0){
                        anim.SetFloat("xVelocity", 1f);
                    }else{
                        anim.SetFloat("xVelocity", 0f);
                    }
                    // Jumping
                    if(Input.GetKeyDown(jumpKey)){
                        // print("s");
                        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    }
                }
            }
        }
    }

    void climb(){
        float verticalInput=0;
        if(isLadder){
            if(Input.GetKey(upKey)){
                verticalInput=1f;
            }else if(Input.GetKey(downKey)){
                verticalInput=-1f;
            }
            Vector2 movement = new Vector2(0, verticalInput);
            rb.velocity = new Vector2(rb.velocity.x, movement.y*moveSpeed);        
        }
        // isClimbing=false;
        // if(isLadder){
        //     print("isLadder");
        //     if(Input.GetKey(upKey)){
        //         isClimbing=true;
        //         verticalInput=1f;
        //         print("isUp");
        //     }else if(Input.GetKey(downKey)){
        //         isClimbing=true;
        //         verticalInput=-1f;
        //         print("isDown");
        //     }
        //     else  isClimbing = false;
        // }
        // if(isClimbing){
        //     Vector2 movement = new Vector2(0, verticalInput);
        //     rb.velocity = new Vector2(rb.velocity.x, movement.y*moveSpeed);
        //     print("isClimbing");
        // }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Ladder")){
            gameObject.GetComponent<Rigidbody2D>().gravityScale=0;
            // climb();
            isLadder=true;
            // isClimbing=true;
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Ladder")){
            isLadder=false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale=gravity;
            // isClimbing=false;
        }
    }


    void StorePos(){
        if(Input.GetKey(KeyCode.E)){
            PlayerPrefs.SetFloat("posY", GetComponent<Transform>().position.y);
            PlayerPrefs.SetFloat("posX", GetComponent<Transform>().position.x);
        }
    }
    public float raycastDistance=1f;
    public LayerMask collisionLayer;
    void blocked(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, raycastDistance, collisionLayer);
    
        // Debug information
        Debug.DrawRay(transform.position, Vector2.left * raycastDistance, Color.red); // Draw the ray in scene view
        // Check if the ray hits a collider
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.name == "blok")
            {
                handler.GetComponent<dialogTutor>().n = 11;
                handler.GetComponent<dialogTutor>().m = 0;
            }
            // Check collider tag
            else if (hit.collider.CompareTag("meja"))
            {
                handler.GetComponent<dialogTutor>().n = 12;
                handler.GetComponent<dialogTutor>().m = 0;
            }
        }
    }
}
