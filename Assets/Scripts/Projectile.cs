using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public GameObject self;
    public int projectileSpeed = 6;
    private Vector2 projectileDirection;
    private float delta = 0;
    
    public void Start()
    {
    }
    private void Update()
    {
        delta += Time.deltaTime;
        GetComponent<Rigidbody2D>().velocity = projectileDirection * projectileSpeed;
        if (delta > 5)
        {
            Destroy(self);
        }
        
    }
    public void InitProjectile(int projectileSpeed, Vector2 dir, GameObject self)
    {
        this.projectileSpeed = projectileSpeed;
        this.projectileDirection = dir;
        this.self = self;
    }
}
