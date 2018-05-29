using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;

namespace StudentsFetcher.Turnitin
{
    class MyWebClient : WebClient
    {
        Uri _responseUri;

        public Uri ResponseUri
        {
            get { return _responseUri; }
        }


        protected override WebResponse GetWebResponse(WebRequest request)
        {
            WebResponse response = base.GetWebResponse(request);

            string header_contentDisposition = response.Headers["content-disposition"];
            if (header_contentDisposition != null)
            {
                string filename = new ContentDisposition(header_contentDisposition).FileName;
            }

            _responseUri = response.ResponseUri;
            return response;
        }
    }
}
