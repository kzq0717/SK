using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EvoPdf;
using System.IO;

namespace SK {
    public class PdfHelper {

        /// <summary> 将HTML文件转为PDF文件
        /// </summary>
        /// <param name="inFilePath">html文件路径</param>
        /// <param name="outFilePath">输出文件路径</param>
        /// <returns>成功：true ，失败：false</returns>
        public static bool HtmlToPDF(string inFilePath, out string outFilePath) {
            try {
                string fileName = "evohtmltopdf.dll";
                //if (Environment.Is64BitOperatingSystem)  //判断系统位数
                //{
                //    fileName = "evohtmltopdf_x64.dll";
                //}
                //else
                //{
                //    fileName = "evohtmltopdf_x86.dll";
                //}

                if (!IsExist(fileName)) {
                    Console.WriteLine("DLL文件不存在");
                    outFilePath = null;
                    return false;
                }
            } catch (Exception ex) {
                throw new Exception("请预先加载对应系统版本的evohtmltopdf.dll文件", ex);
            }

            try {
                if (string.IsNullOrEmpty(inFilePath)) {
                    outFilePath = null;
                    return false;
                }
            } catch (Exception ex) {
                throw new Exception("输入文件文件路径不能为空。", ex);
            }

            outFilePath = System.IO.Directory.GetCurrentDirectory() + @"/outPdf";
            //存放pdf的文件夹是否存在
            if (!Directory.Exists(outFilePath)) {
                Directory.CreateDirectory(outFilePath);
            }


            // Create a PDF document
            Document pdfDocument = new Document();

            // Set license key received after purchase to use the converter in licensed mode
            // Leave it not set to use the converter in demo mode
            //pdfDocument.LicenseKey = "4W9+bn19bn5ue2B+bn1/YH98YHd3d3c=";
            pdfDocument.LicenseKey = "gA4eDxofD2YCeE5dSlVwHR8eGA8YARsPHB4BHh0BFhYWFg8e";

            // Create a PDF page where to add the first HTML
            PdfPage firstPdfPage = pdfDocument.AddPage();

            //
            string outPdfFile = outFilePath + @"\temp.pdf";

            //Cursor = Cursors.WaitCursor;
            //string outPdfFile = @"DemoAppFiles\Output\HTML_to_PDF\Add_HTML_to_PDF_Elements_to_PDF.pdf";
            try {
                // The element location in PDF
                //float xLocation = float.Parse(xLocationTextBox.Text);
                //float yLocation = float.Parse(yLocationTextBox.Text);

                // The URL of the HTML page to convert to PDF
                //string urlToConvert = urlTextBox.Text;
                string urlToConvert = inFilePath;

                // Create the HTML to PDF element
                HtmlToPdfElement htmlToPdfElement = new HtmlToPdfElement(0, 0, urlToConvert);


                // Optionally set the HTML viewer width
                htmlToPdfElement.HtmlViewerWidth = int.Parse("1024");

                // Optionally set the HTML viewer height
                //if (htmlViewerHeightTextBox.Text.Length > 0)
                //   htmlToPdfElement.HtmlViewerHeight = int.Parse(htmlViewerHeightTextBox.Text);

                // Optionally set the HTML content clipping option to force the HTML content width to be exactly HtmlViewerWidth pixels
                //htmlToPdfElement.ClipHtmlView = clipContentCheckBox.Checked;

                // Optionally set the destination width in PDF
                //if (contentWidthTextBox.Text.Length > 0)
                //    htmlToPdfElement.Width = float.Parse(contentWidthTextBox.Text);

                //// Optionally set the destination height in PDF
                //if (contentHeightTextBox.Text.Length > 0)
                //    htmlToPdfElement.Height = float.Parse(contentHeightTextBox.Text);

                // Optionally set a delay before conversion to allow asynchonous scripts to finish
                htmlToPdfElement.ConversionDelay = 2;

                // Add the HTML to PDF element to PDF document
                // The AddElementResult contains the bounds of the HTML to PDF Element in last rendered PDF page
                // such that you can start a new PDF element right under it
                AddElementResult result = firstPdfPage.AddElement(htmlToPdfElement);

                // Save the PDF document in a memory buffer
                byte[] outPdfBuffer = pdfDocument.Save();

                // Write the memory buffer in a PDF file
                System.IO.File.WriteAllBytes(outPdfFile, outPdfBuffer);
            } catch (Exception ex) {
                // The HTML to PDF conversion failed
                throw new Exception(string.Format("HTML to PDF Error. {0}", ex.Message));
                //MessageBox.Show(String.Format("HTML to PDF Error. {0}", ex.Message));
                //return;
            } finally {
                // Close the PDF document
                pdfDocument.Close();
                //Cursor = Cursors.Arrow;
            }

            outFilePath = outPdfFile;
            return true;
        }


        /// <summary> 将HTML文件转为PDF文件
        /// </summary>
        /// <param name="inFilePath">HTML文件路径</param>
        /// <param name="outFilePath">PDF文件全绝对路径</param>
        /// <returns>成功：true ，失败：false</returns>
        public static bool HtmlToPDF(string inFilePath, string outFilePath) {
            try {
                string fileName = "evohtmltopdf.dll";
                //if (Environment.Is64BitOperatingSystem)  //判断系统位数
                //{
                //    fileName = "evohtmltopdf_x64.dll";
                //}
                //else
                //{
                //    fileName = "evohtmltopdf_x86.dll";
                //}

                if (!IsExist(fileName)) {
                    Console.WriteLine("DLL文件不存在");
                    outFilePath = null;
                    return false;
                }
            } catch (Exception ex) {
                throw new Exception("请预先加载对应系统版本的evohtmltopdf.dll文件", ex);
            }

            try {
                if (string.IsNullOrEmpty(inFilePath)) {
                    outFilePath = null;
                    return false;
                }
            } catch (Exception ex) {
                throw new Exception("输入文件文件路径不能为空。", ex);
            }


            string outPdfFile = "";

            if (string.IsNullOrEmpty(outFilePath)) {
                outFilePath = System.IO.Directory.GetCurrentDirectory() + @"/outPdf";
                //存放pdf的文件夹是否存在
                if (!Directory.Exists(outFilePath)) {
                    Directory.CreateDirectory(outFilePath);
                }

                outPdfFile = outFilePath + @"\temp.pdf";
            }
            outPdfFile = outFilePath;

            // Create a PDF document
            Document pdfDocument = new Document();

            // Set license key received after purchase to use the converter in licensed mode
            // Leave it not set to use the converter in demo mode
            //pdfDocument.LicenseKey = "4W9+bn19bn5ue2B+bn1/YH98YHd3d3c=";
            pdfDocument.LicenseKey = "gA4eDxofD2YCeE5dSlVwHR8eGA8YARsPHB4BHh0BFhYWFg8e";

            // Create a PDF page where to add the first HTML
            PdfPage firstPdfPage = pdfDocument.AddPage();

            //


            //Cursor = Cursors.WaitCursor;
            //string outPdfFile = @"DemoAppFiles\Output\HTML_to_PDF\Add_HTML_to_PDF_Elements_to_PDF.pdf";
            try {
                // The element location in PDF
                //float xLocation = float.Parse(xLocationTextBox.Text);
                //float yLocation = float.Parse(yLocationTextBox.Text);

                // The URL of the HTML page to convert to PDF
                //string urlToConvert = urlTextBox.Text;
                string urlToConvert = inFilePath;

                // Create the HTML to PDF element
                HtmlToPdfElement htmlToPdfElement = new HtmlToPdfElement(0, 0, urlToConvert);


                // Optionally set the HTML viewer width
                htmlToPdfElement.HtmlViewerWidth = int.Parse("1024");

                // Optionally set the HTML viewer height
                //if (htmlViewerHeightTextBox.Text.Length > 0)
                //   htmlToPdfElement.HtmlViewerHeight = int.Parse(htmlViewerHeightTextBox.Text);

                // Optionally set the HTML content clipping option to force the HTML content width to be exactly HtmlViewerWidth pixels
                //htmlToPdfElement.ClipHtmlView = clipContentCheckBox.Checked;

                // Optionally set the destination width in PDF
                //if (contentWidthTextBox.Text.Length > 0)
                //    htmlToPdfElement.Width = float.Parse(contentWidthTextBox.Text);

                //// Optionally set the destination height in PDF
                //if (contentHeightTextBox.Text.Length > 0)
                //    htmlToPdfElement.Height = float.Parse(contentHeightTextBox.Text);

                // Optionally set a delay before conversion to allow asynchonous scripts to finish
                htmlToPdfElement.ConversionDelay = 2;

                // Add the HTML to PDF element to PDF document
                // The AddElementResult contains the bounds of the HTML to PDF Element in last rendered PDF page
                // such that you can start a new PDF element right under it
                AddElementResult result = firstPdfPage.AddElement(htmlToPdfElement);

                // Save the PDF document in a memory buffer
                byte[] outPdfBuffer = pdfDocument.Save();

                // Write the memory buffer in a PDF file
                System.IO.File.WriteAllBytes(outPdfFile, outPdfBuffer);
            } catch (Exception ex) {
                // The HTML to PDF conversion failed
                throw new Exception(string.Format("HTML to PDF Error. {0}", ex.Message));
                //MessageBox.Show(String.Format("HTML to PDF Error. {0}", ex.Message));
                //return;
            } finally {
                // Close the PDF document
                pdfDocument.Close();
                //Cursor = Cursors.Arrow;
            }

            outFilePath = outPdfFile;
            return true;
        }


        /// <summary> 打开PDF文件
        /// </summary>
        /// <param name="PdfPath"></param>
        /// <returns></returns>
        public static string OpenFile(string PdfPath) {
            try {
                System.Diagnostics.Process.Start(PdfPath);
                return "已打开PDF文件。";
            } catch (Exception ex) {
                //MessageBox.Show(String.Format("Cannot open created PDF file '{0}'. {1}", outPdfFile, ex.Message));
                return String.Format("Cannot open created PDF file '{0}'. {1}", PdfPath, ex.Message);
            }
        }


        /// <summary>判断DLL文件是否存在
        /// </summary>
        /// <returns></returns>
        public static bool IsExist(string fileName) {
            try {
                if (string.IsNullOrEmpty(fileName)) {
                    return false;
                }
                string filePath = Path.Combine(System.Windows.Forms.Application.StartupPath, fileName);

                if (!File.Exists(filePath)) {
                    return false;
                }

                return true;

            } catch (Exception) {
                return false;
            }
        }

    }
}
