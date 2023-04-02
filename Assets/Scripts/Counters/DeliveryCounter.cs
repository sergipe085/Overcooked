using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{

    [SerializeField] private DeliveryManager deliveryManager = null;

    public override void Interact(Player player) {
        if (player.HasKitchenObject()) {
            if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
                deliveryManager.DeliveryRecipe(plateKitchenObject);
                plateKitchenObject.DestroySelf();
            }
        }
    }
}
