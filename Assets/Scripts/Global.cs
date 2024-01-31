using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Global : MonoBehaviour
{
    [FormerlySerializedAs("objToSpawn")] public GameObject alien;
    // public float timer;
    // public float spawnPeriod;
    // public int numberSpawnedEachPeriod;
    public float screenCoord0;
    
    public Vector3 alienVelocity;
    public Vector3 downMove;
    public int score;

    public Alien currAlien;

    public float leftBound;
    public float rightBound;
    
    // Use this for initialization
    void Start()
    {
        score = 0;
        alienVelocity = new Vector3(0.1f, 0, 0);
        screenCoord0 = Camera.main.WorldToScreenPoint(new Vector3(0, 0, 0)).z;
        
        leftBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.05f, 0f, screenCoord0)).x;
        rightBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.95f, 0f, screenCoord0)).x;
        
        spawnAliens(Screen.height * 15f / 16f);
        
    }

    void spawnAlien(float x, float y)
    {
        var nextAlien = Instantiate(alien,
            Camera.main.ScreenToWorldPoint(
                new Vector3(x, y, screenCoord0)),
            Quaternion.identity).GetComponent<Alien>();
        currAlien.setNext(nextAlien);
        currAlien = nextAlien;
    }

    void spawnAliens(float startY)
    {
        var dummyAlien = Instantiate(alien).GetComponent<Alien>();
        currAlien = dummyAlien;
        
        var startX = Screen.width / 10f;
        var dx = Screen.width / 5f;
        var dy = Screen.height / 8f;
        for (int i = 0; i < 5; i++)
        {
            var y = startY - i * dy;
            spawnAlien(startX, y);
            spawnAlien(startX + dx, y);
            spawnAlien(startX + 2 * dx, y);
            spawnAlien(startX + 3 * dx, y);
            spawnAlien(startX + 4 * dx, y);
        }

        currAlien.setNext(dummyAlien);
        dummyAlien.Delete();
    }

    private void FixedUpdate()
    {
        currAlien.Move(alienVelocity);
        float x = currAlien.gameObject.transform.position.x;
        if (x < leftBound || x > rightBound)
        {
            var alien = currAlien;
            do
            {
                // alien.Move();
                alien = alien.nextAlien;
            } while (alien != currAlien);
            
            alienVelocity *= -1;
        }
        else
        {
            currAlien = currAlien.nextAlien;
        }
    }

    void Update()
    {
        // timer += Time.deltaTime;
        // if (timer > spawnPeriod)
        // {
        //     timer = 0;
        //     float width = Screen.width;
        //     float height = Screen.height;
        //     for (int i = 0; i < numberSpawnedEachPeriod; i++)
        //     {
        //         float horizontalPos = Random.Range(0.0f, width);
        //         float verticalPos = Random.Range(10.0f, height);
        //         Instantiate(alien,
        //             Camera.main.ScreenToWorldPoint(
        //                 new Vector3(horizontalPos, verticalPos, originInScreenCoords.z)),
        //             Quaternion.identity);
        //     }
        // }
        /* if you want to verify that this method works, uncomment
        this code. What will happen when it runs is that one object will be spawned
        at each corner of the screen, regardless of the size of the screen. If you
        pause the Scene and inspect each object, you will see that each has a Ycoordinate
        value of 0.
        */
        /*
        Vector3 botLeft = new Vector3(0,0,originInScreenCoords.z);
        Vector3 botRight = new Vector3(width, 0,
        originInScreenCoords.z);
        Vector3 topLeft = new Vector3(0, height,
        originInScreenCoords.z);
        Vector3 topRight = new Vector3(width, height,
        originInScreenCoords.z);
        Instantiate(objToSpawn,
        Camera.main.ScreenToWorldPoint(topLeft), Quaternion.identity );
        Instantiate(objToSpawn,
        17
        Camera.main.ScreenToWorldPoint(topRight), Quaternion.identity );
        Instantiate(objToSpawn,
        Camera.main.ScreenToWorldPoint(botLeft), Quaternion.identity );
        Instantiate(objToSpawn,
        Camera.main.ScreenToWorldPoint(botRight), Quaternion.identity );*/
    }
}