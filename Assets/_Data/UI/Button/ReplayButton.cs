using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayButton : BaseButton
{
    protected override void OnClick()
    {
        GameManager.Instance.Replay();
    }
}
