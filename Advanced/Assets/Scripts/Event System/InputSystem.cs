using UnityEngine;
using System;

public class InputSystem : MonoBehaviour
{
    #region Properties
    public event Action OnKeyDamage;
    public event Action OnKeyHeal;
    public event Action OnKeyPoints;

    #endregion

    #region Unity Callbacks
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
            OnKeyDamage?.Invoke();

        if (Input.GetKeyUp(KeyCode.E))
            OnKeyHeal?.Invoke();

        if (Input.GetKeyUp(KeyCode.Space))
            OnKeyPoints?.Invoke();
    }

    #endregion
}
