using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Click : MonoBehaviour, IPointerClickHandler
{
    Controller controller;
    [HideInInspector] public bool clicked = true;
    [HideInInspector] public string value;


    private void Awake() => controller = GameObject.FindObjectOfType<Controller>();
    public void OnPointerClick(PointerEventData eventData)
    {
        if (clicked)
        {
            clicked = false;
            transform.GetChild(0).GetComponent<Image>().sprite = controller.GetComponent<Image>().sprite;
            transform.GetChild(0).GetComponent<Image>().DOFade(1, .2f);
            value = transform.GetChild(0).GetComponent<Image>().sprite.name;
            controller.CheckPossibilits();
        }
    }
}