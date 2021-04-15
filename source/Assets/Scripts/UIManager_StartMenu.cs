using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_StartMenu : MonoBehaviour
{
    public Text tokenText;
    public Text PointsText;
    public Button playBtn;

    // Start is called before the first frame update
    void Start()
    {
        UpdateTokenText();
        UpdatePointsText();
    }

    private void Update()
    {
        playBtn.enabled = UserData.Instance.GetRemainingTokenCount() > 0;
    }

    public void UpdateTokenText()
    {
        tokenText.text = "Play Token Held: " + UserData.Instance.GetRemainingTokenCount().ToString();
    }

    public void UpdatePointsText()
    {
        PointsText.text = "Points Held: " + UserData.Instance.totalPoints;
    }

    public void PlayGame()
    {
        UpdateTokenText();
        AppController.Instance.PlayGame();
    }
}
