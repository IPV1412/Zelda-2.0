using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    [Tooltip("Velocidad de movimiento del enemigo.")]
    public float speed = 1.0f;
    private Rigidbody2D _rigidbody;
    public Vector2 directionToMove;

    private bool isMoving;
    [Tooltip("Tiempo en que tarda el enemigo entre pasos sucesivos.")]
    public float timeBetweenSteps;
    private float timeBetweenStepsCounter;

    [Tooltip("Tiempo en que tarda el enemigo en dar un paso.")]
    public float timeToMakeStep;
    private float timeToMakeStepCounter;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        timeBetweenStepsCounter = timeBetweenSteps;
        timeToMakeStepCounter = timeToMakeStep;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            timeToMakeStepCounter -= Time.deltaTime;
            _rigidbody.velocity = directionToMove * speed;
            if (timeToMakeStepCounter < 0)
            {
                isMoving = false;
                timeBetweenStepsCounter = timeBetweenSteps;
                _rigidbody.velocity = Vector2.zero;
            }
        }
        else
        {
            timeBetweenStepsCounter -= Time.deltaTime;
            if (timeBetweenStepsCounter < 0) // Cuando se queda sin tiempo de estar parado, arranca al enemigo para dar un paso.
            {
                isMoving = true;
                timeToMakeStepCounter = timeToMakeStep;

                // Cambia la dirección de movimiento de manera aleatoria
                if (Random.Range(0, 2) == 0)
                {
                    directionToMove = Vector2.right;
                }
                else
                {
                    directionToMove = Vector2.left;
                }
            }
        }
    }
}
