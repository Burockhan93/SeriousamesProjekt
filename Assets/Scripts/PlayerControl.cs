using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    [SerializeField] GameObject camOrient;
    [SerializeField] GameObject fruit;

    private float _fruitCoolDown = 2;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
       // if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) return;
        if (Input.GetKeyDown(KeyCode.Space) && _fruitCoolDown >=2)
        {
            _fruitCoolDown -= Time.deltaTime;
            throwFruit();
        }
        

        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

         // Make it move 10 meters per second instead of 10 meters per frame...
         translation *= Time.deltaTime;
         rotation *= Time.deltaTime;

         // Move translation along the object's z-axis
         transform.Translate(0, 0, translation);

        // Rotate around our y-axis
        if (Input.GetAxis("Horizontal") != 0) {
            transform.Rotate(0, rotation, 0);
        }
        else
        {
            Quaternion newRotation = Quaternion.Euler(0, camOrient.transform.eulerAngles.y, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 10* Time.deltaTime);
            
        }

        //animationen, die werden noch verbessert. Zurzeit läuft er nur
        _animator.SetFloat("Speed_f", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal")))); // Wenn das Player sich bewegt, summirieren wir die Werte von beiden Axis und setzen wir die Wert ins Speed_f ein. Diese Parameter ist für die "Running Animation" verantwortlich
        _animator.SetBool("Static_b", false); // Sollte man Static state "Static_b" false setzt, erfüllt man eine Voraussetzung für "Runinng animation". Die andere ist : Speed_f >=0.5f
    }

    void throwFruit()
    {
        Instantiate(fruit, transform.position, transform.rotation);
        _fruitCoolDown = 2;

    }
}
