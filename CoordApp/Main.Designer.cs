namespace CoordApp
{
	partial class Main
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.L_Title = new System.Windows.Forms.Label();
			this.L_Version = new System.Windows.Forms.Label();
			this.TLP_Buttons = new System.Windows.Forms.TableLayoutPanel();
			this.B_Connect = new System.Windows.Forms.Button();
			this.B_SelectMap = new System.Windows.Forms.Button();
			this.B_Play = new System.Windows.Forms.Button();
			this.PB_MapImage = new System.Windows.Forms.PictureBox();
			this.L_MapTitle = new System.Windows.Forms.Label();
			this.L_Artist = new System.Windows.Forms.Label();
			this.PB_Progress = new System.Windows.Forms.ProgressBar();
			this.L_Time = new System.Windows.Forms.Label();
			this.P_Divider = new System.Windows.Forms.Panel();
			this.TLP_Players = new System.Windows.Forms.TableLayoutPanel();
			this.B_Kick = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.L_playerName = new System.Windows.Forms.Label();
			this.TLP_Buttons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PB_MapImage)).BeginInit();
			this.TLP_Players.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// L_Title
			// 
			this.L_Title.Font = new System.Drawing.Font("Segoe UI Black", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.L_Title.Location = new System.Drawing.Point(12, 9);
			this.L_Title.Name = "L_Title";
			this.L_Title.Size = new System.Drawing.Size(505, 60);
			this.L_Title.TabIndex = 0;
			this.L_Title.Text = "Tournament Assistant";
			// 
			// L_Version
			// 
			this.L_Version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.L_Version.Location = new System.Drawing.Point(1008, 9);
			this.L_Version.Name = "L_Version";
			this.L_Version.Size = new System.Drawing.Size(162, 23);
			this.L_Version.TabIndex = 1;
			this.L_Version.Text = "Version 1.0.0.0";
			this.L_Version.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// TLP_Buttons
			// 
			this.TLP_Buttons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.TLP_Buttons.ColumnCount = 1;
			this.TLP_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TLP_Buttons.Controls.Add(this.B_Connect, 0, 2);
			this.TLP_Buttons.Controls.Add(this.B_SelectMap, 0, 1);
			this.TLP_Buttons.Controls.Add(this.B_Play, 0, 0);
			this.TLP_Buttons.Location = new System.Drawing.Point(970, 878);
			this.TLP_Buttons.Name = "TLP_Buttons";
			this.TLP_Buttons.RowCount = 3;
			this.TLP_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.TLP_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.TLP_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.TLP_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.TLP_Buttons.Size = new System.Drawing.Size(200, 263);
			this.TLP_Buttons.TabIndex = 2;
			// 
			// B_Connect
			// 
			this.B_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.B_Connect.AutoSize = true;
			this.B_Connect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.B_Connect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
			this.B_Connect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.B_Connect.Location = new System.Drawing.Point(3, 177);
			this.B_Connect.Name = "B_Connect";
			this.B_Connect.Size = new System.Drawing.Size(194, 83);
			this.B_Connect.TabIndex = 4;
			this.B_Connect.Text = "Connect";
			this.B_Connect.UseVisualStyleBackColor = false;
			// 
			// B_SelectMap
			// 
			this.B_SelectMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.B_SelectMap.AutoSize = true;
			this.B_SelectMap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.B_SelectMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
			this.B_SelectMap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.B_SelectMap.Location = new System.Drawing.Point(3, 90);
			this.B_SelectMap.Name = "B_SelectMap";
			this.B_SelectMap.Size = new System.Drawing.Size(194, 81);
			this.B_SelectMap.TabIndex = 1;
			this.B_SelectMap.Text = "Select map";
			this.B_SelectMap.UseVisualStyleBackColor = false;
			// 
			// B_Play
			// 
			this.B_Play.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.B_Play.AutoSize = true;
			this.B_Play.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.B_Play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
			this.B_Play.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.B_Play.Location = new System.Drawing.Point(3, 3);
			this.B_Play.Name = "B_Play";
			this.B_Play.Size = new System.Drawing.Size(194, 81);
			this.B_Play.TabIndex = 3;
			this.B_Play.Text = "Play";
			this.B_Play.UseVisualStyleBackColor = false;
			// 
			// PB_MapImage
			// 
			this.PB_MapImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
			this.PB_MapImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PB_MapImage.BackgroundImage")));
			this.PB_MapImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("PB_MapImage.InitialImage")));
			this.PB_MapImage.Location = new System.Drawing.Point(12, 108);
			this.PB_MapImage.Name = "PB_MapImage";
			this.PB_MapImage.Size = new System.Drawing.Size(255, 255);
			this.PB_MapImage.TabIndex = 3;
			this.PB_MapImage.TabStop = false;
			// 
			// L_MapTitle
			// 
			this.L_MapTitle.AutoSize = true;
			this.L_MapTitle.Font = new System.Drawing.Font("Segoe UI Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.L_MapTitle.Location = new System.Drawing.Point(287, 108);
			this.L_MapTitle.Name = "L_MapTitle";
			this.L_MapTitle.Size = new System.Drawing.Size(127, 35);
			this.L_MapTitle.TabIndex = 4;
			this.L_MapTitle.Text = "Birdsong";
			// 
			// L_Artist
			// 
			this.L_Artist.AutoSize = true;
			this.L_Artist.ForeColor = System.Drawing.Color.Silver;
			this.L_Artist.Location = new System.Drawing.Point(287, 143);
			this.L_Artist.Name = "L_Artist";
			this.L_Artist.Size = new System.Drawing.Size(237, 23);
			this.L_Artist.TabIndex = 5;
			this.L_Artist.Text = "James Landino and Kabuki";
			// 
			// PB_Progress
			// 
			this.PB_Progress.Location = new System.Drawing.Point(287, 317);
			this.PB_Progress.Name = "PB_Progress";
			this.PB_Progress.Size = new System.Drawing.Size(404, 23);
			this.PB_Progress.Step = 1;
			this.PB_Progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.PB_Progress.TabIndex = 6;
			this.PB_Progress.Value = 50;
			// 
			// L_Time
			// 
			this.L_Time.Location = new System.Drawing.Point(591, 291);
			this.L_Time.Name = "L_Time";
			this.L_Time.Size = new System.Drawing.Size(100, 23);
			this.L_Time.TabIndex = 7;
			this.L_Time.Text = "1:30 \\ 3:00";
			this.L_Time.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// P_Divider
			// 
			this.P_Divider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
			this.P_Divider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
			this.P_Divider.Location = new System.Drawing.Point(1, 75);
			this.P_Divider.Name = "P_Divider";
			this.P_Divider.Size = new System.Drawing.Size(1200, 15);
			this.P_Divider.TabIndex = 8;
			// 
			// TLP_Players
			// 
			this.TLP_Players.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.TLP_Players.AutoScroll = true;
			this.TLP_Players.AutoSize = true;
			this.TLP_Players.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TLP_Players.ColumnCount = 3;
			this.TLP_Players.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.TLP_Players.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.TLP_Players.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.TLP_Players.Controls.Add(this.B_Kick, 2, 0);
			this.TLP_Players.Controls.Add(this.pictureBox1, 0, 0);
			this.TLP_Players.Controls.Add(this.L_playerName, 1, 0);
			this.TLP_Players.Location = new System.Drawing.Point(12, 369);
			this.TLP_Players.Name = "TLP_Players";
			this.TLP_Players.RowCount = 1;
			this.TLP_Players.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.TLP_Players.Size = new System.Drawing.Size(950, 771);
			this.TLP_Players.TabIndex = 9;
			// 
			// B_Kick
			// 
			this.B_Kick.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.B_Kick.AutoSize = true;
			this.B_Kick.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.B_Kick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
			this.B_Kick.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.B_Kick.Location = new System.Drawing.Point(858, 3);
			this.B_Kick.Name = "B_Kick";
			this.B_Kick.Size = new System.Drawing.Size(89, 765);
			this.B_Kick.TabIndex = 10;
			this.B_Kick.Text = "Kick";
			this.B_Kick.UseVisualStyleBackColor = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(3, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(184, 765);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// L_playerName
			// 
			this.L_playerName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.L_playerName.AutoSize = true;
			this.L_playerName.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.L_playerName.Location = new System.Drawing.Point(193, 3);
			this.L_playerName.Margin = new System.Windows.Forms.Padding(3);
			this.L_playerName.Name = "L_playerName";
			this.L_playerName.Size = new System.Drawing.Size(659, 765);
			this.L_playerName.TabIndex = 1;
			this.L_playerName.Text = "Thijnmens";
			this.L_playerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(1182, 1153);
			this.Controls.Add(this.TLP_Players);
			this.Controls.Add(this.P_Divider);
			this.Controls.Add(this.L_Time);
			this.Controls.Add(this.PB_Progress);
			this.Controls.Add(this.L_Artist);
			this.Controls.Add(this.L_MapTitle);
			this.Controls.Add(this.PB_MapImage);
			this.Controls.Add(this.TLP_Buttons);
			this.Controls.Add(this.L_Version);
			this.Controls.Add(this.L_Title);
			this.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
			this.Name = "Main";
			this.Text = "Tournament Assistant";
			this.TLP_Buttons.ResumeLayout(false);
			this.TLP_Buttons.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PB_MapImage)).EndInit();
			this.TLP_Players.ResumeLayout(false);
			this.TLP_Players.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.Button B_Kick;

		private System.Windows.Forms.Label L_playerName;

		private System.Windows.Forms.PictureBox pictureBox1;


		private System.Windows.Forms.Label L_Time;

		private System.Windows.Forms.ProgressBar PB_Progress;

		private System.Windows.Forms.Label L_Artist;

		private System.Windows.Forms.Label L_MapTitle;

		private System.Windows.Forms.PictureBox PB_MapImage;

		private System.Windows.Forms.Button B_Connect;
		private System.Windows.Forms.Button B_SelectMap;
		private System.Windows.Forms.Button B_Play;

		private System.Windows.Forms.TableLayoutPanel TLP_Players;
		private System.Windows.Forms.TableLayoutPanel TLP_Buttons;

		private System.Windows.Forms.Panel P_Divider;

		private System.Windows.Forms.Label L_Title;

		private System.Windows.Forms.Label L_Version;

		#endregion

	}
}