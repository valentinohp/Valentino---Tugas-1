using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : BaseCharacter
{
    public override void OnMouseDown()
    {
        GameManager.Instance.DecreaseLife();
        base.OnMouseDown();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DestroyEnemy")
        {
            GameManager.Instance.AddScore(_point);
            _spawner.clearedThisWave++;
            Destroy(gameObject);
        }
    }
}