#nullable enable
namespace PhotoGallery.Forms;

partial class PhotoEditForm
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private Label labelTitle = null!;
    private TextBox txtTitle = null!;
    private Label labelPhotographer = null!;
    private ComboBox cmbPhotographer = null!;
    private Label labelLocation = null!;
    private ComboBox cmbLocation = null!;
    private Label labelDate = null!;
    private DateTimePicker dtpTaken = null!;
    private Label labelMp = null!;
    private NumericUpDown numMp = null!;
    private Button btnOk = null!;
    private Button btnCancel = null!;

    private void InitializeComponent()
    {
        labelTitle = new Label();
        txtTitle = new TextBox();
        labelPhotographer = new Label();
        cmbPhotographer = new ComboBox();
        labelLocation = new Label();
        cmbLocation = new ComboBox();
        labelDate = new Label();
        dtpTaken = new DateTimePicker();
        labelMp = new Label();
        numMp = new NumericUpDown();
        btnOk = new Button();
        btnCancel = new Button();

        ((System.ComponentModel.ISupportInitialize)numMp).BeginInit();
        SuspendLayout();

        labelTitle.Location = new Point(12, 15); labelTitle.Size = new Size(110, 22);
        labelTitle.TextAlign = ContentAlignment.MiddleRight; labelTitle.Text = "Название:";
        txtTitle.Location = new Point(128, 14); txtTitle.Size = new Size(260, 23);

        labelPhotographer.Location = new Point(12, 45); labelPhotographer.Size = new Size(110, 22);
        labelPhotographer.TextAlign = ContentAlignment.MiddleRight; labelPhotographer.Text = "Фотограф:";
        cmbPhotographer.Location = new Point(128, 44); cmbPhotographer.Size = new Size(260, 23);
        cmbPhotographer.DropDownStyle = ComboBoxStyle.DropDownList;

        labelLocation.Location = new Point(12, 75); labelLocation.Size = new Size(110, 22);
        labelLocation.TextAlign = ContentAlignment.MiddleRight; labelLocation.Text = "Локация:";
        cmbLocation.Location = new Point(128, 74); cmbLocation.Size = new Size(260, 23);
        cmbLocation.DropDownStyle = ComboBoxStyle.DropDownList;

        labelDate.Location = new Point(12, 105); labelDate.Size = new Size(110, 22);
        labelDate.TextAlign = ContentAlignment.MiddleRight; labelDate.Text = "Дата съёмки:";
        dtpTaken.Location = new Point(128, 104); dtpTaken.Size = new Size(260, 23);
        dtpTaken.Format = DateTimePickerFormat.Short;
        dtpTaken.MinDate = new DateTime(1826, 1, 1);
        dtpTaken.MaxDate = DateTime.Now.AddYears(1);

        labelMp.Location = new Point(12, 135); labelMp.Size = new Size(110, 22);
        labelMp.TextAlign = ContentAlignment.MiddleRight; labelMp.Text = "Мегапиксели:";
        numMp.Location = new Point(128, 134); numMp.Size = new Size(120, 23);
        numMp.DecimalPlaces = 1; numMp.Increment = 0.5m;
        numMp.Minimum = 0.1m; numMp.Maximum = 1000m;

        btnOk.Location = new Point(128, 175); btnOk.Size = new Size(120, 32);
        btnOk.Text = "Сохранить";
        btnOk.Click += btnOk_Click;

        btnCancel.Location = new Point(268, 175); btnCancel.Size = new Size(120, 32);
        btnCancel.Text = "Отмена";
        btnCancel.DialogResult = DialogResult.Cancel;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(404, 220);
        Controls.Add(labelTitle);
        Controls.Add(txtTitle);
        Controls.Add(labelPhotographer);
        Controls.Add(cmbPhotographer);
        Controls.Add(labelLocation);
        Controls.Add(cmbLocation);
        Controls.Add(labelDate);
        Controls.Add(dtpTaken);
        Controls.Add(labelMp);
        Controls.Add(numMp);
        Controls.Add(btnOk);
        Controls.Add(btnCancel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        AcceptButton = btnOk;
        CancelButton = btnCancel;
        StartPosition = FormStartPosition.CenterParent;

        ((System.ComponentModel.ISupportInitialize)numMp).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
