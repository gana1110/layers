using UnityEngine;

public class DragAndScaleSimple : MonoBehaviour
{
    public GameObject PlateformeOutline;  // L'objet à agrandir
    private Vector3 startMousePos;
    private Vector3 startScale;

    void OnMouseDown()
    {
        startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        startMousePos.z = 0;
        startScale = PlateformeOutline.transform.localScale;
    }

    void OnMouseDrag()
    {
        Vector3 currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentMousePos.z = 0;
        float scaleFactor = Vector3.Distance(startMousePos, currentMousePos);
        PlateformeOutline.transform.localScale = startScale * (1 + scaleFactor);
    }
}
