using System;
using UnityEngine;
using UnityEngine.UI;
public class ScoreUI : MonoBehaviour
{
    Global globalObj;
    Text scoreText;
    // Use this for initialization
    void Start()
    {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        scoreText = gameObject.GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = String.Format("Score: {0}, Lives: {1}", globalObj.score.ToString(), globalObj.lives);
    }
}