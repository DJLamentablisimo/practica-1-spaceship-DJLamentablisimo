using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bomb;
    [SerializeField] private MainShipHealth health;
    [SerializeField] private int bombNumber = 5;
    // Start is called before the first frame update
    void Start()
    {
        if (health == null)
        {
            health = GetComponent<MainShipHealth>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !health.IsDead())
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && !health.IsDead() && (bombNumber > 0))
        {
            Instantiate(bomb, transform.position, transform.rotation);
            bombNumber--;
        }
    }
}
