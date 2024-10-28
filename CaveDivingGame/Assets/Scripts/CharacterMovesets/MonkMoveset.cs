using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class MonkMoveset
{

    public static float attack1Cooldown = 1f;
    public static float attack2Cooldown = 3f;
    public static float attack3Cooldown = 5f;

    public static void Attack1(Transform player, GameObject prefab, float direction)
    {
        if (player.GetComponent<PlayerInputHandling>().attack1Cooldown >= attack1Cooldown)
        {
            player.GetComponent<PlayerInputHandling>().attack1Cooldown = 0;

            player.GetComponent<PlayerInputHandling>().Projectile(player.position + new Vector3(1.5f, 0) * direction, 1, prefab, true, new Vector2(1, 0), direction);

        }
    }

    public static void Attack2(Transform player, GameObject prefab, float direction)
    {
        if (player.GetComponent<PlayerInputHandling>().attack2Cooldown >= attack2Cooldown)
        {
            player.GetComponent<PlayerInputHandling>().attack2Cooldown = 0;

            player.GetComponent<PlayerInputHandling>().Projectile(player.position + new Vector3(prefab.GetComponent<ProjectileData>().projectileSpeed, 0, 0) * direction, 1, prefab, false, new Vector2(-1, 0), direction);

        }
    }

    public static void Attack3(Transform player, GameObject prefab, float direction, float vertLook)
    {
        if (player.GetComponent<PlayerInputHandling>().attack3Cooldown >= attack3Cooldown)
        {
            player.GetComponent<PlayerInputHandling>().attack3Cooldown = 0;

            player.GetComponent<PlayerInputHandling>().Projectile(player.position + new Vector3(1.5f * direction, 0) + new Vector3(0, 6) * (vertLook == -1 ? 1 : 0), 0.2f, prefab, false, new Vector2(0, 1 * vertLook == -1 ? -1 : 1), direction);

        }
    }
}