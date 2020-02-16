using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficerAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Claw"))
            GetComponentInParent<Officer>().inRange = true;
    }
}
