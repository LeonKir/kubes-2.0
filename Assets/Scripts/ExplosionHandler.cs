using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ExplosionHandler : MonoBehaviour
{
    public void ApplyExplosion(Vector3 explosionPosition, float force = 10f)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        if (rigidbody != null)
        {
            Vector3 explosionDir = (transform.position - explosionPosition).normalized;
            rigidbody.AddForce(explosionDir * force, ForceMode.Impulse);
        }
    }

    public void ApplyExplosionForce(Vector3 explosionPosition, float baseForce, float baseRadius, float cubeScale)
    {
        float explosionRadius = baseRadius / cubeScale;
        float explosionForce = baseForce / cubeScale;

        Rigidbody[] rigidbodies = FindObjectsOfType<Rigidbody>();

        foreach (var rigidbody in rigidbodies)
        {
            if (rigidbody == null || rigidbody.gameObject == this.gameObject) continue;

            //float distance = Vector3.Distance(rigidbody.position, explosionPosition);
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
}