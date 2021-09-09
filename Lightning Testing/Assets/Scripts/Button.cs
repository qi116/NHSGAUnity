using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    private Color startColor = Color.blue, hoverColor = Color.green;
    private Renderer instance;
    void Start()
    {
        instance = gameObject.GetComponent<Renderer>();
        instance.material.color = startColor;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        instance.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        instance.material.color = startColor;

    }
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Main");
    }
}
