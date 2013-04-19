using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FileDeleter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if  (txtBase.Text.Trim() != String.Empty)
            {
                string url = txtBase.Text.Trim()+@"\";
                
                ArrayList arrList = new ArrayList();
                arrList.AddRange(txtList.Text.Split('\n'));

                string exc = "";
                string nonDeleted = "";

                int i = 0;
                int nonDelCount = 0;
                for (; i < arrList.Count; i++)
                {

                    string curURL = url + arrList[i];

                    if (curURL.Trim() != String.Empty)
                    {
                        if (System.IO.File.Exists(curURL))
                        {
                            try
                            {
                                System.IO.File.Delete(curURL);
                                arrList.Remove(i);
                            }
                            catch (Exception ex)
                            {
                                nonDelCount++;
                                exc += ex.Message + " : " + curURL + "\n";
                                nonDeleted += curURL + "\n";
                            }

                        }
                        else
                        {
                           nonDelCount++;
                           nonDeleted += curURL + "\n";
                            
                        }
                    }
                 
                }

                MessageBox.Show(i - nonDelCount + " File(s) Deleted", "File Deletion",MessageBoxButtons.OK,MessageBoxIcon.Information);


                if (exc != "")
                {
                    txtList.Text += exc+"\n \n *******************************************************";
                }
                if (nonDelCount > 0)
                {
                    txtList.Text = "Following files did not get deleted : \n" + nonDeleted;
                }
                else
                {
                    txtList.Text = "";
                }
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            txtList.Text = txtList.Text.Replace("/", @"\");
        }
    }
}
