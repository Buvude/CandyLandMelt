using UnityEngine;

public class CitizenBehaviour : MonoBehaviour
{
    [SerializeField] private float minTemperature;
    [SerializeField] private float temperatureDecrease = 5;
    [SerializeField] private float currentTemperature;
    [SerializeField] private float maxTemprature;
    [SerializeField] private float heatWaveTimeAdded;
    [SerializeField] private float heatWaveDamageAdded;
    [SerializeField] private Collider2D triggerCollider;
    [SerializeField] private HealthBar heatBar;
    [SerializeField] private float[] animationTemperatureValues;
    [SerializeField] private Animator anim;
    private bool alive = true;
    private bool isRemoved;
    
    private void BeginBehaviour() 
    {
        currentTemperature = minTemperature;
        heatBar.SetMaxTemperature(maxTemprature);
        isRemoved = false;
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
        if(alive)
        {
            currentTemperature += damage;
            UpdateHeatBar();
            UpdateAnimationStatus();
            Death();
        }
    }

    public void RecoverHealth() 
    {
        if(alive)
        {
            currentTemperature -= temperatureDecrease;
            UpdateHeatBar();
            UpdateAnimationStatus();
            if (currentTemperature < minTemperature)
                FullCooldown();
        }
    }

    public void FullCooldown() 
    {
        currentTemperature = minTemperature;
        UpdateHeatBar();
    }

    private void Death() 
    {
        if (currentTemperature >= maxTemprature && this.gameObject.activeInHierarchy)
        {
            LosingConditionManager.CitizenDied();
            alive = false;
            triggerCollider.enabled = false;
            anim.SetBool("Dead", true);
            //this.gameObject.SetActive(false);
        }
    }

    public void SetIsRemoved(bool _isRemoved) 
    {
        isRemoved = _isRemoved;
    }

    public float GetMaxTemperature() 
    {
        return maxTemprature;
    }

    public float GetHeat() 
    {
        return currentTemperature;
    }

    public float GetHeatWaveTimeAdded() 
    {
        return heatWaveTimeAdded;
    }

    public float GetHeatWaveDamageAdded() 
    {
        return heatWaveDamageAdded;
    }

    public bool IsAlive() 
    {
        return alive;
    }

    public bool IsRemoved() 
    {
        return isRemoved;
    }

    private void UpdateHeatBar()
    {
        heatBar.SetTemperature(currentTemperature);
    }
    private void UpdateAnimationStatus()
    {
        for(int i = 0; i < animationTemperatureValues.Length; i++)
        {
            if (currentTemperature >= animationTemperatureValues[i])
                anim.SetBool("HeatLevel" + (i + 1), true);
            else
                anim.SetBool("HeatLevel" + (i + 1), false);
        }
    }
}
