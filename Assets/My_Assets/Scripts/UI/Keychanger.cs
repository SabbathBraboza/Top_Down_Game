using System;
using System.Collections;
using System.Collections.Generic;
using TDS.Object;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Keychanger : Option<string>
{
    [SerializeField] private TMP_InputField input;

    protected override void Reset()
    {
        base.Reset();

        input= GetComponent<TMP_InputField>();  
    }

    protected override void Awake()
    {
        base.Awake();
        input.onSelect.AddListener(OnExecute);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        input.onSelect.RemoveListener(OnExecute);
    }
    protected override void Initiaizle()
    {
        input.text = "Press Any Keys";

        StartCoroutine(DetectKey);
    }

    protected override void OnExecute(string value)
    {
        throw new System.NotImplementedException();
    }

    private IEnumerator DetectKey
    {
        get
        {
            yield return null;
            yield return new WaitUntil(() => Input.anyKeyDown);
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    
                    Settings.key[name] = keyCode;
                    Initiaizle();
                    EventSystem.current.SetSelectedGameObject(null);
                    break;
                }
            }
            yield break;
        }
    }

    
}

