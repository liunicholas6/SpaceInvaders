using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ScoreUI : MonoBehaviour
{
    Global globalObj;
    Text scoreText;
    Text bombsText;
    Text livesText;
    // Use this for initialization
    void Start()
    {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        scoreText = transform.Find("ScorePanel").GetComponent<Text>();
        bombsText = transform.Find("BombsPanel").GetComponent<Text>();
        livesText = transform.Find("LivesPanel").GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {globalObj.score.ToString()}";
        bombsText.text = $"Sacrifices: {globalObj.sacrifices.ToString()}";
        livesText.text = $"Lives: {globalObj.lives.ToString()}";
    }
}