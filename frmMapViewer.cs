using Extensions;
using MOTHER3;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MOTHER3Funland
{
    public partial class frmMapViewer : M3Form
    {
        // Layer stuff
        CheckBox[] chkLayer = new CheckBox[3];
        CheckBox[] chkTable = new CheckBox[6];

        bool loading = false;

        // Text cache
        string[] mapnames = new string[TextMapNames.Entries - 1];

        public frmMapViewer()
        {
            InitializeComponent();

            // Draw the layer stuff
            for (int i = 0; i < 3; i++)
            {
                var cb = new CheckBox();
                cb.AutoSize = true;
                cb.Text = "Layer " + (i + 1).ToString();
                cb.Checked = true;
                cb.Left = 53 + (i * 80);
                cb.Top = 39;
                cb.Visible = true;
                cb.CheckedChanged += new EventHandler(cboRoom_SelectedIndexChanged);
                this.Controls.Add(cb);
                chkLayer[i] = cb;
            }
            for (int u = 0; u < 6; u++)
            {
                var cc = new CheckBox();
                cc.AutoSize = true;
                if (u != 5)
                {
                    cc.Text = "Table " + (u + 1).ToString();
                    cc.Checked = true;
                }
                if (u == 5)
                {
                    cc.Text = "Combine";
                    cc.Checked = false;
                }
                cc.Left = 53 + (u * 80);
                cc.Top = 59;
                cc.Visible = true;
                cc.CheckedChanged += new EventHandler(cboRoom_SelectedIndexChanged);
                this.Controls.Add(cc);
                chkTable[u] = cc;
            }
            MapData.Init();
            // Load the map names
            loading = true;
            Helpers.CheckFont(cboRoom);
            cboRoom.JapaneseSearch = M3Rom.Version == RomVersion.Japanese;
            for (int i = 0; i < mapnames.Length - 1; i++)
            {
                mapnames[i] = TextMapNames.GetName(i + 1);
                cboRoom.Items.Add("[" + i.ToString("X3") + "] " +
                    mapnames[i].Replace(Environment.NewLine, " "));
            }
            loading = false;
            cboRoom.SelectedIndex = 0;
        }
        Bitmap a, b;
        Image pictureBox1Image;
        public static Bitmap MergeTwoImages(Image firstImage, Image secondImage)
        {
            if (firstImage == null)
            {
                throw new ArgumentNullException("firstImage");
            }
            if (secondImage == null)
            {
                throw new ArgumentNullException("secondImage");
            }
            int outputImageWidth = firstImage.Width;
            int outputImageHeight = firstImage.Height;
            Bitmap outputImage = new Bitmap(outputImageWidth, outputImageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                graphics.DrawImage(firstImage, new Rectangle(new Point(), firstImage.Size),
                    new Rectangle(new Point(), firstImage.Size), GraphicsUnit.Pixel);
                graphics.DrawImage(secondImage, new Rectangle(new Point(), secondImage.Size),
                    new Rectangle(new Point(), secondImage.Size), GraphicsUnit.Pixel);
            }
            return outputImage;
        }
        private void cboRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;
            int flags = 0;
            for (int i = 0; i < 3; i++)
                flags |= (chkLayer[i].Checked ? (1 << i) : 0);
            pMap.Image = MapData.GetMap(cboRoom.SelectedIndex, flags);
            if(pMap.Image!=null)
            pictureBox1Image = MapData.GetSprites(pMap.Image.Width, pMap.Image.Height, cboRoom.SelectedIndex, chkTable, out a, out b);
            if ((pMap.Image != null)&&(a!=null))
            {
                pMap.Image = MergeTwoImages(pMap.Image, pictureBox1Image);
                pMap.Image = MergeTwoImages(pMap.Image, a);
                pMap.Image = MergeTwoImages(pMap.Image, b);
                if ((chkTable[5].Checked == true)&&(cboRoom.SelectedIndex!=0x374))
                {
                    a=MapData.GetLayer1(cboRoom.SelectedIndex, flags);
                    if((a!=null)&&(cboRoom.SelectedIndex!=0x95)&&(cboRoom.SelectedIndex != 0x6D))
                        pMap.Image = MergeTwoImages(pMap.Image, a);
                    else
                        pMap.Image = MergeTwoImages(pMap.Image, MapData.GetLayer2(cboRoom.SelectedIndex, flags));
                }
            }
            pMap.Refresh();
        }
        private void mnuMapCopy_Click(object sender, EventArgs e)
        {
            Helpers.GraphicsCopy(sender);
        }

        private void mnuMapSave_Click(object sender, EventArgs e)
        {
            Helpers.GraphicsSave(sender, dlgSaveImage);
        }

        public override void SelectIndex(int[] index)
        {
            cboRoom.SelectedIndex = index[0];
        }

        public override int[] GetIndex()
        {
            return new int[] { cboRoom.SelectedIndex };
        }
    }
}
