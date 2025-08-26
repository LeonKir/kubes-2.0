using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    public List<Cube> RequestSplit(Cube originalCube)
    {
        List<Cube> newSpawnedCubes = new List<Cube>();

        int minCountCubes = 2;
        int maxCountCubes = 7;
        int newCubesCount = Random.Range(minCountCubes, maxCountCubes);
        float bias = 0.5f;
        float decreaseChance = 0.5f;

        for (int i = 0; i < newCubesCount; i++)
        {
            float newSplitChance = originalCube.SplitChance * decreaseChance;
            Debug.Log(newSplitChance);

            Cube newCube = SpawnCube(
                originalCube.transform.position + Random.insideUnitSphere * bias,
                originalCube.transform.localScale * bias,
                newSplitChance);

            newSpawnedCubes.Add(newCube);
        }

        return newSpawnedCubes;
    }

    private Cube SpawnCube(Vector3 position, Vector3 scale, float splitChance)
    {
        float cubeOffset = 0.5f;

        Vector3 newPosition = position + Random.insideUnitSphere * cubeOffset;
        Cube cube = Instantiate(_cubePrefab, newPosition, Random.rotation);
        cube.transform.localScale = scale;
        cube.SetSplitChance(splitChance);
        cube.GetComponent<ColorChanger>()?.ChangeColor();

        return cube;
    }
}