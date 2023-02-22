using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    public override void Interact(Player player) {
        if (kitchenObject != null && !player.HasKitchenObject()) {
            Debug.Log(kitchenObject.GetParent());
            kitchenObject.SetParent(player);
            return;
        }

        if (player.HasKitchenObject() && kitchenObject == null) {
            KitchenObject playerKitchenObject = player.GetKitchenObject();
            player.ClearKitchenObject();
            playerKitchenObject.SetParent(this);
            return;
        }
    }
}
