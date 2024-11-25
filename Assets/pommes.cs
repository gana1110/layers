using UnityEngine;

public class LockPositionIfChild : MonoBehaviour
{
    private Rigidbody rb;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Aucun Rigidbody trouvé sur l'objet.");
            return;
        }
        //

    }
    void DetectMouseHovertoo()
    {
        Transform pouvoirdeplacement = transform.Find("pouvoirdeplacement");
        if (pouvoirdeplacement == null){
            return;
        }

        SpriteRenderer spriteRender = pouvoirdeplacement.GetComponent<SpriteRenderer>();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit)){
            if (hit.collider.gameObject == this.gameObject)
                {
                    spriteRender.enabled = true;
        	    }
    	    } 
    }
        void Update()
    {
        DetectMouseHovertoo();
        // Vérifie à chaque frame si l'objet a un parent
        if (transform.parent != null)
        {
            // Si l'objet a un parent, verrouille la position
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }
        else
        {
            // Si l'objet n'a pas de parent, libère les contraintes de position
            rb.constraints = RigidbodyConstraints.None;
        }
    }   
}
    

    

