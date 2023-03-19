using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public List<KitchenObject> kitchenObjects = new List<KitchenObject>();

    public override void InteractWithKitchenObject(KitchenObject kitchenObject, Player player) {
        if (kitchenObject.GetType() == typeof(PlateKitchenObject)) {
            return;
        }

        kitchenObjects.Add(kitchenObject);
        kitchenObject.transform.SetParent(transform);
        kitchenObject.transform.localPosition = Vector3.up * 0.1f * (kitchenObjects.Count-1);
        player.ClearKitchenObject();
    }
}
