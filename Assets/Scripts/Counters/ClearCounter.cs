using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
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

        if (player.HasKitchenObject() && HasKitchenObject()) {
            KitchenObject kitchenObject = GetKitchenObject();
            if (kitchenObject is PlateKitchenObject && !(player.GetKitchenObject() is PlateKitchenObject)) {
                PlateKitchenObject plate = kitchenObject as PlateKitchenObject;
                if (plate.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())) {
                    Destroy(player.GetKitchenObject().gameObject);
                    player.ClearKitchenObject();
                }
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
    }
}
