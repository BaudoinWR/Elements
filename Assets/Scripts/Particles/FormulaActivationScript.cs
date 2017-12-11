using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FormulaActivationScript : MonoBehaviour
{
    /**
     * Product => (Source => Components)
     */
    public static Dictionary<GameObject, Dictionary<GameObject, ICollection<GameObject>>> activableFormulas = new Dictionary<GameObject, Dictionary<GameObject, ICollection<GameObject>>>();

    public static void AddFormula(GameObject produce, GameObject source, ICollection<GameObject> collidingAvailable)
    {
        Dictionary<GameObject, ICollection<GameObject>> existingOne;
        activableFormulas.TryGetValue(produce, out existingOne);
        if (existingOne == null)
        {
            existingOne = new Dictionary<GameObject, ICollection<GameObject>>();
            activableFormulas.Add(produce, existingOne);
        }
        existingOne.Remove(source);
        existingOne.Add(source, collidingAvailable);
    }

    public static void Remove(GameObject produce, GameObject source) {
        Dictionary<GameObject, ICollection<GameObject>> existing;
        activableFormulas.TryGetValue(produce, out existing);
        if (existing != null)
        {
            existing.Remove(source);
            if (existing.Count == 0)
            {
                activableFormulas.Remove(produce);
            }
        }
    }

    public void Activate()
    {
        foreach(KeyValuePair<GameObject, Dictionary<GameObject, ICollection<GameObject>>> pair in activableFormulas)
        {
            GameObject produce = Instantiate(pair.Key);
            Dictionary<GameObject, ICollection<GameObject>>.Enumerator enumerator = pair.Value.GetEnumerator();
            enumerator.MoveNext();
            GameObject source = enumerator.Current.Key;
            produce.transform.position = source.transform.position;
            Destroy(source);
            foreach (GameObject comp in enumerator.Current.Value)
            {
                Destroy(comp);
            }
            activableFormulas.Clear();
            return;
        }
    }
}
