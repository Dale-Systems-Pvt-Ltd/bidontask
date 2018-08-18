using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mobileapp.ViewModels
{
	public class TermsAndConditionsViewModel : BindableBase
	{
        public TermsAndConditionsViewModel()
        {
            HtmlSource = BuildHtml();
        }

        private string htmlSource;
        public string HtmlSource
        {
            get { return htmlSource; }
            set { SetProperty(ref htmlSource, value); }
        }


        private string BuildHtml()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("<html>");
            str.AppendLine("<body>");
            str.AppendLine("<p>The Bid-On-Task terms and conditions outline BidOnTask.com and Your obligations and responsibilies on Bid-On-Task platform </p>");
            str.AppendLine("<p>Bid-On-Task operates an online platform allowing users to connect with other users who provide services</p>");

            str.AppendLine("</body>");
            str.AppendLine("</html>");

            return str.ToString();
        }

    }
}
