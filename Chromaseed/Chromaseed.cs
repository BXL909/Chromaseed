﻿//!░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
//+++CHROMASEED
//!● Homepage.......... tbc
//!● Version history... tbc
//!● Download.......... tbc
//
//TODO LIST______________________________________________________________________________________________
//trigger textchanged events when seed length changes midway through
//BUG LIST_______________________________________________________________________________________________
//!░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░

#region Using
using CustomControls.RJControls;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
#endregion

namespace Chromaseed
{
    public partial class Chromaseed : Form
    {
        #region variable declarations
        readonly Dictionary<int, string> bip39Words = new();
        TextBox activeSeedBox;
        readonly TextBox[] textBoxesAllSeedWords;
        readonly TextBox[] textBoxes13to24SeedWords;
        readonly Control[] labelsAllSeedWords;
        readonly Control[] labels13to24SeedWords;
        readonly Control[] labels13to24WordPositions;
        readonly Control[] labels9to16Merge;
        readonly Control[] labels9to16ColorDecimal;
        readonly Control[] labels9to16ColorHex;
        readonly Control[] labels9to16ColorRGB;
        readonly Control[] panels13to24SeedWords;
        readonly Control[] panels1to24SeedWords;
        readonly Control[] buttons9to16Colours;
        readonly Control[] labelsColourNumbers9to16;
        #endregion

        #region rounded form
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
             (
               int nLeftRect,     // x-coordinate of upper-left corner
               int nTopRect,      // y-coordinate of upper-left corner
               int nRightRect,    // x-coordinate of lower-right corner
               int nBottomRect,   // y-coordinate of lower-right corner
               int nWidthEllipse, // height of ellipse
               int nHeightEllipse // width of ellipse
             );
        #endregion

        public Chromaseed()
        {
            InitializeComponent();
            activeSeedBox = textBoxSeedWord1;
            #region rounded form
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            Padding = new Padding(1);
            #endregion

            #region rounded panels

            Control[] panelsToBeRounded = new Control[] { panelSeedWords, panelSuggestionBoxSurround, panelColours };

            foreach (Control control in panelsToBeRounded)
            {
                control.Paint += Panel_Paint;
            }
            #endregion

            #region set up groups of controls
            textBoxesAllSeedWords = new TextBox[] { textBoxSeedWord1, textBoxSeedWord2, textBoxSeedWord3, textBoxSeedWord4, textBoxSeedWord5, textBoxSeedWord6, textBoxSeedWord7, textBoxSeedWord8, textBoxSeedWord9, textBoxSeedWord10, textBoxSeedWord11, textBoxSeedWord12, textBoxSeedWord13, textBoxSeedWord14, textBoxSeedWord15, textBoxSeedWord16, textBoxSeedWord17, textBoxSeedWord18, textBoxSeedWord19, textBoxSeedWord20, textBoxSeedWord21, textBoxSeedWord22, textBoxSeedWord23, textBoxSeedWord24 };
            textBoxes13to24SeedWords = new TextBox[] { textBoxSeedWord13, textBoxSeedWord14, textBoxSeedWord15, textBoxSeedWord16, textBoxSeedWord17, textBoxSeedWord18, textBoxSeedWord19, textBoxSeedWord20, textBoxSeedWord21, textBoxSeedWord22, textBoxSeedWord23, textBoxSeedWord24 };
            labelsAllSeedWords = new Control[] { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12, label13, label14, label15, label16, label17, label18, label19, label20, label21, label22, label23, label24 };
            labels13to24SeedWords = new Control[] { label13, label14, label15, label16, label17, label18, label19, label20, label21, label22, label23, label24 };
            labels13to24WordPositions = new Control[] { lblWord13Position, lblWord14Position, lblWord15Position, lblWord16Position, lblWord17Position, lblWord18Position, lblWord19Position, lblWord20Position, lblWord21Position, lblWord22Position, lblWord23Position, lblWord24Position };
            labels9to16Merge = new Control[] { lblMerge9, lblMerge10, lblMerge11, lblMerge12, lblMerge13, lblMerge14, lblMerge15, lblMerge16 };
            labels9to16ColorDecimal = new Control[] { lblColorDecimal9, lblColorDecimal10, lblColorDecimal11, lblColorDecimal12, lblColorDecimal13, lblColorDecimal14, lblColorDecimal15, lblColorDecimal16 };
            labels9to16ColorHex = new Control[] { lblColorHex9, lblColorHex10, lblColorHex11, lblColorHex12, lblColorHex13, lblColorHex14, lblColorHex15, lblColorHex16 };
            labels9to16ColorRGB = new Control[] { lblColorRGB9, lblColorRGB10, lblColorRGB11, lblColorRGB12, lblColorRGB13, lblColorRGB14, lblColorRGB15, lblColorRGB16 };
            panels1to24SeedWords = new Control[] { panelSeedWordColor1, panelSeedWordColor2, panelSeedWordColor3, panelSeedWordColor4, panelSeedWordColor5, panelSeedWordColor6, panelSeedWordColor7, panelSeedWordColor8, panelSeedWordColor9, panelSeedWordColor10, panelSeedWordColor11, panelSeedWordColor12, panelSeedWordColor13, panelSeedWordColor14, panelSeedWordColor15, panelSeedWordColor16, panelSeedWordColor17, panelSeedWordColor18, panelSeedWordColor19, panelSeedWordColor20, panelSeedWordColor21, panelSeedWordColor22, panelSeedWordColor23, panelSeedWordColor24 };
            panels13to24SeedWords = new Control[] { panelSeedWordColor13, panelSeedWordColor14, panelSeedWordColor15, panelSeedWordColor16, panelSeedWordColor17, panelSeedWordColor18, panelSeedWordColor19, panelSeedWordColor20, panelSeedWordColor21, panelSeedWordColor22, panelSeedWordColor23, panelSeedWordColor24 };
            buttons9to16Colours = new Control[] { btnColor9, btnColor10, btnColor11, btnColor12, btnColor13, btnColor14, btnColor15, btnColor16 };
            labelsColourNumbers9to16 = new Control[] { lblColour9, lblColour10, lblColour11, lblColour12, lblColour13, lblColour14, lblColour15, lblColour16 };
            #endregion

            #region load bip39 words and set up controls
            LoadBip39Words();

            AutoCompleteStringCollection autoCompleteCollection = new();
            autoCompleteCollection.AddRange(bip39Words.Values.ToArray());

            foreach (TextBox textbox in textBoxesAllSeedWords)
            {
                textbox.AutoCompleteCustomSource.AddRange(bip39Words.Values.ToArray());
                textbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textbox.AutoCompleteCustomSource = autoCompleteCollection;
            }

            suggestionBox.Items.Clear();
            suggestionBox.Items.AddRange(bip39Words.Values.ToArray());
            #endregion
        }

        #region SEED PHRASE INPUT

        #region show or hide seed words
        private void BtnObscureSeedWords_Click(object sender, EventArgs e)
        {
            if (btnShowHideSeedWords.Text == "SHOW")
            {
                foreach (TextBox textbox in textBoxesAllSeedWords)
                {
                    textbox.PasswordChar = '\0';
                }
                btnShowHideSeedWords.Text = "HIDE";
            }
            else
            {
                foreach (TextBox textbox in textBoxesAllSeedWords)
                {
                    textbox.PasswordChar = '●';
                }
                btnShowHideSeedWords.Text = "SHOW";
            }
        }
        #endregion

        #region select 12 or 24 word seed phrase
        private void Btn24SeedWords_Click(object sender, EventArgs e)
        {
            foreach (TextBox textbox in textBoxes13to24SeedWords)
            {
                textbox.Enabled = true;
                textbox.Text = "";
            }

            foreach (Control control in labels13to24SeedWords)
            {
                control.Enabled = true;
            }

            foreach (Control control in labels13to24WordPositions)
            {
                control.ForeColor = Color.DimGray;
            }

            foreach (Control control in labels9to16Merge)
            {
                control.ForeColor = Color.DimGray;
            }

            foreach (Control control in labels9to16ColorDecimal)
            {
                control.ForeColor = Color.DimGray;
            }

            foreach (Control control in labels9to16ColorHex)
            {
                control.ForeColor = Color.DimGray;
            }

            foreach (Control control in labels9to16ColorRGB)
            {
                control.ForeColor = Color.DimGray;
            }

            foreach (Control control in panels13to24SeedWords)
            {
                control.BackColor = Color.IndianRed;
            }

            foreach (Control control in buttons9to16Colours)
            {
                control.Text = "▔";
            }

            foreach (Control control in labelsColourNumbers9to16)
            {
                control.Enabled = true;
            }

            btn24SeedWords.Enabled = false;
            btn12SeedWords.Enabled = true;
            btn8Colours.Enabled = true;
            btn16Colours.Enabled = false;
        }

        private void Btn12SeedWords_Click(object sender, EventArgs e)
        {
            foreach (TextBox textbox in textBoxes13to24SeedWords)
            {
                textbox.Enabled = false;
                textbox.Text = "";
                if (textbox == activeSeedBox)
                {
                    activeSeedBox = textBoxSeedWord1;
                }
            }

            foreach (Control control in labels13to24SeedWords)
            {
                control.Enabled = false;
            }

            foreach (Control control in labels13to24WordPositions)
            {
                control.ForeColor = Color.Black;
                control.Text = "----";
            }

            foreach (Control control in labels9to16Merge)
            {
                control.ForeColor = Color.Black;
                control.Text = "------";
            }

            foreach (Control control in labels9to16ColorDecimal)
            {
                control.ForeColor = Color.Black;
                control.Text = "--------";
            }

            foreach (Control control in labels9to16ColorHex)
            {
                control.ForeColor = Color.Black;
                control.Text = "-------";
            }

            foreach (Control control in labels9to16ColorRGB)
            {
                control.ForeColor = Color.Black;
                control.Text = "---,---,---";
            }

            foreach (Control control in panels13to24SeedWords)
            {
                control.BackColor = Color.FromArgb(20, 20, 20);
            }

            foreach (Control control in buttons9to16Colours)
            {
                control.Text = "";
            }

            foreach (Control control in labelsColourNumbers9to16)
            {
                control.Enabled = false;
            }

            btn24SeedWords.Enabled = true;
            btn12SeedWords.Enabled = false;
            btn8Colours.Enabled = false;
            btn16Colours.Enabled = true;
        }
        #endregion

        #region autosuggest bip39 words and validate textboxes

        private void SeedTextBox_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                lblSeedPointer.Location = new Point(lblSeedPointer.Location.X, textBox.Location.Y - 8);
                activeSeedBox = textBox;
                SeedTextBox_TextChanged(textBox, e);
            }
        }

        private void SuggestionBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                activeSeedBox.Focus();
            }

        }

        private void SeedTextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                activeSeedBox = textBox;
                string typedText = textBox.Text;

                if (string.IsNullOrEmpty(typedText)) // textbox is empty - show full bip39 list
                {
                    suggestionBox.Items.Clear();
                    suggestionBox.Items.AddRange(bip39Words.Values.ToArray());
                }

                // Filter words that start with the typed text
                var suggestions = bip39Words.Values.Where(w => w.StartsWith(typedText)).ToList();

                if (suggestions.Count > 0)
                {
                    suggestionBox.Items.Clear();
                    suggestionBox.Items.AddRange(suggestions.ToArray());
                }
                else
                {
                    suggestionBox.Items.Clear();
                }

                #region show red/green indicator next to textbox and reset/show position in bip39 list
                if (!bip39Words.ContainsValue(textBox.Text))
                {
                    foreach (Control control in panels1to24SeedWords)
                    {
                        if (control.Location.Y == textBox.Location.Y)
                        {
                            control.BackColor = Color.IndianRed;
                            break;
                        }
                    }

                    int wordPositionInSeedPhrase = 1;

                    foreach (Control control in labelsAllSeedWords)
                    {
                        if (control.Location.Y == textBox.Location.Y)
                        {
                            wordPositionInSeedPhrase = Convert.ToInt16(control.Text);
                        }
                    }

                    DisplayWordPositionInBIP39List(wordPositionInSeedPhrase, "----");
                }
                else
                {
                    foreach (Control control in panels1to24SeedWords)
                    {
                        if (control.Location.Y == textBox.Location.Y)
                        {
                            control.BackColor = Color.OliveDrab;
                            break;
                        }
                    }

                    int wordPositionInBIP39List = FindWordNumber(textBox.Text);
                    int wordPositionInSeedPhrase = 1;

                    foreach (Control control in labelsAllSeedWords)
                    {
                        if (control.Location.Y == textBox.Location.Y)
                        {
                            wordPositionInSeedPhrase = Convert.ToInt16(control.Text);
                        }
                    }

                    DisplayWordPositionInBIP39List(wordPositionInSeedPhrase, wordPositionInBIP39List.ToString("D4"));
                }
                #endregion
            }
        }

        private void SeedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) // move control to the bip39 list
            {
                if (suggestionBox.SelectedItems.Count == 0)
                {
                    if (suggestionBox.Items.Count > 0)
                    {
                        suggestionBox.SelectedIndex = 0;
                    }
                }
                suggestionBox.Focus();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Left) // move control back to the textbox
            {
                activeSeedBox.Focus();
            }

            if (e.KeyCode == Keys.Down) // move down the bip39 list
            {
                if (suggestionBox.SelectedIndex < suggestionBox.Items.Count - 1)
                    suggestionBox.SelectedIndex++;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up) // move up the bip39 list
            {
                if (suggestionBox.SelectedIndex > 0)
                    suggestionBox.SelectedIndex--;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) // select highlighted word
            {
                InsertSelectedSuggestion((TextBox)sender);
                e.Handled = true;
            }
        }

        private void InsertSelectedSuggestion(TextBox textBox)
        {
            textBox.Text = suggestionBox.SelectedItem?.ToString() ?? string.Empty;
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void SuggestionBox_Click(object sender, EventArgs e)
        {
            if (activeSeedBox != null)
            {
                InsertSelectedSuggestion(activeSeedBox);
                activeSeedBox.Focus();

            }
        }

        private void SeedTextBox_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (!bip39Words.ContainsValue(textBox.Text))
                {
                    //     MessageBox.Show("Invalid word. Please enter a valid BIP-39 word.");
                    //     textBox.Focus();
                }
            }
        }

        #region if autocomplete suggestion box is visible and something is selected on it, stop tab key from tabbing, and instead use it to select (same behaviour as enter key)
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (suggestionBox.Visible && suggestionBox.SelectedItem != null && (keyData == Keys.Tab))
            {
                // Insert the suggestion when Tab is pressed
                var selectedTextBox = activeSeedBox;
                if (selectedTextBox != null)
                {
                    InsertSelectedSuggestion(selectedTextBox);
                    return true; // Prevent focus change
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }
        #endregion
        #endregion

        #endregion

        #region common

        #region load bip39 words
        void LoadBip39Words()
        {
            string[] words = File.ReadAllLines("bip39-wordlist.txt");
            for (int i = 0; i < words.Length; i++)
            {
                bip39Words.Add(i, words[i]);
            }
        }
        #endregion

        #region border around form
        private void Chromaseed_Paint(object sender, PaintEventArgs e)
        {
            using var pen = new Pen(Color.FromArgb(80, 80, 80), 1);
            var rect = ClientRectangle;
            rect.Inflate(-1, -1);
            e.Graphics.DrawPath(pen, GetRoundedRect(rect, 15));
        }

        private static GraphicsPath GetRoundedRect(Rectangle rectangle, int radius)
        {
            GraphicsPath path = new();
            path.AddArc(rectangle.X, rectangle.Y, radius, radius, 180, 90);
            path.AddArc(rectangle.Width - radius, rectangle.Y, radius, radius, 270, 90);
            path.AddArc(rectangle.Width - radius, rectangle.Height - radius, radius, radius, 0, 90);
            path.AddArc(rectangle.X, rectangle.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
        #endregion

        #region exit
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region rounded panels
        private void Panel_Paint(object? sender, PaintEventArgs e)
        {
            try
            {
                if (sender == null)
                {
                    return;
                }
                Panel panel = (Panel)sender;

                System.Drawing.Drawing2D.GraphicsPath path = new();
                int cornerRadius = 20;
                path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(panel.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(panel.Width - cornerRadius, panel.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(0, panel.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                path.CloseFigure();

                panel.Region = new Region(path);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Panel_Paint");
            }
        }
        #endregion

        #region error handler
        private void HandleException(Exception ex, string methodName)
        {
            string errorMessage;
            errorMessage = $"Error in {methodName}: {ex.Message}";

            const int MaxErrorMessageLength = 130;

            if (errorMessage.Length > MaxErrorMessageLength)
            {
                errorMessage = $"{errorMessage[..MaxErrorMessageLength]}...";
            }

            lblErrorMessage.Invoke((MethodInvoker)delegate
            {
                lblErrorMessage.Text = errorMessage;

            });
        }
        #endregion

        #endregion

        int FindWordNumber(string word)
        {
            // get the index associated with the given word
            if (bip39Words.ContainsValue(word))
            {
                return bip39Words.FirstOrDefault(x => x.Value == word).Key + 1;
            }

            return -1;
        }

        private void DisplayWordPositionInBIP39List(int intPosition, string newText)
        {
            // Construct the label name
            string labelName = "lblWord" + intPosition.ToString() + "Position";

            // Find the label by its name

            if (this.Controls.Find(labelName, true).FirstOrDefault() is Label label)
            {
                label.Text = newText;
            }
            else
            {
                MessageBox.Show($"Label '{labelName}' not found.");
            }
        }

        private void WordPosition_TextChanged(object sender, EventArgs e)
        {

            // construct word position string for first 12 words
            //lblWordPositionString.Text = lblWord1Position.Text + lblWord2Position.Text + lblWord3Position.Text + lblWord4Position.Text + lblWord5Position.Text + lblWord6Position.Text + lblWord7Position.Text + lblWord8Position.Text + lblWord9Position.Text + lblWord10Position.Text + lblWord11Position.Text + lblWord12Position.Text;

            //if (!btn24SeedWords.Enabled) // and the rest if 24 seed words
            //{
            //    lblWordPositionString.Text = lblWordPositionString.Text + lblWord13Position.Text + lblWord14Position.Text + lblWord15Position.Text + lblWord16Position.Text + lblWord17Position.Text + lblWord18Position.Text + lblWord19Position.Text + lblWord20Position.Text + lblWord21Position.Text + lblWord22Position.Text + lblWord23Position.Text + lblWord24Position.Text;
            //}

            // split into groups of 6 characters for first 12 words
            lblMerge1.Text = lblWord1Position.Text + lblWord2Position.Text[..2];
            lblMerge2.Text = string.Concat(lblWord2Position.Text.AsSpan(2, 2), lblWord3Position.Text);
            lblMerge3.Text = lblWord4Position.Text + lblWord5Position.Text[..2];
            lblMerge4.Text = string.Concat(lblWord5Position.Text.AsSpan(2, 2), lblWord6Position.Text);
            lblMerge5.Text = lblWord7Position.Text + lblWord8Position.Text[..2];
            lblMerge6.Text = string.Concat(lblWord8Position.Text.AsSpan(2, 2), lblWord9Position.Text);
            lblMerge7.Text = lblWord10Position.Text + lblWord11Position.Text[..2];
            lblMerge8.Text = string.Concat(lblWord11Position.Text.AsSpan(2, 2), lblWord12Position.Text);

            if (!btn24SeedWords.Enabled) // and the rest if 24 seed words
            {
                lblMerge9.Text = lblWord13Position.Text + lblWord14Position.Text[..2];
                lblMerge10.Text = string.Concat(lblWord14Position.Text.AsSpan(2, 2), lblWord15Position.Text);
                lblMerge11.Text = lblWord16Position.Text + lblWord17Position.Text[..2];
                lblMerge12.Text = string.Concat(lblWord17Position.Text.AsSpan(2, 2), lblWord18Position.Text);
                lblMerge13.Text = lblWord19Position.Text + lblWord20Position.Text[..2];
                lblMerge14.Text = string.Concat(lblWord20Position.Text.AsSpan(2, 2), lblWord21Position.Text);
                lblMerge15.Text = lblWord22Position.Text + lblWord23Position.Text[..2];
                lblMerge16.Text = string.Concat(lblWord23Position.Text.AsSpan(2, 2), lblWord24Position.Text);
            }
        }

        private void LblMerge_TextChanged(object sender, EventArgs e)
        {
            if (!btn12SeedWords.Enabled) // 12 words
            {
                lblColorDecimal1.Text = "00" + lblMerge1.Text;
                lblColorDecimal2.Text = "02" + lblMerge2.Text;
                lblColorDecimal3.Text = "04" + lblMerge3.Text;
                lblColorDecimal4.Text = "06" + lblMerge4.Text;
                lblColorDecimal5.Text = "08" + lblMerge5.Text;
                lblColorDecimal6.Text = "10" + lblMerge6.Text;
                lblColorDecimal7.Text = "12" + lblMerge7.Text;
                lblColorDecimal8.Text = "14" + lblMerge8.Text;
            }
            else // 24 words
            {
                lblColorDecimal1.Text = "00" + lblMerge1.Text;
                lblColorDecimal2.Text = "01" + lblMerge2.Text;
                lblColorDecimal3.Text = "02" + lblMerge3.Text;
                lblColorDecimal4.Text = "03" + lblMerge4.Text;
                lblColorDecimal5.Text = "04" + lblMerge5.Text;
                lblColorDecimal6.Text = "05" + lblMerge6.Text;
                lblColorDecimal7.Text = "06" + lblMerge7.Text;
                lblColorDecimal8.Text = "07" + lblMerge8.Text;
                lblColorDecimal9.Text = "08" + lblMerge9.Text;
                lblColorDecimal10.Text = "09" + lblMerge10.Text;
                lblColorDecimal11.Text = "10" + lblMerge11.Text;
                lblColorDecimal12.Text = "11" + lblMerge12.Text;
                lblColorDecimal13.Text = "12" + lblMerge13.Text;
                lblColorDecimal14.Text = "13" + lblMerge14.Text;
                lblColorDecimal15.Text = "14" + lblMerge15.Text;
                lblColorDecimal16.Text = "15" + lblMerge16.Text;
            }
        }

        private void LblColorDecimal_TextChanged(object sender, EventArgs e)
        {
            for (int i = 1; i <= 16; i++)
            {
                // find the decimal and hex labels

                if (this.Controls.Find($"lblColorDecimal{i}", true).FirstOrDefault() is Label decimalLabel && this.Controls.Find($"lblColorHex{i}", true).FirstOrDefault() is Label hexLabel)
                {
                    // Parse the decimal value (assuming it's an 8-digit number)
                    if (int.TryParse(decimalLabel.Text, out int decimalValue))
                    {
                        // Convert to hexadecimal and store in the hex label
                        hexLabel.Text = "#" + decimalValue.ToString("X6"); // "X8" for 8-character uppercase hex string

                        if (btnRGBorHex.Text == "RGB")
                        {
                            if (this.Controls.Find($"textBoxColor{i}", true).FirstOrDefault() is TextBox textBox)
                            {
                                textBox.Text = "#" + decimalValue.ToString("X6");
                            }
                            else
                            {
                                MessageBox.Show($"TextBox textBoxColor{i} not found.");
                            }
                        }
                    }
                    else
                    {
                        // Handle invalid decimal input if necessary
                        hexLabel.Text = "-------";
                    }

                }
            }
        }

        private void LblColorHex_TextChanged(object sender, EventArgs e)
        {
            for (int i = 1; i <= 16; i++)
            {
                // Find the hex and RGB labels

                if (this.Controls.Find($"lblColorHex{i}", true).FirstOrDefault() is Label hexLabel && this.Controls.Find($"lblColorRGB{i}", true).FirstOrDefault() is Label rgbLabel)
                {
                    string hexValue = hexLabel.Text;

                    // Validate and remove '#' from hex string if necessary
                    if (!string.IsNullOrEmpty(hexValue) && hexValue.StartsWith("#") && hexValue.Length == 7)
                    {
                        // Convert hex to RGB
                        int r = Convert.ToInt32(hexValue.Substring(1, 2), 16); // Red (chars 1 and 2)
                        int g = Convert.ToInt32(hexValue.Substring(3, 2), 16); // Green (chars 3 and 4)
                        int b = Convert.ToInt32(hexValue.Substring(5, 2), 16); // Blue (chars 5 and 6)

                        // Assign the RGB value in the format "R, G, B"
                        rgbLabel.Text = $"{r},{g},{b}";

                        if (btnRGBorHex.Text == "HEX")
                        {
                            if (this.Controls.Find($"textBoxColor{i}", true).FirstOrDefault() is TextBox textBox)
                            {
                                textBox.Text = $"{r},{g},{b}";
                            }
                            else
                            {
                                MessageBox.Show($"TextBox textBoxColor{i} not found.");
                            }
                        }
                    }
                    else
                    {
                        // Handle invalid hex format
                        rgbLabel.Text = "---,---,---";
                        if (Controls.Find($"textBoxColor{i}", true).FirstOrDefault() is TextBox textBox)
                        {
                            textBox.Text = "---,---,---";
                        }
                    }
                }
            }
        }

        private void LblColorRGB_TextChanged(object sender, EventArgs e)
        {
            for (int i = 1; i <= 16; i++)
            {
                if (this.Controls.Find($"lblColorRGB{i}", true).FirstOrDefault() is Label RGBLabel && this.Controls.Find($"btnColor{i}", true).FirstOrDefault() is RJButton btnColor)
                {
                    if (RGBLabel.Text == "---,---,---")
                    {
                        btnColor.Text = "▔";
                        btnColor.BackColor = Color.FromArgb(20, 20, 20);
                    }
                    else
                    {
                        btnColor.Text = "";

                        string colorString = RGBLabel.Text;

                        // Split the string by commas
                        string[] rgbValues = colorString.Split(',');

                        if (rgbValues.Length == 3)
                        {
                            // Parse the RGB values from the string
                            int r = int.Parse(rgbValues[0]);
                            int g = int.Parse(rgbValues[1]);
                            int b = int.Parse(rgbValues[2]);

                            // Set the BackColor using the parsed RGB values
                            btnColor.BackColor = Color.FromArgb(r, g, b);
                        }

                    }

                }
            }
        }

        private void btnRGBorHex_Click(object sender, EventArgs e)
        {
            if (btnRGBorHex.Text == "HEX")
            {
                btnRGBorHex.Text = "RGB";
                LblColorDecimal_TextChanged(sender, e);
            }
            else
            {
                btnRGBorHex.Text = "HEX";
                LblColorHex_TextChanged(sender, e);
            }
        }
    }
}