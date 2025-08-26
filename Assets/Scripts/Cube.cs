using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _splitChance = 1.0f;

    public void SetSplitChance(float chance)
    {
        _splitChance = chance;
    }

    public float GetSplitChance()
    {
        return _splitChance;
    }
}