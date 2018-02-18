using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.IO;

namespace Common.Web.Mvc.JsonNet
{
    public class JsonNetResult : IActionResult
    {
        #region Constructors and Destructors

        public JsonNetResult()
            : this(null, null, null)
        {
        }

        public JsonNetResult(object data)
            : this(data, null, null)
        {
        }

        public JsonNetResult(object data, string contentType)
            : this(data, contentType, null)
        {
        }

        public JsonNetResult(object data, string contentType, Encoding encoding)
        {
            this.SerializerSettings = new JsonSerializerSettings();

            this.Data = data;
            this.ContentType = contentType;
            this.ContentEncoding = encoding;
        }

        #endregion

        #region Properties

        public Encoding ContentEncoding { get; set; }

        public string ContentType { get; set; }

        public object Data { get; set; }

        public Formatting Formatting { get; set; }

        public JsonSerializerSettings SerializerSettings { get; set; }

        #endregion

        #region Public Methods

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await Task.Factory.StartNew(() =>
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }

                var response = context.HttpContext.Response;

                response.ContentType = !string.IsNullOrEmpty(this.ContentType) ? this.ContentType : "application/json";

                if (this.Data != null)
                {
                    using (var tw = new StreamWriter(response.Body))
                    {
                        var writer = new JsonTextWriter(tw) { Formatting = Formatting };
                        JsonSerializer serializer = JsonSerializer.Create(this.SerializerSettings);
                        serializer.Serialize(writer, this.Data);
                        writer.Flush();
                    }
                }
            });
        }

        #endregion
    }
}
