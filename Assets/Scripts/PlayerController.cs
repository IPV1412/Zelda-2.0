using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.5f;
    private const string AXIS_H = "Horizontal",
                         AXIS_V = "Vertical", 
                         LAST_H = "LastH",
                         LAST_V = "LastV",
                         WALK = "Walking";
    
    private Animator _animator;

    public Vector2 lastMovement = Vector2.zero;
    private bool walking = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        this.walking = false;
        if (Mathf.Abs(Input.GetAxisRaw(AXIS_H)) > 0.2f)
        {
            Vector3 translation = new Vector3(
                Input.GetAxisRaw(AXIS_H) * this.speed * Time.deltaTime, 0, 0);
            this.transform.Translate(translation);
            this.walking = true;
            lastMovement = new Vector2(Input.GetAxisRaw(AXIS_H), 0); //Guarda la última dirección conocida del personaje en x.

        }
        if (Mathf.Abs(Input.GetAxisRaw(AXIS_V)) > 0.2f)
        {
            Vector3 translation = new Vector3(0,
                Input.GetAxisRaw(AXIS_V) * this.speed * Time.deltaTime, 0);
            this.transform.Translate(translation);
            this.walking = true;
            lastMovement = new Vector2(0, Input.GetAxisRaw(AXIS_V)); //Guarda la última dirección conocida del personaje en y.
        }
    }

    private void LateUpdate()
    {
        _animator.SetFloat(AXIS_H, Input.GetAxisRaw(AXIS_H));
        _animator.SetFloat(AXIS_V, Input.GetAxisRaw(AXIS_V));
        _animator.SetFloat(LAST_H, lastMovement.x);
        _animator.SetFloat(LAST_V, lastMovement.y);
        _animator.SetBool(WALK, walking);
    }
}
