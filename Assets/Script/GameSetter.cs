using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetter : MonoBehaviour
{
    [SerializeField]
    private int Card_Carb, Card_Cross, Card_Straight, Card_Stop;
    [SerializeField]
    private GameObject Cardcarb, Cardcross, Cardstraight, Cardstop;
    private int Cards;
    [SerializeField]
    private GameObject DeckP;
    private Vector3 Deck_point;
    [SerializeField]
    private float H_Dis=0.5f;
    [SerializeField]
    private float H=0.5f;
    [SerializeField]
    private GameObject[] DefaltPos;
    [SerializeField]
    private GameObject Board;
    // Start is called before the first frame update
    void Start()
    {

        Deck_point = DeckP.transform.position;
        Cards= Card_Carb+Card_Cross+Card_Straight+ Card_Stop;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Makedeck()
    {
        GameManager.instance.TurnOverButton.SetActive(false);
        GameManager.instance.GameMode = 0;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Card");
        Board.GetComponent<BoardSet>().ResetGame();
        for(int i=0; i < objs.Length; i++)
        {
            Destroy(objs[i]);
        }
        for(int i=0; i < DefaltPos.Length; i++)
        {
            Vector3 defpos=DefaltPos[i].transform.position;
            Instantiate(Cardcross, defpos, Quaternion.identity);
        }

        int CCb = Card_Carb;
        int CCs = Card_Cross;
        int CSt = Card_Straight;
        int CSp = Card_Stop;
        int C = Cards;

        float Hi = H;
        float HD = H_Dis;
        Debug.Log("MakeDeck");
        int t = 0;
        GameObject before = null;
        GameObject bebefore = null;
        while ( 0 < C)
        {
            C--;
            t++;
            int r= Random.Range(0, 159) % 4;
            int a=Random.Range(0, 300)% (Card_Cross + Card_Carb + Card_Stop + Card_Straight);
            
            Debug.Log(a);
            if (a < Card_Carb)
            {
                
                if (CCb != 0)
                {
                    CCb--;
                    Vector3 pos = new Vector3(Deck_point.x, Deck_point.y, Deck_point.z + Hi);
                    Instantiate(Cardcarb, pos, Quaternion.Euler(0, 0, 90 * r));
                    Hi += HD;
                }
                else
                {
                    C++;
                }
            }
            else if (a >= Card_Carb&&a<Card_Carb+Card_Cross)
            {
                if (CCs != 0)
                {
                    CCs--;
                    Vector3 pos = new Vector3(Deck_point.x, Deck_point.y, Deck_point.z + Hi);
                    Instantiate(Cardcross, pos, Quaternion.Euler(0, 0, 90 * r));
                    Hi += HD;
                }
                else
                {
                    C++;
                }
            }
            else if (a >= Card_Carb + Card_Cross&&a< Card_Carb + Card_Cross+Card_Straight)
            {
                if (CSt != 0)
                {
                    CSt--;
                    Vector3 pos = new Vector3(Deck_point.x, Deck_point.y, Deck_point.z + Hi);
                    Instantiate(Cardstraight, pos, Quaternion.Euler(0, 0, 90 * r));
                    Hi += HD;
                }
                else
                {
                    C++;
                }
            }
            else if (a >= Card_Carb + Card_Cross + Card_Straight)
            {
                if (CSp != 0)
                {
                    CSp--;
                    Vector3 pos = new Vector3(Deck_point.x, Deck_point.y, Deck_point.z + Hi);
                    Instantiate(Cardstop, pos, Quaternion.Euler(0, 0, 90 * r));
                    Hi += HD;
                }
                else
                {
                    C++;
                }
            }
            bebefore = before;
        }


    }
    public void Makefield()
    {
        GameManager.instance.GameMode = 1;
        GameManager.instance.CardChanged = false;
        GameManager.instance.CardRotated = false;
        GameManager.instance.TurnOverButton.SetActive(true);
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Card");
        Board.GetComponent<BoardSet>().ResetGame();
        for (int i = 0; i < objs.Length; i++)
        {
            Destroy(objs[i]);
        }
        for (int i = 0; i < DefaltPos.Length; i++)
        {
            Vector3 defpos = DefaltPos[i].transform.position;
            Instantiate(Cardcross, defpos, Quaternion.identity);
        }
        Transform[] Card_points = Board.GetComponent<BoardSet>().SetPlaces();
        int CCb = Card_Carb;
        int CCs = Card_Cross;
        int CSt = Card_Straight;
        int CSp = Card_Stop;
        int C = 63;
        Debug.Log("MakeDeck");
        while (0 < C)
        {
            C--;
            int r = Random.Range(0, 159) % 4;
            int a = Random.Range(0, 300)  % (Card_Cross+Card_Carb+Card_Stop+Card_Straight);
            Vector3 Card_point = Card_points[C].gameObject.transform.position;
            Debug.Log(a);
            if (C == 0 || C == 7 || C == 56 || C == 63)
            {

            }
            else if (a < Card_Carb)
            {
                if (CCb != 0)
                {
                    CCb--;
                    Vector3 pos = new Vector3(Card_point.x, Card_point.y, Card_point.z);
                    Instantiate(Cardcarb, pos, Quaternion.Euler(0, 0, 90 * r));
                    
                }
                else
                {
                    C++;
                }
            }
            else if (a >= Card_Carb && a < Card_Carb + Card_Cross)
            {
                if (CCs != 0)
                {
                    CCs--;
                    Vector3 pos = new Vector3(Card_point.x, Card_point.y, Card_point.z);
                    Instantiate(Cardcross, pos, Quaternion.Euler(0, 0, 90 * r));
                    
                }
                else
                {
                    C++;
                }
            }
            else if (a >= Card_Carb + Card_Cross && a < Card_Carb + Card_Cross + Card_Straight)
            {
                if (CSt != 0)
                {
                    CSt--;
                    Vector3 pos = new Vector3(Card_point.x, Card_point.y, Card_point.z);
                    Instantiate(Cardstraight, pos, Quaternion.Euler(0, 0, 90 * r));
                    
                }
                else
                {
                    C++;
                }
            }
            else if (a >= Card_Carb + Card_Cross + Card_Straight)
            {
                if (CSp != 0)
                {
                    CSp--;
                    Vector3 pos = new Vector3(Card_point.x, Card_point.y, Card_point.z);
                    Instantiate(Cardstop, pos, Quaternion.Euler(0, 0, 90 * r));
                }
                else
                {
                    C++;
                }
            }
        }
    }
    public void MakeDeckOneRoot()
    {
        GameManager.instance.TurnOverButton.SetActive(false);
        GameManager.instance.GameMode = 0;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Card");
        Board.GetComponent<BoardSet>().ResetGame();
        for (int i = 0; i < objs.Length; i++)
        {
            Destroy(objs[i]);
        }
        for (int i = 0; i < DefaltPos.Length; i++)
        {
            Vector3 defpos = DefaltPos[i].transform.position;
            Instantiate(Cardcross, defpos, Quaternion.identity);
        }

        int CCb = Card_Carb;
        int CCs = Card_Cross;
        int CSt = Card_Straight;
        int CSp = Card_Stop;
        int C = Cards;

        float Hi = H;
        float HD = H_Dis;
        Debug.Log("MakeDeck");
        int t = 0;
        while (0 < C)
        {
            C--;
            t++;
            int r = Random.Range(0, 159) % 4;
            int a = Random.Range(0, 300) % (Card_Cross + Card_Carb + Card_Stop + Card_Straight);
            Debug.Log(a);
            if (a < Card_Carb)
            {
                if (CCb != 0)
                {
                    CCb--;
                    Vector3 pos = new Vector3(Deck_point.x, Deck_point.y, Deck_point.z + Hi);
                    Instantiate(Cardcarb, pos, Quaternion.Euler(0, 0, 90 * r));
                    Hi += HD;
                }
                else
                {
                    C++;
                }
            }
            else if (a >= Card_Carb && a < Card_Carb + Card_Cross)
            {
                if (CCs != 0)
                {
                    CCs--;
                    Vector3 pos = new Vector3(Deck_point.x, Deck_point.y, Deck_point.z + Hi);
                    Instantiate(Cardcross, pos, Quaternion.Euler(0, 0, 90 * r));
                    Hi += HD;
                }
                else
                {
                    C++;
                }
            }
            else if (a >= Card_Carb + Card_Cross && a < Card_Carb + Card_Cross + Card_Straight)
            {
                if (CSt != 0)
                {
                    CSt--;
                    Vector3 pos = new Vector3(Deck_point.x, Deck_point.y, Deck_point.z + Hi);
                    Instantiate(Cardstraight, pos, Quaternion.Euler(0, 0, 90 * r));
                    Hi += HD;
                }
                else
                {
                    C++;
                }
            }
            else if (a >= Card_Carb + Card_Cross + Card_Straight)
            {
                if (CSp != 0)
                {
                    CSp--;
                    Vector3 pos = new Vector3(Deck_point.x, Deck_point.y, Deck_point.z + Hi);
                    Instantiate(Cardstop, pos, Quaternion.Euler(0, 0, 90 * r));
                    Hi += HD;
                }
                else
                {
                    C++;
                }
            }
        }
    }
}
