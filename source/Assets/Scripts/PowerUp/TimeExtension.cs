using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeExtension : MonoBehaviour
{
    public float additionalTime = 5.0f;
    TextMesh timeText;
    public GameObject timeTextPrefab;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<TextMesh>();
        timeText.text = "+" + additionalTime + "s";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Net") 
        {
            GameController.Instance.AddTime(additionalTime);

            GameObject timeTextGO = Instantiate(timeTextPrefab, UIManager_Game.Instance.gameObject.transform);
            timeTextGO.transform.position = Camera.main.WorldToScreenPoint(transform.position);
            timeTextGO.GetComponent<Text>().text = "+" + additionalTime + "s";

            GameObject.Destroy(collision.gameObject);
            GameObject.Destroy(this.gameObject);
        }
    }
}
