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


    [DeploymentItem("unico.webandloadtests\\LogInTestData.csv", "unico.webandloadtests")]
    [DataSource("LogInTestData", "Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\unico.webandloadtests\\LogInTestData.csv", Microsoft.VisualStudio.TestTools.WebTesting.DataBindingAccessMethod.Sequential, Microsoft.VisualStudio.TestTools.WebTesting.DataBindingSelectColumns.SelectOnlyBoundColumns, "LogInTestData#csv")]
    [DataBinding("LogInTestData", "LogInTestData#csv", "Login", "LogInTestData.LogInTestData#csv.Login")]
    [DataBinding("LogInTestData", "LogInTestData#csv", "Password", "LogInTestData.LogInTestData#csv.Password")]
    [DataBinding("LogInTestData", "LogInTestData#csv", "Result", "LogInTestData.LogInTestData#csv.Result")]
    [DataBinding("LogInTestData", "LogInTestData#csv", "Text", "LogInTestData.LogInTestData#csv.Text")]
    public class LogInWebTestCoded : WebTest
    {

        public LogInWebTestCoded()
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
            yield return request1;
            request1 = null;

            WebTestRequest request2 = new WebTestRequest("http://localhost:2489/Account/Login");
            request2.ThinkTime = 9;
            ExtractHiddenFields extractionRule1 = new ExtractHiddenFields();
            extractionRule1.Required = true;
            extractionRule1.HtmlDecode = true;
            extractionRule1.ContextParameterName = "1";
            request2.ExtractValues += new EventHandler<ExtractionEventArgs>(extractionRule1.Extract);
            yield return request2;
            request2 = null;

            WebTestRequest request3 = new WebTestRequest("http://localhost:2489/Account/Login");
            request3.ThinkTime = 13;
            request3.Method = "POST";
            request3.ExpectedResponseUrl = GetExpectedReturnUrl();
            FormPostHttpBody request3Body = new FormPostHttpBody();
            request3Body.FormPostParameters.Add("__RequestVerificationToken", this.Context["$HIDDEN1.__RequestVerificationToken"].ToString());
            request3Body.FormPostParameters.Add("Email", this.Context["LogInTestData.LogInTestData#csv.Login"].ToString());
            request3Body.FormPostParameters.Add("Password", this.Context["LogInTestData.LogInTestData#csv.Password"].ToString());
            request3Body.FormPostParameters.Add("RememberMe", this.Context["$HIDDEN1.RememberMe"].ToString());
            request3.Body = request3Body;
            if ((this.Context.ValidationLevel >= Microsoft.VisualStudio.TestTools.WebTesting.ValidationLevel.High))
            {
                ValidationRuleFindText validationRule3 = new ValidationRuleFindText();
                validationRule3.FindText = this.Context["LogInTestData.LogInTestData#csv.Text"].ToString();
                validationRule3.IgnoreCase = false;
                validationRule3.UseRegularExpression = false;
                validationRule3.PassIfTextFound = true;
                request3.ValidateResponse += new EventHandler<ValidationEventArgs>(validationRule3.Validate);
            }
            ExtractHiddenFields extractionRule2 = new ExtractHiddenFields();
            extractionRule2.Required = true;
            extractionRule2.HtmlDecode = true;
            extractionRule2.ContextParameterName = "1";
            request3.ExtractValues += new EventHandler<ExtractionEventArgs>(extractionRule2.Extract);
            yield return request3;
            request3 = null;
        }

        private string GetExpectedReturnUrl()
        {
            if (this.Context["LogInTestData.LogInTestData#csv.Result"].ToString() == "1")
            {
                return "http://localhost:2489/";
            }
            else
            {
                return "http://localhost:2489/Account/Login";
            }
        }
    }
}
