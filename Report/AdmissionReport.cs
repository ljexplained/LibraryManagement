using iTextSharp.text.pdf;
using iTextSharp.text;
using Libms.Models;
using OfficeOpenXml.Style;
using System.Data.SqlClient;
using Org.BouncyCastle.Asn1;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using System.IO;
using System.Drawing.Imaging;

namespace Libms.Report
{
    public class AdmissionReport
    {

       
        private readonly IHostingEnvironment _environment;
        PdfWriter _pdfWriter;
        public AdmissionReport(IHostingEnvironment environment)
        {
            //_logger = logger;
            _environment = environment;

        }


        #region Declaration
        int _totalColumn = 5;
        Document document;
        Font font;
        PdfPTable table = new PdfPTable(5);
        PdfPCell cell;
        MemoryStream _memoryStream = new MemoryStream();
        #endregion

        string conn = "Data Source=SQL5112.site4now.net;Initial Catalog=db_a9eacf_library;User Id=db_a9eacf_library_admin;Password=BrainLib@123#;";
        public byte[] PrepareAdmissionReport()
        {





            #region
            document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(20f, 20f, 20f, 20f);



            table.WidthPercentage = 100;
            table.HorizontalAlignment = Element.ALIGN_LEFT;
             _pdfWriter = PdfWriter.GetInstance(document, _memoryStream);
            document.Open();
            //table.SetWidths(new float[] {120f,120f,120f,120f,25f,120f });
            table.SetWidths(new float[] { 120f, 120f, 120f,120f, 120f });
            #endregion

            this.ReportHeader();
            this.ReportBody();
            table.HeaderRows = 1;
            document.Add(table);
            document.Close();
            return _memoryStream.ToArray();

        }


        private void ReportHeader()
        {

            font = FontFactory.GetFont("Arial", 25f, 1);
            cell = new PdfPCell(new Phrase(" ", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);
            table.CompleteRow();


        }

        private void ReportBody()
        {

            font = FontFactory.GetFont("Arial", 11f, 0);
            cell = new PdfPCell(new Phrase("Student Name\nClass\nYear", font));
            //cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            font = FontFactory.GetFont("Arial", 11f, 0);
            cell = new PdfPCell(new Phrase("Student Id", font));
            //cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            font = FontFactory.GetFont("Arial", 11f, 0);
            cell = new PdfPCell(new Phrase("Photo", font));
            //cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            font = FontFactory.GetFont("Arial", 11f, 0);
            cell = new PdfPCell(new Phrase("Barcode(member id)", font));
            //cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            //font = FontFactory.GetFont("Arial", 11f, 0);
            //cell = new PdfPCell(new Phrase("Heading", font));
            ////cell.Colspan = _totalColumn;
            //cell.HorizontalAlignment = Element.ALIGN_CENTER;
            ////cell.Border = 0;
            //cell.BackgroundColor = BaseColor.WHITE;
            //cell.ExtraParagraphSpace = 3;
            //table.AddCell(cell);


            font = FontFactory.GetFont("Arial", 11f, 0);
            cell = new PdfPCell(new Phrase("Qr code(student id)", font));
            //cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            table.CompleteRow();


            string query = "SELECT MM.MID,MM.MEMBERID,MM.MNAME,MM.MAddress,RG.Course,RG.AcadYear,RG.FatName,RG.whatsapp,RG.ATT17 from MemberMaster MM,RegMaster RG where MM.MEMBERID = RG.REGISTRATIONID order by MM.MID";
            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand(query,sqlConnection);

            SqlDataReader reader = cmd.ExecuteReader(); 

            while (reader.Read())
            {
                string qrcodeinfo = reader.GetString(1) + "," + reader.GetString(2) + "," + reader.GetString(6) + "," + reader.GetString(3) + "," + reader.GetString(7) + "," + reader.GetString(4) + "," + reader.GetString(5);
                string filepath = "";
                string s_profile = reader.GetString(8);
               

                font = FontFactory.GetFont("Arial", 11f, 0);
                cell = new PdfPCell(new Phrase(reader.GetString(2)+"\n\n"+reader.GetString(4)+"\n\n"+reader.GetString(5), font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;  
                cell.BackgroundColor = BaseColor.WHITE;
                cell.ExtraParagraphSpace = 4;  
                table.AddCell(cell);

                font = FontFactory.GetFont("Arial", 11f, 0);
                cell = new PdfPCell(new Phrase(reader.GetString(1), font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                cell.ExtraParagraphSpace = 4;
                table.AddCell(cell);

                if (string.IsNullOrEmpty(s_profile))
                {
                    filepath = Path.Combine(_environment.ContentRootPath, "wwwroot\\demophoto.png");
                }
                else
                {
                    filepath = Path.Combine(_environment.ContentRootPath, "wwwroot\\images\\" + s_profile);
                }

                if (File.Exists(filepath))
                {
                    iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(filepath);
                    jpg.ScaleToFit(100f, 100f);
                    font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);
                    cell = new PdfPCell(jpg);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.Padding = 3;
                    table.AddCell(cell);
                }
                else
                {
                    filepath = Path.Combine(_environment.ContentRootPath, "wwwroot\\demophoto.png");
                    iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(filepath);
                    jpg.ScaleToFit(100f, 100f);
                    cell = new PdfPCell(jpg);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.Padding = 3;
                    table.AddCell(cell);

                }




                iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
                bc.TextAlignment = Element.ALIGN_CENTER;
                bc.Code = reader.GetValue(0).ToString();
                bc.StartStopText = false;
                bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                bc.Extended = true;

                iTextSharp.text.pdf.PdfContentByte cb = _pdfWriter.DirectContent;
                iTextSharp.text.Image img2 = bc.CreateImageWithBarcode(cb,
                iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);

                cb.SetTextMatrix(1.5f, 3.0f);
                img2.ScaleToFit(600, 42);

                font = FontFactory.GetFont("Arial", 11f, 0);
                cell = new PdfPCell(img2);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.WHITE;
                table.AddCell(cell);



                iTextSharp.text.pdf.BarcodeQRCode Qr1 = new BarcodeQRCode(qrcodeinfo, 120, 120, null);
                iTextSharp.text.Image img1 = Qr1.GetImage();
                img1.ScaleAbsoluteHeight(120);
                img1.ScaleAbsoluteWidth(120);
                cell = new PdfPCell(img1);
                cell.Padding = 5;
                cell.BackgroundColor = BaseColor.WHITE;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);

                table.CompleteRow();


            }

            reader.Close(); 

            sqlConnection.Close();



           
            

        }






    }
    }
