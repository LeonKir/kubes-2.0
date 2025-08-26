using System.Collections.Generic;
using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private float _explosionForce = 2f;

    private ExplosionHandler _explosionHandler;

    private void Awake()
    {
        _explosionHandler = FindObjectOfType<ExplosionHandler>();
    }

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

                if (CanSplit(cube))
                {
                    List<Cube> newCubes = _spawner.RequestSplit(cube);

                    _explosionHandler.ApplyExplosion(newCubes, cube.transform.position, averageScale);
                }
                else
                {
                    if (_explosionHandler != null)
                    {
                        _explosionHandler.ApplyExplosionForce(
                            cube.transform.position,
                            _explosionForce,
                            5f,
                            averageScale
                        );
                    }
                }

                Destroy(cube.gameObject);
            }
        }
    }

    private bool CanSplit(Cube cube)
    {
        bool didSplit = false;

        if (Random.value <= cube.GetSplitChance())
        {
            didSplit = true;
        }

        return didSplit;
    }
}