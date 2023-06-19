using System.IO;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int _score = 0;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private int _regularPointValue;
    [SerializeField] private string _fileName;

    private int highScore = 0;

    public static Score Instance { get; private set; }
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
    public void AddScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        _scoreText.text = _score.ToString();
    }
    public void ResetScore() { _score = 0; }
    public int GetRegularPointValue() { return _regularPointValue; }
    public void LoadScore()
    {
        if (File.Exists(Application.persistentDataPath + "/" + _fileName))
        {
            string jsonData = File.ReadAllText(Application.persistentDataPath + "/" + _fileName);
            highScore = int.Parse(jsonData);
        }
    }
    public void SaveScore()
    {
        if(_score > highScore)
            File.WriteAllText(Application.persistentDataPath + "/" + _fileName, _score.ToString());
    }

    public void displayHighScore()
    {
        _scoreText.text = highScore.ToString();
    }
}
