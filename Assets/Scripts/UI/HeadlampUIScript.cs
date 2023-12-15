using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UnityEngine.UI;

namespace UI
{
    public class HeadlampUIScript : MonoBehaviour
    {
        [SerializeField] Inventory inventory;
        [SerializeField] Image headlampImage;

        private void Update()
        {
            headlampImage.enabled = inventory.GetItemBool("headlamp");
        }
    }
}
