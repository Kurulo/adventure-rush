using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PoolBlocks : MonoBehaviour {
    [FormerlySerializedAs("_gameObjects")]
    [SerializeField] private List<GameObject> _pool;
    
    public GameObject RandomObject() {
        int random = Random.Range(0, _pool.Count);
        GameObject returningObj = _pool[random];
        _pool.RemoveAt(random);
        return returningObj;
    }   
    
    public int GetCountPool() {
        return _pool.Count;
    }
    
    public void AddToPool(GameObject added) {
        _pool.Add(added);
    }
}
