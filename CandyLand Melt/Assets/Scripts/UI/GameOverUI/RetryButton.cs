using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    [SerializeField] public string sceneToLoad;

    public void RetryPressed() 
    {
        LosingConditionManager.deadCitizens = 0;
        SceneManager.LoadScene(sceneToLoad);
    }
}
