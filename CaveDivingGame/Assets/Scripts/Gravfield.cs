using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravfield : MonoBehaviour
{
    public float dragSpeed;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            float x = Vector3.Distance(transform.position, collision.transform.position);

            Vector2 dragging = dragSpeed * (1.1f * (x / (x + 1))) * (transform.position - collision.transform.position).normalized;
            //^ eventually add this vector to the enemies velocity
        }
    }
}