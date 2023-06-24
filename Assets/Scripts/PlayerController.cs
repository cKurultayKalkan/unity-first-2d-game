using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    public float moveSpeed = 13f;
    bool facingRight = true;
    Animator playerAnimator;

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
        if(playerRB.velocity.x < 0 && facingRight){
            FlipFace();
        }else if(playerRB.velocity.x > 0 && !facingRight) {
            FlipFace();
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

}
