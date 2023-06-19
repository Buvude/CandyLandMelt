using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    public void QuitPressed() 
    {
        LosingConditionManager.deadCitizens = 0;
        SceneManager.LoadScene(0);
    }
}
