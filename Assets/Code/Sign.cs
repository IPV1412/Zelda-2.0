using UnityEngine;
using TMPro; // Importa el espacio de nombres para TextMesh Pro

public class Sign : MonoBehaviour
{
    public GameObject textPrefab;  //prefab del texto que se instanciará en el canvas
    public string signMessage; //mensaje del cartel
    public Canvas canvas; //el canvas xd
    public TMP_FontAsset newFont;

    private GameObject textInstance; // Instancia del texto
    private TextMeshProUGUI textMesh; // Componente TextMeshProUGUI del texto

    private bool playerInRange = false; // Bandera para controlar si el jugador está en rango

    void Start()
    {
        // Instancia el texto y lo desactiva inicialmente
        textInstance = Instantiate(textPrefab, canvas.transform);
        textMesh = textInstance.GetComponent<TextMeshProUGUI>();

        // Configura el mensaje específico del cartel
        if (textMesh != null)
        {
            textMesh.text = signMessage;
        }
        textInstance.SetActive(false); // Desactivar inicialmente
    }

    void Update()
    {
        // Si el jugador está en rango, activa el texto
        if (playerInRange)
        {
            textInstance.SetActive(true);
        }
        else
        {
            textInstance.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered range of sign.");
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited range of sign.");
            playerInRange = false;
        }
    }
}
