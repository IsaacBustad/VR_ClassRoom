// Isaac Bustad
// 11/6/2024


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;


namespace BugFreeProductions.Tools
{
    public class ObjectPlacementReadWrite
    {
        protected string placementPath = "/ObjectPlacements.json";
        //protected string monstFilterName = "BtlShpTurt";
        //public MonsterStatList statList = new MonsterStatList();

        // singal instance
        private static ObjectPlacementReadWrite instance;






        public List<ObjectPlacement> ReadObjectPlacements()
        {
            return JsonUtility.FromJson<ObjectPlacementList>(CustomGatewayJSON.Instance.ReadJsonFile(placementPath)).objectPlacements.ToList();
        }

        public ObjectPlacement FindObjectPlacement(string aID)
        {
            ObjectPlacementList objLST = JsonUtility.FromJson<ObjectPlacementList>(CustomGatewayJSON.Instance.ReadJsonFile(placementPath));

            foreach (ObjectPlacement op in objLST.objectPlacements)
            {
                if (op.id == aID)
                {
                    return op;
                }
            }
            return null;
        }

        public void WriteObjectPlacements(ObjectPlacementList aPlacementLst)
        {
            string JSONstr = JsonUtility.ToJson(aPlacementLst);

            CustomGatewayJSON.Instance.WriteJsonFile(placementPath, JSONstr);
        }

        // Constructors
        private ObjectPlacementReadWrite() { }


        // Accessors
        public static ObjectPlacementReadWrite Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjectPlacementReadWrite();
                }
                return instance;
            }
        }
    }
}