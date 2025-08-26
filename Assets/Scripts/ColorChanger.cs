using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class ColorChanger : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public Color ChangeColor()
    {
        if (_renderer != null)
        {
            Color newColor = Random.ColorHSV();
            _renderer.material.color = newColor;
            return newColor;
        }

        return Color.white;
    }
}