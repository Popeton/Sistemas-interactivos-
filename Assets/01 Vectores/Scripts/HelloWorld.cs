using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HelloWorld : MonoBehaviour
{
    [SerializeField]
    private MyVector2D myFirstVector;
    [SerializeField]
    private MyVector2D mySecondVector;
    [Range(0, 1)]
    [SerializeField] float scalar = 0.5f;
    

    void Start()
    {
        MyVector2D a = new MyVector2D(2,3);
        MyVector2D b = new MyVector2D(4,6);
        //MyVector2D d = a.Mul(2);
        //Debug.Log(d);
        MyVector2D r = a + b;
        MyVector2D d = a - b;
        MyVector2D c = a * 2;

        Debug.Log(r);
        Debug.Log(d);

        Debug.Log(c);

        Vector2 au = new Vector2(2, 3);
        Vector2 bu = new Vector2(4, 6);
        Vector2 dv = au + bu;
    }

    // Update is called once per frame
    void Update()
    {
       

        MyVector2D myThirdVector = (mySecondVector - myFirstVector)*scalar;
        MyVector2D final = myThirdVector + myFirstVector;
       
        
        
        myFirstVector.Draw(Color.blue);
        mySecondVector.Draw(Color.red);
        
        myThirdVector.Draw(myFirstVector, Color.green);
        myThirdVector.Draw(Color.green);
        
        final.Draw(Color.yellow);



    }






}
