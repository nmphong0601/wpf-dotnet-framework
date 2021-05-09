using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Presentation;
using System.Drawing.Imaging;
using Syncfusion.OfficeChartToImageConverter;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace MediaTinLanh.Control
{
    public class Control_Presentation
    {

        #region Tạo file Powerpoint

        public static void CreateFiles(string location, string Content, string[] format, Stream img)
        {
            string font = format[0];
            string size = format[1];
            string style = format[2];
            //Kiểm tra nội dung nhập vào
            //Content = Control_Util.RemoveSpecialCharacters(Content);
            //Tách đoạn cho nội dung
            string[] sentences = Control_Util.StringSplit(Content);
            //Tạo file
            IPresentation powerpointDoc = Presentation.Create();
            if (img != Stream.Null)
            {
                ILayoutSlide layoutSlide = powerpointDoc.Masters[0].LayoutSlides.Add(SlideLayoutType.Blank, "CustomLayout");
                //Thiết lập background
                ISlideSize slidesize = layoutSlide.SlideSize;

                //Thêm Background
                //layoutSlide.Background.Fill.SolidFill.Color = ColorObject.FromArgb(78, 89, 90);
                layoutSlide.Shapes.AddPicture(img, 0, 0, slidesize.Width, slidesize.Height);

                ////Tạo slide đầu tiên
                CreateSlide1(powerpointDoc, sentences[0], layoutSlide);
                for (int i = 1; i < sentences.Length; i++)
                {
                    //Chèn dữ liệu vào slide
                    CreateSlide2(i - 1, powerpointDoc, sentences[i], font, size, style, layoutSlide);
                }
            }
            else
            {
                ILayoutSlide layoutSlide = powerpointDoc.Masters[0].LayoutSlides.Add(SlideLayoutType.Blank, "CustomLayout");
                CreateSlide1(powerpointDoc, sentences[0], layoutSlide);
                for (int i = 1; i < sentences.Length; i++)
                {
                    //Tạo slide khác
                    CreateSlide2(i - 1, powerpointDoc, sentences[i], font, size, style, layoutSlide);
                }
            }
            //Lưu tệp tin lại
            powerpointDoc.Save(location);

            //Đóng quá trình tạo
            powerpointDoc.Close();
        }

        public static void CreateFiles(string location, string[] Content, string[] format, Stream img)
        {
            string font = format[0];
            string size = format[1];
            string style = format[2];
            //Kiểm tra nội dung nhập vào
            //Content = Control_Util.RemoveSpecialCharacters(Content);
            //Tách đoạn cho nội dung
            string[] sentences = Content;
            //Tạo file
            IPresentation powerpointDoc = Presentation.Create();
            if (img != Stream.Null)
            {
                ILayoutSlide layoutSlide = powerpointDoc.Masters[0].LayoutSlides.Add(SlideLayoutType.Blank, "CustomLayout");
                //Thiết lập background
                ISlideSize slidesize = layoutSlide.SlideSize;

                //Thêm Background
                //layoutSlide.Background.Fill.SolidFill.Color = ColorObject.FromArgb(78, 89, 90);
                layoutSlide.Shapes.AddPicture(img, 0, 0, slidesize.Width, slidesize.Height);

                ////Tạo slide đầu tiên
                CreateSlide1(powerpointDoc, sentences[0], layoutSlide);
                for (int i = 1; i < sentences.Length; i++)
                {
                    //Chèn dữ liệu vào slide
                    CreateSlide2(i - 1, powerpointDoc, sentences[i], font, size, style, layoutSlide);
                }
            }
            else
            {
                ILayoutSlide layoutSlide = powerpointDoc.Masters[0].LayoutSlides.Add(SlideLayoutType.Blank, "CustomLayout");
                CreateSlide1(powerpointDoc, sentences[0], layoutSlide);
                for (int i = 1; i < sentences.Length; i++)
                {
                    //Tạo slide khác
                    CreateSlide2(i - 1, powerpointDoc, sentences[i], font, size, style, layoutSlide);
                }
            }
            //Lưu tệp tin lại
            powerpointDoc.Save(location);

            //Đóng quá trình tạo
            powerpointDoc.Close();
        }

        #endregion

        #region  Slide đầu tiên

        public static void CreateSlide1(IPresentation presentation, string content,ILayoutSlide LayputLayoutSlide)
        {
            ISlide firstSlide = presentation.Slides.Add(LayputLayoutSlide);
            IShape textShape = firstSlide.AddTextBox(0, 0, firstSlide.SlideSize.Width, firstSlide.SlideSize.Height);

            IParagraph paragraph = textShape.TextBody.AddParagraph();
            
            //Căn giữa
            paragraph.HorizontalAlignment = HorizontalAlignmentType.Center;

            //Thêm textbox
            ITextPart textPart = paragraph.AddTextPart(content);
            
            //Font chữ
            textPart.Font.Color = ColorObject.FromArgb(255, 255, 255);
            textPart.Font.Bold = true;
            textPart.Font.FontSize = 80;
        }

        #endregion

        #region Cac slide tiep theo

        public static void CreateSlide2(int index, IPresentation presentation, string Content, string font, string size, string style, ILayoutSlide layoutSlide)
        {
            ISlide Slide = presentation.Slides.Add(layoutSlide);
            IShape textShape = Slide.AddTextBox(0, 0, Slide.SlideSize.Width, Slide.SlideSize.Height);
            IParagraph paragraph = textShape.TextBody.AddParagraph();

            //Căn giữa
            paragraph.HorizontalAlignment = HorizontalAlignmentType.Center;

            //Thêm textbox
            ITextPart textPart = paragraph.AddTextPart(Content);

            //Font chữ
            textPart.Font.Color = ColorObject.FromArgb(255, 255, 255);
            textPart.Font.FontName = font;
            textPart.Font.FontSize = int.Parse(size);
            textPart.Font.Bold = true;
        }
        #endregion

        #region Theme

        public static void CreateTheme(IPresentation pptxDoc, Stream pictureStream, string LayoutSlideName, string location)
        {
            //Add a new LayoutSlide to the PowerPoint file
            ILayoutSlide layoutSlide = pptxDoc.Masters[0].LayoutSlides.Add(SlideLayoutType.Blank, LayoutSlideName);
            ISlideSize slidesize = layoutSlide.SlideSize;

            //Add a shape to the LayoutSlide
            IShape shape = layoutSlide.Shapes.AddShape(AutoShapeType.Diamond, 0, 0, layoutSlide.SlideSize.Width, layoutSlide.SlideSize.Height);

            //Change the background color for LayoutSlide
            //layoutSlide.Background.Fill.SolidFill.Color = ColorObject.FromArgb(78, 89, 90);
            layoutSlide.Shapes.AddPicture(pictureStream, 0, 0, slidesize.Width, slidesize.Height);
            
            //Add a slide of new designed custom layout to the presentation
            ISlide slide = pptxDoc.Slides.Add(layoutSlide);
            //Save the PowerPoint file
            pptxDoc.Save(location);

            //Close the Presentation instance
            pptxDoc.Close();
        }


        #endregion

        #region Powerpoint to Text

        public static string CreateText(Presentation pp)
        {
            string pps = "";
            foreach (Microsoft.Office.Interop.PowerPoint.Slide slide in pp.Slides)
            {
                foreach (Microsoft.Office.Interop.PowerPoint.Shape shape in slide.Shapes)
                {
                    if (shape.HasTextFrame == Microsoft.Office.Core.MsoTriState.msoTrue)
                    {
                        var textFrame = shape.TextFrame;
                        if (textFrame.HasText == Microsoft.Office.Core.MsoTriState.msoTrue)
                        {
                            var textRange = textFrame.TextRange;
                            pps += textRange.Text.ToString();
                        }
                    }

                }
            }
            return pps;
        }
        #endregion

        #region Slide sang JPG

        public static Image SlideToImage (string fileName, int indexSlide, int customWidth,
            int customHeight)
        {
            //Opens a PowerPoint Presentation file
            IPresentation pptxDoc = Presentation.Open(fileName);

            //Creates an instance of ChartToImageConverter
            Stream stream = pptxDoc.Slides[indexSlide].ConvertToImage(Syncfusion.Drawing.ImageFormat.Emf);

            Bitmap bitmap = new Bitmap(customWidth, customHeight, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics graphics = Graphics.FromImage(bitmap);

            //Sets the resolution
            bitmap.SetResolution(graphics.DpiX, graphics.DpiY);

            //Recreates the image in custom size
            graphics.DrawImage(Image.FromStream(stream), new Rectangle(0, 0, bitmap.Width, bitmap.Height));

            //Saves the image as bitmap 
            bitmap.Save("ImageOutput" + Guid.NewGuid().ToString() + ".jpeg");

            //Closes the presentation
            pptxDoc.Close();

            //Convert bitmap to Image
            Image img = (Image)bitmap;

            return img ;
        }


        public void PptxFileToImages(
            string fileName, 
            ObservableCollection<ImageSource> slideImageSources, 
            int customHeight = 0,
            int customWidth = 0)
        {
            //Opens a PowerPoint Presentation file
            using (IPresentation pptxDoc = Presentation.Open(fileName))
            {
                try
                {
                    foreach (var slide in pptxDoc.Slides)
                    {
                        using (Image image = slide.ConvertToImage(Syncfusion.Drawing.ImageType.Bitmap))
                        {
                            Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);

                            using (Stream ms = new MemoryStream())
                            {
                                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                var decoder = BitmapDecoder.Create(ms, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                                slideImageSources.Add(decoder.Frames[0]);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }

        public void PptxFileToImages(
            Stream fileStream,
            ObservableCollection<ImageSource> slideImageSources,
            int customHeight = 0,
            int customWidth = 0)
        {
            //Opens a PowerPoint Presentation file
            using (IPresentation pptxDoc = Presentation.Open(fileStream))
            {
                try
                {
                    foreach (var slide in pptxDoc.Slides)
                    {
                        using (Image image = slide.ConvertToImage(Syncfusion.Drawing.ImageType.Bitmap))
                        {
                            Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);

                            using (Stream ms = new MemoryStream())
                            {
                                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                var decoder = BitmapDecoder.Create(ms, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                                slideImageSources.Add(decoder.Frames[0]);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }

        public bool ThumbnailCallback()
        {
            return false;
        }
        #endregion

        #region Áp dụng theme cho file

        public static void ApplyTheme(string filepath, string img)
        {
            //Open the template presentation
            IPresentation pptxDoc = Presentation.Open(filepath);
            //Add a new custom layout slide to the master collection with a specific layout type and name
            ILayoutSlide layoutSlide = pptxDoc.Masters[0].LayoutSlides.Add(SlideLayoutType.Custom, "CustomLayout");
            //Set background of the layout slide
            layoutSlide.Background.Fill.SolidFill.Color = ColorObject.FromArgb(78, 89, 90);
            //Get the stream of an image
            Stream pictureStream = File.Open(img, FileMode.Open);
            //Add the picture into layout slide
            layoutSlide.Shapes.AddPicture(pictureStream, 0, 0, layoutSlide.SlideSize.Width, layoutSlide.SlideSize.Height);
            //Add a slide of new designed custom layout to the presentation
            ISlide slide = pptxDoc.Slides.Add(layoutSlide);
            //Save the presentation
            pptxDoc.Save(filepath);
            //Close the presentation
            pptxDoc.Close();
        }

        #endregion
        
    }
}
