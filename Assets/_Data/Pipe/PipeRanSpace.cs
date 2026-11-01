using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeRanSpace : LoadMonoBehaviour
{
    [SerializeField] protected Transform topPipe;
    [SerializeField] protected Transform downPipe;
    [SerializeField] protected PipeTrigger pipeTrigger;

    [SerializeField] protected float minSpace = 2f;
    [SerializeField] protected float maxSpace = 3.6f;
    [SerializeField] protected float pipeHalfHeight = 3.2f;
    [SerializeField] protected float space;

    private void OnEnable()
    {
        this.RandomSpace();
    }

    public virtual void RandomSpace()
    {
        this.space = Random.Range(this.minSpace, this.maxSpace);
        this.pipeTrigger.BoxCollider2D.size = new Vector2(0.5f, this.space);
    }

    public virtual void SetSpace()
    {
        float halfSpace = this.space / 2f;

        this.topPipe.localPosition = new Vector3(0, halfSpace + this.pipeHalfHeight, 0);
        this.downPipe.localPosition = new Vector3(0, -halfSpace - this.pipeHalfHeight, 0);
    }
}
