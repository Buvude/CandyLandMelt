using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LosingConditionManager
{
    public const int citizensLimit = 3;
    public static int deadCitizens = 0;

    public static void CitizenDied() 
    {
        deadCitizens += 1;
        if (deadCitizens >= citizensLimit)
        {
            GameManager.Instance.EndGame();
            SceneManager.LoadScene(2);
        }
    }
}
