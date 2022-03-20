using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterSpawn: MonoBehaviour
{
    [SerializeField] private List<int> positions = new List<int>(new int[] { -12, -10, -8, -6, -4, -2, 0, 2, 4, 6, 8, 10, 12 });
    [SerializeField] private float tiempoespera = 1.5f;
    [SerializeField] private Rigidbody rb;
    private bool canSpawn;
    private GameObject blaster;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            canSpawn = false;
            int index = Random.Range(0, positions.Count);
            Instantiate(blaster, new Vector3(transform.position.x, positions[index], transform.position.z), transform.rotation);
            StartCoroutine(WaitAndEnable());
        }
    }
    private IEnumerator WaitAndEnable()
    {
        yield return new WaitForSeconds(tiempoespera);
        canSpawn = true;
    }
}
