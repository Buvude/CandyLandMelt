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
    private float timer;
    private HeatEvent heatWave;

    private void Awake()
    {
        timer = 0;
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

    private void HeatBehaviour() 
    {
        timer += Time.deltaTime;
        if (timer >= damageTime)
        {
            heatWave.Invoke(heatDamage);
            timer = 0;
        }
    }

    private void Update()
    {
        HeatBehaviour();
    }
}
