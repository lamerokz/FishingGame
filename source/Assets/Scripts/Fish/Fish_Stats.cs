using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Stats : MonoBehaviour
{
    public enum E_DIRECTION { LEFT, RIGHT };

    // Start is called before the first frame update
    public int speed = 1;
    public int points = 1;
    public E_DIRECTION direction = E_DIRECTION.LEFT;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (AppController.Instance.isPause)
            return;
        transform.localScale = new Vector3(direction == E_DIRECTION.LEFT ? 1 : -1,1,1);
        transform.position += new Vector3(1, 0) * speed * (direction == E_DIRECTION.LEFT ? -1 : 1) *Time.deltaTime;
    }
}
