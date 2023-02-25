using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private Transform counterTopPoint = null;
    protected KitchenObject kitchenObject = null;

    public virtual void Interact(Player player) {
        
    }

    public virtual void InteractAlternate(Player player) {
        
    }

    public void SetKitchenObject(KitchenObject kitchenObject) {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject() {
        return kitchenObject;
    }

    public void ClearKitchenObject() {
        kitchenObject = null;
    }

    public bool HasKitchenObject() {
        return kitchenObject != null;
    }

    public Transform GetKitchenObjectPoint() {
        return counterTopPoint;
    }
}
