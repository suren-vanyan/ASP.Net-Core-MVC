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
            
            doc.LoadHtml(Scrolling.Scroll(url));

            
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


                    HtmlDocument document = htmlWeb.Load(companyUrl);


                    company.Name = GetContentFromHtml(document, pathName);
                    company.AboutCompany = GetContentFromHtml(document, pathAbout).Trim('\r', '\n', '\t');

                    company.Industry = GetContentFromHtml(document, pathIndustry);
                    company.Industry = company.Industry != null ?
                        Regex.Matches(company.Industry, regexTerms)[0].Groups[1].Value : null;

                    company.Type = GetContentFromHtml(document, pathType);
                    company.Type = company.Type != null ?
                        Regex.Matches(company.Type, regexTerms)[0].Groups[1].Value : null;

                    string num = GetContentFromHtml(document, pathNumberOfEmployees);
                    company.NumberOfEmployees = num != null ?
                        int.Parse(Regex.Matches(num, regexDateOfFoundation)[0].Groups[1].Value) : 0;

                    string date = GetContentFromHtml(document, pathDateOfFoundation);
                    company.DateOfFoundation = date != null ?
                        int.Parse(Regex.Matches(date, regexDateOfFoundation)[0].Groups[1].Value) : 0;

                    string jobHist = GetContentFromHtml(document, pathJobsHistory);
                    company.JobsHistory = jobHist != null ? int.Parse(jobHist) : 0;

                    string companyProps = "//p[@class=\"professional-skills-description\"]";
                    HtmlNodeCollection htmlNodes = document.DocumentNode.SelectNodes(companyProps);
                    List<string> nodeInnerText = htmlNodes.Select(item => item.InnerText.Replace("\n", "").ToLower()).ToList();
                    foreach (var innerText in nodeInnerText)
                    {

                        if (innerText.Contains("website")) company.WebSite = innerText.Replace("website", "");
                        if (innerText.Contains("address")) company.Adress = innerText.Replace("address:", "").Trim();

                    }
                    Console.WriteLine();
                }
                catch (Exception) { }

                if(company.Type!=null&&company.Industry!=null&&company.Name!=null)
                allCompanies.Add(company);
            }

            return allCompanies;
        }

        private static string GetContentFromHtml(HtmlDocument document, string xPath)
        {

            try
            {
                return document.DocumentNode.SelectSingleNode(xPath).InnerText;
            }
            catch
            {
                return null;
            }
        }
    }


   
}
