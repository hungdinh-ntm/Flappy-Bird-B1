using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AbilityFly : BirdAbstract
{
    [Header("Ability Fly")]
    public float flyForce = 5f;
    public float rotateSpeed = 5f;
    public float maxUpAngle = 30f;
    public float maxDownAngle = -90f;

    protected virtual void Update()
    {
        this.RotateBird();
    }

    public virtual void Fly()
    {
        if (GameManager.Instance.IsGameOver) return;
        this.birdCtrl.Rigid2D.velocity = Vector2.up * this.flyForce;
    }

    protected virtual void RotateBird()
    {
        if (GameManager.Instance.IsGameOver) return;

        float velocityY = this.birdCtrl.Rigid2D.velocity.y;

        float targetAngle = velocityY * rotateSpeed;
        targetAngle = Mathf.Clamp(targetAngle, maxDownAngle, maxUpAngle);

        float currentAngle = transform.rotation.eulerAngles.z;

        float smoothAngle = Mathf.LerpAngle(currentAngle, targetAngle, Time.deltaTime * 10f);

        transform.parent.rotation = Quaternion.Euler(0, 0, smoothAngle);
    }

    //public virtual void StopBird()
    //{
    //    this.birdCtrl.Rigid2D.velocity = Vector2.zero;
    //}
}

