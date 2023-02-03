using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMove : MonoBehaviour
{
    float clicktime = 0.3f; 
    float clickcounter = 0f;
    int rotatecount = 0;
    Animator anim;
    private void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        clickcounter -= Time.deltaTime;
    }
    void OnMouseDrag()
    {
        if (GameManager.instance.GameMode == 0)
        {
            Vector3 objPos = Camera.main.WorldToScreenPoint(transform.position);

            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objPos.z);

            transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        }
    }
    public void Onclick()
    {
        if (GameManager.instance.GameMode == 0)
        {
            if (clickcounter > 0)
            {
                transform.Rotate(new Vector3(0, 0, 90));
                //Debug.LogError("‰ñ“]‚È‚¤");
            }
            else
            {
                clickcounter = clicktime;
            }
        }
        if(GameManager.instance.GameMode == 1)
        {
            if (clickcounter > 0&&!anim.GetBool("Moved")&&!GameManager.instance.CardChanged&&(GameManager.instance.Card_ReRotate==this.gameObject|| GameManager.instance.Card_ReRotate == null))
            {
                transform.Rotate(new Vector3(0, 0, 90));
                /*
                if (!anim.GetBool("Moved"))
                {
                    GameManager.instance.Change_Cards(this.gameObject, anim);
                }
                */
                //anim.SetBool("Moved", true);
                anim.SetBool("Selected",true);
                if (!GameManager.instance.CardRotated)
                {
                    GameManager.instance.CardRotated = true;
                    GameManager.instance.Change_Cards(this.gameObject, anim,true);
                    rotatecount = 0;
                    GameManager.instance.Card_ReRotate = this.gameObject;
                }
                rotatecount++;
                if (rotatecount % 4 == 0)
                {
                    anim.SetBool("Selected", false);
                    GameManager.instance.CardRotated = false;
                    GameManager.instance.Card_ReRotate = null;
                }
                Debug.LogError(rotatecount);
                Debug.LogError(GameManager.instance.CardRotated);
                //Debug.LogError("‰ñ“]‚È‚¤");
            }
            else
            {
                clickcounter = clicktime;
                if (!GameManager.instance.CardRotated&&!anim.GetBool("Moved"))
                {
                    GameManager.instance.Change_Cards(this.gameObject,anim,false);
                    
                }
                
            }
        }
    }
}
