using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Bullet : MonoBehaviour
{
    private float dZenit, dAzimut;

    [SerializeField] private float radius;
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    public float Zenit, Azimut;

    public float DZenit { get => dZenit; set => dZenit = value; }
    public float DAzimut { get => dAzimut; set => dAzimut = value; }

    public INamedEntity Owner;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Zenit += dZenit * speed * Time.deltaTime;
        Azimut += dAzimut * speed * Time.deltaTime;

        transform.position = Utils.SphereToDecart(Zenit, Azimut, radius);
    }
}
