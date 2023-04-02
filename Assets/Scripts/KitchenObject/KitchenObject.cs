using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

        transform.DORewind();
        transform.DOPunchScale(new Vector3(0.2f, -0.4f, 0.2f), 0.2f);
    }

    public IKitchenObjectParent GetParent() {
        return parent;
    }

    public void DestroySelf() {
        parent.ClearKitchenObject();
        Destroy(gameObject);
    }

    public static KitchenObject SpawnKitchenObject(KitchenObjectSO kitchenObjectSO, IKitchenObjectParent parent) {
        KitchenObject kitchenObject = Instantiate(kitchenObjectSO.prefab);
        kitchenObject.SetParent(parent);
        return kitchenObject;
    } 

    public bool TryGetPlate(out PlateKitchenObject plateKitchenObject) {
        if (this is PlateKitchenObject) {
            plateKitchenObject = this as PlateKitchenObject;
            return true;
        }
        
        plateKitchenObject = null;
        return false;
    }
}
