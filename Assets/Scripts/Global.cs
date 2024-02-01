using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Global : MonoBehaviour
{
    public Vector3 horizontalMove;
    public Vector3 verticalMove;
    public int score;
    public int lives;

    public GameObject alienSwarm;
    public Alien currAlien;

    public float leftBound;
    public float rightBound;
    public float lowerBound;
    
    public int level = 0;
    
    // Use this for initialization
    void Start()
    {
        score = 0;
        lives = 3;
        horizontalMove = new Vector3(0.1f, 0, 0);
        SpawnAliens();
    }
    private void FixedUpdate()
    {
        currAlien.Move(horizontalMove);
        float x = currAlien.gameObject.transform.position.x;
        if (x < leftBound || x > rightBound)
        {
            var alien = currAlien;
            do
            {
                alien.Move(verticalMove);
                if (alien.gameObject.transform.position.z < lowerBound)
                {
                    GameOver();
                }
                alien = alien.nextAlien;
            } while (alien != currAlien);
            
            horizontalMove *= -1;
        }
        else
        {
            currAlien = currAlien.nextAlien;
        }
    }

    public void SpawnAliens()
    {
        var swarm = Instantiate(alienSwarm);
        swarm.transform.position += verticalMove * level;
        currAlien = swarm.transform.GetChild(0).GetComponent<Alien>();
        level = (level + 1) % 3;
    }

    public void LoseLife()
    {
        lives--;
        if (lives == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Scenes/GameOverScene");
    }
}