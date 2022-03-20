using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float m_Speed = 25f;
    [SerializeField] private int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * m_Speed * Time.deltaTime);

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shoot")
        {
            health--;
        } else if (collision.gameObject.tag == "EnemyWall" || collision.gameObject.tag == "Bomb") {
            health = 0;
        }
    }
}
