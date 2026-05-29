using PhotoGallery.Domain;

namespace PhotoGallery.Forms;

public partial class PhotoEditForm : Form
{
    public string TitleValue => txtTitle.Text.Trim();
    public Photographer PhotographerValue => (Photographer)cmbPhotographer.SelectedItem!;
    public Location LocationValue => (Location)cmbLocation.SelectedItem!;
    public DateTime TakenAtValue => dtpTaken.Value;
    public double MegapixelsValue => (double)numMp.Value;

    public PhotoEditForm(Photo? photo, List<Photographer> photographers, List<Location> locations)
    {
        InitializeComponent();
        cmbPhotographer.DataSource = photographers;
        cmbLocation.DataSource = locations;

        if (photo != null)
        {
            Text = "Изменить фото";
            txtTitle.Text = photo.Title;
            cmbPhotographer.SelectedItem = photographers.Find(p => p.Id == photo.Photographer.Id);
            cmbLocation.SelectedItem = locations.Find(l => l.Id == photo.Location.Id);
            dtpTaken.Value = photo.TakenAt;
            numMp.Value = (decimal)photo.Megapixels;
        }
        else
        {
            Text = "Добавить фото";
            dtpTaken.Value = DateTime.Today;
            numMp.Value = 24m;
        }
    }

    private void btnOk_Click(object? sender, EventArgs e)
    {
        if (!Validate())
            return;
        DialogResult = DialogResult.OK;
        Close();
    }

    private new bool Validate()
    {
        if (string.IsNullOrWhiteSpace(TitleValue))
        {
            Warn("Название фото не может быть пустым");
            return false;
        }
        if (cmbPhotographer.SelectedItem == null)
        {
            Warn("Выберите фотографа");
            return false;
        }
        if (cmbLocation.SelectedItem == null)
        {
            Warn("Выберите локацию");
            return false;
        }
        if (dtpTaken.Value > DateTime.Now.AddDays(1))
        {
            Warn("Дата съёмки не может быть в будущем");
            return false;
        }
        if (numMp.Value <= 0)
        {
            Warn("Разрешение должно быть положительным");
            return false;
        }
        return true;
    }

    private void Warn(string msg)
        => MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
}
