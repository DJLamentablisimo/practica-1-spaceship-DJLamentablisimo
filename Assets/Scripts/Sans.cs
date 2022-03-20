using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sans : MonoBehaviour
{
    
    private EnemySpawner spawner;
    [SerializeField] private int health = 20;
    // Start is called before the first frame update
    void Start()
    {    
            spawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
             StartCoroutine(waiter());

    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(15);
        spawner.SetSpecialEnemySpawned(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            spawner.SetSpecialEnemySpawned(false);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shoot")
        {
            health--;
        }

        if (collision.gameObject.tag == "Bomb")
        {
            health = health-5;
        }
    }
}
