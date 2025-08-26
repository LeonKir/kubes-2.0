using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1.0f;

    public float SplitChance
    {
        get => _splitChance;
        private set => _splitChance = value;
    }

    public void SetSplitChance(float chance)
    {
        SplitChance = chance;
    }
}