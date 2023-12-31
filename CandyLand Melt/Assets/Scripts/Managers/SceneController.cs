using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0)|| SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Score>().displayHighScore();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoseGame()
    {
        SceneManager.LoadScene(2);
    }
    public void ReturnToTittle()
    {
        SceneManager.LoadScene(0);
    }
}
