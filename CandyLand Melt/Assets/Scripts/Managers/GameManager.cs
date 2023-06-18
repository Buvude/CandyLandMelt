using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Score score;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        score.LoadScore();
        ResetGame();
    }
    public void EndGame()
    {
        score.SaveScore();
    }
    private void ResetGame()
    {
        score.ResetScore();
    }
}