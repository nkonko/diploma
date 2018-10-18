﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace UI.FORMULARIOS
{
    public partial class FileExplorer : Form
    {
        List<string> listFiles = new List<string>();

        public FileExplorer()
        {
            InitializeComponent();
        }

        private void FileExplorer_Load(object sender, EventArgs e)
        {

        }

        private void btnIr_Click(object sender, EventArgs e)
        {
            //Clear all items
            listFiles.Clear();
            listView.Items.Clear();
            //Open folder browser dialog
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Ingrese directorio" })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    //Set path to textbox
                    txtPath.Text = fbd.SelectedPath;
                    foreach (string item in Directory.GetFiles(fbd.SelectedPath))
                    {
                        //Add image to imagelist
                        imageList.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(item));
                        FileInfo fi = new FileInfo(item);
                        listFiles.Add(fi.FullName);//Add file name to list
                                                   //Add file name and image to listview
                        listView.Items.Add(fi.Name, imageList.Images.Count - 1);
                    }
                }
            }
        }
    }
}