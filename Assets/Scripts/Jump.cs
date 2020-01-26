using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float strength = 5f;
    public int maxJumpCount = 2;
    public float fallMultiplier = 2f;
    public float jumpTime = 1.0f;
    Rigidbody2D rb;
    public int jumpCount = 0;
    bool canJump = true;
    float distToGround;

    // https://www.gamasutra.com/blogs/DanielFineberg/20150825/244650/Designing_a_Jump_in_Unity.php
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
    }

    void FixedUpdate(){
         if(rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    void Update()
    {
        if(isGrounded()) {
            Debug.Log("grounded");
            if(jumpCount > 0){
                jumpCount = 0;
                Debug.Log("jump reset");    
            }
        }

        if (Input.GetButtonDown("Jump")) {
            if (canJump) {
                if(jumpCount < maxJumpCount) {
                    StartCoroutine(JumpRoutine());
                    ++jumpCount;
                }
            }
        }

        

       
    }

    IEnumerator JumpRoutine() {
        // rb.velocity = Vector2.zero;

        float timer = 0f;
        Vector2 jumpVector = Vector2.up * strength;

        while(Input.GetButton("Jump") && timer < jumpTime) {
            float prop = timer/ jumpTime;
            Vector2 force = Vector2.Lerp(jumpVector, Vector2.zero, prop);
            rb.AddForce(force, ForceMode2D.Impulse);
            timer += Time.deltaTime;
            yield return null;       
        }
        
    }

    bool isGrounded() {
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        return Physics2D.Raycast(transform.position, Vector2.down, distToGround + 0.2f).collider != null;
    }
}
