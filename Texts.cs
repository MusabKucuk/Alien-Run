using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texts : MonoBehaviour
{
    public Text scoreText;
    public Transform player;
    public float score = 0f;
    private float previousPlayerPos;

    private void Awake()
    {
        startingPosition();
    }

    private void startingPosition()
    {
        previousPlayerPos = player.position.x;
    }

    public void writeScore()
    {
        if (previousPlayerPos < player.position.x)
        {
            score += (player.position.x - previousPlayerPos) * 2;
            previousPlayerPos = player.transform.position.x;
            scoreText.text = "Score: " + score.ToString("0");
        }        
    }

    public void FixedUpdate()
    {
        writeScore();
    }

    public float getScore()
    {
        return score;
    }
}
