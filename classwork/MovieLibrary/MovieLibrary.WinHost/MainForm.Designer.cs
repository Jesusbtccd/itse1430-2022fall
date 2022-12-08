namespace MovieLibrary.WinHost
//{
//    partial class MovieForm
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose ( bool disposing )
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent ()
//        {
//            this.components = new System.ComponentModel.Container();
//            this.label1 = new System.Windows.Forms.Label();
//            this._txtTitle = new System.Windows.Forms.TextBox();
//            this._txtDescription = new System.Windows.Forms.TextBox();
//            this._chkIsClassic = new System.Windows.Forms.CheckBox();
//            this._cbRating = new System.Windows.Forms.ComboBox();
//            this._txtRunLength = new System.Windows.Forms.TextBox();
//            this._txtReleaseYear = new System.Windows.Forms.TextBox();
//            this.label2 = new System.Windows.Forms.Label();
//            this.label3 = new System.Windows.Forms.Label();
//            this.label4 = new System.Windows.Forms.Label();
//            this.label5 = new System.Windows.Forms.Label();
//            this._btnSave = new System.Windows.Forms.Button();
//            this._btnCancel = new System.Windows.Forms.Button();
//            this._errors = new System.Windows.Forms.ErrorProvider(this.components);
//            ((System.ComponentModel.ISupportInitialize)(this._errors)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Location = new System.Drawing.Point(87, 22);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(29, 15);
//            this.label1.TabIndex = 0;
//            this.label1.Text = "Title";
//            // 
//            // _txtTitle
//            // 
//            this._txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this._txtTitle.Location = new System.Drawing.Point(122, 19);
//            this._txtTitle.Name = "_txtTitle";
//            this._txtTitle.Size = new System.Drawing.Size(253, 23);
//            this._txtTitle.TabIndex = 0;
//            this._txtTitle.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateTitle);
//            // 
//            // _txtDescription
//            // 
//            this._txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//            | System.Windows.Forms.AnchorStyles.Left)
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this._txtDescription.Location = new System.Drawing.Point(122, 188);
//            this._txtDescription.Multiline = true;
//            this._txtDescription.Name = "_txtDescription";
//            this._txtDescription.Size = new System.Drawing.Size(253, 148);
//            this._txtDescription.TabIndex = 5;
//            // 
//            // _chkIsClassic
//            // 
//            this._chkIsClassic.AutoSize = true;
//            this._chkIsClassic.Location = new System.Drawing.Point(122, 159);
//            this._chkIsClassic.Name = "_chkIsClassic";
//            this._chkIsClassic.Size = new System.Drawing.Size(73, 19);
//            this._chkIsClassic.TabIndex = 4;
//            this._chkIsClassic.Text = "Is Classic";
//            this._chkIsClassic.UseVisualStyleBackColor = true;
//            // 
//            // _cbRating
//            // 
//            this._cbRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this._cbRating.FormattingEnabled = true;
//            this._cbRating.Items.AddRange(new object[] {
//            "G",
//            "PG",
//            "PG-13",
//            "R"});
//            this._cbRating.Location = new System.Drawing.Point(122, 51);
//            this._cbRating.Name = "_cbRating";
//            this._cbRating.Size = new System.Drawing.Size(83, 23);
//            this._cbRating.TabIndex = 1;
//            this._cbRating.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateRating);
//            // 
//            // _txtRunLength
//            // 
//            this._txtRunLength.Location = new System.Drawing.Point(122, 85);
//            this._txtRunLength.Name = "_txtRunLength";
//            this._txtRunLength.Size = new System.Drawing.Size(49, 23);
//            this._txtRunLength.TabIndex = 2;
//            this._txtRunLength.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateRunLength);
//            // 
//            // _txtReleaseYear
//            // 
//            this._txtReleaseYear.Location = new System.Drawing.Point(122, 119);
//            this._txtReleaseYear.Name = "_txtReleaseYear";
//            this._txtReleaseYear.Size = new System.Drawing.Size(49, 23);
//            this._txtReleaseYear.TabIndex = 3;
//            this._txtReleaseYear.Text = "1900";
//            this._txtReleaseYear.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateReleaseYear);
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.Location = new System.Drawing.Point(49, 191);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(67, 15);
//            this.label2.TabIndex = 7;
//            this.label2.Text = "Description";
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Location = new System.Drawing.Point(75, 54);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(41, 15);
//            this.label3.TabIndex = 8;
//            this.label3.Text = "Rating";
//            // 
//            // label4
//            // 
//            this.label4.AutoSize = true;
//            this.label4.Location = new System.Drawing.Point(11, 88);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(105, 15);
//            this.label4.TabIndex = 9;
//            this.label4.Text = "Run Length (mins)";
//            // 
//            // label5
//            // 
//            this.label5.AutoSize = true;
//            this.label5.Location = new System.Drawing.Point(45, 122);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(71, 15);
//            this.label5.TabIndex = 10;
//            this.label5.Text = "Release Year";
//            // 
//            // _btnSave
//            // 
//            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
//            this._btnSave.Location = new System.Drawing.Point(262, 362);
//            this._btnSave.Name = "_btnSave";
//            this._btnSave.Size = new System.Drawing.Size(75, 23);
//            this._btnSave.TabIndex = 6;
//            this._btnSave.Text = "Save";
//            this._btnSave.UseVisualStyleBackColor = true;
//            this._btnSave.Click += new System.EventHandler(this.OnSave);
//            // 
//            // _btnCancel
//            // 
//            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
//            this._btnCancel.CausesValidation = false;
//            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
//            this._btnCancel.Location = new System.Drawing.Point(343, 362);
//            this._btnCancel.Name = "_btnCancel";
//            this._btnCancel.Size = new System.Drawing.Size(75, 23);
//            this._btnCancel.TabIndex = 7;
//            this._btnCancel.Text = "Cancel";
//            this._btnCancel.UseVisualStyleBackColor = true;
//            // 
//            // _errors
//            // 
//            this._errors.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
//            this._errors.ContainerControl = this;
//            // 
//            // MovieForm
//            // 
//            this.AcceptButton = this._btnSave;
//            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
//            this.CancelButton = this._btnCancel;
//            this.ClientSize = new System.Drawing.Size(434, 401);
//            this.Controls.Add(this._btnSave);
//            this.Controls.Add(this._btnCancel);
//            this.Controls.Add(this._txtRunLength);
//            this.Controls.Add(this.label5);
//            this.Controls.Add(this.label4);
//            this.Controls.Add(this.label3);
//            this.Controls.Add(this.label2);
//            this.Controls.Add(this._txtReleaseYear);
//            this.Controls.Add(this._cbRating);
//            this.Controls.Add(this._chkIsClassic);
//            this.Controls.Add(this._txtDescription);
//            this.Controls.Add(this._txtTitle);
//            this.Controls.Add(this.label1);
//            this.MaximizeBox = false;
//            this.MaximumSize = new System.Drawing.Size(700, 575);
//            this.MinimizeBox = false;
//            this.MinimumSize = new System.Drawing.Size(450, 440);
//            this.Name = "MovieForm";
//            this.ShowInTaskbar = false;
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
//            this.Text = "Movie Details";
//            ((System.ComponentModel.ISupportInitialize)(this._errors)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private Label label1;
//        private TextBox _txtTitle;
//        private TextBox _txtDescription;
//        private CheckBox _chkIsClassic;
//        private ComboBox _cbRating;
//        private TextBox _txtRunLength;
//        private TextBox _txtReleaseYear;
//        private Label label2;
//        private Label label3;
//        private Label label4;
//        private Label label5;
//        private Button _btnSave;
//        private Button _btnCancel;
//        private ErrorProvider _errors;
//    }
//}
{
    partial class Mainform
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moviesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._miMovieAdd = new System.Windows.Forms.ToolStripMenuItem();
            this._miMovieEdit = new System.Windows.Forms.ToolStripMenuItem();
            this._miMovieDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this._lstMovies = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.moviesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.OnFileExit);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // moviesToolStripMenuItem
            // 
            this.moviesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miMovieAdd,
            this._miMovieEdit,
            this._miMovieDelete});
            this.moviesToolStripMenuItem.Name = "moviesToolStripMenuItem";
            this.moviesToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.moviesToolStripMenuItem.Text = "&Movies";
            // 
            // _miMovieAdd
            // 
            this._miMovieAdd.Name = "_miMovieAdd";
            this._miMovieAdd.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this._miMovieAdd.Size = new System.Drawing.Size(131, 22);
            this._miMovieAdd.Text = "&Add";
            this._miMovieAdd.Click += new System.EventHandler(this.OnMovieAdd);
            // 
            // _miMovieEdit
            // 
            this._miMovieEdit.Name = "_miMovieEdit";
            this._miMovieEdit.Size = new System.Drawing.Size(131, 22);
            this._miMovieEdit.Text = "&Edit";
            this._miMovieEdit.Click += new System.EventHandler(this.OnMovieEdit);
            // 
            // _miMovieDelete
            // 
            this._miMovieDelete.Name = "_miMovieDelete";
            this._miMovieDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this._miMovieDelete.Size = new System.Drawing.Size(131, 22);
            this._miMovieDelete.Text = "&Delete";
            this._miMovieDelete.Click += new System.EventHandler(this._miMovieDelete_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miHelpAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // _miHelpAbout
            // 
            this._miHelpAbout.Name = "_miHelpAbout";
            this._miHelpAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this._miHelpAbout.Size = new System.Drawing.Size(126, 22);
            this._miHelpAbout.Text = "&About";
            this._miHelpAbout.Click += new System.EventHandler(this.OnHelpAbout);
            // 
            // _lstMovies
            // 
            this._lstMovies.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lstMovies.FormattingEnabled = true;
            this._lstMovies.ItemHeight = 15;
            this._lstMovies.Location = new System.Drawing.Point(0, 24);
            this._lstMovies.Name = "_lstMovies";
            this._lstMovies.Size = new System.Drawing.Size(800, 426);
            this._lstMovies.TabIndex = 1;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._lstMovies);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Mainform";
            this.Text = "Movie Library";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem moviesToolStripMenuItem;
        private ToolStripMenuItem _miMovieAdd;
        private ToolStripMenuItem _miMovieEdit;
        private ToolStripMenuItem _miMovieDelete;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem _miHelpAbout;
        private ListBox _lstMovies;
    }
}