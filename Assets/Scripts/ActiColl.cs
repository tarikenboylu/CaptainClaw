using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiColl : MonoBehaviour
{
    public Collider2D bas;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Activator") && other.GetComponentInParent<CharacterController2D>().fall)
            bas.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
            bas.enabled = false;
    }
}
