// Created By   :   Isaac Bustad
// Created      :   6/15/2026

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace BugFreeProductions.Tools
{
    
    public class XrCharacterCanvas : MonoBehaviour
    {
        #region Vars
        // needed to check and toggel permissions for guest
        //protected NetGuestPermissionManager netUserPermission = null;

        // objects that should be enabled for the host
        [SerializeField] protected List<GameObject> itemsInUI = new List<GameObject>();

        // dedicated host UI slots
        [SerializeField] protected GameObject guestCanEditBtn = null;
        [SerializeField] protected GameObject guestCanRecordBtn = null;


        // positive and negative colors
        [SerializeField] protected Color positiveColor = Color.green;
        [SerializeField] protected Color negativeColor = Color.red;
        [SerializeField] protected Color textColor = Color.white;


        #endregion Vars

        #region Methods
        protected virtual void OnEnable()
        {
            //CollectVars();
            //Setup();
            NetGuestPermissionManager.Instance.OnPermissionsChanged += OnPermissionDataChanged;
        }

        protected virtual void CollectVars()
        {
            // collect the NetUserPermission for reference
            //netUserPermission = NetGuestPermissionManager.Instance;

        }

        public virtual void ToggleGuestCanRecord()
        {
            NetGuestPermissionManager.Instance.ToggleGuestCanRecord();
            Debug.Log("Edit Record Called");
        }

        public virtual void ToggleGuestCanEdit()
        {
            NetGuestPermissionManager.Instance.ToggleGuestCanEdit();
            Debug.Log("Edit Called");
        }

        protected virtual void OnPermissionDataChanged(NetGuestPermission netGuestPermission)
        {
            Setup();
            SetupColor(guestCanEditBtn,netGuestPermission.guestCanEdit);
            SetupColor(guestCanRecordBtn,netGuestPermission.guestCanRecord);

        }

        protected virtual void Setup()
        {
            // find if the class exist on a server
            bool isServer = NetGuestPermissionManager.Instance.isServer;

            // if true turn on the ui items for host
            // if false turn off ui items for the host
            foreach (GameObject uiItem in itemsInUI)
            {
                // make objects visible
                uiItem.SetActive(true);

                uiItem.GetComponent<Button>().enabled = isServer;
                //uiItem.SetActive(!isServer);
                //SetupColor(uiItem);
            }

            // if true turn off the ui items for guest
            // if false turn on ui items for the guest
            // foreach (GameObject uiItem in guestUI)
            // {
            //     //uiItem.SetActive(isServer);
            //     SetupColor(uiItem);
            // }





        }

        protected virtual void SetupColor(GameObject uiItem)
        {
            // set the button color
            uiItem.GetComponent<Image>().color = negativeColor;

            // set the button text color
            uiItem.GetComponentInChildren<TextMeshProUGUI>().color = textColor;

        }

        protected virtual void SetupColor(GameObject uiItem, bool permitted)
        {
            if(permitted)
            {
                // set the button color
                uiItem.GetComponent<Image>().color = positiveColor;

                // set the button text color
                uiItem.GetComponentInChildren<TextMeshProUGUI>().color = textColor;
            }

            else
            {
                // set the button color
                uiItem.GetComponent<Image>().color = negativeColor;

                // set the button text color
                uiItem.GetComponentInChildren<TextMeshProUGUI>().color = textColor;
            }


        }


        #endregion Methods
    }
}