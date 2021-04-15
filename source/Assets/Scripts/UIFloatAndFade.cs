using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFloatAndFade : MonoBehaviour
{
    Text text;
    public float fadeDuration = 1.0f;
    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(Fade());
    }

    public IEnumerator Fade()
    {
        float fadeSpeed = 1.0f / fadeDuration;
        Color c = text.color;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * fadeSpeed)
        {
            c.a = Mathf.Lerp(1, 0, t);
            text.color = c;
            yield return true;
        }

        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
