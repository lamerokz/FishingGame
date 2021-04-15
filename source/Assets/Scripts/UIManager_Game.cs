using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_Game : MonoBehaviour
{
    public Text timeText;
    public Text pointText;
    public GameObject resultMenu;
    public Text resultText;

    private static UIManager_Game instance = null;
    public static UIManager_Game Instance
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

    // Update is called once per frame
    void Update()
    {
        timeText.text = GameController.Instance.GetTimeRemaining().ToString();
        pointText.text = GameController.Instance.points.ToString();
    }

    public void ShowResultScreen()
    {
        resultMenu.SetActive(true);

        resultText.text = "Points Held: " + UserData.Instance.totalPoints +
            "\nPoints Obtained: " + GameController.Instance.points +
            "\n ------------------------------------------------\n" +
            "Total Points Held: " + (UserData.Instance.totalPoints + GameController.Instance.points).ToString();
    }

    public void TallyPointsAndReturnToTitle()
    {
        AppController.Instance.BackToTitle();
        UserData.Instance.AddPoints(GameController.Instance.points);
    }

}
