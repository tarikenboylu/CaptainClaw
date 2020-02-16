using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Officer : MonoBehaviour
{
    Vector3 sPos;
    public bool inRange = false;
    float pacingTime = 5f;

    void Start()
    {
        sPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<PlayerStats>().health -= 10;
    }

    void Update()
    {
        if (pacingTime < 0)
            GetComponent<Rigidbody2D>().position += new Vector2(1, 0);
        print(transform.position);
        GetComponent<Animator>().SetBool("Attack", inRange);
    }
}
