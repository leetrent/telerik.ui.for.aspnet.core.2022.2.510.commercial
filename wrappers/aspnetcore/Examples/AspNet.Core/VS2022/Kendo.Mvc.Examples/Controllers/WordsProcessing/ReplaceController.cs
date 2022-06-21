using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Telerik.Windows.Documents.Common.FormatProviders;
using Telerik.Windows.Documents.Flow.FormatProviders.Docx;
using Telerik.Windows.Documents.Flow.FormatProviders.Html;
using Telerik.Windows.Documents.Flow.FormatProviders.Rtf;
using Telerik.Windows.Documents.Flow.FormatProviders.Txt;
using Telerik.Windows.Documents.Flow.Model;
using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Http;
using Telerik.Windows.Documents.Flow.Model.Editing;
using Telerik.Documents.Media;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class WordsProcessingController : Controller
    {
        private static readonly Color YellowColor = Color.FromRgb(255, 255, 0);

        [Demo]
        public ActionResult Replace()
        {
            return View();
        }

        public ActionResult Download_Document_Replace(IFormFile customDocument, string methodType, string findWord, string replaceWith, bool matchCase, bool matchWholeWord, bool regEx)
        {
            // Process document by type
            RadFlowDocument document = null;
            IFormatProvider<RadFlowDocument> fileFormatProvider = null;
            string fileDownloadExtension = string.Empty;
            string fileDownloadName = "{0}.{1}";

            if (customDocument != null && Regex.IsMatch(Path.GetExtension(customDocument.FileName), ".docx|.rtf|.html|.txt"))
            {
                fileDownloadExtension = Path.GetExtension(customDocument.FileName).TrimStart('.');
                fileDownloadName = String.Format(fileDownloadName, Path.GetFileNameWithoutExtension(customDocument.FileName), fileDownloadExtension);
                fileFormatProvider = GetFormatProvider(fileDownloadExtension);

                document = fileFormatProvider.Import(customDocument.OpenReadStream());
            }
            else
            {
                fileFormatProvider = new DocxFormatProvider();
                string fileName = @"wwwroot/shared/web/wordsprocessing/SampleDocument.docx";
                using (FileStream input = new FileStream(fileName, FileMode.Open))
                {
                    document = fileFormatProvider.Import(input);
                }

                fileDownloadExtension = "docx";
                fileDownloadName = String.Format(fileDownloadName, "SampleDocument", fileDownloadExtension);
            }

            // Apply formatting
            ApplyDocumentFormat(document, methodType, findWord, replaceWith, regEx, matchCase, matchWholeWord);

            // Convert file
            IFormatProvider<RadFlowDocument> convertFormatProvider = GetFormatProvider(fileDownloadExtension);
            string mimeType = GetMimeType(fileDownloadExtension);

            byte[] renderedBytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                convertFormatProvider.Export(document, ms);
                renderedBytes = ms.ToArray();
            }

            return File(renderedBytes, mimeType, fileDownloadName);
        }

        private void ApplyDocumentFormat(
            RadFlowDocument document,
            string methodType,
            string findWord,
            string replaceWith,
            bool wantRegEx,
            bool matchCase,
            bool matchWholeWord)
        {
            if (!string.IsNullOrWhiteSpace(findWord))
            {
                var documentEditor = new RadFlowDocumentEditor(document);
                var isValidRegEx = ValidateRegularExpression(findWord);

                switch (methodType)
                {
                    case "text":
                        if (wantRegEx && isValidRegEx)
                        {
                            var findTextRegEx = new Regex(findWord);

                            documentEditor.ReplaceText(findTextRegEx, replaceWith);
                        }
                        else
                        {
                            documentEditor.ReplaceText(findWord, replaceWith, matchCase, matchWholeWord);
                        }

                        break;

                    case "paragraph":
                        Paragraph paragraph = new Paragraph(document);
                        paragraph.Inlines.AddRun(replaceWith);

                        Break br = new Break(document);
                        paragraph.Inlines.Add(br);

                        documentEditor.ReplaceText(findWord, paragraph, matchCase, matchWholeWord);
                        break;

                    case "inline":
                        Paragraph p = new Paragraph(document);
                        p.Inlines.AddRun(replaceWith);

                        documentEditor.ReplaceText(findWord, p, matchCase, matchWholeWord);
                        break;

                    default:
                        if (wantRegEx && isValidRegEx)
                        {
                            var findTextRegEx = new Regex(findWord);

                            documentEditor.ReplaceStyling(findTextRegEx, properties => properties.HighlightColor.LocalValue = YellowColor);
                        }
                        else
                        {
                            documentEditor.ReplaceStyling(findWord, matchCase, matchWholeWord, properties => properties.HighlightColor.LocalValue = YellowColor);
                        }

                        break;
                }
            }
        }

        private bool ValidateRegularExpression(string expression)
        {
            var isValid = true;

            try
            {
                new Regex(expression);
            }
            catch (Exception)
            {
                isValid = false;
            }

            return isValid;
        }

        private IFormatProvider<RadFlowDocument> GetFormatProvider(string fileExtension)
        {
            IFormatProvider<RadFlowDocument> convertFormatProvider = null;
            switch (fileExtension)
            {
                case "docx":
                    convertFormatProvider = new DocxFormatProvider();
                    break;
                case "rtf":
                    convertFormatProvider = new RtfFormatProvider();
                    break;
                case "html":
                    convertFormatProvider = new HtmlFormatProvider();
                    break;
                case "txt":
                    convertFormatProvider = new TxtFormatProvider();
                    break;
                default:
                    convertFormatProvider = new TxtFormatProvider();
                    break;
            }

            return convertFormatProvider;
        }

        private string GetMimeType(string fileExtension)
        {
            string mimeType = String.Empty;
            switch (fileExtension)
            {
                case "docx":
                    mimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    break;
                case "rtf":
                    mimeType = "application/rtf";
                    break;
                case "html":
                    mimeType = "text/html";
                    break;
                case "txt":
                    mimeType = "text/plain";
                    break;
                case "default":
                    mimeType = "text/plain";
                    break;
            }

            return mimeType;
        }
    }
}
