using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform layer; // L'objet à suivre
    public float smoothSpeed = 0.125f; // Vitesse de suivi
    public Vector3 offset; // Décalage de la caméra par rapport à l'objet

    void Start()
{
    // Décalage sur l'axe des X pour placer le personnage légèrement à gauche
    offset = new Vector3(2f, 2f, offset.z); // Décale de 2 unités à gauche, modifie cette valeur selon ton besoin
}
    void LateUpdate()
    {
        if (layer != null)
        {
            // Obtenir la position cible en incluant à la fois l'axe des X et des Y
            Vector3 desiredPosition = new Vector3(layer.position.x + offset.x, layer.position.y + offset.y, transform.position.z);
            
            // Lisser la transition de la position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Appliquer la nouvelle position à la caméra
            transform.position = smoothedPosition;
        }
    }
}






/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
        public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Récupère les entrées de l'utilisateur
        float horizontal = Input.GetAxis("Horizontal"); // Flèches gauche/droite
        float vertical = Input.GetAxis("Vertical");     // Flèches haut/bas

        // Crée un vecteur de direction basé sur les entrées
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

        // Déplace l'objet
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
*/