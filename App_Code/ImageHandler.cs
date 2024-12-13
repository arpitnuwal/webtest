using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
/// <summary>
/// Summary description for WaterMark
/// </summary>
public class ImageHandler
{
    public bool havException { get; set; }
    public string ExceptionMessage { get; set; }
    public ImageHandler()
	{
        havException = false;
        ExceptionMessage = string.Empty;
	}
    public Image AddWatermarkText(byte[] imageByte,string textOnImage)
    {
        System.Drawing.Image img = null;
        try
        {
            MemoryStream memStream = new MemoryStream(imageByte);
            img = System.Drawing.Image.FromStream(memStream);
            Graphics g = System.Drawing.Graphics.FromImage(img);
            Font font = new Font("Aril", 20, FontStyle.Bold);

            SolidBrush solidBrush = new SolidBrush(Color.Red);
            Point point = new Point(img.Width / 5, img.Height / 2);
            g.DrawString(textOnImage, font, solidBrush, point);
            g.Save();

            memStream.Dispose();
            g.Dispose();
            solidBrush.Dispose();
            font.Dispose();
        }
        catch(Exception ex)
        {
            havException = true;
            ExceptionMessage = ex.Message;
        }
        return img;
    }
    public Bitmap CreateThumbnail(byte[] imageByte, bool maintainAspectRatio, int desiredWidth, int desiredHeight)
    {
        Bitmap bmp = null;
        try
        {
            MemoryStream memStream = new MemoryStream(imageByte);
            System.Drawing.Image img = System.Drawing.Image.FromStream(memStream);

            if (maintainAspectRatio)
            {
                AspectRatio aspectRatio = new AspectRatio();
                aspectRatio.WidthAndHeight(img.Width, img.Height, desiredWidth, desiredHeight);
                bmp = new Bitmap(img, aspectRatio.Width, aspectRatio.Height);
            }
            else
            {
                bmp = new Bitmap(img, desiredWidth, desiredHeight);
            }
            memStream.Dispose();
        }
        catch(Exception ex)
        {
            havException = true;
            ExceptionMessage = ex.Message;
        }
        return bmp;
    }
}