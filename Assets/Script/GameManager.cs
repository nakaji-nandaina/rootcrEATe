using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int GameMode = 0;
    public bool CardChanged = false;
    public bool CardRotated = false;

    public GameObject[] Card_Change=new GameObject[2];
    public GameObject Card_ReRotate;

    public GameObject TurnOverButton;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //player.LoadPlayer();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Card_ReRotate = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Change_Cards(GameObject Card,Animator anim,bool reset) {
        if (reset)
        {
            Card_Change[0] = null;
            Card_Change[1] = null;
        }
        else if (Card_Change[0] == Card)
        {
            Card_Change[0] = null;
            anim.SetBool("Selected", false);
        }
        else if (Card_Change[1] == Card)
        {
            Card_Change[1] = null;
            anim.SetBool("Selected", false);
        }
        else if (Card_Change[0] == null)
        {
            Card_Change[0] = Card;
            anim.SetBool("Selected", true);
        }
        else if(Card_Change[1]==null)
        {
            Card_Change[1] = Card;
            Card_Change[1].gameObject.GetComponent<Animator>().SetBool("Selected", true);
        }
        
        if(Card_Change[0] != null && Card_Change[1] != null)
        {
            CardChanged = true;
        }
        else
        {
            CardChanged = false;
        }
    }
    public void Set_Turn()
    {
        if (CardChanged)
        {
            Vector3 newpos0 = Card_Change[0].transform.position;
            Vector3 newpos1 = Card_Change[1].transform.position;
            Card_Change[1].gameObject.GetComponent<Animator>().SetBool("Selected", false);
            Card_Change[0].gameObject.GetComponent<Animator>().SetBool("Selected", false);
            Card_Change[1].gameObject.GetComponent<Animator>().SetBool("Moved", true);
            Card_Change[0].gameObject.GetComponent<Animator>().SetBool("Moved", true);
            Card_Change[1].transform.position = new Vector3(newpos0.x, newpos0.y, newpos0.z);
            Card_Change[0].transform.position = new Vector3(newpos1.x, newpos1.y, newpos1.z);
            Card_Change[0] = null;
            Card_Change[1] = null;
            CardChanged = false;
        }
        else if (CardRotated)
        {
            Card_ReRotate.GetComponent<Animator>().SetBool("Selected", false);
            Card_ReRotate.GetComponent<Animator>().SetBool("Moved", true);
            CardRotated = false;
            CardChanged = false;
            Card_ReRotate = null;
        }
    }
    
}
