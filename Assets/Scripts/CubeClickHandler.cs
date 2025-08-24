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
                bool canSplit = cube.Split();

                if (!canSplit)
                {
                    var explosionHandler = cube.GetComponent<ExplosionHandler>();
                    if (explosionHandler != null)
                    {
                        explosionHandler.ApplyExplosionForce(hit.point, _explosionForce, 5f, averageScale);
                    }
                }
            }
        }
    }
}