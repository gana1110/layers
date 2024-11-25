using UnityEngine;

public class PouvoirReveles : MonoBehaviour
{

    void Update()
    {
        // Appelle la fonction qui détecte si la souris est sur l'objet à chaque frame
        DetectMouseHover();
    }

    void DetectMouseHover()
    {
        Transform pouvoirs = transform.Find("pouvoirsarbre");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Input.GetMouseButtonDown(0)){
            if (Physics.Raycast(ray, out hit))
            {
                    Debug.Log("Nom de l'objet touché : " + hit.collider.gameObject.name); // Vérifie le nom ici


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
                else if(hit.collider.gameObject.name == "pouvoirAgrandir")
                {
                    if (pouvoirs != null) {
        	            foreach (Transform child in pouvoirs) {
                            if(child.name != "pouvoirAgrandir")
                            {
                                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
                                if (spriteRenderer != null) {
                                spriteRenderer.enabled = false;
                                }
                            }
                        
        	        }
    	            } 
                }
                else if(hit.collider.gameObject.name == "PouvoirDissocier")
                {
                    if (pouvoirs != null) {
        	            foreach (Transform child in pouvoirs) {
                            if(child.name != "PouvoirDissocier")
                            {
                                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
                                if (spriteRenderer != null) {
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
