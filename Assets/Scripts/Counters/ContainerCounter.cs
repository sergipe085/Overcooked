using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Animator animator = null;

    public override void Interact(Player player) {
        if (player.HasKitchenObject()) return;

        KitchenObject kitchenObject = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
        kitchenObject.SetParent(player);

        animator.SetTrigger("OpenClose");
    }
}
