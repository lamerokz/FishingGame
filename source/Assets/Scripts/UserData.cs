using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    // Start is called before the first frame update
    public int totalPoints;
    public int remainingToken;

    private static UserData instance = null;

    // Game Instance Singleton
    public static UserData Instance
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

    public int UseToken(int amt)
    {
        if (amt < 0)
            return -1;

        if (remainingToken >= amt)
        {
            remainingToken -= amt;
            return 1; // successfully reducing token
        }


        return -1; // return -1 if API fails
    }

    public int AddPoints(int amt)
    {
        if (amt > 0)
        {
            totalPoints += amt;
            return 1;
        }

        return -1;
    }

    public int GetRemainingTokenCount()
    {
        return remainingToken;
    }
}
