using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityData : MonoBehaviour
{
    public float HP;
    public float maxSpeed = 10;
    public float speed = 10;
    public bool speedAffected = false;

    void Update()
    {
        if (HP <= 0)
        {
            //death
        }
    }
}
