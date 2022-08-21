using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class InteractableObject : MonoBehaviour
{
    private bool IsInRange;

    public KeyCode Key;


    // Update is called once per frame
    void Update()
    {
        if (IsInRange && Input.GetKeyDown(Key))
        {
            Interact();
        }
    }

    protected abstract void Interact();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            IsInRange = false;
        }
    }
}
