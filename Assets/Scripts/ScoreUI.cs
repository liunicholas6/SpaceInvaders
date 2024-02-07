using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ScoreUI : MonoBehaviour
{
    Global globalObj;
    Text scoreText;
    Text livesText;
    // Use this for initialization
    void Start()
    {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        scoreText = transform.Find("ScorePanel").GetComponent<Text>();
        livesText = transform.Find("LivesPanel").GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {globalObj.score.ToString()}";
        livesText.text = $"Lives: {globalObj.lives.ToString()}";
    }
}