using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHearth : MonoBehaviour
{
    [SerializeField] private RawImage[] Heart;
    private int Vida;
    public string Lose;

    void Start()
    {
        Vida = Heart.Length;
        UpdateHearts();
    }

    void Update()
    {
        UpdateHearts(); 
        gameOver();
    }

    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.tag == "Enemy")
        {
            Vida -= 1;
        }
        else if (Collision.gameObject.tag == "Trupper")
        {
            Vida -= 2;
        }
        else if (Collision.gameObject.tag == "Boss")
        {
            Vida -= 3;
        }
        Vida = Mathf.Clamp(Vida, 0, Heart.Length);
        UpdateHearts();
    }
    private void UpdateHearts()
    {
        for (int i = 0; i < Heart.Length; i++)
        {
            Heart[i].enabled = i < Vida;
        }
    }

    private void gameOver()
    {
        if (Vida <= 0)
        {
            SceneManager.LoadScene(Lose);
        }
    }

private void OnTriggerEnter2D(Collider2D collision)
{
    if (Vida == 5)
    {
        return;
    }
    else if (collision.gameObject.tag == "Vida")
    {
        Vida++;
        Vida = Mathf.Clamp(Vida, 0, Heart.Length);
        Destroy(collision.gameObject);
        UpdateHearts();
    }
}

}

