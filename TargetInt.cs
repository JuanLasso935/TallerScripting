using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetInt : MonoBehaviour
{
    //Superclase de las targets;
    private float interesInicial;
    private float interesMaximo;
    private float expectation;
    private float expectativaMeta;
    public float InteresActual { get => interesInicial; set => interesInicial = value; }
    public float InteresMaximo { get => interesMaximo; set => interesMaximo = value; }
    public float Expectation { get => expectation; set => expectation = value; }
    public float ExpectativaMeta { get => expectativaMeta; set => expectativaMeta = value; }

    public abstract void PreferredTrait();
    public abstract void DislikedTrait();
    public abstract void HatedTrait();
    




}
