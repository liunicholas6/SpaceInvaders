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

    public Material red;
    public Material green;
    public Material blue;
    
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

    void SpawnAlien(float x, int y, int points, Material mat)
    {
        var nextAlien = Instantiate(alien,
            topLeft + x * rightUnit + y * downUnit,
            Quaternion.identity).GetComponent<Alien>();
        nextAlien.pointValue = points;
        nextAlien.gameObject.GetComponent<Renderer>().material = mat;
        nextAlien.level = y;
        currAlien.SetNext(nextAlien);
        currAlien = nextAlien;
    }

    void SpawnAliens(int level)
    {
        var dummyAlien = Instantiate(alien).GetComponent<Alien>();
        currAlien = dummyAlien;
        
        for (int x = 0; x < 5; x++)
        {
            SpawnAlien(x, level, 30, red);
            SpawnAlien(x, level + 1, 20, green);
            SpawnAlien(x, level + 2, 20, green);
            SpawnAlien(x, level + 3, 20, blue);
            SpawnAlien(x, level + 4, 20, blue);
        }

        currAlien.SetNext(dummyAlien);
        dummyAlien.Delete();
    }
}
