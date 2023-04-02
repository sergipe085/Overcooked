using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter, IHasProgress
{
    [SerializeField] private KitchenObjectSO tomatoSlices = null;
    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOs;

    public event Action<int, int> OnStartCutAction = null;

    public event Action<float, float> OnChangeProgressAction;
    public event Action OnCloseProgressAction;

    private int cuttingProgess = 0;

    public override void Interact(Player player) {
        OnCloseProgressAction?.Invoke();

        if (HasKitchenObject() && !player.HasKitchenObject()) {
            kitchenObject.SetParent(player);
            return;
        }

        if (player.HasKitchenObject() && !HasKitchenObject()) {
            KitchenObject playerKitchenObject = player.GetKitchenObject();
            player.ClearKitchenObject();
            playerKitchenObject.SetParent(this);
            cuttingProgess = 0;
            return;
        }

        if (player.GetKitchenObject() is PlateKitchenObject && !(kitchenObject is PlateKitchenObject)) {
            PlateKitchenObject plate = player.GetKitchenObject() as PlateKitchenObject;
            if (plate.TryAddIngredient(kitchenObject.GetKitchenObjectSO())) {
                Destroy(kitchenObject.gameObject);
                ClearKitchenObject();
            }
        }
    }

    public override void InteractAlternate(Player player) {
        KitchenObject kitchenObject = GetKitchenObject();

        if (kitchenObject) {
            KitchenObjectSO kitchenObjectSO = kitchenObject.GetKitchenObjectSO();

            CuttingRecipeSO cuttingRecipeSO = GetRecipeSOForInput(kitchenObjectSO);

            if (!cuttingRecipeSO) {
                return;
            }

            KitchenObjectSO cuttingOutput = cuttingRecipeSO.output;

            if (cuttingOutput) {
                cuttingProgess++;
                OnChangeProgressAction?.Invoke(cuttingProgess, cuttingRecipeSO.cuttingProgressMax);

                if (cuttingProgess >= cuttingRecipeSO.cuttingProgressMax) {
                    Debug.Log($"CuttinCounter.Cut({ GetKitchenObject() })");

                    kitchenObject.DestroySelf();

                    KitchenObject.SpawnKitchenObject(cuttingOutput, this);
                    cuttingProgess = 0;
                }

            }
        }
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO input) {
        CuttingRecipeSO recipeSO = GetRecipeSOForInput(input);

        if (!recipeSO) {
            return null;
        }

        return recipeSO.output;
    }

    private CuttingRecipeSO GetRecipeSOForInput(KitchenObjectSO input) {
        foreach(CuttingRecipeSO recipeSO in  cuttingRecipeSOs) {
            if (input == recipeSO.input) {
                return recipeSO;
            }
        }

        return null;
    }
}
