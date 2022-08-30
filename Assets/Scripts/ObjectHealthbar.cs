using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealthbar : Healthbar
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(this.transform.position - _camera.transform.position);
    }
}
