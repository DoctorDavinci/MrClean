﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MrClean
{
    public class ModuleDestroyVessel : PartModule
    {

        public override void OnStart(StartState state)
        {
            if (HighLogic.LoadedSceneIsFlight)
            {
                part.force_activate();
            }
            base.OnStart(state);
        }

        private bool detonating = false;

        public void Update()
        {
            if (HighLogic.LoadedSceneIsFlight)
            {
                if (!detonating)
                {
                    detonating = true;
                    StartCoroutine(CountDownRoutine());
                }
            }
        }

        private int seconds = 3;

        IEnumerator CountDownRoutine()
        {
            yield return new WaitForSeconds(3);
            this.vessel.DestroyVesselComponents();
            this.vessel.Die();
        }
    }
}
