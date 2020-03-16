using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MejoraGenerador : MonoBehaviour
{
   



    [SerializeField]
    private float altura, extremoIzquierdo, extremoDerecho;// Rango de creacion de la burbuja
    private float CONTADOR;// Cada cuanto se crea un burbuja
    [SerializeField]
    public static float time; // Tiempo que se demroa la burbuja en cambiar la velocidad
    public float contadorgenerador; // Tiempo que lleva la partida iniciada 
    public GameObject love;// Burbuja de amor
    public GameObject intelligence;// Burbuja de inteligencia
    public GameObject flirt;//Burbuja de ligar
    public GameObject affection;// Burbuja de afecto
    public GameObject boorish;//Burbuja de aburrimiento
    public GameObject intimancy;//Burbuja de intimidad


    // Propiedad para llevar el tiempo a las burbujas para que sepan en que velocidad deben estar
    public static float Timer { get => time; set => time = value; }
      
    //Optencion de los temporizadores y creacion de las burbujas
    private void Update()
    {
        contadorgenerador += Time.deltaTime;
        time += Time.deltaTime;
        CONTADOR = 1f;
        
       
        if (contadorgenerador >= CONTADOR)
        {
            CreadorDeBurbuja();
            contadorgenerador = 0;
           
        }
        
        
    }

    //Creador de las Burbujar
    void CreadorDeBurbuja()
    {
        int Aleatoreo = Random.Range(1, 100);
        // Posicion en la que van a spawnear 
        float posArrojar = Random.Range(extremoIzquierdo, extremoDerecho);

        if (Aleatoreo <= 15)//15%
        {
            
            
            GameObject create = Instantiate(flirt);
            create.transform.position = new Vector2(posArrojar, altura);


        }
        if (Aleatoreo > 15 && Aleatoreo <= 30)//15%
        {
          
            GameObject create = Instantiate(love);
            create.transform.position = new Vector2(posArrojar, altura);
            
        }
        if (Aleatoreo > 30 && Aleatoreo <= 45)//15%
        {
         
            GameObject create = Instantiate(intelligence);
            create.transform.position = new Vector2(posArrojar, altura);
        }
        if (Aleatoreo > 45 && Aleatoreo <= 65)//20%
        {
          
            GameObject create = Instantiate(affection);
            create.transform.position = new Vector2(posArrojar, altura);

        }
        if (Aleatoreo > 65 && Aleatoreo <= 95)//30%
        {
            
            GameObject create = Instantiate(boorish);
            create.transform.position = new Vector2(posArrojar, altura);
        }
        if (Aleatoreo > 95 && Aleatoreo <= 100)//5%
        {
           
            GameObject create = Instantiate(intimancy);
            create.transform.position = new Vector2(posArrojar, altura);
        }


    }


}