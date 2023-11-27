using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject instruction;
    public GameObject Credit;
    public GameObject menuPanel;
    // Start is called before the first frame update
    void Start()
    {
        instruction.SetActive(false);
        Credit.SetActive(false);
        menuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void instructionButton()
    {
        menuPanel.SetActive(true);
        Credit.SetActive(false);
        instruction.SetActive(true);
    }

    public void CeditButton()
    {
        menuPanel.SetActive(true);
        instruction.SetActive(false);
        Credit.SetActive(true);
    }

    public void playButton()
    {
        SceneManager.LoadScene("Demo");
    }
}
