using System.Data;

namespace KB11558_UltraGridHotTrackCellStyling_WinFormsApp1;

public partial class Form1 : Form
{
    private Infragistics.Win.Appearance _cellHotTrackAppearance;


    public Form1()
    {
        InitializeComponent();

        // マウスオーバーしたセルの外観を定義する。
        this._cellHotTrackAppearance = new Infragistics.Win.Appearance()
        {
            BackColor = Color.LightBlue
        };
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        this.ultraGrid1.DataSource = GetData();
    }

    private DataTable GetData()
    {
        var dt = new DataTable();

        var idColumn = dt.Columns.Add("ID", typeof(int));
        for (int i = 1; i < 5; i++)
        {
            dt.Columns.Add($"Col{i}", typeof(String));
        }

        for (int i = 0; i < 5; i++)
        {
            var newRow = dt.NewRow();
            newRow["ID"] = i;
            for (int j = 1; j < newRow.ItemArray.Length; j++)
            {
                newRow[j] = $"Row {i}, Col{j}";
            }
            dt.Rows.Add(newRow);
        }

        dt.PrimaryKey = new DataColumn[] { idColumn };

        return dt;
    }

    private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
    {
        // マウスオーバーしたセルの外観を設定したオブジェクトを指定する。
        e.Layout.Override.HotTrackCellAppearance = this._cellHotTrackAppearance;
    }
}
