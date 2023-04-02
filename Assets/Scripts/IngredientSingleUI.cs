using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientSingleUI : MonoBehaviour
{
    [SerializeField] private Image ingredientIcon = null;

    public void Initialize(KitchenObjectSO kitchenObjectSO) {
        ingredientIcon.sprite = kitchenObjectSO.sprite;
    }
}
