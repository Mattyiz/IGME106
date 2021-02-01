using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaveEditor_v1
{
    public partial class Form1 : Form
    {
        // #############[  FIELDS  ]####################################################

        private WaveManager wManager;

        public List<ToolStrip> wavePanels;

        private Wave selectedWave = null;

        public int fileOperationsInProgress = 0;

        // ##### Initialization Settings: #####


        //private readonly Color w_BackColor = Color.FromName("ControlWhiteWhite");
        private readonly Color w_BackColor = Color.FromName("ScrollBar");
        private readonly Color w_BackColorSelected = Color.FromName("ControlDark");


        // === ToolStrip (Wave Panel): ===

        //readonly Point topLocation_W = new Point(1, 1);
        private readonly Padding w_Padding = new Padding(1);
        private readonly Padding w_Margin = new Padding(1, 1, 1, 0);

        private readonly Size w_Size = new Size(294, 25);



        // === ToolStrip Items: ===

            // ToolStripLabel
        // (Wave Panel's Nametag)
        private readonly Padding wLabel_Margin = new Padding(40, 1, 0, 2);
        private readonly Size wLabel_Size = new Size(45, 20);


            // ToolStripButton
        // (Wave Panel's Buttons)
        private readonly Size wButton_Size = new Size(45, 20);


            // ToolStripSeparator
        // (Vertical line on wave panel acting as a seperator/divider)
        private readonly Padding wSeparator_Margin = new Padding(40, 1, 0, 2);
        private readonly Size wSeparator_Size = new Size(45, 20);




        // #############[  CONSTRUCTOR  ]#######################################
        public Form1()
        {
            wManager = new WaveManager(this);
            wavePanels = new List<ToolStrip>();
            InitializeComponent();
        }




        // #############[  METHODS  ]####################################################
        



        public void CreateWaveControl()
        {
            Wave newWave = wManager.AddWave();


            ToolStripLabel wc_NameLabel = new ToolStripLabel(newWave.name);

            /*ToolStripButton wc_EditButton = new ToolStripButton("✎");

            ToolStripSeparator wc_Separator = new ToolStripSeparator();

            ToolStripButton wc_MoveUpButton = new ToolStripButton("🡅");

            ToolStripButton wc_MoveDownButton = new ToolStripButton("🡇");*/


            // NOTE: This part was scrapped because it is way too ambitious and I don't have time.

            //ToolStrip newWaveControl = new ToolStrip(
            //    wc_NameLabel,
            //    wc_EditButton,
            //    wc_Separator,
            //    wc_MoveUpButton,
            //    wc_MoveDownButton
            //    );


            // Here is the simplified version:
            ToolStrip newWaveControl = new ToolStrip(wc_NameLabel);


            newWaveControl.Visible = false;

            flowLayoutPanel1.Controls.Add(newWaveControl);
            

            int relativeHeight = w_Size.Height * wavePanels.Count;

            newWaveControl.Location = new Point(1, 1 + relativeHeight);


            newWaveControl.AutoSize = false;

            newWaveControl.Padding = w_Padding;
            newWaveControl.Margin = w_Margin;
            newWaveControl.Size = w_Size;
            newWaveControl.BackColor = w_BackColor;


            wc_NameLabel.Margin = wLabel_Margin;
            wc_NameLabel.Size = wLabel_Size;


            /*wc_EditButton.Size = wButton_Size;
            wc_MoveUpButton.Size = wButton_Size;
            wc_MoveDownButton.Size = wButton_Size;


            wc_Separator.Margin = wSeparator_Margin;
            wc_Separator.Size = wSeparator_Size;*/


            wavePanels.Add(newWaveControl);

            newWaveControl.Visible = true;

            newWaveControl.Click += waveControl_Click;


            SelectWavePanel(newWaveControl);
        }


        /// <summary>
        /// Designates a specified wave toolstrip as the currently selected wave,
        /// including altering visual elements accordingly.
        /// </summary>
        /// <param name="wavePanels"></param>
        /// <param name="targetPanel"></param>
        public void SelectWavePanel(ToolStrip targetPanel)
        {
            Wave oldWave = selectedWave;

            int waveIndex = wavePanels.IndexOf(targetPanel);

            wManager.SelectWave(waveIndex);

            foreach (ToolStrip w in wavePanels)
            {
                if (w == targetPanel)
                {
                    w.BackColor = w_BackColorSelected;
                }
                else
                {
                    w.BackColor = w_BackColor;
                }
            }

            selectedWaveLabel.Text = wManager.GetWaveName(waveIndex);

            selectedWave = wManager.GetSelectedWave();

            if (selectedWave != oldWave)
            {
                waveNumTop.Value = selectedWave.top;
                waveNumLeft.Value = selectedWave.left;
                waveNumRight.Value = selectedWave.right;
                waveNumBottom.Value = selectedWave.bottom;
            }
        }


        /// <summary>
        /// [Helper Method?]
        /// Allows the main SelectWavePanel() method to be called with an integer index as the parameter,
        /// rather than the toolstrip itself.
        /// </summary>
        /// <param name="waveIndex"></param>
        public void SelectWavePanel(int waveIndex)
        {
            ToolStrip waveToolStrip = wavePanels[waveIndex];

            SelectWavePanel(waveToolStrip);
        }


        public void AddWave()
        {
            if (wavePanels.Count == 0)
            {
                Font oldFont = selectedWaveLabel.Font;
                Font newFont = new Font(oldFont, (FontStyle)5);

                selectedWaveLabel.Font = newFont;

                selectedWaveLabel.Text = "Wave 1";

                waveNumTop.Enabled = true;
                waveNumLeft.Enabled = true;
                waveNumRight.Enabled = true;
                waveNumBottom.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
            }

            CreateWaveControl();
        }


        public void DeleteWave()
        {
            if (wavePanels.Count > 0)
            {
                int removalIndex = wavePanels.Count - 1;

                ToolStrip bottomTS = wavePanels[removalIndex];

                wavePanels.RemoveAt(removalIndex);

                bottomTS.Dispose();

                wManager.RemoveBottomWave();

                selectedWave = null;

                if (wavePanels.Count == 0)
                {
                    Font oldFont = selectedWaveLabel.Font;
                    Font newFont = new Font(oldFont, (FontStyle)0);

                    selectedWaveLabel.Font = newFont;

                    selectedWaveLabel.Text = "(wave list is empty)";

                    waveNumTop.Value = 0;
                    waveNumLeft.Value = 0;
                    waveNumRight.Value = 0;
                    waveNumBottom.Value = 0;

                    waveNumTop.Enabled = false;
                    waveNumLeft.Enabled = false;
                    waveNumRight.Enabled = false;
                    waveNumBottom.Enabled = false;
                    saveToolStripMenuItem.Enabled = false;
                }
                else
                {
                    int selectionIndex = removalIndex - 1;

                    SelectWavePanel(selectionIndex);
                }
            }
        }

        public void RefreshWaveNumText()
        {
            selectedWave = wManager.GetSelectedWave();

            selectedWaveLabel.Text = selectedWave.name;

            waveNumTop.Value = selectedWave.top;
            waveNumLeft.Value = selectedWave.left;
            waveNumRight.Value = selectedWave.right;
            waveNumBottom.Value = selectedWave.bottom;
        }

        public void ValidateWaveNums()
        {
            /*waveNumTop.ValidateEditText();
            waveNumLeft.ValidateEditText();
            waveNumRight.ValidateEditText();
            waveNumBottom.ValidateEditText();*/
        }


        // #############[  EVENTS  ]####################################################
        


        // Triggered by the user clicking the "Add Wave" button.
        private void addWaveButton_Click(object sender, EventArgs e)
        {
            AddWave();
        }


        // Triggered by the user clicking the "Delete Wave" Button.
        private void DeleteWaveButton1_Click(object sender, EventArgs e)
        {
            DeleteWave();
        }

        // Triggered by clicking on a wave toolstrip
        private void waveControl_Click(object sender, EventArgs e)
        {
            ToolStrip waveControl = sender as ToolStrip;

            SelectWavePanel(waveControl);
        }

        private void waveNumTop_ValueChanged(object sender, EventArgs e)
        {
            if (selectedWave != null)
                selectedWave.top = (int)waveNumTop.Value;
        }

        private void waveNumLeft_ValueChanged(object sender, EventArgs e)
        {
            if (selectedWave != null)
                selectedWave.left = (int)waveNumLeft.Value;
        }

        private void waveNumRight_ValueChanged(object sender, EventArgs e)
        {
            if (selectedWave != null)
                selectedWave.right = (int)waveNumRight.Value;
        }

        private void waveNumBottom_ValueChanged(object sender, EventArgs e)
        {
            if (selectedWave != null)
                selectedWave.bottom = (int)waveNumBottom.Value;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                wManager.SaveWaveFile();
            }
            catch (Exception saveFileException)
            {
                MessageBox.Show("ERROR: " + saveFileException.Message,
                "A problem has occurred while attempting to save!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            try
            {
                wManager.LoadWaveFile();
            }
            catch (Exception saveFileException)
            {
                MessageBox.Show("ERROR: " + saveFileException.Message,
                "A problem has occurred while attempting to load!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (fileOperationsInProgress == 0)
            {
                if (e.Control && e.KeyCode == Keys.S && e.KeyCode != Keys.O)
                {
                    fileOperationsInProgress = 1;
                    try
                    {
                        wManager.SaveWaveFile();
                    }
                    catch (Exception saveFileException)
                    {
                        MessageBox.Show("ERROR: " + saveFileException.Message,
                        "A problem has occurred while attempting to save!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    finally
                    {
                        fileOperationsInProgress = 0;
                    }
                }

                else
                if (e.Control && e.KeyCode == Keys.S && e.KeyCode != Keys.O)
                {
                    fileOperationsInProgress = 1;
                    try
                    {
                        wManager.SaveWaveFile();
                    }
                    catch (Exception saveFileException)
                    {
                        MessageBox.Show("ERROR: " + saveFileException.Message,
                        "A problem has occurred while attempting to save!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    finally
                    {
                        fileOperationsInProgress = 0;
                    }
                }
            }
        }

        private void menuStrip1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Click(object sender, EventArgs e)
        {

        }
    }
}
