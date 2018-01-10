using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace Reactives {
    // Define an extension method in a non-nested static class.
    public static class Extensions
    {
        private static Dictionary<Reactive, GameObject> gameObjects = new Dictionary<Reactive, GameObject>();
        static Extensions()
        {
            gameObjects.Add(Reactive.UpQuark, Resources.Load("Quarks/Up Quark") as GameObject);
            gameObjects.Add(Reactive.DownQuark, Resources.Load("Quarks/Down Quark") as GameObject);
            gameObjects.Add(Reactive.Proton, Resources.Load("ProtonNeutrons/Proton") as GameObject);
            gameObjects.Add(Reactive.Neutron, Resources.Load("ProtonNeutrons/Neutron") as GameObject);
            gameObjects.Add(Reactive.Electron, Resources.Load("Electrons/Electron") as GameObject);
        }
        public static GameObject GetParticleObject(this Reactive reactive)
        {
            GameObject value;
            gameObjects.TryGetValue(reactive, out value);
            return value;
        }

        public static int Get(this Reactive reactive)
        {
            int value = 0;
            DataScript.values.TryGetValue(reactive, out value);
            return value;
        }
        public static void Increment(this Reactive reactive, int amount = 1)
        {
            int value = 0;
            DataScript.values.TryGetValue(reactive, out value);
            DataScript.values.Remove(reactive);
            DataScript.values.Add(reactive, value + amount);
        }
        public static void Decrement(this Reactive reactive, int amount = 1)
        {
            int value = 0;
            DataScript.values.TryGetValue(reactive, out value);
            DataScript.values.Remove(reactive);
            value -= amount;
            DataScript.values.Add(reactive, value > 0 ? value  : 0);
        }
    }

    public enum Reactive
    {
        UpQuark,
        DownQuark,
        Electron,
        Proton,
        Neutron
    }

}
