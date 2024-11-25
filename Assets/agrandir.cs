using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class agrandir : MonoBehaviour
{
    public SpriteRenderer spriteRenderere; // Référence au SpriteRenderer
    public Sprite Pouvoir_Agrandir; // Sprite de base
    public Sprite agrandirselect; //Nouveau sprite

    
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
                spriteRenderere.sprite = agrandirselect; // Change le sprite



                Transform pointilles = transform.parent.parent.Find("pointilles");
                Debug.Log(pointilles);
                SpriteRenderer spriteRenderer = pointilles.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null) {
                    spriteRenderer.enabled = true;
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
