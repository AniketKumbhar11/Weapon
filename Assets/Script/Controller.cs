using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    public static Action<SpawnManagerScriptableObject> DisplayWeaponData;


    

    // Start is called before the first frame update
    public List<SpawnManagerScriptableObject>Weapons;
    [Space]
    [Header("======  PROFILE DATA =========")]
    [Space]
    public ProfileCreate profileCreate;

    [Space]
    [Header("======  TMP TEXT =========")]
    [Space]

    [SerializeField] private TMP_Text ProfileName;
    [SerializeField] private TMP_Text CoinText;
    [SerializeField] private TMP_Text BalanceTxt;
    [SerializeField] private TMP_Text WeaponInfoText;
    [SerializeField] private TMP_Text WeaponNameText;


    [Space]
    [Header("======  IMAGES =========")]
    [Space]

    [SerializeField] private Image ProfileImagel;
    [SerializeField] private Image WeaponWeightImage;
    [SerializeField] private Image WeaponAccuracyImage;
    [SerializeField] private Image WeaponRangeImage;
    [SerializeField] private Image WeaponDamageImage;
    [SerializeField] private Image WeaponFirerateImage;
    [SerializeField] private Image WeaponImage;
    [SerializeField] private Image WeaponWiredImage;

    [Space]
    [Header("======  GAMEOBJECTS =========")]
    [Space]


    [SerializeField] private GameObject _pWeaponType;
    [SerializeField] private GameObject _pWeapon;
    [SerializeField] private GameObject _containerWeaponType;
    [SerializeField] private GameObject _containerWeapon;
    [SerializeField] private GameObject WeaponSpawnPoint;





    [SerializeField] private int CurrentWeaponStateIndex = 0;
    [SerializeField] private static int ActiveWeaponIndex= 0;
     public static int SelectedWeaponIndex = 0;
    private ToggleGroup _weaponToggleGroup, _weaponTypeToggleGroup;
    public static List<WeaponData> ls;




    private void OnEnable()
    {
        DisplayWeaponData += displayWeaponData;
    }
    private void OnDisable()
    {
        DisplayWeaponData -= displayWeaponData;
    }


    private void displayWeaponData(SpawnManagerScriptableObject Object)
    {

        if(WeaponSpawnPoint.transform.childCount>0)
            Destroy(WeaponSpawnPoint.transform.GetChild(0).gameObject);

        Instantiate(Object.WeaponPrefab,WeaponSpawnPoint.transform);
        WeaponInfoText.text = "This is " + Object.WeaponName;
        WeaponNameText.text = Object.WeaponName;
        WeaponWiredImage.sprite = Object.WireWeaponImage;
        int totalactiveCount=0;
        for (totalactiveCount = 0; totalactiveCount < 10; totalactiveCount++)
        {
            if(totalactiveCount<=Object.Weigth)
            {
                WeaponWeightImage.transform.GetChild(totalactiveCount).gameObject.SetActive(true);
            }else
            {
                WeaponWeightImage.transform.GetChild(totalactiveCount).gameObject.SetActive(false);
            }
            if (totalactiveCount <= Object.Accuracy)
            {
                WeaponAccuracyImage.transform.GetChild(totalactiveCount).gameObject.SetActive(true);
            }
            else
            {
                WeaponAccuracyImage.transform.GetChild(totalactiveCount).gameObject.SetActive(false);
            }
            if (totalactiveCount <= Object.Damage)
            {
                WeaponDamageImage.transform.GetChild(totalactiveCount).gameObject.SetActive(true);
            }
            else
            {
                WeaponDamageImage.transform.GetChild(totalactiveCount).gameObject.SetActive(false);
            }

            if (totalactiveCount <= Object.Range)
            {
                WeaponRangeImage.transform.GetChild(totalactiveCount).gameObject.SetActive(true);
            }
            else
            {
                WeaponRangeImage.transform.GetChild(totalactiveCount).gameObject.SetActive(false);
            }
            if (totalactiveCount <= Object.FireRate)
            {
                WeaponFirerateImage.transform.GetChild(totalactiveCount).gameObject.SetActive(true);
            }
            else
            {
                WeaponFirerateImage.transform.GetChild(totalactiveCount).gameObject.SetActive(false);
            }
        }

    }

    void Start()
    {
        _weaponToggleGroup=_containerWeapon.GetComponent<ToggleGroup>();
        _weaponTypeToggleGroup = _containerWeaponType.GetComponent<ToggleGroup>();
        
        if(profileCreate!=null)
        {
            CoinText.text= profileCreate.Coin.ToString();
           BalanceTxt.text= profileCreate.Money.ToString();
           ProfileImagel.sprite = profileCreate.ProfileImage;
           ProfileName.text= profileCreate.ProfileName;



        }





        var myEnumMemberCount = Enum.GetNames(typeof(SpawnManagerScriptableObject._weaponType)).Length;
            for (int i = 0; i < myEnumMemberCount; i++)
            {
                GameObject obj = Instantiate(_pWeaponType);
                obj.transform.SetParent(_containerWeaponType.transform,false);     
                CurrentWeaponStateIndex = i;
                foreach (var item in SpwanList())
                {
                    print(item.WeaponName+"  "+i);
                    GameObject TempObj = Instantiate(_pWeapon);
                    TempObj.transform.SetParent(_containerWeapon.transform, false);
                    TempObj.GetComponent<WeaponData>().OnInit(item, i,_weaponToggleGroup);
                    obj.GetComponent<WeaponType>().AddData(TempObj.GetComponent<WeaponData>(), _weaponTypeToggleGroup, (Enum.GetName(typeof(SpawnManagerScriptableObject._weaponType), i)),i);
                }

            }


    }

    IEnumerable<SpawnManagerScriptableObject> SpwanList()
    {
        foreach (var item in Weapons)
        {
            if ((int)item.WeaponType == CurrentWeaponStateIndex)
            {
                yield return item;  

            }
        }
    }




    public void Up()
    {

        for (int i = 0; i < ls.Count; i++)
        {
            if (ls[i].selfToogle.isOn && (SelectedWeaponIndex >0))
            {
                SelectedWeaponIndex = i;
                SelectedWeaponIndex--;
                ls[SelectedWeaponIndex].selfToogle.isOn = true;
                // ls[i].selfToogle.isOn=false;
                break;
            }
        }




    }
    public void Down()
    {
        for (int i = 0; i < ls.Count; i++)
        {
            if (ls[i].selfToogle.isOn &&(SelectedWeaponIndex<(ls.Count-1)))
            {
                SelectedWeaponIndex = i;
                SelectedWeaponIndex++;
                ls[SelectedWeaponIndex].selfToogle.isOn = true;
              // ls[i].selfToogle.isOn=false;
                break;
            }
        }
    }






}
