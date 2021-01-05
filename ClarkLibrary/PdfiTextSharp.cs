using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace ClarkLibrary
{
    public class PdfiTextSharp
    {
        /// <summary> 合併PDF檔(集合) </summary>
        /// <param name="fileList">欲合併PDF檔之集合(一筆以上)</param>
        /// <param name="outMergeFile">合併後的檔名</param>
        private void mergePDFFiles(string[] fileList, string outMergeFile)
        {
            //outMergeFile = Server.MapPath(outMergeFile);

            PdfReader reader;

            Document document = new Document();

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outMergeFile, FileMode.Create));

            document.Open();

            PdfContentByte cb = writer.DirectContent;

            PdfImportedPage newPage;

            for (int i = 0; i < fileList.Length; i++)

            {

                reader = new PdfReader(fileList[i]);

                int iPageNum = reader.NumberOfPages;

                for (int j = 1; j <= iPageNum; j++)

                {

                    document.NewPage();

                    newPage = writer.GetImportedPage(reader, j);

                    cb.AddTemplate(newPage, 0, 0);

                }

            }

            document.Close();
        }

        private void mergePDF()
        {
            string[] pdflist = new string[3];
            pdflist[0] = "RPT01.pdf";
            pdflist[1] = "RPT02.pdf";
            pdflist[2] = "RPT03.pdf";
            mergePDFFiles(pdflist, "newpdf1.pdf");
        }
    }
}
