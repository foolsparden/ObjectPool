using UnityEngine.Pool;
using System;
using UnityEngine;

class BasePool<T>:MonoBehaviour where T:Component
{
    ObjectPool<T> goPool;
    T prefab;
    int defaultSize = 100;
    int maxSize = 500;
    protected Transform transform;
    protected virtual void Init()
    {
        goPool = new ObjectPool<T>(OnCreate, OnGet, OnReleasePool, OnDestroy,true, defaultSize, maxSize
            );
    }
    protected virtual T OnCreate()=> GameObject.Instantiate(prefab, transform);
    protected virtual void OnGet(T obj) => obj.gameObject.SetActive(true);
    protected virtual void OnReleasePool(T obj) => obj.gameObject.SetActive(false);
    protected virtual void OnDestroy(T obj) => GameObject.Destroy(obj.gameObject);
  
}

