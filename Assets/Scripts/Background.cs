using UnityEngine;

namespace Spaceship
{

    public class Background : MonoBehaviour
    {

        [SerializeField]
        private float speed;

        private Renderer backgroundRenderer;

        private void Awake()
        {
            backgroundRenderer = GetComponent<Renderer>();
        }

        private void Update()
        {
            var offset = backgroundRenderer.material.mainTextureOffset;
            backgroundRenderer.material.mainTextureOffset = new Vector2(offset.x - speed * Time.deltaTime, offset.y);
        }

    }

}