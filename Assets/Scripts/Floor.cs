using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float holeSize;
    public float spawnTime;
    
    private Transform leftFloor;
    private Transform rightFloor;
    // Start is called before the first frame update
    void Start()
    {
        leftFloor = transform.GetChild(0);
        rightFloor = transform.GetChild(1);
        StartCoroutine(HoleRoutine());
    }

    IEnumerator HoleRoutine()
    {
        while (true)
        {
            float t = Random.value;
            Debug.Log(t);
            MakeHole(t);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    void MakeHole(float t)
    {
        var leftScale = leftFloor.localScale;
        leftScale.x = t - holeSize;
        leftFloor.localScale = leftScale;

        var leftPos = leftFloor.localPosition;
        leftPos.x = 0.5f * leftScale.x;
        leftFloor.localPosition = leftPos;
        
        var rightScale = rightFloor.localScale;
        rightScale.x = 1f - t - holeSize;
        rightFloor.localScale = rightScale;

        var rightPos = rightFloor.localPosition;
        rightPos.x = t + holeSize + 0.5f * rightScale.x;
        rightFloor.localPosition = rightPos;
        

    }
}
