using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPool<T> where T : MonoBehaviour
{
    private T Prefab { get; }
    public bool AutoExpand { get; set; }
    public bool ReplaceOld { get; set; }
    private Transform Container { get; }

    private List<T> pool;

    public BombPool(T prefab, int count, Transform container)
    {
        this.Prefab = prefab;
        this.Container = container;

        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        pool = new List<T>();
        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        T createdObject = UnityEngine.Object.Instantiate(Prefab, Container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        pool.Add(createdObject);
        return createdObject;
    }

    private bool HasFreeElement(out T element)
    {
        if (pool != null)
            foreach (T mono in pool)
            {
                if (!mono.gameObject.activeInHierarchy)
                {
                    element = mono;
                    mono.gameObject.SetActive(true);
                    return true;
                }
            }
        element = null;
        return false;
    }
    private T GetFirstElementAsLast()
    {
        T tempMono = pool[0];
        pool.RemoveAt(0);
        pool.Add(tempMono);
        tempMono.gameObject.SetActive(false);
        tempMono.gameObject.SetActive(true);
        return tempMono;
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out T element))
            return element;
        if (AutoExpand)
            return CreateObject(true);
        if (ReplaceOld)
            return GetFirstElementAsLast();
        return null;
    }
}