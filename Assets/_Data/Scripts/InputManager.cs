using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : LoadMonoBehaviour
{
    [Header("Input Manager")]
    private static InputManager instance;
    public static InputManager Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.instance = this;
    }

    protected virtual void Update()
    {
        this.GetKeyDown();
    }

    protected virtual void GetKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Space)) GameManager.Instance.OnSpacePressed();
    }
}
