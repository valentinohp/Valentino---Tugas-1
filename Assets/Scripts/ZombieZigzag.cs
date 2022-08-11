using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieZigzag : Zombie
{
    [SerializeField] private float _sideMoveSpeed = 1f;
    private float _zigzagDuration = 2f;
    private float _zigzagTimer;
    private float[] direction = new float[3];

    protected override void Start()
    {
        base.Start();

        _sideMoveSpeed = Random.Range(_sideMoveSpeed, _sideMoveSpeed * 1.5f);

        direction[0] = _sideMoveSpeed;
        direction[1] = 0;
        direction[2] = -_sideMoveSpeed;

        _sideMoveSpeed = direction[Random.Range(0, direction.Length)];
    }

    protected override void Update()
    {
        base.Update();

        _zigzagTimer += Time.deltaTime;

        if (_zigzagTimer >= _zigzagDuration)
        {
            _zigzagDuration = Random.Range(0f, 2f);
            _zigzagTimer = 0;
            _sideMoveSpeed = direction[Random.Range(0, direction.Length)];
        }
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