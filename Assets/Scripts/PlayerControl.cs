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
        //set up listener to control the player
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

        //attach throw and crash sound to the player
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
        //move the player only if he read the instructions
        if (!StaticClass.runGame)
        {
            return;
        }

        //throw fruit with space
        if (Input.GetKeyDown(KeyCode.Space) && _fruitCoolDown <= 2)
        {
            throwFruit();
        }
        //set cooldown to avoid food spamming
        _fruitCoolDown -= Time.deltaTime;

        //move player
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

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

        //change selected food
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
    //check collisions with animal and border -> ignore food collisons #collison-matrix
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Animal")
        {
            //play crash sound and decrease life
            other.gameObject.SetActive(false);
            GameUI.remainingLife -= 1;
            crashAudio.Play();
        }
        else if (other.gameObject.tag == "Border")
        {
            //teleport player
            transform.position = new Vector3(1.22f, 0, -11.9f);
        }
    }

    void throwFruit()
    {
        //get position of the player to set the spawned fruit
        GameObject spawnedFruit = spawnFruit();
        spawnedFruit.SetActive(true);
        spawnedFruit.transform.position = transform.position;
        spawnedFruit.transform.rotation = transform.rotation;
        _fruitCoolDown = 3;
    }

    GameObject spawnFruit()
    {
        //play throw audio
        audio.Play();

        GameObject spawnFruit;

        //get the correct fruit
        int idx = GameUI.itemPointer;

        Debug.Log("Throw fruit with id: " + idx);
        spawnFruit = fruitPool.fruitPool[idx].Dequeue();
        fruitPool.fruitPool[idx].Enqueue(spawnFruit);
        return spawnFruit;
    }
}
