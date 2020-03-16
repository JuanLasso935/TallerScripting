using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Material))]
public class Burbuja : MonoBehaviour
{

    //Seteo de atributos

    [SerializeField]
    private float speed; // Velocidad de la butbuja
    public Rigidbody rb;
    public ETypeBurbuja TypeBurbuja; // Tipo de burbuja

    private void Start()
    {
     
        rb = this.GetComponent<Rigidbody>();
      
    }

    //llamado de los metodos cada segundo
    private void Update()
    {   
        rb.velocity = new Vector3(0,-speed);

        CambioVelicodad();
    }

    // Destruit lo que esta fuera de la pantalla (Se va a cambiar para poder poner que si se destruyen muchas burbujas de las buenas, se le baje el interes)
   /* void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    */

    // Metodo para el cambio de la velocdiad de las burbujas
    void CambioVelicodad()
    {
       if (MejoraGenerador.Timer <= 400)
        {
            speed = 5 + (((int)MejoraGenerador.Timer)/40) * 1f;
        }
    }

}