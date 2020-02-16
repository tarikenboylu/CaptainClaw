using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBoxTreasures : MonoBehaviour
{
    public Vector2 throwVector = new Vector2(0, 1.5f);
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(throwVector);
    }
}
