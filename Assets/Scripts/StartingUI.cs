using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartingUI : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;
    private Button start;

    // Start is called before the first frame update
    void Start()
    {
        //The Start Button
        start = GetComponent<Button>();
        start.onClick.AddListener(Begin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Begin()
    {
        Debug.Log(start.gameObject.name + " was clicked");
        startScreen.gameObject.SetActive(false);
    }
}
