using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBoundary : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fish") // Check if it is a fish
        {
            GameObject.Destroy(collision.gameObject);
        }
    }
}
