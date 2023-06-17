using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenBehaviour : MonoBehaviour
{
    [SerializeField] private float totalHealth;
    [SerializeField] private float healthToRecover = 5;
    [SerializeField] private float currentHealth;
    
    private void BeginBehaviour() 
    {
        currentHealth = totalHealth;
    }

    private void Start()
    {
        BeginBehaviour();
    }

    public void SetHealth(float _health) 
    {
        currentHealth = _health;
        if (health > totalHealth)
            health = totalHealth;
    }

    public void TakeDamage(float damage) 
    {
        currentHealth -= damage;
        Death();
    }

    public void RecoverHealth() 
    {

        currentHealth += healthToRecover;
        if (currentHealth > totalHealth)
            FullHealthRecover();
    }

    public void FullHealthRecover() 
    {
        currentHealth = totalHealth;
    }

    private void Death() 
    {
        if (currentHealth <= 0)
            this.gameObject.SetActive(false);
    }

    public float GetTotalHealth() 
    {
        return totalHealth;
    }

    public float GetHealth() 
    {
        return currentHealth;
    }

    public bool IsAlive() 
    {
        return currentHealth > 0;
    }
}
