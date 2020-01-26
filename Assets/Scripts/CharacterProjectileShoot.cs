using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProjectileShoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 dir = transform.position - Input.mousePosition;
            gameObject.GetComponent<ProjectileSpawner>().SpawnProjectile(Input.mousePosition ,transform.position, dir);
        }
    }
}
