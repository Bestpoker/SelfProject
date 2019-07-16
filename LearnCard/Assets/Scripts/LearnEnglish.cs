using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LearnEnglish : MonoBehaviour
{

    public Canvas canvas;

    public RectTransform planeParent;

    public Button streetBtn;

    public Button backMainSceneBtn;

    public Button showBackBtn;

    public GameObject menuGO;

    public GameObject showGO;

    public RectTransform plane;

    public GameObject plane_shaodow;

    public GraphicRaycaster RaycastInCanvas;

    public EventSystem eventSystem;

    List<RaycastResult> list = new List<RaycastResult>();

    private Transform choseingGO;

    private Vector3 planeStartPos;

    private Vector2 planeStartDis;

    private void Awake()
    {
        streetBtn.onClick.AddListener(delegate () {
            this.OnClickSteetBtn();
        });

        backMainSceneBtn.onClick.AddListener(delegate () {
            this.OnClickBackMainSceneBtn();
        });

        showBackBtn.onClick.AddListener(delegate () {
            this.OnClickShowBackBtn();
        });

        menuGO.SetActive(true);

        showGO.SetActive(false);

        plane.localScale = new Vector3(0.8f, 0.8f, 1);
        planeStartPos = plane.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (choseingGO != null)
        {
            Vector2 pos;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(planeParent, Input.mousePosition, canvas.worldCamera, out pos))
            {
                plane.anchoredPosition = pos + planeStartDis;
            }
        }
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

    void OnClickSteetBtn()
    {
        showGO.SetActive(true);
        menuGO.SetActive(false);

        plane.localScale = new Vector3(0.8f, 0.8f, 1);
        plane.transform.position = planeStartPos;
        plane.GetComponent<Image>().raycastTarget = true;
    }

    public void OnPointDownPlane()
    {
        plane.localScale = Vector3.one;
        choseingGO = plane.transform;
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(planeParent, Input.mousePosition, canvas.worldCamera, out pos))
        {
            planeStartDis = plane.anchoredPosition - pos;
        }
    }

    public void OnPointUpPlane()
    {

        choseingGO = null;

        if (plane != null)
        {
            PointerEventData eventData = new PointerEventData(eventSystem);
            eventData.pressPosition = Input.mousePosition;
            eventData.position = Input.mousePosition;
            list.Clear();
            RaycastInCanvas.Raycast(eventData, list);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].gameObject.name  == "PlaneShadowCollider")
                {
                    plane.transform.position = list[i].gameObject.transform.position;
                    plane.GetComponent<Image>().raycastTarget = false;
                    return;
                }
            }

        }
        
        plane.localScale = new Vector3(0.8f, 0.8f, 1);
        plane.transform.position = planeStartPos;


    }

}
