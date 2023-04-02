using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    [SerializeField] private RecipeListSO recipeListSO = null;
    private List<RecipeSO> waitingRecipeSOList = new List<RecipeSO>();

    private float spawnReciperTimer = 0.0f;
    private float spawnReciperTimerMax = 4.0f;
    private int waitingRecipesMax = 4;

    private void Update() {
        spawnReciperTimer += Time.deltaTime;
        if (spawnReciperTimer >= spawnReciperTimerMax) {
            spawnReciperTimer = 0.0f;

            if (waitingRecipeSOList.Count >= waitingRecipesMax) {
                return;
            }

            SpawnRecipe();
        }
    }

    private void SpawnRecipe() {
        RecipeSO[] recipeSOs = recipeListSO.recipeSOList.ToArray();
        waitingRecipeSOList.Add(recipeSOs[Random.Range(0, recipeSOs.Length)]);
    }

    public void DeliveryRecipe(PlateKitchenObject plateKitchenObject) {
        KitchenObjectSO[] plateIngredients = plateKitchenObject.GetKitchenObjectSOs();

        for (int i = 0; i < waitingRecipeSOList.Count; i++) {
            RecipeSO recipeSO = waitingRecipeSOList[i];
            
            if (recipeSO.kitchenObjectSOs.Count != plateIngredients.Length) {
                continue;
            }

            bool plateContentMatches = true;

            foreach(KitchenObjectSO kitchenObjectRecipe in recipeSO.kitchenObjectSOs) {
                bool ingredientFound = false;
                foreach(KitchenObjectSO KitchenObjectPlate in plateIngredients) {
                    if (kitchenObjectRecipe == KitchenObjectPlate) {
                        ingredientFound = true;
                        break;
                    }
                }
                if (!ingredientFound) {
                    plateContentMatches = false;
                }
            }

            if (plateContentMatches) {
                Debug.Log("Player delivery correct!");
                waitingRecipeSOList.RemoveAt(i);
                return;
            }
        }

        Debug.Log("Player did not delivery correct!");
    }
}
