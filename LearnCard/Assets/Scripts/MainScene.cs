using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    public Button learnCharacterBtn;

    public Button learnEnglishBtn;

    private void Awake()
    {
        learnCharacterBtn.onClick.AddListener(delegate () {
            this.OnClickLearnCharacterBtn();
        });

        learnEnglishBtn.onClick.AddListener(delegate () {
            this.OnClickLearnEnglishBtn();
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClickLearnCharacterBtn()
    {
        SceneManager.LoadScene("LearnCharacterScene");
    }

    void OnClickLearnEnglishBtn()
    {
        SceneManager.LoadScene("LearnEnglishScene");
    }

}
