using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 offset; // Décalage entre le curseur et la position de l'objet
    private Camera mainCamera;
    private bool isDragging = false;
    private bool isInCollision = false; // Pour savoir si on est dans un BoxCollider

    void Start()
    {
        mainCamera = GameObject.Find("Camera").GetComponent<Camera>();
    }

    void OnMouseDown()
    {
        if (!isInCollision) // Seulement si on n'est pas en collision
        {
            offset = transform.position - GetMouseWorldPosition();
            isDragging = true;
        }
    }

    void OnMouseDrag()
    {
        if (isDragging && !isInCollision) // Tant qu'on est en train de déplacer et pas en collision
        {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false; // Arrêter le déplacement quand on relâche le clic
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Mathf.Abs(mainCamera.transform.position.z); // Distance caméra-objet
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }

    // Détecter l'entrée dans un BoxCollider trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StopDrag")) // Tag de l'objet qui arrête le drag
        {
            isDragging = false; // Stopper le drag
            isInCollision = true; // Indiquer qu'on est dans une collision
        }
    }

    // Détecter la sortie d'un BoxCollider trigger
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("StopDrag")) // Tag de l'objet qui arrête le drag
        {
            isInCollision = false; // Sortie de la collision, on peut déplacer à nouveau
        }
    }
}



/*using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 offset; // Décalage entre le curseur et la position de l'objet
    private Camera mainCamera;
    private bool isDragging = false;

    void Start()
    {
    mainCamera = GameObject.Find("Camera").GetComponent<Camera>();
    }
    void OnMouseDown()
    {
 // Calculer le décalage entre la position de l'objet et le curseur
        offset = transform.position - GetMouseWorldPosition();
        isDragging = true;
        
       
    }

    void OnMouseDrag()
    {
        // Tant que l'objet est en train d'être déplacé, ajuster sa position en fonction du curseur
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false; // Arrêter le déplacement quand on relâche le clic
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Récupérer la position du curseur de la souris dans l'espace du monde
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Mathf.Abs(mainCamera.transform.position.z); // Distance caméra-objet
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}*/