using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private float _explosionForce = 10f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }
    }

    private void HandleMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                Vector3 cubeScale = cube.transform.localScale;
                float averageScale = (cubeScale.x + cubeScale.y + cubeScale.z) / 3f;

                cube.ChangeColor();
                bool didSplit = cube.Split();

                if (!didSplit)
                {
                    ApplyExplosionForce(hit.point, _explosionForce, 5f, averageScale);
                }
            }
        }
    }

    private void ApplyExplosionForce(Vector3 explosionPosition, float baseForce, float baseRadius, float cubeScale)
    {
        float explosionRadius = baseRadius / cubeScale;
        float explosionForce = baseForce / cubeScale;

        Rigidbody[] rigidbodies = FindObjectsOfType<Rigidbody>();

        foreach (var rigidbody in rigidbodies)
        {
            if (rigidbody == null || rigidbody.gameObject == this.gameObject) continue;

            float distance = Vector3.Distance(rigidbody.position, explosionPosition);

            if (distance <= explosionRadius)
            {
                float distanceFactor = 1f - (distance / explosionRadius);
                Vector3 direction = (rigidbody.position - explosionPosition).normalized;
                float force = explosionForce * distanceFactor;

                rigidbody.AddForce(direction * force, ForceMode.Impulse);
            }
        }
    }

}