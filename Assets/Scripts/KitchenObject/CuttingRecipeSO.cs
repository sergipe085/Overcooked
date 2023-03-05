using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CuttingRecipeSO : ScriptableObject
{
    public KitchenObjectSO input = null;
    public KitchenObjectSO output = null;
    public int cuttingProgressMax = 3;
}
