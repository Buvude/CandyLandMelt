using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenBehaviour : MonoBehaviour
{
    [SerializeField] private float totalHealth;
    private float health;
    
    private void BeginBehaviour() 
    {
        health = totalHealth;
    }

    private void Start()
    {
        BeginBehaviour();
    }

    public void SetHealth(float _health) 
    {
        health = _health;
    }

    public void TakeDamage(float damage) 
    {
        health -= damage;
        Death();
    }

    public void RecoverHealth(float recover) 
    {
        health += recover;
    }

    public void FullHealthRecover() 
    {
        health = totalHealth;
    }

    private void Death() 
    {
        if (health <= 0)
            this.gameObject.SetActive(false);
    }

    public float GetTotalHealth() 
    {
        return totalHealth;
    }

    public float GetHealth() 
    {
        return health;
    }

    public bool IsAlive() 
    {
        return health > 0;
    }
}
