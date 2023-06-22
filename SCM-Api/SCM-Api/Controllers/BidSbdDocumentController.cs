namespace SCM_Api.Controllers
{
    using AutoMapper;
    using Common.Constant;
    using Common.Helpers;
    using Data.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NReco.PdfGenerator;
    using Services.Contract;
    using Services.Models;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    public class BidSbdDocumentController : ControllerBase
    {
        private readonly IBidSbdDocumentService _bidSbdDocumentService;
        private readonly ISbdDocumentService _sbdDocumentService;
        private readonly IMapper _mapper;

        public BidSbdDocumentController(IBidSbdDocumentService bidSbdDocumentService, IMapper mapper, ISbdDocumentService sbdDocumentService)
        {
            _bidSbdDocumentService = bidSbdDocumentService;
            _sbdDocumentService = sbdDocumentService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get BidSbdDocument data by Id.
        /// </summary>
        /// <param name="bidSbdDocumentId">bidSbdDocumentId</param>
        /// <param name="bidId">bidId</param>
        /// <returns>The Api Response.</returns>
        [HttpGet("GetBidSbdDocumentById/{bidSbdDocumentId}")]
        public async Task<IActionResult> GetBidSbdDocumentById(int bidId, int bidSbdDocumentId)
        {
            BidSbdDocument? bidSbdDocument = await _bidSbdDocumentService.GetById(bidId, bidSbdDocumentId);
            if (bidSbdDocument == null)
            {
                return this.Ok(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { $"BidSbdDocument data not found." }));
            }

            return Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, bidSbdDocument));
        }

        /// <summary>
        /// Add/Update BidSbdDocument Data.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The Api Response.</returns>
        [HttpPost("AddUpdate")]
        public async Task<IActionResult> AddUpdate(BidSbdDocumentModel model)
        {
            BidSbdDocument bidSbdDocument = _mapper.Map<BidSbdDocument>(model);

            List<object> sbdDocumentValueList = new();
            if (model.SbdDocumentValue != null && model.SbdDocumentValue.Any())
            {
                foreach (SbdBidDocumentValueJsonModel sbdDocumentJsonValue in model.SbdDocumentValue)
                {
                    sbdDocumentValueList.Add(new
                    {
                        name = sbdDocumentJsonValue?.Name,
                        value = sbdDocumentJsonValue?.Value?.ToString(),
                        controlType = sbdDocumentJsonValue?.ControlType
                    });
                }

                bidSbdDocument.SbdDocumentValue = JsonConvert.SerializeObject(sbdDocumentValueList);
            }
            else
            {
                SbdDocument? sbdDocument = await _sbdDocumentService.GetById(bidSbdDocument.SbdDocumentId);
                if (sbdDocument != null)
                {
                    bidSbdDocument.SbdDocumentValue = sbdDocument.JsonFormatString;
                }
            }

            int bidSbdDocumentId = await _bidSbdDocumentService.SaveUpdate(bidSbdDocument);
            return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, bidSbdDocumentId));
        }

        /// <summary>
        /// Preview of html page.
        /// </summary>
        /// <param name="bidId"></param>
        /// <param name="sbdDocumentId"></param>
        /// <returns>The Api Response</returns>
        [HttpGet("Preview")]
        public async Task<IActionResult> Preview(int bidId, int sbdDocumentId)
        {
            BidSbdDocument? bidSbdDocument = await _bidSbdDocumentService.GetById(bidId, sbdDocumentId);
            if (bidSbdDocument == null)
            {
                #region Convert HTML to PDF on SBD document.

                SbdDocument? sbdDocument = await _sbdDocumentService.GetById(sbdDocumentId);
                if (sbdDocument == null)
                {
                    return this.Ok(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { "SBD Document is not found." }));
                }
                else
                {
                    string htmlContent = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, $"HtmlTemplate/SBD_Document/SCM-Bid-Document 4.html"));
                    if (!string.IsNullOrEmpty(htmlContent))
                    {
                        string headerImage = String.Empty;
                        htmlContent = htmlContent.Replace("{{Logo_Image}}", headerImage);
                    }

                    if (!sbdDocument.JsonFormatString.IsNullOrEmpty())
                    {
                        IList<SbdBidDocumentValueJsonModel>? sbdDocumentValueArray = sbdDocument.JsonFormatString == null || sbdDocument.JsonFormatString.IsNullOrEmpty() ? new List<SbdBidDocumentValueJsonModel>() : JsonConvert.DeserializeObject<List<SbdBidDocumentValueJsonModel>>(sbdDocument.JsonFormatString);
                        if (sbdDocumentValueArray != null && sbdDocumentValueArray.Count > 0)
                        {
                            foreach (SbdBidDocumentValueJsonModel sbdDocumentValue in sbdDocumentValueArray)
                            {
                                if (sbdDocumentValue.ControlType.Equals("List", StringComparison.OrdinalIgnoreCase) && sbdDocumentValue.Value?.GetType() == typeof(JArray))
                                {
                                    string htmlTableBody = string.Empty;
                                    if (sbdDocumentValue.Value != null)
                                    {
                                        foreach (JObject item in sbdDocumentValue.Value)
                                        {
                                            IList<string> columnList = item.Properties().Select(p => p.Name).ToList();
                                            if (columnList.Count > 0)
                                            {
                                                htmlTableBody += "<tr>";
                                                foreach (string columnName in columnList)
                                                {
                                                    if (!columnName.Contains("_optionalKey", StringComparison.OrdinalIgnoreCase))
                                                    {
                                                        htmlTableBody += $"<td align='center' valign='center' style=' line-height: 18px; font-size: 14px; font-weight: 400; color: #575757; padding: 4px; border: 1px solid #034f8b;'>{item.SelectToken(columnName).ToString()}</td>";
                                                    }
                                                }
                                                htmlTableBody += "</tr>";
                                            }
                                        }
                                    }

                                    htmlContent = htmlContent.Replace("{{" + sbdDocumentValue.Name + "}}", htmlTableBody);
                                }
                                else if (sbdDocumentValue.ControlType.Equals("Text", StringComparison.OrdinalIgnoreCase) || sbdDocumentValue.ControlType.Equals("Textarea", StringComparison.OrdinalIgnoreCase))
                                {
                                    htmlContent = htmlContent.Replace("{{" + sbdDocumentValue.Name + "}}", sbdDocumentValue.Value);
                                }
                                else
                                {
                                    htmlContent = htmlContent.Replace("{{" + sbdDocumentValue.Name + "}}", !string.IsNullOrEmpty(sbdDocumentValue.Value) && Convert.ToBoolean(sbdDocumentValue.Value) == true ? "checked" : String.Empty);
                                }
                            }
                        }
                    }

                    byte[] byteArray = Helper.ConvertHtmlToPdf(htmlContent);
                    MemoryStream stream = new MemoryStream(byteArray);
                    IFormFile? file = new FormFile(stream, 0, byteArray.Length, "SCM", "BID Documents" + ".pdf");

                    string Content = String.Empty;
                    if (file != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        file.CopyTo(ms);
                        Content = Convert.ToBase64String(ms.ToArray());
                    }

                    return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, Content));
                }


                #endregion
            }
            else
            {
                string htmlContent = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, $"HtmlTemplate/SBD_Document/SCM-Bid-Document 4.html"));

                if (!string.IsNullOrEmpty(htmlContent))
                {
                    string headerImage = String.Empty;
                    htmlContent = htmlContent.Replace("{{Logo_Image}}", headerImage);

                    if (!bidSbdDocument.SbdDocumentValue.IsNullOrEmpty())
                    {
                        IList<SbdBidDocumentValueJsonModel>? sbdDocumentValueArray = bidSbdDocument.SbdDocumentValue == null || bidSbdDocument.SbdDocumentValue.IsNullOrEmpty() ? new List<SbdBidDocumentValueJsonModel>() : JsonConvert.DeserializeObject<List<SbdBidDocumentValueJsonModel>>(bidSbdDocument.SbdDocumentValue);
                        if (sbdDocumentValueArray != null && sbdDocumentValueArray.Count > 0)
                        {
                            foreach (SbdBidDocumentValueJsonModel sbdDocumentValue in sbdDocumentValueArray)
                            {
                                if (sbdDocumentValue.ControlType.Equals("List", StringComparison.OrdinalIgnoreCase) && sbdDocumentValue.Value?.GetType() == typeof(JArray))
                                {
                                    string htmlTableBody = string.Empty;
                                    if (sbdDocumentValue.Value != null)
                                    {
                                        foreach (JObject item in sbdDocumentValue.Value)
                                        {
                                            IList<string> columnList = item.Properties().Select(p => p.Name).ToList();
                                            if (columnList.Any())
                                            {
                                                htmlTableBody += "<tr>";
                                                foreach (string columnName in columnList)
                                                {
                                                    if (!columnName.Contains("_optionalKey", StringComparison.OrdinalIgnoreCase))
                                                    {
                                                        htmlTableBody += $"<td align='center' valign='center' style=' line-height: 18px; font-size: 14px; font-weight: 400; color: #575757; padding: 4px; border: 1px solid #034f8b;'>{item.SelectToken(columnName).ToString()}</td>";
                                                    }
                                                }
                                                htmlTableBody += "</tr>";
                                            }
                                        }
                                    }

                                    htmlContent = htmlContent.Replace("{{" + sbdDocumentValue.Name + "}}", htmlTableBody);
                                }
                                else if (sbdDocumentValue.ControlType.Equals("Text", StringComparison.OrdinalIgnoreCase) || sbdDocumentValue.ControlType.Equals("Textarea", StringComparison.OrdinalIgnoreCase))
                                {
                                    htmlContent = htmlContent.Replace("{{" + sbdDocumentValue.Name + "}}", sbdDocumentValue.Value);
                                }
                                else
                                {
                                    htmlContent = htmlContent.Replace("{{" + sbdDocumentValue.Name + "}}", !string.IsNullOrEmpty(sbdDocumentValue.Value) && Convert.ToBoolean(sbdDocumentValue.Value) == true ? "checked" : String.Empty);
                                }
                            }
                        }
                    }
                }

                byte[] byteArray = Helper.ConvertHtmlToPdf(htmlContent);
                MemoryStream stream = new MemoryStream(byteArray);
                IFormFile? file = new FormFile(stream, 0, byteArray.Length, "SCM", "BID Documents" + ".pdf");

                string Content = String.Empty;
                if (file != null)
                {
                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    Content = Convert.ToBase64String(ms.ToArray());
                }

                return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, Content));

            }
        }

        [HttpGet("Demo")]
        public IActionResult Demo()
        {
            string htmlContent = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, $"HtmlTemplate/SBD_Document/htmlpage.html"));
            HtmlToPdfConverter htmlToPdf = new HtmlToPdfConverter();
            htmlToPdf.License.SetLicenseKey("PDF_Generator_Src_Examples_Pack_252860367097", "VznQd4kFbjh2VTOCIL2NhgL/QLI5zfE60okWm9AYsgpYZYAlc/1BUxQea1KFKBneH37lSmxD6bzAdDJaq9AVXz8IqyzSnuXWFDKVctaaQXoVtXZYndHsVreJmaRdiSnYdhILIn/nPxk5E0NsCsUvHOoxp+FKhngOXJXgkYIyuDU=");
            htmlToPdf.PdfToolPath = Path.Combine(Environment.CurrentDirectory, "HtmlTemplate");
            htmlToPdf.Margins = new PageMargins() { Bottom = 10, Left = 10, Right = 10, Top = 10 };

            // Generate the PDF and save it to a file
            htmlToPdf.GeneratePdf(htmlContent, null, (Path.Combine(Environment.CurrentDirectory, $"HtmlTemplate\\Output\\htmlpage.pdf")));

            return Ok();
        }
    }
}
