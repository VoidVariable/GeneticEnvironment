using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SwitchMenus : MonoBehaviour
{
    [SerializeField]
    private GameObject menuToClose;
    [SerializeField]
    private GameObject menuToOpen;

    private void Start()
    {
        Button b = GetComponent<Button>();
        b.onClick.AddListener(() => 
        {
            menuToClose.SetActive(false);
            menuToOpen.SetActive(true);        
        });
    }

}
