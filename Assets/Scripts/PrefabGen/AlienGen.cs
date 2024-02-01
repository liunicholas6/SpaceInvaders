using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienGen : MonoBehaviour
{
    public Alien currAlien;
    public GameObject alien;

    public Vector3 topLeft;
    public Vector3 rightUnit;
    public Vector3 downUnit;

    public float leftBound;
    public float rightBound;
    
    // Use this for initialization
    void Start()
    {
        var screenCoord0 = Camera.main.WorldToScreenPoint(new Vector3(0, 0, 0)).z;
        topLeft = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 1/ 12f, Screen.height * 24f / 25f, screenCoord0));
        rightUnit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 1/4f, Screen.height * 24f / 25f, screenCoord0)) - topLeft;
        downUnit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 1/12f, Screen.height * 22f / 25f, screenCoord0)) - topLeft;
        
        leftBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.05f, 0f, screenCoord0)).x;
        rightBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.95f, 0f, screenCoord0)).x;
        
        SpawnAliens(0);
    }

    void SpawnAlien(float x, float y)
    {
        var nextAlien = Instantiate(alien,
            topLeft + x * rightUnit + y * downUnit,
            Quaternion.identity).GetComponent<Alien>();
        currAlien.SetNext(nextAlien);
        currAlien = nextAlien;
    }

    void SpawnAliens(float startY)
    {
        var dummyAlien = Instantiate(alien).GetComponent<Alien>();
        currAlien = dummyAlien;
        
        for (int i = 0; i < 5; i++)
        {
            var y = startY + i;
            SpawnAlien(0, y);
            currAlien.pointValue = 30;
            SpawnAlien(1, y);
            currAlien.pointValue = 20;
            SpawnAlien( 2, y);
            currAlien.pointValue = 20;
            SpawnAlien(3, y);
            SpawnAlien(4, y);
        }

        currAlien.SetNext(dummyAlien);
        dummyAlien.Delete();
    }
}
