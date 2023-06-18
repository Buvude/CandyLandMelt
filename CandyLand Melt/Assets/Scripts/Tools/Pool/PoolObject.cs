using UnityEngine;

public class PoolObject : MonoBehaviour
{

    public delegate void ObjectRecycle(PoolObject po);
    public event ObjectRecycle onRecycle;

    private Pool pool;
    private float timerOnLive; // timer que decide cuanto tiempo ese objeto existe (mas que nada para las balas)
    private const float timeToLive = 10; // Const para el timer (Buenas practicas)

    private void Start()
    {
        /*if (this.tag == "Bomb") // Solo si es una bomba
        {
            timerOnLive = timeToLive;
            bomb = GetComponent<Bomb>();
        }*/
    }

    private void Update()
    {
        
    }
    public void SetPool(Pool comingPool)
    {
        pool = comingPool;
    }

    public void Recycle()
    {
        if (onRecycle != null)
            onRecycle(this);

        pool.Recycle(this);
    }
    /*
    private void OnTriggerEnter(Collider other) 
    {

    }
    */
}
