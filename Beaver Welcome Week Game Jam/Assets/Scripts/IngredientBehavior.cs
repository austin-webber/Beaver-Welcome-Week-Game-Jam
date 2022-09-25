using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientBehavior : MonoBehaviour
{
    public Button ingredient1;
    public Button ingredient2;
    public Button ingredient3;
    public Button ingredient4;
    public Button ingredient5;
    public Button ingredient6;
    public Button ingredient7;
    public Button ingredient8;

    // Start is called before the first frame update
    void Awake()
    {
        ingredient1.onClick.AddListener(delegate { AddIngredientToInventory("ingredient1"); });
        ingredient2.onClick.AddListener(delegate { AddIngredientToInventory("ingredient2"); });
        ingredient3.onClick.AddListener(delegate { AddIngredientToInventory("ingredient3"); });
        ingredient4.onClick.AddListener(delegate { AddIngredientToInventory("ingredient4"); });
        ingredient5.onClick.AddListener(delegate { AddIngredientToInventory("ingredient5"); });
        ingredient6.onClick.AddListener(delegate { AddIngredientToInventory("ingredient6"); });
        ingredient7.onClick.AddListener(delegate { AddIngredientToInventory("ingredient7"); });
        ingredient8.onClick.AddListener(delegate { AddIngredientToInventory("ingredient8"); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddIngredientToInventory(string ingredient)
    {
        if (PlayerController.inventory.Count < 3)
        {
            PlayerController.inventory.Add(ingredient);
        }
    }
}
