using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UiGame : MonoBehaviour
{


    public static UiGame get; // 

    public delegate void _BurbujaHit(GameObject go); //Delegado

    public event _BurbujaHit Burbujahit; //Evento del raycast de la burbuja

    public GameObject TargetNice; // Mujer 1

    public GameObject TargetMedium;// Mujer 2

    public GameObject TargetHard;// Mujer 3

    public Text ExpectativaMeta; //Texto Expectativa maxima
    public Text Expectativa; // Texto Expectativa parcial
    public Text InterestParcial; // Texto de interes parcial
    public Text MaxInterest;   // Texto de cuanto es el interes maximo
    public Text contador;    // Contador Del tiempo de partida
    private float Expectation;// inicializacion de la expectativa
    private float ExpectativaVictoria;  // Expectativa necesaria para ganar
    private float InteresMaximo;  //Interes maximo que se puede tener
    private float interesInicial; //Interes desde el inicio
    private float DuracionPartidaText; //Texto de la duracion
    private float DuracionPartida = 400; // Tiempo de duracion de la partida;
    private float Restaporperdida; // El daño que se resta al perder 6 burbujas de las 3 principales

    public float InteresInicial { get => interesInicial; set => interesInicial = value; }

    private void Awake()
    {

        get = this;

    }

    public void Start()
    {

        UiTxtStart();
    }

    // Update is called once per frame
    public void Update()
    {



        //Tiempo de la partida 
        TimeTake();
        
        //Raycast
        if (Input.GetMouseButtonDown(0))
        {
            Raycasting();
        }
        //Actualizacion de datos dependiendo de la cita
        TargetIntNice cita1 = TargetNice.GetComponent<TargetIntNice>();
        if (cita1.Estoyvivo == true)
        {
            TargetintNice();
        }
        TargetIntMed cita2 = TargetMedium.GetComponent<TargetIntMed>();
        if (cita2.Estoyvivo == true)
        {
            TargetIntMed();
        }
        TargetIntHard cita3 = TargetHard.GetComponent<TargetIntHard>();
        if (cita3.Estoyvivo == true)
        {
            TargetIntHard();
        }
        if (Expectation == ExpectativaVictoria)
        {
            SceneManager.LoadScene("Victoria");
        }
        if (InteresInicial <= 0)
        {
            SceneManager.LoadScene("Derrota");
        }
        if (DuracionPartidaText <= 0)
        {
            SceneManager.LoadScene("Derrota");
        }

    }
    //********************************************************************************

    // Trae los datos uniciales de las citas para comenzar a jugar;
    private void TargetintNice()
    {
        TargetIntNice cita = TargetNice.GetComponent<TargetIntNice>();

        InteresInicial = cita.InteresActual;
        InteresMaximo = cita.InteresMaximo;
        Expectation = cita.Expectation;
        ExpectativaVictoria = cita.ExpectativaMeta;
    }
    private void TargetIntMed()
    {
        TargetIntMed cita1 = TargetMedium.GetComponent<TargetIntMed>();

        InteresInicial = cita1.InteresActual;
        InteresMaximo = cita1.InteresMaximo;
        Expectation = cita1.Expectation;
        ExpectativaVictoria = cita1.ExpectativaMeta;
    }

    private void TargetIntHard()
    {
        TargetIntHard cita2 = TargetHard.GetComponent<TargetIntHard>();

        InteresInicial = cita2.InteresActual;
        InteresMaximo = cita2.InteresMaximo;
        Expectation = cita2.Expectation;
        ExpectativaVictoria = cita2.ExpectativaMeta;
    }
    //********************************************************************************

    //Contador del tiempo
    private void UiTxtStart()
    {
        contador.text = " " + DuracionPartida;

    }

    //Contruccion de los contadores de prueba
    private void TimeTake()
    {
        DuracionPartidaText = DuracionPartida - (int)MejoraGenerador.time / 1;
        contador.text = "Duracion de la partida: " + DuracionPartidaText;
        InterestParcial.text = "Interes Actual: " + InteresInicial;
        MaxInterest.text = "Interes Maximo: " + InteresMaximo;
        Expectativa.text = "Expectativa: " + Expectation;
        ExpectativaMeta.text = "Objetivo de Expectativa: " + ExpectativaVictoria;
    }

    //Raycast
    void Raycasting()
    {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit tempHit;


        if (Physics.Raycast(ray, out tempHit))
        {

            if (tempHit.collider.GetComponent<Burbuja>() != null)
            {
                Burbujahit?.Invoke(tempHit.collider.gameObject);
            }


        }
    }
    
    
}
