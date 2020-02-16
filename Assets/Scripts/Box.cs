using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject ingredients;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ClawSword"))
        {
            Destroy(gameObject, 0.5f);
            GetComponent<Animator>().SetBool("Break", true);
            Instantiate(ingredients, transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
}
