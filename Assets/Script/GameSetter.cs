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
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Card");
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
        while( 0 < C)
        {
            C--;
            int r= Random.Range(0, 159) % 4;
            int a=Random.Range(0, 79)%4;
            Debug.Log(a);
            if (a == 0)
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
            else if (a == 1)
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
            else if (a == 2)
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
            else if (a == 3)
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
