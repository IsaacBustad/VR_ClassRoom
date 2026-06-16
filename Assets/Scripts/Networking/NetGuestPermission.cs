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


        
        public NetGuestPermission(bool aGuestCanEdit, bool aGuestCanRecord)
        {
            guestCanEdit = aGuestCanEdit;
            guestCanRecord = aGuestCanRecord;
        }
    }
}