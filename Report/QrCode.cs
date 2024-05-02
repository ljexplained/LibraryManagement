using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Data.SqlClient;
using Libms.Models;
using System.Reflection.PortableExecutable;

namespace Libms.Report
{
    public class QrCode
    {
        string isbn = "";
        string Bacessno = "";
        string Btype = "";
        string Bname ="";
        string Bauthor ="";
        string Bpubyear ="";
        string Bedno = "";
        string Bnop = "";
        string Bprice;     
        DateTime Bpdate;
        string Btitle = "";
        string Bpubname = "";
        int Bqty = 0;
        string Bsubtitle = "";
        string Bsauthor = "";
        string Bsource = "";
        string Bbillno = "";
        string Bcollno = "";
        string Bshelfno = "";
        string Blang = "";
        string qrcode = "";
        //string conn = "Data Source=desktop-6lqd0uj\\sqlexpress;Integrated Security=True";
        string conn = "Data Source=SQL5112.site4now.net;Initial Catalog=db_a9eacf_library;User Id=db_a9eacf_library_admin;Password=BrainLib@123#;";
        #region Declaration
        int _totalColumn = 7;
        Document document;
        Font font;
        PdfPTable table = new PdfPTable(7);
        PdfPCell cell;
        MemoryStream _memoryStream = new MemoryStream();
        #endregion
        
        public byte[] PrepareReport(string qrid)
        {

            #region

            //var document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);
            var pgSize = new iTextSharp.text.Rectangle(230, 120);
           document = new Document(pgSize, 5f, 5f, 20f, 20f);
            document.SetMargins(10f, 10f, 10f, 10f);
            PdfWriter writer = PdfWriter.GetInstance(document, _memoryStream);
            document.Open();

            //DataTable dt = new DataTable();
            //dt.Columns.Add("ID");
            //dt.Columns.Add("Price");
            //for (int i = 0; i < 1; i++)
            //{
            //    DataRow row = dt.NewRow();
            //    row["ID"] = "ZS00000000000000" + i.ToString();
            //    row["Price"] = "100," + i.ToString();
            //    dt.Rows.Add(row);
            //}

            string query = "SELECT * FROM BookMaster where bid = @bid";

            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@bid",qrid);

            SqlDataReader reader = command.ExecuteReader(); 
            while (reader.Read()) {
                
                isbn = reader.GetString(1);
                Bacessno = reader.GetString(2);
                Btype = reader.GetString(3);
                Bname = reader.GetString(4);
                Bauthor = reader.GetString(5);
                Bpubyear = reader.GetString(6);
                Bedno = reader.GetString(7);
                Bnop = reader.GetString(8);
                Bprice = reader.GetString(9);
                Bpdate = (DateTime)reader.GetValue(10);
                Btitle = reader.GetString(11);
                Bpubname = reader.GetString(12);
                Bqty = (Int32)reader.GetValue(13);
                Bsubtitle = reader.GetString(14);
                Bsauthor = reader.GetString(15);
                Bsource = reader.GetString(16);
                Bbillno = reader.GetString(17);
                Bcollno = reader.GetString(18);
                Bshelfno = reader.GetString(19);
                Blang = reader.GetString(20);
                qrcode = reader.GetString(21);



            }


            for (int i = 0; i < 1; i++)
            {
                if (i != 0)
                    document.NewPage();

                iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
                //iTextSharp.text.pdf.BarcodeQRCode Qr = new BarcodeQRCode(qrid + "," + isbn + "," + Bacessno + "," + Btype + "," + Bname + "," + Bauthor + "," + Bpubyear
                //    + "," + Bedno + "," + Bnop + "," + Bprice + "," + Bpdate + "," + Btitle + "," + Bpubname + "," + Bqty + "," + Bsubtitle + "," + Bsauthor + "," + Bsource
                //    + "," + Bbillno + "," + Bcollno + "," + Bshelfno + "," + Blang, 60, 6, null);



                iTextSharp.text.pdf.BarcodeQRCode Qr = new BarcodeQRCode(qrid ,60, 6, null);

                iTextSharp.text.Image img = Qr.GetImage();
                cb.SetTextMatrix(-2.0f, 0.0f);
                img.ScaleAbsoluteHeight(100);
                img.ScaleAbsoluteWidth(200);
                //img.SetAbsolutePosition(-2.8f, 0.5f);
                img.SetAbsolutePosition(-30f, 10f);
                cb.AddImage(img);


                PdfContentByte id = writer.DirectContent;
                BaseFont bf1 = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                id.SetFontAndSize(bf1, 22f);
                id.BeginText();
                id.SetTextMatrix(110f, 78f);
                id.ShowText(qrid);
                id.EndText();


                PdfContentByte cb1 = writer.DirectContent;
                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb1.SetFontAndSize(bf, 22f);
                cb1.BeginText();
                cb1.SetTextMatrix(110f,55f);
                cb1.ShowText("DPBS");
                cb1.EndText();



                PdfContentByte cb3 = writer.DirectContent;
                BaseFont b3 = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb3.SetFontAndSize(bf, 10f);
                cb3.BeginText();
                cb3.SetTextMatrix(110f, 44f);
                cb3.ShowText("COLLEGE");
                cb3.EndText(); 



                PdfContentByte cb2 = writer.DirectContent;
                BaseFont bf2 = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb2.SetFontAndSize(bf2, 14f);
                cb2.BeginText();
                cb2.SetTextMatrix(110f,30f);
                cb2.ShowText("Anupshahar");
                cb2.EndText();


               
            }



            document.Close();
            return _memoryStream.ToArray();
            #endregion

        }









    }
}
