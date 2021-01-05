using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace ClarkLibrary
{
    public class PdfProcessor
    {
        public static void MergeMultiplePDFIntoSinglePDF(string outputFilePath, string inputPath)
        {
            // Get some file names
            string[] pdfFiles = GetFiles(inputPath);

            PdfDocument outputDocument = new PdfDocument();
            foreach (string pdfFile in pdfFiles)
            {
                PdfDocument inputPDFDocument = PdfReader.Open(pdfFile, PdfDocumentOpenMode.Import);
                outputDocument.Version = inputPDFDocument.Version;
                foreach (PdfPage page in inputPDFDocument.Pages)
                {
                    outputDocument.AddPage(page);
                }
                // When document is add in pdf document remove file from folder  
                //System.IO.File.Delete(pdfFile);
            }

            // Set font for paging
            XFont fontTime = new XFont("Verdana", 6);
            XFont font = new XFont("Verdana", 8);
            XBrush brush = XBrushes.Black;
            // Create variable that store page count  
            string noPages = outputDocument.Pages.Count.ToString();
            // Set for loop of document page count and set page number using DrawString function of PdfSharp  
            for (int i = 0; i < outputDocument.Pages.Count; ++i)
            {
                PdfPage page = outputDocument.Pages[i];
                // Make a layout rectangle.  
                XRect layoutRectangle = new XRect(-10 /*X*/ , page.Height - font.Height - 40 /*Y*/ , page.Width /*Width*/ , font.Height /*Height*/ );
                XRect timeStampRectangle = new XRect(25 /*X*/ , page.Height - font.Height - 40 /*Y*/ , page.Width /*Width*/ , font.Height /*Height*/ );
                XRect removedRectangle = new XRect(20 /*X*/ , page.Height - font.Height - 40 /*Y*/ , 400 /*Width*/ , font.Height + 5 /*Height*/ );
                using (XGraphics gfx = XGraphics.FromPdfPage(page))
                {
                    // Remove the original paging
                    //gfx.DrawRectangle(XBrushes.Yellow, removedRectangle);
                    // Add new paging
                    gfx.DrawString("Yreated on: " + DateTime.Now.ToString(), fontTime, brush, timeStampRectangle, XStringFormats.CenterLeft);
                    gfx.DrawString("Yage " + (i + 1).ToString() + " of " + noPages, font, brush, layoutRectangle, XStringFormats.Center);
                }
            }
            outputDocument.Options.CompressContentStreams = true;
            outputDocument.Options.NoCompression = false;
            // In the final stage, all documents are merged and save in your output file path.  
            outputDocument.Save(outputFilePath);
        }

        /// <summary>
        /// Imports pages from an external document.
        /// Note that this technique imports the whole page including the hyperlinks.
        /// </summary>
        public static void Variant11()
        {
            // Get two fresh copies of the sample PDF files
            // (Note: The input files are not modified in this sample.)
            string filename1 = "Profit and Loss Summary.pdf";
            File.Copy(Path.Combine(@"C:\Tao_Folder\About_Work\CES\test\input\", filename1),
              Path.Combine(Directory.GetCurrentDirectory(), filename1), true);
            string filename2 = "Transaction History.pdf";  // use other file here
            File.Copy(Path.Combine(@"C:\Tao_Folder\About_Work\CES\test\input\", filename2),
              Path.Combine(Directory.GetCurrentDirectory(), filename2), true);

            // Open the input files
            PdfDocument inputDocument1 = PdfReader.Open(filename1, PdfDocumentOpenMode.Import);
            PdfDocument inputDocument2 = PdfReader.Open(filename2, PdfDocumentOpenMode.Import);

            // Create the output document
            PdfDocument outputDocument = new PdfDocument();

            // Show consecutive pages facing. Requires Acrobat 5 or higher.
            outputDocument.PageLayout = PdfPageLayout.TwoColumnLeft;

            XFont font = new XFont("Verdana", 10, XFontStyle.Bold);
            XStringFormat format = new XStringFormat();
            format.Alignment = XStringAlignment.Center;
            format.LineAlignment = XLineAlignment.Far;
            XGraphics gfx;
            XRect box;
            int count = Math.Max(inputDocument1.PageCount, inputDocument2.PageCount);
            for (int idx = 0; idx < count; idx++)
            {
                // Get page from 1st document
                PdfPage page1 = inputDocument1.PageCount > idx ?
                  inputDocument1.Pages[idx] : new PdfPage();

                // Get page from 2nd document
                PdfPage page2 = inputDocument2.PageCount > idx ?
                  inputDocument2.Pages[idx] : new PdfPage();

                // Add both pages to the output document
                page1 = outputDocument.AddPage(page1);
                page2 = outputDocument.AddPage(page2);

                // Write document file name and page number on each page
                gfx = XGraphics.FromPdfPage(page1);
                box = page1.MediaBox.ToXRect();
                box.Inflate(0, -10);
                gfx.DrawString(String.Format("{0} • {1}", filename1, idx + 1),
                  font, XBrushes.Red, box, format);

                gfx = XGraphics.FromPdfPage(page2);
                box = page2.MediaBox.ToXRect();
                box.Inflate(0, -10);
                gfx.DrawString(String.Format("{0} • {1}", filename2, idx + 1),
                  font, XBrushes.Red, box, format);
            }

            // Save the document...
            string filename = @"C:\Tao_Folder\About_Work\CES\test\output\CompareDocument1.pdf";
            outputDocument.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }

        /// <summary>
        /// Imports the pages as form X objects.
        /// Note that this technique copies only the visual content and the
        /// hyperlinks do not work.
        /// </summary>
        static void Variant22()
        {
            // Get fresh copies of the sample PDF files
            string filename1 = "Portable Document Format.pdf";
            File.Copy(Path.Combine("../../../../PDFs/", filename1),
              Path.Combine(Directory.GetCurrentDirectory(), filename1), true);
            string filename2 = "Portable Document Format.pdf";
            File.Copy(Path.Combine("../../../../PDFs/", filename2),
              Path.Combine(Directory.GetCurrentDirectory(), filename2), true);

            // Create the output document
            PdfDocument outputDocument = new PdfDocument();

            // Show consecutive pages facing
            outputDocument.PageLayout = PdfPageLayout.TwoPageLeft;

            XFont font = new XFont("Verdana", 10, XFontStyle.Bold);
            XStringFormat format = new XStringFormat();
            format.Alignment = XStringAlignment.Center;
            format.LineAlignment = XLineAlignment.Far;
            XGraphics gfx;
            XRect box;

            // Open the external documents as XPdfForm objects. Such objects are
            // treated like images. By default the first page of the document is
            // referenced by a new XPdfForm.
            XPdfForm form1 = XPdfForm.FromFile(filename1);
            XPdfForm form2 = XPdfForm.FromFile(filename2);

            int count = Math.Max(form1.PageCount, form2.PageCount);
            for (int idx = 0; idx < count; idx++)
            {
                // Add two new pages to the output document
                PdfPage page1 = outputDocument.AddPage();
                PdfPage page2 = outputDocument.AddPage();

                if (form1.PageCount > idx)
                {
                    // Get a graphics object for page1
                    gfx = XGraphics.FromPdfPage(page1);

                    // Set page number (which is one-based)
                    form1.PageNumber = idx + 1;

                    // Draw the page identified by the page number like an image
                    gfx.DrawImage(form1, new XRect(0, 0, form1.Width, form1.Height));

                    // Write document file name and page number on each page
                    box = page1.MediaBox.ToXRect();
                    box.Inflate(0, -10);
                    gfx.DrawString(String.Format("{0} • {1}", filename1, idx + 1),
                      font, XBrushes.Red, box, format);
                }

                // Same as above for second page
                if (form2.PageCount > idx)
                {
                    gfx = XGraphics.FromPdfPage(page2);

                    form2.PageNumber = idx + 1;
                    gfx.DrawImage(form2, new XRect(0, 0, form2.Width, form2.Height));

                    box = page2.MediaBox.ToXRect();
                    box.Inflate(0, -10);
                    gfx.DrawString(String.Format("{0} • {1}", filename2, idx + 1),
                      font, XBrushes.Red, box, format);
                }
            }
        }

        /// <summary>
        /// Put your own code here to get the files to be concatenated.
        /// </summary>
        static string[] GetFiles(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            FileInfo[] fileInfos = dirInfo.GetFiles("*.pdf");
            ArrayList list = new ArrayList();
            foreach (FileInfo info in fileInfos)
            {
                // HACK: Just skip the protected samples file...
                if (info.Name.IndexOf("protected") == -1)
                    list.Add(info.FullName);
            }
            return (string[])list.ToArray(typeof(string));
        }

        /// <summary>
        /// Imports all pages from a list of documents.
        /// </summary>
        public static void ConcatenatePdfs(string inputPath, string outputFilePath)
        {
            // Get some file names
            string[] files = GetFiles(inputPath);

            // Open the output document
            PdfDocument outputDocument = new PdfDocument();

            // Iterate files
            foreach (string file in files)
            {
                // Open the document to import pages from it.
                PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);

                // Iterate pages
                int count = inputDocument.PageCount;
                for (int idx = 0; idx < count; idx++)
                {
                    // Get the page from the external document...
                    PdfPage page = inputDocument.Pages[idx];
                    // ...and add it to the output document.
                    outputDocument.AddPage(page);
                }
            }

            // Save the document...
            string filename = @"C:\Tao_Folder\About_Work\CES\test\output\ConcatenatedDocument1.pdf";
            outputDocument.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }

        /// <summary>
        /// This sample adds a consecutive number in the middle of each page.
        /// It shows how you can add graphics to an imported page.
        /// </summary>
        public static void Variant3(string inputPath, string outputFilePath)
        {
            // Get some file names
            string[] files = GetFiles(inputPath);

            // Open the output document
            PdfDocument outputDocument = new PdfDocument();

            // Note that the output document may look significant larger than in Variant1.
            // This is because adding graphics to an imported page causes the 
            // uncompression of its content if it was compressed in the external document.
            // To compare file sizes you should either run the sample as Release build
            // or uncomment the following line.
            //outputDocument.Options.CompressContentStreams = true;

            XFont font = new XFont("Verdana", 40, XFontStyle.Bold);
            XStringFormat format = XStringFormat.Center;
            int number = 0;

            // Iterate files
            foreach (string file in files)
            {
                // Open the document to import pages from it.
                PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);

                // Iterate pages
                int count = inputDocument.PageCount;
                for (int idx = 0; idx < count; idx++)
                {
                    // Get the page from the external document...
                    PdfPage page = inputDocument.Pages[idx];
                    // ...and add it to the output document.
                    // Note that the PdfPage instance returned by AddPage is a
                    // different object.
                    page = outputDocument.AddPage(page);

                    // Create a graphics object for this page. To draw beneath the existing
                    // content set 'Append' to 'Prepend'.
                    XGraphics gfx =
                      XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Append);
                    DrawNumber(gfx, font, ++number);
                }
            }

            // Save the document...
            string filename = @"C:\Tao_Folder\About_Work\CES\test\output\ConcatenatedDocument3.pdf";
            outputDocument.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }



        /// <summary>
        /// This sample is the combination of Variant2 and Variant3. It shows that you 
        /// can add external pages more than once and still add individual graphics on
        /// each page. The external content is shared among the pages, the new graphics
        /// are unique to each page. You can check this by comparing the file size
        /// of Variant3 and Variant4.
        /// </summary>
        static void Variant4(string inputPath)
        {
            // Get some file names
            string[] files = GetFiles(inputPath);

            // Open the output document
            PdfDocument outputDocument = new PdfDocument();

            // For checking the file size uncomment next line.
            //outputDocument.Options.CompressContentStreams = true;

            XFont font = new XFont("Verdana", 40, XFontStyle.Bold);
            XStringFormat format = XStringFormat.Center;
            int number = 0;

            // Iterate files
            foreach (string file in files)
            {
                // Open the document to import pages from it.
                PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);

                // Show consecutive pages facing. Requires Acrobat 5 or higher.
                outputDocument.PageLayout = PdfPageLayout.TwoColumnLeft;

                // Iterate pages
                int count = inputDocument.PageCount;
                for (int idx = 0; idx < count; idx++)
                {
                    // Get the page from the external document...
                    PdfPage page = inputDocument.Pages[idx];
                    // ...and add it twice to the output document.
                    PdfPage page1 = outputDocument.AddPage(page);
                    PdfPage page2 = outputDocument.AddPage(page);

                    XGraphics gfx =
                      XGraphics.FromPdfPage(page1, XGraphicsPdfPageOptions.Append);
                    //DrawNumber(gfx, font, ++number);

                    gfx = XGraphics.FromPdfPage(page2, XGraphicsPdfPageOptions.Append);
                    //DrawNumber(gfx, font, ++number);
                }
            }

            // Save the document...
            string filename = @"C:\Tao_Folder\About_Work\CES\test\output\ConcatenatedDocument4.pdf";
            outputDocument.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }

        /// <summary>
        /// Draws the number in the middle of the page.
        /// </summary>
        static void DrawNumber(XGraphics gfx, XFont font, int number)
        {
            double width = 130;
            gfx.DrawEllipse(new XPen(XColors.DarkBlue, 7), XBrushes.DarkOrange,
              new XRect(gfx.PageSize.ToXPoint(), new XSize(width, width)));
            gfx.DrawString(number.ToString(), font, XBrushes.Firebrick,
              new XRect(new XPoint(), gfx.PageSize), XStringFormats.Center);
        }


    }
}
