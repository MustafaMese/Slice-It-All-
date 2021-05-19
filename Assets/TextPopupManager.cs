using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPopupManager : MonoBehaviour
{
    private static TextPopupManager instance;
    public static TextPopupManager Instance { get => instance; }

    [SerializeField] GameObject prefab;
    [SerializeField] int count;

    private Stack<GameObject> stack = new Stack<GameObject>();

    private void Awake() 
    {
        instance = this;    
    }

    private void Start() 
    {
        Fill(count);    
    }

    private void Fill(int count)
    {
        for (var i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            Push(obj);
        }
    }

    public void Push(GameObject obj)
    {
        if(obj != null)
        {
            obj.SetActive(false);
            stack.Push(obj);
        }
    }

    public GameObject Pop()
    {
        if(stack.Count > 0)
        {
            GameObject obj = stack.Pop();
            obj.SetActive(true);
            return obj;
        }
        else
            return Instantiate(prefab, transform);
    }

}
