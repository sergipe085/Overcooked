using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField] private Transform recipesContainer = null;
    [SerializeField] private RecipeSingleUI recipeUIPrefab = null;

    private void Start() {
        DeliveryManager.Instance.OnChangeRecipesAction += DeliverManager_OnChangeRecipesAction;
    }

    private void DeliverManager_OnChangeRecipesAction(List<RecipeSO> recipeSOs) {
        ClearRecipes();

        foreach(RecipeSO recipeSO in recipeSOs) {
            AddRecipe(recipeSO);
        }
    }

    private void ClearRecipes() {
        foreach(Transform c in recipesContainer) {
            Destroy(c.gameObject);
        }
    }

    private void AddRecipe(RecipeSO recipeSO) {
        RecipeSingleUI recipeSingleUI = Instantiate(recipeUIPrefab, recipesContainer);
        recipeSingleUI.gameObject.SetActive(true);
        recipeSingleUI.Initialize(recipeSO);
    }
}
