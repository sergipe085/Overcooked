using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    private List<KitchenObjectSO> kitchenObjects = new List<KitchenObjectSO>();
    public List<KitchenObjectSO> validkitchenObjects = new List<KitchenObjectSO>();
    public event Action<KitchenObjectSO> OnAddIngredient;

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO) {
        if (!validkitchenObjects.Contains(kitchenObjectSO)) {
            return false;
        }

        if (kitchenObjects.Contains(kitchenObjectSO)) {
            return false;
        }

        kitchenObjects.Add(kitchenObjectSO);
        OnAddIngredient?.Invoke(kitchenObjectSO);
        return true;
    }   
}
