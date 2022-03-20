using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private float yMin;
    [SerializeField] private float yMax;
    [SerializeField] private float waitTime = 2.5f;
    private bool canSpawn;
    private bool specialEnemySpawned;
    
    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn && !specialEnemySpawned)
        {
            canSpawn = false;
            int index = Random.Range(0, enemies.Count);
            float yPos = Random.Range(yMin, yMax);
            Instantiate(enemies[index], new Vector3(transform.position.x, yPos, transform.position.z), transform.rotation);
            StartCoroutine(WaitAndEnable());
        }
    }

    private IEnumerator WaitAndEnable()
    {
        yield return new WaitForSeconds(waitTime);
        canSpawn = true;
    }

    public void SetSpecialEnemySpawned(bool spawn)
    {
        specialEnemySpawned = spawn;
    }
}
