namespace MemoLightMaui;

public partial class MainPage : TabbedPage
{

    // Muistion tallennuspaikka
    string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder
        .LocalApplicationData), "muistio.txt");

    string text = "";


    public MainPage()
	{
		InitializeComponent();

        // Sliderin arvoasteikko
        vahvistusKytkin.Minimum = 0;
        vahvistusKytkin.Maximum = 100;


        // Onko tiedostoa ennestään olemassa
        bool doesExist = File.Exists(fileName);

        if (doesExist == true)
        {
            text = File.ReadAllText(fileName);
            if (text.Length > 0)
            {
                outputLabel.Text = text;
            }
            else
            {
                outputLabel.Text = "Mitään ei ole talletettu muistioon.";
            }

        }
        else
        {
            outputLabel.Text = "Tervetuloa uudelle käyttäjälle!";
        }

    }

    // Muistiinpanon tallentaminen
    private void tallennusNappi_Clicked(object sender, EventArgs e)
    {
        text = text + Environment.NewLine + inputKentta.Text;
        File.WriteAllText(fileName, text);
        outputLabel.Text = text;
        inputKentta.Text = "";
    }

    private void poistoNappi_Clicked(object sender, EventArgs e)
    {
        poistoNappi.IsVisible = false;
        vahvistusInfo.IsVisible = true;
        vahvistusKytkin.IsVisible = true;
    }

    private void vahvistusKytkin_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (vahvistusKytkin.Value > 90)
        {
            //Vibration.Vibrate();
            vahvistusKytkin.Value = 0;
            text = "";
            outputLabel.Text = "";
            vahvistusKytkin.IsVisible = false;
            vahvistusInfo.IsVisible= false;
            poistoNappi.IsVisible= true;   
        }
    }
}

