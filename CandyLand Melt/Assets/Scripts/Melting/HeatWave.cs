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
    [SerializeField] private float heatIncreaser;
    [SerializeField] private float damageTime;
    [SerializeField] private float heatIncreaseTime;
    [SerializeField] private SpeedUpText speedUpText;
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

    private void AddCitizensHeatSlow() 
    {
        for (int i = 0; i < citizens.Count; i++)
        {
            heatIncreaseTime += citizens[i].GetHeatWaveSlow();
        }
    }

    private void Start()
    {
        AddCitizensListeners();
        AddCitizensHeatSlow();
    }

    private void HeatDamageTimerTick() 
    {
        heatDamageTimer += Time.deltaTime;
    }

    private void HeatIncreaseTimerTick() 
    {
        heatIncreaseTimer += Time.deltaTime;
    }

    private void HeatIncreaseBehaviour() 
    {
        if (heatIncreaseTimer >= heatIncreaseTime) 
        {
            heatDamage += heatIncreaser;
            speedUpText.ShowChildren(true);
        }
    }

    private void HeatDamageBehaviour() 
    {
        if (heatDamageTimer >= damageTime)
        {
            heatWave.Invoke(heatDamage);
        }
    }

    private void RemoveDeadCitizenListener() 
    {
        if (heatDamageTimer >= damageTime) 
        {
            for (int i = 0; i < citizens.Count; i++) 
            {
                if (!citizens[i].IsAlive())
                {
                    heatWave.RemoveListener(citizens[i].TakeDamage);
                }
            }
        }
    }

    private void RemoveDeadCitizenHeatSlow() 
    {
        if (heatDamageTimer >= damageTime)
        {
            for (int i = 0; i < citizens.Count; i++)
            {
                if (!citizens[i].IsAlive() && !citizens[i].IsRemoved())
                {
                    heatIncreaseTime -= citizens[i].GetHeatWaveSlow();
                    citizens[i].SetIsRemoved(true);
                }
            }
        }
    }

    private void HeatDamageTimerRestart() 
    {
        if (heatDamageTimer >= damageTime) 
        {
            heatDamageTimer = 0;
        }
    }

    private void HeatIncreaseTimerRestart() 
    {
        if (heatIncreaseTimer >= heatIncreaseTime) 
        {
            heatIncreaseTimer = 0;
        }
    }

    private void HeatWaveBehave() 
    {
        HeatDamageTimerTick();
        HeatIncreaseTimerTick();
        HeatDamageBehaviour();
        RemoveDeadCitizenListener();
        RemoveDeadCitizenHeatSlow();
        HeatIncreaseBehaviour();
        HeatDamageTimerRestart();
        HeatIncreaseTimerRestart();
    }

    private void Update()
    {
        HeatWaveBehave();
    }
}
