using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event Action OnPlayerGrabbedObject = null;

    [SerializeField] KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player) {
        if (player.HasKitchenObject()) return;

        KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);

        OnPlayerGrabbedObject?.Invoke();
    }
}
