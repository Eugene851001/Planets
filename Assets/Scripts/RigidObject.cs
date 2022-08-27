using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidObject : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision) => ProcessCollsionEnter(collision.gameObject);

    private void OnCollisionExit(Collision collision) => ProcessCollisionExit(collision.gameObject);

    private void OnTriggerEnter(Collider other) => ProcessCollsionEnter(other.gameObject);

    private void OnTriggerExit(Collider other) => ProcessCollisionExit(other.gameObject);

    private void ProcessCollsionEnter(GameObject other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Collision woth player");

            var player = other.GetComponent<Player>();

            player.OnObjectCollision(this.gameObject);
        }
    }

    private void ProcessCollisionExit(GameObject other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Collision exit player");

            var player = other.GetComponent<Player>();

            player.OnObjectCollisionExit();
        }
    }
}
