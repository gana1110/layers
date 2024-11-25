using UnityEngine;

public class MouseHoverDetection : MonoBehaviour
{

    void Update()
    {
        // Appelle la fonction qui détecte si la souris est sur l'objet à chaque frame
        DetectMouseHover();
    }

    void DetectMouseHover()
    {
        Transform pouvoirs = transform.Find("pouvoirs");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Input.GetMouseButtonDown(0)){
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
    		        if (pouvoirs != null) {
        	            foreach (Transform child in pouvoirs) {
                        SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            	        if (spriteRenderer != null) {
                        // Active le SpriteRenderer
                        spriteRenderer.enabled = true;
            	        }
        	        }
    	            } 
                }
                else if(hit.collider.gameObject.name == "Pouvoir_Agrandir")
                {
                    if (pouvoirs != null) {
        	            foreach (Transform child in pouvoirs) {
                            if(child.name != "Pouvoir_Agrandir")
                            {
                                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
                                if (spriteRenderer != null) {
                                // Active le SpriteRenderer
                                spriteRenderer.enabled = false;
                                }
                            }
                        
        	        }
    	            } 
                }
                else
                {
    		        if (pouvoirs != null) {
                        foreach (Transform child in pouvoirs) {
                            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();            	            if (spriteRenderer != null) {
                            spriteRenderer.enabled = false;
                            }
                        }
                    }
                } 
            }
            else
                {
                    foreach (Transform child in pouvoirs) {
                        SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();            	            if (spriteRenderer != null) {
                        spriteRenderer.enabled = false;
                        }
                    }
                } 
        }
    }   
}
