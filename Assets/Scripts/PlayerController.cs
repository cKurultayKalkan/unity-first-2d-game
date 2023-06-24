using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    public float moveSpeed = 1f;
    bool facingRight = true;
    Animator playerAnimator;
    public float jumpSpeed = 1f, jumpFrequency = 1f, nextJumpTime; 
    public bool isGrounded = false;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    void Awake()
    {
       
    }

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D> ();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();
        onGroundCheck();
        if(playerRB.velocity.x < 0 && facingRight){
            FlipFace();
        }else if(playerRB.velocity.x > 0 && !facingRight) {
            FlipFace();
        }

        if(Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }
    }

    void FixedUpdate()
    {

    }

    void HorizontalMove(){
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal")* moveSpeed , playerRB.velocity.y);
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void Jump(){
        playerRB.AddForce(new Vector2(0f, jumpSpeed));
    }

    void onGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isGrounded", isGrounded);
    }

}
