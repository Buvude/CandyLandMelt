using UnityEngine;

public class IceMachine : MonoBehaviour
{
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private string poolName;
    [SerializeField] private Animator anim;
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
            if(ice != null)
            {
                ice.GetComponent<Transform>().position = this.transform.position;
                timer.StopAndReset();
                timer.Start();
            }
            /*
            int actives = icePool.GetObjectCount();
            int max = icePool.GetMaxNumber();
            if (icePool.GetObjectCount() >= icePool.GetMaxNumber())
            {
                anim.SetBool("Open", false);
            }
            else
                anim.SetBool("Open", true);*/
        }
    }
}