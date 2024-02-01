using System.Collections.Generic;
using UnityEngine;

public class ShieldGen : MonoBehaviour
{
    public GameObject shieldBlockPrefab;
    // Start is called before the first frame update
    void Start()
    {
        List<Vector2> points = new();
        for (int x = -3; x <= 3; x++)
        {
            points.Add(new Vector2(x, 2));
            points.Add(new Vector2(x, 1));
        }

        foreach (int x in new float[]{-3, -2, 2, 3})
        {
            points.Add(new Vector2(x, 0));
        }

        foreach (int x in new float[] { -3, 3 })
        {
            points.Add(new Vector2(x, -1));
            points.Add(new Vector2(x, -2));
        }

        foreach (Vector2 point in points)
        {
            Instantiate(shieldBlockPrefab, new Vector3(point.x, 0, point.y), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
