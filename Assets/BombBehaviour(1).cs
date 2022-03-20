using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    [SerializeField] private float bombSpeed = 10f;
    [SerializeField] private float bombTime = 3f;
    private bool explosionEnabled;
    private SphereCollider col;
    [SerializeField] private ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<SphereCollider>();

        if (particles == null)
        {
            particles = GetComponent<ParticleSystem>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!explosionEnabled)
        {
            transform.Translate(Vector3.forward * bombSpeed * Time.deltaTime);
            StartCoroutine(WaitAndExplode());
        }
    }

    private IEnumerator WaitAndExplode()
    {
        yield return new WaitForSeconds(bombTime);
        explosionEnabled = true;
        particles.Play();
        col.enabled = true;
        while (col.radius < 50f)
        {
            col.radius += 0.1f;
            yield return new WaitForSeconds(0.06f);
        }
        Destroy(this.gameObject);
    }
}
