using UnityEngine;

namespace TowerDefense3D
{
    public class BuildManager : MonoBehaviour
    {
        public static BuildManager _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Debug.LogError("More than one BuildManager in scene");
                return;
            }
            _instance = this;
        }

        [SerializeField]
        private GameObject _buildEffect;
        private Node _selectedNode;
        
        [SerializeField]
        private NodeUI _nodeUI;

        private TurretShablon _turretToBuild;

        public bool _canBuild { get { return _turretToBuild != null; } }
        public bool _hasMoney { get { return PlayerStats._money >= _turretToBuild._cost;} }

        public void BuildTurretOn(Node node)
        {
            if (PlayerStats._money < _turretToBuild._cost)
            {
                Debug.Log("Not enough money to build that");
                return;
            }

            PlayerStats._money -= _turretToBuild._cost;

            GameObject _turret = (GameObject)Instantiate(_turretToBuild._prefab, node.GetBuildPosition(), Quaternion.identity);
            node._turret = _turret;

            GameObject _effect = (GameObject)Instantiate(_buildEffect, node.GetBuildPosition(), Quaternion.identity);
            Destroy(_effect, 5f);

            Debug.Log("Turret is built! Money left: " + PlayerStats._money);
        }

        public void SelectNode(Node _node)
        {
            if (_selectedNode == _node)
            {
                DeselectNode();
                return;
            }

            _selectedNode = _node;
            _turretToBuild = null;

            _nodeUI.SetTarget(_node);
        }

        public void SelectTurretToBuild(TurretShablon _turret)
        {
            _turretToBuild = _turret;
            DeselectNode();
        }

        public void DeselectNode()
        {
            _selectedNode = null;
            _nodeUI.Hide();
        }
    }
}