using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EFFBobble : MonoBehaviour
{
    Vector3 startScale;

    public float scaleFactor = 1.2f;
    public float scaleUpDuration = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;
        StartCoroutine(BobbleScaleUp());
    }

    public IEnumerator BobbleScaleUp()
    {
        float scaleSpeed = 1.0f / scaleUpDuration;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * scaleSpeed)
        {
            transform.localScale = startScale * Mathf.Lerp(1, scaleFactor, t);
            yield return true;
        }

        StartCoroutine(BobbleScaleDown());
    }

    public IEnumerator BobbleScaleDown()
    {
        float scaleSpeed = 1.0f / scaleUpDuration;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * scaleSpeed)
        {
            transform.localScale = startScale * Mathf.Lerp(scaleFactor, 1, t);
            yield return true;
        }

        StartCoroutine(BobbleScaleUp());
    }

}
