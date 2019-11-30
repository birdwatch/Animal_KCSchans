using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Giver : MonoBehaviour
{
    [SerializeField]
    private Selecter selecter1;

    [SerializeField]
    private Selecter selecter2;

    [SerializeField]
    private LoadingScene ls;

    [SerializeField]
    private List<Camera> cameras;

    public GameObject[] players = new GameObject[2];

    [SerializeField]
    private List<GameObject> list;

    static Giver instance;
    public static Giver Instance { get { return instance; } }

    private int t = 0;

    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Title") Destroy(gameObject);
        if (SceneManager.GetActiveScene().name == "Battle") return;

        if (selecter1.unit >= 0) players[0] = list[selecter1.unit];
        if (selecter2.unit >= 0) players[1] = list[selecter2.unit];

        if (selecter1.unit >= 0 && selecter2.unit >= 0 && t == 0)
        {
            cameras[0].gameObject.SetActive(false);
            cameras[1].gameObject.SetActive(false);
            cameras[2].gameObject.SetActive(true);
            ls.LoadNextScene();
            t = 1;
        }

    }

    public GameObject GetPlayer(int Num)
    {
        return players[Num];
    }
}
