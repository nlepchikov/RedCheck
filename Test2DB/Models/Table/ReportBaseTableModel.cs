using Test2DB.Models.Row;

namespace Test2DB.Models.Table;

public class ReportBaseTableModel: BaseTableModel
{
    private RowModel _reportRowModel = new ReportRowModel();

    public void SetRow(RowModel row)
    {
        _reportRowModel = row;
    }

    /// <returns></returns>
    public List<RowModel> GetRows()
    {
        return new List<RowModel>() {_reportRowModel};
    }
}