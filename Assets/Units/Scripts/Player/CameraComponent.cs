using UnityEngine;

namespace RPG.Units.Player
{
    public class CameraComponent : MonoBehaviour
    {
        private PlayerInputControl _input;
        [SerializeField] private BaseUnit _target;
        [SerializeField] private Transform _pivot;
        [SerializeField] private Transform _camera;
        public Transform pivot { get => _pivot;}

        //текущее положение поворота камеры вокруг оси OX
        private float _angleX;
        //текущее положение поворота камеры вокруг оси OY
        private float _angleY;
        private Vector3 _pivotEulers;
        private Quaternion _pivotTargetRotation;
        private Quaternion _transformTargetRotation;
        private Quaternion _defaultCameraRotation;


        [Space, SerializeField, Range(-90f, 0f), Tooltip("минимальный наклон камеры по вертикале")]
        private float _minY = -45f;
        [SerializeField, Range(0f, 90f), Tooltip("минимальный наклон камеры по горизонтале")]
        private float _maxY = 30f;
        [Space, SerializeField, Range(0.5f, 10f)]
        private float _moveSpeed = 5f;
        private float _rotateSpeed;
        [SerializeField, Range(0.5f, 10f)]
        private float _lockCameraSpeed = 1.5f;
        [SerializeField, Range(10f, 0), Tooltip("Сглаживание вращения камеры")]
        private float _smoothing = 5f;
        [SerializeField] UnitStats _stats;
        private void Awake()
        {
            _input = new PlayerInputControl();
            _input.Enable();
        }
        private void Start()
        {
            _pivotEulers = _pivot.eulerAngles;
            _defaultCameraRotation = _camera.localRotation;

            transform.parent = null;
            _rotateSpeed = _stats.rotateSpeed;
            //todo потеря таргета

        }
        private void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, _target.transform.position, _moveSpeed * Time.deltaTime);
            if (true) //(_target.Target == null) todo выяснить что такое target.Target;
                FreeCamera();
            else
                LockCamera();
        }
        private void OnDisable()
        {
            _input.Disable();
        }
        private void Reset()
        {
            if (_target == null)
                _target = transform.parent.GetComponent<BaseUnit>();
            if (_pivot == null)
                _pivot = transform.GetChild(0);
            if (_camera == null)
                _camera = GetComponentInChildren<Camera>().transform;
            if (_stats == null)
                _stats = _target.GetComponent<UnitStats>();
        }



        private void FreeCamera()
        {
            var delta = _input.MoveMap.Delta.ReadValue<Vector2>();

            _angleX += delta.x * _rotateSpeed;
            _angleY -= delta.y * _rotateSpeed;
            _angleY = Mathf.Clamp(_angleY,_minY,_maxY);

            _pivotTargetRotation = Quaternion.Euler(_angleY, _pivotEulers.y, _pivotEulers.z);
            _transformTargetRotation = Quaternion.Euler(0f, _angleX, 0f);
            _pivot.localRotation = Quaternion.Slerp(_pivot.localRotation, _pivotTargetRotation, _smoothing * Time.deltaTime);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, _transformTargetRotation, _smoothing * Time.deltaTime);
        }
        private void LockCamera()
        {
            //todo
        }



    }
}

