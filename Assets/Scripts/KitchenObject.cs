using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO = null;

    private ClearCounter clearCounter;

    public KitchenObjectSO GetKitchenObjectSO() {
        return kitchenObjectSO;
    }

    public void SetClearCounter(ClearCounter _clearCounter) {
        Debug.Log(_clearCounter.HasKitchenObject());

        if (this.clearCounter) {
            this.clearCounter.ClearKitchenObject();
        }

        this.clearCounter = _clearCounter;
        this.clearCounter.SetKitchenObject(this);

        transform.parent = this.clearCounter.GetCounterTopPoint();
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetClearCounter() {
        return clearCounter;
    }
}
