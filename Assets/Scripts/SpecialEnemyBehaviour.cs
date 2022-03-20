using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemyBehaviour : MonoBehaviour
{
    private EnemySpawner spawner;
    private GameObject player;
    [SerializeField] private float m_Speed = 10f;
    [SerializeField] private int health = 10;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("MainShip");
        spawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
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

        transform.LookAt(player.transform.position);

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, m_Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shoot")
        {
            health--;
        }

        if (collision.gameObject.tag == "Bomb")
        {
            health = 0;
        }
    }
}
