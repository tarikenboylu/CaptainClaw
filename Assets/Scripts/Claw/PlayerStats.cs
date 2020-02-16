using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int point = 0;
    public int life = 2;
    public int health = 100;
    public int gun = 10;
    public int magic = 5;
    public int dynamit = 3;
    public Text scoreBoard;
    public AudioSource deathClawSound;
    public AudioSource deathFlag;
    public AudioSource startFlag;
    public Vector3 startPosition = new Vector3(-4.3f, 0.12f, -1);

    void Update()
    {
        if      (point < 100)
            scoreBoard.text = "0000000" + point;
        else if (point < 1000)
            scoreBoard.text = "00000" + point;
        else if (point < 10000)
            scoreBoard.text = "0000" + point;
        else if (point < 100000)
            scoreBoard.text = "000" + point;
        else if (point < 1000000)
            scoreBoard.text = "00" + point;
        else if (point < 10000000)
            scoreBoard.text = "0" + point;
        else
            scoreBoard.text = "" + point;

        if (health <= 1) 
        {
            deathClawSound.Play();
            deathFlag.PlayDelayed(1f);
            Invoke("Death", 2f);
        }
    }

    void Death()
    {
        transform.position = startPosition;
        health = 100;
        life -= 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Death"))
            health = 0;
    }
}
