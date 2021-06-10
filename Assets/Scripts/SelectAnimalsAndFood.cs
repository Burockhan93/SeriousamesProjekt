using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectAnimalsAndFood : MonoBehaviour
{

    [SerializeField] GameObject animalPanel;
    [SerializeField] GameObject foodPanel;
    [SerializeField] GameObject toggleButton;
    [SerializeField] List<Animals> animals;
    [SerializeField] List<Food> food;

    // Start is called before the first frame update
    void Start()
    {
        //set reference to static class
        StaticClass.animals = animals;

        int offset = 0;
        //int y = (int)foodPanel.GetComponent<RectTransform>().anchoredPosition[1];
        int y = 450;
        foreach (var item in StaticClass.animals)
        {
            //transform.GetChild(i).gameObject.AddComponent<Toggle>();

            GameObject button = (GameObject)Instantiate(toggleButton);
            
            Toggle toggle = button.GetComponent<Toggle>();
            Vector3 offsetPosition = new Vector3(animalPanel.transform.position.x, y + offset, 0);

            button.transform.position = offsetPosition;
            offset -= 45;

            button.SetActive(true);
            toggle.onValueChanged.AddListener((isSelected) =>
            {
                Debug.Log("hit toggle");
                Debug.Log(toggle.isOn);
                item.active = toggle.isOn;
            });

            toggle.isOn = item.active;

            button.GetComponent<RectTransform>().SetParent(animalPanel.transform);
            //button.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, 10);
            button.GetComponentInChildren<Text>().text = item.name;
        }

        //set reference to static class
        StaticClass.food = food;

        offset = 0;
        //y = (int)foodPanel.GetComponent<RectTransform>().anchoredPosition[1];
        y = 450;
        foreach (var item in StaticClass.food)
        {
            //transform.GetChild(i).gameObject.AddComponent<Toggle>();

            GameObject button = (GameObject)Instantiate(toggleButton);
            Toggle toggle = button.GetComponent<Toggle>();
            Vector3 offsetPosition = new Vector3(foodPanel.transform.position.x, y + offset, 0);
            

            Debug.Log(offset + " " + item.name);

            button.transform.position = offsetPosition;
            offset -= 45;

            button.SetActive(true);
            toggle.onValueChanged.AddListener((isSelected) =>
            {
                Debug.Log("hit toggle");
                Debug.Log(toggle.isOn);
                item.active = toggle.isOn;
            });

            toggle.isOn = item.active;

            button.GetComponent<RectTransform>().SetParent(foodPanel.transform);

            //button.GetComponent<RectTransform>().SetParent(foodPanel.transform);
            //button.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, 10);
            button.GetComponentInChildren<Text>().text = item.name;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

}
