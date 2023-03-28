using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlateKitchenObjectVisual : MonoBehaviour
{
    [System.Serializable]
    public struct KitchenObjectSO_GameObject {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    } 

    [SerializeField] private PlateKitchenObject plateKitchenObject = null;
    [SerializeField] private List<KitchenObjectSO_GameObject> kitchenObjectSO_GameObjects = new();

    private void Start() {
        plateKitchenObject.OnAddIngredient += PlateKitchenObject_OnAddIngredient;
    }

    private void PlateKitchenObject_OnAddIngredient(KitchenObjectSO _kitchenObjectSO) {
        foreach(KitchenObjectSO_GameObject kg in kitchenObjectSO_GameObjects) {
            if (kg.kitchenObjectSO == _kitchenObjectSO) {
                kg.gameObject.SetActive(true);
                transform.DORewind();
                transform.DOPunchScale(new Vector3(-0.2f, 0.4f, -0.2f), 0.2f);
                CameraEffects.Instance.DOMiniShake();
                break;
            }
        }
    }
}
