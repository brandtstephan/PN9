using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5;

    void FixedUpdate(){
        float move = Input.GetAxis("Horizontal") * speed;
        
        move *= Time.deltaTime;
        
        transform.Translate(move, 0, 0);
    }
}
