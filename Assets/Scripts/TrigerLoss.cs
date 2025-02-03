using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerLoss : MonoBehaviour
{
    private float timer;

    private bool isGameOver;

    private void Start() 
    {
        isGameOver = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == 7 && !isGameOver)
        {
            //AudioManager.Instance.PlaySFX("Timer");
            isGameOver = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.gameObject.layer == 7)
        {
            timer += Time.deltaTime;
            if (timer >= GameManager.Instance.timeTillGameOver)
            {
                GameManager.Instance.GameOver();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.layer == 7)
        {
            timer = 0;
            isGameOver = false;
        }
    }
}
