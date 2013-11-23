﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.17929
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Unico.WebAndLoadTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.WebTesting;
    using Microsoft.VisualStudio.TestTools.WebTesting.Rules;


    [DeploymentItem("unico.webandloadtests\\ShoppingCartTestData.csv", "unico.webandloadtests")]
    [DataSource("ShoppingCartTestData", "Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\unico.webandloadtests\\ShoppingCartTestData.csv", Microsoft.VisualStudio.TestTools.WebTesting.DataBindingAccessMethod.Sequential, Microsoft.VisualStudio.TestTools.WebTesting.DataBindingSelectColumns.SelectOnlyBoundColumns, "ShoppingCartTestData#csv")]
    [DataBinding("ShoppingCartTestData", "ShoppingCartTestData#csv", "Login", "ShoppingCartTestData.ShoppingCartTestData#csv.Login")]
    [DataBinding("ShoppingCartTestData", "ShoppingCartTestData#csv", "Password", "ShoppingCartTestData.ShoppingCartTestData#csv.Password")]
    [DataBinding("ShoppingCartTestData", "ShoppingCartTestData#csv", "AddProductId1", "ShoppingCartTestData.ShoppingCartTestData#csv.AddProductId1")]
    [DataBinding("ShoppingCartTestData", "ShoppingCartTestData#csv", "AddProductId2", "ShoppingCartTestData.ShoppingCartTestData#csv.AddProductId2")]
    [DataBinding("ShoppingCartTestData", "ShoppingCartTestData#csv", "TotalAmount1", "ShoppingCartTestData.ShoppingCartTestData#csv.TotalAmount1")]
    [DataBinding("ShoppingCartTestData", "ShoppingCartTestData#csv", "SetCount", "ShoppingCartTestData.ShoppingCartTestData#csv.SetCount")]
    [DataBinding("ShoppingCartTestData", "ShoppingCartTestData#csv", "SetProductId", "ShoppingCartTestData.ShoppingCartTestData#csv.SetProductId")]
    [DataBinding("ShoppingCartTestData", "ShoppingCartTestData#csv", "TotalAmount2", "ShoppingCartTestData.ShoppingCartTestData#csv.TotalAmount2")]
    public class ShoppingCartWebTestCoded : WebTest
    {
        public ShoppingCartWebTestCoded()
        {
            this.PreAuthenticate = true;
        }

        public override IEnumerator<WebTestRequest> GetRequestEnumerator()
        {
            // Инициализация правил проверки, применяемых ко всем запросам в веб-тесте
            if ((this.Context.ValidationLevel >= Microsoft.VisualStudio.TestTools.WebTesting.ValidationLevel.Low))
            {
                ValidateResponseUrl validationRule1 = new ValidateResponseUrl();
                this.ValidateResponse += new EventHandler<ValidationEventArgs>(validationRule1.Validate);
            }
            if ((this.Context.ValidationLevel >= Microsoft.VisualStudio.TestTools.WebTesting.ValidationLevel.Low))
            {
                ValidationRuleResponseTimeGoal validationRule2 = new ValidationRuleResponseTimeGoal();
                validationRule2.Tolerance = 0D;
                this.ValidateResponseOnPageComplete += new EventHandler<ValidationEventArgs>(validationRule2.Validate);
            }

            WebTestRequest request1 = new WebTestRequest("http://localhost:2489/");
            request1.ThinkTime = 13;
            yield return request1;
            request1 = null;

            WebTestRequest request2 = new WebTestRequest("http://localhost:2489/Account/Login");
            request2.ThinkTime = 11;
            ExtractHiddenFields extractionRule1 = new ExtractHiddenFields();
            extractionRule1.Required = true;
            extractionRule1.HtmlDecode = true;
            extractionRule1.ContextParameterName = "1";
            request2.ExtractValues += new EventHandler<ExtractionEventArgs>(extractionRule1.Extract);
            yield return request2;
            request2 = null;

            WebTestRequest request3 = new WebTestRequest("http://localhost:2489/Account/Login");
            request3.Method = "POST";
            request3.ExpectedResponseUrl = "http://localhost:2489/";
            FormPostHttpBody request3Body = new FormPostHttpBody();
            request3Body.FormPostParameters.Add("__RequestVerificationToken", this.Context["$HIDDEN1.__RequestVerificationToken"].ToString());
            request3Body.FormPostParameters.Add("Email", this.Context["ShoppingCartTestData.ShoppingCartTestData#csv.Login"].ToString());
            request3Body.FormPostParameters.Add("Password", this.Context["ShoppingCartTestData.ShoppingCartTestData#csv.Password"].ToString());
            request3Body.FormPostParameters.Add("RememberMe", this.Context["$HIDDEN1.RememberMe"].ToString());
            request3.Body = request3Body;
            yield return request3;
            request3 = null;

            WebTestRequest request4 = new WebTestRequest("http://localhost:2489/Category/Show");
            request4.ThinkTime = 2;
            request4.QueryStringParameters.Add("categoryId", "1", false, false);
            ExtractHiddenFields extractionRule2 = new ExtractHiddenFields();
            extractionRule2.Required = true;
            extractionRule2.HtmlDecode = true;
            extractionRule2.ContextParameterName = "1";
            request4.ExtractValues += new EventHandler<ExtractionEventArgs>(extractionRule2.Extract);
            yield return request4;
            request4 = null;

            WebTestRequest request5 = new WebTestRequest("http://localhost:2489/ShoppingCart/AddProduct");
            request5.ThinkTime = 2;
            request5.QueryStringParameters.Add("count", "1", false, false);
            request5.QueryStringParameters.Add("productId", this.Context["ShoppingCartTestData.ShoppingCartTestData#csv.AddProductId1"].ToString(), false, false);
            request5.QueryStringParameters.Add("X-Requested-With", "XMLHttpRequest", false, false);
            yield return request5;
            request5 = null;

            WebTestRequest request6 = new WebTestRequest("http://localhost:2489/ShoppingCart/AddProduct");
            request6.ThinkTime = 6;
            request6.QueryStringParameters.Add("count", "1", false, false);
            request6.QueryStringParameters.Add("productId", this.Context["ShoppingCartTestData.ShoppingCartTestData#csv.AddProductId2"].ToString(), false, false);
            request6.QueryStringParameters.Add("X-Requested-With", "XMLHttpRequest", false, false);
            yield return request6;
            request6 = null;

            WebTestRequest request7 = new WebTestRequest("http://localhost:2489/ShoppingCart");
            request7.ThinkTime = 30;
            if ((this.Context.ValidationLevel >= Microsoft.VisualStudio.TestTools.WebTesting.ValidationLevel.High))
            {
                ValidationRuleFindText validationRule3 = new ValidationRuleFindText();
                validationRule3.FindText = "<label for=\"amount\">"+
                    this.Context["ShoppingCartTestData.ShoppingCartTestData#csv.TotalAmount1"];
                validationRule3.IgnoreCase = false;
                validationRule3.UseRegularExpression = false;
                validationRule3.PassIfTextFound = true;
                request7.ValidateResponse += new EventHandler<ValidationEventArgs>(validationRule3.Validate);
            }
            ExtractHiddenFields extractionRule3 = new ExtractHiddenFields();
            extractionRule3.Required = true;
            extractionRule3.HtmlDecode = true;
            extractionRule3.ContextParameterName = "1";
            request7.ExtractValues += new EventHandler<ExtractionEventArgs>(extractionRule3.Extract);
            yield return request7;
            request7 = null;

            WebTestRequest request8 = new WebTestRequest("http://localhost:2489/ShoppingCart/SetCount");
            request8.ThinkTime = 11;
            request8.Method = "POST";
            FormPostHttpBody request8Body = new FormPostHttpBody();
            request8Body.FormPostParameters.Add("count", this.Context["ShoppingCartTestData.ShoppingCartTestData#csv.SetCount"].ToString());
            request8Body.FormPostParameters.Add("productId", this.Context["ShoppingCartTestData.ShoppingCartTestData#csv.SetProductId"].ToString());
            request8Body.FormPostParameters.Add("X-Requested-With", "XMLHttpRequest");
            request8.Body = request8Body;
            if ((this.Context.ValidationLevel >= Microsoft.VisualStudio.TestTools.WebTesting.ValidationLevel.High))
            {
                ValidationRuleFindText validationRule4 = new ValidationRuleFindText();
                validationRule4.FindText = "<label for=\"amount\">"+
                    this.Context["ShoppingCartTestData.ShoppingCartTestData#csv.TotalAmount2"];
                validationRule4.IgnoreCase = true;
                validationRule4.UseRegularExpression = false;
                validationRule4.PassIfTextFound = true;
                request8.ValidateResponse += new EventHandler<ValidationEventArgs>(validationRule4.Validate);
            }
            yield return request8;
            request8 = null;
        }
    }
}