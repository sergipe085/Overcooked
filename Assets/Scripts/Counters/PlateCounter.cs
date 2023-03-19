using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO plateSO = null;
    
    [Header("CONFIG")]
    [SerializeField] private float timeToSpawn = 5.0f;
    private float timer = 0.0f;
    
    private int plateCounter = 0;
    private int maxPlateCounter = 4;

    public event Action<int> OnPlateSpawned = null;
    public event Action OnPlatePicked = null;

    private void Update() {
        timer += Time.deltaTime;

        if (plateCounter >= maxPlateCounter) {
            return;
        }

        if (timer >= timeToSpawn) {
            SpawnPlate();
            timer = 0.0f;
        }
    }

    private void SpawnPlate() {
        OnPlateSpawned?.Invoke(plateCounter);
        plateCounter += 1;
    }

    public override void Interact(Player player) {
        if (plateCounter <= 0) {
            return;
        }

        if (player.HasKitchenObject()) {
            return;
        }

        KitchenObject.SpawnKitchenObject(plateSO, player);
        OnPlatePicked?.Invoke();
        plateCounter--;
    }
}
