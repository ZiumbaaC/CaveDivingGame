using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class RangerMoveset
{
    public static float attack1Damage = 5;
    public static float throwForce = 450;

    public static float attack1Cooldown = 0.25f;
    public static float attack2Cooldown = 10f;
    public static float attack3Cooldown = 10f;

    public static void Attack1(Transform player, float direction, float lookVertical)
    {
        if (player.GetComponent<PlayerInputHandling>().attack1Cooldown >= attack1Cooldown)
        {
            player.GetComponent<PlayerInputHandling>().attack1Cooldown = 0;

            RaycastHit2D[] hits = Physics2D.RaycastAll(player.position, new Vector2(direction, lookVertical * 0.5f).normalized);

            for(int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.CompareTag("Tiles"))
                {
                    break;
                }

                if (hits[i].collider.CompareTag("Enemy"))
                {
                    hits[i].collider.GetComponent<EntityData>().HP -= attack1Damage + (hits[i].collider.GetComponent<EntityData>().speedAffected ? attack1Damage / 5 : 0) + (hits[i].collider.GetComponent<EntityData>().gravityAffected ? attack1Damage / 5 : 0);
                }
            }
        }
    }

    public static void Attack2(Transform player, GameObject prefab, float direction, float lookVertical)
    {
        if (player.GetComponent<PlayerInputHandling>().attack2Cooldown >= attack2Cooldown)
        {
            player.GetComponent<PlayerInputHandling>().attack2Cooldown = 0;

            player.GetComponent<PlayerInputHandling>().GrenadeProjectile(player.position, prefab, new Vector2(0.5f, 0.5f).normalized, direction, throwForce, lookVertical);

        }
    }

    public static void Attack3(Transform player, GameObject prefab, float direction, float lookVertical)
    {
        if (player.GetComponent<PlayerInputHandling>().attack3Cooldown >= attack3Cooldown)
        {
            player.GetComponent<PlayerInputHandling>().attack3Cooldown = 0;

            player.GetComponent<PlayerInputHandling>().GrenadeProjectile(player.position, prefab, new Vector2(0.5f, 0.5f).normalized, direction, throwForce, lookVertical);

        }
    }
}