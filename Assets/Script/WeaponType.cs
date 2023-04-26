using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class WeaponType : MonoBehaviour
{
    [SerializeField] private string weaponName;
    [SerializeField] private  List<WeaponData> weaponsList;
    [SerializeField] private Toggle selfToggle;
    [SerializeField] private TMP_Text wepaonDisplayName;
    [SerializeField] private int ToogleIndex = 0;
    public List<WeaponData> WeaponList 
    { 
     get { return weaponsList; }
    
    }

    public void AddData(WeaponData weaponData, ToggleGroup toggleGroup,string _weaponName,int _index)
    {
        this.weaponsList.Add(weaponData);
        this.weaponName = _weaponName;
        this.wepaonDisplayName.text= _weaponName;
        this.gameObject.name = _weaponName;
        this.selfToggle.group=toggleGroup;
        this.ToogleIndex = _index;
       // selfToggle.onValueChanged.AddListener(delegate { Click(this.selfToggle); });
    }
    public void Click(Toggle t)
    {
      //  print(t.gameObject.name+"  "+t.isOn);

        if (t.isOn)
        {

            Controller.SelectedWeaponIndex = 0;
            Controller.ls = weaponsList;
            for (int i = 0; i < weaponsList.Count; i++)
            {
                weaponsList[0].selfToogle.isOn = true;
                weaponsList[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < weaponsList.Count; i++)
            {
                weaponsList[i].gameObject.SetActive(false);
                weaponsList[i].selfToogle.isOn = false;
            }
        }
       // print("WEPAOIN TYPE " + t.isOn);

    }




    
}
