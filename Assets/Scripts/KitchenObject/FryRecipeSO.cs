using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FryRecipeSO : ScriptableObject
{
    public KitchenObjectSO input = null;
    public KitchenObjectSO output = null;
    public float fryTimerMax = 3;
}
