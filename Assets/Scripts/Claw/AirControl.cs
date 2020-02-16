using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirControl : MonoBehaviour
{
    public Transform rayPositionLeft;
    public Transform rayPositionRight;
    bool balance = false;

    void Update()
    {
        float feet = Physics2D.Raycast(rayPositionLeft.position, Vector2.down, Mathf.Infinity).distance;
        float feet2 = Physics2D.Raycast(rayPositionRight.position, Vector2.down, Mathf.Infinity).distance;

        GetComponent<Animator>().SetFloat("OnAir", Mathf.Min(feet, feet2));
        GetComponent<Animator>().SetBool("Balance", balance);

        if(feet > 0.02f && feet2 > 0.02f)
            GetComponent<Animator>().SetBool("Jump", false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BalancePoint"))
            if(GetComponent<CharacterController2D>().stable)
                balance = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("BalancePoint"))
            balance = false;
    }
}
