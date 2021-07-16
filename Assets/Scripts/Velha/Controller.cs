using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] Transform localInstant;
    [SerializeField] GameObject prefabClick;
    [SerializeField] Sprite[] sprites;
    Click[] possible0, possible1, possible2, possible3, possible4, possible5, possible6, possible7;
    Click[,] array = new Click[3, 3];
    bool[] bollPoss = new bool[8];
    bool point = false;
    int cont = 0;


    void Start()
    {
        bollPoss = new bool[8];
        SetPossibles();
        Initi();
    }
    void SetPossibles()
    {
        possible0 = new Click[3] { array[0, 0], array[0, 1], array[0, 2] };
        possible1 = new Click[3] { array[1, 0], array[1, 1], array[1, 2] };
        possible2 = new Click[3] { array[2, 0], array[2, 1], array[2, 2] };
        possible3 = new Click[3] { array[0, 0], array[1, 0], array[2, 0] };
        possible4 = new Click[3] { array[0, 1], array[1, 1], array[2, 1] };
        possible5 = new Click[3] { array[0, 2], array[1, 2], array[2, 2] };
        possible6 = new Click[3] { array[0, 0], array[1, 1], array[2, 2] };
        possible7 = new Click[3] { array[0, 2], array[1, 1], array[2, 0] };
    }
    void Initi() => InstantClicks();
    void InstantClicks()
    {
        for (var j = 0; j < 3; j++)
            for (var k = 0; k < 3; k++)
            {
                array[j, k] = Instantiate(prefabClick, localInstant).GetComponent<Click>();
                array[j, k].transform.localPosition = new Vector3(j * 300, k * 300);
                GameObject game = new GameObject("new");
                game.transform.SetParent(array[j, k].transform);
                game.transform.localPosition = Vector3.zero;
                game.transform.localScale = Vector3.one;
                game.AddComponent(typeof(Image));
                game.GetComponent<Image>().DOFade(0, 0);
            }
    }
    public void CheckPossibilits()
    {
        cont++;
        GetComponent<Image>().sprite = GetComponent<Image>().sprite == sprites[0] ? sprites[1] : sprites[0];
        Possibilits();

        Click[] cl = bollPoss[0] ? possible0 : bollPoss[1] ? possible1 : bollPoss[2] ? possible2 : bollPoss[3] ? possible3 : bollPoss[4] ? possible4 : bollPoss[5] ? possible5 : bollPoss[6] ? possible6 : possible7;
        for (var i = 0; i < bollPoss.Length; i++)
            if (bollPoss[i])
                PaintValidate(cl);

        DOVirtual.DelayedCall(.3f, () =>
        {
            if (cont == 9 && !point)
                Debug.Log("VELHA");
        });

    }
    void PaintValidate(Click[] click)
    {
        point = true;
        foreach (var item in GameObject.FindObjectsOfType<Click>())
            item.clicked = false;
        foreach (var item in click)
            item.GetComponent<Image>().color = Color.green;
    }
    void Possibilits()
    {
        bollPoss[0] = ((array[0, 0].value == "x" && array[0, 1].value == "x" && array[0, 2].value == "x")
                || (array[0, 0].value == "o" && array[0, 1].value == "o" && array[0, 2].value == "o"));

        bollPoss[1] = ((array[1, 0].value == "x" && array[1, 1].value == "x" && array[1, 2].value == "x")
        || (array[1, 0].value == "o" && array[1, 1].value == "o" && array[1, 2].value == "o"));

        bollPoss[2] = ((array[2, 0].value == "x" && array[2, 1].value == "x" && array[2, 2].value == "x")
        || (array[2, 0].value == "o" && array[2, 1].value == "o" && array[2, 2].value == "o"));

        bollPoss[3] = ((array[0, 0].value == "x" && array[1, 0].value == "x" && array[2, 0].value == "x")
        || (array[0, 0].value == "o" && array[1, 0].value == "o" && array[2, 0].value == "o"));

        bollPoss[4] = ((array[0, 1].value == "x" && array[1, 1].value == "x" && array[2, 1].value == "x")
        || (array[0, 1].value == "o" && array[1, 1].value == "o" && array[2, 1].value == "o"));

        bollPoss[5] = ((array[0, 2].value == "x" && array[1, 2].value == "x" && array[2, 2].value == "x")
        || (array[0, 2].value == "o" && array[1, 2].value == "o" && array[2, 2].value == "o"));

        bollPoss[6] = ((array[0, 0].value == "x" && array[1, 1].value == "x" && array[2, 2].value == "x")
        || (array[0, 0].value == "o" && array[1, 1].value == "o" && array[2, 2].value == "o"));

        bollPoss[7] = ((array[0, 2].value == "x" && array[1, 1].value == "x" && array[2, 0].value == "x")
        || (array[0, 2].value == "o" && array[1, 1].value == "o" && array[2, 0].value == "o"));
    }
}