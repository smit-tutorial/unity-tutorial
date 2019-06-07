using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public float adjustmentX = 0f;  // Value that calibrate the X-axis touch input
    public float adjustmentY = 0f;  // Value that calibrate the Y-axis touch input

    private GameObject obj;  // an gameobject that have a collider
    private Ray mouseRay;
    private RaycastHit hit;

    private void Update()
    {
        MoveTouchedObject();
    }

    private void MoveTouchedObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit))
            {
                obj = hit.transform.gameObject;
            }
        }
        else if (Input.GetMouseButton(0) && obj)
        {
            obj.transform.position = new Vector3(
                Input.mousePosition.x + adjustmentX,
                Input.mousePosition.y + adjustmentY,
                obj.transform.position.z);
        }
        else if (Input.GetMouseButtonUp(0) && obj)
        {
            obj = null;
        }        
    }
}
