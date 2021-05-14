using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playspace : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.attachedRigidbody.AddForce(new Vector2(0, 5));
    }
}
