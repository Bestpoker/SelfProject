using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LearnCharacter : MonoBehaviour
{
    public GameObject fruitPrefab;

    private Sprite[] _sprites;

    public Transform content;

    private string[] cnNames = new string[] { "火龙果", "榴莲", "葡萄", "哈密瓜", "芒果"};

    private string[] enNames = new string[] { "Dragon fruit", "Durian", "Grape", "Hamimelon", "Mango" };

    public Button fruitBtn;

    public Button backMainSceneBtn;

    public Button showBackBtn;

    public GameObject menuGO;

    public GameObject showGO;

    public ScrollRect scrollRect;

    public UICenterOnChild center;

    private void Awake()
    {
        fruitBtn.onClick.AddListener(delegate () {
            this.OnClickFruitBtn();
        });

        backMainSceneBtn.onClick.AddListener(delegate () {
            this.OnClickBackMainSceneBtn();
        });

        showBackBtn.onClick.AddListener(delegate () {
            this.OnClickShowBackBtn();
        });

        menuGO.SetActive(true);

        showGO.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        _sprites = new Sprite[5];
        for (int i = 0; i < 5; i++)
        {
            var tex = Resources.Load("Fruit/Fruit_" + i) as Texture2D;
            _sprites[i] = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            var item = GameObject.Instantiate(fruitPrefab).GetComponent<FruitItem>();
            item.fruitImage.sprite = _sprites[i];
            item.cnNameText.text = cnNames[i];
            item.enNameText.text = enNames[i];
            item.gameObject.SetActive(true);
            item.transform.SetParent(content);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClickBackMainSceneBtn()
    {
        SceneManager.LoadScene("MainScene");
    }

    void OnClickShowBackBtn()
    {
        showGO.SetActive(false);
        menuGO.SetActive(true);

    }

    void OnClickFruitBtn()
    {
        showGO.SetActive(true);
        menuGO.SetActive(false);
        content.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        center.SetCurrentPageIndex(0);
    }
}
