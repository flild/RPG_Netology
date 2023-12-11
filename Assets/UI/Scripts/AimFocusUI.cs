using UnityEngine;
using UnityEngine.UI;
using TMPro;
using RPG.Units.Extensions;

namespace RPG.UI
{
    public class AimFocusUI : MonoBehaviour
    {
        private Image _image;
        [SerializeField] private TMP_Text _info;
        [SerializeField] private Color _defaultColor;
        [SerializeField] private Color _enemyColor;
        [SerializeField] private Color _friendColor;
        [SerializeField] private Color _neutralColor;
        [SerializeField] private float _maxDistance;

        private void Start()
        {
            _image = GetComponent<Image>();
            _image.color = _defaultColor;
            _info.color = _defaultColor;
        }
        private void LateUpdate()
        {
            var ray = Camera.main.ScreenPointToRay(transform.position);
            if(Physics.Raycast(ray, out var hit,_maxDistance))
            {
                if (hit.transform.TryGetComponent<IFocusable>(out var target))
                {
                    ShowFocusInfo(target);
                }
                else
                {
                    ClearFocusInfo();
                }
            }
            else
            {
                ClearFocusInfo();
            }
                
        }
        private void ShowFocusInfo(IFocusable target)
        {
            SideType side = SideType.None;
            _info.text = target.ShowFocusInfo();
            
            FocusType focusType;
            focusType = target.GetFocusType();

            switch (focusType)
            {
                case FocusType.None:
                    break;
                case FocusType.Unit:
                    side = target.GetSide();
                    break;
                case FocusType.Chest:
                    break;
            }
            switch (side)
            {
                case SideType.None:
                    _info.color = _defaultColor;
                    _image.color = _defaultColor;
                    break;
                case SideType.Enemy:
                    _info.color = _enemyColor;
                    _image.color = _enemyColor;
                    break;
                case SideType.friendly:
                    _info.color = _friendColor;
                    _image.color = _friendColor;
                    break;
                case SideType.neutral:
                    _info.color = _neutralColor;
                    _image.color = _neutralColor;
                    break;
            }
        }
        private void ClearFocusInfo()
        {
            _info.text = "";
            _info.color = _defaultColor;
            _image.color = _defaultColor;
        }

    }
}

