using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace SchoolDialogCreator
{
    

    public partial class Form1 : Form
    {
        private int selectedSpeech = -1;

        public Form1()
        {
            InitializeComponent();
            DataStorage.init();
        }

        private void loadAppropriateSpeeches()
        {
            String flagString = getFlagsString();
            int minNsCount = 99999;
            String minNsCountFile = "";
            Directory.CreateDirectory(DataStorage.mainChar);
            foreach (String file in Directory.GetFiles(DataStorage.mainChar))
            {               
                String fileName = file.Substring(DataStorage.mainChar.Length + 1, file.Length - DataStorage.mainChar.Length - 1);
                if (fileName == "data") continue;
                int nsCount = 0;
                bool fail = false;
                int i = 0;
                foreach (Char c in fileName)
                {
                    if (c == 'n')
                    {
                        nsCount++;
                    }else 
                    {
                        fail = (c != flagString[i] && flagString[i] != 'n');
                    }
                    if (fail)
                    {
                        break;
                    }
                    i++;
                }
                if (!fail && nsCount < minNsCount)
                {
                    minNsCount = nsCount;
                    minNsCountFile = file;
                }
            }
            if (minNsCountFile != "")
            {
                DataStorage.speeches = parseSpeech(minNsCountFile);
                
            }
            else
            {
                DataStorage.speeches = new ArrayList();
            }
            invalidateSpeeches();
        } 

        private String getFlagsString()
        {
            String str = "";
            CheckedListBox l = (CheckedListBox)this.Controls.Find("flagsList", false)[0];
            for (int i = 0; i < DataStorage.flags.Count; ++i)
            {
                switch ((CheckState)DataStorage.flags[i])
                {
                    case CheckState.Checked:
                        str += "1";
                        break;

                    case CheckState.Indeterminate:
                        str += "n";
                        break;

                    case CheckState.Unchecked:
                        str += "0";
                        break;
                }
            }
            return str;
        }

        private void loadCharDialog(String name)
        {         
            String path = name + "\\";
            if (name == DataStorage.mainChar)
            {
                path += getFlagsString();
                DataStorage.speeches = parseSpeech(path);
            }
            else
            {
                parseData(path + "data");              
            }
        }

        private void parseData(String name)
        {
            String path = name + "\\data";
            if (!File.Exists(path))
            {
                return;
            }
            using (System.IO.StreamReader file =
            new System.IO.StreamReader(path))
            {
                setMainChar(file.ReadLine(), Convert.ToInt32(file.ReadLine()));
                int charCount = Convert.ToInt32(file.ReadLine());
                for (int i = 0; i < charCount; ++i)
                {
                    addChar(file.ReadLine(), Convert.ToInt32(file.ReadLine()));
                }
                int flagCount = Convert.ToInt32(file.ReadLine());
                for (int i = 0; i < flagCount; ++i)
                {
                    addFlag(file.ReadLine());
                }
            }
            //loadAppropriateSpeeches();
        }

        private ArrayList parseSpeech(String path)
        {
            //return null;
            ArrayList speeches = new ArrayList();
            using (System.IO.StreamReader file =
            new System.IO.StreamReader(path))
            {
                char c;
                String line = file.ReadLine();
                int charId = -1;
                int flagCharId = -1;
                int texCharId = -1;
                int flagId = -1;
                int transId = -1;
                String imageName = "";
                int sti = 0;
                do
                {
                    Speech spc = new Speech();
                    c = line.ElementAt(0);
                    if (c == '\uFEFF' || c == '#')
                    {
                       
                        ArrayList phrases = new ArrayList();
                        String name = file.ReadLine();
                        line = file.ReadLine();
                        c = line.ElementAt(0);
                        if (c >= '0' && c < '9')
                        {
                            charId = Int32.Parse(line);
                            if (charId != 0)
                            {
                                texCharId = charId;
                            }
                            imageName = file.ReadLine();
                            line = file.ReadLine();
                        }
                        do
                        {
                            phrases.Add(line);
                            line = file.ReadLine();
                            c = line.ElementAt(0);
                        } while (c != '&' && c != '*' && c != '%' && c != '\uFEFF' && c != '$' && c != '#');

                        if (c == '&')
                        {
                            line = file.ReadLine();
                            transId = Int32.Parse(line);
                            spc.speakerPseudonym = name;
                            spc.speakerSprite = imageName;
                            spc.speakerID = charId;
                            spc.answersFlagsID = flagId;
                            spc.lines = phrases;
                            spc.answersFlagsVal = false;
                            spc.isAQuestion = false;
                            spc.gotoID = transId;
                            speeches.Add(spc);
                            //speeches.add(new Speech(name, phrases, assets, charPath + "/" + texCharId + "/graphics/" + imageName + ".png", charId, flagCharId, flagId, false, npcs));
                            //speechTransitionsIds.add(transId);
                            sti++;
                            line = file.ReadLine();
                            c = line.ElementAt(0);
                        }
                        else if (c == '*')
                        {
                            line = file.ReadLine();
                            flagCharId = Int32.Parse(line);
                            line = file.ReadLine();
                            flagId = Int32.Parse(line);
                            line = file.ReadLine();
                            int flagVal = Int32.Parse(line);
                            Boolean flagV = true;
                            if (flagVal == 0)
                            {
                                flagV = false;
                            }
                            line = file.ReadLine();
                            c = line.ElementAt(0);
                            spc.speakerPseudonym = name;
                            spc.speakerSprite = imageName;
                            spc.speakerID = charId;
                            spc.answersFlagsID = flagId;
                            spc.lines = phrases;
                            spc.answersFlagsVal = flagV;
                            spc.isAQuestion = false;
                            spc.gotoID = -1;
                            speeches.Add(spc);
                            //speeches.add(new Speech(name, phrases, assets, charPath + "/" + texCharId + "/graphics/" + imageName + ".png", charId, flagCharId, flagId, flagV, npcs));
                            //speechTransitionsIds.add(speechTransitionsIds.size() + 1);
                        }
                        else
                        {
                            spc.speakerPseudonym = name;
                            spc.speakerSprite = imageName;
                            spc.speakerID = charId;
                            spc.answersFlagsID = flagId;
                            spc.lines = phrases;
                            spc.answersFlagsVal = false;
                            spc.isAQuestion = false;
                            spc.gotoID = -1;
                            speeches.Add(spc);
                            //speeches.add(new Speech(name, phrases, assets, charPath + "/" + texCharId + "/graphics/" + imageName + ".png", charId, flagCharId, flagId, false, npcs));
                            //speechTransitionsIds.add(speechTransitionsIds.size() + 1);
                        }
                    }
                    else if (c == '%')
                    {
                        //speechTransitionsIds.set(speechTransitionsIds.size() - 1, -1 * (choiceTransitionsIds.size() + 1));
                        //choiceTransitionsIds.add(new ArrayList<Integer>());
                        ArrayList phrases = new ArrayList();
                        
                        line = file.ReadLine();
                        String question = line;
                        line = file.ReadLine();
                        while (c != '#')
                        {
                            transId = Int32.Parse(line);
                            line = file.ReadLine();
                            phrases.Add(line);
                            spc.answersGotoIDs.Add(transId);
                            //choiceTransitionsIds.get(choiceTransitionsIds.size() - 1).add(transId);
                            line = file.ReadLine();
                            c = line.ElementAt(0);
                        }
                        spc.speakerPseudonym = "";
                        spc.speakerSprite = imageName;
                        spc.speakerID = 0;
                        spc.answersFlagsID = -1;
                        spc.lines.Add(question);
                        spc.answers = phrases;
                        spc.answersFlagsVal = false;
                        spc.isAQuestion = true;
                        spc.gotoID = -1;
                        speeches.Add(spc);
                        //choices.add(new Choice(speeches.get(speeches.size() - 1).phrases.get(speeches.get(speeches.size() - 1).phrases.size() - 1), phrases, assets, charPath + "/" + texCharId + "/graphics/" + imageName + ".png"));
                    }
                    else if (c == '$')
                    {
                        ((Speech)speeches[speeches.Count - 1]).isEnd = true;
                        //speechTransitionsIds.set(speechTransitionsIds.size() - 1, 999999);
                        line = file.ReadLine();
                        if (line != null)
                        {
                            c = line.ElementAt(0);
                        }
                    }
                } while (line != null);
            }
            return speeches;
        }

        private void saveData(String name)
        {
            Directory.CreateDirectory(name);           
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(name + "\\data"))
            {
                file.WriteLine(DataStorage.mainChar);
                file.WriteLine(DataStorage.mainCharID);
                file.WriteLine(DataStorage.chars.Count - 2);
                foreach (string charr in DataStorage.chars)
                {
                    if (charr != "You" && charr != DataStorage.mainChar)
                    {
                        file.WriteLine(charr);
                        file.WriteLine(DataStorage.charIDs[DataStorage.chars.IndexOf(charr)]);
                    }
                }
                file.WriteLine(DataStorage.flags.Count);
                foreach (string flagName in DataStorage.flagNames)
                {
                    file.WriteLine(flagName);
                }
            }
            saveDialog(name);
        }

        private void saveDialog(String name)
        {
            Directory.CreateDirectory(name);
            int choicesCount = 0;
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(name + "\\" + getFlagsString()))
            {
                for (int i = 0; i < DataStorage.speeches.Count; ++i)
                {
                    Speech speech = (Speech)DataStorage.speeches[i];
                    if (!speech.isAQuestion)
                    {
                        file.WriteLine("#" + (i - choicesCount));
                        file.WriteLine(speech.speakerPseudonym);
                        file.WriteLine(speech.speakerID);
                        file.WriteLine(speech.speakerSprite);
                        for (int j = 0; j < speech.lines.Count; ++j)
                        {
                            file.WriteLine(speech.lines[j]);
                        }
                    } else
                    {
                        choicesCount++;
                    }
                    
                    if (speech.isAQuestion)
                    {
                        file.WriteLine("%");
                        file.WriteLine(speech.lines[0]);
                        for (int j = 0; j < speech.answers.Count; ++j)
                        {
                            file.WriteLine(speech.answersGotoIDs[j]);
                            file.WriteLine(speech.answers[j]);
                        }
                    }
                    if (speech.answersFlagsID != -1)
                    {
                        file.WriteLine("*");
                        file.WriteLine(DataStorage.mainCharID);
                        file.WriteLine(speech.answersFlagsID);
                        if (speech.answersFlagsVal)
                        {
                            file.WriteLine(1);
                        } else
                        {
                            file.WriteLine(0);
                        }
                    }
                    if (speech.gotoID >= 0)
                    {
                        file.WriteLine("&");
                        file.WriteLine(speech.gotoID);
                    }
                    if (speech.isEnd)
                    {
                        file.WriteLine("$");
                    }
                }
                file.WriteLine("$");
            }
        }

        private void invalidateChars()
        {
            ListBox l = (ListBox)this.Controls.Find("charsList", false)[0];
            l.Items.Clear();
            ComboBox c = (ComboBox)this.Controls.Find("charChooseBox", false)[0];
            c.Items.Clear();
            for (int i = 0; i < DataStorage.chars.Count; ++i)
            {
                l.Items.Add(DataStorage.chars[i]);
                c.Items.Add(DataStorage.chars[i]);
            }
            ComboBox cc = (ComboBox)this.Controls.Find("spriteChooseBox", false)[0];
            cc.Items.Clear();
            cc.Items.Add("normal");
        }

        private void invalidateFlags()
        {
            CheckedListBox l = (CheckedListBox)this.Controls.Find("flagsList", false)[0];
            l.Items.Clear();
            ComboBox c1 = (ComboBox)this.Controls.Find("choice1FlagName", false)[0];
            c1.Items.Clear();
            for (int i = 0; i < DataStorage.flags.Count; ++i)
            {
                l.Items.Add(DataStorage.flagNames[i]);
                //((CheckBox)l.Items[i]).IsThreeSta
                l.SetItemCheckState(i, (CheckState)DataStorage.flags[i]); 
                c1.Items.Add(DataStorage.flagNames[i]);
            }
        }

        private void invalidateSpeeches()
        {
            TreeView sp = (TreeView)this.Controls.Find("speechesTree", false)[0];
            sp.Nodes.Clear();
            int choicesCount = 0;
            for (int i = 0; i < DataStorage.speeches.Count; ++i)
            {
                Speech speech = ((Speech)DataStorage.speeches[i]);
                String str;
                if (speech.isAQuestion)
                {
                   str = "? ";
                } else
                {
                    str = (i - choicesCount) + " ";
                }
                str += DataStorage.chars[DataStorage.charIDs.IndexOf(speech.speakerID)] + " " + speech.lines[0];

                if (speech.gotoID > 0)
                {
                    str += " -> " + speech.gotoID;
                }

                if ((int)speech.answersFlagsID != -1)
                {
                    int n = (int)speech.answersFlagsID;
                    if (n != -1)
                    {
                        str += " (" + DataStorage.flagNames[n];
                        if ((Boolean)speech.answersFlagsVal)
                        {
                            str += "+";
                        }
                        else
                        {
                            str += "-";
                        }
                        str += ")";
                    }
                }

                sp.Nodes.Add(str);
                for (int j = 0; j < speech.lines.Count; ++j)
                {
                    sp.Nodes[i].Nodes.Add((String)speech.lines[j]);
                }
                if (speech.isAQuestion)
                {
                    choicesCount++;
                    for (int j = 0; j < speech.answers.Count; ++j)
                    {
                        String str2 = (String)speech.answers[j] + " -> " + speech.answersGotoIDs[j];

                        
                        sp.Nodes[i].Nodes.Add(str2);
                    }
                }
            }
        }

        private void setMainChar(String name, int id) {
            
            DataStorage.mainChar = name;
            DataStorage.mainCharID = id;
            DataStorage.chars.Clear();
            DataStorage.charIDs.Clear();
            DataStorage.chars.Add("You");
            DataStorage.charIDs.Add(0);
            DataStorage.chars.Add(DataStorage.mainChar);
            DataStorage.charIDs.Add(id);
            invalidateChars();
            invalidateFlags();
        }

        private void setMainCharButton_Click(object sender, EventArgs e)
        {
            TextBox t = (TextBox)this.Controls.Find("mainCharText", false)[0];
            NumericUpDown g = (NumericUpDown)this.Controls.Find("mainCharID", false)[0];
            setMainChar(t.Text, (int)g.Value);
        }

        private void addChar(String name, int id)
        {
            DataStorage.chars.Add(name);
            DataStorage.charIDs.Add(id);
            invalidateChars();
        }

        private void addCharButton_Click(object sender, EventArgs e)
        {
            TextBox t = (TextBox)this.Controls.Find("newCharText", false)[0];
            NumericUpDown g = (NumericUpDown)this.Controls.Find("newCharID", false)[0];
            if (g.Value > 0)
            {
                addChar(t.Text, (int)g.Value);
            }
        }

        private void addFlag(String name)
        {
            DataStorage.addFlag(name);
            invalidateFlags();
        }

        private void addFlagButton_Click(object sender, EventArgs e)
        {
            TextBox t = (TextBox)this.Controls.Find("newFlagText", false)[0];
            addFlag(t.Text);
        }

        private void addSpeechButton_Click(object sender, EventArgs e)
        {
            Speech speech = new Speech();
            ComboBox sp = (ComboBox)this.Controls.Find("charChooseBox", false)[0];
            speech.speakerID = (int)DataStorage.charIDs[sp.SelectedIndex];
            ComboBox spr = (ComboBox)this.Controls.Find("spriteChooseBox", false)[0];
            speech.speakerSprite = spr.Items[spr.SelectedIndex].ToString();
            NumericUpDown g = (NumericUpDown)this.Controls.Find("nextSpeechID", false)[0];
            if (g.Value != 0)
            {
                speech.gotoID = (int)g.Value;
            }
            CheckBox iss = (CheckBox)this.Controls.Find("questionCheckBox", false)[0];
            CheckBox end = (CheckBox)this.Controls.Find("endCheckBox", false)[0];
            speech.isEnd = end.Checked;
            speech.isAQuestion = (iss.CheckState == CheckState.Checked);
            TextBox ps = (TextBox)this.Controls.Find("pseudonymText", false)[0];
            speech.speakerPseudonym = ps.Text;
            TextBox txt = (TextBox)this.Controls.Find("speechText", false)[0];
            for (int i = 0; i < txt.Lines.GetLength(0); ++i)
            {
                if (txt.Lines[i] != "")
                {
                    if (speech.isAQuestion && i > 0)
                    {
                        speech.answers.Add(txt.Lines[i]);
                    }
                    else
                    {
                        speech.lines.Add(txt.Lines[i]);
                    }
                }
            }
            NumericUpDown gt1 = (NumericUpDown)this.Controls.Find("choice1gotoID", false)[0];
            NumericUpDown gt2 = (NumericUpDown)this.Controls.Find("choice2gotoID", false)[0];
            NumericUpDown gt3 = (NumericUpDown)this.Controls.Find("choice3gotoID", false)[0];
            speech.answersGotoIDs.Add((int)gt1.Value);
            speech.answersGotoIDs.Add((int)gt2.Value);
            speech.answersGotoIDs.Add((int)gt3.Value);
            ComboBox fl1 = (ComboBox)this.Controls.Find("choice1FlagName", false)[0];
            speech.answersFlagsID = (int)fl1.SelectedIndex;
            CheckBox cb1 = (CheckBox)this.Controls.Find("choice1FlagCheckBox", false)[0];
            speech.answersFlagsVal = cb1.Checked;
            if (selectedSpeech == -1)
            {
                DataStorage.speeches.Add(speech);
            } else
            {
                DataStorage.speeches[selectedSpeech] = speech;
                selectedSpeech = -1;
            }
            resetSpeechCreation();
            invalidateSpeeches();
        }

        private void resetSpeechCreation()
        {           
            NumericUpDown g = (NumericUpDown)this.Controls.Find("nextSpeechID", false)[0];
            g.Value = 0;
            CheckBox iss = (CheckBox)this.Controls.Find("questionCheckBox", false)[0];
            CheckBox end = (CheckBox)this.Controls.Find("endCheckBox", false)[0];
            end.Checked = false;
            iss.Checked = false;
            //TextBox ps = (TextBox)this.Controls.Find("pseudonymText", false)[0];
            //ps.Text = "";
            TextBox txt = (TextBox)this.Controls.Find("speechText", false)[0];
            txt.Text = "";
            NumericUpDown gt1 = (NumericUpDown)this.Controls.Find("choice1gotoID", false)[0];
            NumericUpDown gt2 = (NumericUpDown)this.Controls.Find("choice2gotoID", false)[0];
            NumericUpDown gt3 = (NumericUpDown)this.Controls.Find("choice3gotoID", false)[0];
            gt1.Value = 0;
            gt2.Value = 0;
            gt3.Value = 0;
            ComboBox fl1 = (ComboBox)this.Controls.Find("choice1FlagName", false)[0];
            fl1.SelectedIndex = -1;
            CheckBox cb1 = (CheckBox)this.Controls.Find("choice1FlagCheckBox", false)[0];
            cb1.Checked = false;
        }

        private void flagsList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            switch (e.CurrentValue)
            {
                case CheckState.Checked:
                    e.NewValue = CheckState.Unchecked;
                    break;

                case CheckState.Indeterminate:
                    e.NewValue = CheckState.Checked;
                    break;

                case CheckState.Unchecked:
                    e.NewValue = CheckState.Indeterminate;
                    break;
            }
            DataStorage.flags[e.Index] = e.NewValue;
            if (DataStorage.mainChar != "")
            {
                loadAppropriateSpeeches();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveData(DataStorage.mainChar);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            parseData(DataStorage.mainChar);
        }

        private void charChooseBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)this.Controls.Find("pseudonymText", false)[0];
            ComboBox c = (ComboBox)this.Controls.Find("charChooseBox", false)[0];
            t.Text = (String)DataStorage.chars[c.SelectedIndex];
        }

        private void speechesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null) return;
            TreeView spp = (TreeView)this.Controls.Find("speechesTree", false)[0];
            spp.SelectedNode = e.Node;
            Speech speech = (Speech)DataStorage.speeches[e.Node.Index];
            selectedSpeech = e.Node.Index;
            ComboBox sp = (ComboBox)this.Controls.Find("charChooseBox", false)[0];
            sp.SelectedIndex = speech.speakerID;
            ComboBox spr = (ComboBox)this.Controls.Find("spriteChooseBox", false)[0];
            foreach (Object item in spr.Items)
            {
                if (((String)item) == speech.speakerSprite)
                {
                    spr.SelectedItem = item;
                    break; 
                }
            }
            NumericUpDown g = (NumericUpDown)this.Controls.Find("nextSpeechID", false)[0];
            if (speech.gotoID > -1)
            {
                g.Value = speech.gotoID;
            } else
            {
                g.Value = 0;
            }
            CheckBox iss = (CheckBox)this.Controls.Find("questionCheckBox", false)[0];
            CheckBox end = (CheckBox)this.Controls.Find("endCheckBox", false)[0];
            end.Checked = speech.isEnd;
            iss.Checked = speech.isAQuestion;
            TextBox ps = (TextBox)this.Controls.Find("pseudonymText", false)[0];
            ps.Text = speech.speakerPseudonym;
            TextBox txt = (TextBox)this.Controls.Find("speechText", false)[0];
            String text = "";
            if (speech.isAQuestion)
            {
                for (int i = 0; i < speech.answers.Count; ++i)
                {
                    text += speech.answers[i];
                    text += Environment.NewLine;
                }
            }
            else
            {
                for (int i = 0; i < speech.lines.Count; ++i)
                {
                    text += speech.lines[i];
                    text += Environment.NewLine;
                }
            }
            txt.Text = text;
            NumericUpDown gt1 = (NumericUpDown)this.Controls.Find("choice1gotoID", false)[0];
            NumericUpDown gt2 = (NumericUpDown)this.Controls.Find("choice2gotoID", false)[0];
            NumericUpDown gt3 = (NumericUpDown)this.Controls.Find("choice3gotoID", false)[0];
            if (speech.answersGotoIDs.Count > 0) gt1.Value = (int)speech.answersGotoIDs[0];
            else gt1.Value = 0;
            if (speech.answersGotoIDs.Count > 1) gt2.Value = (int)speech.answersGotoIDs[1];
            else gt2.Value = 0;
            if (speech.answersGotoIDs.Count > 2) gt3.Value = (int)speech.answersGotoIDs[2];
            else gt3.Value = 0;
            ComboBox fl1 = (ComboBox)this.Controls.Find("choice1FlagName", false)[0];
            fl1.SelectedIndex = speech.answersFlagsID;
            CheckBox cb1 = (CheckBox)this.Controls.Find("choice1FlagCheckBox", false)[0];
            cb1.Checked = speech.answersFlagsVal;
            invalidateSpeeches();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            selectedSpeech = -1;
            resetSpeechCreation();
        }
    }

    public class Speech
    {
        public int speakerID;
        public int gotoID;
        public String speakerPseudonym;
        public String speakerSprite;
        public ArrayList lines;
        public Boolean isAQuestion;
        public ArrayList answers;
        public ArrayList answersGotoIDs;
        public int answersFlagsID;
        public bool answersFlagsVal;
        public bool isEnd;

        public Speech()
        {
            speakerID = -1;
            gotoID = -1;
            speakerSprite = "normal";
            lines = new ArrayList();
            isAQuestion = false;
            answers = new ArrayList();
            answersGotoIDs = new ArrayList();
            answersFlagsID = -1;
            answersFlagsVal = false;
            speakerPseudonym = "";
            isEnd = false;
        }
    }

    public static class DataStorage
    {
        public static String mainChar;
        public static int mainCharID;
        public static ArrayList chars;
        public static ArrayList charIDs;
        public static ArrayList flagNames;
        public static ArrayList flags;
        public static ArrayList speeches;

        public static void init()
        {
            mainChar = "";
            mainCharID = -1;
            chars = new ArrayList();
            charIDs = new ArrayList();
            flags = new ArrayList();
            flagNames = new ArrayList();
            speeches = new ArrayList();
        }

        public static void addFlag(String name)
        {
            flagNames.Add(name);
            flags.Add(CheckState.Indeterminate);
        }

    }
}
