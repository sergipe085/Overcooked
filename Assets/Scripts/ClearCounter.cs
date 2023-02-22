using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO = null;
    [SerializeField] private Transform counterTopPoint = null;
    [SerializeField] private ClearCounter secondCounter = null;
    public bool testing = false;

    private KitchenObject kitchenObject = null;

    private void Update() {
        if (testing && Input.GetKeyDown(KeyCode.T)) {
            if (secondCounter.HasKitchenObject()) return;
            kitchenObject?.SetParent(secondCounter);
        }
    }

    public void Interact(Player player) {
        if (kitchenObject != null) {
            Debug.Log(kitchenObject.GetParent());
            kitchenObject.SetParent(player);
            return;
        }

        Debug.Log("Interact with " + transform.name);
        kitchenObject = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
        kitchenObject.SetParent(this);
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
