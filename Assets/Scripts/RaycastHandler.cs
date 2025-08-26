using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    public bool TryGetCubeFromMousePosition(out Cube cube, out Vector3 hitPoint)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out cube))
            {
                hitPoint = hit.point;
                return true;
            }
        }

        cube = null;
        hitPoint = Vector3.zero;
        return false;
    }
}