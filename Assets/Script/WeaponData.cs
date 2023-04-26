using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AI;

public class WeaponData : MonoBehaviour
{
    [SerializeField] private Image weaponIcon;
    [SerializeField] private TMP_Text weaponName;
    [SerializeField]private SpawnManagerScriptableObject spawnManagerScript;
    [SerializeField] private int selfIndex;
     public Toggle selfToogle;
    public void OnInit(SpawnManagerScriptableObject _spawnManagerScriptableObject,int _selfindex,ToggleGroup toggleGroup)
    {


        this.spawnManagerScript = _spawnManagerScriptableObject;
        this.weaponIcon.sprite = spawnManagerScript.SpriteIcon;
        this.weaponName.text = spawnManagerScript.WeaponName;
        this.gameObject.name= spawnManagerScript.WeaponName;
        this.selfIndex = _selfindex;
        this.selfToogle.group = toggleGroup;
     //   this.selfToogle.onValueChanged.AddListener(delegate { Click(this.selfToogle); });
        this.gameObject.SetActive(false);

    }
    public void Click(Toggle t)
    {
        if (t.isOn)
        {
            //Controller.SelectedWeaponIndex = 0;
            Controller.DisplayWeaponData?.Invoke(spawnManagerScript);
        }
    }


}
