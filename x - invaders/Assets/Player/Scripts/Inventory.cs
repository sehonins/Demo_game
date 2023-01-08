using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    int _points;
    [SerializeField]
    Text _pointText;

    private void Start()
    {
        DispalyPoints();
    }
    public int Points { get { return _points; } }   

    public void GetPoints(int points)
    {
        _points += points;
        DispalyPoints();
    }

    private void DispalyPoints()
    {
        if (_pointText != null)
        {
            _pointText.text = _points.ToString();
        }
    }
}
