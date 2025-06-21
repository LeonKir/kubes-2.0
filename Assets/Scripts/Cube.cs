using UnityEngine;

[RequireComponent(typeof(ColorChanger))]
[RequireComponent(typeof(ExplosionHandler))]

public class Cube : MonoBehaviour
{
    private float _splitChance = 1.0f;
    private ColorChanger _colorChanger;
    private CubeSpawner _spawner;

    private void Awake()
    {
        _colorChanger = GetComponent<ColorChanger>();
        _spawner = FindObjectOfType<CubeSpawner>();
    }

    public void SetSplitChance(float chance)
    {
        _splitChance = chance;
    }

    public void ChangeColor()
    {
        _colorChanger?.ChangeColor();
    }

    public bool Split()
    {
        bool didSplit = false;

        if (Random.value <= _splitChance)
        {
            _spawner.RequestSplit(this);
            didSplit = true;
        }

        Destroy(gameObject);
        return didSplit;
    }


    public float GetSplitChance()
    {
        return _splitChance;
    }
}