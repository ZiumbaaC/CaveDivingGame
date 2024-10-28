using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileData : MonoBehaviour
{

    [HideInInspector] public Vector2 projectileAngle;
    [HideInInspector] public float direction;
    public float projectileSpeed;
    public float projectileDamage;
    public float projectileKnockbackForce;
    public Vector2 projectileKnockbackAngle;

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2((projectileSpeed * projectileAngle).x * direction, (projectileSpeed * projectileAngle).y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EntityData>().HP -= projectileDamage;
            collision.GetComponent<Rigidbody2D>().AddForce(projectileKnockbackAngle * projectileKnockbackForce);
        }
    }
}