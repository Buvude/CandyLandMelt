using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class HeatEvent : UnityEvent<float>
{
}

public class HeatWave : MonoBehaviour
{
    [SerializeField] private List<CitizenBehaviour> citizens;
    [SerializeField] private float heatDamage;
    [SerializeField] private float damageTime;
    [SerializeField] private float heatDamageIncrease;
    [SerializeField] private float heatIncreaseTime;
    private float heatDamageTimer;
    private float heatIncreaseTimer;
    private HeatEvent heatWave;

    private void Awake()
    {
        heatDamageTimer = 0;
        heatIncreaseTimer = 0;
        heatWave = new HeatEvent();
    }

    private void AddCitizensListeners() 
    {
        for (int i = 0; i < citizens.Count; i++)
        {
            heatWave.AddListener(citizens[i].TakeDamage);
        }
    }

    private void Start()
    {
        AddCitizensListeners();
    }

    private void HeatIncreaseBehaviour() 
    {
        heatIncreaseTimer += Time.deltaTime;
        if (heatIncreaseTimer >= heatIncreaseTime) 
        {
            heatDamage += heatDamageIncrease;
            heatIncreaseTimer = 0;
        }
    }

    private void HeatDamageBehaviour() 
    {
        heatDamageTimer += Time.deltaTime;
        if (heatDamageTimer >= damageTime)
        {
            heatWave.Invoke(heatDamage);
            heatDamageTimer = 0;
        }
    }

    private void Update()
    {
        HeatDamageBehaviour();
        HeatIncreaseBehaviour();
    }
}
