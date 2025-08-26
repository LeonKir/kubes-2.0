using UnityEngine;

public class InputReader : MonoBehaviour
{
    public bool IsLeftMouseButtonDown()
    {
        const int mouseButton = 0;
        return Input.GetMouseButtonDown(mouseButton);
    }
}