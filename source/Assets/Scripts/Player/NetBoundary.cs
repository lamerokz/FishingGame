using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetBoundary : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Net") // Check if it is a net
        {
            GameObject.Destroy(collision.gameObject);
        }
    }
}
