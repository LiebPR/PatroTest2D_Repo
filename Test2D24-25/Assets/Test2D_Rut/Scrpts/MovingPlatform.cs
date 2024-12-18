using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float speed = 5; //Velocidad plataforma
    [SerializeField] int startingPoint; //Determinador del punto de inicio de la plataforma
    [SerializeField] Transform[] points; //Array que almacena la posición de los diferentes puntos de alcance
    int i; //Indice del array = Punto al que va a perseguir la plataforma

    // Start is called before the first frame update
    void Start()
    {
        //Al inicio del juego la plataforma se teleporta a la posición de igual valor que startingPoint
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if(Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++; //Suma 1 al valor del índice, persigue el siguiente punto
            if (i == points.Length) i = 0; //Resetea el circuito de puntos
        }

        //Mueve la plataforma a la posición del punto en el array que coincida con el valor del indice
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
}
