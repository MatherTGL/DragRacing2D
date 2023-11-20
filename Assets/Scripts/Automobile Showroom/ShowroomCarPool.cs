using System.Collections.Generic;
using UnityEngine;

namespace Showroom
{
    public sealed class ShowroomCarPool : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _poolAllCars = new();
        public List<GameObject> poolAllCars => _poolAllCars;
    }
}
