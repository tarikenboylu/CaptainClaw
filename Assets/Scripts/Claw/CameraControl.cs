using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject character;
    public Vector3 dis;

    void Start()
    {
        dis = transform.position - character.transform.position;
    }

    void Update()
    {
        transform.position = character.transform.position + dis;
    }
}
