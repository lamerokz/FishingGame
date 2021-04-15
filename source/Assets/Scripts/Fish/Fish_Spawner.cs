using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Spawner : MonoBehaviour
{
    public int upperBounds, lowerBounds = 0;
    public float spawnInterval = 3.0f;
    public Fish_Stats.E_DIRECTION direction = Fish_Stats.E_DIRECTION.LEFT;
    public List<GameObject> fishPrefabList = new List<GameObject>();

    public int minWarmUpCounter, maxWarmUpCounter;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WarmUpCountdown());
    }

    private IEnumerator WarmUpCountdown()
    {
        yield return new WaitForSeconds(Random.Range(minWarmUpCounter, maxWarmUpCounter));

        SpawnFish();
        StartCoroutine(SpawnFishTimer());
    }


    private IEnumerator SpawnFishTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            SpawnFish();
        }
    }

    private void SpawnFish()
    {
        if (AppController.Instance.isPause)
            return;

        int randFishIndex = Random.Range(0, fishPrefabList.Count);
        GameObject fishGO = Instantiate(fishPrefabList[randFishIndex]);
        fishGO.transform.position = new Vector2(transform.position.x, Random.Range((float)lowerBounds, (float)upperBounds));
        fishGO.GetComponent<Fish_Stats>().direction = direction;
    }
}
