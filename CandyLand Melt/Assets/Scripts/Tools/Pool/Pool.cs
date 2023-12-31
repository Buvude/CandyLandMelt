﻿using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject prefab;
    public int number; //The maximum number of times that the object will appear at the same time
    private List<PoolObject> poolList = new List<PoolObject>();
    int recycledObjectsNumber = 0;
    int activeObjects = 0;
    private List<PoolObject> Instcances;
    private void Awake()
    {
        Instcances = new List<PoolObject>();
        for (int i = 0; i < number; i++)
        {
            PoolObject po = CreateObject();
            poolList.Add(po);
        }
    }
    public PoolObject GetPooledObject()
    {
        if (poolList.Count > 0)
        {
            PoolObject po = poolList[0];
            po.gameObject.SetActive(true);
            poolList.RemoveAt(0);
            activeObjects++;
            return po;
        }
        else
        {
            return null;
            /*PoolObject po = CreateObject();
            po.gameObject.SetActive(true);
            Debug.LogWarning("Se creo un objeto en tiempo de ejecucion (pool)");
            return po;*/
        }
    }
    public void Recycle(PoolObject po)
    {
        poolList.Add(po);
        po.gameObject.SetActive(false);
        recycledObjectsNumber++;
        activeObjects--;
    }
    public int GetRecycledObjectsNumber()
    {
        return recycledObjectsNumber;
    }
    public void ResetRecycledObjectsNumber()
    {
        recycledObjectsNumber = 0;
    }
    public int GetObjectCount() // devuelve la cantidad de objetos activos
    {
        int activeInstances = 0;
        foreach(PoolObject current in Instcances)
        {
            if (current.isActiveAndEnabled)
                activeInstances++;
        }
        return activeInstances;
    }
    public int GetMaxNumber()
    {
        return number;
    }
    private PoolObject CreateObject()
    {
        GameObject go = Instantiate(prefab);
        PoolObject po = go.AddComponent<PoolObject>();
        po.SetPool(this);
        go.SetActive(false);
        Instcances.Add(po);
        return po;
    }
}