using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float destroyTime = 0.5f;
    [SerializeField] private GameObject bulletHitPrefab;
    [SerializeField] private float bulletSpeed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject bulletHit = Instantiate(bulletHitPrefab, transform.position, transform.rotation);
        Destroy(bulletHit, destroyTime);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BulletWall")
        {
            Destroy(this.gameObject);
        }
    }
}
