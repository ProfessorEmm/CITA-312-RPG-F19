﻿using UnityEngine;
using RPG.Saving;
using System.Collections;

namespace RPG.SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {
        const string defaultSaveFile = "save";
        [SerializeField] float fadeInTime = 0.2f;

        IEnumerator Start()
        {
            Fader fader = FindObjectOfType<Fader>();
            fader.FadeOutImmediate();
            yield return GetComponent<SavingSystem>().LoadLastScene(defaultSaveFile);
            yield return fader.FadeIn(fadeInTime);
        }
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

        public void Save()
        {
            // call to the Saving System and tell it to Save
            GetComponent<SavingSystem>().Save(defaultSaveFile);
        }

        public void Load()
        {
            // call to the Saving System and tell it to Load
            GetComponent<SavingSystem>().Load(defaultSaveFile);
        }
    }
}
