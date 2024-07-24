using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemTrigger : MonoBehaviour
{
    public string playerTag = "Player";
    public string targetScene = "Win";  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            SceneManager.LoadScene(targetScene);
        }
    }
}

