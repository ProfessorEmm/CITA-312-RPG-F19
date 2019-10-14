using UnityEngine;
using RPG.Saving;
using System;

namespace RPG.SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {
        const string defaultSaveFile = "save";
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Load();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Save();
            }
        }

        private void Save()
        {
            // call to the Saving System and tell it to Save
            GetComponent<SavingSystem>().Save(defaultSaveFile);
        }

        private void Load()
        {
            // call to the Saving System and tell it to Load
            GetComponent<SavingSystem>().Load(defaultSaveFile);
        }
    }
}
