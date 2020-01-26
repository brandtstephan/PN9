using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
    public int projectileSpeed = 6;
    public Camera cam;
    public void SpawnProjectile(Vector2 targetPosition, Vector2 spwanPosition, Vector2 dir)
    {
        
        targetPosition = cam.ScreenToWorldPoint(targetPosition);
        spwanPosition = transform.InverseTransformVector(spwanPosition);
        Vector2 direction = targetPosition - spwanPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        

        GameObject _Projectile = Instantiate(projectile, spwanPosition, Quaternion.AngleAxis(angle, direction.normalized));

        if (dir == Vector2.right)
        {
            _Projectile.transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            _Projectile.transform.eulerAngles = new Vector2(0, -180);
        }
        
        _Projectile.GetComponent<Rigidbody2D>().velocity = direction.normalized * projectileSpeed;
        _Projectile.GetComponent<Projectile>().InitProjectile(projectileSpeed, direction.normalized, _Projectile);
    }
}
