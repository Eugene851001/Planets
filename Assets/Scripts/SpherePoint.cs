using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePoint : MonoBehaviour
{
    protected float azimut, zenit;
    protected float radius;

    public float Azimut => azimut;
    public float Zenit => zenit;

    public GameObject Planet;
    // Start is called before the first frame update
    void Start()
    {
        if (Planet != null)
        {
            SetRadius();
        }
    }

    public void InitPlanet(GameObject planet)
    {
        Planet = planet;
        SetRadius();
    }

    private void SetRadius() =>
       radius = Planet.GetComponent<SphereCollider>().radius * Planet.gameObject.transform.localScale.x;
}
