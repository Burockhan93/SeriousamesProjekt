using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControl : MonoBehaviour
{
    public float speed = 2.0f;
    public float rotationSpeed = 100.0f;
    [SerializeField] GameObject camOrient;
    [SerializeField] GameObject fruit;
    [SerializeField] AudioClip throwSound;
    [SerializeField] AudioClip crashSound;
    private AudioSource audio;
    private AudioSource crashAudio;
    private float _fruitCoolDown = 2;
    private const int DESTROY_FOOD_AFTER = 3;
    private Animator _animator;

    public FruitPool fruitPool;

    public UnityEvent<float> onWalkingInput;
    public static UnityEvent<float> onScrollInput;

    private void Awake()
    {
        onWalkingInput = new UnityEvent<float>();
        onScrollInput = new UnityEvent<float>();

        onWalkingInput.AddListener(Walk);
    }

    private void Walk(float val)
    {
        _animator.SetFloat("Speed_f", val); // Wenn das Player sich bewegt, summirieren wir die Werte von beiden Axis und setzen wir die Wert ins Speed_f ein. Diese Parameter ist f�r die "Running Animation" verantwortlich
        _animator.SetBool("Static_b", false); // Sollte man Static state "Static_b" false setzt, erf�llt man eine Voraussetzung f�r "Runinng animation". Die andere 
    }
    private void Start()
    {
        _animator = GetComponent<Animator>();

        audio = gameObject.AddComponent<AudioSource>();
        audio.playOnAwake = false;
        audio.clip = throwSound;
        audio.Stop();

        crashAudio = gameObject.AddComponent<AudioSource>();
        crashAudio.playOnAwake = false;
        crashAudio.clip = crashSound;
        crashAudio.Stop();
    }
    void Update()
    {
        if (!StaticClass.runGame)
        {
            return;
        }
        
        // if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) return;
        if (Input.GetKeyDown(KeyCode.Space) && _fruitCoolDown >= 2)
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
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(0, rotation, 0);
        }
        else
        {
            Quaternion newRotation = Quaternion.Euler(0, camOrient.transform.eulerAngles.y, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 10 * Time.deltaTime);

        }
        InvokeWalkingEvent();

        //animationen, die werden noch verbessert. Zurzeit l�uft er nur
        //_animator.SetFloat("Speed_f", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal")))); // Wenn das Player sich bewegt, summirieren wir die Werte von beiden Axis und setzen wir die Wert ins Speed_f ein. Diese Parameter ist f�r die "Running Animation" verantwortlich
        //_animator.SetBool("Static_b", false); // Sollte man Static state "Static_b" false setzt, erf�llt man eine Voraussetzung f�r "Runinng animation". Die andere ist : Speed_f >=0.5f

        if (Input.mouseScrollDelta.y != 0)
        {
            onScrollInput.Invoke(Input.mouseScrollDelta.y);
        }
    }

    private void InvokeWalkingEvent()
    {
        var walkingValue = (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal")));

        if (walkingValue < 0.5f) return;

        onWalkingInput.Invoke(walkingValue);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Animal")
        {
            other.gameObject.SetActive(false);
            GameUI.remainingLife -= 1;
            crashAudio.Play();
        }
        else if (other.gameObject.tag == "Border")
        {
            transform.position = new Vector3(1.22f, 0, -11.9f);
        }
    }

    void throwFruit()
    {
        GameObject spawnedFruit = spawnFruit();
        spawnedFruit.SetActive(true);
        spawnedFruit.transform.position = transform.position;
        spawnedFruit.transform.rotation = transform.rotation;
        _fruitCoolDown = 2;


    }
    GameObject spawnFruit()
    {
        audio.Play();

        GameObject spawnFruit;

        string idx = GameUI.selectedFood.name;

        switch (idx)
        {
            case "banana":
                spawnFruit = fruitPool.fruitPool["banana"].Dequeue();
                fruitPool.fruitPool["banana"].Enqueue(spawnFruit);
                return spawnFruit;
                break;
            case "bone":
                spawnFruit = fruitPool.fruitPool["bone"].Dequeue();
                fruitPool.fruitPool["bone"].Enqueue(spawnFruit);
                return spawnFruit;
                break;
            case "cookie":
                spawnFruit = fruitPool.fruitPool["cookie"].Dequeue();
                fruitPool.fruitPool["cookie"].Enqueue(spawnFruit);
                return spawnFruit;
                break;
            case "apple":
                spawnFruit = fruitPool.fruitPool["apple"].Dequeue();
                fruitPool.fruitPool["apple"].Enqueue(spawnFruit);
                return spawnFruit;
                break;
            case "steak":
                spawnFruit = fruitPool.fruitPool["steak"].Dequeue();
                fruitPool.fruitPool["steak"].Enqueue(spawnFruit);
                return spawnFruit;
                break;
            default:
                return null;

        }

    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.gameObject.tag == "Border")
    //    {
    //        Debug.Log("Collison with player ");
    //        Debug.Log(collision.collider.gameObject);
    //        Debug.Log(gameObject);
    //    }
    //    else
    //    {
    //        //animal collision
    //        Debug.Log("Animal collision.");
    //        Destroy(collision.collider.gameObject);
    //        AnimalSpawner.animals.Remove(collision.collider.gameObject);
    //        GameUI.remainingLife -= 1;

    //        crashAudio.Play();
    //    }

    //}


}
