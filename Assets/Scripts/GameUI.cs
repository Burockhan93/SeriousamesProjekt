using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{


    public Text remainingLifeText;
    public Text foodText;
    public GameObject[] food;

    public static GameObject selectedFood;
    private int foodPointer = 0;
    public static int remainingLife = 5;

    // Start is called before the first frame update
    void Start()
    {
        remainingLifeText.text = remainingLife.ToString();

        changeFood(0);
    }

    // Update is called once per frame
    void Update()
    {
        
        //change selected item
        if (Input.mouseScrollDelta.y != 0)
        {
            Debug.Log("Scroll " + (int)Input.mouseScrollDelta.y);
            changeFood((int)Input.mouseScrollDelta.y);
        }

        if (remainingLife > 0)
        {
            remainingLifeText.text = remainingLife.ToString();
        }
        else
        {
            Debug.Log("0 remaining life -> end game.");
        }

    }


    public void changeFood(int direction)
    {
        //modulo to scroll up/down
        foodPointer = mod(foodPointer + direction, food.Length);
        Debug.Log("Länge " + food.Length + "; pointer " + foodPointer);

        //change food
        selectedFood = food[foodPointer];

        //change the food image
        //foodImage.MeshRenderer.Materials = selectedFood.Material;
        //foodImage.GetComponent<MeshRenderer>().material = selectedFood.GetComponent<MeshRenderer>().sharedMaterial;
        foodText.text = selectedFood.name;

    }

    int mod(int a, int b)
    {
        int r = a % b;
        return r < 0 ? r + b : r;
    }

}
