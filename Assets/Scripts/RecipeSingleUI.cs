using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeSingleUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI recipeName = null;
    [SerializeField] private IngredientSingleUI ingredientPrefab = null;
    [SerializeField] private Transform ingredientsContainer = null;

    public void Initialize(RecipeSO recipeSO) {
        recipeName.text = recipeSO.recipeName;

        foreach(KitchenObjectSO kitchenObjectSO in recipeSO.kitchenObjectSOs) {
            IngredientSingleUI ingredientSingleUI = Instantiate(ingredientPrefab, ingredientsContainer);
            ingredientSingleUI.gameObject.SetActive(true);
            ingredientSingleUI.Initialize(kitchenObjectSO);
        }
    }
}
