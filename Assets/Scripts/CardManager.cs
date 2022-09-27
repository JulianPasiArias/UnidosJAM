using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<Sprite> listCartas;
    public List<Card> myLoteriaTable;
    public List<Card> currentLoteriaTable;
    public GameObject cardPrefab;
    public static CardManager ManagerCardInstance;
    // Start is called before the first frame update


    void Start()
    {
        ManagerCardInstance = this;
    }
    public void generateLoteriaTable()
    {
        int randomN = Random.Range(0,listCartas.Count);
        string actualNameCard = listCartas[randomN].name;
        //if (myLoteriaTable.Contains()){

        //}
    }
    public void serchForMySprite(string nameSprite)
    {
        for (int i = 0; i < CardManager.ManagerCardInstance.listCartas.Count; i++)
        {
            if (CardManager.ManagerCardInstance.listCartas[i].name == nameSprite)
            {
                //imageCarta.sprite = CardManager.ManagerCardInstance.listCartas[i];
                //imageCartaBack.sprite = CardManager.ManagerCardInstance.listCartas[i];
            }
            else
            {
                print("no se encontro ningun elemento con ese name");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}