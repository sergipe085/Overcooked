using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounterVisual : MonoBehaviour
{
    [SerializeField] private Transform platePrefab = null;
    [SerializeField] private Transform counterTopPoint = null;
    [SerializeField] private PlateCounter plateCounter = null;
    private List<Transform> platesInstances = new List<Transform>();

    private void Start() {
        plateCounter.OnPlateSpawned += PlateCounter_OnPlateSpawned;
        plateCounter.OnPlatePicked += PlateCounter_OnPlatePicked;
    }

    private void PlateCounter_OnPlateSpawned(int count) {
        Transform plateInstance = Instantiate(platePrefab, transform);
        plateInstance.position = counterTopPoint.position + Vector3.up * 0.1f * count; 
        platesInstances.Add(plateInstance);
    }

    private void PlateCounter_OnPlatePicked() {
        int index = platesInstances.Count - 1;
        Destroy(platesInstances[index].gameObject);
        platesInstances.RemoveAt(index);
    }
}
