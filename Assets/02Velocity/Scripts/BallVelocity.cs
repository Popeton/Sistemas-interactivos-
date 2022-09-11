using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallVelocity : MonoBehaviour
{
    private MyVector2D vectorPositon;
    private MyVector2D displacement;
    
    [SerializeField] private MyVector2D Velocity;
    [SerializeField] MyVector2D acceleration;
    [SerializeField] float mass = 1f;

    
    private MyVector2D netforce;
    [Header("Forces")]
    [SerializeField] private MyVector2D force;
    [SerializeField] private MyVector2D wind;
    [SerializeField] private MyVector2D gravity;
    
    
    [Header("World")]
    [SerializeField] new Camera  camera;
    [Range(0f, 1f)][SerializeField] float dampingFactor;
    float timer;
    void Start()
    {
        vectorPositon =  new  MyVector2D(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        // netforce = wind + gravity;
        ApplyForce( wind + gravity);
        Move();
    }
    void Update()
    {
        vectorPositon.Draw(Color.red);
        displacement.Draw(Color.blue);
        Velocity.Draw(Color.cyan);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timer == 0)
            {
               
                acceleration = new MyVector2D(9.8f, 0);
                timer++;
                 Velocity *= 0;
            }
            else if (timer == 1)
            {
              
                acceleration = new MyVector2D(0, 9.8f);
               
                timer++;
            }
            else if (timer == 2)
            {
                acceleration = new MyVector2D(-9.8f, 0);
                Velocity *= 0;
                timer++;
            }
            else if ((timer == 3)){

                acceleration = new MyVector2D(0, -9.8f);
              
                timer++;
            }
            if (timer >= 4)
            {
                timer = 0;
            }

        }

        
    }

    public void Move()
    {
        //displacement = Velocity * Time.deltaTime;
        Velocity = Velocity + acceleration * Time.deltaTime;
        vectorPositon = vectorPositon + Velocity * Time.deltaTime;
        print("moving");

        if(Mathf.Abs(vectorPositon.x)> camera.orthographicSize)
        {
            //Velocity *= -1;
            Velocity.x = Velocity.x * -1;
            vectorPositon.x = Mathf.Sign(vectorPositon.x) * camera.orthographicSize;
            //Velocity *= dampingFactor; // damping factor
        }
      
        if (Mathf.Abs(vectorPositon.y) > camera.orthographicSize)
        {
           /// Velocity *= -1;
            Velocity.y = Velocity.y * -1;
            vectorPositon.y = Mathf.Sign(vectorPositon.y) * camera.orthographicSize;
           // Velocity *= dampingFactor; // damping factor
        }

        transform.position = new Vector3(vectorPositon.x, vectorPositon.y,0);
    }

    private void ApplyForce(MyVector2D force)
    {
        acceleration += force / mass;
    }

}
