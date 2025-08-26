using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private MouseButtonRegistration _inputReader;
    [SerializeField] private RaycastHandler _raycastHandler;
    [SerializeField] private CubeHandler _cubeHandler;

    private void Update()
    {
        if (_inputReader.IsLeftMouseButtonDown())
        {
            if (_raycastHandler.TryGetCubeFromMousePosition(out Cube cube, out Vector3 _))
            {
                _cubeHandler.HandleCube(cube);
            }
        }
    }
}
