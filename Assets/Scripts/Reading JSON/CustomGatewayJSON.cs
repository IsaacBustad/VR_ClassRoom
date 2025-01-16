// Isaac Busatd
// 11/6/2024

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace BugFreeProductions.Tools
{
    public class CustomGatewayJSON
    {
        // Vars
        //[SerializeField] private TextAsset skillFile;
        private static CustomGatewayJSON instance;



        // Methods
        public string ReadJsonFile(string aPath)
        {
            StreamReader streamReader = new StreamReader(Application.persistentDataPath + aPath);
            string jsonTxt = streamReader.ReadToEnd();
            //Debug.Log(jsonTxt);
            streamReader.Close();
            return jsonTxt;

        }

        public void WriteJsonFile(string aPath, string anObjStr)
        {
            StreamWriter streamWriter = new StreamWriter(Application.persistentDataPath + aPath);
            streamWriter.Write(anObjStr);
            streamWriter.Close();
        }




        // Constructors
        private CustomGatewayJSON() { }


        // Accessors
        public static CustomGatewayJSON Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomGatewayJSON();
                }
                return instance;
            }
        }
    }
}