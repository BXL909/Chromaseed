//!░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
//+++CHROMASEED
//!● Homepage.......... https://chromaseed.btcdir.org
//!● Version history... tbc
//!● Download.......... tbc
//
//TODO LIST______________________________________________________________________________________________
//
//BUG LIST_______________________________________________________________________________________________
//
//!░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░

#region Using
using CustomControls.RJControls;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
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
        readonly Control[] labelsAllColours;
        readonly Control[] labels13to24SeedWords;
        readonly Control[] labels13to24WordPositions;
        readonly Control[] labels9to16Merge;
        readonly Control[] labelsAllColorDecimal;
        readonly Control[] labels9to16ColorDecimal;
        readonly Control[] labels1to8ColorHex;
        readonly Control[] labels9to16ColorHex;
        readonly Control[] labels9to16ColorRGB;
        readonly Control[] panels13to24SeedWords;
        readonly Control[] panels1to24SeedWords;
        readonly Control[] buttons9to16Colours;
        readonly Control[] labelsColourNumbers9to16;
        readonly TextBox[] textBoxesAllColours;
        readonly Control[] panels1to16Colors;
        readonly Control[] panels1to8Colors;
        readonly Control[] panels9to16Colors;
        readonly TextBox[] textBoxesColours1to8;
        readonly TextBox[] textBoxesColours9to16;
        readonly Control[] panelsSwatchesForColors9To16;
        readonly Control[] patternButtons;
        readonly Control[] controlsToColor;

        #region pattern specific variables
        string phrase = "Chancellor on brink of second bailout for banks";
        string textGridPhrase = "bxl909.github.io ";
        int noiseSize = 3;
        int radialAngle = 64; 
        int radialRays = 128;
        int hexagonComplexity = 3;
        int distortionAmount = 25;
        int mosaicNumPoints = 100;
        #endregion

        bool eightColours = false;
        List<Color> colorList = new();
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

            Control[] panelsToBeRounded = new Control[] { panelMenu, panelSeedWords, panelSuggestionBoxSurround, panelColours, panelWordsContainer, panelColoursContainer, panelStripesLeft, panelStripesLeftContainer, panelStripesRight, panelStripesRightContainer, panelCirclesLeft, panelCirclesLeftContainer, panelCirclesRight, panelCirclesRightContainer, panelSquaresLeft, panelSquaresLeftContainer, panelSquaresRight, panelSquaresRightContainer, panelRadialLeft, panelRadialLeftContainer, panelRadialRight, panelRadialRightContainer, panelNoiseLeftContainer, panelNoiseRightContainer, panelNoiseLeft, panelNoiseRight, panelHexagonLeftContainer, panelHexagonsLeft, panelHexagonsRight, panelHexagonsRightContainer, panelSpiralRight, panelSpiralRightContainer, panelSpiralLeft, panelSpiralLeftContainer, panelMandelbrotLeft, panel1MandelbrotLeftContainer, panelMandelbrotRight, panelMandelbrotRightContainer, panelSymbolsLeft, panelSymbolsLeftContainer, panelSymbolsRight, panelSymbolsRightContainer, panelBrinkLeft, panelBrinkLeftContainer, panelBrinkRight, panelBrinkRightContainer, panelSquiggleLeft, panelSquiggleLeftContainer, panelSquiggleRight, panelSquiggleRightContainer, panelTilesLeft, panelTilesLeftContainer, panelTilesRight, panelTilesRightContainer, panelMultibrotLeft, panelMultibrotLeftContainer, panelMultibrotRight, panelMultibrotRightContainer, panelPhoenixLeft, panelPhoenixLeftContainer, panelPhoenixRight, panelPhoenixRightContainer, panelTricornLeft, panelTricornLeftContainer, panelTricornRight, panelTricornRightContainer };

            foreach (Control control in panelsToBeRounded)
            {
                control.Paint += Panel_Paint;
            }
            #endregion

            #region set up groups of controls
            textBoxesAllSeedWords = new TextBox[] { textBoxSeedWord1, textBoxSeedWord2, textBoxSeedWord3, textBoxSeedWord4, textBoxSeedWord5, textBoxSeedWord6, textBoxSeedWord7, textBoxSeedWord8, textBoxSeedWord9, textBoxSeedWord10, textBoxSeedWord11, textBoxSeedWord12, textBoxSeedWord13, textBoxSeedWord14, textBoxSeedWord15, textBoxSeedWord16, textBoxSeedWord17, textBoxSeedWord18, textBoxSeedWord19, textBoxSeedWord20, textBoxSeedWord21, textBoxSeedWord22, textBoxSeedWord23, textBoxSeedWord24 };
            textBoxes13to24SeedWords = new TextBox[] { textBoxSeedWord13, textBoxSeedWord14, textBoxSeedWord15, textBoxSeedWord16, textBoxSeedWord17, textBoxSeedWord18, textBoxSeedWord19, textBoxSeedWord20, textBoxSeedWord21, textBoxSeedWord22, textBoxSeedWord23, textBoxSeedWord24 };
            labelsAllSeedWords = new Control[] { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12, label13, label14, label15, label16, label17, label18, label19, label20, label21, label22, label23, label24 };
            labelsAllColours = new Control[] { lblColour1, lblColour2, lblColour3, lblColour4, lblColour5, lblColour6, lblColour7, lblColour8, lblColour9, lblColour10, lblColour11, lblColour12, lblColour13, lblColour14, lblColour15, lblColour16 };
            labels13to24SeedWords = new Control[] { label13, label14, label15, label16, label17, label18, label19, label20, label21, label22, label23, label24 };
            labels13to24WordPositions = new Control[] { lblWord13Position, lblWord14Position, lblWord15Position, lblWord16Position, lblWord17Position, lblWord18Position, lblWord19Position, lblWord20Position, lblWord21Position, lblWord22Position, lblWord23Position, lblWord24Position };
            labels9to16Merge = new Control[] { lblMerge9, lblMerge10, lblMerge11, lblMerge12, lblMerge13, lblMerge14, lblMerge15, lblMerge16 };
            labels9to16ColorDecimal = new Control[] { lblColorDecimal9, lblColorDecimal10, lblColorDecimal11, lblColorDecimal12, lblColorDecimal13, lblColorDecimal14, lblColorDecimal15, lblColorDecimal16 };
            labelsAllColorDecimal = new Control[] { lblColorDecimal1, lblColorDecimal2, lblColorDecimal3, lblColorDecimal4, lblColorDecimal5, lblColorDecimal6, lblColorDecimal7, lblColorDecimal8, lblColorDecimal9, lblColorDecimal10, lblColorDecimal11, lblColorDecimal12, lblColorDecimal13, lblColorDecimal14, lblColorDecimal15, lblColorDecimal16 };
            labels1to8ColorHex = new Control[] { lblColorHex1, lblColorHex2, lblColorHex3, lblColorHex4, lblColorHex5, lblColorHex6, lblColorHex7, lblColorHex8 };
            labels9to16ColorHex = new Control[] { lblColorHex9, lblColorHex10, lblColorHex11, lblColorHex12, lblColorHex13, lblColorHex14, lblColorHex15, lblColorHex16 };
            labels9to16ColorRGB = new Control[] { lblColorRGB9, lblColorRGB10, lblColorRGB11, lblColorRGB12, lblColorRGB13, lblColorRGB14, lblColorRGB15, lblColorRGB16 };
            panels1to24SeedWords = new Control[] { panelSeedWordColor1, panelSeedWordColor2, panelSeedWordColor3, panelSeedWordColor4, panelSeedWordColor5, panelSeedWordColor6, panelSeedWordColor7, panelSeedWordColor8, panelSeedWordColor9, panelSeedWordColor10, panelSeedWordColor11, panelSeedWordColor12, panelSeedWordColor13, panelSeedWordColor14, panelSeedWordColor15, panelSeedWordColor16, panelSeedWordColor17, panelSeedWordColor18, panelSeedWordColor19, panelSeedWordColor20, panelSeedWordColor21, panelSeedWordColor22, panelSeedWordColor23, panelSeedWordColor24 };
            panels13to24SeedWords = new Control[] { panelSeedWordColor13, panelSeedWordColor14, panelSeedWordColor15, panelSeedWordColor16, panelSeedWordColor17, panelSeedWordColor18, panelSeedWordColor19, panelSeedWordColor20, panelSeedWordColor21, panelSeedWordColor22, panelSeedWordColor23, panelSeedWordColor24 };
            buttons9to16Colours = new Control[] { btnColor9, btnColor10, btnColor11, btnColor12, btnColor13, btnColor14, btnColor15, btnColor16 };
            labelsColourNumbers9to16 = new Control[] { lblColour9, lblColour10, lblColour11, lblColour12, lblColour13, lblColour14, lblColour15, lblColour16 };
            textBoxesAllColours = new TextBox[] { textBoxColor1, textBoxColor2, textBoxColor3, textBoxColor4, textBoxColor5, textBoxColor6, textBoxColor7, textBoxColor8, textBoxColor9, textBoxColor10, textBoxColor11, textBoxColor12, textBoxColor13, textBoxColor14, textBoxColor15, textBoxColor16 };
            textBoxesColours1to8 = new TextBox[] { textBoxColor1, textBoxColor2, textBoxColor3, textBoxColor4, textBoxColor5, textBoxColor6, textBoxColor7, textBoxColor8 };
            textBoxesColours9to16 = new TextBox[] { textBoxColor9, textBoxColor10, textBoxColor11, textBoxColor12, textBoxColor13, textBoxColor14, textBoxColor15, textBoxColor16 };
            panels1to16Colors = new Control[] { panelColor1, panelColor2, panelColor3, panelColor4, panelColor5, panelColor6, panelColor7, panelColor8, panelColor9, panelColor10, panelColor11, panelColor12, panelColor13, panelColor14, panelColor15, panelColor16 };
            panels1to8Colors = new Control[] { panelColor1, panelColor2, panelColor3, panelColor4, panelColor5, panelColor6, panelColor7, panelColor8 };
            panels9to16Colors = new Control[] { panelColor9, panelColor10, panelColor11, panelColor12, panelColor13, panelColor14, panelColor15, panelColor16 };
            panelsSwatchesForColors9To16 = new Control[] { panelSwatch2, panelSwatch4, panelSwatch6, panelSwatch8, panelSwatch10, panelSwatch12, panelSwatch14, panelSwatch16 };
            patternButtons = new Control[] { btnMenuCircles, btnMenuSwatches, btnMenuSquares, btnMenuMandelbrot, btnMenuSpiral, btnMenuRadial, btnMenuNoise, btnMenuHexagons, btnMenuSquiggle, btnMenuBrink, btnMenuSymbols, btnMenuTiles, btnMenuMultibrot, btnMenuPhoenix, btnMenuTricorn, btnMenuJulia, btnMenuTextGrid };
            controlsToColor = new Control[] { panelSquaresLeft, panelCirclesLeft, panelStripesLeft, panelRGBLabels, panelHexLabels };
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

        #region WORD AND COLOUR SELECTION

        #region switch between converting from seed to colours or colours to seed
        private void BtnConvert_Click(object sender, EventArgs e)
        {
            if (btnConvert.Text == "▶")
            {
                #region convert colours to words
                foreach (TextBox textbox in textBoxesAllSeedWords)
                {
                    textbox.Text = string.Empty;
                }
                btnConvert.Padding = new Padding(0, 0, 0, 0);
                btnConvert.Text = "◀";
                label25.Text = "◀";
                label26.Text = "◀";
                label26.ForeColor = Color.DarkGray;
                panelColoursContainer.BackColor = Color.DarkGray;
                label25.ForeColor = Color.FromArgb(80, 80, 80);
                panelWordsContainer.BackColor = Color.FromArgb(80, 80, 80);
                suggestionBox.Visible = false;

                foreach (TextBox textbox in textBoxesAllColours)
                {
                    textbox.Text = "";
                }
                if (!btn8Colours.Enabled)
                {
                    foreach (TextBox textbox in textBoxesColours1to8)
                    {
                        textbox.Text = "#";
                    }
                }
                else
                {
                    foreach (TextBox textbox in textBoxesAllColours)
                    {
                        textbox.Text = "#";
                    }
                }

                if (!btn8Colours.Enabled)
                {
                    foreach (TextBox textbox in textBoxesColours9to16)
                    {
                        textbox.Text = string.Empty;
                    }
                }

                foreach (Control control in labelsAllColorDecimal)
                {
                    control.Text = "--------";
                }
                lblSeedPointer.Visible = false;
                lblColourPointer.Visible = true;
                #endregion
            }
            else
            {
                #region convert Words to Colours
                btnConvert.Padding = new Padding(4, 0, 0, 0);
                btnConvert.Text = "▶";
                label25.Text = "▶";
                label26.Text = "▶";
                label25.ForeColor = Color.DarkGray;
                panelWordsContainer.BackColor = Color.DarkGray;
                label26.ForeColor = Color.FromArgb(80, 80, 80);
                panelColoursContainer.BackColor = Color.FromArgb(80, 80, 80);
                suggestionBox.Visible = true;
                foreach (TextBox textbox in textBoxesAllColours)
                {
                    textbox.Text = string.Empty;
                }
                foreach (TextBox textbox in textBoxesAllSeedWords)
                {
                    textbox.Text = string.Empty;
                }
                foreach (Control control in labelsAllColorDecimal)
                {
                    control.Text = "--------";
                }
                lblSeedPointer.Visible = true;
                lblColourPointer.Visible = false;
                #endregion
            }
        }
        #endregion

        #region SEED PHRASE INPUT

        #region show or hide seed words
        private void BtnShowWords_Click(object sender, EventArgs e)
        {
            foreach (TextBox textbox in textBoxesAllSeedWords)
            {
                textbox.PasswordChar = '\0';
            }
            btnHideWords.Enabled = true;
            btnShowWords.Enabled = false;
        }

        private void BtnHideWords_Click(object sender, EventArgs e)
        {
            foreach (TextBox textbox in textBoxesAllSeedWords)
            {
                textbox.PasswordChar = '●';
            }
            btnHideWords.Enabled = false;
            btnShowWords.Enabled = true;
        }
        #endregion

        #region select 12 or 24 word seed phrase
        private void Btn24SeedWords_Click(object sender, EventArgs e)
        {
            if (btnConvert.Text == "▶")
            {
                btn24SeedWords.Enabled = false;
                btn12SeedWords.Enabled = true;
                btn8Colours.Enabled = true;
                btn16Colours.Enabled = false;

                foreach (Control control in buttons9to16Colours)
                {
                    control.Enabled = true;
                    control.Text = "▔";
                }

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

                foreach (Control control in labelsColourNumbers9to16)
                {
                    control.Enabled = true;
                }

                foreach (TextBox textbox in textBoxesColours9to16)
                {
                    textbox.Enabled = true;
                }
                LblMerge_TextChanged(sender, e);
            }
        }

        private void Btn12SeedWords_Click(object sender, EventArgs e)
        {
            if (btnConvert.Text == "▶")
            {
                btn24SeedWords.Enabled = true;
                btn12SeedWords.Enabled = false;
                btn8Colours.Enabled = false;
                btn16Colours.Enabled = true;

                if (lblSeedPointer.Location.Y > 283)
                {
                    lblSeedPointer.Location = new Point(lblSeedPointer.Location.X, textBoxSeedWord1.Location.Y - 8);
                }

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
                    control.Enabled = false;
                    control.Text = "";
                }

                foreach (Control control in labelsColourNumbers9to16)
                {
                    control.Enabled = false;
                }

                foreach (TextBox textbox in textBoxesColours9to16)
                {
                    textbox.Enabled = false;
                }
                LblMerge_TextChanged(sender, e);

                if (btnDummyButton.Text == "allcoloursset")
                {
                    btnDummyButton.Text = "";
                    btnDummyButton.Text = "allcoloursset";
                }
            }
        }
        #endregion

        #region autosuggest bip39 words and validate textboxes

        private void SeedTextBox_Enter(object sender, EventArgs e)
        {
            if (btnConvert.Text == "◀")
            {
                btnDummyButton.Focus();
                return;
            }

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
            if (btnConvert.Text == "▶")
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

        #region word positions

        #region find word position in bip39 list
        int FindWordNumber(string word)
        {
            // get the index associated with the given word
            if (bip39Words.ContainsValue(word))
            {
                return bip39Words.FirstOrDefault(x => x.Value == word).Key + 1;
            }

            return -1;
        }
        #endregion

        #region display word position
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
        #endregion

        #region merge the word positions
        private void WordPosition_TextChanged(object sender, EventArgs e)
        {
            if (btnConvert.Text == "▶")
            {
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
            else
            {
                int wordCount = 12;

                if (!btn16Colours.Enabled)
                {
                    wordCount = 24;
                }
                // Loop through the labels and textboxes
                for (int i = 1; i <= wordCount; i++)
                {
                    // Find the corresponding label (lblWord1Position through lblWord24Position)
                    if (this.Controls.Find($"lblWord{i}Position", true).FirstOrDefault() is Label wordPositionLabel)
                    {
                        // Find the corresponding text box (textBoxSeedWord1 through textBoxSeedWord24)
                        if (this.Controls.Find($"textBoxSeedWord{i}", true).FirstOrDefault() is TextBox seedTextBox)
                        {
                            // Get the 4-digit number from the label
                            if (int.TryParse(wordPositionLabel.Text, out int positionNumber))
                            {
                                // Find the corresponding word in the bip39Words dictionary
                                if (bip39Words.TryGetValue(positionNumber - 1, out var bip39Word))
                                {
                                    seedTextBox.Text = bip39Word;
                                }
                                else
                                {
                                    seedTextBox.Text = "Unknown";
                                }
                            }
                            else
                            {
                                seedTextBox.Text = "Invalid";
                            }
                        }
                    }
                }

            }
        }
        #endregion

        #region assign sequential numbers
        private void LblMerge_TextChanged(object sender, EventArgs e)
        {
            if (btnConvert.Text == "▶")
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
            else
            {
                int wordCount;
                int colourCount;
                if (!btn8Colours.Enabled)
                {
                    wordCount = 12;
                    colourCount = 8;
                }
                else
                {
                    wordCount = 24;
                    colourCount = 16;
                }
                // Combine the text from lblMerge1 through lblMerge16 into one long string
                string combinedString = "";
                for (int i = 1; i <= colourCount; i++)
                {
                    if (this.Controls.Find($"lblMerge{i}", true).FirstOrDefault() is Label mergeLabel)
                    {
                        combinedString += mergeLabel.Text;  // Concatenate the text from each label
                    }
                }

                // Distribute the combined string into the lblWord1Position through lblWord24Position labels
                for (int i = 1; i <= wordCount; i++)
                {
                    if (this.Controls.Find($"lblWord{i}Position", true).FirstOrDefault() is Label wordLabel)
                    {
                        // Ensure there are enough characters left in the combined string
                        if (combinedString.Length >= (i * 4))
                        {
                            // Extract 4 characters from the combined string and assign to the label
                            wordLabel.Text = combinedString.Substring((i - 1) * 4, 4);
                        }
                        else
                        {
                            // If there are fewer than 4 characters remaining, assign whatever is left
                            wordLabel.Text = combinedString[((i - 1) * 4)..];
                        }
                    }
                }

            }
        }
        #endregion

        #endregion

        #endregion

        #region colours

        #region display the hex value
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

                        if (!btnHex.Enabled)
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
                        hexLabel.Text = "-------";
                        if (!btnHex.Enabled)
                        {
                            if (this.Controls.Find($"textBoxColor{i}", true).FirstOrDefault() is TextBox textBox)
                            {
                                textBox.Text = "#";
                            }
                        }
                    }
                }
            }

            if (!btn8Colours.Enabled)
            {
                foreach (TextBox textBox in textBoxesColours9to16)
                {
                    textBox.Text = "";
                }
            }

            if (btnConvert.Text == "◀")
            {
                bool allColoursSet = true;

                int colorCount = 8;

                foreach (Control control in labels1to8ColorHex)
                {
                    if (control.Text == "-------")
                    {
                        allColoursSet = false;
                    }
                }

                if (!btn16Colours.Enabled)
                {
                    foreach (Control control in labels9to16ColorHex)
                    {
                        if (control.Text == "-------")
                        {
                            allColoursSet = false;
                        }
                    }

                    colorCount = 16;
                }

                if (allColoursSet)
                {
                    // Create a list to store the numeric values from lblColorDecimal labels
                    List<string> decimalNumbers = new();

                    // Loop through the labels and extract the 8-digit number from each
                    for (int i = 1; i <= colorCount; i++)
                    {
                        // Find the label
                        if (this.Controls.Find($"lblColorDecimal{i}", true).FirstOrDefault() is Label decimalLabel)
                        {
                            // Extract the number, and ensure it is left-padded with zeros to 8 digits
                            if (int.TryParse(decimalLabel.Text, out int number))
                            {
                                string paddedNumber = number.ToString("D8");  // Left-fill with zeros to 8 digits
                                decimalNumbers.Add(paddedNumber);
                            }
                            else
                            {
                                MessageBox.Show($"Invalid number in lblColorDecimal{i}");
                                return;
                            }
                        }
                    }

                    // sort the numbers numerically as strings (since they are padded)
                    decimalNumbers.Sort();

                    // Remove the first two digits from each number and store the 6-digit results
                    List<string> sixDigitNumbers = decimalNumbers.Select(num => num[2..]).ToList();

                    // Assign the 6-digit numbers to the lblMerge1 through lblMerge16 labels
                    for (int i = 1; i <= colorCount; i++)
                    {
                        if (this.Controls.Find($"lblMerge{i}", true).FirstOrDefault() is Label mergeLabel)
                        {
                            mergeLabel.Text = sixDigitNumbers[i - 1]; // Assign the 6-digit number to the label
                        }
                    }
                }
            }
        }
        #endregion

        #region display rgb value
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
                        rgbLabel.Text = $"{r:D3},{g:D3},{b:D3}";

                        if (!btnRGB.Enabled)
                        {
                            if (this.Controls.Find($"textBoxColor{i}", true).FirstOrDefault() is TextBox textBox)
                            {
                                textBox.Text = $"{r:D3},{g:D3},{b:D3}";
                            }
                            else
                            {
                                MessageBox.Show($"TextBox textBoxColor{i} not found.");
                            }
                        }

                        if (btnConvert.Text == "◀")
                        {
                            string hex = hexLabel.Text[1..];

                            // Convert hex to decimal
                            int decimalValue = Convert.ToInt32(hex, 16);

                            string labelName = "lblColorDecimal" + i;

                            if (this.Controls.Find(labelName, true).FirstOrDefault() is Label label)
                            {
                                label.Text = decimalValue.ToString("D8");
                            }
                        }
                    }
                    else
                    {
                        rgbLabel.Text = "---,---,---";
                        if (this.Controls.Find($"textBoxColor{i}", true).FirstOrDefault() is TextBox textBox)
                        {
                            textBox.Text = "";
                        }
                    }
                }
            }

            if (!btn8Colours.Enabled)
            {
                foreach (TextBox textBox in textBoxesColours9to16)
                {
                    textBox.Text = "";
                }
            }
        }
        #endregion

        #region colour the colour buttons
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

                    if (btnConvert.Text == "◀")
                    {
                        if (!btnRGB.Enabled)
                        {
                            //convert to hex and copy to hex labld
                            string[] rgbParts = RGBLabel.Text.Split(',');

                            if (rgbParts.Length == 3)
                            {
                                // Parse the R, G, and B values, ensure they are valid integers
                                if (int.TryParse(rgbParts[0].Trim(), out int r) && int.TryParse(rgbParts[1].Trim(), out int g) && int.TryParse(rgbParts[2].Trim(), out int b))
                                {
                                    // Ensure the RGB values are in the valid range (0-255)
                                    if (r >= 0 && r <= 255 && g >= 0 && g <= 255 && b >= 0 && b <= 255)
                                    {
                                        // Convert RGB to Hex
                                        string hexValue = $"#{r:X2}{g:X2}{b:X2}"; // Converts RGB to a Hex string in the format "#RRGGBB"

                                        // Assign the hex value to the corresponding label
                                        string labelName = $"lblColorHex{i}";
                                        if (this.Controls.Find(labelName, true).FirstOrDefault() is Label hexLabel)
                                        {
                                            hexLabel.Text = hexValue;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // if all colours are populated enabled the patterns
            int numberOfColours = 8;
            if (!btn16Colours.Enabled)
            {
                numberOfColours = 16;
            }

            bool allColoursSet = true;

            for (int i = 1; i <= numberOfColours; i++)
            {
                if (this.Controls.Find($"lblColorRGB{i}", true).FirstOrDefault() is Label RGBLabel)
                {
                    if (RGBLabel.Text == "---,---,---")
                    {
                        allColoursSet = false;
                    }
                }
            }

            if (allColoursSet)
            {
                btnDummyButton.Text = "allcoloursset";

            }
            else
            {
                btnDummyButton.Text = "";

            }
        }
        #endregion

        #endregion

        #region COLOUR INPUT

        #region switch between rgb and hex
        private void BtnRGB_Click(object sender, EventArgs e)
        {
            btnRGB.Enabled = false;
            btnHex.Enabled = true;
            LblColorHex_TextChanged(sender, e);
        }

        private void BtnHex_Click(object sender, EventArgs e)
        {
            btnRGB.Enabled = true;
            btnHex.Enabled = false;
            LblColorDecimal_TextChanged(sender, e);
        }
        #endregion

        #region switch between 8 and 16 colours
        private void Btn8Colours_Click(object sender, EventArgs e)
        {
            if (btnConvert.Text == "▶")
            {
                return;
            }

            btn8Colours.Enabled = false;
            btn16Colours.Enabled = true;

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
                control.Enabled = false;
                control.Text = "";
            }

            foreach (Control control in labelsColourNumbers9to16)
            {
                control.Enabled = false;
            }

            foreach (TextBox textbox in textBoxesColours9to16)
            {
                textbox.Enabled = false;
                textbox.Text = "";
            }

            btn24SeedWords.Enabled = true;
            btn12SeedWords.Enabled = false;
            btn8Colours.Enabled = false;
            btn16Colours.Enabled = true;

            if (btnDummyButton.Text == "allcoloursset")
            {
                btnDummyButton.Text = "";
                btnDummyButton.Text = "allcoloursset";
            }
        }

        private void Btn16Colours_Click(object sender, EventArgs e)
        {
            if (btnConvert.Text == "▶")
            {
                return;
            }

            btn8Colours.Enabled = true;
            btn16Colours.Enabled = false;

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
                control.Enabled = true;
                control.Text = "▔";
            }

            foreach (Control control in labelsColourNumbers9to16)
            {
                control.Enabled = true;
            }

            foreach (TextBox textbox in textBoxesColours9to16)
            {
                textbox.Enabled = true;
                textbox.Text = "#";
            }

            btn24SeedWords.Enabled = false;
            btn12SeedWords.Enabled = true;
            btn8Colours.Enabled = true;
            btn16Colours.Enabled = false;
        }
        #endregion

        private void TextBoxColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnConvert.Text == "▶")
            {
                e.Handled = true;
                return;
            }
            else
            {
                if (!btnHex.Enabled)
                {
                    TextBox textBox = (TextBox)sender;

                    // Allow Backspace
                    if (e.KeyChar == (char)Keys.Back)
                    {
                        // Prevent user from deleting the #
                        if (textBox.SelectionStart == 1)
                        {
                            e.Handled = true;
                        }
                        return;
                    }

                    // Only allow input if there are less than 6 characters after #
                    if (textBox.Text.Length >= 7 && textBox.SelectionStart > 0)
                    {
                        e.Handled = true;
                        return;
                    }

                    // Allow hex characters (0-9, A-F, a-f) and only after #
                    if (textBox.SelectionStart > 0 &&
                        !char.IsControl(e.KeyChar) &&
                        !Uri.IsHexDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    TextBox? textBox = sender as TextBox;

                    // Allow control keys like backspace, arrows, etc.
                    if (char.IsControl(e.KeyChar))
                    {
                        return;
                    }

                    // Only allow digits
                    if (!char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;  // Prevent anything but digits
                        return;
                    }

                    // Handle the position of the cursor
                    int caretPos = textBox.SelectionStart;

                    // Prevent typing into commas
                    if (caretPos == 3 || caretPos == 7)
                    {
                        // Automatically move the cursor past the comma if user types at comma position
                        textBox.SelectionStart = caretPos + 1;
                        caretPos++;
                    }

                    // Get the parts of the RGB string (split by commas)
                    string[] rgbParts = textBox.Text.Split(',');

                    // Check which part of the RGB we are typing in (0: Red, 1: Green, 2: Blue)
                    int partIndex = GetPartIndex(caretPos);

                    // Prevent typing more than 3 digits per part
                    if (rgbParts[partIndex].Length >= 3)
                    {
                        e.Handled = true;  // Prevent adding more than 3 digits per part
                    }
                }
            }
        }

        private void TextBoxColor_Enter(object sender, EventArgs e)
        {
            if (btnConvert.Text == "▶")
            {
                btnDummyButton.Focus();
            }
            else
            {
                if (sender is TextBox textBox)
                {
                    lblColourPointer.Location = new Point(lblColourPointer.Location.X, textBox.Location.Y - 8);
                    if (!btnHex.Enabled)
                    {
                        if (textBox.Text.StartsWith("#"))
                        {
                            // Move the cursor right after the #
                            textBox.SelectionStart = textBox.Text.Length;
                        }
                        else
                        {
                            // In case # is missing, make sure it's added
                            textBox.Text = "#" + textBox.Text;
                            textBox.SelectionStart = textBox.Text.Length;
                        }
                    }
                    else
                    {
                        textBox.SelectionStart = 0;
                        textBox.SelectionLength = 0;
                    }
                }
            }
        }

        #region validate rgb input
        private void TextBoxColor_Leave(object sender, EventArgs e)
        {
            if (btnConvert.Text == "◀")
            {
                if (!btnRGB.Enabled)
                {
                    TextBox textBox = (TextBox)sender;

                    // Validate if the numbers are in the 0-255 range
                    string[] rgbParts = textBox.Text.Split(',');
                    foreach (var part in rgbParts)
                    {
                        if (int.TryParse(part.Trim(), out int value))
                        {
                            if (value < 0 || value > 255)
                            {
                                MessageBox.Show("RGB values must be between 0 and 255.");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid RGB color in the format 255,255,255.");
                            return;
                        }
                    }
                }
            }
        }
        #endregion

        private void TextBoxColor_TextChanged(object sender, EventArgs e)
        {
            if (btnConvert.Text == "◀")
            {
                if (!btnHex.Enabled)  //HEX
                {
                    TextBox textBox = (TextBox)sender;

                    // Enforce # at the start
                    if (!textBox.Text.StartsWith("#") && textBox.Enabled)
                    {
                        textBox.Text = "#" + textBox.Text.TrimStart('#');
                        textBox.SelectionStart = textBox.Text.Length; // Move cursor to the end
                    }

                    if (textBox.Text.Length == 7)
                    {
                        int colourPositionOnForm = 1;

                        foreach (Control control in labelsAllColours)
                        {
                            if (control.Location.Y == textBox.Location.Y)
                            {
                                colourPositionOnForm = Convert.ToInt16(control.Text);
                            }
                        }

                        // Construct the label name
                        string labelName = "lblColorHex" + colourPositionOnForm.ToString();

                        // Find the label by its name
                        if (this.Controls.Find(labelName, true).FirstOrDefault() is Label label)
                        {
                            label.Text = textBox.Text;
                        }
                        else
                        {
                            MessageBox.Show($"Label '{labelName}' not found.");
                        }
                        return;
                    }
                    else
                    {
                        int colourPositionOnForm = 1;

                        foreach (Control control in labelsAllColours)
                        {
                            if (control.Location.Y == textBox.Location.Y)
                            {
                                colourPositionOnForm = Convert.ToInt16(control.Text);
                            }
                        }

                        // Construct the label name
                        string labelName = "lblColorDecimal" + colourPositionOnForm.ToString();

                        // Find the label by its name
                        if (this.Controls.Find(labelName, true).FirstOrDefault() is Label label)
                        {
                            label.Text = "--------";
                        }
                        else
                        {
                            MessageBox.Show($"Label '{labelName}' not found.");
                        }
                        return;
                    }
                }
                else //RGB
                {
                    TextBox textBox = (TextBox)sender;

                    // Prevent the user from removing the commas
                    if (!textBox.Text.Contains(','))
                    {
                        textBox.Text = ",,";
                        textBox.SelectionStart = 0;
                    }
                    if (textBox.Text.Length == 11)
                    {
                        int colourPositionOnForm = 1;

                        foreach (Control control in labelsAllColours)
                        {
                            if (control.Location.Y == textBox.Location.Y)
                            {
                                colourPositionOnForm = Convert.ToInt16(control.Text);
                            }
                        }

                        // Construct the label name
                        string labelName = "lblColorRGB" + colourPositionOnForm.ToString();

                        // Find the label by its name
                        if (this.Controls.Find(labelName, true).FirstOrDefault() is Label label)
                        {
                            label.Text = textBox.Text;
                        }
                        else
                        {
                            MessageBox.Show($"Label '{labelName}' not found.");
                        }
                        return;
                    }
                    else
                    {
                        int colourPositionOnForm = 1;

                        foreach (Control control in labelsAllColours)
                        {
                            if (control.Location.Y == textBox.Location.Y)
                            {
                                colourPositionOnForm = Convert.ToInt16(control.Text);
                            }
                        }

                        // Construct the label name
                        string labelName = "lblColorDecimal" + colourPositionOnForm.ToString();

                        // Find the label by its name
                        if (this.Controls.Find(labelName, true).FirstOrDefault() is Label label)
                        {
                            label.Text = "--------";
                        }
                        else
                        {
                            MessageBox.Show($"Label '{labelName}' not found.");
                        }
                        return;
                    }
                }
            }
        }

        private void TextBoxColor_Click(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (textBox.Text == "")
                {
                    textBox.SelectionStart = 0;
                    textBox.SelectionLength = 0;
                }
            }
        }

        #region show red/green indicator next to colour textbox
        private void BtnColor_TextChanged(object sender, EventArgs e)
        {

            if (sender is RJButton button)
            {
                if (!btn8Colours.Enabled)
                {
                    foreach (Control control in panels9to16Colors)
                    {
                        if (control.Location.Y == button.Location.Y)
                        {
                            control.BackColor = Color.FromArgb(20, 20, 20);
                            break;
                        }
                    }


                    if (button.Text == "▔")
                    {
                        foreach (Control control in panels1to8Colors)
                        {
                            if (control.Location.Y == button.Location.Y)
                            {
                                control.BackColor = Color.IndianRed;
                                break;
                            }
                        }

                    }
                    else
                    {
                        foreach (Control control in panels1to8Colors)
                        {
                            if (control.Location.Y == button.Location.Y)
                            {
                                control.BackColor = Color.OliveDrab;
                                break;
                            }
                        }

                    }
                }
                else
                {
                    if (button.Text == "▔")
                    {
                        foreach (Control control in panels1to16Colors)
                        {
                            if (control.Location.Y == button.Location.Y)
                            {
                                control.BackColor = Color.IndianRed;
                                break;
                            }
                        }

                    }
                    else
                    {
                        foreach (Control control in panels1to16Colors)
                        {
                            if (control.Location.Y == button.Location.Y)
                            {
                                control.BackColor = Color.OliveDrab;
                                break;
                            }
                        }

                    }
                }
            }
        }
        #endregion
        #endregion

        #region common

        private static int GetPartIndex(int caretPosition)
        {
            // Determine which part of the RGB the caret is in
            if (caretPosition < 3)
                return 0;  // Red part
            else if (caretPosition < 7)
                return 1;  // Green part
            else
                return 2;  // Blue part
        }

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
                int cornerRadius = 7;
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

        #endregion

        private void BtnDummyButton_TextChanged(object sender, EventArgs e)
        {
            if (btnDummyButton.Text == "allcoloursset")
            {
                if (!btn8Colours.Enabled)
                {
                    eightColours = true;
                }
                else
                {
                    eightColours = false;
                }

                #region populate the colorList with 8 or 16 colours
                for (int i = 1; i <= 16; i++)
                {
                    // Find the label (lblColorRGB1 through lblColorRGB16)
                    if (this.Controls.Find($"lblColorRGB{i}", true).FirstOrDefault() is Label rgbLabel)
                    {
                        string rgbValue = rgbLabel.Text;

                        // Check if the label contains a valid RGB value (not '---,---,---')
                        if (!string.IsNullOrWhiteSpace(rgbValue) && rgbValue != "---,---,---")
                        {
                            // Split the RGB string into its components
                            string[] rgbParts = rgbValue.Split(',');

                            // Ensure that there are exactly 3 parts and they are valid integers
                            if (rgbParts.Length == 3 &&
                                int.TryParse(rgbParts[0], out int r) &&
                                int.TryParse(rgbParts[1], out int g) &&
                                int.TryParse(rgbParts[2], out int b))
                            {
                                // Add the valid RGB value to the list
                                colorList.Add(Color.FromArgb(r, g, b));
                            }
                        }
                    }
                }

                colorList = colorList.OrderBy(c => c.GetHue()).ToList();

                #endregion
                foreach (Control control in patternButtons)
                {
                    control.Enabled = true;
                }
            }
            else // there are no longer 8 or 16 valid colours selected
            {
                foreach (Control control in patternButtons)
                {
                    control.Enabled = false;
                }
                colorList.Clear();
                colorList = new List<Color>();
            }
        }

        #region MENU
        private void BtnMenuConvert_Click(object sender, EventArgs e)
        {
            panelConverter.Visible = true;
            panelRGBLabels.Visible = false;
            panelHexLabels.Visible = false;
            panelSaveImage.Visible = false;
            panelConverter.BringToFront();

        }

        private void BtnMenuStripes_Click(object sender, EventArgs e)
        {
            panelPatternStripes.Visible = true;
            panelPatternStripes.BringToFront();
            PopulateHexKey();
            PopulateRGBKey();
            ShowSaveImagePanel();
            SetupStripes();
        }

        private void BtnMenuCircles_Click(object sender, EventArgs e)
        {
            panelPatternCircles.Visible = true;
            panelPatternCircles.BringToFront();
            PopulateHexKey();
            PopulateRGBKey();
            ShowSaveImagePanel();
            SetupCircles(panelImageCircles, colorList);
        }

        private void BtnMenuSquares_Click(object sender, EventArgs e)
        {
            panelPatternSquares.Visible = true;
            panelPatternSquares.BringToFront();
            PopulateHexKey();
            PopulateRGBKey();
            ShowSaveImagePanel();
            SetupSquares(panelImageSquares, colorList);
        }

        private void BtnMenuMandelbrot_Click(object sender, EventArgs e)
        {
            panelPatternMandelbrot.Visible = true;
            panelPatternMandelbrot.BringToFront();
            PopulateHexKey();
            PopulateRGBKey();
            ShowSaveImagePanel();
            SetupMandelbrot(panelImageMandelbrot, colorList);
        }

        private void BtnMenuSpiral_Click(object sender, EventArgs e)
        {
            panelPatternSpiral.Visible = true;
            panelPatternSpiral.BringToFront();
            PopulateHexKey();
            PopulateRGBKey();
            ShowSaveImagePanel();
            SetupSpiral(panelImageSpiral, colorList);
        }

        private void BtnMenuNoise_Click(object sender, EventArgs e)
        {
            panelPatternNoise.Visible = true;
            panelPatternNoise.BringToFront();
            PopulateHexKey();
            PopulateRGBKey();
            ShowSaveImagePanel();
            SetupNoise(panelImageNoise, colorList);
        }

        private void BtnMenuHexagons_Click(object sender, EventArgs e)
        {
            panelPatternHexagons.Visible = true;
            panelPatternHexagons.BringToFront();
            PopulateHexKey();
            PopulateRGBKey();
            ShowSaveImagePanel();
            SetupHexagons(panelImageHexagons, colorList);
        }

        private void BtnMenuSquiggle_Click(object sender, EventArgs e)
        {
            panelPatternSquiggle.Visible = true;
            panelPatternSquiggle.BringToFront();
            PopulateHexKey();
            PopulateRGBKey();
            ShowSaveImagePanel();
            SetupDistortion(panelImageSquiggle, colorList);
        }

        private void BtnMenuRadial_Click(object sender, EventArgs e)
        {
            panelPatternRadial.Visible = true;
            panelPatternRadial.BringToFront();
            PopulateHexKey();
            PopulateRGBKey();
            ShowSaveImagePanel();
            SetupRadial(panelImageRadial, colorList);
        }

        private void BtnMenuBrink_Click(object sender, EventArgs e)
        {
            panelPatternBrink.Visible = true;
            panelPatternBrink.BringToFront();
            PopulateHexKey();
            PopulateRGBKey();
            ShowSaveImagePanel();
            SetupBrink(panelImageBrink, phrase, colorList);
        }

        private void BtnMenuSymbols_Click(object sender, EventArgs e)
        {
            panelPatternSymbols.Visible = true;
            panelPatternSymbols.BringToFront();
            PopulateHexKey();
            PopulateRGBKey();
            ShowSaveImagePanel();
            SetupSymbols(panelImageSymbols, colorList);
        }

        private void BtnMenuTiles_Click(object sender, EventArgs e)
        {
            panelPatternTiles.Visible = true;
            panelPatternTiles.BringToFront();
            PopulateHexKey();
            PopulateRGBKey();
            ShowSaveImagePanel();
            SetupTiles(panelImageTiles, colorList);
        }

        private void BtnMenuMultibrot_Click(object sender, EventArgs e)
        {
            panelPatternMultibrot.Visible = true;
            panelPatternMultibrot.BringToFront();
            PopulateHexKey();
            PopulateRGBKey();
            ShowSaveImagePanel();
            SetupMultibrotSet(panelImageMultibrot, colorList);
        }

        private void BtnMenuPhoenix_Click(object sender, EventArgs e)
        {
            panelPatternPhoenix.Visible = true;
            panelPatternPhoenix.BringToFront();
            PopulateHexKey();
            PopulateRGBKey();
            ShowSaveImagePanel();
            SetupPhoenixFractal(panelImagePhoenix, colorList);
        }

        private void btnMenuTricorn_Click(object sender, EventArgs e)
        {
            panelPatternTricorn.Visible = true;
            panelPatternTricorn.BringToFront();
            PopulateHexKey();
            PopulateRGBKey();
            ShowSaveImagePanel();
            SetupTricornFractal(panelImageTricorn, colorList);
        }

        private void btnMenuJulia_Click(object sender, EventArgs e)
        {
            panelPatternJulia.Visible = true;
            panelPatternJulia.BringToFront();
            PopulateHexKey();
            PopulateRGBKey();
            ShowSaveImagePanel();
            SetupJuliaSet(panelImageJulia, colorList, 0.355, 0.355);
        }

        private void btnMenuTextGrid_Click(object sender, EventArgs e)
        {
            panelPatternTextGrid.Visible = true;
            panelPatternTextGrid.BringToFront();
            PopulateHexKey();
            PopulateRGBKey();
            ShowSaveImagePanel();
            SetupTextGrid(panelImageTextGrid, colorList, textGridPhrase);
        }

        #endregion

        #region PATTERNS

        #region *STRIPES

        private void SetupStripes()
        {
            if (eightColours)
            {
                panelSwatch1.BackColor = colorList[0];
                panelSwatch3.BackColor = colorList[1];
                panelSwatch5.BackColor = colorList[2];
                panelSwatch7.BackColor = colorList[3];
                panelSwatch9.BackColor = colorList[4];
                panelSwatch11.BackColor = colorList[5];
                panelSwatch13.BackColor = colorList[6];
                panelSwatch15.BackColor = colorList[7];

                foreach (Control control in panelsSwatchesForColors9To16)
                {
                    control.Visible = false;
                }
            }
            else
            {
                panelSwatch1.BackColor = colorList[0];
                panelSwatch2.BackColor = colorList[1];
                panelSwatch3.BackColor = colorList[2];
                panelSwatch4.BackColor = colorList[3];
                panelSwatch5.BackColor = colorList[4];
                panelSwatch6.BackColor = colorList[5];
                panelSwatch7.BackColor = colorList[6];
                panelSwatch8.BackColor = colorList[7];
                panelSwatch9.BackColor = colorList[8];
                panelSwatch10.BackColor = colorList[9];
                panelSwatch11.BackColor = colorList[10];
                panelSwatch12.BackColor = colorList[11];
                panelSwatch13.BackColor = colorList[12];
                panelSwatch14.BackColor = colorList[13];
                panelSwatch15.BackColor = colorList[14];
                panelSwatch16.BackColor = colorList[15];

                foreach (Control control in panelsSwatchesForColors9To16)
                {
                    control.Visible = true;
                }
            }

        }

        private void BtnStripesSortByBrightness_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetBrightness()).ToList();
            SetupStripes();
        }

        private void BtnStripesSortByHue_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetHue()).ToList();
            SetupStripes();
        }

        private void BtnStripesSortByRGBSum_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.R + c.G + c.B).ToList();
            SetupStripes();
        }

        private void BtnStripesSortBySaturation_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetSaturation()).ToList();
            SetupStripes();
        }

        #endregion

        #region *CIRCLES

        private void SetupCircles(Panel panel, List<Color> colorList)
        {
            panel.Controls.Clear();

            using Graphics g = panel.CreateGraphics();
            g.Clear(panel.BackColor);

            int centerX = panel.Width / 2;
            int centerY = panel.Height / 2;

            int maxRadius = (int)Math.Ceiling(Math.Sqrt(Math.Pow(panel.Width, 2) + Math.Pow(panel.Height, 2)) / 2);

            int step = maxRadius / colorList.Count;

            int colorIndex = 0;
            for (int radius = maxRadius; radius > 0; radius -= step)
            {
                using SolidBrush brush = new(colorList[colorIndex]);

                g.FillEllipse(brush, centerX - radius, centerY - radius, radius * 2, radius * 2);

                colorIndex = (colorIndex + 1) % colorList.Count;
            }
        }

        private void BtnCirclesSortByHue_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetHue()).ToList();
            SetupCircles(panelImageCircles, colorList);
        }

        private void BtnCirclesSortByBrightness_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetBrightness()).ToList();
            SetupCircles(panelImageCircles, colorList);
        }

        private void BtnCirclesSortByRGBSum_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.R + c.G + c.B).ToList();
            SetupCircles(panelImageCircles, colorList);
        }

        private void BtnCirclesSortBySaturation_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetSaturation()).ToList();
            SetupCircles(panelImageCircles, colorList);
        }

        #endregion

        #region *SQUARES

        private void SetupSquares(Panel panel, List<Color> colorList)
        {
            panel.Controls.Clear();

            int numColors = colorList.Count;
            int numColumns, numRows;

            if (numColors == 8)
            {
                numColumns = 4;
                numRows = 2;
            }
            else if (numColors == 16)
            {
                numColumns = 4;
                numRows = 4;
            }
            else
            {
                throw new ArgumentException("Only lists with 8 or 16 colors are supported.");
            }

            int squareWidth = panel.Width / numColumns;
            int squareHeight = panel.Height / numRows;

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numColumns; col++)
                {
                    int colorIndex = row * numColumns + col;

                    if (colorIndex >= numColors)
                        break;

                    Panel colorPanel = new()
                    {
                        BackColor = colorList[colorIndex],
                        Width = squareWidth,
                        Height = squareHeight,
                        Left = col * squareWidth,
                        Top = row * squareHeight
                    };

                    panel.Controls.Add(colorPanel);
                }
            }
        }

        private void BtnSquaresSortByHue_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetHue()).ToList();
            SetupSquares(panelImageSquares, colorList);
        }

        private void BtnSquaresSortByBrightness_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetBrightness()).ToList();
            SetupSquares(panelImageSquares, colorList);
        }

        private void BtnSquaresSortByRGBSum_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.R + c.G + c.B).ToList();
            SetupSquares(panelImageSquares, colorList);
        }

        private void BtnSquaresSortBySaturation_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetSaturation()).ToList();
            SetupSquares(panelImageSquares, colorList);
        }

        #endregion

        #region *SPIRAL

        private void SetupSpiral(Panel panel, List<Color> colorList)
        {
            panel.Controls.Clear();

            using Graphics g = panel.CreateGraphics();
            g.Clear(panel.BackColor);

            int centerX = panel.Width / 2;
            int centerY = panel.Height / 2;

            double angle = 0;
            double radius = 0;
            double angleStep = 0.1;
            double radiusStep = 3;
            int colorIndex = 0;

            while (radius < Math.Max(panel.Width, panel.Height))
            {
                using Pen pen = new(colorList[colorIndex], 8);

                int x = centerX + (int)(radius * Math.Cos(angle));
                int y = centerY + (int)(radius * Math.Sin(angle));

                g.DrawLine(pen, centerX, centerY, x, y);

                angle += angleStep;
                radius += radiusStep;
                colorIndex = (colorIndex + 1) % colorList.Count;
            }
        }

        private void BtnSpiralSortByHue_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetHue()).ToList();
            SetupSpiral(panelImageSpiral, colorList);
        }

        private void BtnSpiralSortByBrightness_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetBrightness()).ToList();
            SetupSpiral(panelImageSpiral, colorList);
        }

        private void BtnSpiralSortByRGBSum_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.R + c.G + c.B).ToList();
            SetupSpiral(panelImageSpiral, colorList);
        }

        private void BtnSpiralSortBySaturation_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetSaturation()).ToList();
            SetupSpiral(panelImageSpiral, colorList);
        }

        #endregion

        #region *MANDELBROT

        private void SetupMandelbrot(Panel panel, List<Color> colorList)
        {
            panel.Controls.Clear();

            using Graphics g = panel.CreateGraphics();
            g.Clear(panel.BackColor);

            int width = panel.Width;
            int height = panel.Height;
            int colorCount = colorList.Count;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    double a = (x - width / 2.0) * 4.0 / width;
                    double b = (y - height / 2.0) * 4.0 / height;

                    double ca = a;
                    double cb = b;

                    int n = 0;
                    int maxIterations = 100;

                    while (n < maxIterations)
                    {
                        double aa = a * a - b * b;
                        double bb = 2 * a * b;

                        a = aa + ca;
                        b = bb + cb;

                        if (Math.Abs(a + b) > 16)
                        {
                            break;
                        }

                        n++;
                    }

                    int colorIndex = n % colorCount;
                    Color color = colorList[colorIndex];

                    g.FillRectangle(new SolidBrush(color), x, y, 1, 1);
                }
            }
        }


        private void BtnMandelbrotSortByHue_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetHue()).ToList();
            SetupMandelbrot(panelImageMandelbrot, colorList);
        }

        private void BtnMandelbrotSortByBrightness_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetBrightness()).ToList();
            SetupMandelbrot(panelImageMandelbrot, colorList);
        }

        private void BtnMandelbrotSortByRGBSum_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.R + c.G + c.B).ToList();
            SetupMandelbrot(panelImageMandelbrot, colorList);
        }

        private void BtnMandelbrotSortBySaturation_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetSaturation()).ToList();
            SetupMandelbrot(panelImageMandelbrot, colorList);
        }

        #endregion

        #region *NOISE

        private void SetupNoise(Panel panel, List<Color> colorList)
        {
            panel.Controls.Clear();

            using Graphics g = panel.CreateGraphics();
            g.Clear(panel.BackColor);

            Random random = new();
            int colorIndex = 0;

            for (int i = 0; i < 100000; i++)
            {
                colorIndex = random.Next(colorList.Count);
                using SolidBrush brush = new(colorList[colorIndex]);

                int x = random.Next(panel.Width);
                int y = random.Next(panel.Height);
                int size = random.Next(1, noiseSize);

                g.FillRectangle(brush, x, y, size, size);
            }
        }

        private void btnNoiseSize_Click(object sender, EventArgs e)
        {
            noiseSize = (int)numericUpDownNoiseSize.Value;
            SetupNoise(panelImageNoise, colorList);
        }

        #endregion

        #region *RADIAL

        private void SetupRadial(Panel panel, List<Color> colorList)
        {
            panel.Controls.Clear();

            using Graphics g = panel.CreateGraphics();
            g.Clear(panel.BackColor);

            Random random = new();
            int centerX = panel.Width / 2;
            int centerY = panel.Height / 2;
            int colorIndex = 0;
            double angleStep = Math.PI / radialAngle;

            for (int i = 0; i < radialRays; i++)
            {
                using SolidBrush brush = new(colorList[colorIndex]);

                double angle = i * angleStep;
                int outerX1 = centerX + (int)(panel.Width * Math.Cos(angle));
                int outerY1 = centerY + (int)(panel.Height * Math.Sin(angle));
                int outerX2 = centerX + (int)(panel.Width * Math.Cos(angle + angleStep));
                int outerY2 = centerY + (int)(panel.Height * Math.Sin(angle + angleStep));

                Point[] points = { new(centerX, centerY), new(outerX1, outerY1), new(outerX2, outerY2) };
                g.FillPolygon(brush, points);

                colorIndex = (colorIndex + 1) % colorList.Count;
            }
        }

        private void BtnRadialSortByHue_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetHue()).ToList();
            SetupRadial(panelImageRadial, colorList);
        }

        private void BtnRadialSortByBrightness_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetBrightness()).ToList();
            SetupRadial(panelImageRadial, colorList);
        }

        private void BtnRadialSortByRGBSum_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.R + c.G + c.B).ToList();
            SetupRadial(panelImageRadial, colorList);
        }

        private void BtnRadialSortBySaturation_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetSaturation()).ToList();
            SetupRadial(panelImageRadial, colorList);
        }

        private void btnRadialRays_Click(object sender, EventArgs e)
        {
            if (comboBoxRadialRays.Text == "32")
            {
                radialAngle = 16;
                radialRays = 32;
            }
            if (comboBoxRadialRays.Text == "64")
            {
                radialAngle = 32;
                radialRays = 64;
            }
            if (comboBoxRadialRays.Text == "128")
            {
                radialAngle = 64;
                radialRays = 128;
            }
            if (comboBoxRadialRays.Text == "256")
            {
                radialAngle = 128;
                radialRays = 256;
            }
            if (comboBoxRadialRays.Text == "512")
            {
                radialAngle = 256;
                radialRays = 512;
            }
            if (comboBoxRadialRays.Text == "1024")
            {
                radialAngle = 512;
                radialRays = 1024;
            }
            if (comboBoxRadialRays.Text == "2048")
            {
                radialAngle = 1024;
                radialRays = 2048;
            }
            SetupRadial(panelImageRadial, colorList);
        }

        #endregion

        #region *HEXAGONS

        private void SetupHexagons(Panel panel, List<Color> colorList)
        {
            panel.Controls.Clear();

            using Graphics g = panel.CreateGraphics();
            g.Clear(panel.BackColor);

            Random random = new();
            int colorIndex = 0;

            void DrawHexagon(Graphics g, float x, float y, float size, int depth)
            {
                if (depth == 0) return;
                using SolidBrush brush = new(colorList[colorIndex]);

                PointF[] hexagon = new PointF[6];
                for (int i = 0; i < 6; i++)
                {
                    double angle = i * Math.PI / 3;
                    hexagon[i] = new PointF(x + size * (float)Math.Cos(angle), y + size * (float)Math.Sin(angle));
                }
                g.FillPolygon(brush, hexagon);

                colorIndex = (colorIndex + 1) % colorList.Count;

                float newSize = size * 0.5f;
                for (int i = 0; i < 6; i++)
                {
                    DrawHexagon(g, hexagon[i].X, hexagon[i].Y, newSize, depth - 1);
                }
            }

            float hexSize = panel.Width / 12f;
            float hexHeight = (float)Math.Sqrt(3) * hexSize;

            int rows = (int)(panel.Height / hexHeight) + 2;
            int cols = (int)(panel.Width / (1.5 * hexSize)) + 2;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    float x = col * 1.5f * hexSize;
                    float y = row * hexHeight;
                    if (col % 2 == 1)
                    {
                        y += hexHeight / 2;
                    }

                    DrawHexagon(g, x, y, hexSize, hexagonComplexity); // Depth set to 3, adjust for complexity
                }
            }
        }

        private void btnHexagonsSortByHue_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetHue()).ToList();
            SetupHexagons(panelImageHexagons, colorList);
        }

        private void btnHexagonsSortByBrightness_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetBrightness()).ToList();
            SetupHexagons(panelImageHexagons, colorList);
        }

        private void btnHexagonsSortByRGBSum_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.R + c.G + c.B).ToList();
            SetupHexagons(panelImageHexagons, colorList);
        }

        private void btnHexagonsSortBySaturation_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetSaturation()).ToList();
            SetupHexagons(panelImageHexagons, colorList);
        }

        private void btnHexagonComplexity_Click(object sender, EventArgs e)
        {
            hexagonComplexity = (int)numericUpDownHexagonComplexity.Value;
            SetupHexagons(panelImageHexagons, colorList);
        }

        #endregion

        #region *DISTORTION

        private void SetupDistortion(Panel panel, List<Color> colorList)
        {
            panel.Controls.Clear();

            using Graphics g = panel.CreateGraphics();
            g.Clear(panel.BackColor);

            Random random = new();
            int colorIndex = 0;
            int centerX = panel.Width / 2;
            int centerY = panel.Height / 2;

            // Calculate a radius large enough to reach the farthest corners of the panel
            int maxRadius = (int)Math.Ceiling(Math.Sqrt(centerX * centerX + centerY * centerY));

            // Set a smaller step to add more circles
            int step = 15; // Smaller step to increase circle count

            // Continue drawing circles until the smallest radius is very small
            for (int radius = maxRadius; radius > 0; radius -= step)
            {
                // Set the color from the list
                using Pen pen = new(colorList[colorIndex], 3);

                PointF[] points = new PointF[360];
                for (int angle = 0; angle < 360; angle++)
                {
                    // Create distortion by altering the radii slightly
                    float distortion = (float)(random.NextDouble() * distortionAmount - 10); // Random deviation
                    points[angle] = new PointF(
                        centerX + (float)((radius + distortion) * Math.Cos(angle * Math.PI / 180)),
                        centerY + (float)((radius + distortion) * Math.Sin(angle * Math.PI / 180))
                    );
                }

                // Draw the distorted circle, even if parts of it are outside the panel
                g.DrawPolygon(pen, points);

                // Cycle through the colors, repeating if necessary
                colorIndex = (colorIndex + 1) % colorList.Count;
            }
        }

        private void btnDistortionSortByHue_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetHue()).ToList();
            SetupDistortion(panelImageSquiggle, colorList);
        }

        private void btnDistortionSortByBrightness_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetBrightness()).ToList();
            SetupDistortion(panelImageSquiggle, colorList);
        }

        private void btnDistortionSortByRGBSum_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.R + c.G + c.B).ToList();
            SetupDistortion(panelImageSquiggle, colorList);
        }

        private void btnDistortionSortBySaturation_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetSaturation()).ToList();
            SetupDistortion(panelImageSquiggle, colorList);
        }

        private void btnDistortionRefresh_Click(object sender, EventArgs e)
        {
            distortionAmount = (int)numericUpDownDistortion.Value;
            SetupDistortion(panelImageSquiggle, colorList);
        }

        #endregion

        #region *BRINK

        private void SetupBrink(Panel panel, string phrase, List<Color> colorList)
        {
            panel.Controls.Clear();

            using Graphics g = panel.CreateGraphics();
            g.Clear(panel.BackColor);

            Random random = new();
            int colorIndex = 0;

            string[] fontFamilies = { "Arial", "Times New Roman", "Verdana", "Courier New", "Comic Sans MS" };
            int[] fontSizes = { 20, 30, 40, 50, 60, 80 };

            for (int i = 0; i < 400; i++)
            {
                string fontFamily = fontFamilies[random.Next(0, fontFamilies.Length)];
                int fontSize = fontSizes[random.Next(0, fontSizes.Length)];

                using Brush brush = new SolidBrush(colorList[colorIndex]);

                using Font font = new(fontFamily, fontSize, FontStyle.Bold);

                int x = random.Next(0, panel.Width - 100);
                int y = random.Next(0, panel.Height - 100);
                float angle = random.Next(-180, 180);

                g.TranslateTransform(x, y);
                g.RotateTransform(angle);

                g.DrawString(phrase, font, brush, 0, 0);

                g.ResetTransform();

                colorIndex = (colorIndex + 1) % colorList.Count;
            }
        }

        private void btnBrinkRefreshText_Click(object sender, EventArgs e)
        {
            phrase = textBoxBrink.Text;
            SetupBrink(panelImageBrink, phrase, colorList);
        }

        #endregion

        #region *SYMBOLS

        int fontSize = 20;

        private void SetupSymbols(Panel panel, List<Color> colorList)
        {
            panel.Controls.Clear();

            using Graphics g = panel.CreateGraphics();
            g.Clear(panel.BackColor);

            Random random = new();
            int colorIndex = 0;

            char[] asciiChars = { '@', '#', 'S', '%', '?', '*', '+', ';', ':', ',', '.', '₿' };

            using Font font = new("Courier New", fontSize, FontStyle.Bold);

            int gridSize = 20;
            for (int y = 0; y < panel.Height; y += gridSize)
            {
                for (int x = 0; x < panel.Width; x += gridSize)
                {
                    char asciiChar = asciiChars[random.Next(0, asciiChars.Length)];

                    using Brush brush = new SolidBrush(colorList[colorIndex]);

                    g.DrawString(asciiChar.ToString(), font, brush, new PointF(x, y));

                    colorIndex = (colorIndex + 1) % colorList.Count;
                }
            }
        }

        private void BtnSymbolSize_Click(object sender, EventArgs e)
        {
            fontSize = (int)numericUpDownSymbolSize.Value;
            SetupSymbols(panelImageSymbols, colorList);
        }

        #endregion

        #region *TILES

        private void SetupTiles(Panel panel, List<Color> colorList)
        {
            panel.Controls.Clear();

            using Graphics g = panel.CreateGraphics();
            g.Clear(panel.BackColor);

            Random random = new();
            int colorIndex = 0;

            Point[] points = new Point[mosaicNumPoints];
            for (int i = 0; i < mosaicNumPoints; i++)
            {
                points[i] = new Point(random.Next(panel.Width), random.Next(panel.Height));
            }

            for (int x = 0; x < panel.Width; x++)
            {
                for (int y = 0; y < panel.Height; y++)
                {
                    // Find the closest random point for each pixel
                    int closestPointIndex = 0;
                    double closestDistance = double.MaxValue;

                    for (int i = 0; i < mosaicNumPoints; i++)
                    {
                        double dist = Math.Sqrt(Math.Pow(x - points[i].X, 2) + Math.Pow(y - points[i].Y, 2));
                        if (dist < closestDistance)
                        {
                            closestDistance = dist;
                            closestPointIndex = i;
                        }
                    }

                    // Use a color based on the closest point's index
                    colorIndex = closestPointIndex % colorList.Count;
                    using SolidBrush brush = new(colorList[colorIndex]);
                    g.FillRectangle(brush, x, y, 1, 1);
                }
            }
        }

        private void btnTilesCount_Click(object sender, EventArgs e)
        {
            mosaicNumPoints = (int)numericUpDownMosaicTiles.Value;
            SetupTiles(panelImageTiles, colorList);
        }

        #endregion

        #region *MULTIBROT

        private void SetupMultibrotSet(Panel panel, List<Color> colorList)
        {
            panel.Controls.Clear();

            using Graphics g = panel.CreateGraphics();
            g.Clear(panel.BackColor);

            int width = panel.Width;
            int height = panel.Height;
            Bitmap bitmap = new(width, height);

            int colorCount = colorList.Count;
            Random random = new();

            double xmin = -2.0, xmax = 2.0, ymin = -2.0, ymax = 2.0;
            double xscale = (xmax - xmin) / width;
            double yscale = (ymax - ymin) / height;
            int maxIterations = 500;

            for (int px = 0; px < width; px++)
            {
                for (int py = 0; py < height; py++)
                {
                    double x0 = xmin + px * xscale;
                    double y0 = ymin + py * yscale;
                    double x = 0.0, y = 0.0;
                    int iteration = 0;

                    while (x * x + y * y < 4 && iteration < maxIterations)
                    {
                        double xTemp = x * x * x - 3 * x * y * y + x0;
                        y = 3 * x * x * y - y * y * y + y0;
                        x = xTemp;
                        iteration++;
                    }

                    int colorIndex = iteration % colorCount;
                    Color color = (iteration == maxIterations) ? Color.Black : colorList[colorIndex];
                    bitmap.SetPixel(px, py, color);
                }
            }

            g.DrawImage(bitmap, 0, 0);
        }

        private void BtnMultibrotSortByHue_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetHue()).ToList();
            SetupMultibrotSet(panelImageMultibrot, colorList);
        }

        private void BtnMultibrotSortByBrightness_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetBrightness()).ToList();
            SetupMultibrotSet(panelImageMultibrot, colorList);
        }

        private void BtnMultibrotSortByRGBSum_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.R + c.G + c.B).ToList();
            SetupMultibrotSet(panelImageMultibrot, colorList);
        }

        private void BtnMultibrotSortBySaturation_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetSaturation()).ToList();
            SetupMultibrotSet(panelImageMultibrot, colorList);
        }

        #endregion

        #region *PHOENIX

        private void SetupPhoenixFractal(Panel panel, List<Color> colorList)
        {
            panel.Controls.Clear();

            using Graphics g = panel.CreateGraphics();
            g.Clear(panel.BackColor);

            int width = panel.Width;
            int height = panel.Height;
            Bitmap bitmap = new(width, height);

            int colorCount = colorList.Count;
            Random random = new();

            double xmin = -2.0, xmax = 2.0, ymin = -2.0, ymax = 2.0;
            double xscale = (xmax - xmin) / width;
            double yscale = (ymax - ymin) / height;
            int maxIterations = 500;

            // Phoenix specific variables
            double p = -0.5, q = 0.0; 

            for (int px = 0; px < width; px++)
            {
                for (int py = 0; py < height; py++)
                {
                    double x0 = xmin + px * xscale;
                    double y0 = ymin + py * yscale;
                    double x = 0.0, y = 0.0, xn = 0.0, yn = 0.0;
                    int iteration = 0;

                    // Phoenix fractal equation: z = z^2 + c + p*z_previous + q*z_previous^2
                    while (x * x + y * y < 4 && iteration < maxIterations)
                    {
                        double xtemp = x * x - y * y + x0 + p * xn - q * (xn * xn - yn * yn);
                        yn = y;
                        y = 2 * x * y + y0 + p * yn - q * (2 * xn * yn);
                        xn = x;
                        x = xtemp;
                        iteration++;
                    }

                    int colorIndex = iteration % colorCount;
                    Color color = (iteration == maxIterations) ? Color.Black : colorList[colorIndex];
                    bitmap.SetPixel(px, py, color);
                }
            }

            g.DrawImage(bitmap, 0, 0);
        }

        private void BtnPhoenixSortByHue_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetHue()).ToList();
            SetupPhoenixFractal(panelImagePhoenix, colorList);
        }

        private void BtnPhoenixSortByBrightness_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetBrightness()).ToList();
            SetupPhoenixFractal(panelImagePhoenix, colorList);
        }

        private void BtnPhoenixSortByRGBSum_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.R + c.G + c.B).ToList();
            SetupPhoenixFractal(panelImagePhoenix, colorList);
        }

        private void BtnPhoenixSortBySaturation_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetSaturation()).ToList();
            SetupPhoenixFractal(panelImagePhoenix, colorList);
        }

        #endregion

        #region *TRICORN

        private void SetupTricornFractal(Panel panel, List<Color> colorList)
        {
            panel.Controls.Clear();

            using Graphics g = panel.CreateGraphics();
            g.Clear(panel.BackColor);

            int width = panel.Width;
            int height = panel.Height;
            Bitmap bitmap = new(width, height);

            int colorCount = colorList.Count;
            Random random = new();

            double xmin = -2.0, xmax = 2.0, ymin = -2.0, ymax = 2.0;
            double xscale = (xmax - xmin) / width;
            double yscale = (ymax - ymin) / height;
            int maxIterations = 500;

            for (int px = 0; px < width; px++)
            {
                for (int py = 0; py < height; py++)
                {
                    double x0 = xmin + px * xscale;
                    double y0 = ymin + py * yscale;
                    double x = 0.0, y = 0.0;
                    int iteration = 0;

                    // Tricorn equation: z = conj(z^2) + c
                    while (x * x + y * y < 4 && iteration < maxIterations)
                    {
                        double xTemp = x * x - y * y + x0;
                        y = -2 * x * y + y0;
                        x = xTemp;
                        iteration++;
                    }

                    int colorIndex = iteration % colorCount;
                    Color color = (iteration == maxIterations) ? Color.Black : colorList[colorIndex];
                    bitmap.SetPixel(px, py, color);
                }
            }

            g.DrawImage(bitmap, 0, 0);
        }

        private void BtnMenuTricornSortByHue_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetHue()).ToList();
            SetupTricornFractal(panelImageTricorn, colorList);
        }

        private void BtnMenuTricornSortByBrightness_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetBrightness()).ToList();
            SetupTricornFractal(panelImageTricorn, colorList);
        }

        private void BtnMenuTricornSortByRGBSum_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.R + c.G + c.B).ToList();
            SetupTricornFractal(panelImageTricorn, colorList);
        }

        private void BtnMenuTricornSortBySaturation_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetSaturation()).ToList();
            SetupTricornFractal(panelImageTricorn, colorList);
        }

        #endregion

        #region *JULIA

        private void SetupJuliaSet(Panel panel, List<Color> colorList, double realPartC, double imaginaryPartC)
        {
            panel.Controls.Clear();

            using Graphics g = panel.CreateGraphics();
            g.Clear(panel.BackColor);

            int width = panel.Width;
            int height = panel.Height;
            Bitmap bitmap = new(width, height);

            int colorCount = colorList.Count;
            Random random = new();

            double xmin = -2.0, xmax = 2.0, ymin = -2.0, ymax = 2.0;
            double xscale = (xmax - xmin) / width;
            double yscale = (ymax - ymin) / height;
            int maxIterations = 500;

            for (int px = 0; px < width; px++)
            {
                for (int py = 0; py < height; py++)
                {
                    double x = xmin + px * xscale;
                    double y = ymin + py * yscale;
                    int iteration = 0;

                    // Julia set equation: z = z^2 + c (c is fixed, z varies)
                    while (x * x + y * y < 4 && iteration < maxIterations)
                    {
                        double xTemp = x * x - y * y + realPartC;
                        y = 2 * x * y + imaginaryPartC;
                        x = xTemp;
                        iteration++;
                    }

                    int colorIndex = iteration % colorCount;
                    Color color = (iteration == maxIterations) ? Color.Black : colorList[colorIndex];
                    bitmap.SetPixel(px, py, color);
                }
            }

            g.DrawImage(bitmap, 0, 0);
        }

        private void BtnJuliaSortByHue_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetHue()).ToList();
            SetupJuliaSet(panelImageJulia, colorList, 0.355, 0.355);
        }

        private void BtnJuliaSortByBrightness_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetBrightness()).ToList();
            SetupJuliaSet(panelImageJulia, colorList, 0.355, 0.355);
        }

        private void BtnJuliaSortByRGBSum_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.R + c.G + c.B).ToList();
            SetupJuliaSet(panelImageJulia, colorList, 0.355, 0.355);
        }

        private void BtnJuliaSortBySaturation_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetSaturation()).ToList();
            SetupJuliaSet(panelImageJulia, colorList, 0.355, 0.355);
        }

        #endregion

        #region *TEXTGRID

        private void SetupTextGrid(Panel panel, List<Color> colorList, string text)
        {
            panel.Controls.Clear();
            using Graphics g = panel.CreateGraphics();
            g.Clear(panel.BackColor);

            Random random = new();
            int colorIndex = 0;

            int rows = 10;
            int cols = 10;
            float cellWidth = panel.Width / cols;
            float cellHeight = panel.Height / rows;

            using Font font = new("Arial", 24, FontStyle.Bold);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    float x = col * cellWidth;
                    float y = row * cellHeight;

                    using Brush shapeBrush = new SolidBrush(colorList[(colorIndex + 1) % colorList.Count]);
                    if (random.Next(2) == 0)
                    {
                        g.FillEllipse(shapeBrush, x, y, cellWidth, cellHeight);
                    }
                    else
                    {
                        g.FillRectangle(shapeBrush, x, y, cellWidth, cellHeight);
                    }

                    // Draw the text
                    string letter = text[(row * cols + col) % text.Length].ToString();
                    using Brush textBrush = new SolidBrush(colorList[colorIndex]);
                    g.DrawString(letter, font, textBrush, x + 10, y + 10); // Text slightly inside

                    colorIndex = (colorIndex + 1) % colorList.Count;
                }
            }
        }

        private void BtnTextGridSortByHue_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetHue()).ToList();
            SetupTextGrid(panelImageTextGrid, colorList, textGridPhrase);
        }

        private void BtnTextGridSortByBrightness_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetBrightness()).ToList();
            SetupTextGrid(panelImageTextGrid, colorList, textGridPhrase);
        }

        private void BtnTextGridSortByRGBSum_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.R + c.G + c.B).ToList();
            SetupTextGrid(panelImageTextGrid, colorList, textGridPhrase);
        }

        private void BtnTextGridSortBySaturation_Click(object sender, EventArgs e)
        {
            colorList = colorList.OrderBy(c => c.GetSaturation()).ToList();
            SetupTextGrid(panelImageTextGrid, colorList, textGridPhrase);
        }

        private void BtnTextGridUpdatePhrase_Click(object sender, EventArgs e)
        {
            textGridPhrase = textBoxTextGrid.Text;
            SetupTextGrid(panelImageTextGrid, colorList, textGridPhrase);
        }


        #endregion

        #endregion

        #region save area of form as image

        private void SaveAreaAsImage(Rectangle captureArea)
        {
            // Convert the form-relative coordinates to screen coordinates
            Point formLocationOnScreen = this.PointToScreen(captureArea.Location);

            // Create a bitmap with the size of the capture area
            Bitmap bitmap = new(captureArea.Width, captureArea.Height);

            // Create a graphics object from the bitmap
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // Capture the specified area of the form into the bitmap
                g.CopyFromScreen(formLocationOnScreen, Point.Empty, captureArea.Size);
            }

            using SaveFileDialog saveFileDialog = new();
            saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
            saveFileDialog.Title = "Save area as image";
            saveFileDialog.FileName = "Chromaseed.png";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileExtension = System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower();

                switch (fileExtension)
                {
                    case ".jpg":
                        bitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case ".bmp":
                        bitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    default:
                        bitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                }

                MessageBox.Show("Selected area of the form saved successfully!");
            }
        }

        private void ShowSaveImagePanel()
        {
            panelSaveImage.Visible = true;
            panelSaveImage.BringToFront();

        }

        private void BtnSaveImage_Click(object sender, EventArgs e)
        {
            if (checkBoxHex.Checked && checkBoxRGB.Checked)
            {
                Rectangle captureArea = new(135, 82, 640, 568);
                SaveAreaAsImage(captureArea);
            }

            if (!checkBoxHex.Checked && !checkBoxRGB.Checked)
            {
                Rectangle captureArea = new(205, 82, 570, 568);
                SaveAreaAsImage(captureArea);
            }

            if (checkBoxHex.Checked && !checkBoxRGB.Checked)
            {
                Rectangle captureArea = new(135, 82, 640, 568);
                panelRGBLabels.Visible = false;
                SaveAreaAsImage(captureArea);
                panelRGBLabels.Visible = true;
            }

            if (!checkBoxHex.Checked && checkBoxRGB.Checked)
            {
                Rectangle captureArea = new(135, 82, 640, 568);
                panelHexLabels.Visible = false;
                SaveAreaAsImage(captureArea);
                panelHexLabels.Visible = true;
            }
        }
        #endregion

        #region populate hex and rgb keys

        private void PopulateHexKey()
        {
            if (eightColours)
            {
                lblHex1.Text = lblColorHex1.Text;
                lblHex2.Text = lblColorHex2.Text;
                lblHex3.Text = lblColorHex3.Text;
                lblHex4.Text = lblColorHex4.Text;
                lblHex5.Text = lblColorHex5.Text;
                lblHex6.Text = lblColorHex6.Text;
                lblHex7.Text = lblColorHex7.Text;
                lblHex8.Text = lblColorHex8.Text;
                panelHexLabels.Height = 108;
                panelHexLabels.Location = new Point(panelHexLabels.Location.X, 84);
            }
            else
            {
                lblHex1.Text = lblColorHex1.Text;
                lblHex2.Text = lblColorHex2.Text;
                lblHex3.Text = lblColorHex3.Text;
                lblHex4.Text = lblColorHex4.Text;
                lblHex5.Text = lblColorHex5.Text;
                lblHex6.Text = lblColorHex6.Text;
                lblHex7.Text = lblColorHex7.Text;
                lblHex8.Text = lblColorHex8.Text;
                lblHex9.Text = lblColorHex9.Text;
                lblHex10.Text = lblColorHex10.Text;
                lblHex11.Text = lblColorHex11.Text;
                lblHex12.Text = lblColorHex12.Text;
                lblHex13.Text = lblColorHex13.Text;
                lblHex14.Text = lblColorHex14.Text;
                lblHex15.Text = lblColorHex15.Text;
                lblHex16.Text = lblColorHex16.Text;
                panelHexLabels.Height = 216;
                panelHexLabels.Location = new Point(panelHexLabels.Location.X, 84);
            }
            panelHexLabels.BringToFront();
            panelHexLabels.Visible = true;
        }

        private void PopulateRGBKey()
        {
            if (eightColours)
            {
                lblRGB1.Text = lblColorRGB1.Text;
                lblRGB2.Text = lblColorRGB2.Text;
                lblRGB3.Text = lblColorRGB3.Text;
                lblRGB4.Text = lblColorRGB4.Text;
                lblRGB5.Text = lblColorRGB5.Text;
                lblRGB6.Text = lblColorRGB6.Text;
                lblRGB7.Text = lblColorRGB7.Text;
                lblRGB8.Text = lblColorRGB8.Text;
                panelRGBLabels.Height = 108;
                panelRGBLabels.Location = new Point(panelRGBLabels.Location.X, 538);
            }
            else
            {
                lblRGB1.Text = lblColorRGB1.Text;
                lblRGB2.Text = lblColorRGB2.Text;
                lblRGB3.Text = lblColorRGB3.Text;
                lblRGB4.Text = lblColorRGB4.Text;
                lblRGB5.Text = lblColorRGB5.Text;
                lblRGB6.Text = lblColorRGB6.Text;
                lblRGB7.Text = lblColorRGB7.Text;
                lblRGB8.Text = lblColorRGB8.Text;
                lblRGB9.Text = lblColorRGB9.Text;
                lblRGB10.Text = lblColorRGB10.Text;
                lblRGB11.Text = lblColorRGB11.Text;
                lblRGB12.Text = lblColorRGB12.Text;
                lblRGB13.Text = lblColorRGB13.Text;
                lblRGB14.Text = lblColorRGB14.Text;
                lblRGB15.Text = lblColorRGB15.Text;
                lblRGB16.Text = lblColorRGB16.Text;
                panelRGBLabels.Height = 216;
                panelRGBLabels.Location = new Point(panelRGBLabels.Location.X, 430);
            }
            panelRGBLabels.BringToFront();
            panelRGBLabels.Visible = true;
        }

        #endregion
    }
}
