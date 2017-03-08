﻿using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SHColorPicker
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// R, G, B 코드, #FFF 코드 등을 생성해서 화면에 적용시킨다.
        /// </summary>
        /// <param name="color"></param>
        public void generateView_fromColor(Color color)
        {
            if(imgResultColor.BackColor == color) {
                return;
            }
            debug("generateView_fromColor" + color.ToString());
            txtColorCodeR.Text = color.R.ToString();
            txtColorCodeG.Text = color.G.ToString();
            txtColorCodeB.Text = color.B.ToString();
            txtColorCodeFF.Text = getHEX_fromColor(color);
            txtColorCodeRGB.Text = getRGB_fromColor(color);
            imgResultColor.BackColor = color;
            //mParentForm.txtColorCodeFF.Text = string.Concat("#", ColorTranslator.ToHtml(color).Substring(1, 6));
            //txtColorCodeFF.Text = String.Format(ColorTranslator.ToHtml(color).ToString());
            //Debug.WriteLine("generateView_fromColor : " + ColorTranslator.ToHtml(color).ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        private void changeColorRGBText()
        {
            //Color color = new Color();
            int colorR, colorG, colorB;
            try
            {
                colorR = Int32.Parse(txtColorCodeR.Text);
                if (colorR > 255) colorR = 255;
                if (colorR < 0) colorR = 0;
            }
            catch (Exception e)
            {
                colorR = 0;
            }
            try
            {
                colorG = Int32.Parse(txtColorCodeG.Text);
                if (colorG > 255) colorG = 255;
                if (colorG < 0) colorG = 0;
            }
            catch (Exception e)
            {
                colorG = 0;
            }
            try
            {
                colorB = Int32.Parse(txtColorCodeB.Text);
                if (colorB > 255) colorB = 255;
                if (colorB < 0) colorB = 0;
            }
            catch (Exception e)
            {
                colorB = 0;
            }

            try
            {
                //color = Color.FromArgb(colorR, colorG, colorB);
                generateView_fromColor(Color.FromArgb(colorR, colorG, colorB));
            }
            catch (Exception e)
            {
                //color = Color.Black;
                generateView_fromColor(Color.Black);
            }
            
        }

        /// <summary>
        /// Color 를 Hex 로 변환
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private String getHEX_fromColor(Color color)
        {
            String hex = String.Empty;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("#");
                sb.Append(color.R.ToString("X2"));
                sb.Append(color.G.ToString("X2"));
                sb.Append(color.B.ToString("X2"));
                hex = sb.ToString();
                sb.Length = 0;
                //hex = "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
                //hex = String.Format("#{0}{1}{2}",color.R.ToString("X2"), color.G.ToString("X2"), color.B.ToString("X2"));
            }
            catch (Exception e)
            {

            }
            return hex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private String getRGB_fromColor(Color color)
        {
            String rgb = String.Empty;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("RGB(");
                sb.Append(color.R.ToString());
                sb.Append(", ");
                sb.Append(color.G.ToString());
                sb.Append(", ");
                sb.Append(color.B.ToString());
                sb.Append(")");
                //rgb = "RGB(" + color.R.ToString() + ", " + color.G.ToString() + ", " + color.B.ToString() + ")";
                rgb = sb.ToString();
                sb.Length = 0;
            }
            catch (Exception e)
            {
            }
            return rgb;
        }

        /// <summary>
        /// debug 용 메서드
        /// </summary>
        /// <param name="msg"></param>
        private void debug(string msg)
        {
            if(isDebug) System.Diagnostics.Debug.WriteLine(msg);
        }
    }
}
