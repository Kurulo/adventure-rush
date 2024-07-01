using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerationObjects : MonoBehaviour {
    public Location[] locations;

    private int _currentLocation;
    private int _currentFloor;

    private void Start() {
        _currentLocation = 0;
        _currentFloor = 0;
    }
    
    public GameObject GenerateRandomObject() {
        Location location = locations[_currentLocation];
        if (_currentFloor == 0) {
            GameObject[] floorObjects = location.underFloor;
            return floorObjects[Random.Range(0, floorObjects.Length)];
        } else if (_currentFloor == 1) {
            GameObject[] floorObjects = location.mainFloor;
            return floorObjects[Random.Range(0, floorObjects.Length)];
        } else if (_currentFloor == 2) {
            GameObject[] floorObjects = location.topFloor;
            return floorObjects[Random.Range(0, floorObjects.Length)];
        } else {
            return null;
        }
    }
    
    public void SetCurrentFloor(int floor) {
        _currentFloor = floor;
    }
    
    public void SetCurrentLocation(int location) {
        _currentLocation = location;
    }
}

[System.Serializable]
public class Location {
    public GameObject[] mainFloor;
    public GameObject[] topFloor;
    public GameObject[] underFloor;
}