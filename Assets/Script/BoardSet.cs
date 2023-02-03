using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSet : MonoBehaviour
{
    Transform[] Children;
    // Start is called before the first frame update
    void Start()
    {
        Children = GetChildren(this.gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Transform[] GetChildren(Transform parent)
    {
        // 子オブジェクトを格納する配列作成
        var children = new Transform[parent.childCount];
        var childIndex = 0;

        // 子オブジェクトを順番に配列に格納
        foreach (Transform child in parent)
        {
            children[childIndex++] = child;
        }

        // 子オブジェクトが格納された配列
        return children;
    }
    public void ResetGame()
    {
        for(int i = 0; i < Children.Length; i++)
        {
            Children[i].gameObject.GetComponent<SetCard>().SetNew();
        }
    }
    public Transform[] SetPlaces()
    {
        return Children;
    }
}
