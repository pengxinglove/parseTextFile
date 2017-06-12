using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parseTextByTab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String path = @"F:\pengxing\人教小学语文1年级下册(家教机)(6.3).drm\人教小学语文1年级下册(家教机)(6.3).drm.xls";
            parseText(path);
        }

        private void parseText(String path)
        {
            List<DianDuInfo> dianDuInfos = new List<DianDuInfo>();
            DianDuInfo temp = new DianDuInfo();
            String fileName = Path.GetFileNameWithoutExtension(path);
            Console.WriteLine("fileName " + fileName );
            bool isFirstRow = true;
            foreach (var line in File.ReadLines(path).Skip(1))
            {
                var tempLine = line.Split('\t');
                temp.bookName = fileName;
                //if()
                temp.imagePath = tempLine[1];
                if (temp.imagePath.EndsWith(".jpg") && isFirstRow)
                {
                    temp.imagePath = "pic\\" + fileName + ".jpg";
                    isFirstRow = false;
                }
                temp.imageContentType = tempLine[2];

                temp.bookPage = tempLine[3];
                temp.BookInfo = tempLine[4];
                temp.ISBN = tempLine[5];

                Console.WriteLine("imagePath " + temp.imagePath + " - page " + temp.bookPage +
                    " -ISBN " + temp.ISBN);
                dianDuInfos.Add(temp);
            }
        }
    }
}
