using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging;

namespace ImageCompressing
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void CompressImage(Image srcImage, int imageQuality, string savePath)
        {
            try
            {
                ImageCodecInfo jpegCodec = null;

                EncoderParameter imageQualityParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality,imageQuality);

                ImageCodecInfo[] everyCodecs = ImageCodecInfo.GetImageEncoders();

                EncoderParameters codecParameter = new EncoderParameters(1);
                codecParameter.Param[0] = imageQualityParameter;

                for (int x = 0; x < everyCodecs.Length; x++)
                {
                    if (everyCodecs[x].MimeType == "image/jpeg")
                    {
                        jpegCodec = everyCodecs[x];
                        break;
                    }     

                }

            }

            catch(Exception e)
            {
                throw e;
            }
        }


        private void btnBrowse_click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Title = "Select an image ";
            od.Filter = "Jpeg Images(*.jpg)|*.jpg";
            od.Filter += "|Png Images(*.png)|*.png";
            od.Filter += "|Bitmap Images(*.bmp)|*.bmp";
            od.Filter += " |All(*.JPG,*.PNG,*.BMP)|*.JPG;*.PNG;*.BMP";
            od.FilterIndex = 1;

            if(od.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                 textBox1.Text = od.FileName;
                Image imageIn  = Image.FromFile(textBox1.Text);
                pictureBox1.Image = imageIn;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Please load Image first");
            }
            else if(textBox1.Text.Contains(".jpg"))
            {
                CompressImage(Image.FromFile(textBox1.Text), 30, textBox1.Text.Insert(textBox1.Text.Length - 4, "JPEG Image compressed"));
                MessageBox.Show("Image compressed");
            }
            else
            {
                string pr = textBox1.Text.Insert(textBox1.Text.Length - 4, "JPEG Image compressed");
                string p = "abcdef"; 

                CompressImage(Image.FromFile(textBox1.Text), 30, textBox1.Text.Insert(textBox1.Text.Length - 4, "JPEG Image compressed").Substring(0, pr.Length - 4) + ".jpg");
                MessageBox.Show("Image compressed");
            }
        }

    }
}
