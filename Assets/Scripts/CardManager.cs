using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public enum statesGame
{
    inGame,gameOver
}
public class CardManager : MonoBehaviour
{
    public List<Transform> listPositionsCards;
    public List<Sprite> listCartas;
    public List<Image> listMyLoteriaTable;
    public List<Card> myLoteriaTable;
    public List<Card> currentLoteriaTable;
    public GameObject cardPrefab;
    public static CardManager ManagerCardInstance;
    public GameObject CanvasGameOver, CanvasWin,CanvasError;
    //
    public TextMeshProUGUI regresiveCount;
    public float timeLeft = 3.0f;
    public float timeGame = 60.0f;
    public statesGame currentGameState = statesGame.inGame;
    // Start is called before the first frame update

    IEnumerator showCanvas(GameObject canvas)
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(2);
        canvas.SetActive(false);
    }
    IEnumerator gameOver()
    {
        currentGameState = statesGame.gameOver;
        yield return new WaitForSeconds(1);
        currentGameState = statesGame.inGame;
    }
    public void showError()
    {
        StartCoroutine(showCanvas(CanvasError));
    }
    public void showWin()
    {
        StartCoroutine(showCanvas(CanvasWin));
        StartCoroutine(gameOver());
    }
    public void showGameOver()
    {
        StartCoroutine(showCanvas(CanvasGameOver));
        StartCoroutine(gameOver());
    }
    void Start()
    {
        ManagerCardInstance = this;
        iniciarJuego();
    }
    public void iniciarJuego()
    {
        playLoteria();
        generateLoteriaTableCards();
        generateRandomCardsSinRepetir();
    }
    public void addTime()
    {
        timeGame += 15;
    }
    public void removeTime()
    {
        timeGame -= 5;
    }
    public void goTimer()
    {
        if (currentGameState == statesGame.inGame)
        {

            timeGame -= Time.deltaTime;
            regresiveCount.text = (timeGame).ToString("0");
            if (timeGame <= 0)
            {
                regresiveCount.enabled = false;
                showGameOver();
            }
        }
    }
    public void playLoteria()
    {
        regresiveCount.enabled = true;
        timeGame = 60.0f;
        goTimer();
    }
    public void generateRandomCardsSinRepetir()
    {
        for (int i = 6; i <= 11; i++)
        {
            int randomN = Random.Range(0, listCartas.Count);
            string actualNameCard = listCartas[randomN].name;

            if (myLoteriaTable.Find(w => string.Equals(w.nameCard, actualNameCard)))
            {
                print("Ya se Spawneo esta");
            }
            else
            {
                var cardT = Instantiate(cardPrefab,listPositionsCards[i]);
                //
                cardT.GetComponent<Card>().nameCard = listCartas[randomN].name;
                cardT.GetComponent<Card>().imageCarta.sprite = listCartas[randomN];
                cardT.GetComponent<Card>().imageCartaBack.sprite = listCartas[randomN];
            }
        }
    }
    public void generateLoteriaTableCards()
    {
        for (int i = 0; i <= 5; i++)
        {
            int randomN = Random.Range(0,listCartas.Count);
            string actualNameCard = listCartas[randomN].name;

            if (myLoteriaTable.Find(w => string.Equals(w.nameCard, actualNameCard))) {
                print("se encontro ya");
            }
            else
            {
                var cardT = Instantiate(cardPrefab,listPositionsCards[i]);
                //
                cardT.GetComponent<Card>().nameCard = listCartas[randomN].name;
                cardT.GetComponent<Card>().imageCarta.sprite = listCartas[randomN];
                cardT.GetComponent<Card>().imageCartaBack.sprite = listCartas[randomN];
                //
                myLoteriaTable.Add(cardT.GetComponent<Card>());
                listMyLoteriaTable[i].sprite = listCartas[randomN];
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        goTimer();
    }
}