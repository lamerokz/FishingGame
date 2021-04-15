using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum E_APPSTATE
{
    STARTMENU = 0,
    GAME,
    RESULT
}

public class AppController : MonoBehaviour
{
    public E_APPSTATE appState = E_APPSTATE.STARTMENU;
    public bool isPause = false;

    private static AppController instance = null;

    // Game Instance Singleton
    public static AppController Instance
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
        else
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void PlayGame()
    {
        // handling token deduction
        int result = UserData.Instance.UseToken(1); // TODO: Change to actual API call
        if (result == -1) // error handling
        {
            Debug.LogError("API FAILURE: UserData.UseToken  Error code: " + result);
            return;
        }

        // handling update of app state and scene transition
        appState = E_APPSTATE.GAME;
        TransitScene((int)appState);

        ResumeGame();
    }

    public void PauseGame()
    {
        isPause = true;
    }

    public void ResumeGame()
    {
        isPause = false;
    }

    public void BackToTitle()
    {
        // handling update of app state and scene transition
        appState = E_APPSTATE.STARTMENU;
        TransitScene((int)appState);
    }

    public void TransitScene(int sceneIdx)
    {
        SceneManager.LoadScene(sceneIdx);
    }
}
