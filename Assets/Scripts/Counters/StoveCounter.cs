using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter, IHasProgress
{
    [SerializeField] private FryRecipeSO[] fryRecipeSOs;
    private FryRecipeSO currentRecipe = null;
    private float fryTimer = 0.0f;

    public event Action OnStartStoveAction;
    public event Action OnEndStoveAction;
    public event Action<float, float> OnChangeProgressAction;
    public event Action OnCloseProgressAction;

    private void Update() {
        if (currentRecipe) {
            fryTimer += Time.deltaTime;
            OnChangeProgressAction?.Invoke(fryTimer, currentRecipe.fryTimerMax);

            if (fryTimer >= currentRecipe.fryTimerMax) {
                fryTimer = 0.0f;
                kitchenObject.DestroySelf();
                KitchenObject instance = KitchenObject.SpawnKitchenObject(currentRecipe.output, this);
                KitchenObjectSO kitchenObjectSO = instance.GetKitchenObjectSO();
                currentRecipe = GetFryRecipeSOForInput(kitchenObjectSO);

                if (!currentRecipe) {
                    OnCloseProgressAction?.Invoke();
                    OnEndStoveAction?.Invoke();
                }
            }
        }
    }

    public override void Interact(Player player) {
        fryTimer = 0.0f;
        OnCloseProgressAction?.Invoke();

        if (HasKitchenObject() && !player.HasKitchenObject()) {
            kitchenObject.SetParent(player);
            currentRecipe = null;
            OnEndStoveAction?.Invoke();
            return;
        }

        if (player.HasKitchenObject() && !HasKitchenObject()) {
            KitchenObject playerKitchenObject = player.GetKitchenObject();
            KitchenObjectSO playerKitchenObjectSO = playerKitchenObject.GetKitchenObjectSO();
            FryRecipeSO output = GetFryRecipeSOForInput(playerKitchenObjectSO);

            if (output) {
                currentRecipe = output;
                OnStartStoveAction?.Invoke();
            }
            
            player.ClearKitchenObject();
            playerKitchenObject.SetParent(this);


            return;
        }
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO input) {
        FryRecipeSO recipeSO = GetFryRecipeSOForInput(input);

        if (!recipeSO) {
            return null;
        }

        return recipeSO.output;
    }

    private FryRecipeSO GetFryRecipeSOForInput(KitchenObjectSO input) {
        foreach(FryRecipeSO fryRecipeSO in  fryRecipeSOs) {
            if (input == fryRecipeSO.input) {
                return fryRecipeSO;
            }
        }

        return null;
    }
}
