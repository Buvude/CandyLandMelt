using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenBehaviour : MonoBehaviour
{
    [SerializeField] private float minTemperature;
    [SerializeField] private float temperatureDecrease = 5;
    [SerializeField] private float currentTemperature;
    [SerializeField] private float maxTemprature;
    [SerializeField] private HealthBar heatBar;
    
    private void BeginBehaviour() 
    {
        currentTemperature = minTemperature;
        heatBar.SetMaxTemperature(maxTemprature);
    }

    private void Start()
    {
        BeginBehaviour();
    }

    public void SetTemperature(float temperature) 
    {
        currentTemperature = temperature;
        UpdateHeatBar();
        if (currentTemperature < minTemperature)
            FullCooldown();
    }

    public void TakeDamage(float damage) 
    {
        currentTemperature += damage;
        UpdateHeatBar();
        Death();
    }

    public void RecoverHealth() 
    {
        currentTemperature -= temperatureDecrease;
        UpdateHeatBar();
        if (currentTemperature < minTemperature)
            FullCooldown();
    }

    public void FullCooldown() 
    {
        currentTemperature = minTemperature;
        UpdateHeatBar();
    }

    private void Death() 
    {
        if (currentTemperature >= maxTemprature)
            this.gameObject.SetActive(false);
    }

    public float GetMaxTemperature() 
    {
        return maxTemprature;
    }

    public float GetHeat() 
    {
        return currentTemperature;
    }

    public bool IsAlive() 
    {
        return currentTemperature < maxTemprature;
    }

    private void UpdateHeatBar()
    {
        heatBar.SetTemperature(currentTemperature);
    }
}
