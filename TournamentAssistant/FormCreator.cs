using System.Drawing;
using System.Windows.Forms;
using Steamworks;
using ZXing;
using ZXing.QrCode;

namespace TournamentAssistant
{
	public class FormCreator
	{
		private Form Form { get; }

		public FormCreator()
		{
			var writer = new BarcodeWriter
			{
				Format = BarcodeFormat.QR_CODE,
				Options = new QrCodeEncodingOptions
				{
					DisableECI = false,
					CharacterSet = "UTF-8",
					Width = 500,
					Height = 500
				}
			};
			var qrCode = writer.Write(SteamFriends.GetPersonaName());

			Form = new Form
			{
				BackColor = Color.Green,
				BackgroundImage = qrCode,
				BackgroundImageLayout = ImageLayout.Center,
				Location = new Point(0, 0),
				TopMost = true,
				FormBorderStyle = FormBorderStyle.None,
				WindowState = FormWindowState.Maximized,
				Name = "Winner POV"
			};

			Form.ShowDialog();
		}

		public void Show()
		{
			Form.ShowDialog();
		}

		public void Close()
		{
			Form.Close();
		}
	}
}