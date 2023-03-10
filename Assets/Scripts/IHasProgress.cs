using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasProgress
{
    public event Action<float, float> OnChangeProgressAction;
    public event Action OnCloseProgressAction;
}
