// Created By   :   Isaac Busatd
// Created      :   6/16/2026

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BugFreeProductions.Tools
{
    [System.Serializable]
    public struct NetGuestPermission
    {
        public bool guestCanEdit;
        public bool guestCanRecord;
        public bool guestCanPermit;
        public bool guestCanSave;



        public NetGuestPermission(bool aGuestCanEdit, bool aGuestCanRecord, bool aGuestCanPermit, bool aGuestCanSave)
        {
            guestCanEdit = aGuestCanEdit;
            guestCanRecord = aGuestCanRecord;
            guestCanPermit = aGuestCanPermit;
            guestCanSave = aGuestCanSave;

        }

        
    }
}