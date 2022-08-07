using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidObject : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Collision woth player");

            var player = other.gameObject.GetComponent<Player>();

            player.OnObjectCollision(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Collision exit player");

            var player = other.gameObject.GetComponent<Player>();

            player.OnObjectCollisionExit();
        }
    }
}
