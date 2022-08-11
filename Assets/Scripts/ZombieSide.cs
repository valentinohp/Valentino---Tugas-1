using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSide : Zombie
{
    [SerializeField] private float _sideMoveSpeed = 1f;

    protected override void Start()
    {
        base.Start();

        _sideMoveSpeed = Random.Range(_sideMoveSpeed, _sideMoveSpeed * 1.5f);

        float[] direction = new float[2];

        direction[0] = _sideMoveSpeed;
        direction[1] = -_sideMoveSpeed;

        _sideMoveSpeed = direction[Random.Range(0, direction.Length)];
    }

    protected override void Move()
    {
        transform.position -= new Vector3(_sideMoveSpeed * Time.deltaTime, _moveSpeed * Time.deltaTime, 0);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.gameObject.tag == "SideWall")
        {
            _sideMoveSpeed *= -1;
        }
    }
}