using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GrenadeCollision : MonoBehaviour
{
    public GameObject prefab;
    public float effectDuration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameObject effect = Instantiate(prefab, transform.position, Quaternion.identity);
        //Destroy(effect, effectDuration);
        Destroy(gameObject);
    }
}