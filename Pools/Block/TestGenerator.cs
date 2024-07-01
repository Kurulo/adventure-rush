using System;
using System.Collections.Generic;
using UnityEngine;

public class TestGenerator : MonoBehaviour {
    public GameObject poolBlocksContainer;
    public GameObject containerSpawn;
    
    private PoolBlocks _poolBlocks;

    private List<GameObject> _activeBlocks = new List<GameObject>();
    
    private void Start() {
        if (poolBlocksContainer.GetComponent<PoolBlocks>()) {
            _poolBlocks = poolBlocksContainer.GetComponent<PoolBlocks>();
            SpawnAll();
        }
    }

    private void Update() {
        if (_activeBlocks.Count != 0) {
            if (TransformFirst().position.z < -TransformFirst().GetChild(0).localScale.z * 10) {
                _poolBlocks.AddToPool(_activeBlocks[0]);
                _activeBlocks[0].SetActive(false);
                _activeBlocks.RemoveAt(0);
            }
        }
        
        if (_poolBlocks.GetCountPool() == 3) {
            CreateObjects(3);
        }
    }

    private void CreateObjects(int count) {
        for (int i = 0; i < count; i++) {
            GameObject createBlock = _poolBlocks.RandomObject();    
            Transform createTransform = createBlock.GetComponent<Transform>();

            if (_activeBlocks.Count == 0) {
                createTransform.position =  Vector3.zero;
            } else {
                float scaleDifference = ((createTransform.localScale.z - TransformLast().GetChild(0).localScale.z) * 10);
                float distanceSpawn = TransformLast().position.z + (createTransform.localScale.z * 10) - scaleDifference; 
                
                createTransform.position =  new Vector3(createTransform.position.x, 
                    createTransform.position.y, distanceSpawn);
            }
            
            createBlock.SetActive(true);
            _activeBlocks.Add(createBlock);
        }   
    }
    
    private void SpawnAll() {
        int count = _poolBlocks.GetCountPool();
        
        for (int i = 0; i < count; i++) {
            GameObject createBlock = _poolBlocks.RandomObject();
            Transform createTransform = createBlock.GetComponent<Transform>();

            GameObject create;

            if (_activeBlocks.Count == 0) {
                create = Instantiate(createBlock, createTransform.position, createTransform.rotation);
            } else {
                float scaleDifference = ((createTransform.localScale.z - TransformLast().GetChild(0).localScale.z) * 10);
                float distanceSpawn = (TransformLast().position.z + (createTransform.localScale.z * 10)) - scaleDifference;

                Vector3 pos = new Vector3(createTransform.position.x, createTransform.position.y, distanceSpawn);
                create = Instantiate(createBlock, pos, createTransform.rotation);
            }
            
            _activeBlocks.Add(create);
            create.SetActive(true);
            
            // createTransform.position = new Vector3(createTransform.position.x,
            //     createTransform.position.y, createTransform.position.z - 30f);
        }
    }
    
    private Transform TransformLast() {
        return _activeBlocks[_activeBlocks.Count - 1].transform;
    }
    
    private Transform TransformFirst() {
        return _activeBlocks[0].transform;
    }
}
