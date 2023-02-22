using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO = null;

    private IKitchenObjectParent parent = null;

    public KitchenObjectSO GetKitchenObjectSO() {
        return kitchenObjectSO;
    }

    public void SetParent(IKitchenObjectParent parent) {

        if (this.parent != null) {
            this.parent.ClearKitchenObject();
        }

        this.parent = parent;
        this.parent.SetKitchenObject(this);

        transform.parent = this.parent.GetKitchenObjectPoint();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent GetParent() {
        return parent;
    }
}
