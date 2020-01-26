using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 5;
    public float strength = 15;
    Rigidbody2D rb;

    void Start(){

        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate(){
        float move = Input.GetAxis("Horizontal") * speed;
        float jump = Input.GetAxis("Jump") * strength;
        
        move *= Time.deltaTime;
        

        transform.Translate(move, 0, 0);
        rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
    }
}
