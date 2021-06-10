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
        //show toggle button on the screen
        foreach (var item in StaticClass.animals)
        {
            GameObject button = (GameObject)Instantiate(toggleButton);

            Toggle toggle = button.GetComponent<Toggle>();
            Vector3 offsetPosition = new Vector3(animalPanel.transform.position.x, y + offset, 0);

            button.transform.position = offsetPosition;
            offset -= 45;

            button.SetActive(true);
            //set listener to detect changes
            toggle.onValueChanged.AddListener((isSelected) =>
            {
                item.active = toggle.isOn;
            });

            toggle.isOn = item.active;

            button.GetComponent<RectTransform>().SetParent(animalPanel.transform);
            button.GetComponentInChildren<Text>().text = item.name;
        }

        //set reference to static class
        StaticClass.food = food;

        //reset the offset
        offset = 0;
        //y = (int)foodPanel.GetComponent<RectTransform>().anchoredPosition[1];
        y = 450;
        //show toggle button on the screen
        foreach (var item in StaticClass.food)
        {
            GameObject button = (GameObject)Instantiate(toggleButton);
            Toggle toggle = button.GetComponent<Toggle>();
            Vector3 offsetPosition = new Vector3(foodPanel.transform.position.x, y + offset, 0);

            button.transform.position = offsetPosition;
            offset -= 45;

            button.SetActive(true);
            //set listener to detect changes
            toggle.onValueChanged.AddListener((isSelected) =>
            {
                item.active = toggle.isOn;
            });

            toggle.isOn = item.active;

            button.GetComponent<RectTransform>().SetParent(foodPanel.transform);
            button.GetComponentInChildren<Text>().text = item.name;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

}
