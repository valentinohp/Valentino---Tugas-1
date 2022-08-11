using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour, IClickable
{
    public RuntimeAnimatorController[] animators;

    [SerializeField] protected Spawner _spawner;
    [SerializeField] protected float _moveSpeed = 1f;
    [SerializeField] protected int _point = 1;

    protected virtual void Start()
    {
        GetComponent<Animator>().runtimeAnimatorController = animators[Random.Range(0, animators.Length)];
    }

    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        transform.position -= new Vector3(0, _moveSpeed * Time.deltaTime, 0);
    }

    public virtual void OnMouseDown()
    {
        _spawner.clearedThisWave++;
        Destroy(gameObject);
    }

    protected abstract void OnTriggerEnter2D(Collider2D other);
}