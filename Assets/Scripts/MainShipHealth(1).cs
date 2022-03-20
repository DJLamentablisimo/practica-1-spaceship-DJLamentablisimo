using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainShipHealth : MonoBehaviour
{
    [SerializeField] private int health = 1;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            isDead = true;
        }
    }

    public bool IsDead()
    {
        return isDead;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
        }
    }
}
