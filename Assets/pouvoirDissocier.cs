using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dissocier : MonoBehaviour
{
    public SpriteRenderer spriteRenderere; // Référence au SpriteRenderer
    public Sprite dissocierselect; //Nouveau sprite

    
    void Start()
    {
    }

    void DetectMouseHovertoo()
    {
        SpriteRenderer spriteRenderere = GetComponent<SpriteRenderer>();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit)){
            if (hit.transform == transform)
            {
                spriteRenderere.sprite = dissocierselect; // Change le sprite
                Transform arbre = transform.parent.parent;
                Debug.Log(arbre);
                int compteur = 0;
                while (compteur < 5)
                {
                    foreach (Transform child in arbre)
                    {   
                        if (child.name != "pointilles" && child.name != "pouvoirsarbre")
                        {
                            child.SetParent(null);
                        }
                    }
                    compteur++;
                }
                
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        DetectMouseHovertoo();
    }
}
