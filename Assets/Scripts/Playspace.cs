using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playspace : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Works!");
        collision.transform.Translate(Vector2.down);
    }
}
