using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO = null;
    [SerializeField] private Transform counterTopPoint = null;

    private KitchenObject kitchenObject = null;

    public void Interact() {
        Debug.Log("Interact with " + transform.name);
        KitchenObject kitchenObjectInstance = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
        Debug.Log(kitchenObjectInstance.GetKitchenObjectSO().objectName);
    }
}
