using UnityEngine;

public class SpeedUpText : MonoBehaviour
{
    private GameTime timer;
    [SerializeField] private GameObject[] objectsToShow;
    [SerializeField] private float timeShowingObjects;
    private void Start()
    {
        timer = new GameTime();
        timer.SetTimer(timeShowingObjects);
    }
    public void ShowChildren(bool show)
    {
        foreach(GameObject current in objectsToShow)
        {
            current.SetActive(show);
        }
        if(show)
            timer.Start();
    }
    private void Update()
    {
        if (timer.Update(Time.deltaTime))
        {
            ShowChildren(false);
            timer.StopAndReset();
        }
    }
}