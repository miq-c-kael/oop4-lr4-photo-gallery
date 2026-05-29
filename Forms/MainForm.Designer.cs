#nullable enable
namespace PhotoGallery.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private DataGridView grid = null!;
    private Button btnAdd = null!;
    private Button btnEdit = null!;
    private Button btnDelete = null!;
    private Label labelSearch = null!;
    private TextBox txtSearch = null!;
    private Label labelMinMp = null!;
    private NumericUpDown numMinMp = null!;
    private Button btnFilter = null!;
    private Button btnSort = null!;
    private Button btnGroupByLocation = null!;
    private Button btnGroupByPhotographer = null!;
    private Button btnReset = null!;
    private Label labelInfo = null!;

    private void InitializeComponent()
    {
        grid = new DataGridView();
        btnAdd = new Button();
        btnEdit = new Button();
        btnDelete = new Button();
        labelSearch = new Label();
        txtSearch = new TextBox();
        labelMinMp = new Label();
        numMinMp = new NumericUpDown();
        btnFilter = new Button();
        btnSort = new Button();
        btnGroupByLocation = new Button();
        btnGroupByPhotographer = new Button();
        btnReset = new Button();
        labelInfo = new Label();

        ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numMinMp).BeginInit();
        SuspendLayout();

        labelSearch.Location = new Point(12, 12);
        labelSearch.Size = new Size(70, 22);
        labelSearch.Text = "Поиск:";
        labelSearch.TextAlign = ContentAlignment.MiddleRight;

        txtSearch.Location = new Point(88, 12);
        txtSearch.Size = new Size(260, 23);
        txtSearch.TextChanged += txtSearch_TextChanged;

        labelMinMp.Location = new Point(370, 12);
        labelMinMp.Size = new Size(60, 22);
        labelMinMp.Text = "Мин МП:";
        labelMinMp.TextAlign = ContentAlignment.MiddleRight;

        numMinMp.Location = new Point(436, 12);
        numMinMp.Size = new Size(60, 23);
        numMinMp.Minimum = 0;
        numMinMp.Maximum = 1000;
        numMinMp.Value = 20;

        btnFilter.Location = new Point(506, 10);
        btnFilter.Size = new Size(110, 27);
        btnFilter.Text = "Фильтр";
        btnFilter.Click += btnFilter_Click;

        btnSort.Location = new Point(622, 10);
        btnSort.Size = new Size(140, 27);
        btnSort.Text = "Сортировка по дате";
        btnSort.Click += btnSort_Click;

        btnGroupByLocation.Location = new Point(768, 10);
        btnGroupByLocation.Size = new Size(150, 27);
        btnGroupByLocation.Text = "По локациям";
        btnGroupByLocation.Click += btnGroupByLocation_Click;

        btnGroupByPhotographer.Location = new Point(924, 10);
        btnGroupByPhotographer.Size = new Size(150, 27);
        btnGroupByPhotographer.Text = "По фотографам";
        btnGroupByPhotographer.Click += btnGroupByPhotographer_Click;

        grid.Location = new Point(12, 50);
        grid.Size = new Size(1062, 440);
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.ReadOnly = true;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.MultiSelect = false;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        btnAdd.Location = new Point(12, 500);
        btnAdd.Size = new Size(120, 32);
        btnAdd.Text = "Добавить";
        btnAdd.Click += btnAdd_Click;

        btnEdit.Location = new Point(138, 500);
        btnEdit.Size = new Size(120, 32);
        btnEdit.Text = "Изменить";
        btnEdit.Click += btnEdit_Click;

        btnDelete.Location = new Point(264, 500);
        btnDelete.Size = new Size(120, 32);
        btnDelete.Text = "Удалить";
        btnDelete.Click += btnDelete_Click;

        btnReset.Location = new Point(400, 500);
        btnReset.Size = new Size(150, 32);
        btnReset.Text = "Сбросить фильтры";
        btnReset.Click += btnReset_Click;

        labelInfo.Location = new Point(566, 506);
        labelInfo.Size = new Size(500, 22);
        labelInfo.Text = "Записей: 0";

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1086, 542);
        Controls.Add(labelSearch);
        Controls.Add(txtSearch);
        Controls.Add(labelMinMp);
        Controls.Add(numMinMp);
        Controls.Add(btnFilter);
        Controls.Add(btnSort);
        Controls.Add(btnGroupByLocation);
        Controls.Add(btnGroupByPhotographer);
        Controls.Add(grid);
        Controls.Add(btnAdd);
        Controls.Add(btnEdit);
        Controls.Add(btnDelete);
        Controls.Add(btnReset);
        Controls.Add(labelInfo);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "ЛР 4 — Фотогалерея (вариант 8)";
        MinimumSize = new Size(900, 500);

        ((System.ComponentModel.ISupportInitialize)grid).EndInit();
        ((System.ComponentModel.ISupportInitialize)numMinMp).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
