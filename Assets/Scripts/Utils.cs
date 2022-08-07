using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static Vector3 SphereToDecart(float zenit, float azimut, float radius)
    {

        float x = radius * Mathf.Sin(zenit * Mathf.Deg2Rad) * Mathf.Cos(azimut * Mathf.Deg2Rad);
        float z = radius * Mathf.Sin(zenit * Mathf.Deg2Rad) * Mathf.Sin(azimut * Mathf.Deg2Rad);
        float y = radius * Mathf.Cos(zenit * Mathf.Deg2Rad);

        return new Vector3(x, y, z);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
