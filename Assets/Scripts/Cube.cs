using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1.0f;

    public float SplitChance
    {
        get => _splitChance;
        set => _splitChance = value;
    }
}