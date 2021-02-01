using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WaveEditor_v1
{
    class WaveManager
    {
        // ===== FIELDS ===== 

        private Form1 mainWindow;

        private List<Wave> waveList;
        private int selectedIndex;
        private int wavesAdded;
        
        private string gameExeFilePath = "";


        // ===== PROPERTIES =====
        
        public int SelectedIndex
        {
            get { return selectedIndex; }
        }


        // ===== CONSTRUCTOR ===== 

        public WaveManager(Form1 mainWindow)
        {
            this.mainWindow = mainWindow;

            waveList = new List<Wave>();
            selectedIndex = 0;
            wavesAdded = 0;
        }


        // ===== METHODS ===== 

        /// <summary>
        /// Creates a new wave object, adds it to the list, and selects it.
        /// </summary>
        public Wave AddWave()
        {
            Wave newWave = new Wave();
            newWave.name = string.Format("Wave {0}", wavesAdded + 1);

            waveList.Add(newWave);

            //selectedIndex = wavesAdded;
            SelectWave(newWave.name);

            wavesAdded++;

            return newWave;
        }

        /// <summary>
        /// Creates a new wave object, adds it to the list, and selects it.
        /// </summary>
        /*public Wave AddWave(string name, int top, int left, int right, int bottom)
        {
            Wave newWave = new Wave();
            newWave.name = string.Format("Wave {0}", wavesAdded + 1);

            waveList.Add(newWave);

            //selectedIndex = wavesAdded;
            SelectWave(newWave.name);

            wavesAdded++;

            return newWave;
        }*/

        /// <summary>
        /// [HelperMethod]
        /// Checks that a wave with the specified name exists.
        /// </summary>
        /// <param name="waveName">The wave's name.</param>
        /// <returns>Whether a wave with the specified name exists.</returns>
        public bool CheckExists(string waveName)
        {
            foreach (Wave w in waveList)
            {
                if (w.name == waveName)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// [HelperMethod]
        /// Sets the "isSelected" boolean value of the corresponding wave to true,
        /// and sets it to false for all other waves.
        /// Also sets selectedIndex to the index of the selected wave.
        /// </summary>
        /// <param name="waveName">The name of the wave</param>
        public void SelectWave(string waveName)
        {
            if (CheckExists(waveName))
            {
                for (int i = 0; i < waveList.Count; i++)
                {
                    Wave iWave = waveList[i];
                    if (iWave.name == waveName)
                    {
                        iWave.isSelected = true;
                        selectedIndex = i;
                    }
                    else
                    {
                        iWave.isSelected = false;
                    }
                }
            }
            else
            {
                throw new Exception("Error in SelectWave() method: Invalid name, wave does not exist.");
            }
        }


        /// <summary>
        /// [HelperMethod]
        /// Sets the "isSelected" boolean value of the corresponding wave to true,
        /// and sets it to false for all other waves.
        /// Also sets selectedIndex to the index of the selected wave.
        /// </summary>
        /// <param name="waveName">The name of the wave</param>
        public void SelectWave(int waveIndex)
        {
            for (int i = 0; i < waveList.Count; i++)
            {
                if (i == waveIndex)
                {
                    waveList[i].isSelected = true;
                    selectedIndex = i;
                }
                else
                {
                    waveList[i].isSelected = false;
                }
            }
        }



        /// <summary>
        /// Removes a wave from the list.
        /// If the wave had been selected,
        /// changes selection to an adjacent wave.
        /// </summary>
        /// <param name="waveName">T</param>
        public void RemoveWave(string waveName)
        {
            if (CheckExists(waveName))
            {
                int waveIndex = 0;
                bool wasSelected = false;
                for (int i = 0; i < waveList.Count; i++)
                {
                    Wave iWave = waveList[i];
                    if (iWave.name == waveName)
                    {
                        waveIndex = i;
                        wasSelected = iWave.isSelected;
                    }
                }
                waveList.RemoveAt(waveIndex);
                
                if (wasSelected)
                {
                    if (waveList.Count > 0)
                    {
                        if (waveIndex > 0)
                        {
                            waveIndex--;
                        }
                        SelectWave(waveList[waveIndex].name);
                    }
                }
            }
            else
            {
                throw new Exception("Error in RemoveWave() method: Invalid name, wave does not exist.");
            }
        }

        /// <summary>
        /// Gets the index of a specified wave.
        /// </summary>
        /// <param name="waveName">The wave's name</param>
        /// <returns>The wave's index</returns>
        public int GetIndex(string waveName)
        {
            if (CheckExists(waveName))
            {
                for (int i = 0; i < waveList.Count; i++)
                {
                    Wave iWave = waveList[i];
                    if (iWave.name == waveName)
                    {
                        return i;
                    }
                }
            }
            
            throw new Exception("Error in SelectWave() method: Invalid name, wave does not exist.");
        }

        /// <summary>
        /// Gets the 'name' of a specified wave.
        /// </summary>
        /// <param name="index">The wave's index</param>
        /// <returns>The wave's name (as a string)</returns>
        public string GetWaveName(int index)
        {
            Wave wave = waveList[index];

            return wave.name;
        }

        public void RemoveBottomWave()
        {
            if (waveList.Count > 0)
            {
                waveList.RemoveAt(waveList.Count - 1);
                wavesAdded--;
                selectedIndex = waveList.Count - 1;
            }
        }

        /// <summary>
        /// Gets the specified wave.
        /// </summary>
        /// <param name="index">The wave's index</param>
        /// <returns>The specified wave</returns>
        public Wave GetSelectedWave()
        {
            if (wavesAdded > 0)
            {
                Wave wave = waveList[SelectedIndex];

                return wave;
            }
            else
            {
                return null;
            }
        }


        public void SaveWaveFile()
        {
            bool validGameExe = false;
            if (File.Exists("BuzzBattle.exe"))
            {
                gameExeFilePath = Path.GetFullPath("BuzzBattle.exe");
                validGameExe = true;
            }
            else
            {
                if (gameExeFilePath == "" || File.Exists(gameExeFilePath) == false)
                {
                    OpenFileDialog findGameExeFileDialog = new OpenFileDialog();

                    findGameExeFileDialog.Title = "Please locate the game's executable file (BuzzBattle.exe)";
                    findGameExeFileDialog.Filter = "Executable Files|*.exe";

                    findGameExeFileDialog.InitialDirectory = Directory.GetCurrentDirectory();

                    findGameExeFileDialog.CheckFileExists = true;
                    findGameExeFileDialog.CheckPathExists = true;

                    findGameExeFileDialog.DereferenceLinks = true;


                    if (findGameExeFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(findGameExeFileDialog.FileName))
                        {
                            if (findGameExeFileDialog.SafeFileName == "BuzzBattle.exe")
                            {
                                gameExeFilePath = findGameExeFileDialog.FileName;
                                validGameExe = true;
                            }
                        }
                    }
                }
                else
                {
                    validGameExe = true;
                }
            }

            if (validGameExe)
            {
                DirectoryInfo newDirectoryInfo = Directory.GetParent(gameExeFilePath);
                
                string newDirPath = newDirectoryInfo.FullName;

                string currentDirectory = Directory.GetCurrentDirectory();

                if (currentDirectory != newDirPath)
                {
                    Directory.SetCurrentDirectory(newDirPath);
                }

                if (File.Exists("waves.txt"))
                {
                    File.Delete("waves.txt");
                }

                FileStream outStream = File.OpenWrite("waves.txt");
                StreamWriter output = new StreamWriter(outStream);

                int totalWaves = waveList.Count;

                output.WriteLine(totalWaves);

                Wave finalWave = waveList[totalWaves - 1];

                int finalWaveEnemyCount = 0;

                finalWaveEnemyCount += finalWave.top;
                finalWaveEnemyCount += finalWave.left;
                finalWaveEnemyCount += finalWave.right;
                finalWaveEnemyCount += finalWave.bottom;

                output.WriteLine(finalWaveEnemyCount);

                for (int i = 0; i < totalWaves; i++)
                {
                    Wave waveToSave = waveList[i];

                    string waveData = "";

                    if (waveToSave.name == null)
                    {
                        waveData += "null";
                    }
                    else
                    {
                        waveData += waveToSave.name;
                    }

                    waveData += ',';
                    waveData += waveToSave.top;
                    waveData += ',';
                    waveData += waveToSave.left;
                    waveData += ',';
                    waveData += waveToSave.right;
                    waveData += ',';
                    waveData += waveToSave.bottom;

                    output.WriteLine(waveData);
                }

                output.Close();
                outStream.Close();

                MessageBox.Show("The wave file has saved successfully!",
                "File saved.",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }


        public void LoadWaveFile()
        {
            bool validWaveFile = false;
            string waveFilePath = "";

            if (File.Exists("waves.txt"))
            {
                waveFilePath = "waves.txt";
                validWaveFile = true;
            }
            else
            {
                OpenFileDialog findGameExeFileDialog = new OpenFileDialog();

                findGameExeFileDialog.Title = "Please locate the save file (waves.txt)";
                findGameExeFileDialog.Filter = "Text Files|*.txt";

                findGameExeFileDialog.InitialDirectory = Directory.GetCurrentDirectory();

                findGameExeFileDialog.CheckFileExists = true;
                findGameExeFileDialog.CheckPathExists = true;

                findGameExeFileDialog.DereferenceLinks = true;


                if (findGameExeFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(findGameExeFileDialog.FileName))
                    {
                        if (findGameExeFileDialog.SafeFileName == "waves.txt")
                        {
                            waveFilePath = findGameExeFileDialog.FileName;
                            validWaveFile = true;
                        }
                    }
                }
            }

            if (validWaveFile)
            {
                DirectoryInfo newDirectoryInfo = Directory.GetParent(waveFilePath);

                string newDirPath = newDirectoryInfo.FullName;

                string currentDirectory = Directory.GetCurrentDirectory();

                if (currentDirectory != newDirPath)
                {
                    Directory.SetCurrentDirectory(newDirPath);
                }

                FileStream inStream = File.OpenRead("waves.txt");
                StreamReader input = new StreamReader(inStream);

                int totalWaves = int.Parse(input.ReadLine());

                int finalWaveEnemyCount = int.Parse(input.ReadLine());

                List<string[]> wavesAsStringArrays = new List<string[]>();

                string line = "";

                int totalWavesRead = 0;

                do
                {
                    line = input.ReadLine();

                    if (line != null && line != "")
                    {
                        string[] waveData = line.Split(',');
                        wavesAsStringArrays.Add(waveData);
                        totalWavesRead++;
                    }
                }
                while (line != null && line != "");

                input.Close();
                inStream.Close();

                if (totalWaves != totalWavesRead)
                {
                    throw new Exception("Discrepancy in wave quantities.");
                }

                int wpCount = mainWindow.wavePanels.Count;
                for (int w = 0; w < wpCount; w++)
                {
                    mainWindow.DeleteWave();
                }

                wavesAdded = 0;
                mainWindow.wavePanels.Clear();

                for (int i = 0; i < totalWaves; i++)
                {
                    mainWindow.AddWave();
                }

                for (int i = 0; i < totalWaves; i++)
                {
                    string[] waveArray = wavesAsStringArrays[i];

                    Wave newWave = waveList[i];

                    newWave.name = waveArray[0];

                    newWave.top = int.Parse(waveArray[1]);
                    newWave.left = int.Parse(waveArray[2]);
                    newWave.right = int.Parse(waveArray[3]);
                    newWave.bottom = int.Parse(waveArray[4]);
                }

                selectedIndex = waveList.Count - 1;

                mainWindow.RefreshWaveNumText();

                MessageBox.Show("The wave file has loaded successfully!",
                    "File loaded.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
