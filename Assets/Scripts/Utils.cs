using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Utils
{
    public static Vector3 SphereToDecart(float zenit, float azimut, float radius)
    {

        float x = radius * Mathf.Sin(ConvertAngle(zenit)) * Mathf.Cos(ConvertAngle(azimut));
        float z = radius * Mathf.Sin(ConvertAngle(zenit)) * Mathf.Sin(ConvertAngle(azimut));
        float y = radius * Mathf.Cos(ConvertAngle(zenit));

        return new Vector3(x, y, z);
    }
    
    //TODO: add radius and count length
    public static bool IsInRange(Vector2 firstPoint, Vector2 secondPoint, float range)
    {

        return Math.Abs(firstPoint.x - secondPoint.x) < range
            && Math.Abs(firstPoint.y - secondPoint.y) < range;
    }

    private static float ConvertAngle(float angle) => angle * Mathf.Deg2Rad;
}
