using UnityEngine;

public class IceMachine : MonoBehaviour
{
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private string poolName;
    private PoolManager poolManager;
    private Pool icePool;
    private GameTime timer;
    private void Start()
    {
        poolManager = PoolManager.GetInstance();
        icePool = poolManager.GetPool(poolName);
        timer = new GameTime();
        timer.SetTimer(timeBetweenSpawns);
        timer.Start();
    }
    
    private void Update()
    {
        if(timer.Update(Time.deltaTime))
        {
            PoolObject ice = icePool.GetPooledObject();
            ice.GetComponent<Transform>().position = this.transform.position;
            timer.StopAndReset();
            timer.Start();
        }
    }
}