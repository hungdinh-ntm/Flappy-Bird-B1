using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseText : LoadMonoBehaviour
{
    [Header("Base Text")]
    [SerializeField] protected TextMeshProUGUI text;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadText();
    }

    protected virtual void LoadText()
    {
        if (this.text != null) return;
        this.text = GetComponent<TextMeshProUGUI>();
    }
}
