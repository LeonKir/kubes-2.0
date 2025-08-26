using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ExplosionHandler : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;

    public void ApplyExplosionForce(Vector3 explosionPosition, float baseForce, float baseRadius, float cubeScale)
    {
        float explosionRadius = baseRadius / cubeScale;
        float explosionForce = baseForce / cubeScale;

        Rigidbody[] rigidbodies = FindObjectsOfType<Rigidbody>();

        foreach (var rigidbody in rigidbodies)
        {
            if (rigidbody == null || rigidbody.gameObject == this.gameObject) continue;

            float distance = (rigidbody.position - explosionPosition).sqrMagnitude;

            if (distance <= explosionRadius)
            {
                float distanceFactor = 1f - (distance / explosionRadius);
                Vector3 direction = (rigidbody.position - explosionPosition).normalized;
                float force = explosionForce * distanceFactor;

                rigidbody.AddForce(direction * force, ForceMode.Impulse);
            }
        }
    }

    public void ApplyExplosionToCubes(List<Cube> cubes, Vector3 explosionPosition, float force)
    {
        foreach (Cube cube in cubes)
        {
            if (cube != null && cube.TryGetComponent(out Rigidbody rb))
            {
                Vector3 explosionDirection = (cube.transform.position - explosionPosition).normalized;
                rb.AddForce(explosionDirection * force, ForceMode.Impulse);
            }
        }
    }
}