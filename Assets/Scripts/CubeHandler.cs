using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private float _explosionForce = 2f;
    [SerializeField] private ExplosionHandler _explosionHandler;

    private List<Cube> _allCubes = new List<Cube>();

    public void HandleCube(Cube cube)
    {
        Vector3 cubeScale = cube.transform.localScale;
        float averageScale = (cubeScale.x + cubeScale.y + cubeScale.z) / 3f;

        if (CanSplit(cube))
        {
            List<Cube> newCubes = _spawner.RequestSplit(cube);
            _explosionHandler.ApplyExplosionToCubes(newCubes, cube.transform.position, averageScale);

            _allCubes.AddRange(newCubes);
        }
        else
        {
            if (_explosionHandler != null)
            {
                _explosionHandler.ApplyExplosionForce(
                    cube.transform.position,
                    _explosionForce,
                    5f,
                    averageScale,
                    _allCubes
                );
            }
        }

        Destroy(cube.gameObject);
    }

    private bool CanSplit(Cube cube)
    {
        return Random.value <= cube.SplitChance;
    }
}