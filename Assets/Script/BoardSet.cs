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
        // �q�I�u�W�F�N�g���i�[����z��쐬
        var children = new Transform[parent.childCount];
        var childIndex = 0;

        // �q�I�u�W�F�N�g�����Ԃɔz��Ɋi�[
        foreach (Transform child in parent)
        {
            children[childIndex++] = child;
        }

        // �q�I�u�W�F�N�g���i�[���ꂽ�z��
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
