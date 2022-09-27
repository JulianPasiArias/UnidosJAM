using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<ObjetcToCraft> totalObjects;
    public List<string> cardsToFind;
    public ObjetcToCraft currentObjectToCraft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class ObjetcToCraft{
    public string name;
    public List<string> listComponents;
}