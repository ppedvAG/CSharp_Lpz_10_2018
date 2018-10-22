namespace KaffeeGame
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.labelKaffeebeschreibung = new System.Windows.Forms.Label();
            this.listBoxKaffeemaschine = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBoxWasser = new System.Windows.Forms.TextBox();
            this.textBoxKaffee = new System.Windows.Forms.TextBox();
            this.textBoxMilch = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.labelFehlermeldung = new System.Windows.Forms.Label();
            this.timerFehlerAusblenden = new System.Windows.Forms.Timer(this.components);
            this.labelBestellung = new System.Windows.Forms.Label();
            this.labelZeit = new System.Windows.Forms.Label();
            this.timerZeit = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelKaffeebeschreibung
            // 
            this.labelKaffeebeschreibung.AutoSize = true;
            this.labelKaffeebeschreibung.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKaffeebeschreibung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelKaffeebeschreibung.Location = new System.Drawing.Point(78, 318);
            this.labelKaffeebeschreibung.Name = "labelKaffeebeschreibung";
            this.labelKaffeebeschreibung.Size = new System.Drawing.Size(190, 32);
            this.labelKaffeebeschreibung.TabIndex = 0;
            this.labelKaffeebeschreibung.Text = "Beschreibung";
            // 
            // listBoxKaffeemaschine
            // 
            this.listBoxKaffeemaschine.FormattingEnabled = true;
            this.listBoxKaffeemaschine.ItemHeight = 20;
            this.listBoxKaffeemaschine.Location = new System.Drawing.Point(27, 89);
            this.listBoxKaffeemaschine.Name = "listBoxKaffeemaschine";
            this.listBoxKaffeemaschine.Size = new System.Drawing.Size(211, 204);
            this.listBoxKaffeemaschine.TabIndex = 1;
            this.listBoxKaffeemaschine.SelectedValueChanged += new System.EventHandler(this.listBoxKaffeemaschine_SelectedValueChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(720, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "Wasser";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.wasserButton_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(720, 283);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 41);
            this.button2.TabIndex = 3;
            this.button2.Text = "Kaffee";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonKaffee_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(720, 402);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(132, 41);
            this.button3.TabIndex = 4;
            this.button3.Text = "Pad";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonPad_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(720, 346);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(132, 41);
            this.button4.TabIndex = 5;
            this.button4.Text = "Milch";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonMilch_Click);
            // 
            // textBoxWasser
            // 
            this.textBoxWasser.Location = new System.Drawing.Point(875, 237);
            this.textBoxWasser.Name = "textBoxWasser";
            this.textBoxWasser.Size = new System.Drawing.Size(117, 26);
            this.textBoxWasser.TabIndex = 6;
            // 
            // textBoxKaffee
            // 
            this.textBoxKaffee.Location = new System.Drawing.Point(875, 293);
            this.textBoxKaffee.Name = "textBoxKaffee";
            this.textBoxKaffee.Size = new System.Drawing.Size(117, 26);
            this.textBoxKaffee.TabIndex = 7;
            // 
            // textBoxMilch
            // 
            this.textBoxMilch.Location = new System.Drawing.Point(875, 356);
            this.textBoxMilch.Name = "textBoxMilch";
            this.textBoxMilch.Size = new System.Drawing.Size(117, 26);
            this.textBoxMilch.TabIndex = 8;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(720, 474);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(132, 41);
            this.button5.TabIndex = 9;
            this.button5.Text = "Bereite zu";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.buttonZubereitung_Click);
            // 
            // labelFehlermeldung
            // 
            this.labelFehlermeldung.AutoSize = true;
            this.labelFehlermeldung.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFehlermeldung.ForeColor = System.Drawing.Color.Red;
            this.labelFehlermeldung.Location = new System.Drawing.Point(719, 533);
            this.labelFehlermeldung.Name = "labelFehlermeldung";
            this.labelFehlermeldung.Size = new System.Drawing.Size(0, 29);
            this.labelFehlermeldung.TabIndex = 10;
            // 
            // timerFehlerAusblenden
            // 
            this.timerFehlerAusblenden.Interval = 2000;
            this.timerFehlerAusblenden.Tick += new System.EventHandler(this.timerFehlerAusblenden_Tick);
            // 
            // labelBestellung
            // 
            this.labelBestellung.AutoSize = true;
            this.labelBestellung.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBestellung.ForeColor = System.Drawing.Color.Blue;
            this.labelBestellung.Location = new System.Drawing.Point(39, 18);
            this.labelBestellung.Name = "labelBestellung";
            this.labelBestellung.Size = new System.Drawing.Size(85, 29);
            this.labelBestellung.TabIndex = 11;
            this.labelBestellung.Text = "label1";
            // 
            // labelZeit
            // 
            this.labelZeit.AutoSize = true;
            this.labelZeit.Location = new System.Drawing.Point(865, 19);
            this.labelZeit.Name = "labelZeit";
            this.labelZeit.Size = new System.Drawing.Size(51, 20);
            this.labelZeit.TabIndex = 12;
            this.labelZeit.Text = "label1";
            // 
            // timerZeit
            // 
            this.timerZeit.Enabled = true;
            this.timerZeit.Interval = 1000;
            this.timerZeit.Tick += new System.EventHandler(this.timerZeit_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 599);
            this.Controls.Add(this.labelZeit);
            this.Controls.Add(this.labelBestellung);
            this.Controls.Add(this.labelFehlermeldung);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBoxMilch);
            this.Controls.Add(this.textBoxKaffee);
            this.Controls.Add(this.textBoxWasser);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxKaffeemaschine);
            this.Controls.Add(this.labelKaffeebeschreibung);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelKaffeebeschreibung;
        private System.Windows.Forms.ListBox listBoxKaffeemaschine;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBoxWasser;
        private System.Windows.Forms.TextBox textBoxKaffee;
        private System.Windows.Forms.TextBox textBoxMilch;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label labelFehlermeldung;
        private System.Windows.Forms.Timer timerFehlerAusblenden;
        private System.Windows.Forms.Label labelBestellung;
        private System.Windows.Forms.Label labelZeit;
        private System.Windows.Forms.Timer timerZeit;
    }
}

