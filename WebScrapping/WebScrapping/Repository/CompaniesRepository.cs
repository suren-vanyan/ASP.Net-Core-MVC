using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebScrapping.Models;

namespace WebScrapping.Repository
{
    public class CompaniesRepository
    {
        public static async Task<List<Company>> SearchURLForAllCompaniesAsync(string url)
        {
            return await Task.Run(() => SearchURLForAllCompanies(url));

        }

        public static List<Company> SearchURLForAllCompanies(string url)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();

            //if you want to select all 240 companies remove comments  Method Scroll      
            doc.LoadHtml(Scrolling.Scroll(url));


            // doc = htmlWeb.Load(url);
            List<Company> allCompanies = null;

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class='company-action company_inner_right']");
            List<string> companyUrlList = new List<string>();
            try
            {
                // find the address of a particular company
                foreach (HtmlNode node in nodes)
                {
                    var jobUrl = node.SelectSingleNode(".//a").Attributes[0].Value;
                    companyUrlList.Add(@"https://staff.am" + jobUrl);

                }

                allCompanies = GetAllCompaniesWithTheirInfo(companyUrlList);
            }
            catch (Exception) { }

            return allCompanies;
        }

        public static List<Company> GetAllCompaniesWithTheirInfo(List<string> companyUrlList)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            List<Company> allCompanies = new List<Company>();
            foreach (var companyUrl in companyUrlList)
            {
                Company company = new Company();

                try
                {
                    string pathName = "//*[@class=\"company-title-views col-lg-10 col-md-10 col-sm-10\"]/h1";
                    string pathAbout = "//*[@class=\"col-lg-8 col-md-8 about-text\"]";
                    string pathIndustry = "//*[@class=\"professional-skills-description\"][1]";
                    string pathType = "//*[@class=\"professional-skills-description\"][2]";
                    string pathNumberOfEmployees = "//*[@class=\"professional-skills-description\"][3]";
                    string pathDateOfFoundation = "//*[@class=\"professional-skills-description\"][4]";
                    string regexTerms = @"[^:]*:\s+(.*)";
                    string regexDateOfFoundation = @"\D*(\d+)\D*";

                    string pathJobsHistory = "//*[@class=\"company-job-history\"]/span";
                    string html = GetHTMLCode(companyUrl);

                    company.Name = GetContentFromHtml(html, pathName);
                    company.AboutCompany = GetContentFromHtml(html, pathAbout);

                    company.Industry = GetContentFromHtml(html, pathIndustry);
                    company.Industry = company.Industry != null ?
                        Regex.Matches(company.Industry, regexTerms)[0].Groups[1].Value : null;

                    company.Type = GetContentFromHtml(html, pathType);
                    company.Type = company.Type != null ?
                        Regex.Matches(company.Type, regexTerms)[0].Groups[1].Value : null;

                    string num = GetContentFromHtml(html, pathNumberOfEmployees);
                    company.NumberOfEmployees = num != null ?
                        int.Parse(Regex.Matches(num, regexDateOfFoundation)[0].Groups[1].Value) : 0;

                    string date = GetContentFromHtml(html, pathDateOfFoundation);
                    company.DateOfFoundation = date != null ?
                        int.Parse(Regex.Matches(date, regexDateOfFoundation)[0].Groups[1].Value) : 0;

                    string jobHist = GetContentFromHtml(html, pathJobsHistory);
                    company.JobsHistory = jobHist != null ? int.Parse(jobHist) : 0;

                    HtmlDocument htmlDoc = htmlWeb.Load(companyUrl);
                    string companyProps = "//p[@class=\"professional-skills-description\"]";
                    HtmlNodeCollection htmlNodes = htmlDoc.DocumentNode.SelectNodes(companyProps);
                    List<string> nodeInnerText = htmlNodes.Select(node => node.InnerText.Replace("\n", "").ToLower()).ToList();
                    foreach (var innerText in nodeInnerText)
                    {

                        if (innerText.Contains("website")) company.WebSite = innerText;
                        if (innerText.Contains("address")) company.Adress = innerText;

                    }

                }
                catch (Exception) { }

                allCompanies.Add(company);
            }

            return allCompanies;
        }

        private static string GetHTMLCode(string Url)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url);
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();

            return result;
        }

        private static string GetContentFromHtml(string html, string xPath)
        {
            HtmlDocument code = new HtmlDocument();
            code.LoadHtml(html);
            try
            {
                return code.DocumentNode.SelectSingleNode(xPath).InnerText;
            }
            catch
            {
                return null;
            }
        }
    }


    //public class CompaniesRepository
    //{
    //    public static async Task<List<Company>> SearchURLForAllCompaniesAsync(string url)
    //    {
    //        return await Task.Run(() => SearchURLForAllCompanies(url));

    //    }

    //    public static List<Company> SearchURLForAllCompanies(string url)
    //    {
    //        HtmlWeb htmlWeb = new HtmlWeb();
    //        HtmlDocument doc = new HtmlDocument();

    //        //if you want to select all 240 companies remove comments  Method Scroll      
    //         doc.LoadHtml(Scrolling.Scroll(url));

            
    //       // doc = htmlWeb.Load(url);
    //        List<Company> allCompanies = null;

    //        HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class='company-action company_inner_right']");
    //        List<string> companyUrlList = new List<string>();
    //        try
    //        {
    //            // find the address of a particular company
    //            foreach (HtmlNode node in nodes)
    //            {
    //                var jobUrl = node.SelectSingleNode(".//a").Attributes[0].Value;
    //                companyUrlList.Add(@"https://staff.am" + jobUrl);

    //            }

    //            allCompanies = GetAllCompaniesWithTheirInfo(companyUrlList);
    //        }
    //        catch (Exception ) { }

    //        return allCompanies;
    //    }

    //    public static List<Company> GetAllCompaniesWithTheirInfo(List<string> companyUrlList)
    //    {
    //        HtmlWeb htmlWeb = new HtmlWeb();
    //        List<Company> allCompanies = new List<Company>();
    //        foreach (var companyUrl in companyUrlList)
    //        {
    //            Company company = new Company();

    //            try
    //            {
    //                // For example:compnayURL="https://staff.am/en/company/betconstruct"
    //                HtmlDocument htmlDoc = htmlWeb.Load(companyUrl);
   
    //                string companyProperties = "//p[@class=\"professional-skills-description\"]";
    //                // string companyProperties = "//div[@class='professional-skills-description']";                 
    //                HtmlNodeCollection htmlNodes = htmlDoc.DocumentNode.SelectNodes(companyProperties);

    //                string companyProp = "//div[@class='col-lg-8 col-md-8 about-text']";
    //                HtmlNodeCollection htmlNodesAboutComp = htmlDoc.DocumentNode.SelectNodes(companyProp);
    //                var textAboutComp = htmlNodesAboutComp.Select(i => i.InnerText.Replace("\n", "")).ToList();


    //                string companyName = "//h1[@class=\"text-left\"]";
    //                HtmlNodeCollection htmlNodeOfName = htmlDoc.DocumentNode.SelectNodes(companyName);

    //                List<string> nodeInnerText = htmlNodes.Select(node => node.InnerText.Replace("\n", "").ToLower()).ToList();
    //                foreach (var innerText in nodeInnerText)
    //                {
    //                    if (innerText.Contains("industry")) company.Industry = innerText;
    //                    if (innerText.Contains("type")) company.Type = innerText;
    //                    if (innerText.Contains("number of employees")) company.NumbOfEmployees = innerText;
    //                    if (innerText.Contains("foundation")) company.DataOfFoundation = innerText;
    //                    if (innerText.Contains("website")) company.WebSite = innerText;
    //                    if (innerText.Contains("address")) company.Adress = innerText;

    //                }

    //                List<string> nodeofName = htmlNodeOfName.Select(item => item.InnerText).ToList();
    //                if (nodeofName != null) company.Name = nodeofName[0];
    //                if (textAboutComp != null) company.AboutCompany = textAboutComp[0];

    //            }      
    //            catch (Exception ) {  }

    //            allCompanies.Add(company);
    //        }

    //        return allCompanies;
    //    }
    //}
}
