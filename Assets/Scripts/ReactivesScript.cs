using UnityEngine;

namespace Reactives {
    // Define an extension method in a non-nested static class.
    public static class Extensions
    {
        public static GameObject Particle(this Reactive reactive)
        {
            switch(reactive)
            {
                case Reactive.UpQuark:
                    return Resources.Load("Quarks/Up Quark") as GameObject;
                case Reactive.DownQuark:
                    return Resources.Load("Quarks/Down Quark") as GameObject;
                case Reactive.Proton:
                    return Resources.Load("ProtonNeutrons/Proton") as GameObject;
                case Reactive.Neutron:
                    return Resources.Load("ProtonNeutrons/Neutron") as GameObject;
                default: return null;
            }
        }
    }

    public enum Reactive
    {
        UpQuark,
        DownQuark,
        Proton,
        Neutron
    }
}
