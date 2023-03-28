using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitchenObject = null;
    [SerializeField] private PlateIconTemplateUI plateIconTemplate = null;

    private void Start() {
        plateKitchenObject.OnAddIngredient += PlateKitchenObject_OnAddIngredient;
    }

    private void PlateKitchenObject_OnAddIngredient(KitchenObjectSO ingredient) {
        PlateIconTemplateUI iconInstance = Instantiate(plateIconTemplate, transform);
        iconInstance.gameObject.SetActive(true);
        iconInstance.UpdateImage(ingredient.sprite);
    }
}
