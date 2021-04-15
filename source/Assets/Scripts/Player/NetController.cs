using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetController : MonoBehaviour
{
    public float speed = 10.0f;
    public Vector3 direction;
    public GameObject pointTextPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AppController.Instance.isPause)
            return;

        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fish") // Check if it is a fish
        {
            GameController.Instance.points += collision.gameObject.GetComponent<Fish_Stats>().points;

            GameObject pointTextGo = Instantiate(pointTextPrefab, UIManager_Game.Instance.gameObject.transform);
            pointTextGo.transform.position = Camera.main.WorldToScreenPoint(collision.gameObject.transform.position);
            pointTextGo.GetComponent<Text>().text = "+" + collision.gameObject.GetComponent<Fish_Stats>().points + " points";

            GameObject.Destroy(collision.gameObject);
            GameObject.Destroy(this.gameObject);
        }
    }
}
