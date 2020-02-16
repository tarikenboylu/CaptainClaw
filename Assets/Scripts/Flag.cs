using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public Vector3 savePosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("claw"))
            GetComponent<PlayerStats>().startPosition = savePosition;
    }
}
