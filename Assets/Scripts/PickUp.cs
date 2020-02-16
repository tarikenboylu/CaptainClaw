using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public int value = 100;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Claw"))
        {
            Destroy(gameObject);
            other.GetComponent<PlayerStats>().point += value;
        }
    }
}
