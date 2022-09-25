using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static List<string> inventory = new List<string>();
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private float moveSpeed = 1;
    private Rigidbody2D rb;
    [SerializeField] private GameObject recipeBookIndicator;
    [SerializeField] private TextMeshProUGUI recipeBookText;
    [SerializeField] private GameObject recipeBookUI;
    private bool nearRecipeBook = false;
    [SerializeField] private GameObject pantryIndicator;
    [SerializeField] private GameObject pantryUI;
    private bool nearPantry = false;
    [SerializeField] private GameObject garbageIndicator;
    private bool nearGarbage = false;

    [SerializeField] private TextMeshProUGUI inventoryText;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        updateInventory();

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);

        if (nearRecipeBook)
        {
            if (!recipeBookUI.activeSelf && Input.GetKeyDown(KeyCode.R))
            {
                recipeBookIndicator.SetActive(false);
                recipeBookUI.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                recipeBookUI.SetActive(false);
                recipeBookIndicator.SetActive(true);
            }
        }
        if (nearPantry)
        {
            if (!pantryUI.activeSelf && Input.GetKeyDown(KeyCode.I))
            {
                Cursor.visible = true;
                pantryIndicator.SetActive(false);
                pantryUI.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                Cursor.visible = false;
                pantryUI.SetActive(false);
                pantryIndicator.SetActive(true);
            }
        }
        if (nearGarbage)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inventory = new List<string>();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("recipeBook"))
        {
            if (!recipeBookIndicator.activeSelf)
            {
                recipeBookIndicator.SetActive(true);
            }
            nearRecipeBook = true;
        }
        if (collision.gameObject.CompareTag("pantry"))
        {
            if (!pantryIndicator.activeSelf)
            {
                pantryIndicator.SetActive(true);
            }
            nearPantry = true;
        }
        if (collision.gameObject.CompareTag("garbage"))
        {
            if (!garbageIndicator.activeSelf)
            {
                garbageIndicator.SetActive(true);
            }
            nearGarbage = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("recipeBook"))
        {
            recipeBookIndicator.SetActive(false);
            nearRecipeBook = false;
        }
        if (collision.gameObject.CompareTag("pantry"))
        {
            pantryIndicator.SetActive(false);
            nearPantry = false;
        }
        if (collision.gameObject.CompareTag("garbage"))
        {
            garbageIndicator.SetActive(false);
            nearGarbage = false;
        }
    }

    private void updateInventory()
    {
        string result = "inventory: ";
        if (inventory != null)
        {
            foreach (var item in inventory)
            {
                result += item.ToString() + ", ";
            }
        }
        
        inventoryText.text = result;
    }
}
