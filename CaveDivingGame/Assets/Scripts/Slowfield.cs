using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowfield : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EntityData>().speed = 0.5f * collision.GetComponent<EntityData>().maxSpeed;
            collision.GetComponent<EntityData>().speedAffected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EntityData>().speedAffected = false;
        }
    }
}
