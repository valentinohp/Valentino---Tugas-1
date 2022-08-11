using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : BaseCharacter
{
    public override void OnMouseDown()
    {
        GameManager.Instance.AddScore(_point);
        base.OnMouseDown();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DestroyEnemy")
        {
            GameManager.Instance.DecreaseLife();
            _spawner.clearedThisWave++;
            Destroy(gameObject);
        }
    }
}