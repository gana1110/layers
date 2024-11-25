using UnityEngine;

public class RotateOnKeyPress : MonoBehaviour
{
    // public float rotationSpeed = 1f; // Tours par minute
    private bool isRotating = false;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
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

	
 	// Saut
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true) // Vérifie si le personnage est presque au sol
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

     }
}