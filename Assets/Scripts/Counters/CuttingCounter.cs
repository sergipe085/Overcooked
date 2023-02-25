using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO tomatoSlices = null;
    public event Action OnCutAction = null;

    public override void Interact(Player player) {
        if (HasKitchenObject() && !player.HasKitchenObject()) {
            kitchenObject.SetParent(player);
            return;
        }

        if (player.HasKitchenObject() && !HasKitchenObject()) {
            KitchenObject playerKitchenObject = player.GetKitchenObject();
            player.ClearKitchenObject();
            playerKitchenObject.SetParent(this);
            return;
        }
    }

    public override void InteractAlternate(Player player) {
        KitchenObject kitchenObject = GetKitchenObject();

        if (kitchenObject) {
            KitchenObjectSO kitchenObjectSO = kitchenObject.GetKitchenObjectSO();

            KitchenObjectSO cuttingOutput = kitchenObjectSO.cuttingOutput;

            if (cuttingOutput) {
                Debug.Log($"CuttinCounter.Cut({ GetKitchenObject() })");
                OnCutAction?.Invoke();

                kitchenObject.DestroySelf();

                KitchenObject.SpawnKitchenObject(cuttingOutput, this);
            }
        }
    }
}
