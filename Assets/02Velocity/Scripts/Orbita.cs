using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbita : MonoBehaviour
{
    [SerializeField]
    private Vector3 Velocity;
   
    [SerializeField]
    private float accelerationMag = 2;

   
    [Header("World")]
    [SerializeField] new Camera  camera;
    [SerializeField] Transform target;


    private void Update()
    {
       
        MakeOrbit();
    }
   

    public void MakeOrbit()
    {
        Vector3 accelerationOrbit = (target.position - transform.position) ;
        Velocity += accelerationOrbit * Time.deltaTime;
        transform.position += Velocity * Time.deltaTime;
    }
}
