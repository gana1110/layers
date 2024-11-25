using UnityEngine;

public class Layer : MonoBehaviour
{
    // public float rotationSpeed = 1f; // Tours par minute
    private bool isRotating = false;
    public float moveSpeed = 5f;
    public float jumpForce = 2000f;
    public float groundCheckDistance = 1f;
    public LayerMask groundLayer;
    private bool isGrounded;

    private Rigidbody rb;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet avec lequel il entre en collision a un tag spécifique
        if (collision.gameObject.CompareTag("sol"))
        {
            isGrounded = true;
        }	
    }

    private void OnCollisionExit(Collision collision)
    {
 	if (collision.gameObject.CompareTag("sol"))
        {
            isGrounded = false;
        }
        isGrounded = false;
    }


    void Update()
    {



	    // Récupère les entrées de l'utilisateur
        float horizontal = Input.GetAxis("Horizontal"); // Flèches gauche/droite
        float vertical = Input.GetAxis("Vertical");     // Flèches haut/bas

        // Crée un vecteur de direction basé sur les entrées
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

        // Déplace l'objet
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // Mouvement de Layer

        // Trouver l'objet enfant par son nom
        Transform childTransform = transform.Find("jambeG");

        if (childTransform != null)
        {
            // Exemple de modification de la position de l'objet enfant
            childTransform.rotation = Quaternion.Euler(10, 10, 10);
        }
        else
        {
            Debug.LogWarning("L'objet enfant n'a pas été trouvé.");
        }

	
 	// Saut
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true) // Vérifie si le personnage est presque au sol
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

     }
}