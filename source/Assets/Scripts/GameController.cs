using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameController instance = null;
    public int points = 0;
    public float startRoundTime = 20.0f;
    float timeRemaining = 0.0f;
    public static GameController Instance
    {
        get
        {
            return instance;
        }
    }
    void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
    }

    void Start()
    {
        timeRemaining = startRoundTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining = Mathf.Clamp(timeRemaining - Time.deltaTime, 0, timeRemaining);
        if (timeRemaining <= 0 && !AppController.Instance.isPause)
        {
            AppController.Instance.PauseGame();
            UIManager_Game.Instance.ShowResultScreen();
        }
    }

    public void AddTime(float time)
    {
        timeRemaining += time;
    }

    public float GetTimeRemaining()
    {
        return timeRemaining;
    }
}
