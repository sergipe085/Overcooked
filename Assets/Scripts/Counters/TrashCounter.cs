using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public override void Interact(Player player) {
        KitchenObject kitchenObject = player.GetKitchenObject();
        if (kitchenObject) {
            player.ClearKitchenObject();
            kitchenObject.DestroySelf();
        }
    }
}
