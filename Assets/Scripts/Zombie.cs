using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Spawner spawner;
    public float moveSpeed = 1f;
    public int point = 1;
    public RuntimeAnimatorController[] animators;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().runtimeAnimatorController = animators[Random.Range(0, animators.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
    }

    private void OnMouseDown() {
        GameManager.Instance.AddScore(point);
        spawner.clearedThisWave++;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "DestroyEnemy")
        {
            GameManager.Instance.DecreaseLife();
            spawner.clearedThisWave++;
            Destroy(gameObject);
        }
    }
}
