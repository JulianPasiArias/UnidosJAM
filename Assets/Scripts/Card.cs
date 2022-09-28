using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    public string nameCard;
    public Image imageCarta,imageCartaBack;
    private void Start()
    {
    }
    public void generateCard(string name, Sprite sprite)
    {
        nameCard = name;
        imageCarta.sprite = sprite;
        imageCartaBack.sprite = sprite;
    }
}
