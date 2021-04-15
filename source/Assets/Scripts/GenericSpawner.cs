using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSpawner : MonoBehaviour
{
    public int upperBounds, lowerBounds = 0;
    public int leftBounds, rightBounds = 0;
    public float spawnInterval = 3.0f;
    public List<GameObject> spawnObjList = new List<GameObject>();


    public int minWarmUpCounter, maxWarmUpCounter;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WarmUpCountdown());
    }

    private IEnumerator WarmUpCountdown()
    {
        yield return new WaitForSeconds(Random.Range(minWarmUpCounter, maxWarmUpCounter));

        SpawnObject();
        StartCoroutine(SpawnTimer());
    }


    private IEnumerator SpawnTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        if (AppController.Instance.isPause)
            return;

        int index = Random.Range(0, spawnObjList.Count);
        GameObject GO = Instantiate(spawnObjList[index]);
        GO.transform.position = new Vector2(Random.Range(leftBounds, rightBounds), Random.Range(lowerBounds, upperBounds));
    }
}
