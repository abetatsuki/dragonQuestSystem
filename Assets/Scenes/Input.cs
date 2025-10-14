using UnityEngine;
using UnityEngine.UI;

public class InputUI : MonoBehaviour
{
    [SerializeField] private Color _normalCell = Color.white;
    [SerializeField] private Color _selectedCell = Color.cyan;
    [SerializeField] private inputsystem input;

    private int _selectedRow = 0;
    private const int Size = 5;
    private Image[,] _cells;
    private RectTransform _arrow;

    void OnEnable() => input.selected += OnSelected;
    void OnDisable() => input.selected -= OnSelected;

    void OnSelected(int input)
    {
        _selectedRow += input;
        UpdateSelected();
    }

    void Start()
    {
        _cells = new Image[Size, 1];

        for (var r = 0; r < Size; r++)
        {
            var obj = new GameObject($"Cell{r},0");
            obj.transform.SetParent(transform, false);
            var cell = obj.AddComponent<Image>();
            _cells[r, 0] = cell;

            // ✅ セルを縦に並べる
            var rect = cell.rectTransform;
            rect.sizeDelta = new Vector2(200, 70);       // 幅・高さ
            rect.anchoredPosition = new Vector2(0, -r * 80); // 行ごとに下へずらす
        }

        // ✅ 矢印を生成
        var arrowObj = new GameObject("SelectedArrow");
        arrowObj.transform.SetParent(transform, false);

        _arrow = arrowObj.AddComponent<RectTransform>();
        var img = arrowObj.AddComponent<Image>();
        img.color = Color.yellow;
        

        // ✅ 初期選択行
        _selectedRow = 0;
        UpdateSelected();
    }

    private void UpdateSelected()
    {
        _selectedRow = Mathf.Clamp(_selectedRow, 0, Size - 1);

        for (var r = 0; r < Size; r++)
        {
            _cells[r, 0].color =
                (r == _selectedRow)
                ? _selectedCell
                : _normalCell;
        }

        UpdateArrowPosition();
    }

    private void UpdateArrowPosition()
    {
        if (_arrow == null) return;

        // 選択中セルの位置を取得
        var targetCell = _cells[_selectedRow, 0].rectTransform;
        var targetPos = targetCell.anchoredPosition;

        // 左にずらして配置
        _arrow.anchoredPosition = targetPos + new Vector2(-200, 0);
    }
}
