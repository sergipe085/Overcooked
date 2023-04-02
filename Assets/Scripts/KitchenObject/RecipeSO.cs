using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RecipeSO : ScriptableObject
{
    public List<KitchenObjectSO> kitchenObjectSOs = new List<KitchenObjectSO>();
    public string recipeName = "";
}
