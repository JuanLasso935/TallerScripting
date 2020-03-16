using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIntHard : TargetInt
{

    // Inicializacion atributos
    public bool Estoyvivo = false;
    private float SumaExpectation;
    private float StandarPoints;  
    public int count;
    private float Contador = 10;
    private float burbujasperdidas;
    //Seteo de atributos
    public void Awake()
    {

        SumaExpectation = 8f;
        Estoyvivo = true;
    }

    //Seteo de atributos
    public void Start()
    {

        UiGame.get.Burbujahit += Recibirobj;
        InteresActual = 10;
        InteresMaximo = 100;
        Expectation = 0;
        ExpectativaMeta = 600;
        
        StandarPoints = SumaExpectation;
    }

    public void Update()
    {
        burbujasperdidas += Time.deltaTime;
        
        if ((int)burbujasperdidas > Contador )
        {
            InteresActual -= 2;
            burbujasperdidas = 0;
        }
    }
    // Metodos que son los gustos de la chicha
    override public void PreferredTrait()
    {
       
    }
    override public void DislikedTrait()
    {
        

    }
    override public void HatedTrait()
    {

        Expectation += SumaExpectation - (SumaExpectation * 0.55f);
        InteresActual -=  (InteresActual * 0.02f);



    }


    

    //Interaccion de la chica con las burbujas
    private void Recibirobj(GameObject go)
    {

        Burbuja actual = go.GetComponent<Burbuja>();

        switch (actual.TypeBurbuja)
        {


            case ETypeBurbuja.Flirt:
                Expectation += SumaExpectation;
                burbujasperdidas = 0;
                Destroy(actual.gameObject);

                break;
            case ETypeBurbuja.Love:
                HatedTrait();
                burbujasperdidas = 0;
                Destroy(actual.gameObject);
                break;
            case ETypeBurbuja.Intelligence:
                Expectation += SumaExpectation;
                burbujasperdidas = 0;
                Destroy(actual.gameObject);
                break;
            case ETypeBurbuja.Intimacy:
                InteresActual += 5;
                Destroy(actual.gameObject);
                break;
            case ETypeBurbuja.Affection:

                count += 1;
                if (count / 3 > 0 && count / 3 <= 10)
                {
                    SumaExpectation += (SumaExpectation * 0.05f);
                }
                Destroy(actual.gameObject);
                break;
            case ETypeBurbuja.Boorish:
                StandarPoints = StandarPoints * 0.75f;
                Expectation -= StandarPoints;
                if (Expectation < 0)
                {
                    Expectation = 0f;
                }
                InteresActual -= InteresActual * 0.05f;

                Destroy(actual.gameObject);
                break;
            default:
                break;
        }
        
    }
}
